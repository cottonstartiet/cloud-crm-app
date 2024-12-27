using System.ComponentModel.DataAnnotations;

namespace CrmApi.Contracts
{
    public class AddressContract
    {
        public required string Street { get; set; }
        public required string State { get; set; }
        [Required]
        public required string Country { get; set; }

    }
}
