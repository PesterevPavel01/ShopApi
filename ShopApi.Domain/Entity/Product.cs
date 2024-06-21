namespace ShopApi.Domain.Entity
    public class Product
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Price { get; set; } 
        public string Firm { get; set; } 
        public int CategoryId { get; set; }
    }
}
