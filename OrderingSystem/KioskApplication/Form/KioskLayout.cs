using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication.Cards;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.Menus;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem
{
    public partial class KioskLayout : Form
    {

        private IMenuRepository menuRepository;
        private ICategoryRepository categoryRepository;
        private Guna2Button lastActiveButton;
        private CartServices cartServices;
        private bool isShowing = false;
        private int x;
        public KioskLayout()
        {
            InitializeComponent();
            categoryRepository = new CategoryRepository();
            menuRepository = new MenuRepository();
            cartServices = new CartServices(menuRepository, flowCart);
            cartServices.quantityChanged += displayTotal;
        }

        private void displayTotal(object sender, EventArgs e)
        {
            subtotal.Text = cartServices.calculateSubtotal().ToString("N2");
            vat.Text = cartServices.calculateVat().ToString("N2");
            //cartServices.calculateCoupon();
            total.Text = cartServices.calculateTotalAmount().ToString("N2");
        }

        private void displayMenu(List<Menu> menuList)
        {
            foreach (var m in menuList)
            {
                MenuCard card = new MenuCard(m);
                card.Margin = new Padding(12, 10, 12, 10);
                card.orderList += (s, e) =>
                {
                    cartServices.addMenuToCart(e);
                    displayTotal(this, EventArgs.Empty);
                };
                flowMenu.Controls.Add(card);

            }
        }
        private void displayCategories(List<Category> catList)
        {
            foreach (var c in catList)
            {
                Guna2Button b = new Guna2Button();
                b.Text = c.Category_name;
                b.FillColor = Color.FromArgb(238, 238, 238);
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(34, 34, 34);
                b.HoverState.FillColor = Color.FromArgb(238, 238, 238);
                b.Click += buttonClicked;
                b.Tag = c.Category_id;
                b.Size = new Size(100, 46);
                b.Margin = new Padding(12, 0, 12, 0);
                flowCat.Controls.Add(b);
            }
        }
        private void buttonClicked(object sender, EventArgs x)
        {
            Guna2Button b = (Guna2Button)sender;
            if (lastActiveButton != null && b != lastActiveButton)
            {
                lastActiveButton.Paint -= bottomBorder;
                lastActiveButton.Invalidate();
                lastActiveButton.ForeColor = Color.FromArgb(34, 34, 34);

            }
            b.ForeColor = Color.DarkRed;
            lastActiveButton = b;
            b.Paint -= bottomBorder;
            b.Paint += bottomBorder;
        }
        private void bottomBorder(object sender, PaintEventArgs e)
        {
            Control btn = (sender) as Control;
            using (Pen p = new Pen(Color.DarkRed, 3))
            {
                e.Graphics.DrawLine(p, 0, btn.Height - 5, btn.Width, btn.Height - 5);
            }
        }
        private async void KioskLayout_Load(object sender, System.EventArgs e)
        {
            await runAsyncFunction();
        }
        private async Task runAsyncFunction()
        {
            List<Category> catList = await categoryRepository.getCategories();
            displayCategories(catList);

            List<Menu> menuList = await menuRepository.getMenu();
            displayMenu(menuList);
        }
        private void KioskLayout_SizeChanged(object sender, EventArgs e)
        {
            x = cartPanel.Location.X;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            t.Start();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            if (isShowing)
            {
                x += 50;
                cartPanel.Location = new Point(x, 0);
                if (x >= ClientSize.Width)
                {
                    cartPanel.Location = new Point(ClientSize.Width, 0);
                    isShowing = !isShowing;
                    t.Stop();
                }
            }
            else
            {
                x -= 62;
                cartPanel.Location = new Point(x, 0);
                if (cartPanel.Right <= ClientSize.Width)
                {
                    int pos = ClientSize.Width - cartPanel.Width;
                    cartPanel.Location = new Point(pos, 0);
                    isShowing = !isShowing;
                    t.Stop();
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //AddMenu add = new AddMenu();
            //add.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
