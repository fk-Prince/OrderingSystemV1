using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<bool> confirmOrder(OrderModel order)
        {
            return await orderRepository.saveNewOrder(order);
        }
        public async Task<List<OrderModel>> getAllOrders(string order_id)
        {
            bool existsting = await orderRepository.getOrderExists(order_id);
            if (!existsting)
            {
                throw new OrderNotFound("Order-ID not Found.");
            }
            bool isAvalable = await orderRepository.getOrderAvailable(order_id);
            if (!isAvalable)
            {
                throw new OrderInvalid("Order-ID expired.");
            }
            return await orderRepository.getOrders(order_id); ;
        }
        public async Task<bool> payOrder(string order_id, int staff_id, string payment_method)
        {
            return await orderRepository.payOrder(order_id, staff_id, payment_method);
        }
    }
}
