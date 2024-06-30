using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{
    public class Category : IEntityId<int>, IAuditable
    {
        public int Id { get; set; }
        public string NameCategory { get; set; } 
        public string ExtraCharge { get; set; }
        public string Description { get; set; } 

        public List<Product> Products { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
