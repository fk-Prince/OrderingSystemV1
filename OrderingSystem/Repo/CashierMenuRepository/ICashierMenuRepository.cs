using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repo.CashierMenuRepository
{
    public interface ICashierMenuRepository
    {
        List<MenuDetailModel> getMenu();
    }
}
