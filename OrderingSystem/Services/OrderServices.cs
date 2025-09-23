﻿using System.Collections.Generic;
using OrderingSystem.Exceptions;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.KioskApplication.Services
{
    public class OrderServices
    {
        private readonly IOrderRepository orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool confirmOrder(OrderModel order)
        {
            return orderRepository.saveNewOrder(order);
        }
        public List<OrderModel> getAllOrders(string order_id)
        {
            bool existsting = orderRepository.getOrderExists(order_id);
            if (!existsting)
            {
                throw new OrderNotFound("Order-ID not Found.");
            }
            bool isAvalable = orderRepository.getOrderAvailable(order_id);
            if (!isAvalable)
            {
                throw new OrderInvalid("Order-ID expired.");
            }
            return orderRepository.getOrders(order_id); ;
        }
        public bool payOrder(string order_id, int staff_id, string payment_method)
        {
            return orderRepository.payOrder(order_id, staff_id, payment_method);
        }
    }
}
