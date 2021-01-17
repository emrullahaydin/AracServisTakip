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

namespace AracServisTakip
{
    public partial class frmMusteriKayit : DevExpress.XtraEditors.XtraForm
    {
        public frmMusteriKayit()
        {
            InitializeComponent();
        }

        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public string MusteriId = "", MusteriAdSoyad = "", MusteriTelefon = "", AracPlakaNo = "", AracMarkaModel = "", AracSasiMotorNo = "";

        private void frmMusteriKayit_Load(object sender, EventArgs e)
        {
            this.Text = FirmaModel.FirmaAdi + " - " + "Müşteri / Firma / Araç Kayıt Güncelleme İşlemleri";
            using (da.SelectCommand = new SqlCommand(@"SELECT MusteriId, MusteriAdSoyad, MusteriTelefon, AracPlakaNo, AracMarkaModel, AracSasiMotorNo FROM Musteri", baglan.vtbaglan()))
            {
                dt.Clear();
                da.Fill(dt);
                gcListe.DataSource = dt;
                gvListe.Columns["MusteriId"].Visible = false;
                // gvListe.BestFitColumns();

                gvListe.Columns[1].Width = 60;
                gvListe.Columns[2].Width = 40;
                gvListe.Columns[3].Width = 40;
                gvListe.Columns[4].Width = 60;
                gvListe.Columns[5].Width = 125;

            }
            txtMusteriId.Enabled = false;
        }

        
        private void gvListe_DoubleClick(object sender, EventArgs e)
        {
            MusteriId = gvListe.GetFocusedRowCellDisplayText("MusteriId");
            MusteriAdSoyad = gvListe.GetFocusedRowCellDisplayText("MusteriAdSoyad");
            MusteriTelefon = gvListe.GetFocusedRowCellDisplayText("MusteriTelefon");
            AracPlakaNo = gvListe.GetFocusedRowCellDisplayText("AracPlakaNo");
            AracMarkaModel = gvListe.GetFocusedRowCellDisplayText("AracMarkaModel");
            AracSasiMotorNo = gvListe.GetFocusedRowCellDisplayText("AracSasiMotorNo");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gvListe_Click(object sender, EventArgs e)
        {
            txtMusteriId.Text = gvListe.GetFocusedRowCellDisplayText("MusteriId");
            txtMusteriAdSoyad.Text = gvListe.GetFocusedRowCellDisplayText("MusteriAdSoyad");
            txtTelefonNo.Text = gvListe.GetFocusedRowCellDisplayText("MusteriTelefon");
            txtPlakaNo.Text = gvListe.GetFocusedRowCellDisplayText("AracPlakaNo");
            txtAracMarkaModel.Text = gvListe.GetFocusedRowCellDisplayText("AracMarkaModel");
            txtAracSasiMotorNo.Text = gvListe.GetFocusedRowCellDisplayText("AracSasiMotorNo");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            using (da.SelectCommand = new SqlCommand(@"SELECT MusteriId, MusteriAdSoyad, MusteriTelefon, AracPlakaNo, AracMarkaModel, AracSasiMotorNo FROM Musteri", baglan.vtbaglan()))
            {
                dt.Clear();
                da.Fill(dt);
                gcListe.DataSource = dt;
                gvListe.Columns["MusteriId"].Visible = false;
                // gvListe.BestFitColumns();

                gvListe.Columns[1].Width = 60;
                gvListe.Columns[2].Width = 40;
                gvListe.Columns[3].Width = 40;
                gvListe.Columns[4].Width = 60;
                gvListe.Columns[5].Width = 125;

            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtMusteriId.ResetText();
            txtMusteriAdSoyad.ResetText();
            txtTelefonNo.ResetText();
            txtPlakaNo.ResetText();
            txtAracMarkaModel.ResetText();
            txtAracSasiMotorNo.ResetText();
            txtMusteriId.Enabled = false;
            txtMusteriAdSoyad.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region BoşalanKontrolü

                if (string.IsNullOrWhiteSpace(txtMusteriAdSoyad.Text))
                {
                    XtraMessageBox.Show("Müşteri Ad Soyad Alanı Boş Geçilemez", "Müşteri / Firma Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMusteriAdSoyad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonNo.Text))
                {
                    XtraMessageBox.Show("Müşteri Telefon Alanı Boş Geçilemez", "Müşteri / Firma Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefonNo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPlakaNo.Text))
                {
                    XtraMessageBox.Show("Müşteri Plaka Boş Geçilemez", "Müşteri / Firma Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPlakaNo.Focus();
                    return;
                }
                #endregion

                SqlCommand cmd = new SqlCommand() { CommandType = CommandType.Text, Connection = baglan.vtbaglan() };
                if (txtMusteriId.Text=="")
                {
                    cmd.CommandText = @"insert into Musteri values ( @MusteriAdSoyad, @MusteriTelefon, @AracPlakaNo, @AracMarkaModel, @AracSasiMotorNo)";
                }
                else
                {
                    cmd.CommandText = @"update Musteri set  MusteriAdSoyad=@MusteriAdSoyad, MusteriTelefon=@MusteriTelefon, AracPlakaNo=@AracPlakaNo, AracMarkaModel=@AracMarkaModel, AracSasiMotorNo=@AracSasiMotorNo where MusteriId=@Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtMusteriId.Text);
                }

                cmd.Parameters.Add("@MusteriAdSoyad", SqlDbType.NVarChar, 50).Value = txtMusteriAdSoyad.Text;
                cmd.Parameters.Add("@MusteriTelefon", SqlDbType.NVarChar, 20).Value = txtTelefonNo.Text;
                cmd.Parameters.Add("@AracPlakaNo", SqlDbType.NVarChar, 50).Value = txtPlakaNo.Text;
                cmd.Parameters.Add("@AracMarkaModel", SqlDbType.NVarChar, 100).Value = txtAracMarkaModel.Text;
                cmd.Parameters.Add("@AracSasiMotorNo", SqlDbType.NVarChar, 100).Value = txtAracSasiMotorNo.Text;

                cmd.ExecuteNonQuery();

                if (txtMusteriId.Text == "")
                {
                    XtraMessageBox.Show("Müşteri Firma Kaydetme Başarılı", "Müşteri Firma Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Müşteri Firma Güncelleme Başarılı", "Müşteri Firma Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnListele_Click(null,null);

            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message, "Müşteri Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvListe.FocusedRowHandle < 0) return;

                if (XtraMessageBox.Show("Silmek İstediğinizden emin misiniz?", "Silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                using (SqlCommand cmd = new SqlCommand("delete from Musteri Where MusteriId =@Id", baglan.vtbaglan()))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = gvListe.GetFocusedRowCellDisplayText("MusteriId");
                    cmd.ExecuteNonQuery();
                }
                dt.Clear();
                da.Fill(dt);
                btnTemizle_Click(null, null);
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
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
    }
}