namespace ShopApi.Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string?  Address{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Status { get; set; }
    }
}
