using System.Text.Json.Serialization;

namespace CrmApi.Storage.Entities
{
    public class BaseEntity
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("pk")]
        public required string Pk { get; set; }
    }
}
