namespace SAPR.Forns
{
    using System;
    using SAPR.Models;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public partial class RepairWagons_Form : Form
    {
        private List<RepairGroup> repairGroups = new List<RepairGroup>();

        public RepairWagons_Form()
        {
            InitializeComponent();
        }

        private void GroupQty_ValueChanged_1(object sender, EventArgs e)
        {
            int newRowCount = (int)GroupQty.Value;

            // Створюємо список, щоб зберігати дані з попередніх рядків
            List<object[]> previousRows = new List<object[]>();

            // Записуємо дані з попередніх рядків у список
            foreach (DataGridViewRow row in WagonRepairGrid.Rows)
            {
                object[] rowData = new object[5];
                for (int i = 0; i < 5; i++)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                previousRows.Add(rowData);
            }

            WagonRepairGrid.Rows.Clear();
            if (newRowCount > WagonRepairGrid.Rows.Count) // якщо потрібно додати рядки
            {
                // створюємо нові рядки і додаємо їх до DataGridView
                for (int i = WagonRepairGrid.Rows.Count; i < newRowCount; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(WagonRepairGrid);

                    DataGridViewComboBoxCell wagonTypeCell = new DataGridViewComboBoxCell();
                    wagonTypeCell.Items.AddRange(new string[] { "Піввагон", "Цистерна", "Критий", "Плафторма", "Хопер", "Думпкар", "Окатишевоз", "Вагон - бункер", "Спецвагон 1", "Спецвагон 2" });
                    row.Cells[1] = wagonTypeCell;

                    DataGridViewComboBoxCell repairTypeCell = new DataGridViewComboBoxCell();
                    repairTypeCell.Items.AddRange(new string[] { "Д", "К", "М", "У" });
                    row.Cells[2] = repairTypeCell;

                    // Записуємо дані з попередніх рядків у нові рядки, якщо це можливо
                    if (i < previousRows.Count)
                    {
                        object[] rowData = previousRows[i];
                        for (int j = 0; j < 5; j++)
                        {
                            row.Cells[j].Value = rowData[j];
                        }
                    }
                    else
                    {
                        row.Cells[0].Value = i + 1;
                        row.Cells[3].Value = 0;
                        row.Cells[4].Value = 0;
                    }

                    WagonRepairGrid.Rows.Add(row);
                }
            }
            else if (newRowCount < WagonRepairGrid.Rows.Count) // якщо потрібно видалити рядки
            {
                // видаляємо зайві рядки з DataGridView
                for (int i = WagonRepairGrid.Rows.Count - 1; i >= newRowCount; i--)
                {
                    WagonRepairGrid.Rows.RemoveAt(i);
                    repairGroups.RemoveAt(i);
                }
            }
        }

        private void RepairWagons_Form_Load(object sender, EventArgs e)
        {
            string[] headerText = new string[] {
            "Група","Тип Вагона","Вид ремонта","Кількість вагонів","Трудомісткість"
            };

            // Створення колонок з назвами
            foreach (string header in headerText)
            {
                var column = new DataGridViewTextBoxColumn();
                column.Name = header;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                WagonRepairGrid.Columns.Add(column);
            }

            WagonRepairGrid.AllowUserToAddRows = false;
        }


        private void WagonRepairGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // перевірка, що змінюється не заголовок колонки і не порожній рядок
            {
                DataGridViewRow row = WagonRepairGrid.Rows[e.RowIndex];
                int g = Convert.ToInt32(row.Cells[0].Value);
                string ct = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                string kr = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                int cq = Convert.ToInt32(row.Cells[3].Value);
                int hc = Convert.ToInt32(row.Cells[4].Value);
                var model = new RepairGroup
                {
                    GroupNumber = g,
                    CarType = ct,
                    KindRepair = kr,
                    CarQty = cq,
                    HardComplains = hc
                };
                if (e.RowIndex < repairGroups.Count) // якщо рядок вже був доданий до списку, замінюємо його значення
                {
                    repairGroups[e.RowIndex] = model;
                }
                else // якщо рядок є новим, додаємо новий об'єкт до списку
                {
                    repairGroups.Add(model);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            int sum = 0;
            foreach (RepairGroup group in repairGroups)
            {
                sum += group.CarQty * group.HardComplains;
            }
            if (QntWorkingDaysInYear.Text != "" && QntWorkingShiftTextBox.Text != "" && DurationWorkingShiftTextBox.Text != "")
                sum /= (int.Parse(QntWorkingDaysInYear.Text) * int.Parse(QntWorkingShiftTextBox.Text) * int.Parse(DurationWorkingShiftTextBox.Text));
            MainWorkersCount.Text = sum.ToString();
            ChoresWorkersCount.Text = Math.Round(sum * Double.Parse(ChoresWorkingPercentTextBox.Text.ToString()) / 100).ToString();
            CommonWorkersCount.Text = (int.Parse(MainWorkersCount.Text) + int.Parse(ChoresWorkersCount.Text)).ToString();
            SupportWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.16).ToString();
            EngineerWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.06).ToString();
            AccountingWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.02).ToString();
            JuniorServiceWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.02).ToString();
            initializeWorkersGrids();
            updateGrid(MainWorkersGrid, int.Parse(MainWorkersCount.Text));
            updateGrid(ChoresWorkersGrid, int.Parse(ChoresWorkersCount.Text));
        }

        private void initializeWorkersGrids()
        {
            if (MainWorkersGrid.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in WorkersGridData.getMainWorkersRows(MainWorkersGrid))
                {
                    MainWorkersGrid.Rows.Add(row);
                }
                foreach (DataGridViewRow row in WorkersGridData.getChoresWorkersRows(MainWorkersGrid))
                {
                    ChoresWorkersGrid.Rows.Add(row);
                }
            }
        }

        private void updateGrid(DataGridView gridView, int employersCount) {
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Cells[1].Value.ToString() != "")
                {
                    row.Cells[2].Value = Math.Round(double.Parse(row.Cells[1].Value.ToString()) * employersCount / 100);
                }
            }
        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1) ;
        }
    }
}
