using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;
using MenuModel = OrderingSystem.Model.MenuModel;

namespace OrderingSystem.Repository.Menus
{
    public interface IMenuRepository
    {

        Task<List<MenuDetailModel>> getMenu();
        Task<List<MenuDetailModel>> getFrequentlyOrderedTogether(MenuModel menu);
        Task<List<MenuDetailModel>> getMenuDetailFlavorPackage(MenuDetailModel md);
        Task<bool> isMenuPackage(MenuModel menu);
        Task<List<MenuDetailModel>> getMenuDetailFlavor(MenuModel menu);
        Task<List<MenuDetailModel>> getMenuDetailSizeByFlavor(int id, string flavorName);
        Task<List<MenuDetailModel>> getMenuId(int menu_id);
        Task<MenuDetailModel> getSelectedMenu(int menu_id, string flavorName, string sizeName);
        Task<double> getNewPackagePrice(int menu_id, List<MenuDetailModel> includedId);
        Task<int> getMaxOrderRealTime(int menu_id, List<MenuDetailModel> md);
    }
}
