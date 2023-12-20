namespace OtelOtamasyon
{
    partial class Faturalar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Ekran = new System.Windows.Forms.DataGridView();
            this.tarihara = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.odaara = new System.Windows.Forms.TextBox();
            this.adara = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tcara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaEkranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaTeslimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaTelimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervasyonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşterilerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.konaklayanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refekatçılarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çalışanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Ekran)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ekran
            // 
            this.Ekran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ekran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Ekran.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.Ekran.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Ekran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Ekran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ekran.Location = new System.Drawing.Point(12, 92);
            this.Ekran.Name = "Ekran";
            this.Ekran.ReadOnly = true;
            this.Ekran.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ekran.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Ekran.RowTemplate.Height = 24;
            this.Ekran.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Ekran.Size = new System.Drawing.Size(1752, 716);
            this.Ekran.TabIndex = 0;
            // 
            // tarihara
            // 
            this.tarihara.Location = new System.Drawing.Point(382, 55);
            this.tarihara.Name = "tarihara";
            this.tarihara.Size = new System.Drawing.Size(230, 22);
            this.tarihara.TabIndex = 1;
            this.tarihara.ValueChanged += new System.EventHandler(this.tarihara_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(161, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "İşlem Tarihine Göre ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(689, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odaya Göre ";
            // 
            // odaara
            // 
            this.odaara.Location = new System.Drawing.Point(799, 55);
            this.odaara.Name = "odaara";
            this.odaara.Size = new System.Drawing.Size(144, 22);
            this.odaara.TabIndex = 4;
            this.odaara.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // adara
            // 
            this.adara.Location = new System.Drawing.Point(1077, 54);
            this.adara.Name = "adara";
            this.adara.Size = new System.Drawing.Size(144, 22);
            this.adara.TabIndex = 6;
            this.adara.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(967, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ad\'a Göre";
            // 
            // tcara
            // 
            this.tcara.Location = new System.Drawing.Point(1352, 56);
            this.tcara.Name = "tcara";
            this.tcara.Size = new System.Drawing.Size(144, 22);
            this.tcara.TabIndex = 8;
            this.tcara.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1242, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "TC\'ye Göre";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaEkranToolStripMenuItem,
            this.odaTeslimToolStripMenuItem,
            this.müşterilerToolStripMenuItem,
            this.çalışanToolStripMenuItem,
            this.grafikToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1776, 31);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaEkranToolStripMenuItem
            // 
            this.anaEkranToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anaEkranToolStripMenuItem.Name = "anaEkranToolStripMenuItem";
            this.anaEkranToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.anaEkranToolStripMenuItem.Text = "Ana Ekran";
            this.anaEkranToolStripMenuItem.Click += new System.EventHandler(this.anaEkranToolStripMenuItem_Click_1);
            // 
            // odaTeslimToolStripMenuItem
            // 
            this.odaTeslimToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odalarToolStripMenuItem,
            this.odaTelimToolStripMenuItem,
            this.rezervasyonToolStripMenuItem});
            this.odaTeslimToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.odaTeslimToolStripMenuItem.Name = "odaTeslimToolStripMenuItem";
            this.odaTeslimToolStripMenuItem.Size = new System.Drawing.Size(112, 27);
            this.odaTeslimToolStripMenuItem.Text = "Oda Teslim";
            // 
            // odalarToolStripMenuItem
            // 
            this.odalarToolStripMenuItem.Name = "odalarToolStripMenuItem";
            this.odalarToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.odalarToolStripMenuItem.Text = "Odalar";
            this.odalarToolStripMenuItem.Click += new System.EventHandler(this.odalarToolStripMenuItem_Click);
            // 
            // odaTelimToolStripMenuItem
            // 
            this.odaTelimToolStripMenuItem.Name = "odaTelimToolStripMenuItem";
            this.odaTelimToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.odaTelimToolStripMenuItem.Text = "Oda Telim";
            this.odaTelimToolStripMenuItem.Click += new System.EventHandler(this.odaTelimToolStripMenuItem_Click);
            // 
            // rezervasyonToolStripMenuItem
            // 
            this.rezervasyonToolStripMenuItem.Name = "rezervasyonToolStripMenuItem";
            this.rezervasyonToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.rezervasyonToolStripMenuItem.Text = "Rezervasyon";
            this.rezervasyonToolStripMenuItem.Click += new System.EventHandler(this.rezervasyonToolStripMenuItem_Click);
            // 
            // müşterilerToolStripMenuItem
            // 
            this.müşterilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşterilerToolStripMenuItem1,
            this.konaklayanlarToolStripMenuItem,
            this.refekatçılarToolStripMenuItem});
            this.müşterilerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(106, 27);
            this.müşterilerToolStripMenuItem.Text = "Müşteriler";
            // 
            // müşterilerToolStripMenuItem1
            // 
            this.müşterilerToolStripMenuItem1.Name = "müşterilerToolStripMenuItem1";
            this.müşterilerToolStripMenuItem1.Size = new System.Drawing.Size(207, 28);
            this.müşterilerToolStripMenuItem1.Text = "Müşteriler";
            this.müşterilerToolStripMenuItem1.Click += new System.EventHandler(this.müşterilerToolStripMenuItem1_Click);
            // 
            // konaklayanlarToolStripMenuItem
            // 
            this.konaklayanlarToolStripMenuItem.Name = "konaklayanlarToolStripMenuItem";
            this.konaklayanlarToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.konaklayanlarToolStripMenuItem.Text = "Konaklayanlar";
            this.konaklayanlarToolStripMenuItem.Click += new System.EventHandler(this.konaklayanlarToolStripMenuItem_Click);
            // 
            // refekatçılarToolStripMenuItem
            // 
            this.refekatçılarToolStripMenuItem.Name = "refekatçılarToolStripMenuItem";
            this.refekatçılarToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.refekatçılarToolStripMenuItem.Text = "Refekatçılar";
            this.refekatçılarToolStripMenuItem.Click += new System.EventHandler(this.refekatçılarToolStripMenuItem_Click);
            // 
            // çalışanToolStripMenuItem
            // 
            this.çalışanToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.çalışanToolStripMenuItem.Name = "çalışanToolStripMenuItem";
            this.çalışanToolStripMenuItem.Size = new System.Drawing.Size(80, 27);
            this.çalışanToolStripMenuItem.Text = "Çalışan";
            this.çalışanToolStripMenuItem.Click += new System.EventHandler(this.çalışanToolStripMenuItem_Click);
            // 
            // grafikToolStripMenuItem
            // 
            this.grafikToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.grafikToolStripMenuItem.Name = "grafikToolStripMenuItem";
            this.grafikToolStripMenuItem.Size = new System.Drawing.Size(74, 27);
            this.grafikToolStripMenuItem.Text = "Grafik";
            this.grafikToolStripMenuItem.Click += new System.EventHandler(this.grafikToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // Faturalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1776, 836);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tcara);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.adara);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.odaara);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tarihara);
            this.Controls.Add(this.Ekran);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Faturalar";
            this.ShowIcon = false;
            this.Text = "Faturalar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Faturalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ekran)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Ekran;
        private System.Windows.Forms.DateTimePicker tarihara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox odaara;
        private System.Windows.Forms.TextBox adara;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tcara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anaEkranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaTeslimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaTelimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervasyonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşterilerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem konaklayanlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refekatçılarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çalışanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}