using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<CategoryModel>> getCategories()
        {
            var db = DatabaseHandler.getInstance();
            List<CategoryModel> categories = new List<CategoryModel>();
            try
            {
                var conn = await db.getConnection();
                string query = @"
                        SELECT DISTINCT c.category_id, c.category_name FROM category c 
                        INNER JOIN menu m ON m.category_id = c.category_id
                        ";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            categories.Add(new CategoryModel(reader.GetInt32("category_id"), reader.GetString("category_name")));
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                await db.closeConnection();
            }
            return categories;
        }
    }
}
