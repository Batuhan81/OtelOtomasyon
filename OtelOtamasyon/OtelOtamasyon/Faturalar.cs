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
    public partial class Faturalar : Form
    {
        public Faturalar()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");

        private void Satıslar()//Satışları Yeni İSimleri Beraber Ekrana Getiriyorum
        {
            baglanti.Open();
            SqlDataAdapter adapter= new SqlDataAdapter("Select *from Odeme",baglanti);
            adapter.Fill(daset, "Odeme");
            Ekran.DataSource = daset.Tables["Odeme"];
            Ekran.Columns[0].HeaderText = "Ödeme ID'si";
            Ekran.Columns[1].HeaderText = "Ödenen Tutar";
            Ekran.Columns[2].HeaderText = "Ödeme Tarihi";
            Ekran.Columns[3].HeaderText = "Ödeme Şekli";
            Ekran.Columns[4].HeaderText = "Kalınan Oda";
            Ekran.Columns[5].HeaderText = "Müşteri ID'si";
            Ekran.Columns[6].HeaderText = "Kalınan Gün";
            baglanti.Close();
        }

        private void Faturalar_Load(object sender, EventArgs e)
        {
            Satıslar();
        }

        private void tarihara_ValueChanged(object sender, EventArgs e)
        {
            DateTime tarihsec = tarihara.Value.Date;
            DataView dv = daset.Tables["Odeme"].DefaultView;
            dv.RowFilter = $"odemetarihi >= #{tarihsec.ToString("MM/dd/yyyy")}# AND odemetarihi < #{tarihsec.AddDays(1).ToString("MM/dd/yyyy")}#";
            Ekran.DataSource = dv;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Odeme where odaID like '%" + odaara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            Ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Odeme where ad like '%" + adara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            Ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Odeme where tc like '%" + tcara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            Ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void anaEkranToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Ana_Ekran anaekran = new Ana_Ekran();
            anaekran.ShowDialog();
        }

        private void odalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Odalar Yönlendir = new Odalar();
            Yönlendir.ShowDialog();
        }

        private void odaTelimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdaTeslim Yönlendir = new OdaTeslim();
            Yönlendir.ShowDialog();
        }

        private void rezervasyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezervasyon Yönlendir = new Rezervasyon();
            Yönlendir.ShowDialog();
        }

        private void müşterilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Müşteriler Yönlendir = new Müşteriler();
            Yönlendir.ShowDialog();
        }

        private void konaklayanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Konaklayanlar Yönlendir = new Konaklayanlar();
            Yönlendir.ShowDialog();
        }

        private void refekatçılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refakatcılar Yönlendir = new Refakatcılar();
            Yönlendir.ShowDialog();
        }

        private void çalışanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Çalışan Yönlendir = new Çalışan();
            Yönlendir.ShowDialog();
        }

        private void grafikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrafikFRM Yönlendir = new GrafikFRM();
            Yönlendir.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
