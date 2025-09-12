using System;
using System.Collections.Generic;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Builder;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication.Components
{
    public partial class SizeLayout : Guna2Panel
    {
        public event EventHandler<Menu> SizeSelected;
        private List<MenuDetail> menuDetails;
        private List<RadioSize> radioSamples;
        private Menu menu;
        public SizeLayout(Menu menu, List<MenuDetail> menuDetails)
        {
            InitializeComponent();
            this.menu = menu;
            this.menuDetails = menuDetails;

            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;

            displaySizes();
        }



        private void displaySizes()
        {
            int y = 40;
            bool isFirst = true;
            radioSamples = new List<RadioSize>();
            foreach (var m in menuDetails)
            {
                double p = m.getDiscountedPrice() - menuDetails[0].getDiscountedPrice();
                string priceText = p.ToString("N2");
                string displayPrice = isFirst ? "Free" : priceText;

                RadioSize rs = new RadioSize(m.SizeName, displayPrice, m);
                rs.Location = new Point(50, titleOption.Bottom + y);
                rs.RadioCheckedChanged += (s, e) =>
                {

                    foreach (var r in radioSamples)
                    {
                        if (r != rs)
                        {
                            r.Radio().Checked = false;
                        }
                    }
                    var selected = new PurchaseBuilder().Build(menu, e);
                    SizeSelected?.Invoke(this, selected);

                };
                Controls.Add(rs);
                radioSamples.Add(rs);
                y += 50;
                this.Height += 40;
                isFirst = false;
            }

        }

        public void defaultSelection()
        {
            if (menuDetails.Count > 0 && radioSamples.Count > 0)
            {
                radioSamples[0].Radio().Checked = true;
                var selected = new PurchaseBuilder().Build(menu, menuDetails[0]);
                SizeSelected?.Invoke(this, selected);
            }
        }
    }
}
