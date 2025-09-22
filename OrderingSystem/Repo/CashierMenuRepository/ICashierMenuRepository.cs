using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.Repo.CashierMenuRepository
{
    public interface ICashierMenuRepository
    {
        Task<List<MenuDetailModel>> getMenu();
    }
}
