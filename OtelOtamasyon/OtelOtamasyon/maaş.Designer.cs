namespace OtelOtamasyon
{
    partial class maaş
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
            this.ekran = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.departmanara = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcara = new System.Windows.Forms.TextBox();
            this.adara = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cinsiyetara = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.ekran)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ekran
            // 
            this.ekran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ekran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ekran.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ekran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ekran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ekran.Location = new System.Drawing.Point(8, 82);
            this.ekran.Name = "ekran";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ekran.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ekran.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.ekran.RowTemplate.Height = 24;
            this.ekran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ekran.Size = new System.Drawing.Size(1837, 823);
            this.ekran.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(87, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Departmana Göre";
            // 
            // departmanara
            // 
            this.departmanara.FormattingEnabled = true;
            this.departmanara.Items.AddRange(new object[] {
            "Tümü",
            "Temizlik",
            "Tekniker",
            "Resepsiyon",
            "Bahçıvan",
            "Aşçı",
            "Yönetici"});
            this.departmanara.Location = new System.Drawing.Point(253, 40);
            this.departmanara.Name = "departmanara";
            this.departmanara.Size = new System.Drawing.Size(137, 24);
            this.departmanara.TabIndex = 3;
            this.departmanara.SelectedIndexChanged += new System.EventHandler(this.departmanara_SelectedIndexChanged);
            this.departmanara.TextChanged += new System.EventHandler(this.departmanara_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(541, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "TC\'ye Göre";
            // 
            // tcara
            // 
            this.tcara.Location = new System.Drawing.Point(663, 43);
            this.tcara.Name = "tcara";
            this.tcara.Size = new System.Drawing.Size(137, 22);
            this.tcara.TabIndex = 5;
            this.tcara.TextChanged += new System.EventHandler(this.tcara_TextChanged);
            // 
            // adara
            // 
            this.adara.Location = new System.Drawing.Point(1026, 41);
            this.adara.Name = "adara";
            this.adara.Size = new System.Drawing.Size(137, 22);
            this.adara.TabIndex = 7;
            this.adara.TextChanged += new System.EventHandler(this.adara_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(914, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "İsme Göre";
            // 
            // cinsiyetara
            // 
            this.cinsiyetara.FormattingEnabled = true;
            this.cinsiyetara.Items.AddRange(new object[] {
            "Tümü",
            "Kadın",
            "Erkek"});
            this.cinsiyetara.Location = new System.Drawing.Point(1384, 43);
            this.cinsiyetara.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cinsiyetara.Name = "cinsiyetara";
            this.cinsiyetara.Size = new System.Drawing.Size(137, 24);
            this.cinsiyetara.TabIndex = 74;
            this.cinsiyetara.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(1282, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 18);
            this.label12.TabIndex = 73;
            this.label12.Text = " Cinsiyet";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.menuStrip1.Size = new System.Drawing.Size(1838, 31);
            this.menuStrip1.TabIndex = 75;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaEkranToolStripMenuItem
            // 
            this.anaEkranToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anaEkranToolStripMenuItem.Name = "anaEkranToolStripMenuItem";
            this.anaEkranToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.anaEkranToolStripMenuItem.Text = "Ana Ekran";
            this.anaEkranToolStripMenuItem.Click += new System.EventHandler(this.anaEkranToolStripMenuItem_Click);
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
            // maaş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1838, 893);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cinsiyetara);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.adara);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tcara);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.departmanara);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ekran);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "maaş";
            this.ShowIcon = false;
            this.Text = "Maaş Tablosu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.maaş_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ekran)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ekran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox departmanara;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tcara;
        private System.Windows.Forms.TextBox adara;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cinsiyetara;
        private System.Windows.Forms.Label label12;
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