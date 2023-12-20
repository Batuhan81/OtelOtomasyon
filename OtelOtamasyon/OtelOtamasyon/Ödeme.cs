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

namespace OtelOtamasyon
{
    public partial class Ödeme : Form
    {
        private Sınıf1 sınıf;
        private Sınıf2 sınıf2;

        public Ödeme(Sınıf1 s1, Sınıf2 s2)
        {
            InitializeComponent();

            sınıf = s1;
            sınıf2 = s2;
        }
        SqlConnection baglanti=new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();
        private void Ödeme_Load(object sender, EventArgs e)
        {
            //müşteri bilgilerini yerleştir
            hiddenMusteriID.Text = sınıf.MusteriID;
            txtad.Text = sınıf.musteriAd;
            txtsoyad.Text = sınıf.musteriSoyad;
            txttelefon.Text = sınıf.musteriTelefon;
            txtmail.Text = sınıf.musteriEmail;
            combocinsiyet.Text = sınıf.mustericinsiyet;
            txtadres.Text = sınıf.musteriadres;
            txtulus.Text = sınıf.musteriulus;
            txtvatandaslık.Text = sınıf.musterivatandaslık;
            txtuyelik.Text = sınıf.musteriuyelikdurumu;
            combouyelik.Text = sınıf.musteriuyelikdurumu;
            txtcocuks.Text = sınıf.mustericocuksaiyisi;
            txtkisis.Text = sınıf.musterikisisayisi;
            txttc.Text = sınıf.musteritc;
            girist.Text = sınıf.musterigirist;
            cikist.Text = sınıf.mustericikist;
            txtkaldıgıoda.Text = sınıf.musterikaldıgıoda;

            //Oda bilgilerini yerleştir
            hiddenodaID.Text = sınıf2.odaAdi;
            txtkat.Text = sınıf2.odakatı;
            txtyataksayisi.Text = sınıf2.odaKapasite;
            combodurumu.Text = sınıf2.odaDurum;
            txtucret.Text = sınıf2.ucret;
            txtodaozelligi.Text = sınıf2.odaozelligi;
            Doluoda_Getir();

            if (hiddenodaID.Text != "")
            {
                Gun_Hesapla();
            }
        }
        DataTable tablo2 = new DataTable();
        public void Doluoda_Getir()
        {
            baglanti.Open();
            ekran.DataSource = null;
            ekran.Visible = true;
            //Odalar ve Musteri Tablomun birleşimi Alıyor Örn 1 nolu odanıın ve o odada kalan kişinin gerekli tüm bilgileri.
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT o.odaID as OdaID, m.MusteriID AS MusteriID, m.ad AS ad, m.soyad AS soyad,m.telefon AS telefon,m.email AS email, m.cinsiyet AS cinsiyet, m.adres AS adres," +
            " m.ulus AS ulus, m.vatandaslık AS vatandaslık, m.uyelikdurumu AS uyelikdurumu, m.cocuksayisi AS cocuksayisi,m.kisisayisi AS kisisayisi,m.durumu AS durumu,m.tc AS tc, m.istekler AS istekler," +
            "m.girist AS girist, m.cıkıst AS cıkıst, m.kaldıgıoda AS kaldıgıoda,o.yataksayisi as yataksayisi, o. odakat as Odakat,o.durumu as Durumu, o.ucret as ucret,o.ihtiyac as ihtiyac,o.MusteriID as MüşteriID," +
            "o.odaozelligi as odaozelligi FROM Musteri m , Oda2 o where m.kaldıgıoda = o.odaID and m.durumu='Kalıyor'", baglanti);
            adapter2.Fill(tablo2);
            ekran.DataSource = tablo2;
            baglanti.Close();
        }
     
        //Dolar Euro Kurlarını Ayarlama 
        //Kendine Not bir yerden otomatik olarak güncel kuru alabilirim
        int ekstra = 0;
        decimal dolar = 27;
        decimal euro = 30;
        public void Gun_Hesapla()
        {
            if (txtucret.Text == "")
            {
                MessageBox.Show("Lütfen İşlem Yapılcak Odayı Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime Giris = DateTime.Parse(girist.Text);
                DateTime Cikis = DateTime.Now;//Müşteri Erken Çıkabilir Diye Burası Now Oluyor
                simdiTarih.Text = DateTime.Now.ToString();

                TimeSpan fark = Cikis - Giris;

                int kalinanGun = (int)fark.TotalDays + 1;//geldiği günüde ödeyecek
                txtGunsayisi.Text = kalinanGun.ToString();

                int gunlukucret = Convert.ToInt32(txtucret.Text);
                int uyelikind = 0;


                if (combouyelik.SelectedIndex == 0)
                {
                    txttutar.Text = (kalinanGun * gunlukucret).ToString();
                    txtsontutar.Text = "Üyelik İndirimi olduğundan" + (kalinanGun * gunlukucret * 90 / 100).ToString() + "₺ ödenecektir";
                    uyelikind = (kalinanGun * gunlukucret * 90 / 100);
                }
                if (combouyelik.SelectedIndex == 1)
                {
                    txttutar.Text = (kalinanGun * gunlukucret).ToString();
                    txtsontutar.Text = "Üyelik İndirimi olmadığından" + (kalinanGun * gunlukucret).ToString() + "₺ ödenecektir";
                    uyelikind = (kalinanGun * gunlukucret);
                }
                Bilgilendirme2.Text = "Hesaplama İşlemi Şuanki Tarihe Göre Yapılmıştır";
                Bilgilendirme2.Visible = true;
                simdiTarih.Visible = true;

                //ödeme yöntemleri seçilirse yapılacak işlemler
                if (checkkart.Checked)//Kartla Öderse %5 zam
                {
                    txtsontutar.Text = (uyelikind * 110 / 100).ToString("N1") + "₺";
                    ekstra = (uyelikind * 110 / 100) - (uyelikind);
                    txtbilgilendime.Text = "Kart İle Ödeme Yapıldığından " + ekstra + "₺ Ödeme Alınmıştır";
                    txtbilgilendime.Visible = true;
                }
                if (checknakit.Checked)//nakit Öderse %5indirim
                {
                    txtsontutar.Text = (uyelikind * 90 / 100).ToString("N1") + "₺";
                    ekstra = (uyelikind) - (uyelikind * 90 / 100);
                    txtbilgilendime.Text = "Nakit İle Ödeme Yapıldığından  " + ekstra + "₺ İndirim Yapılmıştır";
                    txtbilgilendime.Visible = true;
                }
                if (checkeuro.Checked)//euro öderse kura böl
                {
                    txtsontutar.Text = (uyelikind / euro).ToString("N1") + "€";
                    txtbilgilendime.Text = "1 Euro=" + euro + "₺'ye Göre Hesaplanmıştır";
                    txtbilgilendime.Visible = true;
                }
                if (checkdolar.Checked)//dolar öderse kura böl
                {
                    txtsontutar.Text = (uyelikind / dolar).ToString("N1") + "$";
                    txtbilgilendime.Text = "1 Dolar=" + dolar + "₺'ye Göre Hesaplanmıştır";
                    txtbilgilendime.Visible = true;
                }
            }
        }
       
        private string odeme_Yontemi = "";
        private void Ode_Click(object sender, EventArgs e)
        {
            if (txtucret.Text == "")
            {
                MessageBox.Show("Lütfen İşlem Yapılcak Odayı Seçiniz","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!checkkart.Checked && !checknakit.Checked && !checkeuro.Checked && !checkdolar.Checked)
                {
                    MessageBox.Show("Lütfen bir ödeme yöntemi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Daha fazla işlemin durdurulması
                }
                else
                {
                    DialogResult result2 = MessageBox.Show("Ödeme Yapmak İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Yes)
                    {
                        bool kart = checkkart.Checked;
                        bool nakit = checknakit.Checked;
                        bool euro = checkeuro.Checked;
                        bool dolar = checkdolar.Checked;
                        baglanti.Open();
                        //€ ₺ $ İşaretlerinin Temizlenmesi
                        string tutartext = txtsontutar.Text;
                        tutartext = tutartext.Replace("$", "").Replace("€", "").Replace("₺", "");
                        decimal tutar = decimal.Parse(tutartext);

                        SqlCommand komut = new SqlCommand("INSERT INTO Odeme (odaID, MusteriID, ad, soyad, telefon, email, tc, girist, cikist, odenentutar, odemetarihi, odemeturu, kalınangun)" +
                            "Values(@OdaID, @MusteriID, @ad, @soyad, @telefon, @email, @tc, @girist, @cikist, @odenentutar, @odemetarihi, @odemeturu, @kalınangun)", baglanti);
                        komut.Parameters.AddWithValue("@odaID", hiddenodaID.Text);
                        komut.Parameters.AddWithValue("@MusteriID", hiddenMusteriID.Text);
                        komut.Parameters.AddWithValue("@ad", txtad.Text);
                        komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                        komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                        komut.Parameters.AddWithValue("@email", txtmail.Text);
                        komut.Parameters.AddWithValue("@tc", txttc.Text);
                        komut.Parameters.AddWithValue("@girist", DateTime.Parse(girist.Text));
                        komut.Parameters.AddWithValue("@cikist", DateTime.Parse(cikist.Text));
                        komut.Parameters.AddWithValue("@odenentutar", tutar);
                        komut.Parameters.AddWithValue("@odemetarihi", DateTime.Now);
                        komut.Parameters.AddWithValue("@odemeturu", odeme_Yontemi);
                        komut.Parameters.AddWithValue("@kalınangun", txtGunsayisi.Text);

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        baglanti.Open();
                        //Refakatçılarında durumunu Gitti olarak güncelle
                        SqlCommand komut2 = new SqlCommand("update Refakatcı set durumu=@durumu where musteritc=@musteritc", baglanti);
                        komut2.Parameters.AddWithValue("@durumu", "Gitti");
                        komut2.Parameters.AddWithValue("@musteritc", txttc.Text);
                        komut2.ExecuteNonQuery();
                        baglanti.Close();
                        baglanti.Open();
                        // Oda durumunu Boşa çevirme

                        SqlCommand odaKomut = new SqlCommand("UPDATE Oda2 SET durumu = @durumu WHERE odaID = @odaID", baglanti);
                        odaKomut.Parameters.AddWithValue("@odaID", hiddenodaID.Text);
                        odaKomut.Parameters.AddWithValue("@durumu", "Boş");
                        MessageBox.Show("Ödeme İşlemi Gerçekleşti Oda Durumu Boş Olarak Güncellendi");
                        odaKomut.ExecuteNonQuery();
                        baglanti.Close();

                        //Müşterinin Durumunuda Gittiye ayarlıyoruz ve kaldığı odayı silmemiz lazım
                        baglanti.Open();
                        SqlCommand musteriDurumu = new SqlCommand("update Musteri set durumu=@durumu,kaldıgıoda=@kaldıgıoda,girist=@girist,cıkıst=@cıkıst where MusteriID=@MusteriID", baglanti);
                        musteriDurumu.Parameters.AddWithValue("@MusteriID", hiddenMusteriID.Text);
                        musteriDurumu.Parameters.AddWithValue("@durumu", "Gitti");
                        musteriDurumu.Parameters.AddWithValue("@girist", DateTime.Parse(girist.Text));
                        musteriDurumu.Parameters.AddWithValue("@cıkıst", DateTime.Now);
                        musteriDurumu.Parameters.AddWithValue("@kaldıgıoda", "");//kaldığı odayı boşa çıkarttım
                        musteriDurumu.ExecuteNonQuery();
                        baglanti.Close();
                        Temizle();
                        txtbilgilendime.Visible = false;
                        Bilgilendirme2.Visible = false;
                        simdiTarih.Visible = false;
                        odeme_Yontemi = "";
                        Doluoda_Getir();
                        //Odalar odalaragit = new Odalar();
                        //odalaragit.ShowDialog();//Renkleri kolayca güncellemek için odalar formunu yeniden açıyorrum ve load kısmında renkler güncelleniyor
                    }
                }
            }
        }

        public void Temizle()
        {
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

            foreach (Control item in groupBox2.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }   
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in panel1.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is CheckBox)
                {
                    item.Text = "";
                }
                if (item is DateTimePicker)
                {
                    item.Text = "";
                }
            }
        }

        private void checkkart_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkkart.Checked)
            {
                checknakit.Checked = false;
                checkeuro.Checked = false;
                checkdolar.Checked = false;
                odeme_Yontemi = "Kart";
                txtsontutar.Text = "";
               Gun_Hesapla();
            }
        }

        private void checknakit_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checknakit.Checked)
            {
                checkkart.Checked = false;
                checkeuro.Checked = false;
                checkdolar.Checked = false;
                odeme_Yontemi = "Nakit";
                txtsontutar.Text = "";
                Gun_Hesapla();
            }
        }

        private void checkeuro_CheckedChanged_1(object sender, EventArgs e)
        {
            checkkart.Checked = false;
            checknakit.Checked = false;
            checkdolar.Checked = false;
            odeme_Yontemi = "Euro";
            txtsontutar.Text = "";
            Gun_Hesapla();
        }

        private void checkdolar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkdolar.Checked)
            {
                checkkart.Checked = false;
                checkeuro.Checked = false;
                checknakit.Checked = false;
                odeme_Yontemi = "Dolar";
                txtsontutar.Text = "";
                Gun_Hesapla();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri where tc like '%" + tcara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void odaara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri where kaldıgıoda like '%" + odaara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }
        
        string secilenkat=1.ToString();
       


        private void Hesapla_Click(object sender, EventArgs e)
        {
            if (txtucret.Text == null)
            {
                MessageBox.Show("Geçerli bir ucret girilmedi");
            }
            else
            { 
                Gun_Hesapla();
            }
        }

        private void ekran_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                //Müşteri Bilgilerini İlgili alanlara Yaz
                txtad.Text = ekran.CurrentRow.Cells["ad"].Value.ToString();
                txtsoyad.Text = ekran.CurrentRow.Cells["soyad"].Value.ToString();
                txttelefon.Text = ekran.CurrentRow.Cells["telefon"].Value.ToString();
                txtmail.Text = ekran.CurrentRow.Cells["email"].Value.ToString();
                combocinsiyet.Text = ekran.CurrentRow.Cells["cinsiyet"].Value.ToString();
                txtadres.Text = ekran.CurrentRow.Cells["adres"].Value.ToString();
                txtulus.Text = ekran.CurrentRow.Cells["ulus"].Value.ToString();
                txtvatandaslık.Text = ekran.CurrentRow.Cells["vatandaslık"].Value.ToString();
                combouyelik.Text = ekran.CurrentRow.Cells["uyelikdurumu"].Value.ToString();
                txtuyelik.Text = ekran.CurrentRow.Cells["uyelikdurumu"].Value.ToString();
                txtcocuks.Text = ekran.CurrentRow.Cells["cocuksayisi"].Value.ToString();
                txtkisis.Text = ekran.CurrentRow.Cells["kisisayisi"].Value.ToString();
                txttc.Text = ekran.CurrentRow.Cells["tc"].Value.ToString();
                girist.Text = ekran.CurrentRow.Cells["girist"].Value.ToString();
                cikist.Text = ekran.CurrentRow.Cells["cıkıst"].Value.ToString();

                //Oda Bilgilerini İlgili alanlara Yaz   
                hiddenodaID.Text = ekran.CurrentRow.Cells["odaID"].Value.ToString();
                txtkaldıgıoda.Text = ekran.CurrentRow.Cells["odaID"].Value.ToString();
                txtyataksayisi.Text = ekran.CurrentRow.Cells["yataksayisi"].Value.ToString();
                txtkat.Text = ekran.CurrentRow.Cells["odakat"].Value.ToString();
                combodurumu.Text = ekran.CurrentRow.Cells["durumu"].Value.ToString();
                txtucret.Text = ekran.CurrentRow.Cells["ucret"].Value.ToString();
                txtihtiyac.Text = ekran.CurrentRow.Cells["ihtiyac"].Value.ToString();
                hiddenMusteriID.Text = ekran.CurrentRow.Cells["MusteriID"].Value.ToString();
                txtodaozelligi.Text = ekran.CurrentRow.Cells["odaozelligi"].Value.ToString();
            Gun_Hesapla();
        }

        private void hiddenMusteriID_TextChanged(object sender, EventArgs e)
        {

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
