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
    public partial class OdaBilgiGüncelle : Form
    {
        public OdaBilgiGüncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        private void btngüncelle_Click(object sender, EventArgs e)
        {
            if (durum == true)
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("Update Oda2 set yataksayisi=@yataksayisi,odakat=@odakat,durumu=@durumu,ucret=@ucret,ihtiyac=@ihtiyac,odaozelligi=@odaozelligi where odaID=@odaID", baglantı);
                komut.Parameters.AddWithValue("@odaID", txtodano.Text);//buraya odaAdını almam lazım
                komut.Parameters.AddWithValue("@yataksayisi", txtyataksayisi.Text);
                komut.Parameters.AddWithValue("@odakat", txtodakatı.Text);
                komut.Parameters.AddWithValue("@durumu", combodurumu.Text);
                komut.Parameters.AddWithValue("@ucret", txtucret.Text);
                komut.Parameters.AddWithValue("@ihtiyac", ihtiyacdurumu.Text);
                komut.Parameters.AddWithValue("@odaozelligi", comboodaozelligi.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme İşlemi Başarılı");
                baglantı.Close();

                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                this.Close();
                Odalar odalaragit = new Odalar();
                odalaragit.ShowDialog();
            }
            else
            {
                MessageBox.Show("Dolu Odada Güncelleme İşlemi Yapılamaz");
            }
        }
        bool durum = true;
        public void Verileriaktar(string odaAdi,string yataks, string odakat, string durumu, int ucret, string ihtiyac, string odaozelligi)
        {
            txtodano.Text = odaAdi;
            txtodakatı.Text = odakat;
            txtyataksayisi.Text = yataks;
            combodurumu.Text = durumu;
            txtucret.Text = ucret.ToString();
            ihtiyacdurumu.Text=ihtiyac;
            comboodaozelligi.Text= odaozelligi;
            if (combodurumu.Text == "Dolu")
            {
                durum=false;
            }
            else
            {
                durum=true;
            }
        }
    }
}
