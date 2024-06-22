using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{
    public class Employee : IEntityId<int>, IAuditable
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
