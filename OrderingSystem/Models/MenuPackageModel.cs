using System;
using System.Collections.Generic;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class MenuPackageModel : MenuDetailModel
    {
        private List<MenuDetailModel> menuDetailList;
        public List<MenuDetailModel> MenuDetailList => menuDetailList;

        public static new MenuPackageBuilder Builder() => new MenuPackageBuilder();

        public static MenuPackageModel BuildPurchasePackage(MenuDetailModel xx, List<MenuDetailModel> included, double newPrice)
        {
            return Builder()
                .SetMenuName(xx.MenuName)
                .SetMenuID(xx.Menu_id)
                .SetImage(xx.Image)
                .SetMenuDetailID(xx.Menudetail_id)
                .SetEstimatedTime(xx.EstimatedTime)
                .SetDiscountId(xx.DiscountId)
                .SetMenuDetailList(included)
                .SetPurchaseQty(1)
                .SetSizeName(xx.SizeName)
                .SetFlavorName(xx.FlavorName)
                .SetPrice(newPrice)
                .Build();
        }
        public class MenuPackageBuilder
        {
            protected MenuPackageModel _menu;
            public MenuPackageBuilder()
            {
                _menu = new MenuPackageModel();
                _menu.menuDetailList = new List<MenuDetailModel>();
            }

            public MenuPackageBuilder SetMenuName(string name)
            {
                _menu.menuName = name;
                return this;
            }

            public MenuPackageBuilder SetMenuDescription(string txt)
            {
                _menu.menuDescription = txt;
                return this;
            }

            public MenuPackageBuilder SetMenuID(int id)
            {
                _menu.menu_id = id;
                return this;
            }

            public MenuPackageBuilder SetMaxOrder(int id)
            {
                _menu.MaxOrder = id;
                return this;
            }

            public MenuPackageBuilder SetImage(Image img)
            {
                _menu.image = img;
                return this;
            }
            public MenuPackageBuilder SetPurchaseQty(int purchaseQty)
            {
                _menu.PurchaseQty = purchaseQty;
                return this;
            }
            public MenuPackageBuilder SetMenuDetailID(int id)
            {
                _menu.Menudetail_id = id;
                return this;
            }

            public MenuPackageBuilder SetPrice(double price)
            {
                _menu.Price = price;
                return this;
            }

            public MenuPackageBuilder SetSizeName(string sizeName)
            {
                _menu.SizeName = sizeName;
                return this;
            }

            public MenuPackageBuilder SetFlavorName(string text)
            {
                _menu.FlavorName = text;
                return this;
            }

            public MenuPackageBuilder SetEstimatedTime(TimeSpan estimatedTime)
            {
                _menu.EstimatedTime = estimatedTime;
                return this;
            }

            public MenuPackageBuilder SetDiscountRate(double rate)
            {
                _menu.DiscountRate = rate;
                return this;
            }

            public MenuPackageBuilder SetDiscountId(int? id)
            {
                _menu.DiscountId = id;
                return this;
            }
            public MenuPackageBuilder SetMenuDetailList(List<MenuDetailModel> list)
            {
                _menu.menuDetailList = list;
                return this;
            }

            public MenuPackageBuilder AddMenuDetail(MenuDetailModel detail)
            {
                _menu.menuDetailList.Add(detail);
                return this;
            }

            public MenuPackageModel Build()
            {
                return _menu;
            }
        }
    }
}
