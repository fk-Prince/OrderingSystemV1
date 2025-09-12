using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Repository.Menus;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication
{
    public partial class FrequentlyOrderedLayout : Guna2Panel
    {
        private IMenuRepository menuRepository;
        private Menu menu;
        private List<Menu> checkList;
        public FrequentlyOrderedLayout(IMenuRepository menuRepository, Menu menu)
        {
            InitializeComponent();
            checkList = new List<Menu>();
            this.menuRepository = menuRepository;
            this.menu = menu;
            HandleCreated += async (s, e) => { await asyncFunction(); };

            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;
        }
        private void displayFOT(List<Menu> menu)
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

        private async Task asyncFunction()
        {
            List<Menu> menus = await menuRepository.getFrequentlyOrderedTogether(menu);
            displayFOT(menus);
        }

        public List<Menu> getFrequentlyOrderList()
        {
            return checkList;
        }
    }
}
