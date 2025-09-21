using System;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
namespace OrderingSystem.KioskApplication.Components
{
    public partial class FrequentlyOrderedCard : Guna2Panel
    {
        private MenuDetailModel menu;
        public event EventHandler<MenuDetailModel> checkedMenu;
        public event EventHandler<MenuDetailModel> unCheckedMenu;
        private MenuDetailModel selectedMenu;
        public FrequentlyOrderedCard(MenuDetailModel menu)
        {
            InitializeComponent();
            this.menu = menu;
            cardLayout();
            displayMenu();
            cardChecked();
        }

        private void cardChecked()
        {
            checkBox.Checked = false;
            checkBox.CheckedChanged += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    BorderColor = Color.FromArgb(94, 148, 255);
                    BorderColor = Color.DarkRed;
                    BorderThickness = 3;
                    selectedMenu = MenuDetailModel.BuildPurchaseMenu(menu);
                    checkedMenu.Invoke(this, selectedMenu);
                }
                else
                {
                    BorderColor = Color.DarkGray;
                    BorderThickness = 1;
                    unCheckedMenu.Invoke(this, selectedMenu);
                    selectedMenu = null;
                }
            };
        }

        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            detail.Text = menu.SizeName;
            price.Text = "₱       + " + menu.GetDiscountedPrice().ToString("N2");
            image.Image = menu.Image;
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
            selectedMenu = menu;
        }
    }
}
