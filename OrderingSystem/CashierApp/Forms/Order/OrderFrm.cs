using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.Order;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.Order;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class OrderFrm : Form
    {
        private DataTable table;
        private int staff_id = 1; // to be change
        private string order_id;
        private readonly OrderServices orderServices;

        public OrderFrm(IOrderRepository orderRepository)
        {
            InitializeComponent();
            orderServices = new OrderServices(orderRepository);
            initTable();
        }

        private void initTable()
        {
            table = new DataTable();
            table.Columns.Add("Order-ID");
            table.Columns.Add("Name");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
            table.Columns.Add("Total Amount", typeof(string));
            dataGrid.DataSource = table;
        }
        public static OrderFrm orderFactory()
        {
            IOrderRepository orderRepository = new OrderRepository();
            return new OrderFrm(orderRepository);
        }
        private void displayOrders(object sender, System.EventArgs e)
        {
            IOrderRepository orderRepository = new OrderRepository();
            OrderDialog od = new OrderDialog(orderServices);
            od.ShowDialog(this);

            if (od.DialogResult == DialogResult.OK)
            {
                List<OrderModel> om = od.OrderList;

                if (om.Count > 0)
                {
                    order_id = om[0].Order_id;
                    foreach (var order in om)
                    {
                        DataRow row = table.NewRow();
                        row["Order-ID"] = order.Order_id;
                        row["Name"] = order.Menu_name;
                        row["Price"] = order.PricePerQuantity;
                        row["Quantity"] = order.Quantity;
                        row["Total Amount"] = order.TotalPrice;
                        table.Rows.Add(row);
                    }
                    double subtotald = om.Sum(o => o.TotalPrice);
                    double couponRated = om.Sum(o => o.TotalPrice * o.CouponRate);
                    double vatd = om.Sum(o => (o.TotalPrice - o.CouponRate) * 0.12);
                    double totald = (subtotald - couponRated) + vatd;
                    subtotal.Text = subtotald.ToString("N2");
                    coupon.Text = couponRated.ToString("N2");
                    vat.Text = vatd.ToString("N2");
                    total.Text = totald.ToString("N2");
                }
            }
        }
        private void reset(object sender, System.EventArgs e)
        {
            table.Clear();
            subtotal.Text = "0.00";
            coupon.Text = "0.00";
            vat.Text = "0.00";
            total.Text = "0.00";
        }
        private void cashPayment(object sender, System.EventArgs e)
        {
            string method = "cash";
            payment(method);
        }
        private void creditCardPayment(object sender, System.EventArgs e)
        {
            string method = "credit-card";
            payment(method);
        }
        private async void payment(string payment_method)
        {
            try
            {
                bool result = await orderServices.payOrder(order_id, staff_id, payment_method);
                if (result) MessageBox.Show("Payment Success");
                else MessageBox.Show("Payment Failed");
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
    }
}
