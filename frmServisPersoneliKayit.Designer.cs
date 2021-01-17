namespace AracServisTakip
{
    partial class frmServisPersoneliKayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServisPersoneliKayit));
            this.Id = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gcListe = new DevExpress.XtraGrid.GridControl();
            this.gvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPersonelId = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefonNo = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonelAdSoyad = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Id)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdSoyad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Id
            // 
            this.Id.AutoHeight = false;
            this.Id.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Id.Name = "Id";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gcListe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 290);
            this.panel2.TabIndex = 13;
            // 
            // gcListe
            // 
            this.gcListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListe.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcListe.Location = new System.Drawing.Point(0, 0);
            this.gcListe.MainView = this.gvListe;
            this.gcListe.Name = "gcListe";
            this.gcListe.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Id});
            this.gcListe.Size = new System.Drawing.Size(671, 290);
            this.gcListe.TabIndex = 7;
            this.gcListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListe});
            // 
            // gvListe
            // 
            this.gvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvListe.GridControl = this.gcListe;
            this.gvListe.Name = "gvListe";
            this.gvListe.OptionsBehavior.Editable = false;
            this.gvListe.OptionsView.ShowFooter = true;
            this.gvListe.OptionsView.ShowGroupPanel = false;
            this.gvListe.Click += new System.EventHandler(this.gvListe_Click);
            // 
            // btnListele
            // 
            this.btnListele.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListele.ImageOptions.Image")));
            this.btnListele.Location = new System.Drawing.Point(424, 128);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(240, 45);
            this.btnListele.TabIndex = 17;
            this.btnListele.Text = "LİSTELE";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // btnExceleAktar
            // 
            this.btnExceleAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExceleAktar.ImageOptions.Image")));
            this.btnExceleAktar.Location = new System.Drawing.Point(424, 179);
            this.btnExceleAktar.Name = "btnExceleAktar";
            this.btnExceleAktar.Size = new System.Drawing.Size(240, 45);
            this.btnExceleAktar.TabIndex = 16;
            this.btnExceleAktar.Text = "EXCEL E AKTAR";
            this.btnExceleAktar.Click += new System.EventHandler(this.btnExceleAktar_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTemizle.ImageOptions.Image")));
            this.btnTemizle.Location = new System.Drawing.Point(546, 66);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(118, 51);
            this.btnTemizle.TabIndex = 14;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(423, 66);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(118, 51);
            this.btnSil.TabIndex = 12;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(424, 9);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(240, 51);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "KAYDET && GÜNCELLE";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnListele);
            this.panel1.Controls.Add(this.btnExceleAktar);
            this.panel1.Controls.Add(this.btnTemizle);
            this.panel1.Controls.Add(this.btnSil);
            this.panel1.Controls.Add(this.btnKaydet);
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 234);
            this.panel1.TabIndex = 12;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtPersonelId);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtTelefonNo);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtPersonelAdSoyad);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(414, 221);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Servis Personel Bilgileri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(105, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label7.Location = new System.Drawing.Point(11, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Personel ID";
            // 
            // txtPersonelId
            // 
            this.txtPersonelId.Location = new System.Drawing.Point(123, 47);
            this.txtPersonelId.Name = "txtPersonelId";
            this.txtPersonelId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPersonelId.Properties.Appearance.Options.UseFont = true;
            this.txtPersonelId.Size = new System.Drawing.Size(214, 26);
            this.txtPersonelId.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(105, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label10.Location = new System.Drawing.Point(105, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = ":";
            // 
            // txtTelefonNo
            // 
            this.txtTelefonNo.Location = new System.Drawing.Point(123, 167);
            this.txtTelefonNo.Name = "txtTelefonNo";
            this.txtTelefonNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTelefonNo.Properties.Appearance.Options.UseFont = true;
            this.txtTelefonNo.Properties.Mask.EditMask = "\\d (\\d?\\d?\\d?) \\d\\d\\d \\d\\d \\d\\d";
            this.txtTelefonNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtTelefonNo.Size = new System.Drawing.Size(214, 26);
            this.txtTelefonNo.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label8.Location = new System.Drawing.Point(11, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Telefon No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(11, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad Soyad";
            // 
            // txtPersonelAdSoyad
            // 
            this.txtPersonelAdSoyad.Location = new System.Drawing.Point(123, 105);
            this.txtPersonelAdSoyad.Name = "txtPersonelAdSoyad";
            this.txtPersonelAdSoyad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPersonelAdSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtPersonelAdSoyad.Size = new System.Drawing.Size(214, 26);
            this.txtPersonelAdSoyad.TabIndex = 1;
            // 
            // frmServisPersoneliKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServisPersoneliKayit";
            this.Text = "Servis Personeli Kayit && Güncelle";
            this.Load += new System.EventHandler(this.frmServisPersoneliKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Id)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdSoyad.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Id;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gcListe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListe;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtPersonelId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtTelefonNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtPersonelAdSoyad;
    }
}