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
    public partial class frmServisPersoneliKayit : DevExpress.XtraEditors.XtraForm
    {
        public frmServisPersoneliKayit()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        private void frmServisPersoneliKayit_Load(object sender, EventArgs e)
        {
            this.Text = FirmaModel.FirmaAdi + " - " + "Servis Personeli Kayit && Güncelle";
            using (da.SelectCommand = new SqlCommand(@"SELECT ServisPersonelId, PersonelAdSoyad, PersonelTelefon fROM ServisPersonel", baglan.vtbaglan()))
            {
                dt.Clear();
                da.Fill(dt);
                gcListe.DataSource = dt;
                gvListe.Columns["ServisPersonelId"].Visible = false;
                gvListe.BestFitColumns();

                //gvListe.Columns[1].Width = 60;
                //gvListe.Columns[2].Width = 40;
                //gvListe.Columns[3].Width = 40;


            }
            txtPersonelId.Enabled = false;
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            using (da.SelectCommand = new SqlCommand(@"SELECT ServisPersonelId, PersonelAdSoyad, PersonelTelefon fROM ServisPersonel", baglan.vtbaglan()))
            {
                dt.Clear();
                da.Fill(dt);
                gcListe.DataSource = dt;
                gvListe.Columns["ServisPersonelId"].Visible = false;
                gvListe.BestFitColumns();

                //gvListe.Columns[1].Width = 60;
                //gvListe.Columns[2].Width = 40;
                //gvListe.Columns[3].Width = 40;
            }
            txtPersonelId.Enabled = false;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtPersonelId.ResetText();
            txtPersonelAdSoyad.ResetText();
            txtTelefonNo.ResetText();
            txtPersonelAdSoyad.Focus();
        }
        private void gvListe_Click(object sender, EventArgs e)
        {
            txtPersonelId.Text = gvListe.GetFocusedRowCellDisplayText("ServisPersonelId");
            txtPersonelAdSoyad.Text = gvListe.GetFocusedRowCellDisplayText("PersonelAdSoyad");
            txtTelefonNo.Text = gvListe.GetFocusedRowCellDisplayText("PersonelTelefon");
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region BoşalanKontrolü

                if (string.IsNullOrWhiteSpace(txtPersonelAdSoyad.Text))
                {
                    XtraMessageBox.Show("Personel Ad Soyad Alanı Boş Geçilemez", "Müşteri / Firma Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPersonelAdSoyad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonNo.Text))
                {
                    XtraMessageBox.Show("Personel Telefon Alanı Boş Geçilemez", "Müşteri / Firma Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefonNo.Focus();
                    return;
                }


                #endregion

                #region Mükerrer Personel Engelleme
                csKontrol.Kontrol.s_PersonelKontrol(txtPersonelAdSoyad.Text);
                #endregion

                if (csKontrol.Kontrol.StokKartDurum._PersonelKullanimda)
                {
                    MessageBox.Show("Girmiş Olduğunuz Personel AdSoyad Kullanımdadır","Personel Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtPersonelAdSoyad.Focus();
                    return;
                }

                SqlCommand cmd = new SqlCommand() { CommandType = CommandType.Text, Connection = baglan.vtbaglan() };
                if (txtPersonelId.Text == "")
                {
                    cmd.CommandText = @"insert into ServisPersonel values ( @PersonelAdSoyad, @PersonelTelefon)";
                }
                else
                {
                    cmd.CommandText = @"update ServisPersonel set  PersonelAdSoyad=@PersonelAdSoyad, PersonelTelefon=@PersonelTelefon where ServisPersonelId=@Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtPersonelId.Text);
                }

                cmd.Parameters.Add("@PersonelAdSoyad", SqlDbType.NVarChar, 50).Value = txtPersonelAdSoyad.Text;
                cmd.Parameters.Add("@PersonelTelefon", SqlDbType.NVarChar, 50).Value = txtTelefonNo.Text;


                cmd.ExecuteNonQuery();

                if (txtPersonelId.Text == "")
                {
                    XtraMessageBox.Show("Personel Kaydetme Başarılı", "Müşteri Firma Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Personel Güncelleme Başarılı", "Müşteri Firma Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnListele_Click(null, null);
                btnTemizle_Click(null, null);

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

                using (SqlCommand cmd = new SqlCommand("delete from ServisPersonel Where ServisPersonelId =@Id", baglan.vtbaglan()))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = gvListe.GetFocusedRowCellDisplayText("ServisPersonelId");
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