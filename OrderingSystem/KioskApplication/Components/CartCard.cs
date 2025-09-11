using System;
using System.Drawing;
using Guna.UI2.WinForms;
using Menu = OrderingSystem.Model.Menu;
namespace OrderingSystem.KioskApplication.Components
{
    public partial class CartCard : Guna2Panel
    {
        private Menu menu;
        public event EventHandler<Menu> addQuantityEvent;
        public event EventHandler<Menu> deductQuantityEvent;
        public CartCard(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            displayPurchasedMenu();
            cardLayout();
        }

        private void cardLayout()
        {
            BorderRadius = 5;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(255, 255, 255);
            BackColor = Color.Transparent;
        }

        public void displayPurchasedMenu()
        {
            menuName.Text = menu.MenuName;
            price.Text = menu.MenuDetail.getDiscountedPrice().ToString("N2");
            sizeName.Text = menu.MenuDetail.SizeName;
            qty.Text = menu.MenuDetail.PurchaseQty.ToString();
            total.Text = (menu.MenuDetail.getDiscountedPrice() * menu.MenuDetail.PurchaseQty).ToString("N2");
        }

        private void addQuantity(object sender, System.EventArgs e)
        {
            addQuantityEvent.Invoke(this, menu);
            displayPurchasedMenu();
        }

        private void deductQuantity(object sender, System.EventArgs e)
        {
            deductQuantityEvent.Invoke(this, menu);
            displayPurchasedMenu();
        }
    }
}
