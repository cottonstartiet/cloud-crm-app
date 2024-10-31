using System.Text.Json.Serialization;

namespace CrmApi.Entities
{
    public class BaseEntity
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("pk")]
        public required string PartitionKey { get; set; }
    }
}
