﻿using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface IOrderRepository
    {
        bool getOrderAvailable(string order_id);
        bool getOrderExists(string order_id);
        List<OrderModel> getOrders(string order_id);
        bool saveNewOrder(OrderModel order);
        bool payOrder(string order_id, int staff_id, string payment_method);
    }
}
