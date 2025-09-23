using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Services
{
    public interface IMenuOptions
    {
        void menuOptions(MenuDetailModel menu);
        List<MenuDetailModel> confirmOrder();
    }
}
