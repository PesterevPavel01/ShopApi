using ShopApi.Domain.Entity;

namespace ShopApi.Domain.Dto
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int Prise { get; set; }
        public string Volume { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public PurchaseDto() { }

        public PurchaseDto(int id, int purchasePrise, string purchaseVolume, string purchaseType, string purchaseDescription)
        {
            Id = id;
            Prise = purchasePrise;
            Volume = purchaseVolume;
            Type = purchaseType;
            Description = purchaseDescription;
        }
        public PurchaseDto(Purchase purchase)
        {
            this.Id = purchase.Id;
            this.Prise = purchase.Prise;
            this.Description = purchase.Description;
            this.Volume = purchase.Volume;
            this.Type = purchase.Type;

        }
    }
}
