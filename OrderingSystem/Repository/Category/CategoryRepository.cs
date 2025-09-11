using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> getCategories()
        {
            var db = DatabaseHandler.getInstance();
            List<Category> categories = new List<Category>();
            try
            {
                var conn = await db.getConnection();
                string query = @"
                        SELECT DISTINCT c.category_id, c.category_name FROM category c 
                        INNER JOIN menu m ON m.category_id = c.category_id
                        INNER JOIN menu_branches mb ON mb.menu_id = m.menu_id
                        WHERE mb.branches_id = @branches_id
                        ";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@branches_id", Branches.Branch_ID);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            categories.Add(new Category(reader.GetInt32("category_id"), reader.GetString("category_name")));
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
            return categories;
        }
    }
}
