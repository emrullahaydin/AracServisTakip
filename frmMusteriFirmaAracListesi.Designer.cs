namespace AracServisTakip
{
    partial class frmMusteriFirmaAracListesi
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
            this.gcListe = new DevExpress.XtraGrid.GridControl();
            this.gvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id)).BeginInit();
            this.SuspendLayout();
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
            this.gcListe.Size = new System.Drawing.Size(1006, 480);
            this.gcListe.TabIndex = 8;
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
            this.gvListe.DoubleClick += new System.EventHandler(this.gvListe_DoubleClick);
            // 
            // Id
            // 
            this.Id.AutoHeight = false;
            this.Id.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Id.Name = "Id";
            // 
            // frmMusteriFirmaAracListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 480);
            this.Controls.Add(this.gcListe);
            this.Name = "frmMusteriFirmaAracListesi";
            this.Text = "frmMusteriFirmaAracListesi";
            this.Load += new System.EventHandler(this.frmMusteriFirmaAracListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcListe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListe;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Id;
    }
}