using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repo.CashierMenuRepository
{
    public class CashierMenuRepository : ICashierMenuRepository
    {
        public async Task<List<MenuDetailModel>> getMenu()
        {
            List<MenuDetailModel> list = new List<MenuDetailModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var con = await db.getConnection();
                using (var cmd = new MySqlCommand("SELECT * FROM v_retrieve_menu", con))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            MenuDetailModel md = MenuDetailModel.Builder()
                                     .SetMenuID(reader.GetInt32("menu_id"))
                                     .SetMenuDescription(reader.GetString("menu_description"))
                                     .SetMenuName(reader.GetString("menu_name"))
                                     .SetMenuCategoryID(reader.GetInt32("category_id"))
                                     .SetImage(ImageHelper.GetImageFromBlob(reader))
                                     .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
                                     .Build();
                            list.Add(md);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                await db.closeConnection();
            }
            return list;
        }
    }
}
