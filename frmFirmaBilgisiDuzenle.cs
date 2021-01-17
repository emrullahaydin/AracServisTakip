using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace AracServisTakip
{
    public partial class frmFirmaBilgisiDuzenle : DevExpress.XtraEditors.XtraForm
    {
        public frmFirmaBilgisiDuzenle(string id)
        {
            _id = id;
            InitializeComponent();
        }

        string _id = "-1";
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                #region BoşAşanKontrolü
                if (string.IsNullOrWhiteSpace(txtFirmaUnvan.Text))
                {
                    XtraMessageBox.Show("Firma Ünvanı Boş Geçilemez", "Firma Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirmaUnvan.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAdres.Text))
                {
                    XtraMessageBox.Show("Firma Adresi boş Geçilemez", "Firma Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdres.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEPosta.Text))
                {
                    XtraMessageBox.Show("Firma E-Posta Adresi boş Geçilemez", "Firma Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEPosta.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtWebAdres.Text))
                {
                    XtraMessageBox.Show("Firma Web Adresi boş Geçilemez", "Firma Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWebAdres.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonNo.Text))
                {
                    XtraMessageBox.Show("Firma Telefon Numarası boş Geçilemez", "Firma Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefonNo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFaksNo.Text))
                {
                    XtraMessageBox.Show("Firma Faks Numarası boş Geçilemez", "Firma Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFaksNo.Focus();
                    return;
                }

                #endregion

                SqlCommand cmd = new SqlCommand() { CommandType = CommandType.Text, Connection = baglan.vtbaglan() };
                if (_id == "-1")
                {
                    cmd.CommandText = @"insert into Firma values ( @FirmaAdi, @FirmaAdres, @FirmaEPosta, @FirmaWebAdres, @FirmaTelefonNo, @FirmaFaksNo)";
                }
                else
                {
                    cmd.CommandText = @"update Firma set  FirmaAdi=@FirmaAdi, FirmaAdres=@FirmaAdres, FirmaEPosta=@FirmaEPosta, FirmaWebAdres=@FirmaWebAdres, FirmaTelefonNo=@FirmaTelefonNo, FirmaFaksNo=@FirmaFaksNo where FirmaId=@Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value =Convert.ToInt32(_id);
                }

                cmd.Parameters.Add("@FirmaAdi", SqlDbType.NVarChar).Value = txtFirmaUnvan.Text;
                cmd.Parameters.Add("@FirmaAdres", SqlDbType.NVarChar).Value = txtAdres.Text;
                cmd.Parameters.Add("@FirmaEPosta", SqlDbType.NVarChar).Value = txtEPosta.Text;
                cmd.Parameters.Add("@FirmaWebAdres", SqlDbType.NVarChar).Value = txtWebAdres.Text;
                cmd.Parameters.Add("@FirmaTelefonNo", SqlDbType.NVarChar).Value = txtTelefonNo.Text;
                cmd.Parameters.Add("@FirmaFaksNo", SqlDbType.NVarChar).Value = txtFaksNo.Text;
                cmd.ExecuteNonQuery();
                firmaBilgileri.FirmaBilgileriGetir(1);
                XtraMessageBox.Show("İşlem Başarılı","Firma Bilgileri",MessageBoxButtons.OK,MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }

        private void frmFirmaBilgisiDuzenle_Load(object sender, EventArgs e)
        {
            if (_id != "-1")
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT FirmaId, FirmaAdi, FirmaAdres, FirmaEPosta, FirmaWebAdres, FirmaTelefonNo, FirmaFaksNo FROM            Firma WHERE (FirmaId = @Id)", baglan.vtbaglan()))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.Read())
                        {
                            txtId.Text = dr["FirmaId"].ToString();
                            txtFirmaUnvan.Text = dr["FirmaAdi"].ToString();
                            txtAdres.Text = dr["FirmaAdres"].ToString();
                            txtEPosta.Text = dr["FirmaEPosta"].ToString();
                            txtWebAdres.Text = dr["FirmaWebAdres"].ToString();
                            txtTelefonNo.Text = dr["FirmaTelefonNo"].ToString();
                            txtFaksNo.Text = dr["FirmaFaksNo"].ToString();
                        }
                    }
                }
            }
        }
    }
}