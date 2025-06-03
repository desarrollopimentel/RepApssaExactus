namespace ApssaExactus
{
    partial class frmTransferenciasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferenciasPendientes));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNombreUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.lookUpPaquete = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnProcesarXls = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportarXls = new DevExpress.XtraEditors.SimpleButton();
            this.dpFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.dpFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.checkedComboBoxEdit2 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.gcTransf = new DevExpress.XtraGrid.GridControl();
            this.gvTransf = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPaquete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTransf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransf)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.txtNombreUsuario);
            this.groupControl1.Controls.Add(this.txtUsuario);
            this.groupControl1.Controls.Add(this.lookUpPaquete);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.btnProcesarXls);
            this.groupControl1.Controls.Add(this.btnExportarXls);
            this.groupControl1.Controls.Add(this.dpFechaFin);
            this.groupControl1.Controls.Add(this.dpFechaIni);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.checkedComboBoxEdit1);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.checkedComboBoxEdit2);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Location = new System.Drawing.Point(0, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1099, 55);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Pedidos sin Reserva";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(683, 19);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(208, 20);
            this.txtNombreUsuario.TabIndex = 134;
            this.txtNombreUsuario.Visible = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(577, 20);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 133;
            this.txtUsuario.Visible = false;
            // 
            // lookUpPaquete
            // 
            this.lookUpPaquete.Location = new System.Drawing.Point(413, 20);
            this.lookUpPaquete.Name = "lookUpPaquete";
            this.lookUpPaquete.Properties.AllowMultiSelect = true;
            this.lookUpPaquete.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookUpPaquete.Properties.Appearance.Options.UseFont = true;
            this.lookUpPaquete.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpPaquete.Properties.NullText = "[Vacío]";
            this.lookUpPaquete.Size = new System.Drawing.Size(158, 20);
            this.lookUpPaquete.TabIndex = 126;
            this.lookUpPaquete.ToolTip = "Seleccione  Paquete";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(371, 27);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(40, 13);
            this.labelControl8.TabIndex = 102;
            this.labelControl8.Text = "Paquete";
            // 
            // btnProcesarXls
            // 
            this.btnProcesarXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesarXls.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnProcesarXls.Appearance.Options.UseForeColor = true;
            this.btnProcesarXls.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesarXls.Image")));
            this.btnProcesarXls.Location = new System.Drawing.Point(994, 17);
            this.btnProcesarXls.Name = "btnProcesarXls";
            this.btnProcesarXls.Size = new System.Drawing.Size(91, 23);
            this.btnProcesarXls.TabIndex = 94;
            this.btnProcesarXls.Text = "&Actualizar";
            this.btnProcesarXls.Click += new System.EventHandler(this.btnProcesarXls_Click);
            // 
            // btnExportarXls
            // 
            this.btnExportarXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarXls.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarXls.Image")));
            this.btnExportarXls.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarXls.Location = new System.Drawing.Point(897, 17);
            this.btnExportarXls.Name = "btnExportarXls";
            this.btnExportarXls.Size = new System.Drawing.Size(91, 23);
            this.btnExportarXls.TabIndex = 93;
            this.btnExportarXls.Text = "Exportar";
            this.btnExportarXls.Click += new System.EventHandler(this.btnExportarXls_Click);
            // 
            // dpFechaFin
            // 
            this.dpFechaFin.EditValue = null;
            this.dpFechaFin.Location = new System.Drawing.Point(244, 20);
            this.dpFechaFin.Name = "dpFechaFin";
            this.dpFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Size = new System.Drawing.Size(112, 20);
            this.dpFechaFin.TabIndex = 60;
            // 
            // dpFechaIni
            // 
            this.dpFechaIni.EditValue = null;
            this.dpFechaIni.Location = new System.Drawing.Point(69, 20);
            this.dpFechaIni.Name = "dpFechaIni";
            this.dpFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Size = new System.Drawing.Size(104, 20);
            this.dpFechaIni.TabIndex = 59;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(185, 27);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(54, 13);
            this.labelControl10.TabIndex = 51;
            this.labelControl10.Text = "Fecha Final";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(17, 179);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(36, 13);
            this.labelControl11.TabIndex = 49;
            this.labelControl11.Text = "Bodega";
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(59, 194);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(133, 20);
            this.checkedComboBoxEdit1.TabIndex = 48;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(24, 156);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(29, 13);
            this.labelControl12.TabIndex = 47;
            this.labelControl12.Text = "Grupo";
            // 
            // checkedComboBoxEdit2
            // 
            this.checkedComboBoxEdit2.EditValue = "";
            this.checkedComboBoxEdit2.Location = new System.Drawing.Point(59, 172);
            this.checkedComboBoxEdit2.Name = "checkedComboBoxEdit2";
            this.checkedComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.checkedComboBoxEdit2.Size = new System.Drawing.Size(133, 20);
            this.checkedComboBoxEdit2.TabIndex = 44;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(7, 27);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(57, 13);
            this.labelControl18.TabIndex = 33;
            this.labelControl18.Text = "Fecha Inicio";
            // 
            // gcTransf
            // 
            this.gcTransf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTransf.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gcTransf.Location = new System.Drawing.Point(4, 63);
            this.gcTransf.MainView = this.gvTransf;
            this.gcTransf.Name = "gcTransf";
            this.gcTransf.Size = new System.Drawing.Size(1090, 525);
            this.gcTransf.TabIndex = 11;
            this.gcTransf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTransf});
            // 
            // gvTransf
            // 
            this.gvTransf.GridControl = this.gcTransf;
            this.gvTransf.Name = "gvTransf";
            this.gvTransf.OptionsFind.AlwaysVisible = true;
            this.gvTransf.OptionsFind.FindNullPrompt = "Ingrese el texto a buscar .......";
            this.gvTransf.OptionsView.ShowGroupPanel = false;
            // 
            // frmTransferenciasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 612);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcTransf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmTransferenciasPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Transferencias Pendientes";
            this.Load += new System.EventHandler(this.frmTransferenciasPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPaquete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTransf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dpFechaFin;
        private DevExpress.XtraEditors.DateEdit dpFechaIni;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraGrid.GridControl gcTransf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTransf;
        private DevExpress.XtraEditors.SimpleButton btnProcesarXls;
        private DevExpress.XtraEditors.SimpleButton btnExportarXls;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lookUpPaquete;
        private DevExpress.XtraEditors.TextEdit txtNombreUsuario;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
    }
}