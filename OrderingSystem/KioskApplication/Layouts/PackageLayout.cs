using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication.Layouts
{
    public partial class PackageLayout : Guna2Panel
    {
        private string titleOption;
        private string subTitle;
        private SizeLayout sc;
        private IKioskMenuRepository _menuRepository;
        private MenuDetailModel menuDetail;


        private MenuDetailModel selectedFlavor;
        private MenuDetailModel selectedSize;


        private MenuDetailModel selectedMenu;


        public MenuDetailModel SelectedMenuDetail => selectedMenu;

        public PackageLayout(IKioskMenuRepository menuRepository, MenuDetailModel menuDetail)
        {
            InitializeComponent();

            this._menuRepository = menuRepository;
            this.menuDetail = menuDetail;

            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;

            displayFlavor(menuDetail);
        }

        private void fetchMenuSizeByFlavorOption(int menuId, string flavorName)
        {
            try
            {

                List<MenuDetailModel> menuSize = _menuRepository.getMenuDetailSizeByFlavor(menuId, flavorName);
                displaySize(menuSize);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }

        private void displayFlavor(MenuDetailModel menuFlavorList)
        {
            titleOption = "Option A";
            subTitle = $"Select Flavor of your choice.";
            try
            {
                List<MenuDetailModel> menuSize = _menuRepository.getMenuDetailFlavorPackage(menuDetail);
                List<MenuDetailModel> mds = new List<MenuDetailModel>();
                mds.Add(menuFlavorList);
                mds.AddRange(menuSize);


                if (mds.Count > 1)
                {
                    FlavorLayout fl = new FlavorLayout(mds);
                    fl.Margin = new Padding(0);
                    fl.BorderThickness = 0;
                    fl.BorderRadius = 0;
                    fl.FlavorSelected += flavorSelected;
                    fl.setTitle(titleOption, menuDetail.MenuName);
                    fl.setSubTitle(subTitle);
                    fl.defaultSelection();
                    flowPanel.Controls.Add(fl);
                    adjustHeight();
                    titleOption = "Option B";
                }
                else
                {
                    selectedFlavor = menuDetail;
                    fetchMenuSizeByFlavorOption(menuDetail.Menu_id, menuDetail.FlavorName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error");
            }
        }



        private void flavorSelected(object sender, MenuDetailModel e)
        {
            selectedFlavor = e;

            if (sc != null)
            {
                if (flowPanel.Controls.Contains(sc))
                {
                    flowPanel.Controls.Remove(sc);
                }
                sc.Dispose();
                sc = null;
                resetHeight();
            }
            if (e != null)
                fetchMenuSizeByFlavorOption(e.Menu_id, e.FlavorName);
        }

        private void displaySize(List<MenuDetailModel> menuList)
        {
            try
            {
                if (sc != null)
                {
                    if (flowPanel.Controls.Contains(sc))
                    {
                        flowPanel.Controls.Remove(sc);
                    }
                    sc.Dispose();
                    sc = null;
                }

                if (menuList != null && menuList.Count > 1)
                {

                    subTitle = $"Select Size of your choice.";

                    sc = new SizeLayout(selectedFlavor, menuList);
                    sc.Margin = new Padding(0);
                    sc.BorderThickness = 0;
                    sc.BorderRadius = 0;
                    sc.setTitleOption(titleOption, menuList[0].MenuName);
                    sc.setSubTitle(subTitle);

                    sc.SizeSelected += (s, e) =>
                    {
                        selectedSize = e;

                        string flavorName = selectedFlavor?.FlavorName ?? "";
                        string sizeName = selectedSize?.SizeName ?? "";
                        if (flavorName == "" && sizeName == "") return;
                        selectedMenu = _menuRepository.getSelectedMenu(menuList[0].Menu_id, flavorName, sizeName);
                    };

                    flowPanel.Controls.Add(sc);
                    sc.defaultSelection();
                    adjustHeight();
                }
                else
                {
                    selectedSize = menuList[0];
                    string flavorName = selectedFlavor?.FlavorName ?? "";
                    string sizeName = selectedSize?.SizeName ?? "";

                    selectedMenu = _menuRepository.getSelectedMenu(menuList[0].Menu_id, flavorName, sizeName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error");
            }
        }

        private void adjustHeight()
        {
            int totalHeight = 0;
            foreach (Control control in flowPanel.Controls)
            {
                totalHeight += control.Height + control.Margin.Top;
            }

            flowPanel.Height = totalHeight;
            Height = totalHeight + 10;

            PerformLayout();
            Parent?.PerformLayout();
        }

        private void resetHeight()
        {
            int heigt = 0;
            foreach (Control control in flowPanel.Controls)
            {
                if (control is FlavorLayout)
                {
                    heigt += control.Height + control.Margin.Top;
                }
            }

            flowPanel.Height = heigt;
            Height = heigt + 10;

            PerformLayout();
            Parent?.PerformLayout();
        }
    }
}
