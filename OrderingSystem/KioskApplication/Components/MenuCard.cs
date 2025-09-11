using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication.Cards
{
    public partial class MenuCard : Guna2Panel

    {
        private Menu menu;
        public event EventHandler<List<Menu>> orderList;

        public MenuCard(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            displayMenu();
            cardLayout();
        }

        private void cardLayout()
        {
            BorderRadius = 8;
            BorderThickness = 1;
            BorderColor = Color.FromArgb(34, 34, 34);
            FillColor = Color.White;

            handleClicked(this);
            hoverEffects(this);
        }

        private void handleClicked(Control c)
        {
            c.Click += menuClicked;
            foreach (Control cc in c.Controls)
            {
                handleClicked(cc);
            }
        }

        private void menuClicked(object sender, EventArgs b)
        {
            PopupOptions popup = new PopupOptions(menu);
            popup.orderListEvent += (s, e) =>
            {
                orderList?.Invoke(this, e);
            };
            DialogResult res = popup.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                popup.Hide();
            }
        }

        private void hoverEffects(Control c)
        {
            c.MouseEnter += (s, e) => { BorderColor = Color.FromArgb(94, 148, 255); };
            c.MouseLeave += (s, e) => { BorderColor = Color.FromArgb(34, 34, 34); };
            c.Cursor = Cursors.Hand;

            foreach (Control cc in c.Controls)
            {
                hoverEffects(cc);
            }
        }

        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            price.Text = (menu.MenuDetailList[0].Price - (menu.MenuDetailList[0].Price * menu.MenuDetailList[0].DiscountRate)).ToString("C", new CultureInfo("en-PH"));
            if (menu.MenuDetailList[0].DiscountRate != 0.00)
            {
                off.Visible = true;
                off.Text = (menu.MenuDetailList[0].DiscountRate * 100).ToString("0") + "%";
            }
            else
            {
                off.Visible = true;
            }
            description.Text = menu.MenuDescription;
            menuName.ForeColor = Color.Black;
            price.ForeColor = Color.Black;
            description.ForeColor = Color.Black;
        }
    }
}
