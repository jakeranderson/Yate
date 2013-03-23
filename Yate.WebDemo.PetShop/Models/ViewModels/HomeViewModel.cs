using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yate.WebDemo.PetShop.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FeatureProducts { get; set; }
        public IEnumerable<Product> NewestProducts { get; set; }
    }
}