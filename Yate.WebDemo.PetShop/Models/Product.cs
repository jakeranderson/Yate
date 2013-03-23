using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yate.WebDemo.PetShop.Models
{
    public class Product
    {
        public Product()
        {
            Features = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ZoomImagePath { get; set; }
        public double Price { get; set; }
        public bool IsPromotion { get; set; }
        public IList<string> Features { get; set; }
        public string Category { get; set; }
    }
}