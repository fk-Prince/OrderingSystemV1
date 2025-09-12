using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;
namespace OrderingSystem.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> getIngredientsOfMenu(Menu menu);
    }
}
