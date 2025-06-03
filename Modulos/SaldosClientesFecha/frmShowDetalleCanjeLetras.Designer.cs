namespace ApssaExactus
{
    partial class frmShowDetalleCanjeLetras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDetalleCanjeLetras));
            this.btnActualizaClientes = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnImprimirLetraCanje = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportarHistorico = new DevExpress.XtraEditors.SimpleButton();
            this.lblMensajeEstado = new DevExpress.XtraEditors.LabelControl();
            this.txtClienteNombre = new DevExpress.XtraEditors.TextEdit();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcDetalles = new DevExpress.XtraGrid.GridControl();
            this.gvDetalles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocumentoCanje = new DevExpress.XtraEditors.TextEdit();
            this.txtTipoCanje = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentoCanje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCanje.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizaClientes
            // 
            this.btnActualizaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizaClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizaClientes.Image")));
            this.btnActualizaClientes.Location = new System.Drawing.Point(889, 6);
            this.btnActualizaClientes.Name = "btnActualizaClientes";
            this.btnActualizaClientes.Size = new System.Drawing.Size(90, 23);
            this.btnActualizaClientes.TabIndex = 92;
            this.btnActualizaClientes.Text = "Actualizar";
            this.btnActualizaClientes.ToolTip = "Actualiza informacion segun parametros";
            this.btnActualizaClientes.Click += new System.EventHandler(this.btnActualizaClientes_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.Location = new System.Drawing.Point(517, 407);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 94;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(364, 407);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.txtDocumentoCanje);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtTipoCanje);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnImprimirLetraCanje);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnExportarHistorico);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnActualizaClientes);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblMensajeEstado);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtClienteNombre);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtCliente);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl8);
            this.splitContainerControl1.Panel1.Controls.Add(this.separatorControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(987, 435);
            this.splitContainerControl1.SplitterPosition = 44;
            this.splitContainerControl1.TabIndex = 114;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnImprimirLetraCanje
            // 
            this.btnImprimirLetraCanje.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirLetraCanje.Image")));
            this.btnImprimirLetraCanje.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnImprimirLetraCanje.Location = new System.Drawing.Point(680, 6);
            this.btnImprimirLetraCanje.Name = "btnImprimirLetraCanje";
            this.btnImprimirLetraCanje.Size = new System.Drawing.Size(100, 23);
            this.btnImprimirLetraCanje.TabIndex = 128;
            this.btnImprimirLetraCanje.Tag = "6010101003";
            this.btnImprimirLetraCanje.Text = "Imprimir Letras";
            this.btnImprimirLetraCanje.ToolTip = "Imprime Letra Seleccionada";
            // 
            // btnExportarHistorico
            // 
            this.btnExportarHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarHistorico.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarHistorico.Image")));
            this.btnExportarHistorico.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarHistorico.Location = new System.Drawing.Point(786, 6);
            this.btnExportarHistorico.Name = "btnExportarHistorico";
            this.btnExportarHistorico.Size = new System.Drawing.Size(100, 23);
            this.btnExportarHistorico.TabIndex = 111;
            this.btnExportarHistorico.Text = "Exportar Excel";
            this.btnExportarHistorico.ToolTip = "Exporta Documentos Historico";
            // 
            // lblMensajeEstado
            // 
            this.lblMensajeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensajeEstado.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.lblMensajeEstado.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblMensajeEstado.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMensajeEstado.Appearance.Options.UseBackColor = true;
            this.lblMensajeEstado.Appearance.Options.UseFont = true;
            this.lblMensajeEstado.Appearance.Options.UseForeColor = true;
            this.lblMensajeEstado.Appearance.Options.UseTextOptions = true;
            this.lblMensajeEstado.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMensajeEstado.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMensajeEstado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblMensajeEstado.Location = new System.Drawing.Point(769, 10);
            this.lblMensajeEstado.Name = "lblMensajeEstado";
            this.lblMensajeEstado.Size = new System.Drawing.Size(144, 19);
            this.lblMensajeEstado.TabIndex = 127;
            this.lblMensajeEstado.Text = "Cliente Castigado";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(373, 9);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtClienteNombre.Properties.Appearance.Options.UseFont = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(301, 20);
            this.txtClienteNombre.TabIndex = 110;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(267, 9);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 109;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl1.Location = new System.Drawing.Point(3, 23);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(976, 25);
            this.separatorControl1.TabIndex = 126;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(987, 386);
            this.xtraTabControl1.TabIndex = 115;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcDetalles);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(981, 358);
            this.xtraTabPage1.Text = "Letras";
            // 
            // gcDetalles
            // 
            this.gcDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetalles.Location = new System.Drawing.Point(0, 0);
            this.gcDetalles.MainView = this.gvDetalles;
            this.gcDetalles.Name = "gcDetalles";
            this.gcDetalles.Size = new System.Drawing.Size(981, 358);
            this.gcDetalles.TabIndex = 114;
            this.gcDetalles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetalles});
            // 
            // gvDetalles
            // 
            this.gvDetalles.GridControl = this.gcDetalles;
            this.gvDetalles.Name = "gvDetalles";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(981, 358);
            this.xtraTabPage2.Text = "~";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(222, 16);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(39, 13);
            this.labelControl8.TabIndex = 108;
            this.labelControl8.Text = "Cliente";
            // 
            // txtDocumentoCanje
            // 
            this.txtDocumentoCanje.Location = new System.Drawing.Point(98, 9);
            this.txtDocumentoCanje.Name = "txtDocumentoCanje";
            this.txtDocumentoCanje.Size = new System.Drawing.Size(109, 20);
            this.txtDocumentoCanje.TabIndex = 131;
            // 
            // txtTipoCanje
            // 
            this.txtTipoCanje.Location = new System.Drawing.Point(51, 9);
            this.txtTipoCanje.Name = "txtTipoCanje";
            this.txtTipoCanje.Size = new System.Drawing.Size(41, 20);
            this.txtTipoCanje.TabIndex = 130;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 129;
            this.labelControl1.Text = "Canje";
            // 
            // frmShowDetalleCanjeLetras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 435);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDetalleCanjeLetras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Canjes";
            this.Load += new System.EventHandler(this.frmShowDetalleCanjeLetras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentoCanje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCanje.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnActualizaClientes;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.TextEdit txtClienteNombre;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraGrid.GridControl gcDetalles;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetalles;
        private DevExpress.XtraEditors.SimpleButton btnExportarHistorico;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.LabelControl lblMensajeEstado;
        private DevExpress.XtraEditors.SimpleButton btnImprimirLetraCanje;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit txtDocumentoCanje;
        private DevExpress.XtraEditors.TextEdit txtTipoCanje;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}