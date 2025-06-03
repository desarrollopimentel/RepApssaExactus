namespace ApssaExactus
{
    partial class frm_InventarioAuditoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_InventarioAuditoria));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcGuias = new DevExpress.XtraGrid.GridControl();
            this.gvGuias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboMoneda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoFecha = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dpFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombreUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.dpFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.cboZona = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cboTienda = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Location = new System.Drawing.Point(222, 12);
            this.groupControl1.MaximumSize = new System.Drawing.Size(0, 60);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(0, 51);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "GRE";
            // 
            // gcGuias
            // 
            this.gcGuias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcGuias.Location = new System.Drawing.Point(3, 3);
            this.gcGuias.MainView = this.gvGuias;
            this.gcGuias.Name = "gcGuias";
            this.gcGuias.Size = new System.Drawing.Size(1066, 519);
            this.gcGuias.TabIndex = 0;
            this.gcGuias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGuias});
            // 
            // gvGuias
            // 
            this.gvGuias.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvGuias.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvGuias.GridControl = this.gcGuias;
            this.gvGuias.Name = "gvGuias";
            this.gvGuias.OptionsFind.FindNullPrompt = "Ingrese el texto a buscar";
            this.gvGuias.OptionsView.ShowGroupPanel = false;
            this.gvGuias.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGuias_FocusedRowChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1084, 643);
            this.splitContainerControl1.SplitterPosition = 81;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage3;
            this.xtraTabControl2.Size = new System.Drawing.Size(1084, 81);
            this.xtraTabControl2.TabIndex = 71;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage3});
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.groupControl2);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1078, 53);
            this.xtraTabPage3.Text = "Rango Fechas";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.cboMoneda);
            this.groupControl2.Controls.Add(this.cboTipoFecha);
            this.groupControl2.Controls.Add(this.dpFechaFin);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Controls.Add(this.txtNombreUsuario);
            this.groupControl2.Controls.Add(this.txtUsuario);
            this.groupControl2.Controls.Add(this.btnExportar);
            this.groupControl2.Controls.Add(this.btnActualizar);
            this.groupControl2.Controls.Add(this.dpFechaIni);
            this.groupControl2.Controls.Add(this.cboZona);
            this.groupControl2.Controls.Add(this.cboTienda);
            this.groupControl2.Controls.Add(this.labelControl16);
            this.groupControl2.Controls.Add(this.labelControl17);
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(1078, 51);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "groupControl2";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(479, 15);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.Items.AddRange(new object[] {
            "Dolar",
            "Local"});
            this.cboMoneda.Size = new System.Drawing.Size(133, 20);
            this.cboMoneda.TabIndex = 75;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(435, 22);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 76;
            this.labelControl5.Text = "Moneda";
            // 
            // cboTipoFecha
            // 
            this.cboTipoFecha.Location = new System.Drawing.Point(264, 15);
            this.cboTipoFecha.Name = "cboTipoFecha";
            this.cboTipoFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoFecha.Properties.Items.AddRange(new object[] {
            "Documento",
            "Auditoria"});
            this.cboTipoFecha.Size = new System.Drawing.Size(133, 20);
            this.cboTipoFecha.TabIndex = 73;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(199, 22);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 74;
            this.labelControl4.Text = "Tipo Fecha";
            // 
            // dpFechaFin
            // 
            this.dpFechaFin.EditValue = null;
            this.dpFechaFin.Location = new System.Drawing.Point(75, 15);
            this.dpFechaFin.Name = "dpFechaFin";
            this.dpFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Size = new System.Drawing.Size(112, 20);
            this.dpFechaFin.TabIndex = 68;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(10, 22);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(59, 13);
            this.labelControl10.TabIndex = 66;
            this.labelControl10.Text = "Fecha Corte";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(419, 3);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtNombreUsuario.TabIndex = 72;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(264, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 71;
            // 
            // btnExportar
            // 
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(804, 13);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(117, 22);
            this.btnExportar.TabIndex = 70;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(927, 13);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 22);
            this.btnActualizar.TabIndex = 69;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dpFechaIni
            // 
            this.dpFechaIni.EditValue = null;
            this.dpFechaIni.Location = new System.Drawing.Point(75, 3);
            this.dpFechaIni.Name = "dpFechaIni";
            this.dpFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Size = new System.Drawing.Size(104, 20);
            this.dpFechaIni.TabIndex = 67;
            this.dpFechaIni.Visible = false;
            // 
            // cboZona
            // 
            this.cboZona.Location = new System.Drawing.Point(638, 15);
            this.cboZona.Name = "cboZona";
            this.cboZona.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboZona.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboZona.Size = new System.Drawing.Size(133, 20);
            this.cboZona.TabIndex = 65;
            this.cboZona.Visible = false;
            this.cboZona.EditValueChanged += new System.EventHandler(this.cboZona_EditValueChanged);
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(639, 15);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboTienda.Size = new System.Drawing.Size(132, 20);
            this.cboTienda.TabIndex = 64;
            this.cboTienda.Visible = false;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(601, 22);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(32, 13);
            this.labelControl16.TabIndex = 63;
            this.labelControl16.Text = "Tienda";
            this.labelControl16.Visible = false;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(607, 22);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(24, 13);
            this.labelControl17.TabIndex = 62;
            this.labelControl17.Text = "Zona";
            this.labelControl17.Visible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1084, 557);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcGuias);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1078, 529);
            this.xtraTabPage1.Text = "Inventarios";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1078, 529);
            this.xtraTabPage2.Text = "~";
            // 
            // frm_InventarioAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 643);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frm_InventarioAuditoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventarios - Auditoria";
            this.Load += new System.EventHandler(this.frm_ObtenerGRE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcGuias;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGuias;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.DateEdit dpFechaFin;
        private DevExpress.XtraEditors.DateEdit dpFechaIni;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboZona;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.TextEdit txtNombreUsuario;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoFecha;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}