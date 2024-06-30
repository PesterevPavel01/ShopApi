using ShopApi.Domain.Interfaces;

namespace ShopApi.Domain.Entity
{
    public class Provider : IEntityId<int>, IAuditable
    {
        public int Id { get; set; }
        public int NumberPhone { get; set; }
        public int Fax { get; set; }
        public int Inn { get; set; }
        public string NameProvider { get; set; }
        public string additionally { get; set; }

        public List<Purchase> Purchase{ get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
