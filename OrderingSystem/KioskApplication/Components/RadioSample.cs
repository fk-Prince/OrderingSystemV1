using System;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Components
{
    public partial class RadioSample : Guna2Panel
    {
        public event EventHandler<MenuDetail> RadioCheckedChanged;
        public RadioSample(string namex, string xprice, MenuDetail m)
        {
            InitializeComponent();

            price.Text = xprice == "Free" ? xprice : "+   " + xprice;
            name.Text = namex;

            radioButton.CheckedChanged += (s, e) =>
            {
                if (radioButton.Checked)
                {
                    //var pb = new PurchaseBuilder().Build(m);
                    RadioCheckedChanged?.Invoke(this, m);
                }
            };
        }

        public Guna2CustomRadioButton Radio()
        {
            return radioButton;
        }
    }
}
