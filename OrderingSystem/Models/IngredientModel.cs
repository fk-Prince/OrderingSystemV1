namespace OrderingSystem.Model
{
    public class IngredientModel
    {
        private string ingredientName;
        private int ingredient_id;

        public IngredientModel()
        {
            //this.ingredientName = ingredientName;
            //this.ingredient_id = ingredient_id;
        }

        public string IngredientName { get => ingredientName; }
        public int Ingredient_id { get => ingredient_id; }

        public interface IIngredientModel
        {
            IngredientBuilder SetIngredientName(string ingredientName);
            IngredientBuilder SetIngredient_id(int ingredient_id);
            IngredientModel Build();
        }

        public static IngredientModel Builder() => new IngredientModel();


        public class IngredientBuilder : IIngredientModel
        {
            private IngredientModel ingredientModel = new IngredientModel();
            public IngredientBuilder SetIngredientName(string ingredientName)
            {
                ingredientModel.ingredientName = ingredientName;
                return this;
            }
            public IngredientBuilder SetIngredient_id(int ingredient_id)
            {
                ingredientModel.ingredient_id = ingredient_id;
                return this;
            }
            public IngredientModel Build()
            {
                return ingredientModel;
            }

        }

    }
}
