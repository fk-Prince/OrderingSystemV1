
using System.Drawing;

namespace OrderingSystem.Model
{
    public class MenuModel
    {

        protected string menuName;
        protected string menuDescription;
        protected Image image;
        protected int menuCategory_id;
        protected string menuCategoryName;
        protected int menu_id;

        public string MenuName => menuName;
        public string MenuDescription => menuDescription;
        public string MenuCategoryName => menuCategoryName;
        public Image Image => image;
        public int MenuCategory_id => menuCategory_id;
        public int Menu_id => menu_id;

    }
}