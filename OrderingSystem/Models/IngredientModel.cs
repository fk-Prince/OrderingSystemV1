namespace OrderingSystem.Model
{
    public class IngredientModel
    {
        private string ingredientName;
        private string ingredientUnit;
        private int ingredient_id;

        public IngredientModel()
        {
            //this.ingredientName = ingredientName;
            //this.ingredient_id = ingredient_id;
        }

        public string IngredientName { get => ingredientName; }
        public string IngredientUnit { get => ingredientUnit; }
        public int Ingredient_id { get => ingredient_id; }

        public interface IIngredientModel
        {
            IngredientBuilder SetIngredientName(string ingredientName);
            IngredientBuilder SetIngredient_id(int ingredient_id);
            IngredientBuilder SetIngredientUnit(string ingredientUnit);
            IngredientModel Build();
        }

        public static IngredientBuilder Builder() => new IngredientBuilder();


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

            public IngredientBuilder SetIngredientUnit(string ingredientUnit)
            {
                ingredientModel.ingredientUnit = ingredientUnit;
                return this;
            }
        }

    }
}
