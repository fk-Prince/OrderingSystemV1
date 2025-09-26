using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class NewMenu : Form
    {
        public NewMenu()
        {
            InitializeComponent();
        }

        private void NewMenu_Load(object sender, System.EventArgs e)
        {
            List<CategoryModel> cat = new CategoryRepository().getCategories();
            cat.ForEach(c => cmbCat.Items.Add(c.Category_name));

            ICashierMenuRepository cashierMenuRepository = new CashierMenuRepository();
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
    }
}
