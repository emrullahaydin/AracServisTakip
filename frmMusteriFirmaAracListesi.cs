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
    public partial class frmMusteriFirmaAracListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmMusteriFirmaAracListesi()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        //public string MusteriId = "", MusteriAdSoyad = "", MusteriTelefon = "", AracPlakaNo = "", AracMarkaModel = "", AracSasiMotorNo = "";
        private void frmMusteriFirmaAracListesi_Load(object sender, EventArgs e)
        {
            this.Text = FirmaModel.FirmaAdi+" "+"Araç Listesi";
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

        private void gvListe_DoubleClick(object sender, EventArgs e)
        {
            //MusteriId = gvListe.GetFocusedRowCellDisplayText("MusteriId");
            //MusteriAdSoyad = gvListe.GetFocusedRowCellDisplayText("MusteriAdSoyad");
            //MusteriTelefon = gvListe.GetFocusedRowCellDisplayText("MusteriTelefon");
            //AracPlakaNo = gvListe.GetFocusedRowCellDisplayText("AracPlakaNo");
            //AracMarkaModel = gvListe.GetFocusedRowCellDisplayText("AracMarkaModel");
            //AracSasiMotorNo = gvListe.GetFocusedRowCellDisplayText("AracSasiMotorNo");
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}