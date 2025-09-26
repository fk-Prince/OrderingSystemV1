using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repo.CashierMenuRepository
{
    public interface ICashierMenuRepository
    {
        List<string> getFlavor();
        List<MenuDetailModel> getMenu();
        List<string> getSize();
    }
}
