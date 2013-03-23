using System.Collections.Generic;
using System.Web.Mvc;
using Yate.WebDemo.PetShop.Models;

namespace Yate.WebDemo.PetShop.Controllers
{
    public class BaseController : Controller
    {
        public IEnumerable<Product> Products;

        public BaseController()
        {
            Products = new List<Product>
                {
                    new Product
                        {
                            Id=1,
                            ImagePath = "/images/products/whippet.jpg",
                            ZoomImagePath = "/images/products/whippet_zoom.jpg",
                            IsPromotion = true,
                            Name="Whippet",
                            Price = 449.97,
                            ShortDescription = "The Whippet is the best bread of dog in the world.",
                            Description = "The Whippet (also English Whippet or Snap dog) is a breed of medium-sized dog. They are a sighthound breed that originated in England, where they descended from greyhounds. Whippets today still strongly resemble a smaller greyhound. Shown in the Hound group, Whippets have relatively few health problems other than arrhythmia. Whippets also participate in dog sports such as lure coursing, agility, and flyball.  Whippets were originally greyhounds that were deemed unsuitable for hunting because of their size. They were returned to their peasant breeders after being maimed so that they could not be used to hunt and break the Forest law. These maimed dogs were bred together and used to catch rats, and hunt rabbits. When the Forest law was repealed, these \"miniature greyhounds\" became popular in the sport of dog racing. This has led to Whippets being described as \"the poor man's racehorse.\" They are still frequently used as racing dogs today, as they have the highest running speed of breeds their weight: 35 miles per hour (56 km/h). [taken from wikipedia]",
                            Features = new List<string>{"They are awesome","Sleep a lot","Run fast","Don't bark"},
                            Category = "Dogs"
                        }
                };

        }
    }

}