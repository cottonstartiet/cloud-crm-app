using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Contracts;

public record CreateContactRequest
{
    [Required]
    [Length(3, 50)]
    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }
    [Required]
    [Length(3, 50)]
    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }
}
