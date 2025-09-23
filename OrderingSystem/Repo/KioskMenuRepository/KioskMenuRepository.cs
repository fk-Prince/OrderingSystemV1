using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using MySqlConnector;
using Newtonsoft.Json;
using OrderingSystem.DatabaseConnection;
using OrderingSystem.Model;
using MenuModel = OrderingSystem.Model.MenuModel;

namespace OrderingSystem.Repository.Menus
{
    public class KioskMenuRepository : IKioskMenuRepository
    {
        private List<MenuDetailModel> orderList;
        public KioskMenuRepository(List<MenuDetailModel> orderList)
        {
            this.orderList = orderList;
        }
        public List<MenuDetailModel> getMenu()
        {
            var db = DatabaseHandler.getInstance();
            List<MenuDetailModel> menuList = new List<MenuDetailModel>();
            try
            {
                var conn = db.getConnection();
                string query = @"SELECT DISTINCT m.menu_id, m.* FROM v_retrieve_menu m WHERE m.isAvailable = 'Yes'";
                using (var cmd = new MySqlCommand(query, conn))
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
                                  .SetPrice(reader.GetDouble("min_price"))
                                  .SetImage(ImageHelper.GetImageFromBlob(reader))
                                  .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
                                  .SetDiscountRate(reader.GetDouble("discount_rate"))
                                  .SetMaxOrder(reader.GetInt32("max_available_order"))
                                  .Build();
                            menuList.Add(md);
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
            return menuList;
        }

        public List<MenuDetailModel> getMenuDetailFlavor(MenuModel menu)
        {
            var db = DatabaseHandler.getInstance();
            List<MenuDetailModel> mds = new List<MenuDetailModel>();
            var tempData = new List<(int MenuId, int MenuDetailId, double Price, double DiscountRate, string FlavorName)>();
            try
            {
                var conn = db.getConnection();
                string query = @"                        
                            SELECT menu_id,menu_detail_id, price, flavor_name, discount_rate, max_order
                              FROM (
                                  SELECT 
                                      md.menu_id,
                                      md.menu_detail_id,
                                      md.price,
                                      f.flavor_name,
                                      COALESCE(d.rate, 0) AS discount_rate,
                                      mm.max_order,
                                      ROW_NUMBER() OVER (PARTITION BY f.flavor_name ORDER BY md.price ASC) AS rn
                                  FROM menu m
                                  LEFT JOIN menu_discount mdc ON m.menu_id = mdc.menu_id
                                  LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                                  LEFT JOIN category c ON m.category_id = c.category_id
                                  LEFT JOIN menu_detail md ON m.menu_id = md.menu_id
                                  LEFT JOIN flavor f ON f.flavor_id = md.flavor_id
                                  LEFT JOIN v_retrieve_max_order_per_menu mm ON mm.menu_detail_id = md.menu_detail_id
                                  WHERE m.isAvailable = 'Yes' 
                                    AND m.menu_id = @menu_id
                                    AND md.menu_detail_id NOT IN (SELECT from_menu_detail_id FROM menu_package)
                              ) AS ranked
                              WHERE rn = 1
                              ORDER BY price,menu_detail_id;
                     ";
                using (var cmd = new MySqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@menu_id", menu.Menu_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempData.Add((
                                  MenuId: reader.GetInt32("menu_id"),
                                  MenuDetailId: reader.GetInt32("menu_detail_id"),
                                  Price: reader.GetDouble("price"),
                                  DiscountRate: reader.GetDouble("discount_rate"),
                                  FlavorName: reader.GetString("flavor_name")
                              ));
                        }
                        reader.Dispose();
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                db.closeConnection();
                foreach (var item in tempData)
                {
                    int maxOrder = getMaxOrderRealTime(item.MenuDetailId, orderList);
                    mds.Add(MenuDetailModel.Builder()
                        .SetMenuID(item.MenuId)
                        .SetMenuDetailID(item.MenuDetailId)
                        .SetPrice(item.Price)
                        .SetDiscountRate(item.DiscountRate)
                        .SetMaxOrder(maxOrder)
                        .SetFlavorName(item.FlavorName)
                        .Build());
                }
            }
            return mds;
        }
        public List<MenuDetailModel> getFrequentlyOrderedTogether(MenuModel menu)
        {

            var db = DatabaseHandler.getInstance();
            var tempData = new List<(
                                int MenuId,
                                string MenuDescription,
                                string MenuName,
                                double Price,
                                string FlavorName,
                                string SizeName,
                                int MenuDetailId,
                                double DiscountRate,
                                int? DiscountId,
                                int maxOrder,
                                Image image
                            )>();
            List<MenuDetailModel> menuList = new List<MenuDetailModel>();
            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("p_retrieve_FrequentlyOrderedTogether", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_menu_id", menu.Menu_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempData.Add((
                               MenuId: reader.GetInt32("menu_id"),
                               MenuDescription: reader.IsDBNull(reader.GetOrdinal("menu_description")) ? "" : reader.GetString("menu_description"),
                               MenuName: reader.GetString("menu_name"),
                               Price: reader.GetDouble("price"),
                               FlavorName: reader.GetString("flavor_name"),
                               SizeName: reader.GetString("size_name"),
                               MenuDetailId: reader.GetInt32("menu_detail_id"),
                               DiscountRate: reader.GetDouble("discount_rate"),
                               DiscountId: reader.IsDBNull(reader.GetOrdinal("discount_id")) ? (int?)null : reader.GetInt32("discount_id"),
                               maxOrder: 0,
                               image: ImageHelper.GetImageFromBlob(reader)
                           ));
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
                db.closeConnection();
            }

            foreach (var i in tempData)
            {

                int max = getMaxOrderRealTime(i.MenuDetailId, orderList);
                if (max > 0)
                {
                    menuList.Add(MenuDetailModel.Builder()
                       .SetMenuID(i.MenuId)
                       .SetMenuDetailID(i.MenuDetailId)
                       .SetPrice(i.Price)
                       .SetDiscountRate(i.DiscountRate)
                       .SetMaxOrder(max)
                       .SetImage(i.image)
                       .SetFlavorName(i.FlavorName)
                       .SetMenuDescription(i.MenuDescription)
                       .SetMenuName(i.MenuName)
                       .SetSizeName(i.SizeName)
                       .SetDiscountId(i.DiscountId)
                       .Build());
                }
            }
            return menuList;
        }
        public List<MenuDetailModel> getMenuDetailFlavorPackage(MenuDetailModel md)
        {
            var db = DatabaseHandler.getInstance();
            List<MenuDetailModel> mds = new List<MenuDetailModel>();
            var tempData = new List<(int MenuId, int MenuDetailId, double Price, double DiscountRate, string FlavorName)>();
            try
            {
                var conn = db.getConnection();
                string query = @"                        
                           
                            SELECT menu_id,menu_detail_id, price, flavor_name, discount_rate, max_order
                            FROM (
                                SELECT 
                                    md.menu_id,
                                    md.menu_detail_id,
                                    md.price,
                                    f.flavor_name,
                                    COALESCE(d.rate, 0) AS discount_rate,
                                    mm.max_order,
                                    ROW_NUMBER() OVER (PARTITION BY f.flavor_name ORDER BY md.price ASC) AS rn
                                FROM menu m
                                LEFT JOIN menu_discount mdc ON m.menu_id = mdc.menu_id
                                LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                                LEFT JOIN category c ON m.category_id = c.category_id
                                LEFT JOIN menu_detail md ON m.menu_id = md.menu_id
                                LEFT JOIN flavor f ON f.flavor_id = md.flavor_id
                                LEFT JOIN v_retrieve_max_order_per_menu mm ON mm.menu_detail_id = md.menu_detail_id
                                WHERE m.isAvailable = 'Yes' 
                                  AND m.menu_id = @menu_id                               
                                  AND md.menu_detail_id <> @id
                                  AND f.flavor_name <> @flavor_name
                            ) AS ranked
                            WHERE rn = 1
                            ORDER BY menu_detail_id
                                        ";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", md.Menu_id);
                    cmd.Parameters.AddWithValue("@id", md.Menudetail_id);
                    cmd.Parameters.AddWithValue("@flavor_name", md.FlavorName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempData.Add((
                                   MenuId: reader.GetInt32("menu_id"),
                                   MenuDetailId: reader.GetInt32("menu_detail_id"),
                                   Price: reader.GetDouble("price"),
                                   DiscountRate: reader.GetDouble("discount_rate"),
                                   FlavorName: reader.GetString("flavor_name")
                               ));

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
                db.closeConnection();
                foreach (var item in tempData)
                {
                    int maxOrder = getMaxOrderRealTime(item.MenuDetailId, orderList);
                    //MessageBox.Show(item.MenuDetailId.ToString());
                    mds.Add(MenuDetailModel.Builder()
                        .SetMenuID(item.MenuId)
                        .SetMenuDetailID(item.MenuDetailId)
                        .SetPrice(item.Price)
                        .SetDiscountRate(item.DiscountRate)
                        .SetMaxOrder(maxOrder)
                        .SetFlavorName(item.FlavorName)
                        .Build());
                }
            }
            return mds;
        }
        public List<MenuDetailModel> getMenuDetailSizeByFlavor(int id, string flavorName)
        {
            var db = DatabaseHandler.getInstance();
            List<MenuDetailModel> mds = new List<MenuDetailModel>();
            var tempData = new List<(int MenuId, string MenuName, int MenuDetailId, double Price, double DiscountRate, string SizeName)>();
            try
            {
                string query = "SELECT * FROM v_retrieve_menu_details m";
                var conn = db.getConnection();
                if (string.IsNullOrWhiteSpace(flavorName))
                {
                    query += @" WHERE 
                                    m.isAvailable = 'Yes'
                                    AND m.menu_id = @menu_id
                                ORDER BY m.price";
                }
                else
                {
                    query += @" WHERE 
                                     m.isAvailable = 'Yes'
                                     AND m.menu_id = @menu_id
                                     AND LOWER(m.flavor_name) = LOWER(@flavor_name)
                                ORDER BY m.price";
                }
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", id);
                    cmd.Parameters.AddWithValue("@flavor_name", flavorName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempData.Add((
                                     MenuId: reader.GetInt32("menu_id"),
                                     MenuName: reader.GetString("menu_name"),
                                     MenuDetailId: reader.GetInt32("menu_detail_id"),
                                     Price: reader.GetDouble("price"),
                                     DiscountRate: reader.GetDouble("discount_rate"),
                                     SizeName: reader.GetString("size_name")
                                 ));
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
                db.closeConnection();
                foreach (var item in tempData)
                {
                    int maxOrder = getMaxOrderRealTime(item.MenuDetailId, orderList);

                    mds.Add(MenuDetailModel.Builder()
                        .SetMenuID(item.MenuId)
                        .SetMenuName(item.MenuName)
                        .SetMenuDetailID(item.MenuDetailId)
                        .SetPrice(item.Price)
                        .SetDiscountRate(item.DiscountRate)
                        .SetMaxOrder(maxOrder)
                        .SetSizeName(item.SizeName)
                        .Build());
                }
            }
            return mds;
        }
        public bool isMenuPackage(MenuModel menu)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = @"
                                SELECT COUNT(*) c FROM menu m
                                INNER JOIN menu_detail md ON m.menu_id = md.menu_id
                                WHERE md.menu_detail_id IN (
	                                SELECT pg.from_menu_detail_id FROM menu_package pg WHERE LOWER(pg.package_type) = 'not-fixed'
                                ) AND m.menu_id = @menu_id;
                                ";
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu.Menu_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32("c") >= 1;
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
                db.closeConnection();
            }
            return false;
        }
        public MenuDetailModel getSelectedMenu(int menu_id, string flavorName, string sizeName)
        {
            var db = DatabaseHandler.getInstance();
            var tempData = new List<(
                    int MenuId,
                    string MenuDescription,
                    string MenuName,
                    double Price,
                    string FlavorName,
                    string SizeName,
                    int MenuDetailId,
                    double DiscountRate,
                    int? DiscountId,
                    int maxOrder,
                    Image image,
                    TimeSpan estimatedTime
                )>();
            try
            {
                string query = @"
                                 SELECT md.menu_detail_id,md.price,f.flavor_name,s.size_name,md.estimated_time, m.*,d.discount_id,COALESCE(d.rate,0) discount_rate FROM menu_detail md
                                 INNER JOIN menu m ON m.menu_id = md.menu_id
                                 LEFT JOIN menu_discount mdc ON mdc.menu_id = m.menu_id
                                 LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                                 INNER JOIN size s ON s.size_id = md.size_id
                                 INNER JOIN flavor f ON f.flavor_id = md.flavor_id
                                 WHERE md.menu_id = @menu_id";

                if (!string.IsNullOrWhiteSpace(flavorName))
                    query += " AND LOWER(f.flavor_name) = LOWER(@flavor_name)";


                if (!string.IsNullOrWhiteSpace(sizeName))
                    query += " AND LOWER(s.size_name) = LOWER(@size_name)";

                query += " ORDER BY md.menu_detail_id LIMIT 1";

                var conn = db.getConnection();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu_id);
                    if (!string.IsNullOrWhiteSpace(flavorName))
                        cmd.Parameters.AddWithValue("@flavor_name", flavorName);

                    if (!string.IsNullOrWhiteSpace(sizeName))
                        cmd.Parameters.AddWithValue("@size_name", sizeName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            //int? discountId = reader.IsDBNull(reader.GetOrdinal("discount_id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("discount_id"));
                            //return MenuDetail.Builder()
                            //    .SetMenuID(reader.GetInt32("menu_id"))
                            //    .SetMenuDescription(reader.GetString("menu_description"))
                            //    .SetMenuName(reader.GetString("menu_name"))
                            //    .SetPrice(reader.GetDouble("price"))
                            //    .SetFlavorName(reader.GetString("flavor_name"))
                            //    .SetSizeName(reader.GetString("size_name"))
                            //    .SetMenuDetailID(reader.GetInt32("menu_detail_id"))
                            //    .SetDiscountRate(reader.GetDouble("discount_rate"))
                            //    .SetDiscountId(discountId)
                            //    .Build();

                            tempData.Add((
                                MenuId: reader.GetInt32("menu_id"),
                                MenuDescription: reader.IsDBNull(reader.GetOrdinal("menu_description")) ? "" : reader.GetString("menu_description"),
                                MenuName: reader.GetString("menu_name"),
                                Price: reader.GetDouble("price"),
                                FlavorName: reader.GetString("flavor_name"),
                                SizeName: reader.GetString("size_name"),
                                MenuDetailId: reader.GetInt32("menu_detail_id"),
                                DiscountRate: reader.GetDouble("discount_rate"),
                                DiscountId: reader.IsDBNull(reader.GetOrdinal("discount_id")) ? (int?)null : reader.GetInt32("discount_id"),
                                maxOrder: 0,
                                image: ImageHelper.GetImageFromBlob(reader),
                                estimatedTime: reader.GetTimeSpan("estimated_time")
                            ));
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
                db.closeConnection();
            }
            foreach (var i in tempData)
            {

                int max = getMaxOrderRealTime(i.MenuDetailId, orderList);
                return MenuDetailModel.Builder()
                   .SetMenuID(i.MenuId)
                   .SetMenuDetailID(i.MenuDetailId)
                   .SetPrice(i.Price)
                   .SetDiscountRate(i.DiscountRate)
                   .SetMaxOrder(max)
                   .SetImage(i.image)
                   .SetFlavorName(i.FlavorName)
                   .SetMenuDescription(i.MenuDescription)
                   .SetMenuName(i.MenuName)
                   .SetSizeName(i.SizeName)
                   .SetDiscountId(i.DiscountId)
                   .SetEstimatedTime(i.estimatedTime)
                   .Build();
            }
            return null;
        }
        public int getMaxOrderRealTime(int menu_id, List<MenuDetailModel> md)
        {
            var db = DatabaseHandler.getInstance();
            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("p_menu_max_order", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string json = JsonConvert.SerializeObject(orderList);
                    cmd.Parameters.AddWithValue("@p_menu_detail_id", menu_id);
                    cmd.Parameters.AddWithValue("@p_json", json);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32("max_order");
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
                db.closeConnection();
            }
            return 0;
        }
        public List<MenuDetailModel> getMenuId(int menu_id)
        {
            List<MenuDetailModel> intz = new List<MenuDetailModel>();

            var tempData = new List<(
                     int MenuId,
                     int MenuDetailId,
                     string MenuName,
                     string MenuDescription,
                     string FlavorName,
                     double Price,
                     double DiscountRate,
                     int MaxOrder
                 )>();
            var db = DatabaseHandler.getInstance();
            try
            {
                string query = @"
                             WITH RECURSIVE package_items AS (
                                SELECT
                                    mp.included_menu_detail_id,
                                    mp.quantity,
                                    1 AS item_number
                                FROM
                                    menu_package mp
                                JOIN
                                    menu_detail md_package ON mp.from_menu_detail_id = md_package.menu_detail_id
                                WHERE
                                    md_package.menu_id = @menu_id
                                UNION ALL
                                SELECT
                                    p.included_menu_detail_id,
                                    p.quantity,
                                    p.item_number + 1
                                FROM
                                    package_items p
                                WHERE
                                    p.item_number < p.quantity
                            )
                            SELECT
                                md.menu_id,
                                md.menu_detail_id,
                                m.menu_name,
                                m.menu_description,
                                f.flavor_name,
                                md.price,
                                COALESCE(d.rate, 0) AS discount_rate,
                                pi.quantity 
                            FROM
                                package_items pi
                            JOIN
                                menu_detail md ON pi.included_menu_detail_id = md.menu_detail_id
                            JOIN
                                flavor f ON f.flavor_id = md.flavor_id
                            LEFT JOIN
                                menu m ON md.menu_id = m.menu_id
                            LEFT JOIN
                                menu_discount mdc ON md.menu_id = mdc.menu_id
                            LEFT JOIN
                                discount d ON d.discount_id = mdc.discount_id
                            ORDER BY
                                md.menu_id, 
                                f.flavor_name;";
                //string query = @"
                //              SELECT 
                //                DISTINCT md.menu_id,
                //                md.menu_detail_id,
                //                m.menu_name,
                //                m.menu_description,
                //                f.flavor_name,
                //                md.price,
                //                COALESCE(d.rate, 0) AS discount_rate,
                //                mm.max_order
                //            FROM menu_detail md
                //            JOIN flavor f ON f.flavor_id = md.flavor_id
                //            LEFT JOIN menu m ON md.menu_id = m.menu_id
                //            LEFT JOIN menu_discount mdc ON md.menu_id = mdc.menu_id
                //            LEFT JOIN discount d ON d.discount_id = mdc.discount_id
                //            LEFT JOIN v_retrieve_max_order_per_menu mm ON mm.menu_detail_id = md.menu_detail_id
                //            WHERE md.menu_detail_id IN (
                //                SELECT pg.included_menu_detail_id
                //                FROM menu_detail parent_md
                //                JOIN menu_package pg ON pg.from_menu_detail_id = parent_md.menu_detail_id
                //                WHERE parent_md.menu_id = @menu_id
                //            )
                //            ORDER BY md.menu_id, f.flavor_name";

                var conn = db.getConnection();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menu_id", menu_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempData.Add((
                                    reader.GetInt32("menu_id"),
                                    reader.GetInt32("menu_detail_id"),
                                    reader.GetString("menu_name"),
                                    reader.IsDBNull(reader.GetOrdinal("menu_description")) ? "" : reader.GetString("menu_description"),
                                    reader.GetString("flavor_name"),
                                    reader.GetDouble("price"),
                                    reader.GetDouble("discount_rate"),
                                    0
                                ));

                            //md.menu_id,
                            //    md.menu_detail_id,
                            //    m.menu_name,
                            //    m.menu_description,
                            //    f.flavor_name,
                            //    md.price,
                            //    COALESCE(d.rate, 0) AS discount_rate,
                            //    pi.quantity
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
                db.closeConnection();

                foreach (var i in tempData)
                {
                    int max = getMaxOrderRealTime(i.MenuDetailId, orderList);
                    intz.Add(MenuDetailModel.Builder()
                             .SetMenuID(i.MenuId)
                             .SetMenuName(i.MenuName)
                             .SetMenuDescription(i.MenuDescription)
                             .SetMenuDetailID(i.MenuDetailId)
                             .SetPrice(i.Price)
                             .SetDiscountRate(i.DiscountRate)
                             .SetMaxOrder(max)
                             .SetFlavorName(i.FlavorName)
                             .Build());
                }
            }
            return intz;
        }
        public double getNewPackagePrice(int menu_id, List<MenuDetailModel> includedId)
        {
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = db.getConnection();

                using (var cmd = new MySqlCommand("p_menu_package_price", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string json = JsonConvert.SerializeObject(includedId);
                    cmd.Parameters.AddWithValue("@p_package_id", menu_id);
                    cmd.Parameters.AddWithValue("@p_included", json);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal d = reader.GetDecimal(0);
                            return (double)d;
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
                db.closeConnection();
            }
            return 0;
        }

    }
}
