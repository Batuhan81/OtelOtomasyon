using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OtelOtamasyon
{
    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");

       
        int sonButonID;
        String secilenkat = 1.ToString();

        List<Button> addedButtons = new List<Button>();

        bool secimdurumu = true;//kat seçilmemişse işlem yapma
        private void OdaEkle_Click(object sender, EventArgs e)
        {
            if (comboKat.Text == null)
            {
                secimdurumu = false;
            }
            if (secimdurumu == true)
            {  //butona tıklandığımda dinamik olarak odaları temsil eden butonları oluşturma ve gerekli özelliklerin atanması
                baglanti.Open();
                if (secimdurumu == true)
                {
                    OdaBilgileriGir odabilgileri = new OdaBilgileriGir();
                    odabilgileri.ShowDialog();
                    if (odabilgileri.EkleButonunaTiklandi) // Eğer form işlemi tamamlandıysa
                    {
                        //maxIdyi alma
                        //Oda2 tablosundaki en yüksek deeri aldım
                        SqlCommand maxodaIDKomut = new SqlCommand("SELECT ISNULL(MAX(odaID), 0) FROM Oda2", baglanti);
                        sonButonID = (int)maxodaIDKomut.ExecuteScalar();
                        baglanti.Close();
                        int yeniodaId = sonButonID;

                        baglanti.Open();
                        
                        Button btn = new Button();
                        btn.Text = yeniodaId.ToString();
                        btn.Name = yeniodaId.ToString();
                        btn.Size = new Size(150, 150);
                        Renk_Degistir(btn);
                        btn.Click += Yonlendir;
                        btn.ContextMenuStrip = OdaButtonClick();

                        SqlCommand komut2 = new SqlCommand("update Oda2 set odakat=@odakat where odaID=@odaID", baglanti);//emin değilim silinebilir
                        komut2.Parameters.AddWithValue("@odakat", secilenkat);
                        komut2.Parameters.AddWithValue("@odaID", yeniodaId);
                        komut2.ExecuteNonQuery();
                      
                        addedButtons.Add(btn);
                        PanelOdalar.Controls.Add(btn);
                        baglanti.Close();
                        sonButonID = yeniodaId;//burada enson eklediğimiz odayı son butonIdsine veriyoruz. }
                    }
                    else
                    {
                        // Eğer form işlemi iptal edildiyse, bir mesaj gösterebilirsiniz.
                        MessageBox.Show("Oda ekleme işlemi iptal edildi.");
                    }
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Önce Kat Seçiniz");
            }
        }

        private void Yonlendir(object sender, EventArgs e)//odanın durumuna göre gerekli yerlere yönlendirilme işlemi
        {
            Button button = (Button)sender;
            using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
            {
                this.Close();
                baglanti.Open();
                Sınıf1 sınıf = new Sınıf1();
                Sınıf2 sınıf2 = new Sınıf2();
                Sınıf3 sınıf3 = new Sınıf3();
                OdabilgileriniGetir getir = new OdabilgileriniGetir(sınıf, sınıf2);
                using (SqlCommand durumSorgusu = new SqlCommand("SELECT durumu FROM Oda2 WHERE odaID = @odaID", baglanti))
                {
                    //odanın durumu Kontrol ediliyor.
                    durumSorgusu.Parameters.AddWithValue("@odaID", button.Name.ToString());
                    object odaDurumuObj = durumSorgusu.ExecuteScalar();
                    if (odaDurumuObj != null)
                    {
                        string odaDurumu = odaDurumuObj.ToString();
                        if (odaDurumu == "Dolu")//oda durumu doluysa Müşteri Bilgilerini  Odabilgilerinigetir formuna gönder
                        {
                            button.BackColor = Color.Red;
                            SqlCommand Odabilgisi = new SqlCommand("SELECT * FROM Oda2 WHERE OdaID = @odaID ", baglanti);
                            Odabilgisi.Parameters.AddWithValue("@odaID", button.Name.ToString());
                            using (SqlDataReader odaReader = Odabilgisi.ExecuteReader())
                            {
                                if (odaReader.Read())//oda  bilgilerini oku ve oda bilgilerini sınıf2 ye yükle
                                {
                                    sınıf2.odaAdi = odaReader["odaID"].ToString();
                                    sınıf2.odaKapasite = odaReader["yataksayisi"].ToString();
                                    sınıf2.odakatı = odaReader["odakat"].ToString();
                                    sınıf2.odaDurum = odaReader["durumu"].ToString();
                                    sınıf2.ucret = odaReader["ucret"].ToString();
                                    sınıf2.ihtiyac = odaReader["ihtiyac"].ToString();
                                    sınıf2.odaozelligi = odaReader["odaozelligi"].ToString();
                                }
                                odaReader.Close();
                            }
                            //buraya sonra bakmam gerekebilir
                            //veriyi getirirken Kaldığı odaya bakıyor ve durumuna bakıyor
                            SqlCommand musteriSorgusu = new SqlCommand("SELECT * FROM Musteri WHERE kaldıgıoda = @kaldıgıoda AND durumu=@durumu ", baglanti);
                            musteriSorgusu.Parameters.AddWithValue("@kaldıgıoda", button.Name.ToString());
                            musteriSorgusu.Parameters.AddWithValue("@durumu", "Kalıyor");
                            using (SqlDataReader Reader = musteriSorgusu.ExecuteReader())
                            {
                                if (Reader.Read())//Müşteri Bilgielrini Oku ve sınıfa kaydet
                                {
                                    sınıf.MusteriID = Reader["MusteriID"].ToString();
                                    sınıf.musteriAd = Reader["ad"].ToString();
                                    sınıf.musteriSoyad = Reader["soyad"].ToString();
                                    sınıf.musteriTelefon = Reader["telefon"].ToString();
                                    sınıf.musteriEmail = Reader["email"].ToString();
                                    sınıf.mustericinsiyet = Reader["cinsiyet"].ToString();
                                    sınıf.musteriadres = Reader["adres"].ToString();
                                    sınıf.musteriulus = Reader["ulus"].ToString();
                                    sınıf.musterivatandaslık = Reader["vatandaslık"].ToString();
                                    sınıf.musteriuyelikdurumu = Reader["uyelikdurumu"].ToString();
                                    sınıf.mustericocuksaiyisi = Reader["cocuksayisi"].ToString();
                                    sınıf.musterikisisayisi = Reader["kisisayisi"].ToString();
                                    sınıf.musteritc = Reader["tc"].ToString();
                                    sınıf.musteriistekler = Reader["istekler"].ToString();
                                    sınıf.musterigirist = Reader["girist"].ToString();
                                    sınıf.mustericikist = Reader["cıkıst"].ToString();
                                    sınıf.musterikaldıgıoda = Reader["kaldıgıoda"].ToString();

                                    getir = new OdabilgileriniGetir(sınıf, sınıf2);
                                    getir.ShowDialog();
                                }
                                else//Muhtemel sebebi tablodaki Idlerin sırası karıştı.
                                //Sebebini buldum aynı müşteriyi başka bir odaya kayıt edersem müşterinin kaldığı oda güncelleniyordu fakat eski oda dolu kalıyordu aynı tcleri engelleyerek çözdüm
                                {
                                    MessageBox.Show("Okuma İşlemi Yapılamadı");
                                }
                                Odalar odalaragit=new Odalar();
                                odalaragit.ShowDialog();
                            }
                        }
                        else if (odaDurumu == "Boş")
                        {
                            OdaTeslim teslim = new OdaTeslim(button.Name, sınıf3);
                            button.BackColor = Color.Green;
                            SqlCommand Odabilgisi = new SqlCommand("SELECT * FROM Oda2 WHERE OdaID = @odaID ", baglanti);
                            Odabilgisi.Parameters.AddWithValue("@odaID", button.Name.ToString());
                            using (SqlDataReader odaReader = Odabilgisi.ExecuteReader())
                            {
                                if (odaReader.Read())//oda  bilgilerini oku ve oda bilgilerini sınıf3 ye yükle
                                {
                                    sınıf3.odaAdi = odaReader["odaID"].ToString();
                                    sınıf3.odaKapasite = odaReader["yataksayisi"].ToString();
                                    sınıf3.odakatı = odaReader["odakat"].ToString();
                                    sınıf3.odaDurum = odaReader["durumu"].ToString();
                                    sınıf3.ucret = odaReader["ucret"].ToString();
                                    sınıf3.ihtiyac = odaReader["ihtiyac"].ToString();
                                    sınıf3.odaozelligi = odaReader["odaozelligi"].ToString();
                                }
                                odaReader.Close();
                            }
                            teslim = new OdaTeslim(button.Name, sınıf3);
                            teslim.ShowDialog();

                        }
                        else if (odaDurumu == "Servis Dışı")
                        {
                            OdaTeslim teslim = new OdaTeslim(button.Name, sınıf3);
                            button.BackColor = Color.Gray;
                            SqlCommand Odabilgisi = new SqlCommand("SELECT * FROM Oda2 WHERE OdaID = @odaID ", baglanti);
                            Odabilgisi.Parameters.AddWithValue("@odaID", button.Name);
                            using (SqlDataReader odaReader = Odabilgisi.ExecuteReader())
                            {
                                if (odaReader.Read())//oda  bilgilerini oku ve oda bilgilerini sınıf3 ye yükle
                                {
                                    sınıf3.odaAdi = odaReader["odaID"].ToString();
                                    sınıf3.odaKapasite = odaReader["yataksayisi"].ToString();
                                    sınıf3.odakatı = odaReader["odakat"].ToString();
                                    sınıf3.odaDurum = odaReader["durumu"].ToString();
                                    sınıf3.ucret = odaReader["ucret"].ToString();
                                    sınıf3.ihtiyac = odaReader["ihtiyac"].ToString();
                                    sınıf3.odaozelligi = odaReader["odaozelligi"].ToString();
                                }
                                odaReader.Close();
                            }
                            teslim = new OdaTeslim(button.Name, sınıf3);
                            teslim.ShowDialog();
                            Odalar odalargetir = new Odalar();
                            odalargetir.ShowDialog();

                        }
                        else if (odaDurumu == "Rezerve")
                        {
                            button.BackColor = Color.Yellow;
                            SqlCommand Odabilgisi = new SqlCommand("SELECT * FROM Oda2 WHERE OdaID = @odaID ", baglanti);
                            Odabilgisi.Parameters.AddWithValue("@odaID", button.Name.ToString());
                            using (SqlDataReader odaReader = Odabilgisi.ExecuteReader())
                            {
                                if (odaReader.Read())//oda  bilgilerini oku ve oda bilgilerini sınıf2 ye yükle
                                {
                                    sınıf2.odaAdi = odaReader["odaID"].ToString();
                                    sınıf2.odaKapasite = odaReader["yataksayisi"].ToString();
                                    sınıf2.odakatı = odaReader["odakat"].ToString();
                                    sınıf2.odaDurum = odaReader["durumu"].ToString();
                                    sınıf2.ucret = odaReader["ucret"].ToString();
                                    sınıf2.ihtiyac = odaReader["ihtiyac"].ToString();
                                    sınıf2.odaozelligi = odaReader["odaozelligi"].ToString();
                                }
                                odaReader.Close();
                            }
                            //buraya sonra bakmam gerekebilir
                            //veriyi getirirken Kaldığı odaya bakıyor ve durumuna bakıyor
                            SqlCommand musteriSorgusu = new SqlCommand("SELECT * FROM Musteri WHERE kaldıgıoda = @kaldıgıoda AND durumu=@durumu ", baglanti);
                            musteriSorgusu.Parameters.AddWithValue("@kaldıgıoda", button.Name);
                            musteriSorgusu.Parameters.AddWithValue("@durumu", "Gelecek");
                            using (SqlDataReader Reader = musteriSorgusu.ExecuteReader())
                            {
                                if (Reader.Read())//Müşteri Bilgielrini Oku ve sınıfa kaydet
                                {
                                    sınıf.MusteriID = Reader["MusteriID"].ToString();
                                    sınıf.musteriAd = Reader["ad"].ToString();
                                    sınıf.musteriSoyad = Reader["soyad"].ToString();
                                    sınıf.musteriTelefon = Reader["telefon"].ToString();
                                    sınıf.musteriEmail = Reader["email"].ToString();
                                    sınıf.mustericinsiyet = Reader["cinsiyet"].ToString();
                                    sınıf.musteriadres = Reader["adres"].ToString();
                                    sınıf.musteriulus = Reader["ulus"].ToString();
                                    sınıf.musterivatandaslık = Reader["vatandaslık"].ToString();
                                    sınıf.musteriuyelikdurumu = Reader["uyelikdurumu"].ToString();
                                    sınıf.mustericocuksaiyisi = Reader["cocuksayisi"].ToString();
                                    sınıf.musterikisisayisi = Reader["kisisayisi"].ToString();
                                    sınıf.musteritc = Reader["tc"].ToString();
                                    sınıf.musteriistekler = Reader["istekler"].ToString();
                                    sınıf.musterigirist = Reader["girist"].ToString();
                                    sınıf.mustericikist = Reader["cıkıst"].ToString();
                                    sınıf.musterikaldıgıoda = Reader["kaldıgıoda"].ToString();
                                    getir = new OdabilgileriniGetir(sınıf, sınıf2);
                                    getir.ShowDialog();

                                }
                                else//Muhtemel sebebi tablodaki Idlerin sırası karıştı.
                                {
                                    MessageBox.Show("Okuma İşelemi Yapılamadı");
                                }
                                Odalar odalargetir=new Odalar();
                                odalargetir.ShowDialog();
                            }
                        }
                    }
                    else if (odaDurumuObj == null)
                    {

                        OdaTeslim teslim = new OdaTeslim(button.Name, sınıf3);
                        SqlCommand Odabilgisi = new SqlCommand("SELECT * FROM Oda2 WHERE OdaID = @odaID ", baglanti);
                        Odabilgisi.Parameters.AddWithValue("@odaID", button.Name.ToString());
                        using (SqlDataReader odaReader = Odabilgisi.ExecuteReader())
                        {
                            if (odaReader.Read())//oda  bilgilerini oku ve oda bilgilerini sınıf2 ye yükle
                            {
                                sınıf3.odaAdi = odaReader["odaID"].ToString();
                                sınıf3.odaKapasite = odaReader["yataksayisi"].ToString();
                                sınıf3.odakatı = odaReader["odakat"].ToString();
                                sınıf3.odaDurum = odaReader["durumu"].ToString();
                                sınıf3.ucret = odaReader["ucret"].ToString();
                                sınıf3.ihtiyac = odaReader["ihtiyac"].ToString();
                                sınıf3.odaozelligi = odaReader["odaozelligi"].ToString();
                            }
                        }
                        teslim = new OdaTeslim(button.Name, sınıf3);
                        teslim.ShowDialog();
                        baglanti.Close();
                    }
                }
            }
            this.Close();
            ContextMenuStrip contextMenu = button.ContextMenuStrip;
        }

        private ContextMenuStrip OdaButtonClick()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem güncelle = new ToolStripMenuItem("Güncelle");
            güncelle.Click += Guncelle_Click; // güncelle_Click metoduna tıklama olayını atayın
            menu.Items.Add(güncelle);

            ToolStripMenuItem sil = new ToolStripMenuItem("Sil");
            sil.Click += sil_Click;
            menu.Items.Add(sil);
            return menu;
        }
        private void sil_Click(object sender, EventArgs e)
        {
            //Butona Sağ tıklayarak açılan menüden butonu silme
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenu = (ContextMenuStrip)menuItem.Owner;
            Button secilenButon = (Button)contextMenu.SourceControl;
            string secilenOda = secilenButon.Name;

            baglanti.Open();
            SqlCommand silkomut = new SqlCommand("delete  From Oda2 Where odaID=@odaID ", baglanti);
            silkomut.Parameters.AddWithValue("@odaID", secilenOda);
            silkomut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand silindi = new SqlCommand("update  Oda2 set durumu='Silindi' where odaID=@odaID", baglanti);
            silindi.Parameters.AddWithValue("@odaID", secilenOda);
            silindi.ExecuteNonQuery();
            baglanti.Close();

            PanelOdalar.Controls.Remove(secilenButon);
            MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşti");
        }
        private void Guncelle_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenu = (ContextMenuStrip)menuItem.Owner;
            Button secilenButon = (Button)contextMenu.SourceControl;
            string odaAdi = secilenButon.Name;
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Oda2 where odaID=@odaID", baglanti);
            komut.Parameters.AddWithValue("@odaID", odaAdi);
            komut.ExecuteNonQuery();
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                string yataks = reader["yataksayisi"].ToString();
                string odakat = reader["odakat"].ToString();
                string durumu = reader["durumu"].ToString();
                int ucret = Convert.ToInt32(reader["ucret"]);
                string ihtiyac = reader["ihtiyac"].ToString();
                string odaozelligi = reader["odaozelligi"].ToString();
                baglanti.Close();

                OdaBilgiGüncelle güncelle = new OdaBilgiGüncelle();
                güncelle.Verileriaktar(odaAdi, yataks, odakat, durumu, ucret, ihtiyac, odaozelligi);
                güncelle.ShowDialog();
            }
        }
        private void Odalar_Load(object sender, EventArgs e)
        {
            //Katları ComboKat kısmına load olayında yükleme
            ComboKatı_Doldur();
              comboKat.SelectedIndex = 0;
        }
     
        private void btnKatEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            //İdentity özelliğiyle Kat ekledik ve otomatikmen kimlik oluşturuyor
            SqlCommand komut = new SqlCommand("INSERT INTO Katlar (katbiligisi) VALUES ('Yeni Kat'); SELECT SCOPE_IDENTITY();", baglanti);
            int yeniKatId = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            ComboKatı_Doldur();
            MessageBox.Show("Kat Ekleme İşlemi Başarılı");
        }
        int odaID = 0;
        private void comboKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKat.SelectedItem != null)
            {
                secilenkat = comboKat.SelectedItem.ToString();
                PanelOdalar.Controls.Clear();
                using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
                {
                    baglanti.Open();
                    SqlCommand odakomut = new SqlCommand("select odaID from Oda2 Where odakat=@odakat", baglanti);
                    odakomut.Parameters.AddWithValue("@odakat", secilenkat);
                    List<int> Odalistesi = new List<int>();
                    using (SqlDataReader Odaıdoku = odakomut.ExecuteReader())
                    {
                        while (Odaıdoku.Read())
                        {
                            odaID = Odaıdoku.GetInt32(0);
                            Odalistesi.Add(odaID);
                            // Odaıdoku nesnesini burada kullanabilirsiniz
                        }
                        Odaıdoku.Close();
                        foreach (int odaID in Odalistesi)
                        {
                            SqlCommand odakomut2 = new SqlCommand("select * from Oda2 where odaID=@odaID", baglanti);
                            odakomut2.Parameters.AddWithValue("@odaID", odaID);
                            using (SqlDataReader odaReader = odakomut2.ExecuteReader())
                            {
                                while (odaReader.Read())
                                {
                                    Button btn = new Button();
                                    int btnAdi = odaReader.GetInt32(0);
                                    btn.Text = btnAdi.ToString();
                                    btn.Name = btnAdi.ToString();
                                    btn.Size = new Size(150, 150);
                                    Renk_Degistir(btn);
                                    btn.Click += Yonlendir;
                                    PanelOdalar.Controls.Add(btn);
                                    btn.ContextMenuStrip = OdaButtonClick();//sağtıklanabilirlik özelliği
                                }
                                odaReader.Close();
                            }
                        }
                    }
                }
            }
        }

        private void btnKatSil_Click(object sender, EventArgs e)
        {
            //Seçili katı siliyor
            if (comboKat.SelectedItem != null)
            {
                string secilenKat = comboKat.SelectedItem.ToString();
                DialogResult result = MessageBox.Show("Seçilen Katı Silmek İstediğinizee Emin Misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Katı silme İşlemi
                    baglanti.Open();
                    SqlCommand katsilme = new SqlCommand("delete from Katlar where KatNo=@KatNo", baglanti);
                    katsilme.Parameters.AddWithValue("KatNo", secilenKat);
                    katsilme.ExecuteNonQuery();
                    baglanti.Close();

                    //ComboBox ı güncelleme İşlemi
                    ComboKatı_Doldur();
                    MessageBox.Show("Kat ve Onunla İlişkili Odalar Silindi");
                }
                else
                {
                    MessageBox.Show("Lütfen Önce Silinecek Odayı Seçin");
                }
                comboKat.Text = "";
            }
        }
        public void Renk_Degistir(Button btn)//Odanın Duruma Göre Gerekli Renklerin Verilmesi olayı.
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand durumSorgusu = new SqlCommand("SELECT durumu FROM Oda2 WHERE odaID = @odaID", baglanti);
                durumSorgusu.Parameters.AddWithValue("@odaID", btn.Name);
                object odaDurumuObj = durumSorgusu.ExecuteScalar();

                if (odaDurumuObj != null)
                {
                    string odaDurumu = odaDurumuObj.ToString();
                    if (odaDurumu == "Dolu")
                    {
                        btn.BackColor = Color.Red;
                    }
                    else if (odaDurumu == "Boş")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else if (odaDurumu == "Servis Dışı")
                    {
                        btn.BackColor = Color.Gray;
                    }
                    else if (odaDurumu == "Rezerve")
                    {
                        btn.BackColor = Color.Yellow;
                    }
                }
                else if (odaDurumuObj == null)
                {
                    btn.BackColor = Color.Green;
                }
                baglanti.Close();
            }
        }
        public void ComboKatı_Doldur()
        {
            //combokat a Eklenen Katları yerleştiriyor
            comboKat.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select KatNo From Katlar", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                comboKat.Items.Add(reader["KatNo"].ToString());
            }
            reader.Close();
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