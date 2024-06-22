using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{ 
    public class Purchase : IEntityId<int>, IAuditable
    {
        public int Id { get; set; }
        public int PurchasePrise { get; set; }
        public string PurchaseVolume { get; set; }
        public string PurchaseType { get; set; }
        public string PurchaseDescription { get; set; }


        public Provider Providers { get; set; }
        public Category Categories{ get; set; }
        public List<Product> Products{ get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
