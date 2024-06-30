using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{
    public class Bascket : BascketDto, IEntityId<int>, IAuditable
    {

        public Bascket(BascketDto bascketDto ) 
        {
            Number = bascketDto.Number;
            EmployeeId = bascketDto.EmployeeId;
            ProductId = bascketDto.ProductId;
        }

        public Bascket() { }

        public int Id { get; set; }
        public double Number { get; set; } 
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }

        public Employee Employee { get; set; }
        public Product Product { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
