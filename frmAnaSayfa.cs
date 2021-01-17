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
    public partial class frmAnaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();       
        string firmavar = "-1";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();           
            frmAnaServisIslemleri frmAnaServisIslemleri = new frmAnaServisIslemleri();
            frmAnaServisIslemleri.FormClosed += FrmAnaServisIslemleri_FormClosed;
            frmAnaServisIslemleri.Show();            
        }

        private void FrmAnaServisIslemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmAnaSayfa frmAnaSayfa = new frmAnaSayfa();
            frmAnaSayfa.FormClosed += FrmAnaSayfa_FormClosed;
            frmAnaSayfa.Show();
        }

        private void FrmAnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }       

        private void picMusteriFirmaKayit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMusteriKayit frmMusteriKayit = new frmMusteriKayit();
            frmMusteriKayit.FormClosed += FrmMusteriKayit_FormClosed;
            frmMusteriKayit.Show();
        }

        private void FrmMusteriKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmAnaSayfa frmAnaSayfa = new frmAnaSayfa();
            frmAnaSayfa.FormClosed += FrmAnaSayfa_FormClosed;
            frmAnaSayfa.Show();
        }       

        private void FrmFirmaBilgisiDuzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmAnaSayfa frmAnaSayfa = new frmAnaSayfa();
            frmAnaSayfa.FormClosed += FrmAnaSayfa_FormClosed;
            frmAnaSayfa.Show();
        }

        

        private void FrmServisPersoneliKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmAnaSayfa frmAnaSayfa = new frmAnaSayfa();
            frmAnaSayfa.FormClosed += FrmAnaSayfa_FormClosed;
            frmAnaSayfa.Show();
        }

        private void FrmStokKartlariListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmAnaSayfa frmAnaSayfa = new frmAnaSayfa();
            frmAnaSayfa.FormClosed += FrmAnaSayfa_FormClosed;
            frmAnaSayfa.Show();
        }

        #region Menu Kodları
        private void servisİşlemleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(null, null);
        }

        private void müşteriFirmaKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picMusteriFirmaKayit_Click(null, null);
        }

        private void firmaBilgileriDüzenleKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            #region FirmaSorgula

            using (SqlCommand cmd = new SqlCommand(@"SELECT FirmaId FROM Firma WHERE (FirmaId = @Id)", baglan.vtbaglan()))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 1;
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr.Read())
                    {
                        firmavar = "1";
                    }
                    else
                    {
                        firmavar = "-1";
                    }
                }
            }

            #endregion

            frmFirmaBilgisiDuzenle frmFirmaBilgisiDuzenle = new frmFirmaBilgisiDuzenle(firmavar);
            frmFirmaBilgisiDuzenle.FormClosed += FrmFirmaBilgisiDuzenle_FormClosed;
            frmFirmaBilgisiDuzenle.Show();
        }

        private void servisPersonelKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pictureBox1_Click_1(null, null);
            this.Hide();
            frmServisPersoneliKayit frmServisPersoneliKayit = new frmServisPersoneliKayit();
            frmServisPersoneliKayit.FormClosed += FrmServisPersoneliKayit_FormClosed;
            frmServisPersoneliKayit.Show();
        }

        private void btnStokkartListesi_Click(object sender, EventArgs e)
        {
            this.Hide();
            StokIslemleri.frmStokKartlariListesi frmStokKartlariListesi = new StokIslemleri.frmStokKartlariListesi();
            frmStokKartlariListesi.FormClosed += FrmStokKartlariListesi_FormClosed;
            frmStokKartlariListesi.Show();
        }

       

        #endregion

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            lblPCAdi.Text = FirmaModel.PcName + " - " + FirmaModel.KullaniciAdi;                      
            this.Text = FirmaModel.FirmaAdi;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           lblTarihSaat.Text = DateTime.Now.ToString();
        }

       
    }
}