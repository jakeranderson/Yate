using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yate.WebDemo.PetShop.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult GetProduct(string productName, int id)
        {
            var viewModel = new Models.ViewModels.ProductDetailViewModel { Product = Products.Single(p => p.Id == id) };

            return View("details", viewModel);
        }
    }
}
