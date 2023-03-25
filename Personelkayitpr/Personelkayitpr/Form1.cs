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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9HVO3KO\\;Initial Catalog=Personel_veri_tabani;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Persehir,count(*) From Tbl_Personel Group By PerSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
            //Grafik2
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select PerMeslek,Avg(perMaas) From Tbl_Personel group by Permeslek", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read()) 
            {
                chart2.Series["Meslekler-Maaslar"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();



        }
    }
}
