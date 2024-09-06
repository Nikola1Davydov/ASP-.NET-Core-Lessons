namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }
        public decimal TotalCost { get; }
        public Cart ()
        {
            TotalCost = Products.Sum(x => x.Cost);
        }
    }
}
