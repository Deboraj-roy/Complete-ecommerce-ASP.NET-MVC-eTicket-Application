﻿using eTicket.Models;

namespace eTicket.Data.Services.IServices
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrderByUserIdAsync(string userId);
    }
}
