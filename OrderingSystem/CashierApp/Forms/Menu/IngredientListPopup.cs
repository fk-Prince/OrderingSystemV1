using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class IngredientListPopup : Form
    {
        private DataTable table;
        private ICashierMenuRepository cashierMenuRepository;
        private IIngredientRepository ingredientRepository;
        public IngredientListPopup(ICashierMenuRepository cashierMenuRepository)
        {
            InitializeComponent();
            this.cashierMenuRepository = cashierMenuRepository;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            dataGrid.Columns.Add(checkBoxColumn);

            List<IngredientModel> i = ingredientRepository.getIngredients();

            table = new DataTable();
            table.Columns.Add("Ingredient Name");
            table.Columns.Add("Quantity");
            dataGrid.DataSource = table;





        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrid.Columns["Select"].Index && e.RowIndex >= 0)
            {
                bool isChecked = Convert.ToBoolean(dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGrid.Rows[e.RowIndex].Cells[i].ReadOnly = !isChecked;
                }
            }
        }

        private void dataGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGrid.IsCurrentCellDirty)
            {
                dataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
