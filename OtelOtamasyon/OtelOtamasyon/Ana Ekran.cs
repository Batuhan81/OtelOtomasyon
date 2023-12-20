using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtamasyon
{
    public partial class Ana_Ekran : Form
    {
        public Ana_Ekran()
        {
            InitializeComponent();
        }
        private void btnMusteri_Click(object sender, EventArgs e)
        {
            Müşteriler MüşteriLİstesi = new Müşteriler();
            MüşteriLİstesi.ShowDialog();
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            Odalar odaList = new Odalar();
            odaList.ShowDialog();
            
        }

        private void btnCalısan_Click(object sender, EventArgs e)
        {
            Çalışan çalışan = new Çalışan();
            çalışan.ShowDialog();
        }

        private void btnrezervasyon_Click(object sender, EventArgs e)
        {
            Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.ShowDialog();
        }

        private void btnodateslim_Click(object sender, EventArgs e)
        {
            OdaTeslim form1 = new OdaTeslim();
            form1.ShowDialog();
        }

        private void btnkonaklayan_Click(object sender, EventArgs e)
        {
            Konaklayanlar konaklayanListesi = new Konaklayanlar();
            konaklayanListesi.ShowDialog();
            this.Close();
        }

        private void btnödeme_Click(object sender, EventArgs e)
        {
            Sınıf1 sınıf1 = new Sınıf1();
            Sınıf2 sınıf2 = new Sınıf2();

            Ödeme ödeme = new Ödeme(sınıf1, sınıf2);
            ödeme.ShowDialog();
        }

        private void btnfaturalar_Click(object sender, EventArgs e)
        {
            Faturalar FaturaEkranı=new Faturalar();
            FaturaEkranı.ShowDialog();
        }

        private void btnmaas_Click(object sender, EventArgs e)
        {
            maaş maaşlistesi = new maaş();
            maaşlistesi.ShowDialog();
        }

        private void refakcılar_Click(object sender, EventArgs e)
        {
            Refakatcılar refakatcı=new Refakatcılar();
            refakatcı.ShowDialog();
        }

        private void grafik_Click(object sender, EventArgs e)
        {
            GrafikFRM grafik=new GrafikFRM();
            grafik.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
