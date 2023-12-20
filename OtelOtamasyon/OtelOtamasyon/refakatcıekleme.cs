using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace OtelOtamasyon
{
    public partial class refakatcıekleme : Form
    {
        public refakatcıekleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)//ekle butonu
            //vtye ekleme yapmıyor düzeltilecek daha sonrasında odab getir kısmında vs refakaçılarında gözükebileceği bazı yerler lazım
        {
            if (int.Parse(hiddenrefID.Text) == 0)//Yeni Ref Ekleme
            { 
                    baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Refakatcı (musteritc,tc,ad,soyad,telefon,email,adres,cinsiyet,kaldıgıoda) Values(@musteritc,@tc,@ad,@soyad,@telefon," +
                "@email,@adres,@cinsiyet,@kaldıgıoda)", baglanti);
                komut.Parameters.AddWithValue("@musteritc",musteritcsi.Text);
                komut.Parameters.AddWithValue("@tc", txttc.Text );
                komut.Parameters.AddWithValue("@ad", txtad.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("@email", txtmail.Text);
                komut.Parameters.AddWithValue("@adres", txtadres.Text);
                komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                komut.Parameters.AddWithValue("@kaldıgıoda", txtkaldıgıoda.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Refakatçı Başarıyla Eklendi");
                baglanti.Close();
            }
            else if(hiddenrefID.Text==refID)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Update Refakatcı musteritc=@musteritc,tc=@tc,ad=@ad,soyad=@soyad,telefon=@telefon,email=@email,adres=@adres,cinsiyet=@cinsiyet," +
                "kaldıgıoda=@kaldıgıoda)", baglanti);
                komut.Parameters.AddWithValue("@musteritc", musteritcsi.Text);
                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.Parameters.AddWithValue("@ad", txtad.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("@email", txtmail.Text);
                komut.Parameters.AddWithValue("@adres", txtadres.Text);
                komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                komut.Parameters.AddWithValue("@kaldıgıoda", txtkaldıgıoda.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Refakatçı Başarıyla Eklendi");
                baglanti.Close();
            }
            Refgetir();
            Temizle();
        } 
        DataTable tablo=new DataTable();
        public void Refgetir()//Refakatçıları getiriken durumu kalıyor ve gelecek olannları getirecek bu sayede daha önceki refler gözükmeyecekler
        {
            tablo.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Refakatcı where musteritc=@musteritc", baglanti);//Gitti hariç tümünü getir
            komut.Parameters.AddWithValue("@refakatID", musteritcsi.Text);
            komut.Parameters.AddWithValue("@musteritc", musteritcsi.Text);
            komut.Parameters.AddWithValue("@tc", txttc.Text);
            komut.Parameters.AddWithValue("@ad", txtad.Text);
            komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
            komut.Parameters.AddWithValue("@email", txtmail.Text);
            komut.Parameters.AddWithValue("@adres", txtadres.Text);
            komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
            komut.Parameters.AddWithValue("@kaldıgıoda", txtkaldıgıoda.Text);
            komut.ExecuteNonQuery();
            SqlDataAdapter adapter2 = new SqlDataAdapter(komut);
            adapter2.Fill(tablo);
            ekran.DataSource = tablo;
            baglanti.Close();
        }
        string refID = "";
        private void ekran_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            refID= ekran.CurrentRow.Cells["refakatID"].Value.ToString();
            musteritcsi.Text = ekran.CurrentRow.Cells["musteritc"].Value.ToString();
            txttc.Text = ekran.CurrentRow.Cells["tc"].Value.ToString();
            txtad.Text = ekran.CurrentRow.Cells["ad"].Value.ToString();
            txtsoyad.Text = ekran.CurrentRow.Cells["soyad"].Value.ToString();
            txttelefon.Text = ekran.CurrentRow.Cells["telefon"].Value.ToString();
            txtmail.Text = ekran.CurrentRow.Cells["email"].Value.ToString();
            txtadres.Text = ekran.CurrentRow.Cells["adres"].Value.ToString();
            combocinsiyet.Text = ekran.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtkaldıgıoda.Text = ekran.CurrentRow.Cells["kaldıgıoda"].Value.ToString();
            hiddenrefID.Text = refID;
        }
        public void veriaktar(string musteritc,string kaldıgıoda)
        {
            musteritcsi.Text = musteritc;
            txtkaldıgıoda.Text = kaldıgıoda;
        }

        private void refakatcıekleme_Load(object sender, EventArgs e)
        {
            Refgetir();
            hiddenrefID.Text = 0.ToString();
            hiddentc.Text = txtkaldıgıoda.Text;
        }

        private void sil_Click(object sender, EventArgs e)//Refakatçıyı Silme
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Refakatcı  WHERE musteritc = @musteritc and tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@musteritc", musteritcsi.Text);
            komut.Parameters.AddWithValue("@tc", txttc.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Refakatçı Başarıyla Silindi");
            baglanti.Close();
            Refgetir();
            Temizle();

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
        }
    }
}
