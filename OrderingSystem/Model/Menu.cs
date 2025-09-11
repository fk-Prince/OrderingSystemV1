using System.Collections.Generic;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class Menu
    {
        private string menuName;
        private string menuDescription;
        private Image image;
        private int menuCategory_id;
        private int menu_id;
        private int branches_id;
        private List<MenuDetail> menuDetailList;
        private MenuDetail menuDetail;

        public string MenuName { get => menuName; }
        public string MenuDescription { get => menuDescription; }
        public Image Image { get => image; }
        public int MenuCategory_id { get => menuCategory_id; }
        public int Menu_id { get => menu_id; }
        public List<MenuDetail> MenuDetailList { get => menuDetailList; }
        public MenuDetail MenuDetail { get => menuDetail; }
        public int Branches_id { get => branches_id; }


        public static MenuBuilder Builder() => new MenuBuilder();

        public class MenuBuilder
        {
            private Menu _menu;

            public MenuBuilder()
            {
                _menu = new Menu();
            }

            public MenuBuilder SetMenuName(string name)
            {
                _menu.menuName = name;
                return this;
            }
            public MenuBuilder SetMenuDescription(string txt)
            {
                _menu.menuDescription = txt;
                return this;
            }
            public MenuBuilder SetMenuID(int txt)
            {
                _menu.menu_id = txt;
                return this;
            }
            public MenuBuilder SetMenuCategoryID(int txt)
            {
                _menu.menuCategory_id = txt;
                return this;
            }
            public MenuBuilder SetImage(Image img)
            {
                _menu.image = img;
                return this;
            }

            public MenuBuilder SetBranchID(int text)
            {
                _menu.branches_id = text;
                return this;
            }
            public Menu Build()
            {
                return _menu;
            }

            public MenuBuilder SetMenuDetailList(List<MenuDetail> menuDetails)
            {
                _menu.menuDetailList = menuDetails;
                return this;
            }
            public MenuBuilder SetMenuDetail(MenuDetail menuDetails)
            {
                _menu.menuDetail = menuDetails;
                return this;
            }
        }
    }
}
