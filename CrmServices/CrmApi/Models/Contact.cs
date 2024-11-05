using System;

namespace CrmApi.Models;

public record Contact
{
  public required string Id { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
}
