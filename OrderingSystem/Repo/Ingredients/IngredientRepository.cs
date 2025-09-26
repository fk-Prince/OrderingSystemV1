using System;
using System.Collections.Generic;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        public List<IngredientModel> getIngredients()
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT i.ingredient_id, i.ingredient_name,i.unit FROM ingredients i", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IngredientModel i = IngredientModel.Builder()
                                .SetIngredient_id(reader.GetInt32("ingredient_id"))
                                .SetIngredientName(reader.GetString("ingredient_name"))
                                .SetIngredientUnit(reader.GetString("unit"))
                                .Build();

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return null;
        }
    }
}
