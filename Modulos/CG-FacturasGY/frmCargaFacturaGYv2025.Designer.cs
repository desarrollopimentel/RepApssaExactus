namespace ApssaExactus
{
    partial class frmCargaFacturaGYv2025
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaFacturaGYv2025));
            this.btnLoadXML = new DevExpress.XtraEditors.SimpleButton();
            this.btnXlsExportar = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageCarga = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer_Carga = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtNombreUsuario = new DevExpress.XtraEditors.TextEdit();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnProcesar = new DevExpress.XtraEditors.SimpleButton();
            this.dpFechaProceso = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcXmlPath = new DevExpress.XtraGrid.GridControl();
            this.gvXmlPath = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VERSION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FECHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOCUMENTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MONTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IMPUESTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TOTAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VCMTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DIAS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CONDPAGO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARCHIVO_PDF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtXML_Contenido = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPageBrowse = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.chkFacturas = new DevExpress.XtraEditors.CheckEdit();
            this.btnProcesarFacturas = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargar2Exactus = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportarFacturas = new DevExpress.XtraEditors.SimpleButton();
            this.gcFactura = new DevExpress.XtraGrid.GridControl();
            this.gvFactura = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPageXml = new DevExpress.XtraTab.XtraTabPage();
            this.txtOuter = new DevExpress.XtraEditors.MemoEdit();
            this.txtInner = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.txtXML_Path = new DevExpress.XtraEditors.TextEdit();
            this.txtBaseDatos = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Carga)).BeginInit();
            this.splitContainer_Carga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaProceso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaProceso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcXmlPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXmlPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXML_Contenido.Properties)).BeginInit();
            this.xtraTabPageBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFacturas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFactura)).BeginInit();
            this.xtraTabPageXml.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOuter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXML_Path.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseDatos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnLoadXML.Appearance.Options.UseForeColor = true;
            this.btnLoadXML.Location = new System.Drawing.Point(6, 9);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(92, 29);
            this.btnLoadXML.TabIndex = 3;
            this.btnLoadXML.Text = "&Cargar XML";
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // btnXlsExportar
            // 
            this.btnXlsExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXlsExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnXlsExportar.Image")));
            this.btnXlsExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXlsExportar.Location = new System.Drawing.Point(988, 7);
            this.btnXlsExportar.Name = "btnXlsExportar";
            this.btnXlsExportar.Size = new System.Drawing.Size(70, 29);
            this.btnXlsExportar.TabIndex = 34;
            this.btnXlsExportar.Click += new System.EventHandler(this.btnXlsExportar_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageCarga;
            this.xtraTabControl1.Size = new System.Drawing.Size(1092, 622);
            this.xtraTabControl1.TabIndex = 36;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageCarga,
            this.xtraTabPageBrowse,
            this.xtraTabPageXml});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabControl1.Click += new System.EventHandler(this.xtraTabControl1_Click);
            // 
            // xtraTabPageCarga
            // 
            this.xtraTabPageCarga.Controls.Add(this.splitContainer_Carga);
            this.xtraTabPageCarga.Name = "xtraTabPageCarga";
            this.xtraTabPageCarga.Size = new System.Drawing.Size(1086, 594);
            this.xtraTabPageCarga.Text = "Carga XML";
            // 
            // splitContainer_Carga
            // 
            this.splitContainer_Carga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_Carga.Horizontal = false;
            this.splitContainer_Carga.Location = new System.Drawing.Point(6, 14);
            this.splitContainer_Carga.Name = "splitContainer_Carga";
            this.splitContainer_Carga.Panel1.Controls.Add(this.txtBaseDatos);
            this.splitContainer_Carga.Panel1.Controls.Add(this.txtUsuario);
            this.splitContainer_Carga.Panel1.Controls.Add(this.txtNombreUsuario);
            this.splitContainer_Carga.Panel1.Controls.Add(this.textBox1);
            this.splitContainer_Carga.Panel1.Controls.Add(this.btnLoadXML);
            this.splitContainer_Carga.Panel1.Controls.Add(this.btnProcesar);
            this.splitContainer_Carga.Panel1.Controls.Add(this.dpFechaProceso);
            this.splitContainer_Carga.Panel1.Controls.Add(this.btnXlsExportar);
            this.splitContainer_Carga.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer_Carga.Panel1.Text = "Panel1";
            this.splitContainer_Carga.Panel2.Controls.Add(this.gcXmlPath);
            this.splitContainer_Carga.Panel2.Controls.Add(this.simpleButton1);
            this.splitContainer_Carga.Panel2.Controls.Add(this.txtXML_Contenido);
            this.splitContainer_Carga.Panel2.Text = "Panel2";
            this.splitContainer_Carga.Size = new System.Drawing.Size(1074, 577);
            this.splitContainer_Carga.SplitterPosition = 42;
            this.splitContainer_Carga.TabIndex = 38;
            this.splitContainer_Carga.Text = "splitContainerControl1";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(319, 17);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtUsuario.TabIndex = 82;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(452, -1);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.txtNombreUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(171, 18);
            this.txtNombreUsuario.TabIndex = 83;
            this.txtNombreUsuario.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(346, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 81;
            this.textBox1.Visible = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesar.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnProcesar.Appearance.Options.UseForeColor = true;
            this.btnProcesar.Location = new System.Drawing.Point(862, 7);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(92, 29);
            this.btnProcesar.TabIndex = 80;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // dpFechaProceso
            // 
            this.dpFechaProceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFechaProceso.EditValue = null;
            this.dpFechaProceso.Location = new System.Drawing.Point(693, 16);
            this.dpFechaProceso.Name = "dpFechaProceso";
            this.dpFechaProceso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dpFechaProceso.Properties.Appearance.Options.UseFont = true;
            this.dpFechaProceso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaProceso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaProceso.Size = new System.Drawing.Size(95, 20);
            this.dpFechaProceso.TabIndex = 78;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(607, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 79;
            this.labelControl1.Text = "Fecha Proceso";
            // 
            // gcXmlPath
            // 
            this.gcXmlPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcXmlPath.Location = new System.Drawing.Point(6, 6);
            this.gcXmlPath.MainView = this.gvXmlPath;
            this.gcXmlPath.Name = "gcXmlPath";
            this.gcXmlPath.Size = new System.Drawing.Size(1068, 510);
            this.gcXmlPath.TabIndex = 39;
            this.gcXmlPath.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvXmlPath});
            // 
            // gvXmlPath
            // 
            this.gvXmlPath.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VERSION,
            this.FECHA,
            this.DOCUMENTO,
            this.MONTO,
            this.IMPUESTO,
            this.TOTAL,
            this.VCMTO,
            this.DIAS,
            this.CONDPAGO,
            this.ARCHIVO_PDF});
            this.gvXmlPath.GridControl = this.gcXmlPath;
            this.gvXmlPath.Name = "gvXmlPath";
            this.gvXmlPath.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvXmlPath.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvXmlPath.OptionsSelection.MultiSelect = true;
            this.gvXmlPath.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvXmlPath.OptionsSelection.UseIndicatorForSelection = false;
            this.gvXmlPath.OptionsView.ShowGroupPanel = false;
            this.gvXmlPath.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvXmlPath_FocusedRowChanged);
            // 
            // VERSION
            // 
            this.VERSION.AppearanceCell.Options.UseTextOptions = true;
            this.VERSION.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.VERSION.AppearanceHeader.Options.UseTextOptions = true;
            this.VERSION.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.VERSION.Caption = "VERSION";
            this.VERSION.FieldName = "VERSION";
            this.VERSION.MaxWidth = 60;
            this.VERSION.MinWidth = 60;
            this.VERSION.Name = "VERSION";
            this.VERSION.Visible = true;
            this.VERSION.VisibleIndex = 1;
            this.VERSION.Width = 60;
            // 
            // FECHA
            // 
            this.FECHA.AppearanceCell.Options.UseTextOptions = true;
            this.FECHA.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.FECHA.AppearanceHeader.Options.UseTextOptions = true;
            this.FECHA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.FECHA.Caption = "FECHA";
            this.FECHA.FieldName = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.Visible = true;
            this.FECHA.VisibleIndex = 2;
            this.FECHA.Width = 90;
            // 
            // DOCUMENTO
            // 
            this.DOCUMENTO.AppearanceCell.Options.UseTextOptions = true;
            this.DOCUMENTO.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DOCUMENTO.AppearanceHeader.Options.UseTextOptions = true;
            this.DOCUMENTO.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DOCUMENTO.Caption = "DOCUMENTO";
            this.DOCUMENTO.FieldName = "DOCUMENTO";
            this.DOCUMENTO.Name = "DOCUMENTO";
            this.DOCUMENTO.Visible = true;
            this.DOCUMENTO.VisibleIndex = 3;
            this.DOCUMENTO.Width = 325;
            // 
            // MONTO
            // 
            this.MONTO.Caption = "MONTO";
            this.MONTO.FieldName = "MONTO";
            this.MONTO.Name = "MONTO";
            this.MONTO.Visible = true;
            this.MONTO.VisibleIndex = 4;
            this.MONTO.Width = 65;
            // 
            // IMPUESTO
            // 
            this.IMPUESTO.Caption = "IMPUESTO";
            this.IMPUESTO.FieldName = "IMPUESTO";
            this.IMPUESTO.Name = "IMPUESTO";
            this.IMPUESTO.Visible = true;
            this.IMPUESTO.VisibleIndex = 5;
            this.IMPUESTO.Width = 65;
            // 
            // TOTAL
            // 
            this.TOTAL.Caption = "TOTAL";
            this.TOTAL.FieldName = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.Visible = true;
            this.TOTAL.VisibleIndex = 6;
            this.TOTAL.Width = 65;
            // 
            // VCMTO
            // 
            this.VCMTO.FieldName = "VCMTO";
            this.VCMTO.Name = "VCMTO";
            this.VCMTO.Visible = true;
            this.VCMTO.VisibleIndex = 7;
            this.VCMTO.Width = 83;
            // 
            // DIAS
            // 
            this.DIAS.Caption = "DIAS";
            this.DIAS.FieldName = "DIAS";
            this.DIAS.Name = "DIAS";
            this.DIAS.Visible = true;
            this.DIAS.VisibleIndex = 8;
            this.DIAS.Width = 45;
            // 
            // CONDPAGO
            // 
            this.CONDPAGO.Caption = "CONDPAGO";
            this.CONDPAGO.FieldName = "CONDPAGO";
            this.CONDPAGO.Name = "CONDPAGO";
            this.CONDPAGO.Visible = true;
            this.CONDPAGO.VisibleIndex = 9;
            this.CONDPAGO.Width = 80;
            // 
            // ARCHIVO_PDF
            // 
            this.ARCHIVO_PDF.Caption = "ARCHIVO_PDF";
            this.ARCHIVO_PDF.FieldName = "ARCHIVO_PDF";
            this.ARCHIVO_PDF.Name = "ARCHIVO_PDF";
            this.ARCHIVO_PDF.Visible = true;
            this.ARCHIVO_PDF.VisibleIndex = 10;
            this.ARCHIVO_PDF.Width = 97;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(989, 486);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(82, 20);
            this.simpleButton1.TabIndex = 81;
            this.simpleButton1.Text = ".....";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtXML_Contenido
            // 
            this.txtXML_Contenido.Location = new System.Drawing.Point(234, 487);
            this.txtXML_Contenido.Name = "txtXML_Contenido";
            this.txtXML_Contenido.Size = new System.Drawing.Size(747, 20);
            this.txtXML_Contenido.TabIndex = 82;
            this.txtXML_Contenido.Visible = false;
            // 
            // xtraTabPageBrowse
            // 
            this.xtraTabPageBrowse.Controls.Add(this.splitContainerControl1);
            this.xtraTabPageBrowse.Name = "xtraTabPageBrowse";
            this.xtraTabPageBrowse.Size = new System.Drawing.Size(1086, 594);
            this.xtraTabPageBrowse.Text = "Facturas Detalle";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.simpleButton2);
            this.splitContainerControl1.Panel1.Controls.Add(this.chkFacturas);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnProcesarFacturas);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnCargar2Exactus);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnExportarFacturas);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcFactura);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1086, 594);
            this.splitContainerControl1.SplitterPosition = 39;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(220, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 85;
            this.simpleButton2.Text = "Actualiza";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // chkFacturas
            // 
            this.chkFacturas.Location = new System.Drawing.Point(15, 16);
            this.chkFacturas.Name = "chkFacturas";
            this.chkFacturas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFacturas.Properties.Appearance.Options.UseFont = true;
            this.chkFacturas.Properties.Caption = "Procesar Todos";
            this.chkFacturas.Size = new System.Drawing.Size(110, 19);
            this.chkFacturas.TabIndex = 84;
            this.chkFacturas.CheckedChanged += new System.EventHandler(this.chkFacturas_CheckedChanged);
            // 
            // btnProcesarFacturas
            // 
            this.btnProcesarFacturas.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnProcesarFacturas.Appearance.Options.UseForeColor = true;
            this.btnProcesarFacturas.Location = new System.Drawing.Point(370, 6);
            this.btnProcesarFacturas.Name = "btnProcesarFacturas";
            this.btnProcesarFacturas.Size = new System.Drawing.Size(120, 29);
            this.btnProcesarFacturas.TabIndex = 83;
            this.btnProcesarFacturas.Text = "&Procesar Facturas";
            this.btnProcesarFacturas.Visible = false;
            this.btnProcesarFacturas.Click += new System.EventHandler(this.btnProcesarFacturas_Click);
            // 
            // btnCargar2Exactus
            // 
            this.btnCargar2Exactus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar2Exactus.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnCargar2Exactus.Appearance.Options.UseForeColor = true;
            this.btnCargar2Exactus.Location = new System.Drawing.Point(859, 6);
            this.btnCargar2Exactus.Name = "btnCargar2Exactus";
            this.btnCargar2Exactus.Size = new System.Drawing.Size(120, 29);
            this.btnCargar2Exactus.TabIndex = 82;
            this.btnCargar2Exactus.Text = "&Cargar a Exactus";
            this.btnCargar2Exactus.Click += new System.EventHandler(this.btnCargar2Exactus_Click);
            // 
            // btnExportarFacturas
            // 
            this.btnExportarFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarFacturas.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarFacturas.Image")));
            this.btnExportarFacturas.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnExportarFacturas.Location = new System.Drawing.Point(985, 6);
            this.btnExportarFacturas.Name = "btnExportarFacturas";
            this.btnExportarFacturas.Size = new System.Drawing.Size(94, 29);
            this.btnExportarFacturas.TabIndex = 81;
            this.btnExportarFacturas.Click += new System.EventHandler(this.btnExportarFacturas_Click);
            // 
            // gcFactura
            // 
            this.gcFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFactura.Location = new System.Drawing.Point(7, 14);
            this.gcFactura.MainView = this.gvFactura;
            this.gcFactura.Name = "gcFactura";
            this.gcFactura.Size = new System.Drawing.Size(1074, 524);
            this.gcFactura.TabIndex = 4;
            this.gcFactura.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFactura});
            // 
            // gvFactura
            // 
            this.gvFactura.GridControl = this.gcFactura;
            this.gvFactura.Name = "gvFactura";
            this.gvFactura.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvFactura_CustomRowCellEdit);
            this.gvFactura.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFactura_FocusedRowChanged_1);
            // 
            // xtraTabPageXml
            // 
            this.xtraTabPageXml.Controls.Add(this.txtOuter);
            this.xtraTabPageXml.Controls.Add(this.txtInner);
            this.xtraTabPageXml.Name = "xtraTabPageXml";
            this.xtraTabPageXml.PageEnabled = false;
            this.xtraTabPageXml.Size = new System.Drawing.Size(1086, 594);
            this.xtraTabPageXml.Text = "Visor Xml";
            // 
            // txtOuter
            // 
            this.txtOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOuter.Location = new System.Drawing.Point(15, 12);
            this.txtOuter.Name = "txtOuter";
            this.txtOuter.Size = new System.Drawing.Size(1058, 570);
            this.txtOuter.TabIndex = 1;
            // 
            // txtInner
            // 
            this.txtInner.Location = new System.Drawing.Point(115, 94);
            this.txtInner.Name = "txtInner";
            this.txtInner.Size = new System.Drawing.Size(549, 430);
            this.txtInner.TabIndex = 0;
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
            // txtBaseDatos
            // 
            this.txtBaseDatos.Enabled = false;
            this.txtBaseDatos.Location = new System.Drawing.Point(173, 18);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtBaseDatos.Properties.Appearance.Options.UseFont = true;
            this.txtBaseDatos.Size = new System.Drawing.Size(140, 20);
            this.txtBaseDatos.TabIndex = 84;
            // 
            // frmCargaFacturaGYv2025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 622);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.txtXML_Path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargaFacturaGYv2025";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML - Carga de Facturas GY  v2025";
            this.Load += new System.EventHandler(this.frmCargaFacturaGYv2024_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Carga)).EndInit();
            this.splitContainer_Carga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaProceso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaProceso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcXmlPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXmlPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXML_Contenido.Properties)).EndInit();
            this.xtraTabPageBrowse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkFacturas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFactura)).EndInit();
            this.xtraTabPageXml.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOuter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXML_Path.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseDatos.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLoadXML;
        private DevExpress.XtraEditors.SimpleButton btnXlsExportar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCarga;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageBrowse;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageXml;
        private DevExpress.XtraEditors.MemoEdit txtInner;
        private DevExpress.XtraEditors.MemoEdit txtOuter;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.DateEdit dpFechaProceso;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnProcesar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtXML_Contenido;
        private DevExpress.XtraEditors.TextEdit txtXML_Path;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer_Carga;
        private DevExpress.XtraGrid.GridControl gcXmlPath;
        private DevExpress.XtraGrid.Views.Grid.GridView gvXmlPath;
        private DevExpress.XtraGrid.Columns.GridColumn FECHA;
        private DevExpress.XtraGrid.Columns.GridColumn DOCUMENTO;
        private DevExpress.XtraGrid.Columns.GridColumn MONTO;
        private DevExpress.XtraGrid.Columns.GridColumn IMPUESTO;
        private DevExpress.XtraGrid.Columns.GridColumn TOTAL;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnCargar2Exactus;
        private DevExpress.XtraEditors.SimpleButton btnExportarFacturas;
        private DevExpress.XtraGrid.GridControl gcFactura;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFactura;
        private DevExpress.XtraEditors.SimpleButton btnProcesarFacturas;
        private DevExpress.XtraEditors.CheckEdit chkFacturas;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraGrid.Columns.GridColumn CONDPAGO;
        private DevExpress.XtraGrid.Columns.GridColumn ARCHIVO_PDF;
        private DevExpress.XtraGrid.Columns.GridColumn VERSION;
        private DevExpress.XtraGrid.Columns.GridColumn VCMTO;
        private DevExpress.XtraGrid.Columns.GridColumn DIAS;
        private DevExpress.XtraEditors.TextEdit txtNombreUsuario;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.TextEdit txtBaseDatos;
    }
}