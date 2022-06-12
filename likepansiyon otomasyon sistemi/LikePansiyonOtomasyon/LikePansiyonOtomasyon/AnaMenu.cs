using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace LikePansiyonOtomasyon
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrKayit ac = new OgrKayit();
            ac.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recep Berat Çelikbaş Tarafından Yazılmıştır...");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            AdminGiriş fr = new AdminGiriş();
            fr.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Not fr1 = new Not();
            fr1.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            OgrKayit fr2 = new OgrKayit();
            fr2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OgrListe fr4 = new OgrListe();
            fr4.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OgrDuzenle fr3 = new OgrDuzenle();
            fr3.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Personel fr5 = new Personel();
            fr5.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            YöneticiPaneli fr6 = new YöneticiPaneli();
            fr6.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            GelirIstatistik fr7 = new GelirIstatistik();
            fr7.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Odemeler fr8 = new Odemeler();
            fr8.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            GiderListesi fr10 = new GiderListesi();
            fr10.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Giderler fr9 = new Giderler();
            fr9.Show();
        }
    }
}
