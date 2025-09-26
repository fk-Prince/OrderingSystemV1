using System.Collections.Generic;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;

namespace OrderingSystem.Repo.CashierMenuRepository
{
    public class CashierMenuRepository : ICashierMenuRepository
    {
        public List<string> getFlavor()
        {
            List<string> list = new List<string>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var con = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT flavor_name FROM flavor", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString("flavor_name"));
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
                db.closeConnection();
            }
            return list;
        }

        public List<MenuDetailModel> getMenu()
        {
            List<MenuDetailModel> list = new List<MenuDetailModel>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var con = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT * FROM v_retrieve_menu", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuDetailModel md = MenuDetailModel.Builder()
                                     .SetMenuID(reader.GetInt32("menu_id"))
                                     .SetMenuDescription(reader.GetString("menu_description"))
                                     .SetMenuName(reader.GetString("menu_name"))
                                     .SetMenuCategoryID(reader.GetInt32("category_id"))
                                     .SetImage(ImageHelper.GetImageFromBlob(reader))
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
                db.closeConnection();
            }
            return list;
        }

        public List<string> getSize()
        {
            List<string> list = new List<string>();
            var db = DatabaseHandler.getInstance();
            try
            {
                var con = db.getConnection();
                using (var cmd = new MySqlCommand("SELECT DISTINCT size_name FROM size", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString("size_name"));
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
                db.closeConnection();
            }
            return list;
        }
    }
}
