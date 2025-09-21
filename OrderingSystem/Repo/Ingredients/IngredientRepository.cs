using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;
using MenuModel = OrderingSystem.Model.MenuModel;

namespace OrderingSystem.Repository.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        public async Task<List<IngredientModel>> getIngredientsOfMenu(MenuModel menu)
        {
            List<IngredientModel> ingredientsList = new List<IngredientModel>();

            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = await db.getConnection();
                string query = @"
                                SELECT i.* FROM ingredients i
                                INNER JOIN menu_ingredient mi ON mi.ingredient_id = i.ingredient_id 
                                WHERE mi.menu_detail_id = @menu_detail_id AND i.removable = 'Yes'
                                ";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@menu_detail_id", menu.MenuDetail.Menudetail_id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ingredientsList.Add(new IngredientModel(reader.GetInt32("ingredient_id"), reader.GetString("ingredient_name")));
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Internal Server Error");
            }
            finally
            {
                await db.closeConnection();
            }

            return ingredientsList;
        }
    }
}
