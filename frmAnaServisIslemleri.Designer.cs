namespace AracServisTakip
{
    partial class frmAnaServisIslemleri
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnaServisIslemleri));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gcListe = new DevExpress.XtraGrid.GridControl();
            this.gvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServisId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AraciGetiren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MusteriAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MusteriTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AracPlakaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AracMarkaModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AracSasiMotorNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PersonelAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AracTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTarihSaat = new System.Windows.Forms.Label();
            this.lblPcAd = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnFormdaGoster = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeniKayitEkle = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuYeniKayit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDegistir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFormdaGoster = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSil = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExceleAktar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcListe);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 618);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servis Kayıtları Listesi";
            // 
            // gcListe
            // 
            this.gcListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListe.Location = new System.Drawing.Point(3, 24);
            this.gcListe.MainView = this.gvListe;
            this.gcListe.Name = "gcListe";
            this.gcListe.Size = new System.Drawing.Size(930, 591);
            this.gcListe.TabIndex = 5;
            this.gcListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListe});
            // 
            // gvListe
            // 
            this.gvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServisId,
            this.col_Tarih,
            this.col_AraciGetiren,
            this.col_MusteriAdSoyad,
            this.col_MusteriTelefon,
            this.col_AracPlakaNo,
            this.col_AracMarkaModel,
            this.col_AracSasiMotorNo,
            this.col_PersonelAdSoyad,
            this.col_AracTeslimTarihi});
            this.gvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvListe.GridControl = this.gcListe;
            this.gvListe.Name = "gvListe";
            this.gvListe.OptionsBehavior.Editable = false;
            this.gvListe.OptionsView.ShowFooter = true;
            this.gvListe.OptionsView.ShowGroupPanel = false;
            // 
            // col_ServisId
            // 
            this.col_ServisId.Caption = "ServisId";
            this.col_ServisId.FieldName = "ServisId";
            this.col_ServisId.Name = "col_ServisId";
            this.col_ServisId.Visible = true;
            this.col_ServisId.VisibleIndex = 0;
            // 
            // col_Tarih
            // 
            this.col_Tarih.Caption = "Tarih";
            this.col_Tarih.FieldName = "Tarih";
            this.col_Tarih.Name = "col_Tarih";
            this.col_Tarih.Visible = true;
            this.col_Tarih.VisibleIndex = 1;
            // 
            // col_AraciGetiren
            // 
            this.col_AraciGetiren.Caption = "Aracı Getiren";
            this.col_AraciGetiren.FieldName = "Aracı Getiren";
            this.col_AraciGetiren.Name = "col_AraciGetiren";
            this.col_AraciGetiren.Visible = true;
            this.col_AraciGetiren.VisibleIndex = 2;
            // 
            // col_MusteriAdSoyad
            // 
            this.col_MusteriAdSoyad.Caption = "Ad Soyad";
            this.col_MusteriAdSoyad.FieldName = "Ad Soyad";
            this.col_MusteriAdSoyad.Name = "col_MusteriAdSoyad";
            this.col_MusteriAdSoyad.Visible = true;
            this.col_MusteriAdSoyad.VisibleIndex = 3;
            // 
            // col_MusteriTelefon
            // 
            this.col_MusteriTelefon.Caption = "Telefon";
            this.col_MusteriTelefon.FieldName = "Telefon";
            this.col_MusteriTelefon.Name = "col_MusteriTelefon";
            this.col_MusteriTelefon.Visible = true;
            this.col_MusteriTelefon.VisibleIndex = 4;
            // 
            // col_AracPlakaNo
            // 
            this.col_AracPlakaNo.Caption = "Plaka";
            this.col_AracPlakaNo.FieldName = "Plaka";
            this.col_AracPlakaNo.Name = "col_AracPlakaNo";
            this.col_AracPlakaNo.Visible = true;
            this.col_AracPlakaNo.VisibleIndex = 5;
            // 
            // col_AracMarkaModel
            // 
            this.col_AracMarkaModel.Caption = "MarkaModel";
            this.col_AracMarkaModel.FieldName = "MarkaModel";
            this.col_AracMarkaModel.Name = "col_AracMarkaModel";
            this.col_AracMarkaModel.Visible = true;
            this.col_AracMarkaModel.VisibleIndex = 6;
            // 
            // col_AracSasiMotorNo
            // 
            this.col_AracSasiMotorNo.Caption = "Sasi Motor No";
            this.col_AracSasiMotorNo.FieldName = "SasiMotorNo";
            this.col_AracSasiMotorNo.Name = "col_AracSasiMotorNo";
            this.col_AracSasiMotorNo.Visible = true;
            this.col_AracSasiMotorNo.VisibleIndex = 7;
            // 
            // col_PersonelAdSoyad
            // 
            this.col_PersonelAdSoyad.Caption = "Personel";
            this.col_PersonelAdSoyad.FieldName = "Personel";
            this.col_PersonelAdSoyad.Name = "col_PersonelAdSoyad";
            this.col_PersonelAdSoyad.Visible = true;
            this.col_PersonelAdSoyad.VisibleIndex = 8;
            // 
            // col_AracTeslimTarihi
            // 
            this.col_AracTeslimTarihi.Caption = "Teslim Tarihi";
            this.col_AracTeslimTarihi.FieldName = "Teslim Tarihi";
            this.col_AracTeslimTarihi.Name = "col_AracTeslimTarihi";
            this.col_AracTeslimTarihi.Visible = true;
            this.col_AracTeslimTarihi.VisibleIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTarihSaat);
            this.panel2.Controls.Add(this.lblPcAd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 685);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(936, 26);
            this.panel2.TabIndex = 2;
            // 
            // lblTarihSaat
            // 
            this.lblTarihSaat.AutoSize = true;
            this.lblTarihSaat.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTarihSaat.Location = new System.Drawing.Point(781, 4);
            this.lblTarihSaat.Name = "lblTarihSaat";
            this.lblTarihSaat.Size = new System.Drawing.Size(78, 17);
            this.lblTarihSaat.TabIndex = 1;
            this.lblTarihSaat.Text = "Tarih - Saat";
            // 
            // lblPcAd
            // 
            this.lblPcAd.AutoSize = true;
            this.lblPcAd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPcAd.Location = new System.Drawing.Point(12, 4);
            this.lblPcAd.Name = "lblPcAd";
            this.lblPcAd.Size = new System.Drawing.Size(92, 17);
            this.lblPcAd.TabIndex = 0;
            this.lblPcAd.Text = "pcAdi/Kullanıcı";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExceleAktar);
            this.panel1.Controls.Add(this.btnFormdaGoster);
            this.panel1.Controls.Add(this.btnSil);
            this.panel1.Controls.Add(this.btnDegistir);
            this.panel1.Controls.Add(this.btnYeniKayitEkle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 67);
            this.panel1.TabIndex = 3;
            // 
            // btnExceleAktar
            // 
            this.btnExceleAktar.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnExceleAktar.Appearance.Options.UseFont = true;
            this.btnExceleAktar.ImageOptions.Image = global::AracServisTakip.Properties.Resources.exporttoxls_32x32;
            this.btnExceleAktar.Location = new System.Drawing.Point(748, 12);
            this.btnExceleAktar.Name = "btnExceleAktar";
            this.btnExceleAktar.Size = new System.Drawing.Size(176, 43);
            this.btnExceleAktar.TabIndex = 5;
            this.btnExceleAktar.Text = "Excel Aktar";
            this.btnExceleAktar.Click += new System.EventHandler(this.btnExceleAktar_Click);
            // 
            // btnFormdaGoster
            // 
            this.btnFormdaGoster.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnFormdaGoster.Appearance.Options.UseFont = true;
            this.btnFormdaGoster.ImageOptions.Image = global::AracServisTakip.Properties.Resources.report_32x32;
            this.btnFormdaGoster.Location = new System.Drawing.Point(380, 12);
            this.btnFormdaGoster.Name = "btnFormdaGoster";
            this.btnFormdaGoster.Size = new System.Drawing.Size(178, 43);
            this.btnFormdaGoster.TabIndex = 4;
            this.btnFormdaGoster.Text = "Formu\r\nGöster && Yazdır";
            this.btnFormdaGoster.Click += new System.EventHandler(this.btnFormdaGoster_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = global::AracServisTakip.Properties.Resources.trash_32x32;
            this.btnSil.Location = new System.Drawing.Point(564, 12);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(178, 43);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnDegistir
            // 
            this.btnDegistir.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnDegistir.Appearance.Options.UseFont = true;
            this.btnDegistir.ImageOptions.Image = global::AracServisTakip.Properties.Resources.edit_32x32;
            this.btnDegistir.Location = new System.Drawing.Point(196, 12);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(178, 43);
            this.btnDegistir.TabIndex = 1;
            this.btnDegistir.Text = "Değiştir";
            this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
            // 
            // btnYeniKayitEkle
            // 
            this.btnYeniKayitEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnYeniKayitEkle.Appearance.Options.UseFont = true;
            this.btnYeniKayitEkle.ImageOptions.Image = global::AracServisTakip.Properties.Resources.addfile_32x32;
            this.btnYeniKayitEkle.Location = new System.Drawing.Point(12, 12);
            this.btnYeniKayitEkle.Name = "btnYeniKayitEkle";
            this.btnYeniKayitEkle.Size = new System.Drawing.Size(178, 43);
            this.btnYeniKayitEkle.TabIndex = 0;
            this.btnYeniKayitEkle.Text = "Yeni Kayıt Ekle";
            this.btnYeniKayitEkle.Click += new System.EventHandler(this.btnYeniKayitEkle_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(936, 618);
            this.panel3.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuYeniKayit,
            this.menuDegistir,
            this.menuFormdaGoster,
            this.menuSil,
            this.menuExceleAktar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 114);
            // 
            // menuYeniKayit
            // 
            this.menuYeniKayit.Image = global::AracServisTakip.Properties.Resources.addfile_32x32;
            this.menuYeniKayit.Name = "menuYeniKayit";
            this.menuYeniKayit.Size = new System.Drawing.Size(168, 22);
            this.menuYeniKayit.Text = "YENİ KAYIT";
            // 
            // menuDegistir
            // 
            this.menuDegistir.Image = global::AracServisTakip.Properties.Resources.edit_32x32;
            this.menuDegistir.Name = "menuDegistir";
            this.menuDegistir.Size = new System.Drawing.Size(168, 22);
            this.menuDegistir.Text = "DEĞİŞTİR";
            // 
            // menuFormdaGoster
            // 
            this.menuFormdaGoster.Image = global::AracServisTakip.Properties.Resources.report_32x32;
            this.menuFormdaGoster.Name = "menuFormdaGoster";
            this.menuFormdaGoster.Size = new System.Drawing.Size(168, 22);
            this.menuFormdaGoster.Text = "FORMDA GÖSTER";
            // 
            // menuSil
            // 
            this.menuSil.Image = global::AracServisTakip.Properties.Resources.trash_32x32;
            this.menuSil.Name = "menuSil";
            this.menuSil.Size = new System.Drawing.Size(168, 22);
            this.menuSil.Text = "SİL";
            // 
            // menuExceleAktar
            // 
            this.menuExceleAktar.Image = global::AracServisTakip.Properties.Resources.exporttoxls_32x32;
            this.menuExceleAktar.Name = "menuExceleAktar";
            this.menuExceleAktar.Size = new System.Drawing.Size(168, 22);
            this.menuExceleAktar.Text = "EXCEL E AKTAR";
            // 
            // frmAnaServisIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 711);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAnaServisIslemleri";
            this.Text = "frmAnaServisIslemleri";
            this.Load += new System.EventHandler(this.frmAnaServisIslemleri_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnYeniKayitEkle;
        private DevExpress.XtraEditors.SimpleButton btnDegistir;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnFormdaGoster;
        private System.Windows.Forms.Label lblTarihSaat;
        private System.Windows.Forms.Label lblPcAd;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
        private DevExpress.XtraGrid.GridControl gcListe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListe;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServisId;
        private DevExpress.XtraGrid.Columns.GridColumn col_Tarih;
        private DevExpress.XtraGrid.Columns.GridColumn col_AraciGetiren;
        private DevExpress.XtraGrid.Columns.GridColumn col_AracTeslimTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn col_MusteriAdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn col_MusteriTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn col_AracPlakaNo;
        private DevExpress.XtraGrid.Columns.GridColumn col_AracMarkaModel;
        private DevExpress.XtraGrid.Columns.GridColumn col_AracSasiMotorNo;
        private DevExpress.XtraGrid.Columns.GridColumn col_PersonelAdSoyad;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuYeniKayit;
        private System.Windows.Forms.ToolStripMenuItem menuDegistir;
        private System.Windows.Forms.ToolStripMenuItem menuFormdaGoster;
        private System.Windows.Forms.ToolStripMenuItem menuSil;
        private System.Windows.Forms.ToolStripMenuItem menuExceleAktar;
    }
}