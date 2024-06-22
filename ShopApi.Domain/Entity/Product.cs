using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{ 
    public class Product : IEntityId<int>, IAuditable
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Price { get; set; } 
        public string Firm { get; set; } 
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
