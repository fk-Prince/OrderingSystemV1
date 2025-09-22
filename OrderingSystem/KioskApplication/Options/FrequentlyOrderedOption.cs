using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication.Options
{
    public class FrequentlyOrderedOption : ISelectedFrequentlyOrdered
    {
        private FrequentlyOrderedLayout fot;
        private FlowLayoutPanel flowPanel;
        private IKioskMenuRepository menuRepository;
        public FrequentlyOrderedOption(IKioskMenuRepository menuRepository, FlowLayoutPanel flowPanel)
        {
            this.flowPanel = flowPanel;
            this.menuRepository = menuRepository;
        }

        public async Task diplsyFreqentlyOrdered(MenuDetailModel menus)
        {
            try
            {
                List<MenuDetailModel> md = await menuRepository.getFrequentlyOrderedTogether(menus);
                if (flowPanel.Contains(fot))
                {
                    flowPanel.Controls.SetChildIndex(fot, flowPanel.Controls.Count - 1);
                    return;
                }
            ;
                fot = new FrequentlyOrderedLayout(md);
                fot.Margin = new Padding(20, 30, 0, 0);
                flowPanel.Controls.Add(fot);
                if (flowPanel.Controls.Contains(fot))
                {
                    flowPanel.Controls.SetChildIndex(fot, flowPanel.Controls.Count - 1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }

        public List<MenuDetailModel> getFrequentlyOrdered()
        {
            if (fot != null)
            {
                return fot.getFrequentlyOrderList();
            }
            return null;
        }
    }
}
