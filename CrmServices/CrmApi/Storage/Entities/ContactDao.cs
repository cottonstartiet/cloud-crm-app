namespace CrmApi.Storage.Entities
{
    public class ContactDao : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
