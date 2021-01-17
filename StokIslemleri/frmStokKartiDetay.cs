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
    public partial class frmStokKartiDetay : DevExpress.XtraEditors.XtraForm
    {
        public frmStokKartiDetay(string id, bool degistir)
        {
            _id = id;
            _degistir = degistir;
            InitializeComponent();
        }
        string _id = "-1";
        bool _degistir = false;
        private void frmStokKartiDetay_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != "-1")
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT id, StokKodu, StokAdi, Birim, Raf, MinStok, MaksStok, TeminSuresi, AlimFiyati, SatisFiyati, OzelKod1, OzelKod2, Aciklama, Barkod, statu FROM StokKarti WHERE (id = @id)", baglan.vtbaglan()))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = _id;
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        {
                            if (dr.Read())
                            {
                                txtStokKodu.Text = dr["StokKodu"].ToString();
                                txtStokAdi.Text = dr["StokAdi"].ToString();
                                txtStokAciklama.Text = dr["Aciklama"].ToString();
                                cmbStatu.Text = dr["statu"].ToString();
                                txtStokRaf.Text = dr["Raf"].ToString();
                                cmbBirim.Text = dr["Birim"].ToString();
                                txtMinStokMiktari.Text = dr["MinStok"].ToString();
                                txtMaksStokMiktari.Text = dr["MaksStok"].ToString();
                                txtTeminSuresi.Text = dr["TeminSuresi"].ToString();
                                txtAlimFiyat.Text = dr["AlimFiyati"].ToString();
                                txtSatisFiyat.Text = dr["SatisFiyati"].ToString();
                                txtOzelKod1.Text = dr["OzelKod1"].ToString();
                                txtOzelKod2.Text = dr["OzelKod2"].ToString();
                                txtStokBarkod.Text = dr["Barkod"].ToString();
                                txtStokKodu.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region BoşAşanKontrolü

                if (string.IsNullOrWhiteSpace(txtStokKodu.Text))
                {
                    XtraMessageBox.Show("Stok Kodu Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStokKodu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtStokAdi.Text))
                {
                    XtraMessageBox.Show("Stok Adı Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStokAdi.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbBirim.Text))
                {
                    XtraMessageBox.Show("Birim Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStatu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbStatu.Text))
                {
                    XtraMessageBox.Show("Statü Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStatu.Focus();
                    return;
                }
                #endregion

                #region  StokAdıKontrolü
                if (!string.IsNullOrWhiteSpace(txtStokAdi.Text))
                {
                    csKontrol.Kontrol.StokAd(txtStokAdi.Text);
                }

                if (csKontrol.Kontrol.StokKartDurum._stokAdi)
                {
                    if (XtraMessageBox.Show(" Girmiş Olduğunuz Stok Adı Kullanımdadır... Emin misiniz!!!", "Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
                #endregion

                using (SqlCommand cmd = new SqlCommand() { CommandType = CommandType.Text, Connection = baglan.vtbaglan() })
                {
                    if (_id == "-1")
                    {
                        cmd.CommandText = @"insert into StokKarti values (  @StokKodu, @StokAdi, @Birim, @Raf, @MinStok, @MaksStok, @TeminSuresi, @AlimFiyati, @SatisFiyati, @OzelKod1, @OzelKod2, @Aciklama, @Barkod, @statu)";
                    }
                    else
                    {
                        cmd.CommandText = @"update StokKarti set  StokKodu=@StokKodu, StokAdi=@StokAdi, Birim=@Birim, Raf=@Raf, MinStok=@MinStok, MaksStok=@MaksStok, TeminSuresi=@TeminSuresi, AlimFiyati=@AlimFiyati, SatisFiyati=@SatisFiyati, OzelKod1=@OzelKod1, OzelKod2=@OzelKod2, Aciklama=@Aciklama, Barkod=@Barkod, statu=@statu where id=@id";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = _id;
                    }

                    cmd.Parameters.Add("@StokKodu", SqlDbType.NVarChar).Value = txtStokKodu.Text;
                    cmd.Parameters.Add("@StokAdi", SqlDbType.NVarChar).Value = txtStokAdi.Text;
                    cmd.Parameters.Add("@Birim", SqlDbType.NVarChar).Value = cmbBirim.Text;
                    cmd.Parameters.Add("@Raf", SqlDbType.NVarChar).Value = txtStokRaf.Text;

                    if (txtMinStokMiktari.Text != "")
                    {
                        cmd.Parameters.Add("@MinStok", SqlDbType.Decimal).Value = txtMinStokMiktari.Text;
                    }
                    else
                    {
                        cmd.Parameters.Add("@MinStok", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
                    }

                    if (txtMaksStokMiktari.Text != "")
                    {
                        cmd.Parameters.Add("@MaksStok", SqlDbType.Decimal).Value = txtMaksStokMiktari.Text;
                    }
                    else
                    {
                        cmd.Parameters.Add("@MaksStok", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
                    }

                    if (txtTeminSuresi.Text != "")
                    {
                        cmd.Parameters.Add("@TeminSuresi", SqlDbType.Int).Value = Convert.ToInt32(txtTeminSuresi.Text);
                    }
                    else
                    {
                        cmd.Parameters.Add("@TeminSuresi", SqlDbType.Int).Value = Convert.ToInt32(0);
                    }


                    if (txtAlimFiyat.Text != "")
                    {
                        cmd.Parameters.Add("@AlimFiyati", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAlimFiyat.Text);
                    }
                    else
                    {
                        cmd.Parameters.Add("@AlimFiyati", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
                    }


                    if (txtSatisFiyat.Text != "")
                    {
                        cmd.Parameters.Add("@SatisFiyati", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSatisFiyat.Text);
                    }
                    else
                    {
                        cmd.Parameters.Add("@SatisFiyati", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
                    }


                    cmd.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = txtOzelKod1.Text;
                    cmd.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = txtOzelKod2.Text;
                    cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = txtStokAciklama.Text;
                    cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar, 11).Value = txtStokBarkod.Text;
                    cmd.Parameters.Add("@statu", SqlDbType.NVarChar).Value = cmbStatu.Text;

                    cmd.ExecuteNonQuery();
                }

                if (_degistir)
                {
                    XtraMessageBox.Show("Stok Kartı Güncellendi", "Stok Kartı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("Stok Kartı Eklendi", "Stok Kartı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtStokKodu_EditValueChanged(object sender, EventArgs e)
        {
            if (!_degistir)
            {
                if (!string.IsNullOrWhiteSpace(txtStokKodu.Text))
                {
                    csKontrol.Kontrol.StokKodu(Convert.ToInt32(txtStokKodu.Text));
                }

                if (csKontrol.Kontrol.StokKartDurum._stokKodu)
                {
                    lblStokKodDurum.Text = "Girmiş Olduğunuz Stok Kodu Kullanımdadır...";
                    lblStokKodDurum.ForeColor = Color.Red;
                    btnKaydet.Enabled = false;
                }
                else
                {
                    lblStokKodDurum.Text = "Girmiş Olduğunuz Stok Kodu Uygundur...";
                    lblStokKodDurum.ForeColor = Color.Green;
                    btnKaydet.Enabled = true;
                }
            }

        }
        private void txtStokAdi_EditValueChanged(object sender, EventArgs e)
        {
            if (!_degistir)
            {
                if (!string.IsNullOrWhiteSpace(txtStokAdi.Text))
                {
                    csKontrol.Kontrol.StokAd(txtStokAdi.Text);
                }

                if (csKontrol.Kontrol.StokKartDurum._stokAdi)
                {
                    lblStokKodDurum.Text = "Girmiş Olduğunuz Stok Adı Kullanımdadır...";
                    lblStokKodDurum.ForeColor = Color.Red;
                    btnKaydet.Enabled = false;
                }
                else
                {
                    lblStokKodDurum.Text = "Girmiş Olduğunuz Stok Adı Uygundur...";
                    lblStokKodDurum.ForeColor = Color.Green;
                    btnKaydet.Enabled = true;
                }
            }

        }
    }
}