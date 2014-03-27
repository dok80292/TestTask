using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Task
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cottagersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cottagersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testTaskDBDataSet);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testTaskDBDataSet.Tariff". При необходимости она может быть перемещена или удалена.
            this.tariffTableAdapter.Fill(this.testTaskDBDataSet.Tariff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testTaskDBDataSet.Tariff". При необходимости она может быть перемещена или удалена.
            this.tariffTableAdapter.Fill(this.testTaskDBDataSet.Tariff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testTaskDBDataSet.WaterConsumption". При необходимости она может быть перемещена или удалена.
            this.waterConsumptionTableAdapter.Fill(this.testTaskDBDataSet.WaterConsumption);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testTaskDBDataSet.Bill". При необходимости она может быть перемещена или удалена.
            this.billTableAdapter.Fill(this.testTaskDBDataSet.Bill);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testTaskDBDataSet.Cottagers". При необходимости она может быть перемещена или удалена.
            this.cottagersTableAdapter.Fill(this.testTaskDBDataSet.Cottagers);
            if (tariffDataGridView.RowCount == 0)
            {
                ввестиПоказанияToolStripMenuItem.Enabled = false;

            }
            else
            {
                ввестиТарифToolStripMenuItem.Enabled = false;
            }

            if (cottagersDataGridView.RowCount == 0)
            {
                ввестиПоказанияToolStripMenuItem.Enabled = false;
            }
        }

        public void CottagerAdd(int Number, double Area)
        {
            TestTaskDBDataSet.CottagersRow newCottagerRow;
            newCottagerRow = testTaskDBDataSet.Cottagers.NewCottagersRow();
            newCottagerRow.CottageNumber = Number;
            newCottagerRow.CottageArea = Area;

            this.testTaskDBDataSet.Cottagers.Rows.Add(newCottagerRow);
            this.Validate();
            this.cottagersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testTaskDBDataSet);
            this.cottagersTableAdapter.Fill(this.testTaskDBDataSet.Cottagers);

        }

        public void PriceAdd(decimal Price)
        {
            TestTaskDBDataSet.TariffRow newTariffRow;
            newTariffRow = testTaskDBDataSet.Tariff.NewTariffRow();
            newTariffRow.Price = Price;

            this.testTaskDBDataSet.Tariff.Rows.Add(newTariffRow);
            this.Validate();
            this.tariffBindingSource.EndEdit();
            this.tariffTableAdapter.Update(newTariffRow);
            this.tariffTableAdapter.Fill(this.testTaskDBDataSet.Tariff);

        }

        public void WaterConsumptionAdd(DateTime date, double water)
        {
            TestTaskDBDataSet.WaterConsumptionRow newWaterConsumptionRow;
            newWaterConsumptionRow = testTaskDBDataSet.WaterConsumption.NewWaterConsumptionRow();
            newWaterConsumptionRow.Date = date;
            newWaterConsumptionRow.WaterQuantity = water;
            this.testTaskDBDataSet.WaterConsumption.Rows.Add(newWaterConsumptionRow);
            this.Validate();
            this.waterConsumptionBindingSource.EndEdit();
            this.waterConsumptionTableAdapter.Update(newWaterConsumptionRow);
            this.waterConsumptionTableAdapter.Fill(this.testTaskDBDataSet.WaterConsumption);
            this.tableAdapterManager.UpdateAll(this.testTaskDBDataSet);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                TestTaskDBDataSet.CottagersRow CottagerRowForDelete;
                CottagerRowForDelete = testTaskDBDataSet.Cottagers.FindByIdCottager((int)cottagersDataGridView.CurrentRow.Cells[0].Value);
                CottagerRowForDelete.Delete();
                this.Validate();
                this.cottagersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.testTaskDBDataSet);
                this.cottagersTableAdapter.Fill(this.testTaskDBDataSet.Cottagers);
            }
            catch { }
        }

        private void cottagersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Validate();
                this.cottagersBindingSource.EndEdit();
                this.waterConsumptionBindingSource.EndEdit();
                this.tariffBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.testTaskDBDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.billTableAdapter.Fill(this.testTaskDBDataSet.Bill);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void удалитьДачникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TestTaskDBDataSet.CottagersRow CottagerRowForDelete;
                CottagerRowForDelete = testTaskDBDataSet.Cottagers.FindByIdCottager((int)cottagersDataGridView.CurrentRow.Cells[0].Value);
                CottagerRowForDelete.Delete();
                this.Validate();
                this.cottagersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.testTaskDBDataSet);
                this.cottagersTableAdapter.Fill(this.testTaskDBDataSet.Cottagers);
            }
            catch { }

            if (cottagersDataGridView.RowCount == 0)
            {
                ввестиПоказанияToolStripMenuItem.Enabled = false;
            }
        }

        private void добавитьДачникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            AddCottagerForm AC = new AddCottagerForm();
            AC.Owner = this;
            AC.ShowDialog();
        }

        private void ввестиТарифToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTariffForm AT = new AddTariffForm();
            AT.Owner = this;
            AT.ShowDialog();
            if (tariffDataGridView.RowCount != 0)
            {
                ввестиТарифToolStripMenuItem.Enabled = false;
            }

        }

        private void ввестиПоказанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWaterConsumptionForm AWC = new AddWaterConsumptionForm();
            AWC.Owner = this;
            AWC.ShowDialog();
        }

        private void tariffDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (cottagersDataGridView.RowCount != 0)
            {
                ввестиПоказанияToolStripMenuItem.Enabled = true;
            }
        }

        private void cottagersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (tariffDataGridView.RowCount != 0)
            {
                ввестиПоказанияToolStripMenuItem.Enabled = true;
            }
        }

        private void tariffDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            tariffDataGridView.Rows[e.RowIndex].ErrorText = "";
            double newDouble;

            if (tariffDataGridView.Rows[e.RowIndex].IsNewRow) { return; }
            if (!double.TryParse(e.FormattedValue.ToString(), out newDouble))
            {
                e.Cancel = true;
                tariffDataGridView.Rows[e.RowIndex].ErrorText = "Значение должно быть числом";
            }
        }

        private void waterConsumptionDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                waterConsumptionDataGridView.Rows[e.RowIndex].ErrorText = "";
                double newDouble;

                if (waterConsumptionDataGridView.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(), out newDouble))
                {
                    e.Cancel = true;
                    waterConsumptionDataGridView.Rows[e.RowIndex].ErrorText = "Значение должно быть числом";
                }
            }
        }

        private void cottagersDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            cottagersDataGridView.Rows[e.RowIndex].ErrorText = "";
            if (e.ColumnIndex == 1)
            {
                int newInt;

                if (cottagersDataGridView.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(), out newInt))
                {
                    e.Cancel = true;
                    cottagersDataGridView.Rows[e.RowIndex].ErrorText = "Значение должно быть целым числом";
                }
            }
            if (e.ColumnIndex == 2)
            {
                double newDouble;

                if (cottagersDataGridView.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(), out newDouble))
                {
                    e.Cancel = true;
                    cottagersDataGridView.Rows[e.RowIndex].ErrorText = "Значение должно быть числом";
                }
            }
        }
    }
}
