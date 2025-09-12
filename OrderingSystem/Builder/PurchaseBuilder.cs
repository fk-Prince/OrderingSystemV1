using OrderingSystem.Model;

namespace OrderingSystem.Builder
{
    public class PurchaseBuilder
    {
        public Menu Build(Menu m, MenuDetail xx)
        {
            var mm = MenuDetail.Builder()
                .SetMenuDetailID(xx.Menudetail_id)
                .SetPurchaseQty(1)
                .SetSizeName(xx.SizeName)
                .SetPrice(xx.getDiscountedPrice())
                .Build();

            return Menu.Builder()
                .SetMenuName(m.MenuName)
                .SetMenuID(m.Menu_id)
                .SetBranchID(m.Branches_id)
                .SetMenuDetail(mm)
                .Build();
        }
    }
}
