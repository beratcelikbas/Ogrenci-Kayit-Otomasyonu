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
    public partial class AdminGiriş : Form
    {
        public AdminGiriş()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("select *from Yönetici where YoneticiAd=@p1 and YoneticiSifre=@p2", bgl.baglanti());
            kmt.Parameters.AddWithValue("@p1", txtYöneticiAd.Text);
            kmt.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader oku = kmt.ExecuteReader();
            if (oku.Read())
            {
                AnaMenu fr = new AnaMenu();
                fr.Show();
                this.Hide();
                MessageBox.Show("Hoşgeldin "+txtYöneticiAd.Text);
            }
            else
            {
                MessageBox.Show("Hatalı Giriş.");
                txtSifre.Clear();
                txtYöneticiAd.Clear();
                txtYöneticiAd.Focus();
            }
            bgl.baglanti().Close();
        }

        private void AdminGiriş_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
