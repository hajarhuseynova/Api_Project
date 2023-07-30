using ApiIntro.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntro.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }   
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; } 
    }
}
