namespace ApssaExactus
{
    partial class frmLiquidacionAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiquidacionAsiento));
            this.btnAsientoCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtAsiento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.gcAsiento = new DevExpress.XtraGrid.GridControl();
            this.gvAsiento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ASIENTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CONSECUTIVO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CENTRO_COSTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUENTA_CONTABLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FUENTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEBITO_LOCAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CREDITO_LOCAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEBITO_DOLAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CREDITO_DOLAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REFERENCIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDiferenciaSoles = new DevExpress.XtraEditors.TextEdit();
            this.txtCreditoLocal = new DevExpress.XtraEditors.TextEdit();
            this.txtDebitoLocal = new DevExpress.XtraEditors.TextEdit();
            this.txtDiferenciaDolares = new DevExpress.XtraEditors.TextEdit();
            this.txtCreditoDolar = new DevExpress.XtraEditors.TextEdit();
            this.txtDebitoDolar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAsientoExportar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAsiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferenciaSoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferenciaDolares.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoDolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoDolar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAsientoCancelar
            // 
            this.btnAsientoCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAsientoCancelar.Location = new System.Drawing.Point(926, 53);
            this.btnAsientoCancelar.Name = "btnAsientoCancelar";
            this.btnAsientoCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnAsientoCancelar.TabIndex = 1;
            this.btnAsientoCancelar.Text = "&Cerrar";
            this.btnAsientoCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.txtDiferenciaSoles);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtCreditoLocal);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtDebitoLocal);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtDiferenciaDolares);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtCreditoDolar);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtDebitoDolar);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAsientoExportar);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAsientoCancelar);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1013, 458);
            this.splitContainerControl1.SplitterPosition = 362;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.txtAsiento);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gcAsiento);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1013, 362);
            this.splitContainerControl2.SplitterPosition = 45;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // txtAsiento
            // 
            this.txtAsiento.Location = new System.Drawing.Point(418, 9);
            this.txtAsiento.Name = "txtAsiento";
            this.txtAsiento.Properties.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.txtAsiento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtAsiento.Properties.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtAsiento.Properties.Appearance.Options.UseBackColor = true;
            this.txtAsiento.Properties.Appearance.Options.UseFont = true;
            this.txtAsiento.Properties.Appearance.Options.UseForeColor = true;
            this.txtAsiento.Size = new System.Drawing.Size(111, 20);
            this.txtAsiento.TabIndex = 166;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(368, 16);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 151;
            this.labelControl6.Text = "ASIENTO";
            // 
            // gcAsiento
            // 
            this.gcAsiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAsiento.Location = new System.Drawing.Point(0, 0);
            this.gcAsiento.MainView = this.gvAsiento;
            this.gcAsiento.Name = "gcAsiento";
            this.gcAsiento.Size = new System.Drawing.Size(1013, 312);
            this.gcAsiento.TabIndex = 81;
            this.gcAsiento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAsiento});
            // 
            // gvAsiento
            // 
            this.gvAsiento.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvAsiento.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvAsiento.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvAsiento.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvAsiento.ColumnPanelRowHeight = 50;
            this.gvAsiento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ASIENTO,
            this.CONSECUTIVO,
            this.NIT,
            this.CENTRO_COSTO,
            this.CUENTA_CONTABLE,
            this.FUENTE,
            this.DEBITO_LOCAL,
            this.CREDITO_LOCAL,
            this.DEBITO_DOLAR,
            this.CREDITO_DOLAR,
            this.REFERENCIA});
            this.gvAsiento.GridControl = this.gcAsiento;
            this.gvAsiento.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvAsiento.Name = "gvAsiento";
            this.gvAsiento.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // ASIENTO
            // 
            this.ASIENTO.Caption = "ASIENTO";
            this.ASIENTO.FieldName = "ASIENTO";
            this.ASIENTO.MinWidth = 75;
            this.ASIENTO.Name = "ASIENTO";
            this.ASIENTO.Visible = true;
            this.ASIENTO.VisibleIndex = 0;
            // 
            // CONSECUTIVO
            // 
            this.CONSECUTIVO.Caption = "Ln";
            this.CONSECUTIVO.FieldName = "CONSECUTIVO";
            this.CONSECUTIVO.Name = "CONSECUTIVO";
            this.CONSECUTIVO.Visible = true;
            this.CONSECUTIVO.VisibleIndex = 1;
            this.CONSECUTIVO.Width = 38;
            // 
            // NIT
            // 
            this.NIT.Caption = "NIT";
            this.NIT.FieldName = "NIT";
            this.NIT.MinWidth = 75;
            this.NIT.Name = "NIT";
            this.NIT.Visible = true;
            this.NIT.VisibleIndex = 2;
            // 
            // CENTRO_COSTO
            // 
            this.CENTRO_COSTO.Caption = "CENTRO COSTO";
            this.CENTRO_COSTO.FieldName = "CENTRO_COSTO";
            this.CENTRO_COSTO.MinWidth = 75;
            this.CENTRO_COSTO.Name = "CENTRO_COSTO";
            this.CENTRO_COSTO.Visible = true;
            this.CENTRO_COSTO.VisibleIndex = 3;
            // 
            // CUENTA_CONTABLE
            // 
            this.CUENTA_CONTABLE.Caption = "CUENTA CONTABLE";
            this.CUENTA_CONTABLE.FieldName = "CUENTA_CONTABLE";
            this.CUENTA_CONTABLE.MinWidth = 75;
            this.CUENTA_CONTABLE.Name = "CUENTA_CONTABLE";
            this.CUENTA_CONTABLE.Visible = true;
            this.CUENTA_CONTABLE.VisibleIndex = 4;
            // 
            // FUENTE
            // 
            this.FUENTE.Caption = "FUENTE";
            this.FUENTE.FieldName = "FUENTE";
            this.FUENTE.MinWidth = 75;
            this.FUENTE.Name = "FUENTE";
            this.FUENTE.Visible = true;
            this.FUENTE.VisibleIndex = 5;
            // 
            // DEBITO_LOCAL
            // 
            this.DEBITO_LOCAL.Caption = "DEBITO LOCAL";
            this.DEBITO_LOCAL.FieldName = "DEBITO_LOCAL";
            this.DEBITO_LOCAL.MinWidth = 75;
            this.DEBITO_LOCAL.Name = "DEBITO_LOCAL";
            this.DEBITO_LOCAL.Visible = true;
            this.DEBITO_LOCAL.VisibleIndex = 6;
            // 
            // CREDITO_LOCAL
            // 
            this.CREDITO_LOCAL.Caption = "CREDITO LOCAL";
            this.CREDITO_LOCAL.FieldName = "CREDITO_LOCAL";
            this.CREDITO_LOCAL.MinWidth = 75;
            this.CREDITO_LOCAL.Name = "CREDITO_LOCAL";
            this.CREDITO_LOCAL.Visible = true;
            this.CREDITO_LOCAL.VisibleIndex = 7;
            // 
            // DEBITO_DOLAR
            // 
            this.DEBITO_DOLAR.Caption = "DEBITO DOLAR";
            this.DEBITO_DOLAR.FieldName = "DEBITO_DOLAR";
            this.DEBITO_DOLAR.MinWidth = 75;
            this.DEBITO_DOLAR.Name = "DEBITO_DOLAR";
            this.DEBITO_DOLAR.Visible = true;
            this.DEBITO_DOLAR.VisibleIndex = 8;
            // 
            // CREDITO_DOLAR
            // 
            this.CREDITO_DOLAR.Caption = "CREDITO DOLAR";
            this.CREDITO_DOLAR.FieldName = "CREDITO_DOLAR";
            this.CREDITO_DOLAR.MinWidth = 75;
            this.CREDITO_DOLAR.Name = "CREDITO_DOLAR";
            this.CREDITO_DOLAR.Visible = true;
            this.CREDITO_DOLAR.VisibleIndex = 9;
            // 
            // REFERENCIA
            // 
            this.REFERENCIA.Caption = "REFERENCIA";
            this.REFERENCIA.FieldName = "REFERENCIA";
            this.REFERENCIA.MinWidth = 350;
            this.REFERENCIA.Name = "REFERENCIA";
            this.REFERENCIA.Visible = true;
            this.REFERENCIA.VisibleIndex = 10;
            this.REFERENCIA.Width = 350;
            // 
            // txtDiferenciaSoles
            // 
            this.txtDiferenciaSoles.Location = new System.Drawing.Point(338, 33);
            this.txtDiferenciaSoles.Name = "txtDiferenciaSoles";
            this.txtDiferenciaSoles.Properties.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDiferenciaSoles.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiferenciaSoles.Properties.Appearance.Options.UseBackColor = true;
            this.txtDiferenciaSoles.Properties.Appearance.Options.UseFont = true;
            this.txtDiferenciaSoles.Properties.Mask.EditMask = "n2";
            this.txtDiferenciaSoles.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiferenciaSoles.Size = new System.Drawing.Size(100, 20);
            this.txtDiferenciaSoles.TabIndex = 162;
            // 
            // txtCreditoLocal
            // 
            this.txtCreditoLocal.Location = new System.Drawing.Point(216, 33);
            this.txtCreditoLocal.Name = "txtCreditoLocal";
            this.txtCreditoLocal.Properties.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCreditoLocal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCreditoLocal.Properties.Appearance.Options.UseBackColor = true;
            this.txtCreditoLocal.Properties.Appearance.Options.UseFont = true;
            this.txtCreditoLocal.Properties.Mask.EditMask = "n2";
            this.txtCreditoLocal.Size = new System.Drawing.Size(100, 20);
            this.txtCreditoLocal.TabIndex = 161;
            // 
            // txtDebitoLocal
            // 
            this.txtDebitoLocal.Location = new System.Drawing.Point(110, 33);
            this.txtDebitoLocal.Name = "txtDebitoLocal";
            this.txtDebitoLocal.Properties.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDebitoLocal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDebitoLocal.Properties.Appearance.Options.UseBackColor = true;
            this.txtDebitoLocal.Properties.Appearance.Options.UseFont = true;
            this.txtDebitoLocal.Properties.Mask.EditMask = "n2";
            this.txtDebitoLocal.Size = new System.Drawing.Size(100, 20);
            this.txtDebitoLocal.TabIndex = 160;
            // 
            // txtDiferenciaDolares
            // 
            this.txtDiferenciaDolares.Location = new System.Drawing.Point(338, 56);
            this.txtDiferenciaDolares.Name = "txtDiferenciaDolares";
            this.txtDiferenciaDolares.Properties.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDiferenciaDolares.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiferenciaDolares.Properties.Appearance.Options.UseBackColor = true;
            this.txtDiferenciaDolares.Properties.Appearance.Options.UseFont = true;
            this.txtDiferenciaDolares.Properties.Mask.EditMask = "n2";
            this.txtDiferenciaDolares.Size = new System.Drawing.Size(100, 20);
            this.txtDiferenciaDolares.TabIndex = 159;
            // 
            // txtCreditoDolar
            // 
            this.txtCreditoDolar.Location = new System.Drawing.Point(216, 56);
            this.txtCreditoDolar.Name = "txtCreditoDolar";
            this.txtCreditoDolar.Properties.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCreditoDolar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCreditoDolar.Properties.Appearance.Options.UseBackColor = true;
            this.txtCreditoDolar.Properties.Appearance.Options.UseFont = true;
            this.txtCreditoDolar.Properties.Mask.EditMask = "n2";
            this.txtCreditoDolar.Size = new System.Drawing.Size(100, 20);
            this.txtCreditoDolar.TabIndex = 158;
            // 
            // txtDebitoDolar
            // 
            this.txtDebitoDolar.Location = new System.Drawing.Point(110, 56);
            this.txtDebitoDolar.Name = "txtDebitoDolar";
            this.txtDebitoDolar.Properties.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDebitoDolar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDebitoDolar.Properties.Appearance.Options.UseBackColor = true;
            this.txtDebitoDolar.Properties.Appearance.Options.UseFont = true;
            this.txtDebitoDolar.Properties.Mask.EditMask = "n2";
            this.txtDebitoDolar.Size = new System.Drawing.Size(100, 20);
            this.txtDebitoDolar.TabIndex = 157;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(367, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 13);
            this.labelControl5.TabIndex = 153;
            this.labelControl5.Text = "Diferencias";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(249, 16);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 152;
            this.labelControl4.Text = "Creditos";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(130, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 151;
            this.labelControl3.Text = "Debitos";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 150;
            this.labelControl1.Text = "Dolares US$";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(52, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 149;
            this.labelControl2.Text = "Soles S/.";
            // 
            // btnAsientoExportar
            // 
            this.btnAsientoExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAsientoExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnAsientoExportar.Image")));
            this.btnAsientoExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAsientoExportar.Location = new System.Drawing.Point(830, 53);
            this.btnAsientoExportar.Name = "btnAsientoExportar";
            this.btnAsientoExportar.Size = new System.Drawing.Size(90, 25);
            this.btnAsientoExportar.TabIndex = 92;
            this.btnAsientoExportar.Text = "Exportar";
            this.btnAsientoExportar.Click += new System.EventHandler(this.btnExportarXls_Click);
            // 
            // frmLiquidacionAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 458);
            this.Controls.Add(this.splitContainerControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLiquidacionAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asiento Contable";
            this.Load += new System.EventHandler(this.frmLiquidacionAsiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAsiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAsiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferenciaSoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferenciaDolares.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditoDolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitoDolar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnAsientoCancelar;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnAsientoExportar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtAsiento;
        private DevExpress.XtraEditors.TextEdit txtDiferenciaDolares;
        private DevExpress.XtraEditors.TextEdit txtCreditoDolar;
        private DevExpress.XtraEditors.TextEdit txtDebitoDolar;
        private DevExpress.XtraEditors.TextEdit txtDiferenciaSoles;
        private DevExpress.XtraEditors.TextEdit txtCreditoLocal;
        private DevExpress.XtraEditors.TextEdit txtDebitoLocal;
        private DevExpress.XtraGrid.GridControl gcAsiento;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAsiento;
        private DevExpress.XtraGrid.Columns.GridColumn ASIENTO;
        private DevExpress.XtraGrid.Columns.GridColumn CONSECUTIVO;
        private DevExpress.XtraGrid.Columns.GridColumn NIT;
        private DevExpress.XtraGrid.Columns.GridColumn CENTRO_COSTO;
        private DevExpress.XtraGrid.Columns.GridColumn CUENTA_CONTABLE;
        private DevExpress.XtraGrid.Columns.GridColumn FUENTE;
        private DevExpress.XtraGrid.Columns.GridColumn REFERENCIA;
        private DevExpress.XtraGrid.Columns.GridColumn DEBITO_LOCAL;
        private DevExpress.XtraGrid.Columns.GridColumn CREDITO_LOCAL;
        private DevExpress.XtraGrid.Columns.GridColumn DEBITO_DOLAR;
        private DevExpress.XtraGrid.Columns.GridColumn CREDITO_DOLAR;
    }
}