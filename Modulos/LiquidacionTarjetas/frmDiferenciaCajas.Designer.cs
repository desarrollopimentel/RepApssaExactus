namespace ApssaExactus
{
    partial class frmDiferenciaCajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiferenciaCajas));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPagePendientes = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lookUpEditCaja = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dpFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.dpFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDiferenciasExportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDiferenciasConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcDiferencias = new DevExpress.XtraGrid.GridControl();
            this.gvDiferencias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FECHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESCRIPCION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAJA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOLAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SALDO_FINAL_LOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SALDO_FINAL_DOL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FLAG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDiferenciasCorregir = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageBrowse = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnValidarFacturas = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargar2Exactus = new DevExpress.XtraEditors.SimpleButton();
            this.chkFacturas = new DevExpress.XtraEditors.CheckEdit();
            this.btnExportarFacturas = new DevExpress.XtraEditors.SimpleButton();
            this.gcFactura = new DevExpress.XtraGrid.GridControl();
            this.gvFactura = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.txtXML_Path = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPagePendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiferencias)).BeginInit();
            this.xtraTabPageBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFacturas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXML_Path.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPagePendientes;
            this.xtraTabControl1.Size = new System.Drawing.Size(924, 627);
            this.xtraTabControl1.TabIndex = 36;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPagePendientes,
            this.xtraTabPageBrowse});
            // 
            // xtraTabPagePendientes
            // 
            this.xtraTabPagePendientes.Controls.Add(this.splitContainerControl3);
            this.xtraTabPagePendientes.Name = "xtraTabPagePendientes";
            this.xtraTabPagePendientes.Size = new System.Drawing.Size(918, 599);
            this.xtraTabPagePendientes.Text = "Cajas";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.lookUpEditCaja);
            this.splitContainerControl3.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl3.Panel1.Controls.Add(this.dpFechaIni);
            this.splitContainerControl3.Panel1.Controls.Add(this.dpFechaFin);
            this.splitContainerControl3.Panel1.Controls.Add(this.label5);
            this.splitContainerControl3.Panel1.Controls.Add(this.label6);
            this.splitContainerControl3.Panel1.Controls.Add(this.btnDiferenciasExportar);
            this.splitContainerControl3.Panel1.Controls.Add(this.btnDiferenciasConsultar);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl3.Panel2.Controls.Add(this.gcDiferencias);
            this.splitContainerControl3.Panel2.Controls.Add(this.btnDiferenciasCorregir);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(918, 599);
            this.splitContainerControl3.SplitterPosition = 34;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // lookUpEditCaja
            // 
            this.lookUpEditCaja.Location = new System.Drawing.Point(478, 7);
            this.lookUpEditCaja.Name = "lookUpEditCaja";
            this.lookUpEditCaja.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookUpEditCaja.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCaja.Properties.NullText = "[Vacío]";
            this.lookUpEditCaja.Size = new System.Drawing.Size(169, 20);
            this.lookUpEditCaja.TabIndex = 101;
            this.lookUpEditCaja.ToolTip = "Seleccionar Caja";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(439, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 100;
            this.labelControl2.Text = "Caja";
            // 
            // dpFechaIni
            // 
            this.dpFechaIni.EditValue = null;
            this.dpFechaIni.Location = new System.Drawing.Point(84, 8);
            this.dpFechaIni.Name = "dpFechaIni";
            this.dpFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Size = new System.Drawing.Size(104, 20);
            this.dpFechaIni.TabIndex = 99;
            // 
            // dpFechaFin
            // 
            this.dpFechaFin.EditValue = null;
            this.dpFechaFin.Location = new System.Drawing.Point(285, 8);
            this.dpFechaFin.Name = "dpFechaFin";
            this.dpFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Size = new System.Drawing.Size(104, 20);
            this.dpFechaFin.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Fecha Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Fecha Inicial";
            // 
            // btnDiferenciasExportar
            // 
            this.btnDiferenciasExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiferenciasExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnDiferenciasExportar.Image")));
            this.btnDiferenciasExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDiferenciasExportar.Location = new System.Drawing.Point(707, 6);
            this.btnDiferenciasExportar.Name = "btnDiferenciasExportar";
            this.btnDiferenciasExportar.Size = new System.Drawing.Size(92, 23);
            this.btnDiferenciasExportar.TabIndex = 92;
            this.btnDiferenciasExportar.Text = "Exportar";
            this.btnDiferenciasExportar.Click += new System.EventHandler(this.btnDiferenciasExportar_Click);
            // 
            // btnDiferenciasConsultar
            // 
            this.btnDiferenciasConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiferenciasConsultar.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnDiferenciasConsultar.Appearance.Options.UseForeColor = true;
            this.btnDiferenciasConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnDiferenciasConsultar.Image")));
            this.btnDiferenciasConsultar.Location = new System.Drawing.Point(818, 4);
            this.btnDiferenciasConsultar.Name = "btnDiferenciasConsultar";
            this.btnDiferenciasConsultar.Size = new System.Drawing.Size(90, 25);
            this.btnDiferenciasConsultar.TabIndex = 83;
            this.btnDiferenciasConsultar.Text = "&Consultar";
            this.btnDiferenciasConsultar.Click += new System.EventHandler(this.btnDiferenciasConsultar_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(42, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 97;
            this.labelControl3.Text = "Procesar";
            // 
            // gcDiferencias
            // 
            this.gcDiferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDiferencias.Location = new System.Drawing.Point(11, 30);
            this.gcDiferencias.MainView = this.gvDiferencias;
            this.gcDiferencias.Name = "gcDiferencias";
            this.gcDiferencias.Size = new System.Drawing.Size(897, 489);
            this.gcDiferencias.TabIndex = 96;
            this.gcDiferencias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDiferencias});
            // 
            // gvDiferencias
            // 
            this.gvDiferencias.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FECHA,
            this.DESCRIPCION,
            this.CAJA,
            this.SOLES,
            this.DOLAR,
            this.SALDO_FINAL_LOC,
            this.SALDO_FINAL_DOL,
            this.FLAG});
            this.gvDiferencias.GridControl = this.gcDiferencias;
            this.gvDiferencias.Name = "gvDiferencias";
            this.gvDiferencias.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDiferencias.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvDiferencias.OptionsSelection.MultiSelect = true;
            this.gvDiferencias.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDiferencias.OptionsSelection.UseIndicatorForSelection = false;
            this.gvDiferencias.OptionsView.ShowGroupPanel = false;
            // 
            // FECHA
            // 
            this.FECHA.Caption = "FECHA";
            this.FECHA.FieldName = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.Visible = true;
            this.FECHA.VisibleIndex = 1;
            this.FECHA.Width = 102;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.Caption = "DESCRIPCION";
            this.DESCRIPCION.FieldName = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.Visible = true;
            this.DESCRIPCION.VisibleIndex = 2;
            this.DESCRIPCION.Width = 200;
            // 
            // CAJA
            // 
            this.CAJA.Caption = "CAJA";
            this.CAJA.FieldName = "CAJA";
            this.CAJA.Name = "CAJA";
            this.CAJA.Visible = true;
            this.CAJA.VisibleIndex = 3;
            this.CAJA.Width = 58;
            // 
            // SOLES
            // 
            this.SOLES.Caption = "SOLES";
            this.SOLES.FieldName = "SOLES";
            this.SOLES.Name = "SOLES";
            this.SOLES.Visible = true;
            this.SOLES.VisibleIndex = 4;
            this.SOLES.Width = 96;
            // 
            // DOLAR
            // 
            this.DOLAR.Caption = "DOLAR";
            this.DOLAR.FieldName = "DOLAR";
            this.DOLAR.Name = "DOLAR";
            this.DOLAR.Visible = true;
            this.DOLAR.VisibleIndex = 5;
            this.DOLAR.Width = 100;
            // 
            // SALDO_FINAL_LOC
            // 
            this.SALDO_FINAL_LOC.Caption = "SALDO_FINAL_LOC";
            this.SALDO_FINAL_LOC.FieldName = "SALDO_FINAL_LOC";
            this.SALDO_FINAL_LOC.Name = "SALDO_FINAL_LOC";
            this.SALDO_FINAL_LOC.Visible = true;
            this.SALDO_FINAL_LOC.VisibleIndex = 6;
            this.SALDO_FINAL_LOC.Width = 94;
            // 
            // SALDO_FINAL_DOL
            // 
            this.SALDO_FINAL_DOL.Caption = "SALDO_FINAL_DOL";
            this.SALDO_FINAL_DOL.FieldName = "SALDO_FINAL_DOL";
            this.SALDO_FINAL_DOL.Name = "SALDO_FINAL_DOL";
            this.SALDO_FINAL_DOL.Visible = true;
            this.SALDO_FINAL_DOL.VisibleIndex = 7;
            this.SALDO_FINAL_DOL.Width = 94;
            // 
            // FLAG
            // 
            this.FLAG.Caption = "FLAG";
            this.FLAG.FieldName = "FLAG";
            this.FLAG.Name = "FLAG";
            this.FLAG.Visible = true;
            this.FLAG.VisibleIndex = 8;
            this.FLAG.Width = 60;
            // 
            // btnDiferenciasCorregir
            // 
            this.btnDiferenciasCorregir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiferenciasCorregir.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnDiferenciasCorregir.Appearance.Options.UseForeColor = true;
            this.btnDiferenciasCorregir.Image = ((System.Drawing.Image)(resources.GetObject("btnDiferenciasCorregir.Image")));
            this.btnDiferenciasCorregir.Location = new System.Drawing.Point(15, 528);
            this.btnDiferenciasCorregir.Name = "btnDiferenciasCorregir";
            this.btnDiferenciasCorregir.Size = new System.Drawing.Size(106, 23);
            this.btnDiferenciasCorregir.TabIndex = 95;
            this.btnDiferenciasCorregir.Text = "&Corregir";
            this.btnDiferenciasCorregir.Click += new System.EventHandler(this.btnDiferenciasCorregir_Click);
            // 
            // xtraTabPageBrowse
            // 
            this.xtraTabPageBrowse.Controls.Add(this.splitContainerControl1);
            this.xtraTabPageBrowse.Name = "xtraTabPageBrowse";
            this.xtraTabPageBrowse.PageEnabled = false;
            this.xtraTabPageBrowse.Size = new System.Drawing.Size(918, 599);
            this.xtraTabPageBrowse.Text = "~";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcFactura);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(918, 599);
            this.splitContainerControl1.SplitterPosition = 46;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnValidarFacturas);
            this.groupControl2.Controls.Add(this.btnCargar2Exactus);
            this.groupControl2.Controls.Add(this.chkFacturas);
            this.groupControl2.Controls.Add(this.btnExportarFacturas);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(918, 46);
            this.groupControl2.TabIndex = 86;
            this.groupControl2.Text = "groupControl2";
            // 
            // btnValidarFacturas
            // 
            this.btnValidarFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidarFacturas.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnValidarFacturas.Appearance.Options.UseForeColor = true;
            this.btnValidarFacturas.Image = ((System.Drawing.Image)(resources.GetObject("btnValidarFacturas.Image")));
            this.btnValidarFacturas.Location = new System.Drawing.Point(629, 11);
            this.btnValidarFacturas.Name = "btnValidarFacturas";
            this.btnValidarFacturas.Size = new System.Drawing.Size(90, 25);
            this.btnValidarFacturas.TabIndex = 95;
            this.btnValidarFacturas.Text = "&Validar";
            // 
            // btnCargar2Exactus
            // 
            this.btnCargar2Exactus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar2Exactus.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnCargar2Exactus.Appearance.Options.UseForeColor = true;
            this.btnCargar2Exactus.Location = new System.Drawing.Point(821, 11);
            this.btnCargar2Exactus.Name = "btnCargar2Exactus";
            this.btnCargar2Exactus.Size = new System.Drawing.Size(90, 25);
            this.btnCargar2Exactus.TabIndex = 82;
            this.btnCargar2Exactus.Text = "&Cargar a Exactus";
            // 
            // chkFacturas
            // 
            this.chkFacturas.Location = new System.Drawing.Point(26, 17);
            this.chkFacturas.Name = "chkFacturas";
            this.chkFacturas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFacturas.Properties.Appearance.Options.UseFont = true;
            this.chkFacturas.Properties.Caption = "Procesar Todos";
            this.chkFacturas.Size = new System.Drawing.Size(110, 19);
            this.chkFacturas.TabIndex = 84;
            // 
            // btnExportarFacturas
            // 
            this.btnExportarFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarFacturas.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarFacturas.Image")));
            this.btnExportarFacturas.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarFacturas.Location = new System.Drawing.Point(725, 11);
            this.btnExportarFacturas.Name = "btnExportarFacturas";
            this.btnExportarFacturas.Size = new System.Drawing.Size(90, 25);
            this.btnExportarFacturas.TabIndex = 81;
            this.btnExportarFacturas.Text = "Exportar";
            // 
            // gcFactura
            // 
            this.gcFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFactura.Location = new System.Drawing.Point(7, 14);
            this.gcFactura.MainView = this.gvFactura;
            this.gcFactura.Name = "gcFactura";
            this.gcFactura.Size = new System.Drawing.Size(906, 522);
            this.gcFactura.TabIndex = 4;
            this.gcFactura.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFactura});
            // 
            // gvFactura
            // 
            this.gvFactura.GridControl = this.gcFactura;
            this.gvFactura.Name = "gvFactura";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(16, 577);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 23);
            this.simpleButton5.TabIndex = 40;
            this.simpleButton5.Text = "simpleButton5";
            this.simpleButton5.Visible = false;
            // 
            // txtXML_Path
            // 
            this.txtXML_Path.Location = new System.Drawing.Point(12, 580);
            this.txtXML_Path.Name = "txtXML_Path";
            this.txtXML_Path.Size = new System.Drawing.Size(223, 20);
            this.txtXML_Path.TabIndex = 83;
            this.txtXML_Path.Visible = false;
            // 
            // frmDiferenciaCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 627);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.txtXML_Path);
            this.Name = "frmDiferenciaCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diferencia Cajas";
            this.Load += new System.EventHandler(this.frmDiferenciaCajas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPagePendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiferencias)).EndInit();
            this.xtraTabPageBrowse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkFacturas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXML_Path.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageBrowse;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.TextEdit txtXML_Path;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnCargar2Exactus;
        private DevExpress.XtraEditors.SimpleButton btnExportarFacturas;
        private DevExpress.XtraGrid.GridControl gcFactura;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFactura;
        private DevExpress.XtraEditors.CheckEdit chkFacturas;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnValidarFacturas;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePendientes;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.SimpleButton btnDiferenciasConsultar;
        private DevExpress.XtraEditors.SimpleButton btnDiferenciasExportar;
        private DevExpress.XtraEditors.SimpleButton btnDiferenciasCorregir;
        private DevExpress.XtraEditors.DateEdit dpFechaIni;
        private DevExpress.XtraEditors.DateEdit dpFechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lookUpEditCaja;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcDiferencias;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDiferencias;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPCION;
        private DevExpress.XtraGrid.Columns.GridColumn FECHA;
        private DevExpress.XtraGrid.Columns.GridColumn CAJA;
        private DevExpress.XtraGrid.Columns.GridColumn FLAG;
        private DevExpress.XtraGrid.Columns.GridColumn SALDO_FINAL_LOC;
        private DevExpress.XtraGrid.Columns.GridColumn SOLES;
        private DevExpress.XtraGrid.Columns.GridColumn DOLAR;
        private DevExpress.XtraGrid.Columns.GridColumn SALDO_FINAL_DOL;
    }
}