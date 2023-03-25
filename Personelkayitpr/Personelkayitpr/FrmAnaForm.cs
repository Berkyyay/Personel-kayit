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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9HVO3KO\\;Initial Catalog=Personel_veri_tabani;Integrated Security=True");

        void temizle()
        {
            textBox1.Text = "";
            Txtad.Text = "";
            Txtsoyad.Text = "";
            comboBox2.Text= "";
            Txtmaas.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Txtad.Focus();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personel_veri_tabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personel_veri_tabaniDataSet.Tbl_Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,Perdurum) values (@p1, @p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut.Parameters.AddWithValue("@p4", Txtmaas.Text);
            komut.Parameters.AddWithValue("@p5", comboBox1.Text);
            komut.Parameters.AddWithValue("@p6", label1.Text);


            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personel_veri_tabaniDataSet.Tbl_Personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label1.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label1.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox2.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            Txtmaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label1.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label1.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel Where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set Perad=@a1,Persoyad=@a2,Persehir=@a3,PerMaas=@a4,Perdurum=@a5,Permeslek=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", Txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", Txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", comboBox2.Text);
            komutguncelle.Parameters.AddWithValue("@a4", Txtmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label1.Text);
            komutguncelle.Parameters.AddWithValue("@a6", comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a7", textBox1.Text);


            komutguncelle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Personel Bilgi Güncellendi");

        }

        private void Btnistatislik_Click(object sender, EventArgs e)
        {
            Frmistatislik fr = new Frmistatislik();
            fr.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafik frg = new FrmGrafik();
            frg.Show();
        }
    }
}
