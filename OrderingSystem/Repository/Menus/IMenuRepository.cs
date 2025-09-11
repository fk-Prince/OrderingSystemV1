using System.Collections.Generic;
using System.Threading.Tasks;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.Repository.Menus
{
    public interface IMenuRepository
    {

        Task<List<Menu>> getMenu();
        Task<List<Menu>> getFrequentlyOrderedTogether(Menu menu);
    }
}
