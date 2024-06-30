using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string ExtraCharge { get; set; }
        public string Description { get; set; }


        public CategoryDto() { }

        public CategoryDto(int id, string nameCategory, string extraCharge, string description)
        {
            Id = id;
            NameCategory = nameCategory;
            ExtraCharge = extraCharge;
            Description = description;
        }
    }
}
