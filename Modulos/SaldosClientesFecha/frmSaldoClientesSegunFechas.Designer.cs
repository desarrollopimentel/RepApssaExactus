namespace ApssaExactus
{
    partial class frmSaldoClientesSegunFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldoClientesSegunFecha));
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.dpFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.dpFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageCtaCte = new DevExpress.XtraTab.XtraTabPage();
            this.gcDocumentos = new DevExpress.XtraGrid.GridControl();
            this.gvDocumentos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.labelRangoFechas = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageCtaCte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(969, 9);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(103, 23);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.ToolTip = "Actualizar Informacion";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dpFechaFin
            // 
            this.dpFechaFin.EditValue = null;
            this.dpFechaFin.Location = new System.Drawing.Point(119, 15);
            this.dpFechaFin.Name = "dpFechaFin";
            this.dpFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Size = new System.Drawing.Size(85, 20);
            this.dpFechaFin.TabIndex = 64;
            // 
            // dpFechaIni
            // 
            this.dpFechaIni.EditValue = null;
            this.dpFechaIni.Location = new System.Drawing.Point(28, 15);
            this.dpFechaIni.Name = "dpFechaIni";
            this.dpFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Size = new System.Drawing.Size(85, 20);
            this.dpFechaIni.TabIndex = 63;
            this.dpFechaIni.Visible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(-2, 42);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageCtaCte;
            this.xtraTabControl1.Size = new System.Drawing.Size(1074, 567);
            this.xtraTabControl1.TabIndex = 69;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageCtaCte});
            // 
            // xtraTabPageCtaCte
            // 
            this.xtraTabPageCtaCte.Controls.Add(this.gcDocumentos);
            this.xtraTabPageCtaCte.Name = "xtraTabPageCtaCte";
            this.xtraTabPageCtaCte.Size = new System.Drawing.Size(1068, 539);
            this.xtraTabPageCtaCte.Text = "Saldos";
            // 
            // gcDocumentos
            // 
            this.gcDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDocumentos.Location = new System.Drawing.Point(10, 3);
            this.gcDocumentos.MainView = this.gvDocumentos;
            this.gcDocumentos.Name = "gcDocumentos";
            this.gcDocumentos.Size = new System.Drawing.Size(1062, 533);
            this.gcDocumentos.TabIndex = 1;
            this.gcDocumentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocumentos});
            // 
            // gvDocumentos
            // 
            this.gvDocumentos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvDocumentos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.gvDocumentos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvDocumentos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvDocumentos.Appearance.SelectedRow.BackColor = System.Drawing.Color.SkyBlue;
            this.gvDocumentos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDocumentos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDocumentos.GridControl = this.gcDocumentos;
            this.gvDocumentos.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvDocumentos.Name = "gvDocumentos";
            this.gvDocumentos.OptionsView.EnableAppearanceEvenRow = true;
            this.gvDocumentos.OptionsView.ShowGroupPanel = false;
            this.gvDocumentos.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Location = new System.Drawing.Point(847, 9);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(103, 23);
            this.btnExportar.TabIndex = 70;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.ToolTip = "Actualizar Informacion";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // labelRangoFechas
            // 
            this.labelRangoFechas.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelRangoFechas.Appearance.Options.UseFont = true;
            this.labelRangoFechas.Location = new System.Drawing.Point(17, 18);
            this.labelRangoFechas.Name = "labelRangoFechas";
            this.labelRangoFechas.Size = new System.Drawing.Size(91, 14);
            this.labelRangoFechas.TabIndex = 61;
            this.labelRangoFechas.Text = "Fecha de Corte";
            // 
            // frmSaldoClientesSegunFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.labelRangoFechas);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dpFechaFin);
            this.Controls.Add(this.dpFechaIni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 650);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(868, 610);
            this.Name = "frmSaldoClientesSegunFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldo de Clientes a una Fecha";
            this.Load += new System.EventHandler(this.frmSaldoClientesSegunFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageCtaCte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.DateEdit dpFechaFin;
        private DevExpress.XtraEditors.DateEdit dpFechaIni;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCtaCte;
        private DevExpress.XtraGrid.GridControl gcDocumentos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumentos;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.LabelControl labelRangoFechas;
    }
}