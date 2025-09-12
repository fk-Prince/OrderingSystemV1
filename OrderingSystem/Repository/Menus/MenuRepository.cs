using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.Repository.Menus
{
    public class MenuRepository : IMenuRepository
    {
        public async Task<List<Menu>> getFrequentlyOrderedTogether(Menu menu)
        {

            var db = DatabaseHandler.getInstance();
            List<Menu> menuList = new List<Menu>();
            try
            {
                var conn = await db.getConnection();

                using (var cmd = new MySqlCommand("x_retrieve_fot", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_branches_id", Branches.Branch_ID);
                    cmd.Parameters.AddWithValue("@p_menu_id", menu.Menu_id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            var menuDetail = MenuDetail.Builder()
                             .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
                             .SetPrice(reader.GetDouble("price"))
                             .SetDiscountRate(reader.GetDouble("discount_rate"))
                             .SetSizeName(reader.GetString("size_name"))
                             .SetMaxOrder(reader.GetInt32("max-order"))
                             .Build();
                            Menu m = Menu.Builder()
                                .SetMenuID(reader.GetInt32("menu_id"))
                                .SetMenuDescription(reader.GetString("menu_description"))
                                .SetMenuName(reader.GetString("menu_name"))
                                .SetMenuCategoryID(reader.GetInt32("category_id"))
                                .SetBranchID(reader.GetInt32("branches_id"))
                                .SetMenuDetail(menuDetail)
                                .Build();

                            menuList.Add(m);
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
            return menuList;
        }

        public async Task<List<Menu>> getMenu()
        {
            var db = DatabaseHandler.getInstance();
            List<Menu> menuList = new List<Model.Menu>();
            try
            {
                var conn = await db.getConnection();

                using (var cmd = new MySqlCommand("SELECT * FROM x_retrieve_menu WHERE isAvailable = 'Yes' AND branches_id = @branches_id", conn))
                {
                    cmd.Parameters.AddWithValue("@branches_id", Branches.Branch_ID);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {


                            Menu menu = Menu.Builder()
                                .SetMenuID(reader.GetInt32("menu_id"))
                                .SetMenuDescription(reader.GetString("menu_description"))
                                .SetMenuName(reader.GetString("menu_name"))
                                .SetMenuCategoryID(reader.GetInt32("category_id"))
                                .SetMenuDetailList(getMenuDetail(reader.GetString("menu_detail")))
                                .Build();

                            menuList.Add(menu);
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
            return menuList;
        }

        //public async Task<List<MenuDetail>> getMenuDetailsByFlavor(int menu_id)
        //{
        //    var db = DatabaseHandler.getInstance();
        //    List<MenuDetail> menuList = new List<MenuDetail>();
        //    try
        //    {
        //        var conn = await db.getConnection();
        //        string query = @"
        //                        SELECT f.*, md.* FROM menu_detail md
        //                        INNER JOIN menu_flavor mf ON mf.menu_detail_id = md.menu_detail_id
        //                        INNER JOIN flavor f ON f.flavor_id = mf.flavor_id
        //                        INNER JOIN menu m ON m.menu_id = md.menu_id
        //                        WHERE m.menu_id = @menu_id";

        //        using (var cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@menu_id", menu_id);
        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {

        //                    MenuDetail md = MenuDetail.Builder()
        //                        .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
        //                        .SetPrice(reader.GetDouble("price"))
        //                        .SetEstimatedTime(reader.GetTimeSpan("estimated_time"))
        //                        .SetFlavorName(reader.GetString("flavor_name"))
        //                        .Build();
        //                    menuList.Add(md);

        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Internal Server Error");
        //    }
        //    finally
        //    {
        //        await db.closeConnection();
        //    }
        //    return menuList;
        //}
        //public async Task<List<MenuDetail>> getMenuDetailsBySize(int menu_id, int flavor)
        //{
        //    var db = DatabaseHandler.getInstance();
        //    List<MenuDetail> menuList = new List<MenuDetail>();
        //    try
        //    {
        //        var conn = await db.getConnection();
        //        string query = @"
        //                        SELECT f.*, md.* FROM menu_detail md
        //                        INNER JOIN menu_size ms ON ms.menu_detail_id = md.menu_detail_id
        //                        INNER JOIN size s ON s.size_id = ms.size_id
        //                        INNER JOIN menu m ON m.menu_id = md.menu_id
        //                        WHERE m.menu_id = @menu_id";

        //        using (var cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@menu_id", menu_id);
        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {

        //                    MenuDetail md = MenuDetail.Builder()
        //                        .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
        //                        .SetPrice(reader.GetDouble("price"))
        //                        .SetEstimatedTime(reader.GetTimeSpan("estimated_time"))
        //                        .SetSizeName(reader.GetString("size_name"))
        //                        .Build();
        //                    menuList.Add(md);

        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Internal Server Error");
        //    }
        //    finally
        //    {
        //        await db.closeConnection();
        //    }
        //    return menuList;
        //}






        public List<MenuDetail> getMenuDetail(string text)
        {
            List<MenuDetail> menuDetails = new List<MenuDetail>();

            if (string.IsNullOrWhiteSpace(text))
                return menuDetails;
            string[] details = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string d in details)
            {
                try
                {
                    string[] parts = d.Trim().Split('|');

                    int id = 0;
                    double price = 0;
                    double discountedPrice = 0;
                    string servingSize = "";
                    int maxOrder = 0;

                    foreach (string part in parts)
                    {
                        string trimmed = part.Trim();

                        if (trimmed.StartsWith("ID:"))
                        {
                            int.TryParse(trimmed.Replace("ID:", "").Trim(), out id);
                        }
                        else if (trimmed.StartsWith("DiscountedRate:"))
                        {
                            double.TryParse(trimmed.Replace("DiscountedRate:", "").Trim(), out discountedPrice);
                        }
                        else if (trimmed.StartsWith("Price:"))
                        {
                            double.TryParse(trimmed.Replace("Price:", "").Trim(), out price);
                        }
                        else if (trimmed.StartsWith("SizeName:"))
                        {
                            servingSize = trimmed.Replace("SizeName:", "").Trim();
                        }
                        else if (trimmed.StartsWith("Max-Order:"))
                        {
                            int.TryParse(trimmed.Replace("Max-Order:", "").Trim(), out maxOrder);
                        }
                    }

                    var menuDetail = MenuDetail.Builder()
                        .SetMenuDetailID(id)
                        .SetPrice(price)
                        .SetDiscountRate(discountedPrice)
                        .SetSizeName(servingSize)
                        .SetMaxOrder(maxOrder)
                        .Build();

                    menuDetails.Add(menuDetail);
                }
                catch
                {
                    continue;
                }
            }

            return menuDetails;
        }


        //public async Task<List<MenuDetail>> GetAllMenuDetailsForMenu(int menu_id)
        //{
        //    var db = DatabaseHandler.getInstance();
        //    List<MenuDetail> menuList = new List<MenuDetail>();
        //    try
        //    {
        //        var conn = await db.getConnection();
        //        string query = @"
        //                SELECT 
        //                    md.menu_detail_id,
        //                    md.menu_id,
        //                    md.price,
        //                    md.estimated_time,
        //                    f.flavor_name,
        //                    s.size_name
        //                FROM menu_detail md
        //                INNER JOIN menu m ON m.menu_id = md.menu_id
        //                LEFT JOIN menu_flavor mf ON mf.menu_detail_id = md.menu_detail_id
        //                LEFT JOIN flavor f ON f.flavor_id = mf.flavor_id
        //                LEFT JOIN menu_size ms ON ms.menu_detail_id = md.menu_detail_id
        //                LEFT JOIN size s ON s.size_id = ms.size_id
        //                WHERE m.menu_id = @menu_id
        //                ORDER BY md.menu_detail_id";

        //        using (var cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@menu_id", menu_id);
        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {

        //                    MenuDetail md = MenuDetail.Builder()
        //                     .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
        //                     .SetPrice(reader.GetDouble("price"))
        //                     .SetEstimatedTime(reader.GetTimeSpan("estimated_time"))
        //                     .SetFlavorName(reader.IsDBNull(reader.GetOrdinal("flavor_name"))
        //                          ? string.Empty
        //                          : reader.GetString(reader.GetOrdinal("flavor_name")))
        //                     .SetSizeName(reader.IsDBNull(reader.GetOrdinal("size_name"))
        //                          ? string.Empty
        //                          : reader.GetString(reader.GetOrdinal("size_name")))
        //                     .Build();
        //                    menuList.Add(md);
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Internal Server Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        await db.closeConnection();
        //    }
        //    return menuList;

        //}
    }
}
