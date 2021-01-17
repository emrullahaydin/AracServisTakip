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
    public partial class frmServisIslemleri : DevExpress.XtraEditors.XtraForm
    {
        public frmServisIslemleri(string ServisId)
        {
            _ServisId = ServisId;
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string _ServisId = "-1";
        SqlTransaction trGenel;
        decimal tutar = 0, adet = 0, bfiyat = 0;
        bool bosSatirVar = false;
        int musteriId = 0;

        private void btnPalakaSorgula_Click(object sender, EventArgs e)
        {
            frmMusteriKayit frmMusteriKayit = new frmMusteriKayit();
            if (frmMusteriKayit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMusteriAdSoyad.Text = frmMusteriKayit.MusteriAdSoyad;
                txtTelefonNoCep.Text = frmMusteriKayit.MusteriTelefon;
                txtPlakaNo.Text = frmMusteriKayit.AracPlakaNo;
                txtAracMarkaModel.Text = frmMusteriKayit.AracMarkaModel;
                txtAracSasiMotorNo.Text = frmMusteriKayit.AracSasiMotorNo;
                musteriId = Convert.ToInt32(frmMusteriKayit.MusteriId);
            }
        }
        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            frmMusteriKayit frmMusteriKayit = new frmMusteriKayit();
            if (frmMusteriKayit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMusteriAdSoyad.Text = frmMusteriKayit.MusteriAdSoyad;
                txtTelefonNoCep.Text = frmMusteriKayit.MusteriTelefon;
                txtPlakaNo.Text = frmMusteriKayit.AracPlakaNo;
                txtAracMarkaModel.Text = frmMusteriKayit.AracMarkaModel;
                txtAracSasiMotorNo.Text = frmMusteriKayit.AracSasiMotorNo;
                musteriId = Convert.ToInt32(frmMusteriKayit.MusteriId);
            }
        }
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = FirmaModel.FirmaAdi + " - " + "Servis İşlemleri";
                lkpServisPersoneli.EditValue = -1;
                #region lkpServisPersoneli Doldur
                using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT ServisPersonelId, PersonelAdSoyad FROM dbo.ServisPersonel", baglan.vtbaglan()))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lkpServisPersoneli.Properties.DataSource = dt;
                    lkpServisPersoneli.Properties.PopulateColumns(); //dt deki kolonları lkp de oluşturma işlemi yap
                    lkpServisPersoneli.Properties.ForceInitialize(); // arayüzde görünmese de dt'deki verileri lkp içine sırala/yaz
                    lkpServisPersoneli.Properties.DisplayMember = "PersonelAdSoyad";
                    lkpServisPersoneli.Properties.ValueMember = "ServisPersonelId";
                    lkpServisPersoneli.Properties.Columns["PersonelAdSoyad"].Caption = "Per. Ad Soyad";
                    lkpServisPersoneli.EditValue = -1; //lkp ilk yüklendiğinde içinde seçili satır olmamasını sağlıyor.   
                    lkpServisPersoneli.Properties.Columns["ServisPersonelId"].Visible = false;
                }

                #endregion
                GridDoldur();
                if (_ServisId != "-1")
                {

                    using (SqlCommand cmd = new SqlCommand(@"SELECT dbo.ServisIslemleri.ServisId, dbo.ServisIslemleri.AraciGetiren, dbo.ServisIslemleri.AracTeslimTarihi, dbo.ServisIslemleri.ServisPersonelId , dbo.ServisIslemleri.MusteriId, dbo.ServisIslemleri.MusteriSikayetTalepAciklamasi, dbo.ServisIslemleri.Tarih, dbo.ServisIslemleri.IskontoOrani, dbo.Musteri.MusteriAdSoyad, dbo.Musteri.MusteriTelefon, dbo.Musteri.AracPlakaNo, dbo.Musteri.AracMarkaModel, dbo.Musteri.AracSasiMotorNo FROM dbo.ServisIslemleri LEFT OUTER JOIN                    dbo.Musteri ON dbo.ServisIslemleri.MusteriId = dbo.Musteri.MusteriId WHERE (dbo.ServisIslemleri.ServisId = @ServisId)", baglan.vtbaglan()))
                    {
                        cmd.Parameters.Add("@ServisId", SqlDbType.Int).Value = _ServisId;
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        {
                            if (dr.Read())
                            {
                                txtMusteriAdSoyad.Text = dr["MusteriAdSoyad"].ToString();
                                txtAraciGetiren.Text = dr["AraciGetiren"].ToString();
                                txtTelefonNoCep.Text = dr["MusteriTelefon"].ToString();
                                txtPlakaNo.Text = dr["AracPlakaNo"].ToString();
                                txtAracMarkaModel.Text = dr["AracMarkaModel"].ToString();
                                txtAracSasiMotorNo.Text = dr["AracSasiMotorNo"].ToString();
                                lkpServisPersoneli.EditValue = Convert.ToInt32(dr["ServisPersonelId"].ToString());
                                dtTeslimTarihi.EditValue = dr["AracTeslimTarihi"].ToString();
                                musteriId = Convert.ToInt32(dr["MusteriId"].ToString());
                                txtMusteriSikayetTalebi.Text = dr["MusteriSikayetTalepAciklamasi"].ToString();
                                txtIskonto.Text = dr["IskontoOrani"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    DataRow yeniSatir = dt.NewRow();
                    dt.Rows.Add(yeniSatir);
                    //dtTarih.EditValue = DateTime.Today;
                    txtMusteriAdSoyad.Focus();
                }

                gvListe.Columns["ServisId"].Visible = false;
                gvListe.Columns["id"].Visible = false;
                gvListe.Columns["StokId"].Visible = false;
                //gvListe.Columns["IskontoOrani"].Visible = false;
                gvListe.BestFitColumns();

            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
        private void GridDoldur()
        {
            try
            {
                da.SelectCommand = new SqlCommand(@"SELECT id,StokId,ServisId, malzemeKodu, malzemeAciklama, Adet, BirimFiyat, Tutar, KayitZamani FROM dbo.ServisIslemleriSatir WHERE (ServisId = @ServisId)", baglan.vtbaglan());
                da.SelectCommand.Parameters.Add("@ServisId", SqlDbType.Int).Value = _ServisId;

                da.InsertCommand = new SqlCommand(@"Insert into ServisIslemleriSatir (StokId,ServisId, malzemeKodu, malzemeAciklama, Adet, BirimFiyat, Tutar,KayitZamani) values(@StokId, @ServisId, @malzemeKodu, @malzemeAciklama, @Adet, @BirimFiyat, @Tutar,@KayitZamani)", baglan.vtbaglan());

                da.InsertCommand.Parameters.Add("@StokId", SqlDbType.Int, 0, "StokId");
                da.InsertCommand.Parameters.Add("@ServisId", SqlDbType.Int, 0, "ServisId");
                da.InsertCommand.Parameters.Add("@malzemeKodu", SqlDbType.NVarChar, 50, "malzemeKodu");
                da.InsertCommand.Parameters.Add("@malzemeAciklama", SqlDbType.NVarChar, 100, "malzemeAciklama");
                da.InsertCommand.Parameters.Add("@Adet", SqlDbType.Decimal, 0, "Adet");
                da.InsertCommand.Parameters.Add("@BirimFiyat", SqlDbType.Decimal, 0, "BirimFiyat");
                da.InsertCommand.Parameters.Add("@Tutar", SqlDbType.Decimal, 0, "Tutar");
                da.InsertCommand.Parameters.Add("@KayitZamani", SqlDbType.DateTime, 0, "KayitZamani");



                da.UpdateCommand = new SqlCommand(@"Update ServisIslemleriSatir SET  StokId=@StokId, malzemeKodu=@malzemeKodu, malzemeAciklama=@malzemeAciklama, Adet=@Adet, BirimFiyat=@BirimFiyat, Tutar=@Tutar WHERE (id = @id)", baglan.vtbaglan());
                //  da.UpdateCommand.Parameters.Add("@ServisId", SqlDbType.Int, 0, "ServisId");
                da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
                da.UpdateCommand.Parameters.Add("@StokId", SqlDbType.Int, 0, "StokId");
                da.UpdateCommand.Parameters.Add("@malzemeKodu", SqlDbType.NVarChar, 50, "malzemeKodu");
                da.UpdateCommand.Parameters.Add("@malzemeAciklama", SqlDbType.NVarChar, 100, "malzemeAciklama");
                da.UpdateCommand.Parameters.Add("@Adet", SqlDbType.Decimal, 0, "Adet");
                da.UpdateCommand.Parameters.Add("@BirimFiyat", SqlDbType.Decimal, 0, "BirimFiyat");
                da.UpdateCommand.Parameters.Add("@Tutar", SqlDbType.Decimal, 0, "Tutar");


                //  da.UpdateCommand.Parameters.Add("@KayitZamani", SqlDbType.DateTime, 0, "KayitZamani");


                da.DeleteCommand = new SqlCommand(@"delete from ServisIslemleriSatir WHERE (id = @id)", baglan.vtbaglan());
                da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");

                dt.Clear();
                da.Fill(dt);
                gcListe.DataSource = dt;

                gvListe.BestFitColumns();
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }
        private void btnYeniSatir_Click(object sender, EventArgs e)
        {
            // bool bosSatirVar = false;
            foreach (DataRow satir in dt.AsEnumerable())
            {
                if (satir["malzemeKodu"].ToString() == "")
                {
                    bosSatirVar = true;
                    break;
                }
            }

            if (bosSatirVar == false)
            {
                DataRow yeniSatir = dt.NewRow();
                dt.Rows.Add(yeniSatir);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                #region GridBoşlukKontolü
                bool bosSatirVar = false;
                bool bosMiktarVar = false;

                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Hareket satırı giriniz.");
                    return;
                }

                foreach (DataRow satir in dt.AsEnumerable())
                {
                    if (satir["malzemeKodu"].ToString() == "")
                    {
                        bosSatirVar = true;
                        break;
                    }
                }
                if (bosSatirVar)
                {
                    XtraMessageBox.Show("Malzeme Kodu girilmemiş satır var. Boş Geçilemez giriniz.");
                    return;
                }

                foreach (DataRow satir in dt.AsEnumerable())
                {
                    if (satir["Adet"].ToString() == "")
                    {
                        bosMiktarVar = true;
                        break;
                    }
                }
                if (bosMiktarVar)
                {
                    XtraMessageBox.Show("Adet girilmemiş satır bulunmaktadır. Lütfen miktar giriniz.");
                    return;
                }
                #endregion
                #region Boş Alan Kontrolü

                if (string.IsNullOrWhiteSpace(txtMusteriAdSoyad.Text))
                {
                    XtraMessageBox.Show("Müşteri Ad Soyad Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMusteriAdSoyad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAraciGetiren.Text))
                {
                    XtraMessageBox.Show("Aracı Getiren Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAraciGetiren.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonNoCep.Text))
                {
                    XtraMessageBox.Show("Telefon Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefonNoCep.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPlakaNo.Text))
                {
                    XtraMessageBox.Show("Plaka Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPlakaNo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAracMarkaModel.Text))
                {
                    XtraMessageBox.Show("Araç Marka Model Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAracMarkaModel.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAracSasiMotorNo.Text))
                {
                    XtraMessageBox.Show("Araç Şasi Alanı Boş Geçilemez", "Boş Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAracSasiMotorNo.Focus();
                    return;
                }              

                #endregion

                trGenel = baglan.vtbaglan().BeginTransaction();

                da.UpdateCommand.Transaction = trGenel;
                da.InsertCommand.Transaction = trGenel;
                da.DeleteCommand.Transaction = trGenel;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = baglan.vtbaglan();
                cmd.Transaction = trGenel;
                if (_ServisId == "-1")
                {
                    //Sipariş Başlık tablosuna INSERT
                    cmd.CommandText = "insert into ServisIslemleri values ( @AraciGetiren, @AracTeslimTarihi, @ServisPersonelId, @MusteriId, @FirmaId, @MusteriSikayetTalepAciklamasi, @KayitZamani, @Tarih, @IskontoOrani) SET @YeniID= SCOPE_IDENTITY()";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@KayitZamani", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@Tarih", SqlDbType.Date).Value = DateTime.Today;
                    //cmd.Transaction = trGenel;
                }
                else
                {
                    //Sipariş Başlık tablosuna UPDATE 
                    cmd.CommandText = "update ServisIslemleri set  AraciGetiren=@AraciGetiren, AracTeslimTarihi=@AracTeslimTarihi, ServisPersonelId=@ServisPersonelId, MusteriId=@MusteriId, FirmaId=@FirmaId, MusteriSikayetTalepAciklamasi=@MusteriSikayetTalepAciklamasi, IskontoOrani=@IskontoOrani where ServisId=@ServisId";
                    cmd.Parameters.Add("@ServisId", SqlDbType.Int).Value = _ServisId;
                }

                //ortak parametreler buraya yazılacak.


                cmd.Parameters.Add("@MusteriId", SqlDbType.Int).Value = musteriId;
                cmd.Parameters.Add("@AraciGetiren", SqlDbType.NVarChar).Value = txtAraciGetiren.Text;
                cmd.Parameters.Add("@ServisPersonelId", SqlDbType.Int).Value = lkpServisPersoneli.EditValue.ToString();
                cmd.Parameters.Add("@MusteriSikayetTalepAciklamasi", SqlDbType.NVarChar).Value = txtMusteriSikayetTalebi.Text;
                cmd.Parameters.Add("@AracTeslimTarihi", SqlDbType.Date).Value = dtTeslimTarihi.DateTime.Date;
                if (txtIskonto.Text=="")
                {
                    txtIskonto.Text = "0";
                }

                cmd.Parameters.Add("@IskontoOrani", SqlDbType.Int).Value = int.Parse(txtIskonto.Text);

                cmd.Parameters.Add("@FirmaId", SqlDbType.Int).Value = FirmaModel.FirmaId;


                cmd.ExecuteNonQuery();

                if (_ServisId == "-1")
                    _ServisId = cmd.Parameters["@YeniID"].Value.ToString();

                foreach (DataRow satir in dt.AsEnumerable())
                {
                    satir["ServisId"] = _ServisId;
                    satir["KayitZamani"] = DateTime.Now.ToString();
                }

                da.Update(dt);


                trGenel.Commit();

                XtraMessageBox.Show("Kaydetme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                XtraMessageBox.Show(hata.Message);
            }
        }
        private void btnMalzemeKodu_Click_1(object sender, EventArgs e)
        {
            // MessageBox.Show("Stok Listesi Açılacak");
            StokIslemleri.frmStokKartlariListesi frmStokKartlariListesi = new StokIslemleri.frmStokKartlariListesi();
            if (frmStokKartlariListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gvListe.SetFocusedRowCellValue(col_StokId, frmStokKartlariListesi.StokId);
                gvListe.SetFocusedRowCellValue(col_malzemeKodu, frmStokKartlariListesi.StokKodu);
                gvListe.SetFocusedRowCellValue(col_malzemeAciklama, frmStokKartlariListesi.StokAdi);
                gvListe.SetFocusedRowCellValue(col_Adet, 1);
                gvListe.SetFocusedRowCellValue(col_BirimFiyat, frmStokKartlariListesi.SatisFiyat);
                adet = Convert.ToDecimal(gvListe.GetFocusedRowCellValue("Adet").ToString());
                tutar = frmStokKartlariListesi.SatisFiyat * adet;
                gvListe.SetFocusedRowCellValue(col_Tutar, tutar);
                gvListe.BestFitColumns();
                //  Grid_Tutar_Hesapla();
            }
        }
        private void txtAdet_Leave(object sender, EventArgs e)
        {
            Grid_Tutar_Hesapla();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnmalzemeAciklama_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Stok Listesi Açılacak");
            StokIslemleri.frmStokKartlariListesi frmStokKartlariListesi = new StokIslemleri.frmStokKartlariListesi();
            if (frmStokKartlariListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gvListe.SetFocusedRowCellValue(col_StokId, frmStokKartlariListesi.StokId);
                gvListe.SetFocusedRowCellValue(col_malzemeKodu, frmStokKartlariListesi.StokKodu);
                gvListe.SetFocusedRowCellValue(col_malzemeAciklama, frmStokKartlariListesi.StokAdi);
                gvListe.SetFocusedRowCellValue(col_Adet, 1);
                gvListe.SetFocusedRowCellValue(col_BirimFiyat, frmStokKartlariListesi.SatisFiyat);
                adet = Convert.ToDecimal(gvListe.GetFocusedRowCellValue("Adet").ToString());
                tutar = frmStokKartlariListesi.SatisFiyat * adet;
                gvListe.SetFocusedRowCellValue(col_Tutar, tutar);
                gvListe.BestFitColumns();
            }
        }
        void Grid_Tutar_Hesapla()
        {
            //  StokIslemleri.frmStokKartlariListesi frmStokKartlariListesi = new StokIslemleri.frmStokKartlariListesi();

            adet = Convert.ToDecimal(gvListe.GetFocusedRowCellValue(col_Adet).ToString());
            bfiyat = Convert.ToDecimal(gvListe.GetFocusedRowCellValue(col_BirimFiyat).ToString());
            tutar = bfiyat * adet;
            gvListe.SetFocusedRowCellValue(col_Tutar, tutar);
        }
    }
}