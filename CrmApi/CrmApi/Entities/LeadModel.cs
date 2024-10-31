using System.Text.Json.Serialization;

namespace CrmApi.Entities
{
    public class LeadModel : BaseEntity
    {
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }
        [JsonPropertyName("dob")]
        public DateOnly DoB { get; set; }
        [JsonPropertyName("primaryPhone")]
        public required string PrimaryPhone { get; set; }
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("alternateEmail")]
        public required string AlternameEmail { get; set; }
    }
}
