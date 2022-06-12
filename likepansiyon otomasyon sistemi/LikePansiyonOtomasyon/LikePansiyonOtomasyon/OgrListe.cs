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
    public partial class OgrListe : Form
    {
        public OgrListe()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-AF57TAA\\SQLEXPRESS;Initial Catalog=LikePansiyonKayit;Integrated Security=True");
        private void OgrListe_Load(object sender, EventArgs e)
        {
            
        }
        private void verilerigoster()
        {
            listView1.Items.Clear();
            bgl.Open();
            SqlCommand komut = new SqlCommand("select *from OgrenciBilgi",bgl);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["OgrAd"].ToString();
                ekle.SubItems.Add(oku["OgrSoyad"].ToString());
                ekle.SubItems.Add(oku["OgrTC"].ToString());
                ekle.SubItems.Add(oku["OgrTelefon"].ToString());
                ekle.SubItems.Add(oku["OgrDogum"].ToString());
                ekle.SubItems.Add(oku["OgrBolum"].ToString());
                ekle.SubItems.Add(oku["OgrOdaNo"].ToString());
                ekle.SubItems.Add(oku["OgrVeliAdSoyad"].ToString());
                ekle.SubItems.Add(oku["OgrVeliTelefon"].ToString());
                ekle.SubItems.Add(oku["OgrAdres"].ToString());
                listView1.Items.Add(ekle);
            }
            bgl.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            bgl.Open();
            SqlCommand komut = new SqlCommand("select *from OgrenciBilgi where OgrOdaNo like '%"+textBox1.Text+ "%' ", bgl);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["OgrAd"].ToString();
                ekle.SubItems.Add(oku["OgrSoyad"].ToString());
                ekle.SubItems.Add(oku["OgrTC"].ToString());
                ekle.SubItems.Add(oku["OgrTelefon"].ToString());
                ekle.SubItems.Add(oku["OgrDogum"].ToString());
                ekle.SubItems.Add(oku["OgrBolum"].ToString());
                ekle.SubItems.Add(oku["OgrOdaNo"].ToString());
                ekle.SubItems.Add(oku["OgrVeliAdSoyad"].ToString());
                ekle.SubItems.Add(oku["OgrVeliTelefon"].ToString());
                ekle.SubItems.Add(oku["OgrAdres"].ToString());
                listView1.Items.Add(ekle);
            }
            bgl.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
