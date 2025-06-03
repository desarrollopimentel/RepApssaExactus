namespace ApssaExactus
{
    partial class frmLiquidacionReporteFiltros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiquidacionReporteFiltros));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl47 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl48 = new DevExpress.XtraEditors.LabelControl();
            this.cboCaja = new System.Windows.Forms.ComboBox();
            this.labelControl57 = new DevExpress.XtraEditors.LabelControl();
            this.cboTarjetas = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkPendiente = new DevExpress.XtraEditors.CheckEdit();
            this.checkLiquidado = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkDolar = new DevExpress.XtraEditors.CheckEdit();
            this.checkLocal = new DevExpress.XtraEditors.CheckEdit();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPendiente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLiquidado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(236, 63);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Size = new System.Drawing.Size(88, 20);
            this.deFechaHasta.TabIndex = 140;
            // 
            // labelControl47
            // 
            this.labelControl47.Location = new System.Drawing.Point(202, 70);
            this.labelControl47.Name = "labelControl47";
            this.labelControl47.Size = new System.Drawing.Size(28, 13);
            this.labelControl47.TabIndex = 138;
            this.labelControl47.Text = "Hasta";
            // 
            // labelControl48
            // 
            this.labelControl48.Location = new System.Drawing.Point(38, 70);
            this.labelControl48.Name = "labelControl48";
            this.labelControl48.Size = new System.Drawing.Size(30, 13);
            this.labelControl48.TabIndex = 137;
            this.labelControl48.Text = "Desde";
            // 
            // cboCaja
            // 
            this.cboCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCaja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboCaja.ForeColor = System.Drawing.Color.MediumBlue;
            this.cboCaja.FormattingEnabled = true;
            this.cboCaja.Location = new System.Drawing.Point(93, 109);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Size = new System.Drawing.Size(169, 21);
            this.cboCaja.TabIndex = 159;
            // 
            // labelControl57
            // 
            this.labelControl57.Location = new System.Drawing.Point(42, 117);
            this.labelControl57.Name = "labelControl57";
            this.labelControl57.Size = new System.Drawing.Size(40, 13);
            this.labelControl57.TabIndex = 158;
            this.labelControl57.Text = "Sucursal";
            // 
            // cboTarjetas
            // 
            this.cboTarjetas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTarjetas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboTarjetas.ForeColor = System.Drawing.Color.MediumBlue;
            this.cboTarjetas.FormattingEnabled = true;
            this.cboTarjetas.Location = new System.Drawing.Point(93, 147);
            this.cboTarjetas.Name = "cboTarjetas";
            this.cboTarjetas.Size = new System.Drawing.Size(169, 21);
            this.cboTarjetas.TabIndex = 161;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 155);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 160;
            this.labelControl1.Text = "Tarjeta";
            // 
            // checkPendiente
            // 
            this.checkPendiente.Location = new System.Drawing.Point(91, 219);
            this.checkPendiente.Name = "checkPendiente";
            this.checkPendiente.Properties.Caption = "Pendiente";
            this.checkPendiente.Size = new System.Drawing.Size(75, 19);
            this.checkPendiente.TabIndex = 162;
            // 
            // checkLiquidado
            // 
            this.checkLiquidado.Location = new System.Drawing.Point(187, 219);
            this.checkLiquidado.Name = "checkLiquidado";
            this.checkLiquidado.Properties.Caption = "Liquidado";
            this.checkLiquidado.Size = new System.Drawing.Size(75, 19);
            this.checkLiquidado.TabIndex = 163;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 222);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 164;
            this.labelControl2.Text = "Estado";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(187, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 25);
            this.btnCancelar.TabIndex = 166;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ToolTip = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(64, 276);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 23);
            this.btnImprimir.TabIndex = 165;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.ToolTip = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(38, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 167;
            this.labelControl3.Text = "Fechas";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(49, 188);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 170;
            this.labelControl4.Text = "Moneda";
            // 
            // checkDolar
            // 
            this.checkDolar.Location = new System.Drawing.Point(187, 185);
            this.checkDolar.Name = "checkDolar";
            this.checkDolar.Properties.Caption = "Dolares";
            this.checkDolar.Size = new System.Drawing.Size(75, 19);
            this.checkDolar.TabIndex = 169;
            // 
            // checkLocal
            // 
            this.checkLocal.Location = new System.Drawing.Point(91, 185);
            this.checkLocal.Name = "checkLocal";
            this.checkLocal.Properties.Caption = "Local";
            this.checkLocal.Size = new System.Drawing.Size(75, 19);
            this.checkLocal.TabIndex = 168;
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(91, 63);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Size = new System.Drawing.Size(88, 20);
            this.deFechaDesde.TabIndex = 171;
            // 
            // frmLiquidacionReporteFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 313);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.checkDolar);
            this.Controls.Add(this.checkLocal);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.checkLiquidado);
            this.Controls.Add(this.checkPendiente);
            this.Controls.Add(this.cboTarjetas);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboCaja);
            this.Controls.Add(this.labelControl57);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl47);
            this.Controls.Add(this.labelControl48);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLiquidacionReporteFiltros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte De Liquidacion";
            this.Load += new System.EventHandler(this.frmLiquidacionReporteFiltros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPendiente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLiquidado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl47;
        private DevExpress.XtraEditors.LabelControl labelControl48;
        private System.Windows.Forms.ComboBox cboCaja;
        private DevExpress.XtraEditors.LabelControl labelControl57;
        private System.Windows.Forms.ComboBox cboTarjetas;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkPendiente;
        private DevExpress.XtraEditors.CheckEdit checkLiquidado;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit checkDolar;
        private DevExpress.XtraEditors.CheckEdit checkLocal;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
    }
}