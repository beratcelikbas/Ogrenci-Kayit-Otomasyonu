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
    public partial class GelirIstatistik : Form
    {
        public GelirIstatistik()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();

        private void GelirIstatistik_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblPara.Text = oku[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            //ayları listeleme
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbAySecim.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

            //aylık kazanç
            SqlCommand kmtchart = new SqlCommand("select OdemeAy,sum(OdemeMiktar)from Kasa group by OdemeAy",bgl.baglanti());
            SqlDataReader okuchart = kmtchart.ExecuteReader();
            while (okuchart.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(okuchart[0],okuchart[1]);
            }
            bgl.baglanti().Close();
        }

        private void lblPara_Click(object sender, EventArgs e)
        {

        }

        private void cmbAySecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAySecim.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAyPara.Text = oku[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();
        }
    }
}
