﻿namespace ShopApi.Domain.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public EmployeeDto() { }

        public EmployeeDto(int id, string name, string address, string login, string password, string status) 
        {
            Id = id;
            NameEmployee = name;
            Address = address;
            Login = login;
            Password = password;
            Status = status;
        }
    }
}
