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
    public partial class OgrDuzenle : Form
    {
        public OgrDuzenle()
        {
            InitializeComponent();
        }
        public string id, ad, soyad, tc, ogrtel, dogum, bolum, oda, vadsoyad, velitel, adres;
        DatabaseConnection bgl = new DatabaseConnection();

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from OgrenciBilgi where OgrID=@o1 ", bgl.baglanti());
            sil.Parameters.AddWithValue("@o1",TxtID.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayit Silindi.");

            SqlCommand kmtoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@proda ", bgl.baglanti());
            kmtoda.Parameters.AddWithValue("@proda", CmbBoxOda.Text);
            kmtoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update OgrenciBilgi set OgrAd=@p2,OgrSoyad=@p3,OgrTC=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrOdaNo=@p8,OgrVeliAdSoyad=@p9,OgrVeliTelefon=@p10,OgrAdres=@p11 where OgrID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MskTc.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTel.Text);
                komut.Parameters.AddWithValue("@p6", MskDogumTarihi.Text);
                komut.Parameters.AddWithValue("@p7", CmbBoxBolum.Text);
                komut.Parameters.AddWithValue("@p8", CmbBoxOda.Text);
                komut.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p10", MskVeliTel.Text);
                komut.Parameters.AddWithValue("@p11", richTextBoxAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Yeniden Deneyiniz.");
            }
        }

        private void OgrDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBoxBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbBoxOda.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

            TxtID.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskTc.Text = tc;
            MskOgrTel.Text = ogrtel;
            MskDogumTarihi.Text = dogum;
            CmbBoxBolum.Text = bolum;
            CmbBoxOda.Text = oda;
            txtVeliAdSoyad.Text = vadsoyad;
            MskVeliTel.Text = velitel;
            richTextBoxAdres.Text = adres;

        }
    }
}
