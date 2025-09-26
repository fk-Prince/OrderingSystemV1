using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class NewMenu : Form
    {
        private ICashierMenuRepository cashierMenuRepository;
        public NewMenu()
        {
            InitializeComponent();
        }

        private void NewMenu_Load(object sender, System.EventArgs e)
        {
            List<CategoryModel> cat = new CategoryRepository().getCategories();
            cat.ForEach(c => cmbCat.Items.Add(c.Category_name));

            cashierMenuRepository = new CashierMenuRepository();
            List<string> flavor = cashierMenuRepository.getFlavor();
            List<string> size = cashierMenuRepository.getSize();

            flavor.ForEach(f => cmbFlavor.Items.Add(f));
            size.ForEach(f => cmbSize.Items.Add(f));
        }

        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
            display();
        }

        private void display()
        {
            ofd.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                pictureBox.ImageLocation = imagePath;
                //image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.ImageLocation = null;
            }
        }

        private void pictureBox_Click(object sender, System.EventArgs e)
        {
            display();
        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(menuDescription.Text) ||
                string.IsNullOrEmpty(menuPrice.Text) ||
                string.IsNullOrEmpty(cmbCat.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string name = menuName.Text.Trim();
            string desc = menuDescription.Text.Trim();
            double price = double.Parse(menuPrice.Text.Trim());
            string cat = cmbCat.Text;
            string flavor = cmbFlavor.Text;
            string size = cmbSize.Text;
            Image image = ImageHelper.PathToImage(pictureBox.ImageLocation);

            MenuDetailModel md = MenuDetailModel.Builder()
                .SetMenuName(name)
                .SetMenuDescription(desc)
                .SetPrice(price)
                .SetFlavorName(flavor)
                .SetImage(image)
                .SetSizeName(size)
                .SetMenuCategoryName(cat)
                .Build();

            cashierMenuRepository.createRegularMenu(md);

        }

        private void guna2Button4_Click(object sender, System.EventArgs e)
        {
            IngredientListPopup p = new IngredientListPopup(cashierMenuRepository);
            p.ShowDialog(this);
        }
    }
}
