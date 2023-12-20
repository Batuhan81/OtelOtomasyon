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

namespace OtelOtamasyon
{
    public partial class Konaklayanlar : Form
    {
        public Konaklayanlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();

        private void Konaklayanlar_Load(object sender, EventArgs e)
        {
            Kayıt_Getir();
        }
        public void Kayıt_Getir()
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Musteri Where durumu='Kalıyor'", baglanti);
            daset.Clear(); // Önceki verileri temizle
            adapter.Fill(daset);
            ekran.DataSource = daset.Tables[0]; 
            baglanti.Close();
        }

        private void tcara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri where tc like '%" + tcara.Text + "%'and durumu='Kalıyor'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void odaara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri where kaldıgıoda like '%" + odaara.Text + "%'and durumu='Kalıyor'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Ana_Ekran ana_Ekran = new Ana_Ekran();
            ana_Ekran.ShowDialog();
        }

        private void odalarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Odalar odalar = new Odalar();
            odalar.ShowDialog();
        }

        private void odaTelimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            OdaTeslim Yönlendir = new OdaTeslim();
            Yönlendir.ShowDialog();
        }

        private void rezervasyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Rezervasyon Yönlendir = new Rezervasyon();
            Yönlendir.ShowDialog();
        }

        private void müşterilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Müşteriler Yönlendir = new Müşteriler();
            Yönlendir.ShowDialog();
        }

        private void konaklayanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Konaklayanlar Yönlendir = new Konaklayanlar();
            Yönlendir.ShowDialog();
        }

        private void refekatçılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Refakatcılar Yönlendir = new Refakatcılar();
            Yönlendir.ShowDialog();
        }

        private void çalışanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Çalışan Yönlendir = new Çalışan();
            Yönlendir.ShowDialog();
        }

        private void grafikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            GrafikFRM Yönlendir = new GrafikFRM();
            Yönlendir.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adaara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri where ad like '%" + adaara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }
    }
}
