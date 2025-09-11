using System;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Builder;
using Menu = OrderingSystem.Model.Menu;
namespace OrderingSystem.KioskApplication.Components
{
    public partial class FotCard : Guna2Panel
    {
        private Menu menu;
        public event EventHandler<Menu> checkedMenu;
        public event EventHandler<Menu> unCheckedMenu;
        private Menu selectedMenu;
        public FotCard(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            cardLayout();
            displayMenu();
        }

        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            size.Text = menu.MenuDetail.SizeName;
            price.Text = "₱       + " + menu.MenuDetail.getDiscountedPrice().ToString("N2");
            checkBox.Checked = false;
            checkBox.CheckedChanged += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    BorderColor = Color.FromArgb(94, 148, 255);
                    selectedMenu = new PurchaseBuilder().Build(menu, menu.MenuDetail);
                    checkedMenu.Invoke(this, selectedMenu);
                }
                else
                {
                    BorderColor = Color.DarkGray;
                    unCheckedMenu.Invoke(this, selectedMenu);
                    selectedMenu = null;
                }
            };
        }

        private void cardLayout()
        {
            BorderRadius = 5;
            BorderColor = Color.DarkGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            //selectedMenu = menu;
        }
    }
}
