﻿using System.Collections.Generic;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication
{
    public partial class FrequentlyOrderedLayout : Guna2Panel
    {

        private List<MenuDetailModel> checkList;
        public FrequentlyOrderedLayout(List<MenuDetailModel> menus)
        {
            InitializeComponent();
            checkList = new List<MenuDetailModel>();

            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;

            displayFrequentlyOrdered(menus);
        }
        private void displayFrequentlyOrdered(List<MenuDetailModel> menu)
        {
            int y = 30;

            foreach (var m in menu)
            {

                FrequentlyOrderedCard fot = new FrequentlyOrderedCard(m);
                fot.Location = new Point(20, title.Bottom + y);
                fot.checkedMenu += (s, e) => { checkList.Add(e); };
                fot.unCheckedMenu += (s, e) => { checkList.Remove(e); };
                this.Controls.Add(fot);
                y += 120;
                this.Height += 110;
            }

        }

        public List<MenuDetailModel> getFrequentlyOrderList()
        {
            return checkList;
        }
    }
}
