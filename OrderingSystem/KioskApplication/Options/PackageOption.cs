using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Layouts;
using OrderingSystem.KioskApplication.Options;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication.Services
{
    public class PackageOption : IMenuOptions, ISelectedFrequentlyOrdered, IOutOfOrder
    {
        private readonly IKioskMenuRepository _menuRepository;
        private readonly List<PackageLayout> _orderListPackage;
        private FlowLayoutPanel flowPanel;
        private FrequentlyOrderedOption frequentlyOrderedOption;
        private MenuDetailModel currentMenu;

        public event EventHandler outOfOrder;

        public PackageOption(IKioskMenuRepository menuRepository, FlowLayoutPanel flowPanel)
        {
            _menuRepository = menuRepository;
            this.flowPanel = flowPanel;
            _orderListPackage = new List<PackageLayout>();
            frequentlyOrderedOption = new FrequentlyOrderedOption(menuRepository, flowPanel);
        }

        public void menuOptions(MenuDetailModel menu)
        {
            currentMenu = menu;

            if (menu.MaxOrder <= 0)
            {
                outOfOrder?.Invoke(this, EventArgs.Empty);
                return;
            }

            List<MenuDetailModel> menuList = _menuRepository.getMenuId(menu.Menu_id);

            foreach (var item in menuList)
            {
                var pakage = new PackageLayout(_menuRepository, item);
                pakage.Margin = new Padding(20, 20, 0, 0);
                flowPanel.Controls.Add(pakage);
                _orderListPackage.Add(pakage);
            }

            frequentlyOrderedOption.diplsyFreqentlyOrdered(menu);
        }

        public List<MenuDetailModel> getFrequentlyOrdered()
        {
            return frequentlyOrderedOption?.getFrequentlyOrdered();
        }

        public List<MenuDetailModel> confirmOrder()
        {
            if (_orderListPackage.Any(pg => pg.SelectedMenuDetail == null || pg.SelectedMenuDetail.MaxOrder <= 0))
            {
                throw new OutOfOrder("Currently this menu is unavailable.");
            }

            var selectedMenus = _orderListPackage.Select(pg => pg.SelectedMenuDetail).ToList();
            double newPrice = _menuRepository.getNewPackagePrice(currentMenu.Menudetail_id, selectedMenus);
            var baseMenu = _menuRepository.getSelectedMenu(currentMenu.Menu_id, "", "");
            var purchasePackage = MenuPackageModel.BuildPurchasePackage(baseMenu, selectedMenus, newPrice);

            return new List<MenuDetailModel> { purchasePackage };
        }
    }
}
