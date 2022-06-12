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
    public partial class Odemeler : Form
    {
        public Odemeler()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();
        private void Odemeler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'likePansiyonKayitDataSet6.Borclar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclarTableAdapter1.Fill(this.likePansiyonKayitDataSet6.Borclar);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnOdemeAl_Click(object sender, EventArgs e)
        {
            //kalan borç hesaplama
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt16(TxtOdeme.Text);
            kalan = Convert.ToInt16(TxtKalanBorc.Text);
            yeniborc = kalan - odenen;
            TxtKalanBorc.Text = yeniborc.ToString();

            SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1,SonOdeme=@p3 where OgrID=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", TxtOgrID.Text);
            komut.Parameters.AddWithValue("@p1", TxtKalanBorc.Text);
            komut.Parameters.AddWithValue("@p3", mskTarihS.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ödeme alındı.");
            this.borclarTableAdapter1.Fill(this.likePansiyonKayitDataSet6.Borclar);

            // kasa Tablosuna Ekleme
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("k1", txtOdemeAy.Text);
            komut2.Parameters.AddWithValue("k2", TxtOdeme.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad,kalanborc, tarih;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalanborc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            tarih = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            TxtOgrID.Text = id;
            TxtAd.Text = ad;
            TxtKalanBorc.Text = kalanborc;
            mskTarihS.Text = tarih;
            txtSoyad.Text = soyad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ppdDialog.ShowDialog();
        }
        Font baslik = new Font("Verdana", 12, FontStyle.Bold);
        Font bas = new Font("Verdana", 20, FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void ppdYazici_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Ödeme Dekont", bas, sb, 300, 100);
            e.Graphics.DrawString("ID       ÖĞRENCİ AD      ÖĞRENCİ SOYAD       ÖDEME       TARİH", baslik, sb, 70, 200);
            e.Graphics.DrawString("-----------------------------------------------------------------------------", baslik, sb, 70, 220);


            e.Graphics.DrawString(TxtOgrID.Text, govde, sb, 70, 240);
            e.Graphics.DrawString(TxtAd.Text, govde, sb, 180, 240);
            e.Graphics.DrawString(txtSoyad.Text, govde, sb, 340, 240);
            e.Graphics.DrawString(TxtOdeme.Text + "₺", govde, sb, 500, 240);
            e.Graphics.DrawString(mskTarihS.Text, govde, sb, 600, 240);

            e.Graphics.DrawString("-----------------------------------------------------------------------------", baslik, sb, 70, 300);
            e.Graphics.DrawString("Öğrenci İmza:", govde, sb, 70, 350);
            e.Graphics.DrawString("Yetkili İmza:", govde, sb, 600, 350);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
