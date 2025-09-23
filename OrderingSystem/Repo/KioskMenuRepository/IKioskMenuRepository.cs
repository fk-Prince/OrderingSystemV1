using System.Collections.Generic;
using OrderingSystem.Model;
using MenuModel = OrderingSystem.Model.MenuModel;

namespace OrderingSystem.Repository.Menus
{
    public interface IKioskMenuRepository
    {

        List<MenuDetailModel> getMenu();
        List<MenuDetailModel> getFrequentlyOrderedTogether(MenuModel menu);
        List<MenuDetailModel> getMenuDetailFlavorPackage(MenuDetailModel md);
        bool isMenuPackage(MenuModel menu);
        List<MenuDetailModel> getMenuDetailFlavor(MenuModel menu);
        List<MenuDetailModel> getMenuDetailSizeByFlavor(int id, string flavorName);
        List<MenuDetailModel> getMenuId(int menu_id);
        MenuDetailModel getSelectedMenu(int menu_id, string flavorName, string sizeName);
        double getNewPackagePrice(int menu_id, List<MenuDetailModel> includedId);
        int getMaxOrderRealTime(int menu_id, List<MenuDetailModel> md);
    }
}
