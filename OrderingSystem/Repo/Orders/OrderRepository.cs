using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Order
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<bool> getOrderAvailable(string order_id)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = await db.getConnection();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) as c FROM orders WHERE order_id = @order_id AND available_until > NOW()", conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            return reader.GetInt32("c") > 0;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                await db.closeConnection();
            }
            return false;
        }

        public async Task<bool> getOrderExists(string order_id)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = await db.getConnection();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) as c FROM orders WHERE order_id = @order_id", conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            return reader.GetInt32("c") > 0;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                await db.closeConnection();
            }
            return false;
        }

        public async Task<List<OrderModel>> getOrders(string order_id)
        {
            List<OrderModel> orderList = new List<OrderModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = await db.getConnection();
                using (var cmd = new MySqlCommand("p_retrieve_order_v2", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_order_id", order_id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            OrderModel om = OrderModel.Builder()
                                .SetOrderId(reader.GetString("order_id"))
                                .SetMenuName(reader.GetString("menu_name"))
                                .SetTotalPrice(reader.GetDouble("total_price"))
                                .SetPricePerQuantity(reader.GetDouble("price"))
                                .SetQuantity(reader.GetInt32("quantity"))
                                .SetCouponRate(reader.GetDouble("coupon_rate"))
                                .Build();

                            orderList.Add(om);
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                await db.closeConnection();
            }
            return orderList;
        }

        public async Task<bool> saveNewOrder(OrderModel order)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = await db.getConnection();
                using (var cmd = new MySqlCommand("p_New_Order", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    Console.Write(order.JsonOrderList());
                    cmd.Parameters.AddWithValue("@p_json_orderList", order.JsonOrderList());
                    if (order.Coupon != null)
                    {
                        cmd.Parameters.AddWithValue("@p_coupon_code", order.Coupon.CouponCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@p_coupon_code", DBNull.Value);
                    }
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                await db.closeConnection();
            }
        }

        public async Task<bool> payOrder(string order_id, int staff_id, string payment_method)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = await db.getConnection();
                using (var cmd = new MySqlCommand("p_Confirm_Payment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_order_id ", order_id);
                    cmd.Parameters.AddWithValue("@p_staff_id", staff_id);
                    cmd.Parameters.AddWithValue("@p_payment_method ", payment_method);
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                await db.closeConnection();
            }

        }
    }
}
