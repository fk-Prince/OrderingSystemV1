using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class MenuCard : Guna2Panel
    {
        private MenuDetailModel menu;
        public MenuCard(MenuDetailModel menu)
        {
            InitializeComponent();
            this.menu = menu;
            menuName.Text = menu.MenuName;
            menuDescription.Text = menu.MenuDescription;
            image.Image = menu.Image;

            BorderRadius = 10;
            BackColor = Color.Transparent;
            FillColor = Color.White;
            BorderColor = Color.FromArgb(34, 34, 34);
        }

        private void menuDescription_Click(object sender, System.EventArgs e)
        {

        }
    }
}
