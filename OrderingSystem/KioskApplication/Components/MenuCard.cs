using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication.Cards
{
    public partial class MenuCard : Guna2Panel

    {
        private MenuDetailModel menu;
        private IMenuRepository menuRepository;
        public event EventHandler<List<MenuDetailModel>> orderListEvent;


        public MenuDetailModel Menu => menu;

        public MenuCard(IMenuRepository menuRepository, MenuDetailModel menu)
        {
            InitializeComponent();
            this.menuRepository = menuRepository;
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
            PopupOptions popup = new PopupOptions(menuRepository, menu);
            popup.orderListEvent += (s, e) =>
            {
                orderListEvent?.Invoke(this, e);
            };
            DialogResult res = popup.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                popup.Hide();
            }
        }

        private void hoverEffects(Control c)
        {
            c.MouseEnter += (s, e) => { BorderColor = Color.DarkRed; BorderThickness = 2; };
            c.MouseLeave += (s, e) => { BorderColor = Color.FromArgb(34, 34, 34); BorderThickness = 1; };
            c.Cursor = Cursors.Hand;

            foreach (Control cc in c.Controls)
            {
                hoverEffects(cc);
            }
        }

        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            price.Text = menu.Price.ToString("C", new CultureInfo("en-PH"));
            if (menu.DiscountRate != 0.00)
            {
                off.Visible = true;
                off.Text = (menu.DiscountRate * 100).ToString() + "%";
                stick.Visible = true;
                newPrice.Visible = true;
                newPrice.Text = menu.GetDiscountedPrice().ToString("C", new CultureInfo("en-PH"));
            }
            else
            {
                stick.Visible = false;
                newPrice.Visible = false;
                off.Visible = false;
            }
            image.Image = menu.Image;
            description.Text = menu.MenuDescription;
            menuName.ForeColor = Color.Black;
            price.ForeColor = Color.Black;
            description.ForeColor = Color.Black;
        }

        private void price_Click(object sender, EventArgs e)
        {

        }
    }
}
