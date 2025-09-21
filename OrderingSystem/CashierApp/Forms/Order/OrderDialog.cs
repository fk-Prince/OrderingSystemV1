using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms.Order
{
    public partial class OrderDialog : Form
    {
        private List<OrderModel> om;
        private OrderServices orderServices;
        public List<OrderModel> OrderList => om;

        public OrderDialog(OrderServices orderServices)
        {
            InitializeComponent();
            this.orderServices = orderServices;
        }
        private async void getOrderButton(object sender, EventArgs e)
        {
            try
            {
                string orderId = txt.Text.Trim();
                om = await orderServices.getAllOrders(orderId);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) when (ex is OrderInvalid || ex is OrderNotFound)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
