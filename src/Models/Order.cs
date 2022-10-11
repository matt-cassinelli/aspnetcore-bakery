using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace Bakery.Models;

public class Order
{
    [BindNever]
    public int Id { get; set; }

    public List<OrderLine>? OrderLines { get; set; }

    [StringLength(50)]
    [Display(Name = "First name")]
    [Required(ErrorMessage = "Please enter your first name")]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50)]
    [Display(Name = "Last name")]
    [Required(ErrorMessage = "Please enter your last name")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100)]
    [Display(Name = "Address line 1")]
    [Required(ErrorMessage = "Please enter your address")]
    public string AddressLine1 { get; set; } = string.Empty;

    [StringLength(100)]
    [Display(Name = "Address line 2")]
    public string? AddressLine2 { get; set; }

    [StringLength(10, MinimumLength = 4)]
    [Required(ErrorMessage = "Please enter your postcode")]
    public string Postcode { get; set; } = string.Empty;

    [StringLength(50)]
    [Display(Name = "Town / city")]
    [Required(ErrorMessage = "Please enter your town or city")]
    public string Town { get; set; } = string.Empty;

    [StringLength(50)]
    [Required(ErrorMessage = "Please enter your country")]
    public string Country { get; set; } = string.Empty;

    [StringLength(25)]
    [Display(Name = "Phone number")]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Please enter your phone number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]

    [RegularExpression(
        @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
       ErrorMessage = "The email address is not entered in a correct format"
    )]
    public string Email { get; set; } = string.Empty;

    [BindNever]
    public decimal Total { get; set; }

    [BindNever]
    public DateTime Placed { get; set; }
}