namespace ApssaExactus
{
    partial class frmValidacionDocumentosFE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidacionDocumentosFE));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageExcel = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtNombreUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcExcel = new DevExpress.XtraGrid.GridControl();
            this.gvExcel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PROVEEDOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CODIGO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SERIE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NUMERO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FECHA_EMISION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MONTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALIDACION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnValidarXls = new DevExpress.XtraEditors.SimpleButton();
            this.btnProcesarXls = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportarXls = new DevExpress.XtraEditors.SimpleButton();
            this.txtTipoCarga = new DevExpress.XtraEditors.TextEdit();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnConsultaCPE = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerarToken = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLoadXls = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboHojas = new System.Windows.Forms.ComboBox();
            this.btnBuscar_Xls = new System.Windows.Forms.Button();
            this.txtPathXls = new System.Windows.Forms.TextBox();
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
            this.xtraTabPageExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCarga.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageExcel;
            this.xtraTabControl1.Size = new System.Drawing.Size(1274, 766);
            this.xtraTabControl1.TabIndex = 36;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageExcel,
            this.xtraTabPageBrowse});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabControl1.Click += new System.EventHandler(this.xtraTabControl1_Click);
            // 
            // xtraTabPageExcel
            // 
            this.xtraTabPageExcel.Controls.Add(this.xtraTabControl2);
            this.xtraTabPageExcel.Controls.Add(this.groupControl1);
            this.xtraTabPageExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPageExcel.Name = "xtraTabPageExcel";
            this.xtraTabPageExcel.Size = new System.Drawing.Size(1267, 732);
            this.xtraTabPageExcel.Text = "Carga Excel";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl2.Location = new System.Drawing.Point(8, 64);
            this.xtraTabControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl2.Size = new System.Drawing.Size(1251, 658);
            this.xtraTabControl2.TabIndex = 2;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtNombreUsuario);
            this.xtraTabPage1.Controls.Add(this.txtUsuario);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.gcExcel);
            this.xtraTabPage1.Controls.Add(this.btnValidarXls);
            this.xtraTabPage1.Controls.Add(this.btnProcesarXls);
            this.xtraTabPage1.Controls.Add(this.btnExportarXls);
            this.xtraTabPage1.Controls.Add(this.txtTipoCarga);
            this.xtraTabPage1.Controls.Add(this.btnGrabar);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1244, 624);
            this.xtraTabPage1.Text = "Documentos";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Enabled = false;
            this.txtNombreUsuario.Location = new System.Drawing.Point(638, 10);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(231, 22);
            this.txtNombreUsuario.TabIndex = 98;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(514, 10);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(117, 22);
            this.txtUsuario.TabIndex = 97;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(42, 32);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 17);
            this.labelControl3.TabIndex = 95;
            this.labelControl3.Text = "Procesar";
            // 
            // gcExcel
            // 
            this.gcExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcExcel.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcExcel.Location = new System.Drawing.Point(6, 52);
            this.gcExcel.MainView = this.gvExcel;
            this.gcExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcExcel.Name = "gcExcel";
            this.gcExcel.Size = new System.Drawing.Size(1232, 566);
            this.gcExcel.TabIndex = 94;
            this.gcExcel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExcel});
            // 
            // gvExcel
            // 
            this.gvExcel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PROVEEDOR,
            this.CODIGO,
            this.SERIE,
            this.NUMERO,
            this.FECHA_EMISION,
            this.MONTO,
            this.VALIDACION});
            this.gvExcel.GridControl = this.gcExcel;
            this.gvExcel.Name = "gvExcel";
            this.gvExcel.OptionsClipboard.ShowProgress = DevExpress.Export.ProgressMode.Always;
            this.gvExcel.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvExcel.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvExcel.OptionsSelection.MultiSelect = true;
            this.gvExcel.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvExcel.OptionsSelection.UseIndicatorForSelection = false;
            this.gvExcel.OptionsView.ShowGroupPanel = false;
            // 
            // PROVEEDOR
            // 
            this.PROVEEDOR.Caption = "PROVEEDOR";
            this.PROVEEDOR.FieldName = "PROVEEDOR";
            this.PROVEEDOR.Name = "PROVEEDOR";
            this.PROVEEDOR.Visible = true;
            this.PROVEEDOR.VisibleIndex = 1;
            this.PROVEEDOR.Width = 131;
            // 
            // CODIGO
            // 
            this.CODIGO.Caption = "CODIGO";
            this.CODIGO.FieldName = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.Visible = true;
            this.CODIGO.VisibleIndex = 2;
            this.CODIGO.Width = 127;
            // 
            // SERIE
            // 
            this.SERIE.Caption = "SERIE";
            this.SERIE.FieldName = "SERIE";
            this.SERIE.Name = "SERIE";
            this.SERIE.Visible = true;
            this.SERIE.VisibleIndex = 3;
            this.SERIE.Width = 94;
            // 
            // NUMERO
            // 
            this.NUMERO.Caption = "NUMERO";
            this.NUMERO.FieldName = "NUMERO";
            this.NUMERO.Name = "NUMERO";
            this.NUMERO.Visible = true;
            this.NUMERO.VisibleIndex = 4;
            this.NUMERO.Width = 87;
            // 
            // FECHA_EMISION
            // 
            this.FECHA_EMISION.Caption = "FEC.EMISION";
            this.FECHA_EMISION.FieldName = "FECHA_EMISION";
            this.FECHA_EMISION.Name = "FECHA_EMISION";
            this.FECHA_EMISION.Visible = true;
            this.FECHA_EMISION.VisibleIndex = 5;
            this.FECHA_EMISION.Width = 87;
            // 
            // MONTO
            // 
            this.MONTO.Caption = "MONTO";
            this.MONTO.FieldName = "MONTO";
            this.MONTO.Name = "MONTO";
            this.MONTO.Visible = true;
            this.MONTO.VisibleIndex = 6;
            this.MONTO.Width = 87;
            // 
            // VALIDACION
            // 
            this.VALIDACION.Caption = "VALIDACION";
            this.VALIDACION.FieldName = "VALIDACION";
            this.VALIDACION.MinWidth = 100;
            this.VALIDACION.Name = "VALIDACION";
            this.VALIDACION.Visible = true;
            this.VALIDACION.VisibleIndex = 7;
            this.VALIDACION.Width = 350;
            // 
            // btnValidarXls
            // 
            this.btnValidarXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidarXls.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnValidarXls.Appearance.Options.UseForeColor = true;
            this.btnValidarXls.Image = ((System.Drawing.Image)(resources.GetObject("btnValidarXls.Image")));
            this.btnValidarXls.Location = new System.Drawing.Point(899, 14);
            this.btnValidarXls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnValidarXls.Name = "btnValidarXls";
            this.btnValidarXls.Size = new System.Drawing.Size(105, 31);
            this.btnValidarXls.TabIndex = 93;
            this.btnValidarXls.Text = "&Validar";
            this.btnValidarXls.Click += new System.EventHandler(this.btnValidarXls_Click);
            // 
            // btnProcesarXls
            // 
            this.btnProcesarXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesarXls.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnProcesarXls.Appearance.Options.UseForeColor = true;
            this.btnProcesarXls.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesarXls.Image")));
            this.btnProcesarXls.Location = new System.Drawing.Point(1123, 14);
            this.btnProcesarXls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProcesarXls.Name = "btnProcesarXls";
            this.btnProcesarXls.Size = new System.Drawing.Size(105, 31);
            this.btnProcesarXls.TabIndex = 92;
            this.btnProcesarXls.Text = "&Procesar";
            this.btnProcesarXls.Click += new System.EventHandler(this.btnProcesarXls_Click);
            // 
            // btnExportarXls
            // 
            this.btnExportarXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarXls.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarXls.Image")));
            this.btnExportarXls.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarXls.Location = new System.Drawing.Point(1011, 14);
            this.btnExportarXls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportarXls.Name = "btnExportarXls";
            this.btnExportarXls.Size = new System.Drawing.Size(105, 31);
            this.btnExportarXls.TabIndex = 91;
            this.btnExportarXls.Text = "Exportar";
            this.btnExportarXls.Click += new System.EventHandler(this.btnExportarXls_Click);
            // 
            // txtTipoCarga
            // 
            this.txtTipoCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTipoCarga.Location = new System.Drawing.Point(19, 302);
            this.txtTipoCarga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTipoCarga.Name = "txtTipoCarga";
            this.txtTipoCarga.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoCarga.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTipoCarga.Properties.Appearance.Options.UseBackColor = true;
            this.txtTipoCarga.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCarga.Size = new System.Drawing.Size(142, 24);
            this.txtTipoCarga.TabIndex = 90;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.Location = new System.Drawing.Point(1151, 300);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(86, 28);
            this.btnGrabar.TabIndex = 54;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.ToolTip = "Grabar Cuotas de Ventas";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(1244, 624);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnConsultaCPE);
            this.groupControl1.Controls.Add(this.btnGenerarToken);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnLoadXls);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.cboHojas);
            this.groupControl1.Controls.Add(this.btnBuscar_Xls);
            this.groupControl1.Controls.Add(this.txtPathXls);
            this.groupControl1.Location = new System.Drawing.Point(9, 5);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1249, 52);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Cargar Archivo de Excel   -->  Columnas   TIPO,  FACTURA";
            // 
            // btnConsultaCPE
            // 
            this.btnConsultaCPE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultaCPE.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnConsultaCPE.Appearance.Options.UseForeColor = true;
            this.btnConsultaCPE.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultaCPE.Image")));
            this.btnConsultaCPE.Location = new System.Drawing.Point(996, 7);
            this.btnConsultaCPE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultaCPE.Name = "btnConsultaCPE";
            this.btnConsultaCPE.Size = new System.Drawing.Size(105, 31);
            this.btnConsultaCPE.TabIndex = 98;
            this.btnConsultaCPE.Text = "&Consultar";
            this.btnConsultaCPE.Click += new System.EventHandler(this.btnConsultaCPE_Click);
            // 
            // btnGenerarToken
            // 
            this.btnGenerarToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarToken.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnGenerarToken.Appearance.Options.UseForeColor = true;
            this.btnGenerarToken.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarToken.Image")));
            this.btnGenerarToken.Location = new System.Drawing.Point(876, 7);
            this.btnGenerarToken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerarToken.Name = "btnGenerarToken";
            this.btnGenerarToken.Size = new System.Drawing.Size(105, 31);
            this.btnGenerarToken.TabIndex = 97;
            this.btnGenerarToken.Text = "&TOKEN";
            this.btnGenerarToken.Click += new System.EventHandler(this.btnGenerarToken_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(899, 9);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(0, 37);
            this.labelControl4.TabIndex = 96;
            this.labelControl4.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(587, 22);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 17);
            this.labelControl2.TabIndex = 74;
            this.labelControl2.Text = "Hoja";
            // 
            // btnLoadXls
            // 
            this.btnLoadXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadXls.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadXls.Image")));
            this.btnLoadXls.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnLoadXls.Location = new System.Drawing.Point(1121, 9);
            this.btnLoadXls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadXls.Name = "btnLoadXls";
            this.btnLoadXls.Size = new System.Drawing.Size(105, 31);
            this.btnLoadXls.TabIndex = 73;
            this.btnLoadXls.Text = "&Cargar Excel";
            this.btnLoadXls.ToolTip = "Exportar a Excel";
            this.btnLoadXls.Click += new System.EventHandler(this.btnLoadXls_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(20, 22);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(91, 17);
            this.labelControl6.TabIndex = 58;
            this.labelControl6.Text = "Archivo Excel";
            // 
            // cboHojas
            // 
            this.cboHojas.FormattingEnabled = true;
            this.cboHojas.Location = new System.Drawing.Point(622, 12);
            this.cboHojas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboHojas.Name = "cboHojas";
            this.cboHojas.Size = new System.Drawing.Size(226, 24);
            this.cboHojas.TabIndex = 56;
            // 
            // btnBuscar_Xls
            // 
            this.btnBuscar_Xls.Location = new System.Drawing.Point(514, 10);
            this.btnBuscar_Xls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar_Xls.Name = "btnBuscar_Xls";
            this.btnBuscar_Xls.Size = new System.Drawing.Size(29, 28);
            this.btnBuscar_Xls.TabIndex = 55;
            this.btnBuscar_Xls.Text = "...";
            this.btnBuscar_Xls.UseVisualStyleBackColor = true;
            this.btnBuscar_Xls.Click += new System.EventHandler(this.btnBuscar_Xls_Click);
            // 
            // txtPathXls
            // 
            this.txtPathXls.Location = new System.Drawing.Point(114, 12);
            this.txtPathXls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPathXls.Name = "txtPathXls";
            this.txtPathXls.Size = new System.Drawing.Size(392, 23);
            this.txtPathXls.TabIndex = 54;
            this.txtPathXls.DoubleClick += new System.EventHandler(this.txtPathXls_DoubleClick);
            // 
            // xtraTabPageBrowse
            // 
            this.xtraTabPageBrowse.Controls.Add(this.splitContainerControl1);
            this.xtraTabPageBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPageBrowse.Name = "xtraTabPageBrowse";
            this.xtraTabPageBrowse.Size = new System.Drawing.Size(1267, 732);
            this.xtraTabPageBrowse.Text = "Documento Detalle";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcFactura);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1267, 732);
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
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(1267, 46);
            this.groupControl2.TabIndex = 86;
            this.groupControl2.Text = "groupControl2";
            // 
            // btnValidarFacturas
            // 
            this.btnValidarFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidarFacturas.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnValidarFacturas.Appearance.Options.UseForeColor = true;
            this.btnValidarFacturas.Image = ((System.Drawing.Image)(resources.GetObject("btnValidarFacturas.Image")));
            this.btnValidarFacturas.Location = new System.Drawing.Point(930, 14);
            this.btnValidarFacturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnValidarFacturas.Name = "btnValidarFacturas";
            this.btnValidarFacturas.Size = new System.Drawing.Size(105, 31);
            this.btnValidarFacturas.TabIndex = 95;
            this.btnValidarFacturas.Text = "&Validar";
            this.btnValidarFacturas.Click += new System.EventHandler(this.btnValidarFacturas_Click);
            // 
            // btnCargar2Exactus
            // 
            this.btnCargar2Exactus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar2Exactus.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnCargar2Exactus.Appearance.Options.UseForeColor = true;
            this.btnCargar2Exactus.Location = new System.Drawing.Point(1154, 14);
            this.btnCargar2Exactus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCargar2Exactus.Name = "btnCargar2Exactus";
            this.btnCargar2Exactus.Size = new System.Drawing.Size(105, 31);
            this.btnCargar2Exactus.TabIndex = 82;
            this.btnCargar2Exactus.Text = "&Actualizar";
            this.btnCargar2Exactus.Click += new System.EventHandler(this.btnCargar2Exactus_Click);
            // 
            // chkFacturas
            // 
            this.chkFacturas.Location = new System.Drawing.Point(30, 21);
            this.chkFacturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFacturas.Name = "chkFacturas";
            this.chkFacturas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFacturas.Properties.Appearance.Options.UseFont = true;
            this.chkFacturas.Properties.Caption = "Procesar Todos";
            this.chkFacturas.Size = new System.Drawing.Size(128, 21);
            this.chkFacturas.TabIndex = 84;
            this.chkFacturas.CheckedChanged += new System.EventHandler(this.chkFacturas_CheckedChanged);
            // 
            // btnExportarFacturas
            // 
            this.btnExportarFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarFacturas.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarFacturas.Image")));
            this.btnExportarFacturas.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarFacturas.Location = new System.Drawing.Point(1042, 14);
            this.btnExportarFacturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportarFacturas.Name = "btnExportarFacturas";
            this.btnExportarFacturas.Size = new System.Drawing.Size(105, 31);
            this.btnExportarFacturas.TabIndex = 81;
            this.btnExportarFacturas.Text = "Exportar";
            this.btnExportarFacturas.Click += new System.EventHandler(this.btnExportarFacturas_Click);
            // 
            // gcFactura
            // 
            this.gcFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFactura.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcFactura.Location = new System.Drawing.Point(8, 17);
            this.gcFactura.MainView = this.gvFactura;
            this.gcFactura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcFactura.Name = "gcFactura";
            this.gcFactura.Size = new System.Drawing.Size(1253, 641);
            this.gcFactura.TabIndex = 4;
            this.gcFactura.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFactura});
            // 
            // gvFactura
            // 
            this.gvFactura.GridControl = this.gcFactura;
            this.gvFactura.Name = "gvFactura";
            this.gvFactura.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvFactura_CustomRowCellEdit);
            this.gvFactura.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFactura_FocusedRowChanged);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(19, 710);
            this.simpleButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(87, 28);
            this.simpleButton5.TabIndex = 40;
            this.simpleButton5.Text = "simpleButton5";
            this.simpleButton5.Visible = false;
            // 
            // txtXML_Path
            // 
            this.txtXML_Path.Location = new System.Drawing.Point(14, 714);
            this.txtXML_Path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXML_Path.Name = "txtXML_Path";
            this.txtXML_Path.Size = new System.Drawing.Size(260, 22);
            this.txtXML_Path.TabIndex = 83;
            this.txtXML_Path.Visible = false;
            // 
            // frmValidacionDocumentosFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 766);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.txtXML_Path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmValidacionDocumentosFE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validacion Documentos FE";
            this.Load += new System.EventHandler(this.frmCargaFacturaCPv5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCarga.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
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
        private DevExpress.XtraTab.XtraTabPage xtraTabPageExcel;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.TextEdit txtTipoCarga;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLoadXls;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.ComboBox cboHojas;
        private System.Windows.Forms.Button btnBuscar_Xls;
        private System.Windows.Forms.TextBox txtPathXls;
        private DevExpress.XtraEditors.SimpleButton btnProcesarXls;
        private DevExpress.XtraEditors.SimpleButton btnExportarXls;
        private DevExpress.XtraEditors.SimpleButton btnValidarXls;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcExcel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExcel;
        private DevExpress.XtraGrid.Columns.GridColumn PROVEEDOR;
        private DevExpress.XtraGrid.Columns.GridColumn CODIGO;
        private DevExpress.XtraGrid.Columns.GridColumn FECHA_EMISION;
        private DevExpress.XtraGrid.Columns.GridColumn MONTO;
        private DevExpress.XtraGrid.Columns.GridColumn NUMERO;
        private DevExpress.XtraGrid.Columns.GridColumn SERIE;
        private DevExpress.XtraGrid.Columns.GridColumn VALIDACION;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnValidarFacturas;
        private DevExpress.XtraEditors.TextEdit txtNombreUsuario;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.SimpleButton btnGenerarToken;
        private DevExpress.XtraEditors.SimpleButton btnConsultaCPE;
    }
}