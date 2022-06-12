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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();

        private void Personel_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'likePansiyonKayitDataSet5.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.likePansiyonKayitDataSet5.Personel);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personel(PersonelAdSoyad,PersonelDepartman) values(@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPerDep.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Kaydı Eklendi.");
            TxtPerAd.Clear();
            TxtPerDep.Clear();
            this.personelTableAdapter.Fill(this.likePansiyonKayitDataSet5.Personel);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, departman;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            departman = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtPerAd.Text = ad;
            TxtPerDep.Text = departman;
            TxtPerID.Text = id;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Personel where PersonelID=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPerID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silme İşlemi Başarılı.");
            this.personelTableAdapter.Fill(this.likePansiyonKayitDataSet5.Personel);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2 where PersonelID=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPerDep.Text);
            komut.Parameters.AddWithValue("@p3", TxtPerID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncelleme İşlemi Başarılı.");
            this.personelTableAdapter.Fill(this.likePansiyonKayitDataSet5.Personel);
        }
    }
}
