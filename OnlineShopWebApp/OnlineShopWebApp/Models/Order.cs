using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Nummer { get; set; }
        public OrderStatusesEnum Status { get; set; }
        public UserDeliveryInfo UserDeliveryInfo { get; set; }
        public List<CartItem> CartItems { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Cost
        {
            get
            {
                return CartItems.Sum(x => x.Cost);
            }
        }

        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatusesEnum.Created;
            DateCreated = DateTime.Now;
        }
    }
}
