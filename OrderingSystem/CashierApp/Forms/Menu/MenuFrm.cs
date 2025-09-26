using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.Menu;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class MenuFrm : Form
    {
        private ICashierMenuRepository cashierMenuRepository;
        public MenuFrm()
        {
            InitializeComponent();
            cashierMenuRepository = new CashierMenuRepository();
            List<MenuDetailModel> list = cashierMenuRepository.getMenu();
            foreach (var i in list)
            {
                MenuCard m = new MenuCard(i);
                m.Margin = new Padding(10, 10, 10, 10);
                flowMenu.Controls.Add(m);
            }
        }

        public void showBundle()
        {

        }

        public void showNewMenu()
        {
            NewMenu f = new NewMenu();
            DialogResult rs = f.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                f.Hide();
            }
            //loadForm(new NewMenu());
        }

        public void showUpdate()
        {

        }

        public void loadForm(Form f)
        {
            if (mm.Controls.Count > 0) mm.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mm.Controls.Add(f);
            mm.Tag = f;
            f.Show();
        }


    }
}
