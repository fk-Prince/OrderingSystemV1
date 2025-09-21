using System.Windows.Forms;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class CashierLayout : Form
    {
        private IngredientFrm ingredientInstance;
        public CashierLayout()
        {
            InitializeComponent();
            loadForm(OrderFrm.orderFactory());
        }

        public void loadForm(Form f)
        {
            if (mm.Controls.Count > 0)
            {
                mm.Controls.Clear();
            }

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mm.Controls.Add(f);
            mm.Tag = f;
            f.Show();
        }
        private void showSub(Panel panel)
        {
            if (panel.Visible == false)
            {
                hideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void hideSubMenu()
        {
            if (s1.Visible == true) s1.Visible = false;
            if (ingredientSub.Visible == true) ingredientSub.Visible = false;
        }


        private void guna2Button14_Click(object sender, System.EventArgs e)
        {
            loadForm(OrderFrm.orderFactory());
        }

        private void guna2Button6_Click(object sender, System.EventArgs e)
        {
            showSub(s1);
        }
        private void guna2Button12_Click(object sender, System.EventArgs e)
        {
            showSub(ingredientSub);
            loadForm(ingredientInstance = new IngredientFrm());
        }

        private void restockIngredient(object sender, System.EventArgs e)
        {
            if (ingredientInstance == null) return;
            ingredientInstance.showRestockIngredient();
        }

        private void addIngredient(object sender, System.EventArgs e)
        {
            if (ingredientInstance == null) return;
            ingredientInstance.showAddIngredient();
        }

        private void deductIngredient(object sender, System.EventArgs e)
        {
            if (ingredientInstance == null) return;
            ingredientInstance.showDeductIngredient();
        }
    }
}
