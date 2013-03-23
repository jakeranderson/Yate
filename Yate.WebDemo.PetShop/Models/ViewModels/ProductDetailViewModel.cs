using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yate.WebDemo.PetShop.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {
            RelatedProducts = new List<Product>();
        }

        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}