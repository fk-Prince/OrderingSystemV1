using System;
using System.Collections.Generic;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Builder;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication.Components
{
    public partial class SizeCard : Guna2Panel
    {
        public event EventHandler<Menu> SizeSelected;
        private Menu menu;
        public SizeCard(Menu menu, List<MenuDetail> menuDetails)
        {
            InitializeComponent();
            this.menu = menu;

            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;

            displaySizes(menuDetails);
        }



        private void displaySizes(List<MenuDetail> menuDetails)
        {
            int y = 40;
            bool isFirst = true;
            List<RadioSample> radioSamples = new List<RadioSample>();
            foreach (var m in menuDetails)
            {
                double p = m.getDiscountedPrice() - menuDetails[0].getDiscountedPrice();
                string priceText = p.ToString("N2");
                string displayPrice = isFirst ? "Free" : priceText;

                RadioSample rs = new RadioSample(m.SizeName, displayPrice, m);
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
    }
}
