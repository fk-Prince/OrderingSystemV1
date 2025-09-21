
using System.Drawing;

namespace OrderingSystem.Model
{
    public class MenuModel
    {

        protected string menuName;
        protected string menuDescription;
        protected Image image;
        protected int menuCategory_id;
        protected int menu_id;

        public string MenuName => menuName;
        public string MenuDescription => menuDescription;
        public Image Image => image;
        public int MenuCategory_id => menuCategory_id;
        public int Menu_id => menu_id;


        //    public abstract class MenuBuilder<TBuilder, TMenu>
        //        where TBuilder : MenuBuilder<TBuilder, TMenu>
        //        where TMenu : Menu, new()
        //    {
        //        protected TMenu _menu = new TMenu();

        //        public TBuilder SetMenuName(string name)
        //        {
        //            _menu.menuName = name;
        //            return (TBuilder)this;
        //        }

        //        public TBuilder SetMenuDescription(string txt)
        //        {
        //            _menu.menuDescription = txt;
        //            return (TBuilder)this;
        //        }

        //        public TBuilder SetMenuID(int id)
        //        {
        //            _menu.menu_id = id;
        //            return (TBuilder)this;
        //        }

        //        public TBuilder SetMenuCategoryID(int id)
        //        {
        //            _menu.menuCategory_id = id;
        //            return (TBuilder)this;
        //        }

        //        public TBuilder SetImage(Image img)
        //        {
        //            _menu.image = img;
        //            return (TBuilder)this;
        //        }

        //        public virtual TMenu Build()
        //        {
        //            return _menu;
        //        }
        //    }
        //}

    }
}