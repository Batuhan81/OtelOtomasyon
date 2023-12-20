namespace OtelOtamasyon
{
    partial class Odalar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Odalar));
            this.comboKat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OdaEkle = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnKatEkle = new System.Windows.Forms.Button();
            this.btnKatSil = new System.Windows.Forms.Button();
            this.PanelOdalar = new System.Windows.Forms.FlowLayoutPanel();
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboKat
            // 
            this.comboKat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboKat.FormattingEnabled = true;
            this.comboKat.Location = new System.Drawing.Point(1663, 305);
            this.comboKat.Name = "comboKat";
            this.comboKat.Size = new System.Drawing.Size(233, 24);
            this.comboKat.TabIndex = 13;
            this.comboKat.SelectedIndexChanged += new System.EventHandler(this.comboKat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1553, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Otel Katı";
            // 
            // OdaEkle
            // 
            this.OdaEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OdaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OdaEkle.ImageIndex = 0;
            this.OdaEkle.ImageList = this.ımageList1;
            this.OdaEkle.Location = new System.Drawing.Point(1599, 96);
            this.OdaEkle.Name = "OdaEkle";
            this.OdaEkle.Size = new System.Drawing.Size(197, 82);
            this.OdaEkle.TabIndex = 19;
            this.OdaEkle.Text = " Oda Ekle";
            this.OdaEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OdaEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OdaEkle.UseVisualStyleBackColor = true;
            this.OdaEkle.Click += new System.EventHandler(this.OdaEkle_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Ekle2.png");
            this.ımageList1.Images.SetKeyName(1, "Sil butonu.png");
            // 
            // btnKatEkle
            // 
            this.btnKatEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKatEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnKatEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKatEkle.ImageIndex = 0;
            this.btnKatEkle.ImageList = this.ımageList1;
            this.btnKatEkle.Location = new System.Drawing.Point(1496, 184);
            this.btnKatEkle.Name = "btnKatEkle";
            this.btnKatEkle.Size = new System.Drawing.Size(197, 82);
            this.btnKatEkle.TabIndex = 22;
            this.btnKatEkle.Text = " Kat Ekle";
            this.btnKatEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKatEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKatEkle.UseVisualStyleBackColor = false;
            this.btnKatEkle.Click += new System.EventHandler(this.btnKatEkle_Click);
            // 
            // btnKatSil
            // 
            this.btnKatSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKatSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKatSil.ImageIndex = 1;
            this.btnKatSil.ImageList = this.ımageList1;
            this.btnKatSil.Location = new System.Drawing.Point(1709, 184);
            this.btnKatSil.Name = "btnKatSil";
            this.btnKatSil.Size = new System.Drawing.Size(197, 82);
            this.btnKatSil.TabIndex = 23;
            this.btnKatSil.Text = " Kat Sil";
            this.btnKatSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKatSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKatSil.UseVisualStyleBackColor = true;
            this.btnKatSil.Click += new System.EventHandler(this.btnKatSil_Click);
            // 
            // PanelOdalar
            // 
            this.PanelOdalar.AutoScroll = true;
            this.PanelOdalar.BackColor = System.Drawing.Color.Transparent;
            this.PanelOdalar.Location = new System.Drawing.Point(32, 73);
            this.PanelOdalar.Name = "PanelOdalar";
            this.PanelOdalar.Size = new System.Drawing.Size(1458, 814);
            this.PanelOdalar.TabIndex = 25;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
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
            this.menuStrip1.Size = new System.Drawing.Size(1895, 31);
            this.menuStrip1.TabIndex = 76;
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
            // Odalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OtelOtamasyon.Properties.Resources.konaklama_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1895, 1035);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.PanelOdalar);
            this.Controls.Add(this.btnKatSil);
            this.Controls.Add(this.btnKatEkle);
            this.Controls.Add(this.OdaEkle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboKat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Odalar";
            this.ShowIcon = false;
            this.Text = "Odalar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Odalar_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboKat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OdaEkle;
        private System.Windows.Forms.Button btnKatEkle;
        private System.Windows.Forms.Button btnKatSil;
        private System.Windows.Forms.FlowLayoutPanel PanelOdalar;
        private System.Windows.Forms.ImageList ımageList1;
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