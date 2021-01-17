using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AracServisTakip
{
    public partial class frmExcelAktar : DevExpress.XtraEditors.XtraForm
    {
        public frmExcelAktar(DevExpress.XtraGrid.GridControl GelenGrid)
        {
            InitializeComponent();
            _GelenGrid = GelenGrid;
        }
        DevExpress.XtraGrid.GridControl _GelenGrid;

        private void frmExcelAktar_Load(object sender, EventArgs e)
        {
            try
            {
                sfdKaydet.Filter = "Excel Files |*.xls";

                if (sfdKaydet.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions a = new DevExpress.XtraPrinting.XlsExportOptions();
                    a.ExportMode = DevExpress.XtraPrinting.XlsExportMode.SingleFile;
                    a.ShowGridLines = true;
                    a.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    a.ExportHyperlinks = true;
                    a.Suppress256ColumnsWarning = true;
                    a.Suppress65536RowsWarning = true;

                    _GelenGrid.ExportToXls(sfdKaydet.FileName, a);
                    if (sfdKaydet.FileName != ".xls")
                        if (XtraMessageBox.Show("Kaydetme Başarılı.\nKaydedilen Dosya Açılsın mı?", "Servis Takip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            System.Diagnostics.Process.Start(sfdKaydet.FileName);
                }
                this.Close();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
    }
}