using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OtelOtamasyon
{
    public partial class GrafikFRM : Form
    {
        public GrafikFRM()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");

        string secilenkat=0.ToString();
        int toplamOdaSayisi = 0;
    
        public void OdaBilgileri()
        {
            baglanti.Open();
            string[] durumlar = { "Dolu", "Boş", "Servis Dışı", "Rezerve" };
            Color[] renkler = { Color.Red, Color.Green, Color.Gray, Color.Yellow };
            // Seçilen kattaki toplam oda sayısını buldurma
            SqlCommand toplamOdaKomut = new SqlCommand("SELECT COUNT(*) FROM Oda2 WHERE odakat=@odakat", baglanti);
            toplamOdaKomut.Parameters.AddWithValue("@odakat", secilenkat);
            toplamOdaSayisi = (int)toplamOdaKomut.ExecuteScalar();

            for (int i = 0; i < durumlar.Length; i++)
            {
                string durum = durumlar[i];
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Oda2 WHERE odakat=@odakat AND durumu=@durum", baglanti);
                komut.Parameters.AddWithValue("@odakat", secilenkat);
                komut.Parameters.AddWithValue("@durum", durum);

                int odaSayisi = (int)komut.ExecuteScalar();

                if (odaSayisi > 0)
                {
                    chart1.Series[0].Points.AddXY(durum, odaSayisi);
                    chart1.Series[0].Points[i].Color = renkler[i]; // Her durum için farklı renk
                    double yuzdelikOran = (double)odaSayisi / toplamOdaSayisi * 100.0;
                    chart1.Series[0].Points[i].Label = $"{durumlar[i]}: {yuzdelikOran.ToString("0.00")}%";
                }
                else
                {
                    chart1.Series[0].Points.AddXY(durum, 0);//Eğer o Durumda bir oda yoksa etiketini siliyorumki kötü görüntü oluşmasın
                    chart1.Series[0].Points[i].IsEmpty = true;
                }
            }
            chart1.Titles.Clear();
            chart1.Titles.Add("Oda Durumları"); // Başlık
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut; // Pasta grafiği türü
            baglanti.Close();
        }

        private void GrafikFRM_Load(object sender, EventArgs e)//LOad kısmında Genel Doluluk durumunu göstericek şekilde Ayarladım
        {
            ComboKatı_Doldur();
            chart1.Series[0].Points.Clear();
            chart1.Titles.Clear();
            OdaBilgileri();
            GenelGrafikOlustur();
        }

        private void geneldoluluk_Click(object sender, EventArgs e)
        {
            GenelGrafikOlustur();
        }
        private void GenelGrafikOlustur()
        {
            chart1.Series[0].Points.Clear();
            chart1.Titles.Clear();
            baglanti.Open();
            string[] durumlar = { "Dolu", "Boş", "Servis Dışı", "Rezerve" };
            Color[] renkler = { Color.Red, Color.Green, Color.Gray, Color.Yellow };

            // Seçilen kattaki toplam oda sayısını bulun
            SqlCommand toplamOdaKomut = new SqlCommand("SELECT COUNT(*) FROM Oda2 ", baglanti);
            toplamOdaSayisi = (int)toplamOdaKomut.ExecuteScalar();

            for (int i = 0; i < durumlar.Length; i++)
            {
                string durum = durumlar[i];
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Oda2 WHERE durumu=@durum", baglanti);
                komut.Parameters.AddWithValue("@durum", durum);
                int odaSayisi = (int)komut.ExecuteScalar();

                if (odaSayisi > 0)
                {
                    chart1.Series[0].Points.AddXY(durum, odaSayisi);
                    chart1.Series[0].Points[i].Color = renkler[i]; // Her durum için farklı renk
                    double yuzdelikOran = (double)odaSayisi / toplamOdaSayisi * 100.0;
                    chart1.Series[0].Points[i].Label = $"{durumlar[i]}: {yuzdelikOran.ToString("0.00")}%";
                }
                else
                {
                    chart1.Series[0].Points.AddXY(durum, 0); // Eğer oda yoksa 0 olarak ekleyin
                    chart1.Series[0].Points[i].IsEmpty = true; // Boş etiketler
                }
            }
            chart1.Titles.Add("Otel Genel Durum"); // Başlık
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut; // Pasta grafiği türü
            baglanti.Close();
        }

        private void comboKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Titles.Clear();
            secilenkat = comboKat.Text;
            OdaBilgileri();
        }
        public void ComboKatı_Doldur() //combokat a Eklenen Katları yerleştiriyor
        {
            comboKat.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select KatNo From Katlar", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                comboKat.Items.Add(reader["KatNo"].ToString());
            }
            reader.Close();
            baglanti.Close();
        }
    }
}
