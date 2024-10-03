namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }

        public UserDeliveryInfo UserDeliveryInfo { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}
