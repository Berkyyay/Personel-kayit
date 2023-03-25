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

namespace Personelkayitpr
{
    public partial class Frmistatislik : Form
    {
        public Frmistatislik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9HVO3KO\\;Initial Catalog=Personel_veri_tabani;Integrated Security=True");



        private void Frmistatislik_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL SAYISI//
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                Lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI//
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI//
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where Perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarpersonel.Text=dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir Sayısı//


            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(persehir))From Tbl_personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                Lblsehirsayisi.Text = dr4[0].ToString();
            }
            
            baglanti.Close();
            //Toplam Maaş//

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(Permaas)From Tbl_personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                Lbltoplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ORTALAMA MAAŞ//
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas)From Tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                Lblortalamamaas.Text=dr6[0].ToString();
            }
            baglanti.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
