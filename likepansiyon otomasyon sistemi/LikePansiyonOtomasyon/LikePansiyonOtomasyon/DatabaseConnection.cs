using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LikePansiyonOtomasyon
{
    public class DatabaseConnection
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-AF57TAA\SQLEXPRESS;Initial Catalog=LikePansiyonKayit;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
