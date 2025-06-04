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
            this.txtTarjetas = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtCaja = new DevExpress.XtraEditors.TextEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLocal = new DevExpress.XtraEditors.TextEdit();
            this.txtDolar = new DevExpress.XtraEditors.TextEdit();
            this.txtLiquidado = new DevExpress.XtraEditors.TextEdit();
            this.txtPendiente = new DevExpress.XtraEditors.TextEdit();
            this.txtFechaDesde = new DevExpress.XtraEditors.TextEdit();
            this.txtFechaHasta = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarjetas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquidado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPendiente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "dsPimentel";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ApssaExactus.RptLiquidacionTarjetas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(826, 489);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtTarjetas
            // 
            this.txtTarjetas.Location = new System.Drawing.Point(416, 12);
            this.txtTarjetas.Name = "txtTarjetas";
            this.txtTarjetas.Size = new System.Drawing.Size(137, 20);
            this.txtTarjetas.TabIndex = 74;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(244, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 73;
            this.labelControl3.Text = "Sucursal";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(13, 19);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(34, 13);
            this.labelControl18.TabIndex = 70;
            this.labelControl18.Text = "Fechas";
            // 
            // txtCaja
            // 
            this.txtCaja.Location = new System.Drawing.Point(289, 12);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(77, 20);
            this.txtCaja.TabIndex = 69;
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
            this.labelControl1.Location = new System.Drawing.Point(377, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 75;
            this.labelControl1.Text = "Tarjeta";
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(559, 12);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(39, 20);
            this.txtLocal.TabIndex = 76;
            // 
            // txtDolar
            // 
            this.txtDolar.Location = new System.Drawing.Point(604, 12);
            this.txtDolar.Name = "txtDolar";
            this.txtDolar.Size = new System.Drawing.Size(34, 20);
            this.txtDolar.TabIndex = 77;
            // 
            // txtLiquidado
            // 
            this.txtLiquidado.Location = new System.Drawing.Point(697, 12);
            this.txtLiquidado.Name = "txtLiquidado";
            this.txtLiquidado.Size = new System.Drawing.Size(34, 20);
            this.txtLiquidado.TabIndex = 79;
            // 
            // txtPendiente
            // 
            this.txtPendiente.Location = new System.Drawing.Point(652, 12);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.Size = new System.Drawing.Size(39, 20);
            this.txtPendiente.TabIndex = 78;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(62, 12);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(77, 20);
            this.txtFechaDesde.TabIndex = 80;
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(145, 12);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(77, 20);
            this.txtFechaHasta.TabIndex = 81;
            // 
            // frmLiquidacionReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 532);
            this.Controls.Add(this.txtFechaHasta);
            this.Controls.Add(this.txtFechaDesde);
            this.Controls.Add(this.txtLiquidado);
            this.Controls.Add(this.txtPendiente);
            this.Controls.Add(this.txtDolar);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.txtTarjetas);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.txtCaja);
            this.Controls.Add(this.btnConsultar);
            this.Name = "frmLiquidacionReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion de tarjetas";
            this.Load += new System.EventHandler(this.frmLiquidacionReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTarjetas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquidado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPendiente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevExpress.XtraEditors.TextEdit txtTarjetas;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtCaja;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLocal;
        private DevExpress.XtraEditors.TextEdit txtDolar;
        private DevExpress.XtraEditors.TextEdit txtLiquidado;
        private DevExpress.XtraEditors.TextEdit txtPendiente;
        private DevExpress.XtraEditors.TextEdit txtFechaDesde;
        private DevExpress.XtraEditors.TextEdit txtFechaHasta;
    }
}