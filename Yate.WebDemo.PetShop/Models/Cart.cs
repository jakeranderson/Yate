using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yate.WebDemo.PetShop.Models
{
    public class Cart
    {
        public IList<LineItem> LineItems { get; set; }

        public Cart()
        {
            LineItems = new List<LineItem>();
        }

        public double SubTotal
        {
            get
            {
                return LineItems.Sum(li => li.Total);
            }
        }

        public double Tax
        {
            get
            {
                return SubTotal * .0912;
            }
        }

        public double Total
        {
            get
            {
                return SubTotal + Tax;
            }
        }
    }
}