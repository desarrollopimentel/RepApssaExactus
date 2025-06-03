namespace ApssaExactus
{
    partial class frm_FacturasSinCargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FacturasSinCargos));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcFacturas = new DevExpress.XtraGrid.GridControl();
            this.gvFacturas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboCargo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboAprobado = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dpFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAprobado.Properties)).BeginInit();
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
            // gcFacturas
            // 
            this.gcFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturas.Location = new System.Drawing.Point(3, 3);
            this.gcFacturas.MainView = this.gvFacturas;
            this.gcFacturas.Name = "gcFacturas";
            this.gcFacturas.Size = new System.Drawing.Size(1066, 519);
            this.gcFacturas.TabIndex = 0;
            this.gcFacturas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFacturas});
            // 
            // gvFacturas
            // 
            this.gvFacturas.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvFacturas.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvFacturas.GridControl = this.gcFacturas;
            this.gvFacturas.Name = "gvFacturas";
            this.gvFacturas.OptionsFind.FindNullPrompt = "Ingrese el texto a buscar";
            this.gvFacturas.OptionsView.ShowGroupPanel = false;
            this.gvFacturas.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGuias_FocusedRowChanged);
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
            this.xtraTabPage3.Text = "Filtros";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.cboCargo);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cboAprobado);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.dpFechaFin);
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
            // cboCargo
            // 
            this.cboCargo.Location = new System.Drawing.Point(640, 15);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCargo.Properties.Items.AddRange(new object[] {
            "Todos",
            "Sin Cargo",
            "Con Cargo"});
            this.cboCargo.Size = new System.Drawing.Size(133, 20);
            this.cboCargo.TabIndex = 77;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(593, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 78;
            this.labelControl1.Text = "Cargo ?";
            // 
            // cboAprobado
            // 
            this.cboAprobado.Location = new System.Drawing.Point(464, 15);
            this.cboAprobado.Name = "cboAprobado";
            this.cboAprobado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAprobado.Properties.Items.AddRange(new object[] {
            "Todos",
            "Sin Aprobar",
            "Aprobado"});
            this.cboAprobado.Size = new System.Drawing.Size(105, 20);
            this.cboAprobado.TabIndex = 75;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(404, 22);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 13);
            this.labelControl5.TabIndex = 76;
            this.labelControl5.Text = "Aprobado ?";
            // 
            // dpFechaFin
            // 
            this.dpFechaFin.EditValue = null;
            this.dpFechaFin.Location = new System.Drawing.Point(257, 15);
            this.dpFechaFin.Name = "dpFechaFin";
            this.dpFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Size = new System.Drawing.Size(112, 20);
            this.dpFechaFin.TabIndex = 68;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(194, 22);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 13);
            this.labelControl4.TabIndex = 74;
            this.labelControl4.Text = " Fecha Final";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(10, 22);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(57, 13);
            this.labelControl10.TabIndex = 66;
            this.labelControl10.Text = "Fecha Inicio";
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
            this.dpFechaIni.Location = new System.Drawing.Point(73, 15);
            this.dpFechaIni.Name = "dpFechaIni";
            this.dpFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Size = new System.Drawing.Size(104, 20);
            this.dpFechaIni.TabIndex = 67;
            // 
            // cboZona
            // 
            this.cboZona.Location = new System.Drawing.Point(638, 1);
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
            this.cboTienda.Location = new System.Drawing.Point(639, 2);
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
            this.labelControl16.Location = new System.Drawing.Point(601, 8);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(32, 13);
            this.labelControl16.TabIndex = 63;
            this.labelControl16.Text = "Tienda";
            this.labelControl16.Visible = false;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(607, 9);
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
            this.xtraTabPage1.Controls.Add(this.gcFacturas);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1078, 529);
            this.xtraTabPage1.Text = "Documentos CP";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1078, 529);
            this.xtraTabPage2.Text = "~";
            // 
            // frm_FacturasSinCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 643);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frm_FacturasSinCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas CP sin Cargos";
            this.Load += new System.EventHandler(this.frm_ObtenerGRE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAprobado.Properties)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcFacturas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturas;
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
        private DevExpress.XtraEditors.ComboBoxEdit cboAprobado;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cboCargo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}