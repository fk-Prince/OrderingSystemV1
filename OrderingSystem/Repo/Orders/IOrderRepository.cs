using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface IOrderRepository
    {
        Task<bool> getOrderAvailable(string order_id);
        Task<bool> getOrderExists(string order_id);
        Task<List<OrderModel>> getOrders(string order_id);
        Task<bool> saveNewOrder(OrderModel order);
        Task<bool> payOrder(string order_id, int staff_id, string payment_method);
    }
}
