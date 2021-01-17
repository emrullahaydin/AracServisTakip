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
using System.Data.SqlClient;

namespace AracServisTakip.StokIslemleri
{
    public partial class frmStokKartlariListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmStokKartlariListesi()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public string StokId = "-1", StokKodu = "", StokAdi = "";
        public decimal SatisFiyat = 0, Tutar = 0;

        private void btnEkle_Click(object sender, EventArgs e)
        {
            StokIslemleri.frmStokKartiDetay frmStokKartiDetay = new frmStokKartiDetay("-1",false);
            frmStokKartiDetay.ShowDialog();
            {
                dt.Clear();
                da.Fill(dt);
                gvListe.Columns["id"].Visible = false;
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

                csKontrol.Kontrol.StokKullanimDurumu(Convert.ToInt32(gvListe.GetFocusedRowCellDisplayText("StokKodu")));

                if (csKontrol.Kontrol.StokKartDurum._stokKullanimDurumu)
                {
                    XtraMessageBox.Show("Hareket Görmüş Malzeme Silinemez","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Silmek İstediğinizden emin misiniz? İlgili kayda bağlı işlemler de silinecek!!!", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                using (SqlCommand cmd = new SqlCommand("delete from StokKarti Where id=@id", baglan.vtbaglan()))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = gvListe.GetFocusedRowCellDisplayText("id");
                    cmd.ExecuteNonQuery();
                }
                XtraMessageBox.Show("Silme İşlemi Başarılı", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Clear();
                da.Fill(dt);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }

        private void gcListe_DoubleClick(object sender, EventArgs e)
        {
            if (gvListe.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("satır seçmediniz");
                return;
            }
            StokId = gvListe.GetFocusedRowCellDisplayText("id");
            StokKodu = gvListe.GetFocusedRowCellDisplayText("StokKodu");
            StokAdi = gvListe.GetFocusedRowCellDisplayText("StokAdi");
            SatisFiyat = Convert.ToDecimal(gvListe.GetFocusedRowCellDisplayText("SatisFiyati"));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvListe.FocusedRowHandle < 0)
                    return;

                csKontrol.Kontrol.StokKullanimDurumu(Convert.ToInt32(gvListe.GetFocusedRowCellDisplayText("StokKodu")));

                if (csKontrol.Kontrol.StokKartDurum._stokKullanimDurumu)
                {
                    if (XtraMessageBox.Show("Hareket Görmüş Malzemeyi değiştirmekte emin misiniz? İlgili malzemenin kullanılmış olduğu servislerde değişecek!!!", "Değiştirme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;                   
                }

                int satirNo = gvListe.FocusedRowHandle;
                //Seçili satırın Id sini alır -> gvListe.GetFocusedRowCellDisplayText(col_Id)
                StokIslemleri.frmStokKartiDetay frmStokKartiDetay = new frmStokKartiDetay(gvListe.GetFocusedRowCellDisplayText("id"),true);
                if (frmStokKartiDetay.ShowDialog() == DialogResult.OK)
                {
                    dt.Clear();
                    da.Fill(dt);

                    gvListe.FocusedRowHandle = satirNo;
                    gvListe.Columns["id"].Visible = false;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }

        private void frmStokKartlariListesi_Load(object sender, EventArgs e)
        {
            try
            {
                using (da.SelectCommand = new SqlCommand(@"SELECT id, StokKodu, StokAdi, Birim, Raf, MinStok, MaksStok, TeminSuresi, AlimFiyati, SatisFiyati, OzelKod1, OzelKod2, Aciklama, Barkod, statu FROM StokKarti", baglan.vtbaglan()))
                {
                    dt.Clear();
                    da.Fill(dt);
                    gcListe.DataSource = dt;
                    gvListe.Columns["id"].Visible = false;
                    gvListe.Columns["Raf"].Visible = false;
                    gvListe.Columns["MinStok"].Visible = false;
                    gvListe.Columns["MaksStok"].Visible = false;
                    gvListe.Columns["TeminSuresi"].Visible = false;
                    gvListe.Columns["OzelKod2"].Visible = false;

                    gvListe.Columns["Aciklama"].Visible = false;
                    gvListe.Columns["Barkod"].Visible = false;
                    gvListe.Columns["statu"].Visible = false;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
    }
}