namespace OtelOtamasyon
{
    partial class GrafikFRM
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.geneldoluluk = new System.Windows.Forms.Button();
            this.comboKat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "Dolu";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Dolu";
            legend1.TitleForeColor = System.Drawing.SystemColors.Desktop;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1, 1);
            this.chart1.Name = "chart1";
            series1.ChartArea = "Dolu";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Dolu";
            series1.Name = "Dolu";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(583, 433);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            title1.Name = "oteldoluluk";
            title1.Text = "Otel Doluluk Oranı";
            this.chart1.Titles.Add(title1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bilgisini İstediğiniz Kat";
            // 
            // geneldoluluk
            // 
            this.geneldoluluk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geneldoluluk.Location = new System.Drawing.Point(434, 440);
            this.geneldoluluk.Name = "geneldoluluk";
            this.geneldoluluk.Size = new System.Drawing.Size(108, 72);
            this.geneldoluluk.TabIndex = 3;
            this.geneldoluluk.Text = "Genel Doluluk";
            this.geneldoluluk.UseVisualStyleBackColor = true;
            this.geneldoluluk.Click += new System.EventHandler(this.geneldoluluk_Click);
            // 
            // comboKat
            // 
            this.comboKat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboKat.FormattingEnabled = true;
            this.comboKat.Location = new System.Drawing.Point(238, 467);
            this.comboKat.Name = "comboKat";
            this.comboKat.Size = new System.Drawing.Size(137, 24);
            this.comboKat.TabIndex = 16;
            this.comboKat.SelectedIndexChanged += new System.EventHandler(this.comboKat_SelectedIndexChanged);
            // 
            // GrafikFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 519);
            this.Controls.Add(this.comboKat);
            this.Controls.Add(this.geneldoluluk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.Name = "GrafikFRM";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grafik";
            this.Load += new System.EventHandler(this.GrafikFRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button geneldoluluk;
        private System.Windows.Forms.ComboBox comboKat;
    }
}