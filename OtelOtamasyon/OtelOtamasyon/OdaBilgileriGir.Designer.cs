namespace OtelOtamasyon
{
    partial class OdaBilgileriGir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdaBilgileriGir));
            this.txtyataks = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ucret = new System.Windows.Forms.TextBox();
            this.txtodaozelligi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.iptal = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.txtodano = new System.Windows.Forms.TextBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // txtyataks
            // 
            this.txtyataks.AutoSize = true;
            this.txtyataks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtyataks.Location = new System.Drawing.Point(36, 48);
            this.txtyataks.Name = "txtyataks";
            this.txtyataks.Size = new System.Drawing.Size(100, 18);
            this.txtyataks.TabIndex = 0;
            this.txtyataks.Text = "Yatak Sayısı";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(73, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ücreti ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(35, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = " Oda Özelliği";
            // 
            // ucret
            // 
            this.ucret.Location = new System.Drawing.Point(146, 88);
            this.ucret.Name = "ucret";
            this.ucret.Size = new System.Drawing.Size(131, 22);
            this.ucret.TabIndex = 9;
            // 
            // txtodaozelligi
            // 
            this.txtodaozelligi.FormattingEnabled = true;
            this.txtodaozelligi.Items.AddRange(new object[] {
            "Standart",
            "Geniş",
            "Kral Dairesi",
            "Manzaralı",
            "Havuz Manzaralı"});
            this.txtodaozelligi.Location = new System.Drawing.Point(146, 127);
            this.txtodaozelligi.Name = "txtodaozelligi";
            this.txtodaozelligi.Size = new System.Drawing.Size(131, 24);
            this.txtodaozelligi.TabIndex = 11;
            this.txtodaozelligi.SelectedIndexChanged += new System.EventHandler(this.odaozelligi_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = " Oda Numarası";
            // 
            // iptal
            // 
            this.iptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.iptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptal.ImageIndex = 0;
            this.iptal.ImageList = this.ımageList1;
            this.iptal.Location = new System.Drawing.Point(88, 232);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(153, 48);
            this.iptal.TabIndex = 30;
            this.iptal.Text = "İptal";
            this.iptal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iptal.UseVisualStyleBackColor = true;
            this.iptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // btnekle
            // 
            this.btnekle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnekle.ImageIndex = 2;
            this.btnekle.ImageList = this.ımageList1;
            this.btnekle.Location = new System.Drawing.Point(88, 178);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(153, 48);
            this.btnekle.TabIndex = 27;
            this.btnekle.Text = "Ekle";
            this.btnekle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // txtodano
            // 
            this.txtodano.Location = new System.Drawing.Point(146, 12);
            this.txtodano.Name = "txtodano";
            this.txtodano.Size = new System.Drawing.Size(131, 22);
            this.txtodano.TabIndex = 31;
            this.txtodano.TextChanged += new System.EventHandler(this.txtodano_TextChanged);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "iptal.png");
            this.ımageList1.Images.SetKeyName(1, "Yenile İkonu2.png");
            this.ımageList1.Images.SetKeyName(2, "Ekle2.png");
            // 
            // OdaBilgileriGir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.iptal;
            this.ClientSize = new System.Drawing.Size(288, 284);
            this.Controls.Add(this.txtodano);
            this.Controls.Add(this.iptal);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtodaozelligi);
            this.Controls.Add(this.ucret);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtyataks);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OdaBilgileriGir";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Oda Ekle";
            this.Load += new System.EventHandler(this.OdaBilgileriGir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtyataks;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ucret;
        private System.Windows.Forms.ComboBox txtodaozelligi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button iptal;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.TextBox txtodano;
        private System.Windows.Forms.ImageList ımageList1;
    }
}