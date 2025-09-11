using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Builder;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Repository.Menus;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication
{
    public partial class PopupOptions : Form
    {
        private Menu menu;
        private List<Menu> orderList;
        private FrequentlyOrdered freq;
        private Menu selectedSize;
        public event EventHandler<List<Menu>> orderListEvent;
        public PopupOptions(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            this.orderList = new List<Menu>();

            displayPopup();
        }

        private void displayPopup()
        {
            IMenuRepository menuRepository = new MenuRepository();
            if (menu.MenuDetailList.Count > 1)
            {
                SizeCard sc = new SizeCard(menu, menu.MenuDetailList);
                sc.Margin = new Padding(20, 0, 0, 0);
                sc.SizeSelected += (s, e) =>
                {
                    selectedSize = e;
                };
                flowPanel.Controls.Add(sc);
            }
            else
            {

                selectedSize = new PurchaseBuilder().Build(menu, menu.MenuDetailList[0]);
            }

            freq = new FrequentlyOrdered(menuRepository, menu);
            freq.Margin = new Padding(20, 30, 0, 0);
            flowPanel.Controls.Add(freq);

        }
        private void closePopup(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void confirmOrder(object sender, EventArgs e)
        {

            if (selectedSize == null || menu.MenuDetailList.Count < 1)
            {
                MessageBox.Show("no selected size (required)");
                return;
            }
            orderList.Add(selectedSize);
            List<Menu> md = freq.getFrequentlyOrderList();
            orderList.AddRange(md);

            orderListEvent?.Invoke(this, orderList);
            DialogResult = DialogResult.OK;
            //string json = JsonConvert.SerializeObject(orderList);
            //Console.WriteLine(json);
        }
    }
}