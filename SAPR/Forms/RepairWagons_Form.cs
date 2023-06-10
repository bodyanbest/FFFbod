namespace SAPR.Forms
{
    using System;
    using SAPR.Models;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;

    public partial class RepairWagons_Form : Form
    {
        private List<RepairGroup> repairGroups = new List<RepairGroup>();
        private EconomicParameters economicParameters = new EconomicParameters();
        private readonly string version = "1.4.4";
        private FileInfo saveFile;
        private readonly bool invalidFile = false;

        private XDocument Data
        {
            get
            {
                return GetSaveData();
            }
        }

        public RepairWagons_Form(FileInfo saveFile) : this()
        {
            if (saveFile != null)
            {
                this.saveFile = saveFile;
                try
                {
                    LoadData();
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show(
                       "Файл пошкоджено або він має непідтримуваний формат. Хочете продовжити з новим файлом?",
                       "Помилка читання!",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Error,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.No)
                    {
                        invalidFile = true;
                        Close();
                    }
                }
            }
        }

        private void RadioButtons_Handler(object sender, EventArgs e)
        {
            RadioButton currButton = (RadioButton)sender;
            if (currButton.Checked == true)
            {
                CreateEconomicParameter(currButton);
            }

        }

        private void CreateEconomicParameter(RadioButton currButton)
        {
            if (currButton == radioButton1)
            {
                fillEconomicParameterGrids(economicParameters.GetRepairWagonParameters());
            }
            else if (currButton == radioButton2)
            {
                fillEconomicParameterGrids(new List<EconomicParameters.Parameter> { economicParameters.oneTimeExpenses });
            }
            else if (currButton == radioButton3)
            {
                fillEconomicParameterGrids(economicParameters.GetBuildingMaintenanceParameters());
            }
            else if (currButton == radioButton4)
            {
                fillEconomicParameterGrids(economicParameters.GetRepairAndDeprecationParameters());
            }
            else if (currButton == radioButton5)
            {
                fillEconomicParameterGrids(new List<EconomicParameters.Parameter> { economicParameters.repairAnnualCost });
            }
            else
            {

            }
        }

        private void fillEconomicParameterGrids(List<EconomicParameters.Parameter> parameterList)
        {
            HashSet<EconomicParameters.Parameter> neededParameters = new HashSet<EconomicParameters.Parameter>();
            CalculateParametersDataGridView.Rows.Clear();
            BaseParametersDataGridView.Rows.Clear();
            foreach (EconomicParameters.Parameter param in parameterList)
            {
                param.AddAsGridViewRow(CalculateParametersDataGridView);
                foreach (EconomicParameters.Parameter subparam in param.ConnectedParameters)
                {
                    neededParameters.Add(subparam);
                }
            }
            foreach (EconomicParameters.Parameter param in neededParameters)
            {
                if (!parameterList.Contains(param))
                {
                    param.AddAsGridViewRow(BaseParametersDataGridView);
                }
            }
        }

        public RepairWagons_Form()
        {
            InitializeComponent();
            radioButton1.CheckedChanged += RadioButtons_Handler;
            radioButton2.CheckedChanged += RadioButtons_Handler;
            radioButton3.CheckedChanged += RadioButtons_Handler;
            radioButton4.CheckedChanged += RadioButtons_Handler;
            radioButton5.CheckedChanged += RadioButtons_Handler;
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomSettings.Cols());
            FillProcessesGrids();
            ConnectSettings();
        }

        private void FillProcessesGrids()
        {
            foreach (DataGridViewRow row in EquipmentGridData.GetMainProcessRows(MainWorkersGrid))
            {
                MainProcessesGrid.Rows.Add(row);
            }
            foreach (DataGridViewRow row in EquipmentGridData.GetSupportProcessRows(MainWorkersGrid))
            {
                SupportProcessesGrid.Rows.Add(row);
            }
        }

        private void ConnectSettings()
        {
            tabPage1.ForeColor = Properties.Settings.Default.TextColor;
            tabPage2.ForeColor = Properties.Settings.Default.TextColor;
            tabPage3.ForeColor = Properties.Settings.Default.TextColor;
            panel2.ForeColor = Properties.Settings.Default.TextColor;
            panel1.ForeColor = Properties.Settings.Default.TextColor;
            GroupQty.ForeColor = Properties.Settings.Default.TextColor;
            WagonRepairGrid.ForeColor = Properties.Settings.Default.TextColor;
            panel3.ForeColor = Properties.Settings.Default.TextColor;
            QtyWorkingDaysInYearTextBox.ForeColor = Properties.Settings.Default.TextColor;
            DurationWorkingShiftTextBox.ForeColor = Properties.Settings.Default.TextColor;
            tabPage5.ForeColor = Properties.Settings.Default.TextColor;
            ChoresWorkingPercentTextBox.ForeColor = Properties.Settings.Default.TextColor;
            panel4.ForeColor = Properties.Settings.Default.TextColor;
            MainWorkersCount.ForeColor = Properties.Settings.Default.TextColor;
            ChoresWorkersCnt.ForeColor = Properties.Settings.Default.TextColor;
            MainWorkersGrid.ForeColor = Properties.Settings.Default.TextColor;
            ChoresWorkersGrid.ForeColor = Properties.Settings.Default.TextColor;
            QtyWorkingShiftTextBox.ForeColor = Properties.Settings.Default.TextColor;
            CommonWorkersCount.ForeColor = Properties.Settings.Default.TextColor;
            AccountingWorkersCount.ForeColor = Properties.Settings.Default.TextColor;
            JuniorServiceWorkersCount.ForeColor = Properties.Settings.Default.TextColor;
            SupportWorkersCount.ForeColor = Properties.Settings.Default.TextColor;
            EngineerWorkersCount.ForeColor = Properties.Settings.Default.TextColor;

            tabControl1.BackColor = Properties.Settings.Default.BackgroundColor;
            tabPage1.BackColor = Properties.Settings.Default.BackgroundColor;
            tabPage2.BackColor = Properties.Settings.Default.BackgroundColor;
            tabPage3.BackColor = Properties.Settings.Default.BackgroundColor;
            panel2.BackColor = Properties.Settings.Default.BackgroundColor;
            panel1.BackColor = Properties.Settings.Default.BackgroundColor;
            GroupQty.BackColor = Properties.Settings.Default.BackgroundColor;
            WagonRepairGrid.BackColor = Properties.Settings.Default.BackgroundColor;
            panel3.BackColor = Properties.Settings.Default.BackgroundColor;
            Submit_Btn.BackColor = Properties.Settings.Default.BackgroundColor;
            button1.BackColor = Properties.Settings.Default.BackgroundColor;
            button2.BackColor = Properties.Settings.Default.BackgroundColor;
            QtyWorkingDaysInYearTextBox.BackColor = Properties.Settings.Default.BackgroundColor;
            DurationWorkingShiftTextBox.BackColor = Properties.Settings.Default.BackgroundColor;
            tabPage5.BackColor = Properties.Settings.Default.BackgroundColor;
            ChoresWorkingPercentTextBox.BackColor = Properties.Settings.Default.BackgroundColor;
            panel4.BackColor = Properties.Settings.Default.BackgroundColor;
            MainWorkersCount.BackColor = Properties.Settings.Default.BackgroundColor;
            ChoresWorkersCnt.BackColor = Properties.Settings.Default.BackgroundColor;
            MainWorkersGrid.BackColor = Properties.Settings.Default.BackgroundColor;
            ChoresWorkersGrid.BackColor = Properties.Settings.Default.BackgroundColor;
            QtyWorkingShiftTextBox.BackColor = Properties.Settings.Default.BackgroundColor;
            CommonWorkersCount.BackColor = Properties.Settings.Default.BackgroundColor;
            AccountingWorkersCount.BackColor = Properties.Settings.Default.BackgroundColor;
            JuniorServiceWorkersCount.BackColor = Properties.Settings.Default.BackgroundColor;
            SupportWorkersCount.BackColor = Properties.Settings.Default.BackgroundColor;
            EngineerWorkersCount.BackColor = Properties.Settings.Default.BackgroundColor;
            WagonRepairGrid.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
            ChoresWorkersGrid.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
            MainWorkersGrid.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
            SupportProcessesGrid.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
            MainProcessesGrid.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
            CalculateParametersDataGridView.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
            BaseParametersDataGridView.DefaultCellStyle.BackColor = Properties.Settings.Default.BackgroundColor;
        }

        private void LoadData()
        {
            List<RepairGroup> repairGroups = new List<RepairGroup>();
            XDocument xDocument = XDocument.Load(saveFile.FullName);
            XElement root = xDocument.Element("dataFile");
            var repairData = root.Elements("repairGroupsData");
            if (repairData != null)
            {
                foreach (var repairGroup in repairData.Elements("repairGroup"))
                {
                    RepairGroup group = new RepairGroup();
                    group.InitializeFromXml(repairGroup);
                    repairGroups.Add(group);
                }
            }
            this.repairGroups = repairGroups;
            var processes = root.Elements("mainProcess");
            if (processes != null)
            {
                MainProcessesGrid.Rows.Clear();
                foreach (var process in processes)
                {
                    List<string> cells = new List<string>();
                    foreach (var attribute in process.Attributes())
                    {
                        if (attribute != null)
                        {
                            cells.Add(attribute.Value);
                        }
                    }
                    MainProcessesGrid.Rows.Add(cells.ToArray());
                }
            }
            processes = root.Elements("supportProcess");
            if (processes != null)
            {
                SupportProcessesGrid.Rows.Clear();
                foreach (var process in processes)
                {
                    List<string> cells = new List<string>();
                    foreach (var attribute in process.Attributes())
                    {
                        if (attribute != null)
                        {
                            cells.Add(attribute.Value);
                        }
                    }
                    SupportProcessesGrid.Rows.Add(cells.ToArray());
                }
            }
            GroupQty.Value = repairGroups.Count;
            QtyWorkingDaysInYearTextBox.Text = root.Element("workingDaysQuantity").Value;
            QtyWorkingShiftTextBox.Text = root.Element("workingShiftQuantity").Value;
            DurationWorkingShiftTextBox.Text = root.Element("durationWorkingShift").Value;
            ChoresWorkingPercentTextBox.Text = root.Element("choresWorkingPercent").Value;

            XElement economicParametersData = root.Element("economicParametersData");
            if (economicParametersData != null) { 
                economicParameters = new EconomicParameters(economicParametersData.Elements("economicParameter"));
            }
        }

        private void GroupQty_ValueChanged_1(object sender, EventArgs e)
        {
            int newRowCount = (int)GroupQty.Value;

            if (newRowCount > repairGroups.Count) // якщо потрібно додати рядки
            {
                for (int i = repairGroups.Count; i < newRowCount; i++)
                {
                    RepairGroup repairGroup = new RepairGroup
                    {
                        GroupNumber = i + 1
                    };
                    repairGroups.Add(repairGroup);
                }
            }
            else if (newRowCount < repairGroups.Count) // якщо потрібно видалити рядки
            {
                // видаляємо зайві рядки з DataGridView
                for (int i = repairGroups.Count - 1; i >= newRowCount; i--)
                {
                    repairGroups.RemoveAt(i);
                }
            }

            WagonRepairGrid.Rows.Clear();
            foreach (RepairGroup group in repairGroups)
            {
                group.AddAsGridViewRow(WagonRepairGrid);
            }
        }


        private void WagonRepairGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // перевірка, що змінюється не заголовок колонки і не порожній рядок
            {
                repairGroups[e.RowIndex].InitializeFromGridViewRow(WagonRepairGrid.Rows[e.RowIndex]);
            }
        }


        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 1:
                    CalculateWorkersCount();
                    break;
            }
        }

        private void CalculateWorkersCount()
        {
            double sum = 0;
            foreach (RepairGroup group in repairGroups)
            {
                sum += group.CarQty * group.HardComplains;
            }
            if (QtyWorkingDaysInYearTextBox.Text != "" && QtyWorkingShiftTextBox.Text != "" && DurationWorkingShiftTextBox.Text != "")
                sum /= (double.Parse(QtyWorkingDaysInYearTextBox.Text) * double.Parse(QtyWorkingShiftTextBox.Text) * double.Parse(DurationWorkingShiftTextBox.Text));
            MainWorkersCount.Text = Math.Round(sum).ToString();
            ChoresWorkersCnt.Text = Math.Round(sum * Double.Parse(ChoresWorkingPercentTextBox.Text.ToString()) / 100).ToString();
            CommonWorkersCount.Text = (int.Parse(MainWorkersCount.Text) + int.Parse(ChoresWorkersCnt.Text)).ToString();
            SupportWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.16).ToString();
            EngineerWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.06).ToString();
            AccountingWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.02).ToString();
            JuniorServiceWorkersCount.Text = Math.Round(int.Parse(CommonWorkersCount.Text) * 0.02).ToString();

            InitializeWorkersGrids();
            UpdateGrid(MainWorkersGrid, int.Parse(MainWorkersCount.Text));
            UpdateGrid(ChoresWorkersGrid, int.Parse(ChoresWorkersCnt.Text));
        }

        private void InitializeWorkersGrids()
        {
            if (MainWorkersGrid.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in WorkersGridData.GetMainWorkersRows(MainWorkersGrid))
                {
                    MainWorkersGrid.Rows.Add(row);
                }
                foreach (DataGridViewRow row in WorkersGridData.GetChoresWorkersRows(MainWorkersGrid))
                {
                    ChoresWorkersGrid.Rows.Add(row);
                }
            }
        }

        private void UpdateGrid(DataGridView gridView, int employersCount)
        {
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
            if (saveFile != null)
                SaveDialog(saveFile);
            tabControl1.SelectTab(1);
        }

        private void RepairWagons_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool hasUnsavedData = saveFile == null;
            if (!hasUnsavedData)
            {
                XDocument lastSave = XDocument.Load(saveFile.FullName);
                hasUnsavedData = Data == lastSave;
                Console.WriteLine(Data);
                Console.WriteLine(lastSave);
            }
            if (!invalidFile && hasUnsavedData)
            {
                DialogResult result = MessageBox.Show(
                   "Після останнього редагування зміни не були збереженні. Хочете зберегти?",
                   "Є незбрежені дані!",
                   MessageBoxButtons.YesNoCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
                switch (result)
                {
                    case DialogResult.Yes:
                        e.Cancel = !SaveDialog(saveFile);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        private bool SaveDialog(FileInfo file = null)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Repair Wagon Calculation Files (*.rwcf)|*.rwcf",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (file == null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return false;
                }
                saveFile = new FileInfo(saveFileDialog.FileName);
            }
            else
            {
                saveFile = file;
            }

            Data.Save(saveFile.FullName);
            return true;
        }

        private XDocument GetSaveData()
        {
            XDocument document = new XDocument();
            XElement root = new XElement("dataFile");
            XAttribute programVersion = new XAttribute("programVersion", version);
            root.Add(programVersion);

            XElement repairGroupsData = new XElement("repairGroupsData");
            foreach (RepairGroup repairGroup in repairGroups)
            {
                repairGroup.AddAsXMLObject(repairGroupsData);
            }
            root.Add(repairGroupsData);

            foreach (KeyValuePair<string, string> data in GetDataToSave())
            {
                XElement element = new XElement(data.Key);
                element.Add(data.Value);
                root.Add(element);
            }
            foreach (DataGridViewRow row in MainProcessesGrid.Rows)
            {
                XElement process = new XElement("mainProcess");
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    var cellValue = row.Cells[i].Value;
                    XAttribute cell = new XAttribute("Cell" + i, cellValue ?? "");
                    process.Add(cell);
                }
                root.Add(process);
            }
            foreach (DataGridViewRow row in SupportProcessesGrid.Rows)
            {
                XElement process = new XElement("supportProcess");
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    var cellValue = row.Cells[i].Value;
                    XAttribute cell = new XAttribute("Cell" + i, cellValue ?? "");
                    process.Add(cell);
                }
                root.Add(process);
            }

            XElement economicParametersData = new XElement("economicParametersData");
            foreach (EconomicParameters.Parameter parameter in economicParameters.GetParameters())
            {
                parameter.AddAsXMLObject(economicParametersData);
            }
            root.Add(economicParametersData);

            document.Add(root);
            return document;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog(saveFile);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog();
        }

        private Dictionary<string, string> GetDataToSave()
        {
            return new Dictionary<string, string>() {
                {"workingShiftQuantity", QtyWorkingShiftTextBox.Text},
                {"durationWorkingShift", DurationWorkingShiftTextBox.Text},
                {"workingDaysQuantity", QtyWorkingDaysInYearTextBox.Text},
                {"choresWorkingPercent", ChoresWorkingPercentTextBox.Text},
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double automatizationLevel = 0;
            double automatizationAndMechLevel = 0;
            double commonAutomatization = 0;
            double commonAutomatizationAndMech = 0;
            double commonDivider = 0;
            double divider = 0;
            double degreeOfAutomatization = 0;
            foreach (DataGridViewRow row in MainProcessesGrid.Rows)
            {
                var Kz = row.Cells[4].Value;
                var mv = row.Cells[3].Value;
                var z = row.Cells[1].Value;
                var nz = row.Cells[2].Value;
                if (mv != null && Kz != null)
                {
                    double mz = double.Parse(mv.ToString()) * double.Parse(Kz.ToString());
                    row.Cells[5].Value = mz;
                    if (z != null)
                    {
                        double zValue = double.Parse(z.ToString());
                        if (zValue >= 1)
                        {
                            automatizationAndMechLevel += zValue * mz;
                            if (zValue >= 3.5)
                            {
                                automatizationLevel += zValue * mz;
                                if (nz != null)
                                {
                                    degreeOfAutomatization += mz * double.Parse(nz.ToString());
                                }
                            }
                        }
                        divider += mz;
                    }
                }
            }
            commonAutomatization += automatizationLevel;
            commonAutomatizationAndMech += automatizationAndMechLevel;
            commonDivider += divider;
            MainAutomatiztionLevel.Text = Math.Round(automatizationLevel / (5 * divider) * 100).ToString();
            MainAutomatiztionAndMechaniztionLevel.Text = Math.Round(automatizationAndMechLevel / (5 * divider) * 100).ToString();
            automatizationLevel = 0;
            automatizationAndMechLevel = 0;
            divider = 0;
            foreach (DataGridViewRow row in SupportProcessesGrid.Rows)
            {
                var Kz = row.Cells[4].Value;
                var mv = row.Cells[3].Value;
                var z = row.Cells[1].Value;
                var nz = row.Cells[2].Value;
                if (mv != null && Kz != null)
                {
                    double mz = double.Parse(mv.ToString()) * double.Parse(Kz.ToString());
                    row.Cells[5].Value = mz;
                    if (z != null)
                    {
                        double zValue = double.Parse(z.ToString());
                        if (zValue >= 1)
                        {
                            automatizationAndMechLevel += zValue * mz;
                            if (zValue >= 3.5)
                            {
                                automatizationLevel += zValue * mz;
                                if (nz != null)
                                {
                                    degreeOfAutomatization += mz * double.Parse(nz.ToString());
                                }
                            }
                        }
                        divider += mz;
                    }
                }
            }
            SupportAutomatiztionLevel.Text = Math.Round(automatizationLevel / (5 * divider) * 100).ToString();
            SupportAutomatiztionAndMechanizationLevel.Text = Math.Round(automatizationAndMechLevel / (5 * divider) * 100).ToString();
            commonAutomatization += automatizationLevel;
            commonDivider += divider;
            CommonAutomatiztionLevel.Text = Math.Round(commonAutomatization / (5 * commonDivider) * 100).ToString();
            CommonAutomatiztionAndMaechanizationLevel.Text = Math.Round(commonAutomatizationAndMech / (5 * commonDivider) * 100).ToString();
            degreeAutomatiztionLevel.Text = (Math.Round(degreeOfAutomatization / (5 * commonDivider) * 100) / 100).ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void parametersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in ((DataGridView)sender).Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == "")
                {
                    row.Cells[1].Value = "Н/Д. Проведіть розрахунки";
                }
            }
        }

        private void BaseParametersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in ((DataGridView)sender).Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == "")
                {
                    if (isCalculateParameterName(row.Cells[0].Value.ToString()))
                    {
                        row.Cells[1].Value = "Н/Д. Проведіть розрахунки";
                    }
                }
            }
        }

        private bool isCalculateParameterName(string name)
        {
            foreach (var parameter in economicParameters.GetCalculateParameters())
            {
                if (parameter.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void BaseParametersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = (sender as DataGridView).Rows[e.RowIndex];
            if (isCalculateParameterName(row.Cells[0].Value.ToString()))
            {
                e.Cancel = true;
            }
        }

        private void CalculateEconomicParameter(object sender, EventArgs e)
        {
            List<EconomicParameters.Parameter> tempParam = new List<EconomicParameters.Parameter>(economicParameters.GetParameters());
            foreach (DataGridViewRow row in BaseParametersDataGridView.Rows)
            {
                foreach (EconomicParameters.Parameter parameter in tempParam)
                {
                    if (parameter.Name == row.Cells[0].Value.ToString())
                    {
                        if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == "")
                        {
                            parameter.Value = null;
                        }
                        else
                        {
                            try
                            {
                                parameter.Value = double.Parse(row.Cells[1].Value.ToString());
                            }
                            catch (Exception)
                            {

                            }
                        }
                        tempParam.Remove(parameter);
                        break;
                    }
                }
            }
            
            tempParam = new List<EconomicParameters.Parameter>(economicParameters.GetCalculateParameters());

            foreach (DataGridViewRow row in CalculateParametersDataGridView.Rows)
            {
                foreach (EconomicParameters.Parameter parameter in tempParam)
                {
                    if (parameter.Name == row.Cells[0].Value.ToString())
                    {
                        if (parameter.Value == null)
                        {
                            row.Cells[1].Value = "Н/Д. Проведіть розрахунки";
                        }
                        else 
                        {
                            row.Cells[1].Value = parameter.Value;
                        }
                        tempParam.Remove(parameter);
                        break;
                    }
                }
            }
        }
    }
}
