using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography;
using static System.Windows.Forms.AxHost;

namespace OtelOtamasyon
{
    public partial class OdaTeslim : Form
    {
        private string gelenOda;
        private Sınıf3 sınıf3;
        public OdaTeslim()
        {
            InitializeComponent();
        }

        public OdaTeslim(string oda, Sınıf3 s3)
        {
            InitializeComponent();
            gelenOda = oda;
            sınıf3 = s3;
        }

        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();
        DataTable tablo = new DataTable();
        int odaKapasite = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            // DateTimePicker'ın Format ve CustomFormat özelliklerini ayarlayın
            girist.Format = DateTimePickerFormat.Custom;
            girist.CustomFormat = "dd/MM/yyyy HH:mm";
           
            cikist.Format = DateTimePickerFormat.Custom;
            cikist.CustomFormat = "dd/MM/yyyy HH:mm";
            
            if (sınıf3 != null)
            {
                txtodano.Text = sınıf3.odaAdi;
                txtyataksayisi.Text = sınıf3.odaKapasite;
                comboodadurumu.Text = sınıf3.odaDurum;
                txtkat.Text = sınıf3.odakatı;
                txtucret.Text = sınıf3.ucret;
                İhtiyacdurumu.Text = sınıf3.ihtiyac;
                odaozelligi.Text = sınıf3.odaozelligi;
                yataksara.Visible = false;
                odaKapasite = Convert.ToInt32(txtyataksayisi.Text);
            }
            else
            {
                ;
            }
            if(comboodadurumu.Text =="Boş")
            {   
                label23.Visible = false;
                ekran2.Visible = false;
            }
            if (txtodano.Text == null) 
            { 
                seciliOdaNumarasi = Convert.ToInt32(txtodano.Text);
            }
            else
            {
                ;
            }
            
            Bosoda_Getir();
            AyarlaOncekiTarihler();
        }
        
        DataTable tablo2 = new DataTable();
        public void Bosoda_Getir()
        {
          baglanti.Open();
          SqlDataAdapter adapter2= new SqlDataAdapter("Select odaID,yataksayisi,odakat,durumu,ucret,ihtiyac,odaozelligi from Oda2 where durumu='Boş'",baglanti);
          adapter2.Fill(tablo2);
          ekran2.DataSource = tablo2;
          baglanti.Close();
        }

        private bool MusteriExists(string tc)
        {
            baglanti.Open();
            SqlCommand tcControl = new SqlCommand("Select Count (*) From Musteri Where tc=@tc", baglanti);
            tcControl.Parameters.AddWithValue("@tc", tc);

            int count = (int)tcControl.ExecuteScalar();

            return count > 0;
        }
        int seciliOdaNumarasi = 1;
        //int sonmusteriID = 0;
        private DateTime eskiGirisTarihi;
        private DateTime eskiCikisTarihi;

        // Bu metodu çağırarak tarih alanlarının önceki değerlerini ayarlayabilirsiniz
        private void AyarlaOncekiTarihler()
        {
            eskiGirisTarihi = girist.Value;
            eskiCikisTarihi = cikist.Value;
        }
        bool durum = true;
        public void musteridrmKontrol()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Musteri where durumu='Kalıyor' and tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", txttc.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                durum = false;
            }
            else//Bunların yeri Yanlışmış şuan doğru
            {
                durum = true;
            }
            baglanti.Close();
        }
   
        private void btnodateslim_Click(object sender, EventArgs e)
        {
            if (comboodadurumu.Text == "Servis Dışı")//Servis Dışıysa işlem Yaptırmıyorum
            {
                MessageBox.Show("Bu Odada İşelem Yapılamaz Çünkü Oda Servis Dışı", "Uyarı!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                musteridrmKontrol();
                if (durum == true)
                {
                    //Tüm Texboxların dolu olduğundan emin olurum
                    BosBilgi_Kontrol();
                    if (boskontrol == false)
                    {
                        MessageBox.Show("Müşteri ile İlgili Tüm Alanları Doldurduğunuzdan Emin Olun!", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else//Hepsi Doluysa İşleme devam Et
                    {
                        //eğer odadak yatak sayısı kalacak kişi sayısından daha azsa uyarmalı ve teslim etme işlemini engellemeliyim
                        if (odaKapasite < Convert.ToInt32(txtkisisayisi.Text))
                        {
                            MessageBox.Show("Odanın Kapasitesi Aşıldı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            seciliOdaNumarasi = Convert.ToInt32(txtodano.Text);
                            string tc = txttc.Text;
                            DateTime girisTarihi = girist.Value;
                            DateTime cikisTarihi = cikist.Value;
                            DateTime simdiTarihi = DateTime.Now;
                            if (girisTarihi > simdiTarihi)
                            {
                                MessageBox.Show("Giriş Tarihi Şuanki Tarihinden Daha Sonra Olmalı","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                girist.Value = eskiGirisTarihi;
                                cikist.Value = eskiCikisTarihi;
                                return;
                            }
                            else if (cikisTarihi <= girisTarihi)
                            {
                                MessageBox.Show("Çıkış Tarihi Giriş Tarihinden Daha Sonra Olmalı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                girist.Value = eskiGirisTarihi;
                                cikist.Value = eskiCikisTarihi;
                                return;
                            }
                            else//tarihler uygunsa işlemi yap
                            {
                                if (!MusteriExists(tc))
                                {
                                    // Müşteri veritabanında yoksa yeni müşteri kaydı ekliyor
                                    using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
                                    {
                                        baglanti.Open();
                                        string sql = "INSERT INTO Musteri (ad, soyad, telefon, email, cinsiyet, adres, ulus, vatandaslık, uyelikdurumu, cocuksayisi, kisisayisi, istekler, tc, durumu, girist, cıkıst, kaldıgıoda) " +
                                                     "VALUES (@ad, @soyad, @telefon, @email, @cinsiyet, @adres, @ulus, @vatandaslik, @uyelikdurumu, @cocuksayisi, @kisisayisi, @istekler, @tc, @durumu, @girist, @cıkıst, @kaldıgıoda)";
                                        SqlCommand komut = new SqlCommand(sql, baglanti);

                                        komut.Parameters.AddWithValue("@ad", txtad.Text);
                                        komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                                        komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                                        komut.Parameters.AddWithValue("@email", txtmail.Text);
                                        komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                                        komut.Parameters.AddWithValue("@adres", txtadres.Text);
                                        komut.Parameters.AddWithValue("@ulus", txtulus.Text);
                                        komut.Parameters.AddWithValue("@vatandaslik", txtvatandaslık.Text);
                                        komut.Parameters.AddWithValue("@uyelikdurumu", comboüyelik.SelectedItem.ToString());
                                        komut.Parameters.AddWithValue("@cocuksayisi", Convert.ToInt32(txtcocuksayisi.Text));
                                        komut.Parameters.AddWithValue("@kisisayisi", Convert.ToInt32(txtkisisayisi.Text));
                                        komut.Parameters.AddWithValue("@istekler", txtistekler.Text);
                                        komut.Parameters.AddWithValue("@tc", txttc.Text);
                                        komut.Parameters.AddWithValue("@durumu", "Kalıyor"); // burada durumunu kalıyor moduna aldım
                                        komut.Parameters.AddWithValue("@girist", DateTime.Parse(girist.Text));
                                        komut.Parameters.AddWithValue("@cıkıst", DateTime.Parse(cikist.Text));
                                        komut.Parameters.AddWithValue("@kaldıgıoda", seciliOdaNumarasi);
                                        komut.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    //Aslında Bu kısmı kaldırmam daha mantıklı olabilir Çünkü her Müşteriye yeni Kayıt Açıp yeni Bir Id kazandırmak daha mantıklı olacaktır hem bu sayede VT de müşterinin daha önceden girip çıktığı
                                    //Tarihleride görebiliriz bunu bi sor
                                    int secilitc = Convert.ToInt32(txttc.Text);
                                    // Müşteri veritabanında varsa müşterinin durumunu güncelle
                                    using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
                                    {
                                        baglanti.Open();
                                        SqlCommand komut = new SqlCommand("update Musteri set durumu=@durumu ,kaldıgıoda=@kaldıgıoda,girist=@girist,cıkıst=@cıkıst where MusteriID=@MusteriID ", baglanti);
                                        komut.Parameters.AddWithValue("@MusteriID", musteriID);
                                        komut.Parameters.AddWithValue("@durumu", "Kalıyor");
                                        komut.Parameters.AddWithValue("@kaldıgıoda", seciliOdaNumarasi);
                                        komut.Parameters.AddWithValue("@girist", DateTime.Parse(girist.Text));
                                        komut.Parameters.AddWithValue("@cıkıst", DateTime.Parse(cikist.Text));
                                        komut.ExecuteNonQuery();
                                        baglanti.Close();
                                        MessageBox.Show("Müşteri Zaten Kayıtlıydı Durumu Güncellendi");
                                    }
                                }
                                baglanti.Close();
                                //müşteriyle beraber müşterinin refatkatçısınında durumunu kalıyor olarak ayarlayıp gerektiği yerlerde güncelle
                                baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("update Refakatcı set durumu=@durumu where musteritc=@musteritc", baglanti);
                                komut2.Parameters.AddWithValue("@durumu", "Kalıyor");
                                komut2.Parameters.AddWithValue("@musteritc", txttc.Text);
                                komut2.ExecuteNonQuery();
                                baglanti.Close();
                                baglanti.Open();
                                // Oda durumunu doluya çevirme
                                SqlCommand odaKomut = new SqlCommand("UPDATE Oda2 SET durumu = @durumu,MusteriID=MusteriID WHERE odaID = @odaID", baglanti);
                                odaKomut.Parameters.AddWithValue("@odaID", seciliOdaNumarasi);
                                odaKomut.Parameters.AddWithValue("@durumu", "Dolu");
                                odaKomut.ExecuteNonQuery();

                                MessageBox.Show("Müşteri kaydı başarıyla eklendi ve Oda durumu da güncellendi.");
                                Temizle();
                                baglanti.Close();

                                eskiGirisTarihi = girisTarihi;
                                eskiCikisTarihi = cikisTarihi;
                                Odalar odalaragit = new Odalar();
                                odalaragit.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bu Müşteri Hali Hazırda Bir Odada Kalıyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.Close();
        }
        private bool dataGridVisible = false;

        private void txttc_TextChanged(object sender, EventArgs e)
        {
            if (!dataGridVisible)
            {
                Göster();
            }
            TCGetirme();
        }
        private void Göster()
        {
            ekran.Visible = true;
            dataGridVisible = true;
        }
        private void Sakla()
        {
            ekran.Visible = false;
            dataGridVisible = false;
        }
        private void TCGetirme()
        {

            using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
            {
                tablo.Clear();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select MusteriID,ad,soyad,telefon,email,cinsiyet,adres,ulus,vatandaslık,tc from Musteri where tc like '%" + txttc.Text + "%'AND durumu NOT IN ('Kalıyor','Gelecek')", baglanti);
                adtr.Fill(tablo);
                ekran.DataSource = tablo;
                baglanti.Close();
            }
        }
        string musteriID=0.ToString();
        private void ekran_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            // DataGridView satırına tıklanıldığında yapılması gereken işlemler.
            Sakla();
            musteriID = ekran.CurrentRow.Cells["MusteriID"].Value.ToString();
            txtad.Text = ekran.CurrentRow.Cells["ad"].Value.ToString();
            txtsoyad.Text = ekran.CurrentRow.Cells["soyad"].Value.ToString();
            txttelefon.Text = ekran.CurrentRow.Cells["telefon"].Value.ToString();
            txtmail.Text = ekran.CurrentRow.Cells["email"].Value.ToString();
            combocinsiyet.Text = ekran.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtadres.Text = ekran.CurrentRow.Cells["adres"].Value.ToString();
            txttc.Text = ekran.CurrentRow.Cells["tc"].Value.ToString();
            txtulus.Text = ekran.CurrentRow.Cells["ulus"].Value.ToString();
            txtvatandaslık.Text = ekran.CurrentRow.Cells["vatandaslık"].Value.ToString();
            hiddenMusteriID.Text=musteriID.ToString();
            ekran.Visible = false;
        }

        private void Temizle()
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
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnrezerve_Click(object sender, EventArgs e)
        {
           if (comboodadurumu.Text == "Servis Dışı")
           {
                MessageBox.Show("Bu Odada İşlem Yapılamaz Çünkü Oda Servis Dışı");
                return;
           }
           else
           {
              musteridrmKontrol();
              if (durum == true)
              {
                   //Tüm Texboxların dolu olduğundan emin olurum
                    BosBilgi_Kontrol();
                    if (boskontrol == false)
                    {
                        MessageBox.Show("Müşteri ile İlgili Tüm Alanları Doldurduğunuzdan Emin Olun!", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else//Hepsi Doluysa İşleme devam Et
                    {
                        //eğer odadak yatak sayısı kalacak kişi sayısından daha azsa uyarmalı ve teslim etme işlemini engellemeliyim
                        if (odaKapasite < Convert.ToInt32(txtkisisayisi.Text))
                        {
                            MessageBox.Show("Odanın Kapasitesi Aşıldı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            seciliOdaNumarasi = Convert.ToInt32(txtodano.Text);
                            DateTime girisTarihi = girist.Value;
                            DateTime cikisTarihi = cikist.Value;
                            if (cikisTarihi >= girisTarihi)
                            {
                                baglanti.Open();
                                // Müşteri bilgilerini kaydetmek için SQL komutu
                                string sql = "INSERT INTO Musteri (ad, soyad, telefon, email, cinsiyet, adres, ulus, vatandaslık, uyelikdurumu, cocuksayisi, kisisayisi, istekler, tc, durumu, girist, cıkıst, kaldıgıoda) " +
                                "VALUES (@ad, @soyad, @telefon, @email, @cinsiyet, @adres, @ulus, @vatandaslik, @uyelikdurumu, @cocuksayisi, @kisisayisi, @istekler, @tc, @durumu, @girist, @cıkıst, @kaldıgıoda)";
                                SqlCommand komut = new SqlCommand(sql, baglanti);

                                komut.Parameters.AddWithValue("@ad", txtad.Text);
                                komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                                komut.Parameters.AddWithValue("@email", txtmail.Text);
                                komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                                komut.Parameters.AddWithValue("@adres", txtadres.Text);
                                komut.Parameters.AddWithValue("@ulus", txtulus.Text);
                                komut.Parameters.AddWithValue("@vatandaslik", txtvatandaslık.Text);
                                komut.Parameters.AddWithValue("@uyelikdurumu", comboüyelik.SelectedItem.ToString());
                                komut.Parameters.AddWithValue("@cocuksayisi", Convert.ToInt32(txtcocuksayisi.Text));
                                komut.Parameters.AddWithValue("@kisisayisi", Convert.ToInt32(txtkisisayisi.Text));
                                komut.Parameters.AddWithValue("@istekler", txtistekler.Text);
                                komut.Parameters.AddWithValue("@tc", txttc.Text);
                                komut.Parameters.AddWithValue("@durumu", "Gelecek");
                                komut.Parameters.AddWithValue("@girist", DateTime.Parse(girist.Text));
                                komut.Parameters.AddWithValue("@cıkıst", DateTime.Parse(cikist.Text));
                                komut.Parameters.AddWithValue("@kaldıgıoda", txtodano.Text);
                                komut.ExecuteNonQuery();

                                // Oda durumunu Rezerveye çevirme

                                SqlCommand odaKomut = new SqlCommand("UPDATE Oda2 SET durumu = @durumu WHERE odaID = @odaID", baglanti);
                                odaKomut.Parameters.AddWithValue("@odaID", seciliOdaNumarasi);///1 nolu odaya bakıyor
                                odaKomut.Parameters.AddWithValue("@durumu", "Rezerve");
                                odaKomut.ExecuteNonQuery();
                                baglanti.Close();
                                //müşteriyle beraber müşterinin refatkatçısınında durumunu gelecek olarak ayarlayıp gerektiği yerlerde güncelle
                                baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("update Refakatcı set durumu=@durumu where musteritc=@musteritc", baglanti);
                                komut2.Parameters.AddWithValue("@durumu", "Gelecek");
                                komut2.Parameters.AddWithValue("@musteritc", txttc.Text);
                                komut2.ExecuteNonQuery();
                                baglanti.Close();

                                MessageBox.Show("Rezervasyon kaydı başarıyla eklendi ve Oda durumu da güncellendi.");
                                Temizle();
                            }
                            else
                            {
                                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra veya aynı gün olmalıdır. Lütfen geçerli bir çıkış tarihi seçin.");
                                return;
                            }
                            this.Close();
                            eskiGirisTarihi = girisTarihi;
                            eskiCikisTarihi = cikisTarihi;
                            Odalar odalaragit = new Odalar();
                            odalaragit.ShowDialog();
                        }
                    }
              }
           }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Temizlik İşlemini Gerçekleştirmek İsterdiğinize Emin Misiniz", "Onay İsteği", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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
                girist.Text = "";
                cikist.Text = "";
                txtistekler.Text = "";
                girist.Text = "";
                cikist.Text = "";
                ekran.Visible = false;
            }
            else
            {
                MessageBox.Show("Temizleme İşlemi İptal Edildi");
            }
        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {
            ekran.Visible=false;
        }

        private void ekran2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtodano.Text = ekran2.CurrentRow.Cells["odaID"].Value.ToString();
            txtyataksayisi.Text = ekran2.CurrentRow.Cells["yataksayisi"].Value.ToString();
            txtkat.Text = ekran2.CurrentRow.Cells["odakat"].Value.ToString();
            comboodadurumu.Text = ekran2.CurrentRow.Cells["durumu"].Value.ToString();
            txtucret.Text = ekran2.CurrentRow.Cells["ucret"].Value.ToString();
            İhtiyacdurumu.Text = ekran2.CurrentRow.Cells["ihtiyac"].Value.ToString();
            odaozelligi.Text = ekran2.CurrentRow.Cells["odaozelligi"].Value.ToString();
            odaKapasite=Convert.ToInt32( txtyataksayisi.Text);
        }

        private void yataksara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select odaID,yataksayisi,odakat,durumu,ucret,ihtiyac,odaozelligi from Oda2 where yataksayisi like '%" + yataksara.Text + "%' And durumu='Boş'", baglanti);
            adtr.Fill(tablo);
            ekran2.DataSource = tablo;
            baglanti.Close();
        }

        private void refakatcıekle_Click(object sender, EventArgs e)
        {
            refakatcıekleme refakatekle=new refakatcıekleme();
            string musteritc = txttc.Text;
            string kaldıgıoda= txtodano.Text;
            refakatekle.veriaktar(musteritc, kaldıgıoda);
            refakatekle.ShowDialog();
        }

        bool boskontrol = false;
        public void BosBilgi_Kontrol()//bu kısımdada null ise yazmışım
        {
            if (txtad.Text == "" || txtsoyad.Text == "" || txttelefon.Text == "" || txtmail.Text == "" || txttc.Text == "" || combocinsiyet.Text == "" || txtulus.Text == "" || txtvatandaslık.Text == "" ||
                comboüyelik.Text == "" || txtkisisayisi.Text == "" || txtcocuksayisi.Text == "")
            {
                boskontrol = false;
            }
            else
            {
                boskontrol = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            musteridrmKontrol();
            if(durum==true) 
            {
                BosBilgi_Kontrol();
                if (boskontrol == true)
                {
                    MessageBox.Show("Müşteri ile İlgili Tüm Alanları Doldurduğunuzdan Emin Olun!", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO Musteri(tc, ad, soyad, telefon, email, cinsiyet, adres, ulus, vatandaslık, uyelikdurumu, cocuksayisi, kisisayisi,durumu,istekler)" +
                    " Values(@tc, @ad, @soyad, @telefon, @email, @cinsiyet, @adres, @ulus, @vatandaslık, @uyelikdurumu, @cocuksayisi, @kisisayisi, @istekler)", baglanti);
                    // Parametreler
                    komut.Parameters.AddWithValue("@ad", txtad.Text);
                    komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                    komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                    komut.Parameters.AddWithValue("@email", txtmail.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                    komut.Parameters.AddWithValue("@adres", txtadres.Text);
                    komut.Parameters.AddWithValue("@ulus", txtulus.Text);
                    komut.Parameters.AddWithValue("@vatandaslık", txtvatandaslık.Text);
                    komut.Parameters.AddWithValue("@uyelikdurumu", comboüyelik.Text);
                    komut.Parameters.AddWithValue("@cocuksayisi", txtcocuksayisi.Text);
                    komut.Parameters.AddWithValue("@kisisayisi", Convert.ToInt32(txtkisisayisi.Text));
                    komut.Parameters.AddWithValue("@istekler", txtistekler.Text);
                    komut.Parameters.AddWithValue("@tc", txttc.Text);
                    komut.Parameters.AddWithValue("@girişt", girist.Text);
                    komut.Parameters.AddWithValue("@durumu", "Boş");
                    komut.Parameters.AddWithValue("@kaldıgıoda", txtodano.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Etme İşlemi Başarılı");
                    baglanti.Close();
                }
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