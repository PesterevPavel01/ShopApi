namespace ShopApi.Domain.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; } 
        public string ExtraCharge { get; set; }
        public string Description { get; set; } 


        public List<Product> purchaseOfGoods { get; set; }

        //public List<Product> product { get; set; } = new List<Product>();

    }
}
