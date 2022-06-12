using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LikePansiyonOtomasyon
{
    public partial class GiderListesi : Form
    {
        public GiderListesi()
        {
            InitializeComponent();
        }

        private void GiderListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'likePansiyonKayitDataSet7.Giderler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.giderlerTableAdapter1.Fill(this.likePansiyonKayitDataSet7.Giderler);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
