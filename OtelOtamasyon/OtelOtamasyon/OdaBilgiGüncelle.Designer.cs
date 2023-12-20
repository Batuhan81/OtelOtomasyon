namespace OtelOtamasyon
{
    partial class OdaBilgiGüncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdaBilgiGüncelle));
            this.button1 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btngüncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboodaozelligi = new System.Windows.Forms.ComboBox();
            this.ihtiyacdurumu = new System.Windows.Forms.ComboBox();
            this.txtucret = new System.Windows.Forms.TextBox();
            this.combodurumu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtodakatı = new System.Windows.Forms.ComboBox();
            this.txtyataksayisi = new System.Windows.Forms.TextBox();
            this.txtyataks = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtodano = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(316, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 56);
            this.button1.TabIndex = 49;
            this.button1.Text = "   İptal";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "iptal.png");
            this.ımageList1.Images.SetKeyName(1, "Yenile İkonu2.png");
            // 
            // btngüncelle
            // 
            this.btngüncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngüncelle.ImageIndex = 1;
            this.btngüncelle.ImageList = this.ımageList1;
            this.btngüncelle.Location = new System.Drawing.Point(316, 137);
            this.btngüncelle.Name = "btngüncelle";
            this.btngüncelle.Size = new System.Drawing.Size(147, 56);
            this.btngüncelle.TabIndex = 48;
            this.btngüncelle.Text = " Güncelle";
            this.btngüncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btngüncelle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btngüncelle.UseVisualStyleBackColor = true;
            this.btngüncelle.Click += new System.EventHandler(this.btngüncelle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(18, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = " Oda Numarası";
            // 
            // comboodaozelligi
            // 
            this.comboodaozelligi.FormattingEnabled = true;
            this.comboodaozelligi.Location = new System.Drawing.Point(152, 323);
            this.comboodaozelligi.Name = "comboodaozelligi";
            this.comboodaozelligi.Size = new System.Drawing.Size(131, 26);
            this.comboodaozelligi.TabIndex = 43;
            // 
            // ihtiyacdurumu
            // 
            this.ihtiyacdurumu.FormattingEnabled = true;
            this.ihtiyacdurumu.Location = new System.Drawing.Point(152, 274);
            this.ihtiyacdurumu.Name = "ihtiyacdurumu";
            this.ihtiyacdurumu.Size = new System.Drawing.Size(131, 26);
            this.ihtiyacdurumu.TabIndex = 42;
            // 
            // txtucret
            // 
            this.txtucret.Location = new System.Drawing.Point(152, 227);
            this.txtucret.Name = "txtucret";
            this.txtucret.Size = new System.Drawing.Size(131, 24);
            this.txtucret.TabIndex = 41;
            // 
            // combodurumu
            // 
            this.combodurumu.FormattingEnabled = true;
            this.combodurumu.Items.AddRange(new object[] {
            "Boş",
            "Servis Dışı"});
            this.combodurumu.Location = new System.Drawing.Point(152, 178);
            this.combodurumu.Name = "combodurumu";
            this.combodurumu.Size = new System.Drawing.Size(131, 26);
            this.combodurumu.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(41, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 39;
            this.label5.Text = " Oda Özelliği";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(30, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "İhtiyaç Durumu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(79, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "Ücreti ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(68, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = " Durumu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(66, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Oda Katı";
            // 
            // txtodakatı
            // 
            this.txtodakatı.FormattingEnabled = true;
            this.txtodakatı.Location = new System.Drawing.Point(152, 129);
            this.txtodakatı.Name = "txtodakatı";
            this.txtodakatı.Size = new System.Drawing.Size(131, 26);
            this.txtodakatı.TabIndex = 34;
            // 
            // txtyataksayisi
            // 
            this.txtyataksayisi.Location = new System.Drawing.Point(152, 82);
            this.txtyataksayisi.Name = "txtyataksayisi";
            this.txtyataksayisi.Size = new System.Drawing.Size(131, 24);
            this.txtyataksayisi.TabIndex = 33;
            // 
            // txtyataks
            // 
            this.txtyataks.AutoSize = true;
            this.txtyataks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtyataks.Location = new System.Drawing.Point(42, 82);
            this.txtyataks.Name = "txtyataks";
            this.txtyataks.Size = new System.Drawing.Size(100, 18);
            this.txtyataks.TabIndex = 32;
            this.txtyataks.Text = "Yatak Sayısı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtodano);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboodaozelligi);
            this.groupBox1.Controls.Add(this.ihtiyacdurumu);
            this.groupBox1.Controls.Add(this.txtucret);
            this.groupBox1.Controls.Add(this.combodurumu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtodakatı);
            this.groupBox1.Controls.Add(this.txtyataksayisi);
            this.groupBox1.Controls.Add(this.txtyataks);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 367);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Oda Bilgileri";
            // 
            // txtodano
            // 
            this.txtodano.Location = new System.Drawing.Point(152, 34);
            this.txtodano.Name = "txtodano";
            this.txtodano.Size = new System.Drawing.Size(131, 24);
            this.txtodano.TabIndex = 46;
            // 
            // OdaBilgiGüncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 390);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btngüncelle);
            this.Name = "OdaBilgiGüncelle";
            this.ShowIcon = false;
            this.Text = "OdaBilgiGüncelle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btngüncelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboodaozelligi;
        private System.Windows.Forms.ComboBox ihtiyacdurumu;
        private System.Windows.Forms.TextBox txtucret;
        private System.Windows.Forms.ComboBox combodurumu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtodakatı;
        private System.Windows.Forms.TextBox txtyataksayisi;
        private System.Windows.Forms.Label txtyataks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtodano;
        private System.Windows.Forms.ImageList ımageList1;
    }
}