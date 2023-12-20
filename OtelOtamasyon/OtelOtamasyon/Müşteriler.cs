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
    public partial class Müşteriler : Form
    {
        public Müşteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();
        
        public void Kayıt_Göster()//Müşteri Tablosundaki Kayıtları Tabloya Yeni Başlıklarıyla Ekleme
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri", baglanti);
            adtr.Fill(daset, "Musteri");
            ekran.DataSource = daset.Tables["Musteri"];
            ekran.Columns[0].HeaderText = "MusteriID";
            ekran.Columns[1].HeaderText = "ad ";
            ekran.Columns[2].HeaderText = "soyad";
            ekran.Columns[3].HeaderText = "telefon";
            ekran.Columns[4].HeaderText = "email";
            ekran.Columns[5].HeaderText = "cinsiyet";
            ekran.Columns[6].HeaderText = "adres";
            ekran.Columns[7].HeaderText = "ulus";
            ekran.Columns[8].HeaderText = "vatandaslık";
            ekran.Columns[9].HeaderText = "uyelikdurumu";
            ekran.Columns[10].HeaderText = "cocuksayisi";
            ekran.Columns[11].HeaderText = "kisisayisi";
            ekran.Columns[12].HeaderText = "durumu";
            ekran.Columns[13].HeaderText = "tc";
            ekran.Columns[14].HeaderText = "istekler";
            ekran.Columns[15].HeaderText = "girist";
            ekran.Columns[16].HeaderText = "cıkıst";
            ekran.Columns[17].HeaderText = "kaldıgıoda";
            baglanti.Close();
        }
       
         string musteriID = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//Ekrana 2 kez Tıklandığında Müşterinin Bilgilerini ilgili alanlara yazar
        {
            musteriID= ekran.CurrentRow.Cells["MusteriID"].Value.ToString();
            txtad.Text = ekran.CurrentRow.Cells["ad"].Value.ToString();
            txtsoyad.Text = ekran.CurrentRow.Cells["soyad"].Value.ToString();
            txttelefon.Text = ekran.CurrentRow.Cells["telefon"].Value.ToString();
            txtmail.Text = ekran.CurrentRow.Cells["email"].Value.ToString();
            combocinsiyet.Text = ekran.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtadres.Text = ekran.CurrentRow.Cells["adres"].Value.ToString();
            txttc.Text = ekran.CurrentRow.Cells["tc"].Value.ToString();
            txtulus.Text = ekran.CurrentRow.Cells["ulus"].Value.ToString();
            txtvatandaslık.Text = ekran.CurrentRow.Cells["vatandaslık"].Value.ToString();
            comboüyelik.Text = ekran.CurrentRow.Cells["uyelikdurumu"].Value.ToString();
            txtcocuks.Text = ekran.CurrentRow.Cells["cocuksayisi"].Value.ToString();
            txtkisis.Text = ekran.CurrentRow.Cells["kisisayisi"].Value.ToString();
            combodurumu.Text = ekran.CurrentRow.Cells["durumu"].Value.ToString();
            txtistek.Text = ekran.CurrentRow.Cells["istekler"].Value.ToString();
            girist.Text = ekran.CurrentRow.Cells["girist"].Value.ToString();
            cikist.Text = ekran.CurrentRow.Cells["cıkıst"].Value.ToString();
            txtkaldıgıoda.Text = ekran.CurrentRow.Cells["kaldıgıoda"].Value.ToString();
            hiddenId.Text = musteriID;
        }

        private void Müşteriler_Load(object sender, EventArgs e)
        {
            // Tarihlerin formatlarını  ayarladığım kısım
            girist.Format = DateTimePickerFormat.Custom;
            girist.CustomFormat = "dd/MM/yyyy HH:mm";

            cikist.Format = DateTimePickerFormat.Custom;
            cikist.CustomFormat = "dd/MM/yyyy HH:mm";

            Kayıt_Göster();
            hiddenId.Text =0.ToString();
        }
        bool tckontrol = true;
        public void TC_Kontrol()//Tcyi Kontrol edip var Olan tc ile yeni bir kayıt eklenmesini engeller
        {
            tckontrol = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Musteri", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                if (txttc.Text == reader["tc"].ToString())
                {
                    tckontrol = false;
                    MessageBox.Show("Böyle Bir Müşteri Zaten Var", "Uyarı");
                }
                else
                {
                    tckontrol = true;
                }
            }
            baglanti.Close();
        }

        bool boskontrol = false;
        public void BosBilgi_Kontrol()
        {
            if (txtad.Text == "" || txtsoyad.Text == "" || txttelefon.Text == "" || txtmail.Text == "" || txttc.Text == "" || combocinsiyet.Text == "" || txtulus.Text == "" || txtvatandaslık.Text == "" ||
                comboüyelik.Text == "" || txtkisis.Text== "" || txtcocuks.Text == "")
            {
                boskontrol = true;
            }
            else
            {
                boskontrol = false;
            }
        }
        private void btnekle_Click(object sender, EventArgs e)//Yeni Adı kaydet Duruma Göre Kayıt veya Güncelleme İşlemlerini gerçekleştiriyor
        {
            //Tüm Texboxların dolu olduğundan emin olurum
            BosBilgi_Kontrol();
            if (boskontrol==true)
            {
                MessageBox.Show("Müşteri ile İlgili Tüm Alanları Doldurduğunuzdan Emin Olun!","Uyarı!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else//Hepsi Doluysa İşleme devam Et
            {
                //müşteri ilk kez ekleneceği için mevcutta bir ıdsi olmayacak 
                if (int.Parse(hiddenId.Text) == 0)//Gizli bir Texboxım var
                {

                    TC_Kontrol();
                    if (tckontrol == true)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("insert into Musteri(ad,soyad,telefon,email,cinsiyet,adres,ulus,vatandaslık,uyelikdurumu,cocuksayisi,kisisayisi,durumu,tc,istekler,girist,cıkıst," +
                        "kaldıgıoda)Values(@ad,@soyad,@telefon,@email,@cinsiyet,@adres,@ulus,@vatandaslık,@uyelikdurumu,@cocuksayisi,@kisisayisi,@durumu,@tc,@istekler,@girist,@cıkıst,@kaldıgıoda)", baglanti);
                        komut.Parameters.AddWithValue("ad", txtad.Text);
                        komut.Parameters.AddWithValue("soyad", txtsoyad.Text);
                        komut.Parameters.AddWithValue("telefon", txttelefon.Text);
                        komut.Parameters.AddWithValue("email", txtmail.Text);
                        komut.Parameters.AddWithValue("cinsiyet", combocinsiyet.Text);
                        komut.Parameters.AddWithValue("adres", txtadres.Text);
                        komut.Parameters.AddWithValue("ulus", txtulus.Text);
                        komut.Parameters.AddWithValue("vatandaslık", txtvatandaslık.Text);
                        komut.Parameters.AddWithValue("uyelikdurumu", comboüyelik.Text);
                        komut.Parameters.AddWithValue("cocuksayisi", txtcocuks.Text);
                        komut.Parameters.AddWithValue("kisisayisi", txtkisis.Text);
                        komut.Parameters.AddWithValue("durumu", combodurumu.Text);
                        komut.Parameters.AddWithValue("tc", txttc.Text);
                        komut.Parameters.AddWithValue("istekler", txtistek.Text);
                        komut.Parameters.AddWithValue("girist", DateTime.Parse(girist.Text));
                        komut.Parameters.AddWithValue("cıkıst", DateTime.Parse(cikist.Text));
                        komut.Parameters.AddWithValue("kaldıgıoda", txtkaldıgıoda.Text);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Etme İşlemi Başarılı");
                        baglanti.Close();
                    }
                }
                else if (hiddenId.Text == musteriID)//Müşteri Daha Önceden Kayıtlı ise Ekrana 2 kez tıklandığında Gizli Texboxa IDsi yazılacak ve eğer buraya ID Gelirse Bu kısım Çalışacak
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("Update Musteri set  ad=@ad,soyad=@soyad,telefon=@telefon,email=@email,cinsiyet=@cinsiyet,adres=@adres,ulus=@ulus,vatandaslık=@vatandaslık," +
                    "uyelikdurumu=@uyelikdurumu,cocuksayisi=@cocuksayisi,kisisayisi=@kisisayisi,durumu=@durumu,tc=@tc,istekler=@istekler,girist=@girist,cıkıst=@cıkıst,kaldıgıoda=@kaldıgıoda where " +
                    "MusteriID=@MusteriID", baglanti);
                    komut.Parameters.AddWithValue("@MusteriID", hiddenId.Text);
                    komut.Parameters.AddWithValue("ad", txtad.Text);
                    komut.Parameters.AddWithValue("soyad", txtsoyad.Text);
                    komut.Parameters.AddWithValue("telefon", txttelefon.Text);
                    komut.Parameters.AddWithValue("email", txtmail.Text);
                    komut.Parameters.AddWithValue("cinsiyet", combocinsiyet.Text);
                    komut.Parameters.AddWithValue("adres", txtadres.Text);
                    komut.Parameters.AddWithValue("ulus", txtulus.Text);
                    komut.Parameters.AddWithValue("vatandaslık", txtvatandaslık.Text);
                    komut.Parameters.AddWithValue("uyelikdurumu", comboüyelik.Text);
                    komut.Parameters.AddWithValue("cocuksayisi", txtcocuks.Text);
                    komut.Parameters.AddWithValue("kisisayisi", txtkisis.Text);
                    komut.Parameters.AddWithValue("durumu", combodurumu.Text);
                    komut.Parameters.AddWithValue("tc", txttc.Text);
                    komut.Parameters.AddWithValue("istekler", txtistek.Text);
                    komut.Parameters.AddWithValue("girist", DateTime.Parse(girist.Text));
                    komut.Parameters.AddWithValue("cıkıst", DateTime.Parse(cikist.Text));
                    komut.Parameters.AddWithValue("kaldıgıoda", txtkaldıgıoda.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                    baglanti.Close();
                }
                //Tabloyu Güncellediğim Kısım
                Kayıt_Getir();
                //Gerekli Temizliklerin yapıldığı Kısım
                Temizle();
            }
        }
        public void Kayıt_Getir()
        {
            SqlCommand komut2 = new SqlCommand("select * from Musteri", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ekran.DataSource = dt;
        }
        private void tarihara_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = tarihara.Value.Date;
            DataView dv = daset.Tables["Musteri"].DefaultView;
            dv.RowFilter = $"girist >= #{selectedDate.ToString("MM/dd/yyyy")}# AND girist < #{selectedDate.AddDays(1).ToString("MM/dd/yyyy")}#";
            ekran.DataSource = dv;
        }
        private void TumKayitlariGoster()
        {
            DataView dv = daset.Tables["Musteri"].DefaultView;
            dv.RowFilter = "";
            ekran.DataSource = dv;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           TumKayitlariGoster();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Silmek için Onay Aldıktan sonra vtden Müşteri ve Refakatçısını Silme İşlemi
            DialogResult result=MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Musteri where MusteriID='" + hiddenId.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["Musteri"].Clear();
                Kayıt_Göster();
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("delete from Refakatcı where musteritc='" + hiddenId.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Müşteri Kaydıyla Berabar Refakatçılarda Silindi");
                Temizle();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Silme İşlemi İptal Edildi");
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
                if (item is DateTimePicker)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//Temizle Butonu
        {
            Temizle();
            hiddenId.Text = 0.ToString();
        }
    
        private void durumara_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                if (durumara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (durumara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri where durumu='Kalıyor'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (durumara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri where durumu='Gelecek'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (durumara.SelectedIndex == 3)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri where durumu='Gitti'", baglanti);
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
            baglanti.Close();
        }

        private void uyelikara_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                if (uyelikara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (uyelikara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri where uyelikdurumu='Var'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (uyelikara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Musteri where uyelikdurumu='Yok'", baglanti);
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
            baglanti.Close();
        }

        private void txttcara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Musteri where tc like '%" + txttcara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void odaara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Oda2 where odaID like '%" + odaara.Text + "%'", baglanti);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
