using System;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class MenuDetailModel : MenuModel
    {
        public int Menudetail_id { get; protected set; }
        public double Price { get; protected set; }
        public int? DiscountId { get; protected set; }
        public double DiscountRate { get; protected set; }
        public string SizeName { get; protected set; }
        public string FlavorName { get; protected set; }
        public TimeSpan EstimatedTime { get; protected set; }
        public int MaxOrder { get; protected set; }
        public int PurchaseQty { get; set; }



        public static MenuDetailBuilder Builder() => new MenuDetailBuilder();

        public interface IMenuDetailBuilder
        {
            MenuDetailBuilder SetMenuDetailID(int id);
            MenuDetailBuilder SetPrice(double price);
            MenuDetailBuilder SetSizeName(string sizeName);
            MenuDetailBuilder SetFlavorName(string text);
            MenuDetailBuilder SetEstimatedTime(TimeSpan estimatedTime);
            MenuDetailBuilder SetDiscountRate(double rate);
            MenuDetailBuilder SetDiscountId(int? id);
            MenuDetailBuilder SetMaxOrder(int maxOrder);
            MenuDetailBuilder SetPurchaseQty(int purchaseQty);
            MenuDetailBuilder SetMenuDescription(string txt);
            MenuDetailBuilder SetImage(Image img);
            MenuDetailBuilder SetMenuCategoryID(int id);
            MenuDetailBuilder SetMenuID(int id);
            MenuDetailModel Build();
        }

        public double GetDiscountedPrice()
        {
            return Price - (Price * DiscountRate);
        }

        public static MenuDetailModel BuildPurchaseMenu(MenuDetailModel xx)
        {
            return Builder()
              .SetMenuName(xx.MenuName)
              .SetMenuID(xx.Menu_id)
              .SetMenuDetailID(xx.Menudetail_id)
              .SetEstimatedTime(xx.EstimatedTime)
              .SetDiscountId(xx.DiscountId)
              .SetImage(xx.Image)
              .SetPurchaseQty(1)
              .SetPrice(xx.GetDiscountedPrice())
              .Build();
        }

        public class MenuDetailBuilder : IMenuDetailBuilder
        {
            protected MenuDetailModel _menu;

            public MenuDetailBuilder()
            {
                _menu = new MenuDetailModel();
            }

            public MenuDetailBuilder SetMenuDetailID(int id)
            {
                _menu.Menudetail_id = id;
                return this;
            }

            public MenuDetailBuilder SetPrice(double price)
            {
                _menu.Price = price;
                return this;
            }

            public MenuDetailBuilder SetSizeName(string sizeName)
            {
                _menu.SizeName = sizeName;
                return this;
            }

            public MenuDetailBuilder SetFlavorName(string text)
            {
                _menu.FlavorName = text;
                return this;
            }

            public MenuDetailBuilder SetEstimatedTime(TimeSpan estimatedTime)
            {
                _menu.EstimatedTime = estimatedTime;
                return this;
            }

            public MenuDetailBuilder SetDiscountRate(double rate)
            {
                _menu.DiscountRate = rate;
                return this;
            }

            public MenuDetailBuilder SetDiscountId(int? id)
            {
                _menu.DiscountId = id;
                return this;
            }

            public MenuDetailBuilder SetMaxOrder(int maxOrder)
            {
                _menu.MaxOrder = maxOrder;
                return this;
            }

            public MenuDetailBuilder SetPurchaseQty(int purchaseQty)
            {
                _menu.PurchaseQty = purchaseQty;
                return this;
            }


            public MenuDetailBuilder SetMenuName(string name)
            {
                _menu.menuName = name;
                return this;
            }

            public MenuDetailBuilder SetMenuDescription(string txt)
            {
                _menu.menuDescription = txt;
                return this;
            }

            public MenuDetailBuilder SetMenuID(int id)
            {
                _menu.menu_id = id;
                return this;
            }

            public MenuDetailBuilder SetMenuCategoryID(int id)
            {
                _menu.menuCategory_id = id;
                return this;
            }

            public MenuDetailBuilder SetImage(Image img)
            {
                _menu.image = img;
                return this;
            }
            public MenuDetailModel Build()
            {
                return _menu;
            }

        }
    }
}