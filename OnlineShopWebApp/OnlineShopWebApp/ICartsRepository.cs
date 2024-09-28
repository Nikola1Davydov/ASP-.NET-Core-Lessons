﻿using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository 
    {
        List<Cart> InMemoryCartsRepository { get; }
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Remove(Product product, string userId);
        void CleanCartRepository();
    }
}
