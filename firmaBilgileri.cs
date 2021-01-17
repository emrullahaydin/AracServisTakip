using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisTakip
{    
    public class firmaBilgileri
    {
        public static void FirmaBilgileriGetir(int kullaniciKodu)
        {
            using (SqlCommand cmd = new SqlCommand(@"SELECT FirmaId, FirmaAdi, FirmaAdres, FirmaEPosta, FirmaWebAdres, FirmaTelefonNo, FirmaFaksNo FROM            Firma WHERE (FirmaId = @Id)", baglan.vtbaglan()))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = kullaniciKodu;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        FirmaModel.FirmaId = Convert.ToInt32(dr["FirmaId"].ToString());
                        FirmaModel.FirmaAdi = dr["FirmaAdi"].ToString();
                        FirmaModel.FirmaAdres = dr["FirmaAdres"].ToString();
                        FirmaModel.FirmaEPosta = dr["FirmaEPosta"].ToString();
                        FirmaModel.FirmaWebAdres = dr["FirmaWebAdres"].ToString();
                        FirmaModel.FirmaTelefonNo = dr["FirmaTelefonNo"].ToString();
                        FirmaModel.FirmaFaksNo = dr["FirmaFaksNo"].ToString();
                        
                    }
                }
            }
        }
    }

    public class FirmaModel
    {
        public static int FirmaId { get; set; }
        public static string FirmaAdi { get; set; }
        public static string FirmaAdres { get; set; }
        public static string FirmaEPosta { get; set; }
        public static string FirmaWebAdres { get; set; }
        public static string FirmaTelefonNo { get; set; }
        public static string FirmaFaksNo { get; set; }
        public static string KullaniciAdi { get; set; }
        public static string PcName { get; set; }

    }
}
