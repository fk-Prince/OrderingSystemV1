using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Services
{
    public interface IMenuOptions
    {
        Task menuOptions(MenuDetailModel menu);
        Task<List<MenuDetailModel>> confirmOrder();
    }
}
