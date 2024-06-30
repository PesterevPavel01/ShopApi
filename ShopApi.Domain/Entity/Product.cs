using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{ 
    public class Product : IEntityId<int>, IAuditable
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Price { get; set; } 
        public string Firm { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<Bascket> Basckets { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product() { }

        public Product(ProductDto productDto) 
        {
            Id = productDto.Id;
            Name = productDto.Name;
            Price = productDto.Price;
            Firm = productDto.Firm;
            CategoryId = productDto.CategoryId;
        }
    }
}
