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

namespace LikePansiyonOtomasyon
{
    public partial class YöneticiPaneli : Form
    {
        public YöneticiPaneli()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void YöneticiPaneli_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'likePansiyonKayitDataSet4.Yönetici' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.yöneticiTableAdapter.Fill(this.likePansiyonKayitDataSet4.Yönetici);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Yönetici (YoneticiAd,YoneticiSifre) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtYöneticiAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yönetici Başarıyla Eklendi.");
            this.yöneticiTableAdapter.Fill(this.likePansiyonKayitDataSet4.Yönetici);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, sifre;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            txtYöneticiAd.Text = ad;
            txtSifre.Text = sifre;
            txtYoneticiID.Text = id;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Yönetici where YoneticiID=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtYoneticiID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yönetici Silme İşlemi Başarılı.");
            this.yöneticiTableAdapter.Fill(this.likePansiyonKayitDataSet4.Yönetici);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Yönetici set YoneticiAd=@p1,YoneticiSifre=@p2 where YoneticiID=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("p1", txtYöneticiAd.Text);
            komut.Parameters.AddWithValue("p2", txtSifre.Text);
            komut.Parameters.AddWithValue("p3", txtYoneticiID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı.");
            this.yöneticiTableAdapter.Fill(this.likePansiyonKayitDataSet4.Yönetici);

        }
    }
}
