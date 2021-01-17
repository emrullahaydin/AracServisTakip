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
    public partial class frmGiris : DevExpress.XtraEditors.XtraForm
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
                {
                    MessageBox.Show("kullanici adi boş geçilemez");
                    txtKullaniciAdi.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtKullaniciSifre.Text))
                {
                    MessageBox.Show("kullanici şifre boş geçilemez");
                    txtKullaniciSifre.Focus();
                    return;
                }
                firmaBilgileri.FirmaBilgileriGetir(1);
                using (SqlCommand cmd = new SqlCommand(@"SELECT id, kullaniciAdi, kullaniciSifre, durum FROM Kullanicilar WHERE (kullaniciAdi = @kullaniciadi) AND (kullaniciSifre = @kullaniciSifre) AND (durum = 1)", baglan.vtbaglan()))
                {
                    cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = txtKullaniciAdi.Text;
                    cmd.Parameters.Add("@KullaniciSifre", SqlDbType.NVarChar).Value = txtKullaniciSifre.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            this.Hide();
                            frmAnaSayfa frmAnaSayfa = new frmAnaSayfa();
                            FirmaModel.KullaniciAdi= txtKullaniciAdi.Text; ;
                            FirmaModel.PcName = Environment.MachineName;
                            frmAnaSayfa.FormClosed += FrmAnaSayfa_FormClosed;
                            frmAnaSayfa.Show();
                        }
                        else
                        {
                            XtraMessageBox.Show("Girmiş olduğunuz kullanıcı bilgileri gerçersiz","Kullanıcı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            txtKullaniciAdi.ResetText();
                            txtKullaniciSifre.ResetText();
                            txtKullaniciAdi.Focus();
                            return;
                        }
                        dr.Close();
                    }                    
                }
                
                



            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void FrmAnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}