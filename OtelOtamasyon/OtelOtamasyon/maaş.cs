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
    public partial class maaş : Form
    {
        public maaş()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();
        public void Calısan_Guncelle()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Calısan", baglantı);
            SqlDataReader reader = komut.ExecuteReader();
       
            DataTable table = new DataTable();
            table.Load(reader);
            ekran.DataSource = table;

            reader.Close();
            baglantı.Close();
        }

        private void maaş_Load(object sender, EventArgs e)
        {
            Calısan_Guncelle();
        }

        private void departmanara_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglantı.Open();

            try
            {
                if (departmanara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Temizlik'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;

                }
                if (departmanara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Tekniker'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 3)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Resepsiyon'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 4)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Bahçıvan'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 5)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Aşçı'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 6)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Yönetici'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
            }
            catch
            {
                ;
            }
            baglantı.Close();
        }

        private void tcara_TextChanged(object sender, EventArgs e)
        {
            departmanara.Text = "";
            adara.Text = "";
            cinsiyetara.Text = "";
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Calısan where tc like '%" + tcara.Text + "%'", baglantı);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglantı.Close();
        }

        private void adara_TextChanged(object sender, EventArgs e)
        {
            tcara.Text = "";
            departmanara.Text = "";
            cinsiyetara.Text = "";
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Calısan where ad like '%" + adara.Text + "%'", baglantı);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglantı.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcara.Text = "";
            adara.Text = "";
            departmanara.Text = "";
            baglantı.Open();
            try
            {
                if (cinsiyetara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (cinsiyetara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where cinsiyet='Kadın'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (cinsiyetara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where cinsiyet='Erkek'", baglantı);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
            }
            catch
            {
                ;
            }
            baglantı.Close();
        }

        private void departmanara_TextChanged(object sender, EventArgs e)
        {
            tcara.Text = "";
            adara.Text = "";
            cinsiyetara.Text = "";
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
