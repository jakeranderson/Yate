namespace Yate.WebDemo.PetShop.Models
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double Total
        {
            get
            {
                if (Product == null)
                {
                    return 0;
                }

                return Product.Price * Quantity;
            }
        }
    }
}