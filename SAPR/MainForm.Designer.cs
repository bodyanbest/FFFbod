namespace SAPR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GoOnCalc_Btn = new System.Windows.Forms.Button();
            this.NewCalc_Btn = new System.Windows.Forms.Button();
            this.Exit_Btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.світлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "САПР проєктів вагоноремонтних підприємств";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SAPR.Properties.Resources._logo3;
            this.pictureBox1.Location = new System.Drawing.Point(307, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // GoOnCalc_Btn
            // 
            this.GoOnCalc_Btn.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoOnCalc_Btn.Location = new System.Drawing.Point(72, 431);
            this.GoOnCalc_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.GoOnCalc_Btn.Name = "GoOnCalc_Btn";
            this.GoOnCalc_Btn.Size = new System.Drawing.Size(176, 75);
            this.GoOnCalc_Btn.TabIndex = 2;
            this.GoOnCalc_Btn.Text = "Продовжити розрахунки";
            this.GoOnCalc_Btn.UseVisualStyleBackColor = true;
            this.GoOnCalc_Btn.Click += new System.EventHandler(this.GoOnCalculation_Btn_Click);
            // 
            // NewCalc_Btn
            // 
            this.NewCalc_Btn.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCalc_Btn.Location = new System.Drawing.Point(384, 431);
            this.NewCalc_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.NewCalc_Btn.Name = "NewCalc_Btn";
            this.NewCalc_Btn.Size = new System.Drawing.Size(176, 75);
            this.NewCalc_Btn.TabIndex = 3;
            this.NewCalc_Btn.Text = "Почати нові розрахунки";
            this.NewCalc_Btn.UseVisualStyleBackColor = true;
            this.NewCalc_Btn.Click += new System.EventHandler(this.NewCalculation_Btn_Click);
            // 
            // Exit_Btn
            // 
            this.Exit_Btn.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Btn.Location = new System.Drawing.Point(687, 431);
            this.Exit_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Exit_Btn.Name = "Exit_Btn";
            this.Exit_Btn.Size = new System.Drawing.Size(176, 75);
            this.Exit_Btn.TabIndex = 4;
            this.Exit_Btn.Text = "Вихід";
            this.Exit_Btn.UseVisualStyleBackColor = true;
            this.Exit_Btn.Click += new System.EventHandler(this.Exit_Btn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1018, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.BackColorChanged += new System.EventHandler(this.MenuStrip1_BackColorChanged);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThemeToolStripMenuItem});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.settingsToolStripMenuItem.Text = "Налаштування";
            // 
            // ThemeToolStripMenuItem
            // 
            this.ThemeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ThemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.темнаToolStripMenuItem,
            this.світлаToolStripMenuItem});
            this.ThemeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ThemeToolStripMenuItem.Name = "ThemeToolStripMenuItem";
            this.ThemeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ThemeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ThemeToolStripMenuItem.Text = "Тема";
            this.ThemeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // темнаToolStripMenuItem
            // 
            this.темнаToolStripMenuItem.Name = "темнаToolStripMenuItem";
            this.темнаToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.темнаToolStripMenuItem.Text = "Темна";
            this.темнаToolStripMenuItem.Click += new System.EventHandler(this.DarkThemeToolStripMenuItem_Click);
            // 
            // світлаToolStripMenuItem
            // 
            this.світлаToolStripMenuItem.Name = "світлаToolStripMenuItem";
            this.світлаToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.світлаToolStripMenuItem.Text = "Світла";
            this.світлаToolStripMenuItem.Click += new System.EventHandler(this.LightThemeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 602);
            this.Controls.Add(this.Exit_Btn);
            this.Controls.Add(this.NewCalc_Btn);
            this.Controls.Add(this.GoOnCalc_Btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    "                       САПР";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button GoOnCalc_Btn;
        private System.Windows.Forms.Button NewCalc_Btn;
        private System.Windows.Forms.Button Exit_Btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem світлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThemeToolStripMenuItem;
    }
}

