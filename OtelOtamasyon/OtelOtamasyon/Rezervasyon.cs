using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OtelOtamasyon
{
    public partial class Rezervasyon : Form
    {
        public Rezervasyon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Odalar odalaragit = new Odalar();
            odalaragit.ShowDialog();
        }

        private void Rezervasyon_Load(object sender, EventArgs e)
        {
            Bilgi_Getir();
        }

        DataTable tablo2 = new DataTable();
        public void Bilgi_Getir()
        {
            baglanti.Open();
            ekran.Visible = true;
            //Odalar ve Musteri Tablomun birleşimi Alıyor Örn 1 nolu odanıın ve o odada kalan kişinin gerekli tüm bilgileri.
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT o.odaID as odaID, m.MusteriID AS MusteriID, m.ad AS Ad, m.soyad AS soyad,m.telefon AS telefon,m.email AS email, m.cinsiyet AS cinsiyet, m.adres AS adres," +
            " m.ulus AS ulus, m.vatandaslık AS vatandaslık, m.uyelikdurumu AS uyelikdurumu, m.cocuksayisi AS cocuksayisi,m.kisisayisi AS kisisayisi,m.durumu AS durumu,m.tc AS tc, m.istekler AS istekler," +
            "m.girist AS girist, m.cıkıst AS cıkıst, m.kaldıgıoda AS kaldıgıoda ,o.yataksayisi AS yataksayisi, o. odakat AS Odakat,o.durumu AS Durumu, o.ucret AS ucret,o.ihtiyac AS ihtiyac," +
            "o.odaozelligi AS odaozelligi FROM Musteri m , Oda2 o where m.kaldıgıoda = o.odaID and m.durumu='Gelecek'", baglanti);
            adapter2.Fill(tablo2);
            ekran.DataSource = tablo2;
            baglanti.Close();
        }

        private void ekran_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtad.Text = ekran.CurrentRow.Cells["ad"].Value.ToString();
            txtsoyad.Text = ekran.CurrentRow.Cells["soyad"].Value.ToString();
            txttelefon.Text = ekran.CurrentRow.Cells["telefon"].Value.ToString();
            txtmail.Text = ekran.CurrentRow.Cells["email"].Value.ToString();
            combocinsiyet.Text = ekran.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtadres.Text = ekran.CurrentRow.Cells["adres"].Value.ToString();
            txtulus.Text = ekran.CurrentRow.Cells["ulus"].Value.ToString();
            txtvatandaslık.Text = ekran.CurrentRow.Cells["vatandaslık"].Value.ToString();
            combouyelik.Text = ekran.CurrentRow.Cells["uyelikdurumu"].Value.ToString();
            txtcocuksayisi.Text = ekran.CurrentRow.Cells["cocuksayisi"].Value.ToString();
            txtkisisayisi.Text = ekran.CurrentRow.Cells["kisisayisi"].Value.ToString();
            txttc.Text = ekran.CurrentRow.Cells["tc"].Value.ToString();
            txtistek.Text = ekran.CurrentRow.Cells["istekler"].Value.ToString();
            girist.Text = ekran.CurrentRow.Cells["girist"].Value.ToString();
            cikist.Text = ekran.CurrentRow.Cells["cıkıst"].Value.ToString();
            txtkaldıgıoda.Text = ekran.CurrentRow.Cells["kaldıgıoda"].Value.ToString();

            hiddenodaID.Text = ekran.CurrentRow.Cells["odaID"].Value.ToString();
            txtyataks.Text = ekran.CurrentRow.Cells["yataksayisi"].Value.ToString();
            txtkat.Text = ekran.CurrentRow.Cells["odakat"].Value.ToString();
            txtodadurumu.Text = ekran.CurrentRow.Cells["durumu"].Value.ToString();
            txtucret.Text = ekran.CurrentRow.Cells["ucret"].Value.ToString();
            //txtihtiyac.Text = ekran.CurrentRow.Cells["ihtiyac"].Value.ToString();
            hiddenMusteriID.Text = ekran.CurrentRow.Cells["MusteriID"].Value.ToString();
            txtodaozelligi.Text = ekran.CurrentRow.Cells["odaozelligi"].Value.ToString();
        }
        public void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
                if(item is ComboBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in panel1.Controls)
            {
                if (item is DateTimePicker)
                {
                    item.Text = "";
                }
                txtistek.Text = "";
            }
        }
 
        private void btnrezervsil_Click(object sender, EventArgs e)
        {
            if (txttc.Text == "")
            {
                MessageBox.Show("Silinebilecek Bir Kimlik Numarası Seçmelisiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Kaydı Silmek İstediğininze Emin Misininz", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //rezervasyonun iptali durumunda kişinin ve odanın durmularını boşaltır
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("Update Musteri set durumu=@durumu where MusteriID=@MusteriID", baglanti);
                    komut.Parameters.AddWithValue("@durumu", "");
                    komut.Parameters.AddWithValue("@MusteriID", hiddenMusteriID.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update  Oda2 set durumu=@durumu where odaID=@odaID", baglanti);
                    komut2.Parameters.AddWithValue("@durumu", "Boş");
                    komut2.Parameters.AddWithValue("@odaID", txtkaldıgıoda.Text);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("İşlem İptal Edildi");
                }
            }
        }

        private void güncelle_Click(object sender, EventArgs e)
        {
            if (txttc.Text == "")
            {
                MessageBox.Show("Güncellenecek Veri Bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Update  Musteri set ad=@ad,soyad=@soyad,telefon=@telefon,email=@email,cinsiyet=@cinsiyet,adres=@adres,ulus=@ulus,vatandaslık=@vatandaslık,uyelikdurumu=@uyelikdurumu," +
                " cocuksayisi=@cocuksayisi,kisisayisi=@kisisayisi,tc=@tc,istekler=@istekler,girist=@girist,cıkıst=@cıkıst,kaldıgıoda=@kaldıgıoda where MusteriID=@MusteriID", baglanti);
                komut.Parameters.AddWithValue("@MusteriID", hiddenMusteriID.Text);
                komut.Parameters.AddWithValue("ad", txtad.Text);
                komut.Parameters.AddWithValue("soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("email", txtmail.Text);
                komut.Parameters.AddWithValue("cinsiyet", combocinsiyet.Text);
                komut.Parameters.AddWithValue("adres", txtadres.Text);
                komut.Parameters.AddWithValue("ulus", txtulus.Text);
                komut.Parameters.AddWithValue("vatandaslık", txtvatandaslık.Text);
                komut.Parameters.AddWithValue("uyelikdurumu", combouyelik.Text);
                komut.Parameters.AddWithValue("cocuksayisi", txtcocuksayisi.Text);
                komut.Parameters.AddWithValue("kisisayisi", txtkisisayisi.Text);
                komut.Parameters.AddWithValue("tc", txttc.Text);
                komut.Parameters.AddWithValue("istekler", txtistek.Text);
                komut.Parameters.AddWithValue("girist", DateTime.Parse(girist.Text));
                komut.Parameters.AddWithValue("cıkıst", DateTime.Parse(cıkıst.Text));
                komut.Parameters.AddWithValue("kaldıgıoda", txtkaldıgıoda.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme İşlemi Başarılı");
                baglanti.Close();
                Temizle();
            }
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
