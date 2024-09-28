using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    //public static class CartsRepository
    //{
    //    public static List<Cart> Carts = new List<Cart>();
    //    public static Cart TryGetByUserId(string userId)
    //    {
    //        return Carts.FirstOrDefault(x => x.UserId == userId);
    //    }
    //    public static void Add(Product product, string userId)
    //    {
    //        var existingCart = TryGetByUserId(userId);
    //        if (existingCart == null)
    //        {
    //            var newCart = new Cart
    //            {
    //                ProductId = Guid.NewGuid(),
    //                UserId = userId,
    //                CartItems = new List<CartItem>
    //                {
    //                    new CartItem
    //                    {
    //                        Id = Guid.NewGuid(),
    //                        Amount = 1,
    //                        Product = product
    //                    }
    //                }
    //            };

    //            Carts.Add(newCart);
    //        }
    //        else
    //        {
    //            var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
    //            if (existingCartItem != null)
    //            {
    //                existingCartItem.Amount += 1;
    //            }
    //            else
    //            {
    //                existingCart.CartItems.Add(new CartItem
    //                {
    //                    Id = Guid.NewGuid(),
    //                    Amount = 1,
    //                    Product = product
    //                });
    //            }
    //        }
    //    }

    //    internal static void Remove(Product product, string userId)
    //    {
    //        var existingCart = TryGetByUserId(userId);
    //        if (existingCart != null)
    //        {
    //            var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
    //            if (existingCartItem != null)
    //            {
    //                if (existingCartItem.Amount > 1)
    //                {
    //                    existingCartItem.Amount -= 1;
    //                }
    //                else
    //                {
    //                    existingCart.CartItems.Remove(existingCartItem);
    //                }
    //            }
    //        }
    //    }
    //}
    public class CartsInMemoryRepository : ICartsRepository
    {
        private List<Cart> _carts;
        public CartsInMemoryRepository()
        {
            _carts = new List<Cart>();
        }
        public List<Cart> Carts
        {
            get { return _carts; }
        }
        public Cart TryGetByUserId(string userId)
        {
            return Carts.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    ProductId = Guid.NewGuid(),
                    UserId = userId,
                    CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };

                Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.CartItems.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }

        public void Remove(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    if (existingCartItem.Amount > 1)
                    {
                        existingCartItem.Amount -= 1;
                    }
                    else
                    {
                        existingCart.CartItems.Remove(existingCartItem);
                    }
                }
            }
        }
        public void CleanCartRepository()
        {
            _carts.Clear();
        }
    }
}
