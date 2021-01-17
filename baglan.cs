using System.Data;
using System.Data.SqlClient;


namespace AracServisTakip
{
    public class baglan
    {
        static SqlConnection baglanti;
        public static SqlConnection vtbaglan()
        {
            if (baglanti == null)
                baglanti = new SqlConnection(@"Data Source=BT\SQLSERVER;Initial Catalog=AracServisTakip;User ID=sa;Password=Emo_93351986");

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            return baglanti;
        }
    }
}
