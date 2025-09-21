using System;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Components
{
    public partial class IngredientCheckbox : Guna2Panel
    {
        public event EventHandler<IngredientModel> Checked;
        public event EventHandler<IngredientModel> unChecked;
        public IngredientCheckbox(IngredientModel i)
        {
            InitializeComponent();
            name.Text = i.IngredientName;

            checkBox.CheckedChanged += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    Checked?.Invoke(this, i);
                }
                else
                {
                    unChecked?.Invoke(this, i);
                }
            };
        }
    }
}
