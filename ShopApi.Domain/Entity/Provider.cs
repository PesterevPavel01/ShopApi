namespace ShopApi.Domain.Entity
{
    public class Provider
    {
        public int Id { get; set; }
        public int NumberPhone { get; set; }
        public int Fax { get; set; }
        public int Inn { get; set; }
        public string NameProvider { get; set; } = "";
        public string? additionally { get; set; }

        public List<PurchaseOfGoods> purchaseOfGoods{ get; set; } = new List<PurchaseOfGoods>();
    }
}
