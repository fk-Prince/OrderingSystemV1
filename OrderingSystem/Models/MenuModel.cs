
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

    }
}