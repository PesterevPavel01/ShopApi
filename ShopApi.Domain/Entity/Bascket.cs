namespace ShopApi.Domain.Entity
{
    public class Bascket
    {
        public int Id { get; set; }
        public double Number { get; set; } 
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }

        public List<Employee> Employee { get; set; }

        public List<Product> Product { get; set; }
    }
}
