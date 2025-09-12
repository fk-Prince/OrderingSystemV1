using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Builder;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication
{
    public partial class PopupOptions : Form
    {
        private Menu menu;
        private List<Menu> orderList;
        private FrequentlyOrderedLayout freq;
        private Menu selectedSize;
        public event EventHandler<List<Menu>> orderListEvent;
        private RemoveableIngredientLayout r;
        private List<Ingredient> removeIngredients;
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
                SizeLayout sc = new SizeLayout(menu, menu.MenuDetailList);
                sc.Margin = new Padding(20, 0, 0, 0);
                sc.SizeSelected += (s, e) =>
                {
                    selectedSize = e;
                    displayR(selectedSize);
                };
                sc.defaultSelection();
                flowPanel.Controls.Add(sc);
            }
            else
            {

                selectedSize = new PurchaseBuilder().Build(menu, menu.MenuDetailList[0]);
            }

            freq = new FrequentlyOrderedLayout(menuRepository, menu);
            freq.Margin = new Padding(20, 30, 0, 0);
            flowPanel.Controls.Add(freq);

            displayR(selectedSize);
        }

        private void displayR(Menu m)
        {
            if (m.MenuDetail == null) return;
            if (r != null && flowPanel.Controls.Contains(r))
            {
                flowPanel.Controls.Remove(r);
            }
            r = new RemoveableIngredientLayout(m);
            r.Margin = new Padding(20, 30, 0, 0);
            flowPanel.Controls.Add(r);
            //flowPanel.Controls.SetChildIndex(r, flowPanel.Controls.Count - 1);

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
            if (r != null)
            {
                selectedSize.MenuDetail.RemoveIngredientList = r.getRemoveIngredient();
            }
            orderList.Add(selectedSize);
            List<Menu> md = freq.getFrequentlyOrderList();
            orderList.AddRange(md);
            orderListEvent?.Invoke(this, orderList);
            //string json = JsonConvert.SerializeObject(orderList);
            //Console.WriteLine(json);
            DialogResult = DialogResult.OK;
        }
    }
}