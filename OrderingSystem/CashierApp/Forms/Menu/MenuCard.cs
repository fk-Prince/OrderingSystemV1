using System.Windows.Forms;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class MenuCard : Form
    {
        private MenuDetailModel menu;
        public MenuCard(MenuDetailModel menu)
        {
            InitializeComponent();
            this.menu = menu;

        }


    }
}
