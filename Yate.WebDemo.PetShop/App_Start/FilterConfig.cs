using System.Web;
using System.Web.Mvc;

namespace Yate.WebDemo.PetShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}