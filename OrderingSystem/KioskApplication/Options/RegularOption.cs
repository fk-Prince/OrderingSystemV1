using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication.Options
{
    public class RegularOption : IMenuOptions, IOutOfOrder, ISelectedFrequentlyOrdered
    {
        private IMenuRepository _menuRepository;
        private string titleOption;
        private string subTitle;
        private SizeLayout sc;
        private MenuDetailModel menu;
        private FlowLayoutPanel flowPanel;
        private MenuDetailModel selectedFlavor;
        private FrequentlyOrderedOption frequentlyOrderedOption;
        private MenuDetailModel selectedSize;
        public event EventHandler outOfOrder;

        public RegularOption(IMenuRepository menuRepository, FlowLayoutPanel flowPanel)
        {
            _menuRepository = menuRepository;
            this.flowPanel = flowPanel;

            frequentlyOrderedOption = new FrequentlyOrderedOption(menuRepository, flowPanel);
        }
        public async Task menuOptions(MenuDetailModel menu)
        {
            try
            {
                if (!await _menuRepository.isMenuPackage(menu))
                {
                    this.menu = menu;
                    List<MenuDetailModel> menuFlavorList = await _menuRepository.getMenuDetailFlavor(menu);
                    displayFlavor(menuFlavorList);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error");
            }
        }

        private async void displayFlavor(List<MenuDetailModel> menuFlavorList)
        {
            titleOption = "Option A";
            subTitle = "Select Flavor of your choice.";
            try
            {

                if (menuFlavorList.Count > 1)
                {
                    FlavorLayout fl = new FlavorLayout(menuFlavorList);
                    fl.Margin = new Padding(20, 30, 0, 0);
                    fl.FlavorSelected += async (s, e) => await flavorSelected(s, e);
                    fl.setTitle(titleOption, menu.MenuName);
                    fl.setSubTitle(subTitle);
                    fl.defaultSelection();
                    flowPanel.Controls.Add(fl);
                    titleOption = "Option B";
                }
                else
                {
                    if (menuFlavorList[0].MaxOrder > 0)
                    {
                        selectedFlavor = menuFlavorList[0];

                    }
                    await fetchMenuSizeByFlavorOption(menu.Menu_id, "");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }

        }
        private async Task flavorSelected(object sender, MenuDetailModel e)
        {
            try
            {
                if (e != null)
                {
                    await fetchMenuSizeByFlavorOption(e.Menu_id, e.FlavorName);
                    selectedFlavor = e;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
        private async Task fetchMenuSizeByFlavorOption(int id, string flavorName)
        {
            try
            {

                List<MenuDetailModel> menuSize = await _menuRepository.getMenuDetailSizeByFlavor(id, flavorName);
                displaySize(menuSize);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
        private async void displaySize(List<MenuDetailModel> menuList)
        {
            if (sc != null) flowPanel.Controls.Remove(sc);

            if (menuList.Count > 1)
            {
                subTitle = "Select Size of your choice";
                sc = new SizeLayout(selectedFlavor, menuList);
                sc.Margin = new Padding(20, 30, 0, 0);
                sc.SizeSelected += (s, e) => selectedSize = e;
                sc.setTitleOption(titleOption, menuList[0].MenuName);
                sc.setSubTitle(subTitle);
                sc.defaultSelection();
                flowPanel.Controls.Add(sc);
            }
            else
            {
                if (menuList[0].MaxOrder > 0)
                {
                    selectedSize = menuList[0];
                }
                else
                {
                    outOfOrder.Invoke(this, EventArgs.Empty);
                }
            }
            if (menuList[0].MaxOrder > 0)
            {
                await frequentlyOrderedOption.diplsyFreqentlyOrdered(menu);
            }
        }
        public List<MenuDetailModel> getFrequentlyOrdered()
        {
            if (frequentlyOrderedOption != null)
                return frequentlyOrderedOption.getFrequentlyOrdered();

            return null;
        }
        public async Task<List<MenuDetailModel>> confirmOrder()
        {
            if (selectedFlavor == null && selectedSize == null)
            {
                throw new NoSelectedMenu("No Selected Menu.");
            }

            string flavorName = selectedFlavor?.FlavorName ?? "";
            string sizeName = selectedSize?.SizeName ?? "";
            var selectedMenu = await _menuRepository.getSelectedMenu(menu.Menu_id, flavorName, sizeName);
            var purchaseMenu = MenuDetailModel.BuildPurchaseMenu(selectedMenu);

            return new List<MenuDetailModel> { purchaseMenu };

        }
    }
}
