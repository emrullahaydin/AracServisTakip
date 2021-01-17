namespace AracServisTakip.StokIslemleri
{
    partial class frmStokKartlariListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokKartlariListesi));
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gcListe = new DevExpress.XtraGrid.GridControl();
            this.gvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gcListe);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(933, 457);
            this.panelControl3.TabIndex = 9;
            // 
            // gcListe
            // 
            this.gcListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListe.Location = new System.Drawing.Point(2, 2);
            this.gcListe.MainView = this.gvListe;
            this.gcListe.Name = "gcListe";
            this.gcListe.Size = new System.Drawing.Size(929, 453);
            this.gcListe.TabIndex = 4;
            this.gcListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListe});
            this.gcListe.DoubleClick += new System.EventHandler(this.gcListe_DoubleClick);
            // 
            // gvListe
            // 
            this.gvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvListe.GridControl = this.gcListe;
            this.gvListe.Name = "gvListe";
            this.gvListe.OptionsBehavior.Editable = false;
            this.gvListe.OptionsView.ShowFooter = true;
            this.gvListe.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExceleAktar);
            this.panelControl1.Controls.Add(this.btnYenile);
            this.panelControl1.Controls.Add(this.btnDegistir);
            this.panelControl1.Controls.Add(this.btnSil);
            this.panelControl1.Controls.Add(this.btnEkle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 457);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(933, 61);
            this.panelControl1.TabIndex = 7;
            // 
            // btnExceleAktar
            // 
            this.btnExceleAktar.ImageOptions.Image = global::AracServisTakip.Properties.Resources.exporttoxlsx_32x32;
            this.btnExceleAktar.Location = new System.Drawing.Point(420, 13);
            this.btnExceleAktar.Name = "btnExceleAktar";
            this.btnExceleAktar.Size = new System.Drawing.Size(110, 36);
            this.btnExceleAktar.TabIndex = 4;
            this.btnExceleAktar.Text = "Excel e Aktar";
            this.btnExceleAktar.Click += new System.EventHandler(this.btnExceleAktar_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.ImageOptions.Image = global::AracServisTakip.Properties.Resources.refresh_32x32;
            this.btnYenile.Location = new System.Drawing.Point(318, 13);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(96, 36);
            this.btnYenile.TabIndex = 3;
            this.btnYenile.Text = "Yenile";
            // 
            // btnDegistir
            // 
            this.btnDegistir.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDegistir.Appearance.Options.UseFont = true;
            this.btnDegistir.ImageOptions.Image = global::AracServisTakip.Properties.Resources.edit_32x321;
            this.btnDegistir.Location = new System.Drawing.Point(216, 13);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(96, 36);
            this.btnDegistir.TabIndex = 2;
            this.btnDegistir.Text = "Değiştir";
            this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = global::AracServisTakip.Properties.Resources.trash_32x321;
            this.btnSil.Location = new System.Drawing.Point(114, 13);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(96, 36);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnEkle.Appearance.Options.UseFont = true;
            this.btnEkle.ImageOptions.Image = global::AracServisTakip.Properties.Resources.add_32x32;
            this.btnEkle.Location = new System.Drawing.Point(12, 13);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(96, 36);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // frmStokKartlariListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 518);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStokKartlariListesi";
            this.Text = "Stok - Malzeme Listesi";
            this.Load += new System.EventHandler(this.frmStokKartlariListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gcListe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListe;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnDegistir;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
    }
}