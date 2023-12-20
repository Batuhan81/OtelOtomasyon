using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OtelOtamasyon
{
    public partial class OdabilgileriniGetir : Form
    {
        private Sınıf1 sınıf;
        private Sınıf2 sınıf2;

        public OdabilgileriniGetir(Sınıf1 s1, Sınıf2 s2)
        {
            InitializeComponent();

            sınıf = s1;
            sınıf2 = s2;
        }

        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        private void btnodeme_Click(object sender, EventArgs e)
        {
            //ödemeye tıklandığında mevcut verileri tekrar kayıt edip ödeme formunda tekrar geri alıyorum
            
            sınıf.MusteriID = hiddenMusteriID.Text;
            sınıf.musteriAd=txtad.Text;
            sınıf.musteriSoyad=txtsoyad.Text;
            sınıf.musteriTelefon=txttelefon.Text;
            sınıf.musteriEmail=txtmail.Text;
            sınıf.mustericinsiyet=txtcinsiyet.Text;
            sınıf.musteriadres=txtadres.Text;
            sınıf.musteriulus=txtulus.Text;
            sınıf.musterivatandaslık=txtvatandaslık.Text;
            sınıf.mustericocuksaiyisi=txtcocuks.Text;
            sınıf.musterikisisayisi=txtkisis.Text;
            sınıf.musteriuyelikdurumu=combouyelik.Text;
            sınıf.musteritc=txttc.Text;
            sınıf.musteriistekler=txtistek.Text;
            sınıf.musterigirist=girist.Text;
            sınıf.mustericikist=cikist.Text;
            sınıf.musterikaldıgıoda=txtkaldıgıoda.Text;

            Sınıf2 sınıf2 = new Sınıf2();
     
            sınıf2.odaAdi= txtkaldıgıoda.Text;
            sınıf2.odaKapasite=txtyataksayisi.Text;
            sınıf2.odakatı=txtodakatı.Text; 
            sınıf2.odaDurum= combodurum.Text;
            sınıf2.ucret =txtucret.Text;
            sınıf2.ihtiyac =txtihtiyacdurumu.Text;
            sınıf2.odaozelligi = txtodaozelligi.Text;
            Ödeme ödeme = new Ödeme(sınıf,sınıf2);
            ödeme.ShowDialog();
            this.Close();
        }

        private void OdabilgileriniGetir_Load(object sender, EventArgs e)
        {
            // DateTimePicker'ın Format ve CustomFormat özelliklerini ayarlayın
            girist.Format = DateTimePickerFormat.Custom;
            girist.CustomFormat = "dd/MM/yyyy HH:mm";


            cikist.Format = DateTimePickerFormat.Custom;
            cikist.CustomFormat = "dd/MM/yyyy HH:mm";

            //odalar formundan alınan verileri ilgili alanlara yazdırma

            hiddenMusteriID.Text = sınıf.MusteriID;
                txtad.Text = sınıf.musteriAd;
                txtsoyad.Text = sınıf.musteriSoyad;
                txttelefon.Text = sınıf.musteriTelefon;
                txtmail.Text = sınıf.musteriEmail;
                txtcinsiyet.Text = sınıf.mustericinsiyet;
                txtadres.Text = sınıf.musteriadres;
                txtulus.Text = sınıf.musteriulus;
                txtvatandaslık.Text = sınıf.musterivatandaslık;
                combouyelik.Text = sınıf.musteriuyelikdurumu;
                txtcocuks.Text = sınıf.mustericocuksaiyisi;
                txtkisis.Text = sınıf.musterikisisayisi;
                txttc.Text = sınıf.musteritc;
                txtistek.Text = sınıf.musteriistekler;
                girist.Text = sınıf.musterigirist;
                cikist.Text = sınıf.mustericikist;
                txtkaldıgıoda.Text = sınıf.musterikaldıgıoda;
          
                txtodano.Text = sınıf2.odaAdi;
                txtyataksayisi.Text = sınıf2.odaKapasite;
                txtodakatı.Text = sınıf2.odakatı;
                mevcutdurum.Text = sınıf2.odaDurum;
                combodurum.Text = sınıf2.odaDurum;
                txtucret.Text = sınıf2.ucret;
                txtihtiyacdurumu.Text = sınıf2.ihtiyac;
                txtodaozelligi.Text = sınıf2.odaozelligi;

            if (mevcutdurum.Text == "Dolu")
            {
                combodurumu.Text = "Kalıyor";
            }
            if (mevcutdurum.Text == "Rezerve") 
            {
                combodurumu.Text = "Gelecek";
                btngeldi.Visible = true;
                btnodeme.Visible = false;
            }
            AyarlaOncekiTarihler();
            Refgetir();
        }
        DataTable tablo = new DataTable();
        public void Refgetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *From Refakatcı Where musteritc=@musteritc", baglanti);
            komut.Parameters.AddWithValue("musteritc",txttc.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            adapter.Fill(tablo);
            ekran.DataSource = tablo;
        }
        private DateTime eskiGirisTarihi;
        private DateTime eskiCikisTarihi;

        // Bu metodu çağırarak tarih alanlarının önceki değerlerini ayarlayabilirsiniz
        private void AyarlaOncekiTarihler()
        {
            eskiGirisTarihi = girist.Value;
            eskiCikisTarihi = cikist.Value;
        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            DateTime girisTarihi = girist.Value;
            DateTime cikisTarihi = cikist.Value;
            DateTime simdiTarihi = DateTime.Now;
            if (girisTarihi < simdiTarihi)
            {
                //MessageBox.Show("Giriş Tarihi Şuanki Tarihinden Daha Sonra Olmalı");
                //girist.Value = eskiGirisTarihi;
                //cikist.Value = eskiCikisTarihi;
                //return;
                
            }
            else if (cikisTarihi < girisTarihi)
            {
                MessageBox.Show("Çıkış Tarihi Giriş Tarihinden Daha Sonra Olmalı");
                girist.Value = eskiGirisTarihi;
                cikist.Value = eskiCikisTarihi;
                return;
            }
            else 
            { 
                baglanti.Close();
                //Güncelleme yapılıyor
                baglanti.Open();
                SqlCommand Güncelle = new SqlCommand("update Musteri set ad=@ad,soyad=@soyad,telefon=@telefon,email=@email,cinsiyet=@cinsiyet,adres=@adres,ulus=@ulus,vatandaslık=@vatandaslık" +
                    ",uyelikdurumu=@uyelikdurumu,cocuksayisi=@cocuksayisi,kisisayisi=@kisisayisi,durumu=@durumu,tc=@tc,istekler=@istekler,girist=@girist,cıkıst=@cıkıst," +
                    "kaldıgıoda=@kaldıgıoda WHERE tc=@tc", baglanti);//Tc yerine Müşteri Id daha sağlıklı Olacaktır
          
                Güncelle.Parameters.AddWithValue("ad", txtad.Text);
                Güncelle.Parameters.AddWithValue("soyad", txtsoyad.Text);
                Güncelle.Parameters.AddWithValue("telefon", txttelefon.Text);
                Güncelle.Parameters.AddWithValue("email", txtmail.Text);
                Güncelle.Parameters.AddWithValue("cinsiyet", txtcinsiyet.Text);
                Güncelle.Parameters.AddWithValue("adres", txtadres.Text);
                Güncelle.Parameters.AddWithValue("ulus", txtulus.Text);
                Güncelle.Parameters.AddWithValue("vatandaslık", txtvatandaslık.Text);
                Güncelle.Parameters.AddWithValue("uyelikdurumu", combouyelik.Text);
                Güncelle.Parameters.AddWithValue("cocuksayisi", txtcocuks.Text);
                Güncelle.Parameters.AddWithValue("kisisayisi", txtkisis.Text);
                Güncelle.Parameters.AddWithValue("durumu", combodurumu.Text);
                Güncelle.Parameters.AddWithValue("tc", txttc.Text);
                Güncelle.Parameters.AddWithValue("istekler", txtistek.Text);
                Güncelle.Parameters.AddWithValue("girist", DateTime.Parse(girist.Text));
                Güncelle.Parameters.AddWithValue("cıkıst", DateTime.Parse(cikist.Text));
                Güncelle.Parameters.AddWithValue("kaldıgıoda", txtkaldıgıoda.Text);
                Güncelle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme İşlemi Başarılı");
                baglanti.Close();
                this.Close();
            }
            Odalar odalar=new Odalar();
            odalar.ShowDialog();
        }

        private void btngeldi_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            //Müşteri odayı teslim almak için geldiğinde geldi butonuna basılınca Müşterinin Idsine bakarak durumunu ve giriş Tarihi Güncelliyorum Ayrıyetten Odanın Durumunuda Dolu yapmalıyım
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Musteri set durumu=@durumu,girist=@girist where MusteriID=@MusteriID", baglanti);
            komut.Parameters.AddWithValue("durumu","Kalıyor");
            komut.Parameters.AddWithValue("girist", DateTime.Now);
            komut.Parameters.AddWithValue("MusteriID", hiddenMusteriID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Update Oda2 set durumu=@durumu where odaID=@odaID", baglanti);
            komut2.Parameters.AddWithValue("durumu", "Dolu");//Odanın durumunu dolu olarak Güncelliyorum
            komut2.Parameters.AddWithValue("odaId",txtodano.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Durumu,Giriş Tarihi ve Odanın Durumu  Güncellendi");
            this.Close();
        }
    }
}

