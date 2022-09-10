using Microsoft.EntityFrameworkCore;

namespace Bakery.Models;

public class Basket : IBasket
{
    private readonly MyDbContext _context;

    private Basket(MyDbContext context)
    {
        _context = context; // DI
    }

    public string? Id { get; set; } // TODO: Should this be a Guid? instead?

    public List<BasketItem> Items { get; set; } = default!;
    //public List<BasketItem> Items
    //{
    //    get {
    //        return _context.BasketItems
    //            .Where(c => c.BasketId == Id)
    //            .Include(s => s.Product)
    //            .ToList();
    //    }
    //}

    public static Basket GetBasket(IServiceProvider services) // TODO: Maybe this should be in the constructor instead?
    {
        MyDbContext context = services.GetService<MyDbContext>() ?? throw new Exception("Error initialising"); // Why are we getting the context here when there is already a field for it in the class?

        // Check if BasketId Guid exists in session (browser cookie), if not then create it.
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
        string basketId = session?.GetString("BasketId") ?? Guid.NewGuid().ToString();
        session?.SetString("BasketId", basketId);

        return new Basket(context) { Id = basketId };
    }

    public void AddItem(Product product)
    {
        var basketItem = _context.BasketItems
            .SingleOrDefault(s => s.Product.Id == product.Id && s.BasketId == Id);

        if (basketItem != null)
        {
            basketItem.Amount++;
        }
        else
        {
            basketItem = new BasketItem
            {
                BasketId = Id,
                Product = product,
                Amount = 1
            };
            _context.BasketItems.Add(basketItem);
        }
        _context.SaveChanges();
    }

    public void RemoveItem(Product product) // NOTE: I removed 'local amount' int return type from here.
    {
        var basketItem = _context.BasketItems
            .SingleOrDefault(s => s.Product.Id == product.Id && s.BasketId == Id);

        if (basketItem == null) { return; }

        if (basketItem.Amount > 1)
        {
            basketItem.Amount--;
        }
        else
        {
            _context.BasketItems.Remove(basketItem);
        }
        _context.SaveChanges();
    }

    public List<BasketItem> GetItems() // TODO: Make this private? Where is it used?
    {
        Items = _context.BasketItems
            .Where(c => c.BasketId == Id)
            .Include(s => s.Product)
            .ToList();

        return Items;
    }

    public void Clear()
    {
        var basketItems = _context.BasketItems
            .Where(bi => bi.BasketId == Id);

        _context.BasketItems.RemoveRange(basketItems);

        _context.SaveChanges();
    }

    public decimal GetTotal()
    {
        var total = _context.BasketItems
            .Where(c => c.BasketId == Id)
            .Select(c => c.Product.Price * c.Amount)
            .Sum();

        return total;
    }
}