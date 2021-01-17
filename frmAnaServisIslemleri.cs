using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace AracServisTakip
{
    public partial class frmAnaServisIslemleri : DevExpress.XtraEditors.XtraForm
    {
        public frmAnaServisIslemleri()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        SqlTransaction trGenel;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarihSaat.Text = DateTime.Now.ToString();
        }

        private void frmAnaServisIslemleri_Load(object sender, EventArgs e)
        {
            try
            {
                lblPcAd.Text = FirmaModel.PcName + " - " + FirmaModel.KullaniciAdi;
                this.Text = FirmaModel.FirmaAdi + " - " + "Serviş İşlemleri Listesi";

                using (da.SelectCommand = new SqlCommand(@"select ServisId, Tarih, [Aracı Getiren], [Ad Soyad], Telefon, Plaka, MarkaModel, SasiMotorNo, Personel, [Teslim Tarihi] from AnaServisListesi order by Tarih desc", baglan.vtbaglan()))
                {
                    dt.Clear();
                    da.Fill(dt);
                    gcListe.DataSource = dt;
                    gvListe.Columns["ServisId"].Visible = false;
                    //gvListe.Columns["Aracı Getiren"].Visible = false;
                    //gvListe.Columns["MarkaModel"].Visible = false;
                    gvListe.Columns["SasiMotorNo"].Visible = false;
                    gvListe.Columns["Personel"].Visible = false;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
        private void btnYeniKayitEkle_Click(object sender, EventArgs e)
        {
            frmServisIslemleri frmServisIslemleri = new frmServisIslemleri("-1");
            frmServisIslemleri.ShowDialog();
            {
                dt.Clear();
                da.Fill(dt);
                // gvListe.Columns["ServisId"].Visible = false;
            }
        }
        private void btnDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvListe.FocusedRowHandle < 0)
                    return;

                int satirNo = gvListe.FocusedRowHandle;
                //Seçili satırın Id sini alır -> gvListe.GetFocusedRowCellDisplayText(col_Id)
                frmServisIslemleri frmServisIslemleri = new frmServisIslemleri(gvListe.GetFocusedRowCellDisplayText("ServisId"));
                if (frmServisIslemleri.ShowDialog() == DialogResult.OK)
                {
                    dt.Clear();
                    da.Fill(dt);
                    gvListe.FocusedRowHandle = satirNo;
                    // gvListe.Columns["ServisId"].Visible = false;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
            try
            {
                var frmExcel = new frmExcelAktar(gcListe);
                frmExcel.Show();
            }
            catch (System.Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvListe.FocusedRowHandle < 0) return;

                if (XtraMessageBox.Show("Silmek İstediğinizden emin misiniz? İlgili kayda bağlı işlemler de silinecek!!!", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                trGenel = baglan.vtbaglan().BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("delete from ServisIslemleri Where ServisId=@ServisId", baglan.vtbaglan(), transaction: trGenel))
                {
                    cmd.Parameters.Add("@ServisId", SqlDbType.Int).Value = gvListe.GetFocusedRowCellDisplayText("ServisId");
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("delete from ServisIslemleriSatir Where ServisId=@ServisId", baglan.vtbaglan(), transaction: trGenel))
                {
                    cmd.Parameters.Add("@ServisId", SqlDbType.Int).Value = gvListe.GetFocusedRowCellDisplayText("ServisId");
                    cmd.ExecuteNonQuery();
                }
                trGenel.Commit();
                XtraMessageBox.Show("Silme İşlemi Başarılı", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Clear();
                da.Fill(dt);
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                XtraMessageBox.Show(hata.Message);
            }
        }

        private void btnFormdaGoster_Click(object sender, EventArgs e)
        {
            RaporTasarla().ShowPreview();
            //RaporTasarla().ShowDesigner();
        }

        #region Rapor Alma İşlemleri
        private XtraReport RaporTasarla()
        {
            XtraReport xrRapor = new XtraReport();
            xrRapor.LoadLayout(System.Windows.Forms.Application.StartupPath + "\\Raporlar\\TeslimBilgiFisi.repx");


            //Procedure den Parametresiz tüm listeyi almak için bu sorgu olur.
            //using (SqlDataAdapter da = new SqlDataAdapter(@"EXEC StokHareketleri_Hepsi", cs.csBaglanti.BaglantiVer()))


            using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT dbo.Firma.FirmaAdi, dbo.Firma.FirmaAdres, dbo.Firma.FirmaTelefonNo, dbo.Firma.FirmaFaksNo, dbo.Firma.FirmaEPosta, dbo.Firma.FirmaWebAdres, dbo.Musteri.MusteriAdSoyad, dbo.Musteri.MusteriTelefon, dbo.Musteri.AracPlakaNo, dbo.Musteri.AracMarkaModel, dbo.Musteri.AracSasiMotorNo, dbo.ServisIslemleri.AraciGetiren, dbo.ServisIslemleri.MusteriSikayetTalepAciklamasi, dbo.ServisIslemleri.KayitZamani, dbo.ServisIslemleri.AracTeslimTarihi, dbo.ServisIslemleri.IskontoOrani, dbo.ServisPersonel.PersonelAdSoyad, dbo.ServisIslemleriSatir.malzemeKodu, dbo.ServisIslemleriSatir.malzemeAciklama, dbo.ServisIslemleriSatir.Adet, dbo.ServisIslemleriSatir.BirimFiyat, dbo.ServisIslemleriSatir.Tutar FROM dbo.ServisIslemleri INNER JOIN dbo.Musteri ON dbo.ServisIslemleri.MusteriId = dbo.Musteri.MusteriId INNER JOIN dbo.ServisPersonel ON dbo.ServisIslemleri.ServisPersonelId = dbo.ServisPersonel.ServisPersonelId INNER JOIN dbo.Firma ON dbo.ServisIslemleri.FirmaId = dbo.Firma.FirmaId INNER JOIN dbo.ServisIslemleriSatir ON dbo.ServisIslemleri.ServisId = dbo.ServisIslemleriSatir.ServisId WHERE (dbo.ServisIslemleri.ServisId = @id)", baglan.vtbaglan()))

            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(gvListe.GetFocusedRowCellDisplayText("ServisId"));


                dt1.Clear();
                da.Fill(dt1);
            }
            xrRapor.DataSource = dt1;
            return xrRapor;
        }
        #endregion
    }
}