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
    public partial class Refakatcılar : Form
    {
        public Refakatcılar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();
        public void Kayıt_Getir()//DESC kullanıyorum Çünkü en yeni ID(Yani en yeni gelen) en üstte olsun istiyorum
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Refakatcı ORDER BY refakatID DESC", baglanti);
            daset.Clear();
            adapter.Fill(daset);
            ekran.DataSource = daset.Tables[0];
            baglanti.Close();
        }

        private void Refakatcılar_Load(object sender, EventArgs e)
        {
            Kayıt_Getir();
        }
        private void tcara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Refakatcı where musteritc like '%" + tcara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }
        private void odaara_TextChanged_1(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Refakatcı where kaldıgıoda like '%" + odaara.Text + "%'ORDER BY refakatID DESC", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void reftcara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Refakatcı where tc like '%" + reftcara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void odalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Odalar odalar = new Odalar();
            odalar.ShowDialog();
        }

        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Ana_Ekran ana_Ekran = new Ana_Ekran();
            ana_Ekran.ShowDialog();
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
    }
}