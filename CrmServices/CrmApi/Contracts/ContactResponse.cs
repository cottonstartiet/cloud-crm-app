namespace CrmApi.Contracts;

public record ContactResponse
{
    public required string Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}
