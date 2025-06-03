namespace ApssaExactus
{
    partial class frmLiquidacionReporte
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtTarjeta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dpFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.dpFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtSucursal = new DevExpress.XtraEditors.TextEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMoneda = new DevExpress.XtraEditors.TextEdit();
            this.txtEstado = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarjeta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "dsPimentel";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ApssaExactus.RptLiquidacionTarjetas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(826, 489);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(428, 12);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(137, 20);
            this.txtTarjeta.TabIndex = 74;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(256, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 73;
            this.labelControl3.Text = "Sucursal";
            // 
            // dpFechaFin
            // 
            this.dpFechaFin.EditValue = null;
            this.dpFechaFin.Location = new System.Drawing.Point(144, 12);
            this.dpFechaFin.Name = "dpFechaFin";
            this.dpFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaFin.Size = new System.Drawing.Size(85, 20);
            this.dpFechaFin.TabIndex = 72;
            // 
            // dpFechaIni
            // 
            this.dpFechaIni.EditValue = null;
            this.dpFechaIni.Location = new System.Drawing.Point(53, 12);
            this.dpFechaIni.Name = "dpFechaIni";
            this.dpFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFechaIni.Size = new System.Drawing.Size(85, 20);
            this.dpFechaIni.TabIndex = 71;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(13, 19);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(34, 13);
            this.labelControl18.TabIndex = 70;
            this.labelControl18.Text = "Fechas";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(301, 12);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(77, 20);
            this.txtSucursal.TabIndex = 69;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Location = new System.Drawing.Point(762, 9);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 23);
            this.btnConsultar.TabIndex = 68;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(389, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 75;
            this.labelControl1.Text = "Tarjeta";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(571, 12);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(52, 20);
            this.txtMoneda.TabIndex = 76;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(629, 12);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(52, 20);
            this.txtEstado.TabIndex = 77;
            // 
            // frmLiquidacionReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 532);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.dpFechaFin);
            this.Controls.Add(this.dpFechaIni);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.btnConsultar);
            this.Name = "frmLiquidacionReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion de tarjetas";
            this.Load += new System.EventHandler(this.frmLiquidacionReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTarjeta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevExpress.XtraEditors.TextEdit txtTarjeta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dpFechaFin;
        private DevExpress.XtraEditors.DateEdit dpFechaIni;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtSucursal;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMoneda;
        private DevExpress.XtraEditors.TextEdit txtEstado;
    }
}