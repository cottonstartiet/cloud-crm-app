using System.ComponentModel.DataAnnotations;

namespace CrmApi.Contracts;

public record CreateContactRequest
{
    [Required]
    [Length(3, 50)]
    public required string FirstName { get; init; }
    [Required]
    [Length(3, 50)]
    public required string LastName { get; init; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    public AddressContract? ConactAddress { get; set; }
}
