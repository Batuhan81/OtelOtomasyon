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
    public partial class Çalışan : Form
    {
        public Çalışan()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        DataSet daset = new DataSet();

        private void btnekle_Click(object sender, EventArgs e)
        {
            //Tüm TextBoxların Dolu olup olmadığını Kontrol Eder Bu sayede Boş Kayıt Eklenemez
            bool enAzBirTextBoxBos = false;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;

                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        enAzBirTextBoxBos = true;
                        break; // En az bir boş TextBox bulundu, döngüyü sonlandır.
                    }
                }
            }
            if (enAzBirTextBoxBos)
            {
                MessageBox.Show("Tüm İlgili Alanları Doldurduğunuzdan Emin Olun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                calısandrmKontrol();
                if (durum == true)
                {
                    if (int.Parse(hiddenId.Text) == 0)//Burada Yeni Kayıt Ekliyorum
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("insert into Calısan(departman,tc,ad,soyad,telefon,email,cinsiyet,adres,maas,isebaslamat,isibirakmat,yetkisv,durumu)Values(@departman,@tc,@ad,@soyad,@telefon,@email,@cinsiyet,@adres,@maas,@isebaslamat,@isibirakmat,@yetkisv,@durumu)", baglanti);
                        komut.Parameters.AddWithValue("departman", departman.Text);
                        komut.Parameters.AddWithValue("ad", txtad.Text);
                        komut.Parameters.AddWithValue("soyad", txtsoyad.Text);
                        komut.Parameters.AddWithValue("telefon", txttelefon.Text);
                        komut.Parameters.AddWithValue("email", txtmail.Text);
                        komut.Parameters.AddWithValue("cinsiyet", combocinsiyet.Text);
                        komut.Parameters.AddWithValue("adres", txtadres.Text);
                        komut.Parameters.AddWithValue("tc", txttc.Text);
                        komut.Parameters.AddWithValue("maas", txtmaas.Text);
                        komut.Parameters.AddWithValue("isebaslamat", DateTime.Parse(baslamat.Text));
                        komut.Parameters.AddWithValue("isibirakmat", DateTime.Parse(birakmat.Text));
                        komut.Parameters.AddWithValue("yetkisv", txtyetkisv.Text);
                        komut.Parameters.AddWithValue("Durumu", durumcombo.Text);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Etme İşlemi Başarılı");
                        baglanti.Close();
                      
                        SqlCommand komut2 = new SqlCommand("select * from Calısan", baglanti);
                        SqlDataAdapter adapter = new SqlDataAdapter(komut2);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        ekran.DataSource = dt;
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
                    }
                    else if (hiddenId.Text == CalısanID)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("Update  Calısan set departman=@departman,ad=@ad,soyad=@soyad,telefon=@telefon,email=@email,cinsiyet=@cinsiyet,adres=@adres," +
                        "tc=@tc,maas=@maas,isebaslamat=@isebaslamat,isibirakmat=@isibirakmat,yetkisv=@yetkisv,Durumu=@Durumu,izinhakki=@izinhakki,izinbast=@izinbast,izinbitt=@izinbitt" +
                        " where tc=@tc  ", baglanti);
                        komut.Parameters.AddWithValue("departman", departman.Text);
                        komut.Parameters.AddWithValue("ad", txtad.Text);
                        komut.Parameters.AddWithValue("soyad", txtsoyad.Text);
                        komut.Parameters.AddWithValue("telefon", txttelefon.Text);
                        komut.Parameters.AddWithValue("email", txtmail.Text);
                        komut.Parameters.AddWithValue("cinsiyet", combocinsiyet.Text);
                        komut.Parameters.AddWithValue("adres", txtadres.Text);
                        komut.Parameters.AddWithValue("tc", txttc.Text);
                        komut.Parameters.AddWithValue("maas", decimal.Parse(txtmaas.Text));
                        komut.Parameters.AddWithValue("isebaslamat", Convert.ToDateTime(baslamat.Text));
                        komut.Parameters.AddWithValue("isibirakmat", Convert.ToDateTime(birakmat.Text));
                        komut.Parameters.AddWithValue("yetkisv", txtyetkisv.Text);
                        komut.Parameters.AddWithValue("Durumu", durumcombo.Text);
                        komut.Parameters.AddWithValue("izinhakki", txtizinhakki.Text);
                        komut.Parameters.AddWithValue("izinbast", Convert.ToDateTime(izinbas.Text));
                        komut.Parameters.AddWithValue("izinbitt", Convert.ToDateTime(izinson.Text));
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Güncelleme İşlemi Başarılı");
                        baglanti.Close();
                        SqlCommand komut2 = new SqlCommand("select * from Calısan", baglanti);
                        SqlDataAdapter adapter = new SqlDataAdapter(komut2);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        ekran.DataSource = dt;
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
                        baslamat.Text = "";
                        birakmat.Text = "";
                    }
                }
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Kaydı Silmek İstediğininze Emin Misininz","Silme Onayı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Calısan where tc='" + ekran.CurrentRow.Cells["tc"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["Calısan"].Clear();
                Kayıt_Göster();
                MessageBox.Show("Kayıt Silindi");
                Temizle();
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi");
            }
        }

        private void button1_Click(object sender, EventArgs e)//İptal Butonu
        {
            Temizle();
            departmanara.Text = "";
            yetkiara.Text = "";
            durumara.Text = "";
            txttcara.Text = "";
            hiddenId.Text=0.ToString();
            MessageBox.Show("İşlem İptal Edilmiştir","İptal İşlemi",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            departmanara.Text = "";
            durumara.Text = "";
            txtyetkisv.Text = "";
            baslamat.Text = "";
            birakmat.Text = "";
            izinson.Text = "";
            izinbas.Text = "";
        }

        public void Ekran_Temizle()
        {
            daset.Reset();
            ekran.DataSource = null;
            ekran.DataSource = ""; // Verileri temizle
            ekran.Columns.Clear();    // Sütunları temizle
        }
        private void Kayıt_Göster()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
            {
                Ekran_Temizle();
                baglantı.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select *from Calısan", baglantı);
                adtr.Fill(daset, "Calısan");
                ekran.DataSource = daset.Tables["Calısan"];
                ekran.Columns[0].HeaderText = "CalısanID";
                ekran.Columns[1].HeaderText = "departman";
                ekran.Columns[2].HeaderText = "ad";
                ekran.Columns[3].HeaderText = "soyad";
                ekran.Columns[4].HeaderText = "telefon";
                ekran.Columns[5].HeaderText = "email";
                ekran.Columns[6].HeaderText = "cinsiyet";
                ekran.Columns[7].HeaderText = "adres";
                ekran.Columns[8].HeaderText = "tc";
                ekran.Columns[9].HeaderText = "maas";
                ekran.Columns[10].HeaderText = "isebaslamat";
                ekran.Columns[11].HeaderText = "isibırakmat";
                ekran.Columns[12].HeaderText = "yetkisv";
                ekran.Columns[13].HeaderText = "Durumu";
                ekran.Columns[14].HeaderText = "İzin Hakkı";
                ekran.Columns[15].HeaderText = "İzne Çıkma";
                ekran.Columns[16].HeaderText = "İzin Dönüş";
                baglantı.Close();
            }
        }
        string CalısanID=0.ToString();
        private void ekran_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CalısanID= ekran.CurrentRow.Cells["CalısanID"].Value.ToString();
            txtad.Text = ekran.CurrentRow.Cells["ad"].Value.ToString();
            txtsoyad.Text = ekran.CurrentRow.Cells["soyad"].Value.ToString();
            txttelefon.Text = ekran.CurrentRow.Cells["telefon"].Value.ToString();
            txtmail.Text = ekran.CurrentRow.Cells["email"].Value.ToString();
            combocinsiyet.Text = ekran.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtadres.Text = ekran.CurrentRow.Cells["adres"].Value.ToString();
            txttc.Text = ekran.CurrentRow.Cells["tc"].Value.ToString();
            departman.Text = ekran.CurrentRow.Cells["departman"].Value.ToString();
            txtmaas.Text = ekran.CurrentRow.Cells["maas"].Value.ToString();
            baslamat.Text = ekran.CurrentRow.Cells["isebaslamat"].Value.ToString();
            birakmat.Text = ekran.CurrentRow.Cells["isibirakmat"].Value.ToString();
            txtyetkisv.Text = ekran.CurrentRow.Cells["yetkisv"].Value.ToString();
            durumcombo.Text = ekran.CurrentRow.Cells["Durumu"].Value.ToString();
            izinbas.Text = ekran.CurrentRow.Cells["izinbast"].Value.ToString();
            izinson.Text= ekran.CurrentRow.Cells["izinbitt"].Value.ToString();
            txtizinhakki.Text = ekran.CurrentRow.Cells["izinhakki"].Value.ToString();
            hiddenId.Text = CalısanID;
            izinbas.Visible = true;
            izinson.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
        }
        bool durum = true;
        public void calısandrmKontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Calısan", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                if (txttc.Text == reader["tc"].ToString())
                {
                    durum = false;
                    MessageBox.Show("Böyle Bir Çalışan Zaten Var", "Uyarı");
                }
            }
            baglanti.Close();
        }

        private void Çalışan_Load(object sender, EventArgs e)
        {
            // DateTimePicker'ın Format ve CustomFormat özelliklerini ayarlayın
            baslamat.Format = DateTimePickerFormat.Custom;
            baslamat.CustomFormat = "dd/MM/yyyy HH:mm";

            birakmat.Format = DateTimePickerFormat.Custom;
            birakmat.CustomFormat = "dd/MM/yyyy HH:mm";

            izinbas.Format = DateTimePickerFormat.Custom;
            izinbas.CustomFormat = "dd/MM/yyyy HH:mm";

            izinson.Format = DateTimePickerFormat.Custom;
            izinson.CustomFormat = "dd/MM/yyyy HH:mm";
            Kayıt_Göster();
            hiddenId.Text = 0.ToString();
        }

        private void combodepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                if (departmanara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Temizlik'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Tekniker'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 3)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Resepsiyon'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 4)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Bahçıvan'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 5)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Aşçı'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (departmanara.SelectedIndex == 6)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where departman='Yönetici'", baglanti);
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

        private void combodurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();//Veri Tabanından Çekmeden Sadece Seçilen İndekse Göre İşlem Yaptım
            try
            {
                if (durumara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (durumara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where Durumu='Aktif'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (durumara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where Durumu='Ayrıldı'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (durumara.SelectedIndex == 3)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where Durumu='İzinde'", baglanti);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Calısan where tc like '%" + txttcara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void txtyetkisv_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                if (txtyetkisv.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='0'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                }
                if (txtyetkisv.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='1'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                }
                if (txtyetkisv.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='2'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                }
                if (txtyetkisv.SelectedIndex == 3)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='3'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                }
                if (txtyetkisv.SelectedIndex == 4)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='4'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                }
                if (txtyetkisv.SelectedIndex ==5 )
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='5'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                }
            }
            catch
            {
                ;
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//Yetki SVnin ComboBox'ı
        {
            baglanti.Open();
            try
            {
                if (yetkiara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (yetkiara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='0'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (yetkiara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='1'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (yetkiara.SelectedIndex == 3)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='2'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (yetkiara.SelectedIndex == 4)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='3'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (yetkiara.SelectedIndex == 5)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='4'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (yetkiara.SelectedIndex == 6)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where yetkisv='5'", baglanti);
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
        public void İzin_Hesapla()
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True"))
            {
                baglanti.Open();    
                DateTime baslangic = DateTime.Parse(izinbas.Text);
                //DateTime son = DateTime.Parse(izinson.Text);
                DateTime son = DateTime.Now;//Kişi olurda İzinden Erken dönerse diye işlemin yapılma vaktine göre İşlem yapıyorum.Kişinin izin hakkını Default olarak 30
                TimeSpan fark = son - baslangic;
                int kalanizin =Convert.ToInt32( txtizinhakki.Text);
                int kalinanGun = (int)fark.TotalDays + 1;//gittiği günüde ekliyorum
                txtizinhakki.Text = (kalanizin-kalinanGun).ToString();
                SqlCommand komut = new SqlCommand("Select izinhakki from Calısan where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@izinhakki", txtizinhakki.Text);
                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.ExecuteNonQuery();
                baglanti.Close() ; 
            }
        }

        private void btnizinver_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (durumcombo.Text == "İzinde")//kişi eğer izindeyken bu butona basılırsa kişiyi izinden aktif moduna alacak harcadığı izini hesaplayıp vtde güncelleyecek
            { 
                İzin_Hesapla();
                SqlCommand izindönüs = new SqlCommand("Update Calısan set izinbast=@izinbast,izinbitt=@izinbitt,izinhakki=@izinhakki,Durumu=@Durumu where tc=@tc", baglanti);
                izindönüs.Parameters.AddWithValue("@izinbast", DateTime.Parse(izinbas.Text));
                izindönüs.Parameters.AddWithValue("@izinbitt", DateTime.Parse(izinson.Text));
                izindönüs.Parameters.AddWithValue("@izinhakki", txtizinhakki.Text);
                izindönüs.Parameters.AddWithValue("@tc", txttc.Text);
                izindönüs.Parameters.AddWithValue("@Durumu", "Aktif");
                izindönüs.ExecuteNonQuery();
                MessageBox.Show("Kişi İzinden Döndü Olarak Ayarlandı");
                Kayıt_Göster();
                izinbas.Visible = false;
                izinson.Visible= false;
                label18.Visible = false;
                label19.Visible = false;
            }
            else if(durumcombo.Text == "Aktif")//Bişi hali Hazırda Aktif Durumdaysa belirlenen tarihler Arasında Kişiyi izinli Durumuna alacak
            {  
                SqlCommand izin = new SqlCommand("Update Calısan set izinbast=@izinbast,izinbitt=@izinbitt,izinhakki=@izinhakki,Durumu=@Durumu where tc=@tc", baglanti);
                izin.Parameters.AddWithValue("@izinbast", DateTime.Parse( izinbas.Text));
                izin.Parameters.AddWithValue("@izinbitt", DateTime.Parse(izinson.Text));
                izin.Parameters.AddWithValue("@izinhakki",txtizinhakki.Text);
                izin.Parameters.AddWithValue("@tc",txttc.Text);
                izin.Parameters.AddWithValue("@Durumu", "İzinde");
                izin.ExecuteNonQuery();
                MessageBox.Show("İzin Verme İşlemi Başarılı");
                Kayıt_Göster();
            }
            else if (durumcombo.Text == "Ayrıldı")//Ayrılan kişiye izin vermeyi engelleme
            {
                MessageBox.Show("Ayrılan Birisine İzin Veremezsiniz","Uyarı !!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.Close();
            Temizle();
        }

        private void adara_TextChanged(object sender, EventArgs e)//İsme Göre Filtreleme 
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Calısan where ad like '%" + adara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)//Cinsiyete Göre Filtreleme
        {
            baglanti.Open();
            try
            {
                if (cinsiyetara.SelectedIndex == 0)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;
                }
                if (cinsiyetara.SelectedIndex == 1)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where cinsiyet='Kadın'", baglanti);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ekran.DataSource = dt;

                }
                if (cinsiyetara.SelectedIndex == 2)
                {
                    SqlCommand komut = new SqlCommand("select * from Calısan where cinsiyet='Erkek'", baglanti);
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

        //ToolStrip Kısmının Yönlendirmeleri
        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ana_Ekran Yönlendir = new Ana_Ekran();
            Yönlendir.ShowDialog();
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
