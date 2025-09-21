namespace OrderingSystem.Model
{
    public class IngredientModel
    {
        private string ingredientName;
        private int ingredient_id;

        public IngredientModel(int ingredient_id, string ingredientName)
        {
            this.ingredientName = ingredientName;
            this.ingredient_id = ingredient_id;
        }

        public string IngredientName { get => ingredientName; }
        public int Ingredient_id { get => ingredient_id; }
    }
}
