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
    public partial class OgrKayit : Form
    {
        public OgrKayit()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();

        private void Form1_Load(object sender, EventArgs e)
        {
            //bölüm listeleme
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBoxBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();
            //boş odaları listeleme
            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbBoxOda.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseConnection bgl = new DatabaseConnection();
            try
            {
                SqlCommand komutkyt = new SqlCommand("insert into OgrenciBilgi(OgrAd,OgrSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
                komutkyt.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komutkyt.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komutkyt.Parameters.AddWithValue("@p3", MskTc.Text);
                komutkyt.Parameters.AddWithValue("@p4", MskOgrTel.Text);
                komutkyt.Parameters.AddWithValue("@p5", MskDogumTarihi.Text);
                komutkyt.Parameters.AddWithValue("@p6", CmbBoxBolum.Text);
                komutkyt.Parameters.AddWithValue("@p7", CmbBoxOda.Text);
                komutkyt.Parameters.AddWithValue("@p8", txtVeliAdSoyad.Text);
                komutkyt.Parameters.AddWithValue("@p9", MskVeliTel.Text);
                komutkyt.Parameters.AddWithValue("@p10", richTextBoxAdres.Text);
                komutkyt.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Gerçekleşti.");   
                bgl.baglanti().Close();

                SqlCommand id = new SqlCommand("select OgrID from OgrenciBilgi", bgl.baglanti());
                SqlDataReader oku = id.ExecuteReader();
                while (oku.Read())
                {
                    label13.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();


                //öğrenci borç alanı
                SqlCommand komutkayit2 = new SqlCommand("insert into Borclar (OgrID,OgrAd,OgrSoyad) values(@a1,@a2,@a3)", bgl.baglanti());
                komutkayit2.Parameters.AddWithValue("@a1", label13.Text);
                komutkayit2.Parameters.AddWithValue("@a2", TxtOgrAd.Text);
                komutkayit2.Parameters.AddWithValue("@a3", TxtOgrSoyad.Text);
                komutkayit2.ExecuteNonQuery();
                TxtOgrAd.Clear();
                TxtOgrSoyad.Clear();
                txtVeliAdSoyad.Clear();
                MskDogumTarihi.Clear();
                MskOgrTel.Clear();
                MskTc.Clear();
                MskVeliTel.Clear();
                richTextBoxAdres.Clear();
                bgl.baglanti().Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı giriş..");
            }
            //oda kontenjanını arttırma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@b1", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@b1", CmbBoxOda.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        private void CmbBoxOda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
