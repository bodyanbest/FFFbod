namespace SAPR
{
    using System;
    using SAPR.Forms;
    using System.Windows.Forms;
    using System.Drawing;
    using SAPR.Models;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            Console.WriteLine(Convert.ToDouble(null));
            InitializeComponent();
            ConnectSettings();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomSettings.Cols());
        }

        private void NewCalculation_Btn_Click(object sender, EventArgs e)
        {
            new RepairWagons_Form().ShowDialog();
        }

        private void GoOnCalculation_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Repair Wagon Calculation Files (*.rwcf)|*.rwcf|XML (*.xml)|*.xml|Text (*.txt)|*.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (ofd.ShowDialog() != DialogResult.Cancel) {
                RepairWagons_Form repairWagons = new RepairWagons_Form(new System.IO.FileInfo(ofd.FileName));
                if(!repairWagons.IsDisposed)
                {
                    repairWagons.ShowDialog();
                }
            }
        }

        private void Exit_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextColor = SystemColors.ControlText;
            Properties.Settings.Default.BackgroundColor = SystemColors.Control;
            Properties.Settings.Default.Save();
        }

        private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BackgroundColor = Color.FromArgb(54, 70, 77);
            Properties.Settings.Default.TextColor = Color.White;
            Properties.Settings.Default.Save();
        }

        private void ConnectSettings() {
            DataBindings.Add(CustomSettings.BackColorBinding);
            DataBindings.Add( CustomSettings.TextColorBinding);
            Exit_Btn.DataBindings.Add(CustomSettings.BackColorBinding);
            Exit_Btn.DataBindings.Add( CustomSettings.TextColorBinding);
            NewCalc_Btn.DataBindings.Add(CustomSettings.BackColorBinding);
            NewCalc_Btn.DataBindings.Add( CustomSettings.TextColorBinding);
            GoOnCalc_Btn.DataBindings.Add(CustomSettings.BackColorBinding);
            GoOnCalc_Btn.DataBindings.Add( CustomSettings.TextColorBinding);
            menuStrip1.DataBindings.Add(CustomSettings.BackColorBinding);
            label1.DataBindings.Add( CustomSettings.TextColorBinding);
            label1.ForeColorChanged += Label1_ForeColorChanged;
        }

        private void Label1_ForeColorChanged(object sender, EventArgs e)
        {
            UpdateChildrenForeGround(menuStrip1.Items, Properties.Settings.Default.TextColor);
        }

        private void MenuStrip1_BackColorChanged(object sender, EventArgs e)
        { 
            UpdateChildrenBackGround(menuStrip1.Items, menuStrip1.BackColor);   
            menuStrip1.ForeColor = Properties.Settings.Default.TextColor;
        }

        private void UpdateChildrenBackGround(ToolStripItemCollection collection, Color color)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i].BackColor = color;
                if (collection[i].GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem temp = (ToolStripMenuItem)collection[i];
                    UpdateChildrenBackGround(temp.DropDownItems, color);
                }
            }
        }

        private void UpdateChildrenForeGround(ToolStripItemCollection collection, Color color)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i].ForeColor = color;
                if (collection[i].GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem temp = (ToolStripMenuItem)collection[i];
                    UpdateChildrenForeGround(temp.DropDownItems, color);
                }
            }
            
        }
    }
}
