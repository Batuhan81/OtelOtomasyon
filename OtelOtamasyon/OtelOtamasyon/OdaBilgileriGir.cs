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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace OtelOtamasyon
{
    public partial class OdaBilgileriGir : Form
    {
        public OdaBilgileriGir()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=OtelOtomasyon2;Integrated Security=True");
        public bool EkleButonunaTiklandi { get; private set; } = false;//ekleye tıklandıysa odalar formunda ekleme işlemine devam edecek
        private void OdaBilgileriGir_Load(object sender, EventArgs e)
        {
            YeniODaID();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if(txtodaozelligi.Text!=null || ucret.Text != null || txtyataks.Text != null)
            {  
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Oda2(yataksayisi,ucret,odaozelligi)Values(@yataksayisi,@ucret,@odaozelligi);", baglanti);
                komut.Parameters.AddWithValue("yataksayisi", textBox1.Text);
                komut.Parameters.AddWithValue("ucret", ucret.Text);
                komut.Parameters.AddWithValue("odaozelligi",txtodaozelligi.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Oda Ekleme İşlemi Başarılı");
                baglanti.Close();
                EkleButonunaTiklandi = true; // "Ekle" butonuna tıklandığını işaretle
                this.Close();
            }
            else
            {
                MessageBox.Show("Bilgileri Eksiksiz Girdiğinizden Emin Olunuz");
            }
        }

        private void odaozelligi_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            if (txtodaozelligi.SelectedIndex == 0)
            {
                SqlCommand komut = new SqlCommand("insert into Oda2 Where odaozelligi=@odaozelligi",baglanti);
                komut.Parameters.AddWithValue("odaozelligi", "Standart");
            }
            if (txtodaozelligi.SelectedIndex == 1)
            {
                SqlCommand komut = new SqlCommand("insert into Oda2 Where odaozelligi=@odaozelligi", baglanti);
                komut.Parameters.AddWithValue("odaozelligi", "Geniş");
            }
            if (txtodaozelligi.SelectedIndex == 2)
            {
                SqlCommand komut = new SqlCommand("insert into Oda2 Where odaozelligi=@odaozelligi", baglanti);
                komut.Parameters.AddWithValue("odaozelligi", "Kral Dairesi");
            }
            if (txtodaozelligi.SelectedIndex == 3)
            {
                SqlCommand komut = new SqlCommand("insert into Oda2 Where odaozelligi=@odaozelligi", baglanti);
                komut.Parameters.AddWithValue("odaozelligi", "Manzaralı");
            }
            if (txtodaozelligi.SelectedIndex == 4)
            {
                SqlCommand komut = new SqlCommand("insert into Oda2 Where odaozelligi=@odaozelligi", baglanti);
                komut.Parameters.AddWithValue("odaozelligi", "Havuz Manzaralı");
            }
            baglanti.Close();  
        }
        int sonButonID = 0;

        private void YeniODaID() //sondaki oda silinmediği sürece sorun yok o silinse dahi kendi kendine düzeliyor
        {
            baglanti.Open();
            SqlCommand maxButonIDKomut = new SqlCommand("SELECT ISNULL(MAX(odaID), 0) FROM Oda2", baglanti);
            sonButonID = (int)maxButonIDKomut.ExecuteScalar();
            baglanti.Close();
            int yeniodaId = sonButonID + 1;
            txtodano.Text = yeniodaId.ToString();
        }

        private void txtodano_TextChanged(object sender, EventArgs e)
        {
            YeniODaID();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
