using System;
using System.Data;
using System.Data.SqlClient;

namespace AracServisTakip.csKontrol
{
    public class Kontrol
    {
        public class StokKartDurum
        {
            public static bool _stokKodu { get; set; }
            public static bool _stokAdi { get; set; }
            public static bool _stokKullanimDurumu { get; set; }
            public static bool _PersonelKullanimda { get; set; }
        }

        public static void s_PersonelKontrol(string personelAdi)
        {
            using (SqlCommand cmd = new SqlCommand(@"SELECT PersonelAdSoyad FROM ServisPersonel WHERE (PersonelAdSoyad = @id)", baglan.vtbaglan()))
            {
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = personelAdi;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        StokKartDurum._PersonelKullanimda = true;
                    }
                    else
                    {
                        StokKartDurum._PersonelKullanimda = false;
                    }
                    dr.Close();
                }
            }
        }

        public static void StokKodu(int stokKodu)
        {
            using (SqlCommand cmd = new SqlCommand(@"SELECT StokKodu FROM dbo.StokKarti WHERE (StokKodu = @kod)", baglan.vtbaglan()))
            {
                cmd.Parameters.Add("@kod", SqlDbType.Int).Value = stokKodu;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        StokKartDurum._stokKodu = true;                        
                    }
                    else
                    {
                        StokKartDurum._stokKodu = false;
                    }
                    dr.Close();
                }
            }
        }

        public static void StokAd(string stokAd)
        {
            using (SqlCommand cmd = new SqlCommand(@"SELECT StokAdi FROM dbo.StokKarti WHERE (StokAdi = @ad)", baglan.vtbaglan()))
            {
                cmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = stokAd;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        StokKartDurum._stokAdi = true;
                    }
                    else
                    {
                        StokKartDurum._stokAdi = false;
                    }
                    dr.Close();
                }
            }
        }

        public static void StokKullanimDurumu(int stokKodu)
        {
            using (SqlCommand cmd = new SqlCommand(@"SELECT malzemeKodu FROM dbo.ServisIslemleriSatir WHERE (malzemeKodu = @kod)", baglan.vtbaglan()))
            {
                cmd.Parameters.Add("@kod", SqlDbType.Int).Value = stokKodu;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        StokKartDurum._stokKullanimDurumu = true;
                    }
                    else
                    {
                        StokKartDurum._stokKullanimDurumu = false;
                    }
                    dr.Close();
                }
            }
        }
    }
}
