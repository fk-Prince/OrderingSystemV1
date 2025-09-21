using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;
using MenuModel = OrderingSystem.Model.MenuModel;
namespace OrderingSystem.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        Task<List<IngredientModel>> getIngredientsOfMenu(MenuModel menu);
    }
}
