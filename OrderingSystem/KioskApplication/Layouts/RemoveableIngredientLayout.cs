using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using OrderingSystem.Repository.Ingredients;
using MenuModel = OrderingSystem.Model.MenuModel;

namespace OrderingSystem.KioskApplication.Components
{
    public partial class RemoveableIngredientLayout : Guna2Panel
    {
        private IIngredientRepository ingredientRepository = new IngredientRepository();
        private MenuModel menu;
        private List<IngredientModel> removeIngredients;

        public RemoveableIngredientLayout(MenuModel menu)
        {
            InitializeComponent();
            this.menu = menu;
            removeIngredients = new List<IngredientModel>();
            HandleCreated += (s, e) => init();
            cardLayout();
        }
        public List<IngredientModel> getRemoveIngredient() { return removeIngredients; }
        private void init()
        {
            //List<IngredientModel> ingredientList =  ingredientRepository.getIngredientsOfMenu(menu);
            //display(ingredientList);
        }
        private void cardLayout()
        {
            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;
        }

        private void display(List<IngredientModel> ingredientList)
        {
            int y = 30;
            foreach (var i in ingredientList)
            {
                IngredientCheckbox box = new IngredientCheckbox(i);
                box.unChecked += (s, e) =>
                {
                    var ex = removeIngredients.FirstOrDefault(x => x.Ingredient_id == e.Ingredient_id);
                    if (ex != null) removeIngredients.Remove(ex);
                };
                box.Checked += (s, e) =>
                {
                    var ex = removeIngredients.FirstOrDefault(x => x.Ingredient_id == e.Ingredient_id);
                    if (ex == null) removeIngredients.Add(e);
                };
                box.Location = new Point(20, title.Bottom + y);
                Controls.Add(box);
                y += 30;
                this.Height += 40;
            }
        }
    }
}
