using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{ 
    public class Purchase : IEntityId<int>, IAuditable
    {
        public Purchase()
        {
        }

        public Purchase(PurchaseDto purchaseDto) 
        {
            Id = purchaseDto.Id;
            Prise=purchaseDto.Prise;
            Volume= purchaseDto.Volume;
            Type= purchaseDto.Type;
            Description=purchaseDto.Description;
        }

        public int Id { get; set; }
        public int Prise { get; set; }
        public string Volume { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }


        public Provider Providers { get; set; }
        public Category Categories{ get; set; }
        public List<Product> Products{ get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
