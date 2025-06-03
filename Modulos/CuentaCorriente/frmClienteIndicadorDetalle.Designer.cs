namespace ApssaExactus
{
    partial class frmClienteIndicadorDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClienteIndicadorDetalle));
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCobClienteNombre = new DevExpress.XtraEditors.TextEdit();
            this.txtCobCliente = new DevExpress.XtraEditors.TextEdit();
            this.gcCliente = new DevExpress.XtraGrid.GridControl();
            this.gvCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCobEjercicio = new DevExpress.XtraEditors.TextEdit();
            this.txtCobMes = new DevExpress.XtraEditors.TextEdit();
            this.btnExportarDetalle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobClienteNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobEjercicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobMes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(888, 9);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(87, 23);
            this.btnActualizar.TabIndex = 92;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.ToolTip = "Actualiza informacion segun parametros";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizaClientes_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.Location = new System.Drawing.Point(539, 533);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 94;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(450, 533);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "&Cerrar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl17.Location = new System.Drawing.Point(648, 19);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(36, 13);
            this.labelControl17.TabIndex = 108;
            this.labelControl17.Text = "Periodo";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(159, 19);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 13);
            this.labelControl8.TabIndex = 106;
            this.labelControl8.Text = "Razon Social";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 110;
            this.labelControl1.Text = "Cliente";
            // 
            // txtCobClienteNombre
            // 
            this.txtCobClienteNombre.Location = new System.Drawing.Point(228, 12);
            this.txtCobClienteNombre.Name = "txtCobClienteNombre";
            this.txtCobClienteNombre.Size = new System.Drawing.Size(328, 20);
            this.txtCobClienteNombre.TabIndex = 111;
            // 
            // txtCobCliente
            // 
            this.txtCobCliente.Location = new System.Drawing.Point(56, 12);
            this.txtCobCliente.Name = "txtCobCliente";
            this.txtCobCliente.Size = new System.Drawing.Size(94, 20);
            this.txtCobCliente.TabIndex = 112;
            // 
            // gcCliente
            // 
            this.gcCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCliente.Location = new System.Drawing.Point(6, 45);
            this.gcCliente.MainView = this.gvCliente;
            this.gcCliente.Name = "gcCliente";
            this.gcCliente.Size = new System.Drawing.Size(972, 482);
            this.gcCliente.TabIndex = 113;
            this.gcCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCliente});
            // 
            // gvCliente
            // 
            this.gvCliente.GridControl = this.gcCliente;
            this.gvCliente.Name = "gvCliente";
            // 
            // txtCobEjercicio
            // 
            this.txtCobEjercicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCobEjercicio.Location = new System.Drawing.Point(689, 12);
            this.txtCobEjercicio.Name = "txtCobEjercicio";
            this.txtCobEjercicio.Size = new System.Drawing.Size(44, 20);
            this.txtCobEjercicio.TabIndex = 114;
            // 
            // txtCobMes
            // 
            this.txtCobMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCobMes.Location = new System.Drawing.Point(741, 12);
            this.txtCobMes.Name = "txtCobMes";
            this.txtCobMes.Size = new System.Drawing.Size(114, 20);
            this.txtCobMes.TabIndex = 115;
            // 
            // btnExportarDetalle
            // 
            this.btnExportarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarDetalle.Image")));
            this.btnExportarDetalle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarDetalle.Location = new System.Drawing.Point(10, 533);
            this.btnExportarDetalle.Name = "btnExportarDetalle";
            this.btnExportarDetalle.Size = new System.Drawing.Size(110, 23);
            this.btnExportarDetalle.TabIndex = 116;
            this.btnExportarDetalle.Text = "Exportar Excel";
            this.btnExportarDetalle.ToolTip = "Exporta Cobranza Detalle";
            this.btnExportarDetalle.Click += new System.EventHandler(this.btnExportarDetalle_Click);
            // 
            // frmClienteIndicadorDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnExportarDetalle);
            this.Controls.Add(this.txtCobMes);
            this.Controls.Add(this.txtCobEjercicio);
            this.Controls.Add(this.gcCliente);
            this.Controls.Add(this.txtCobCliente);
            this.Controls.Add(this.txtCobClienteNombre);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClienteIndicadorDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes - Cobranza Detalle";
            this.Load += new System.EventHandler(this.frmClienteIndicadorDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCobClienteNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobEjercicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobMes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCobClienteNombre;
        private DevExpress.XtraEditors.TextEdit txtCobCliente;
        private DevExpress.XtraGrid.GridControl gcCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCliente;
        private DevExpress.XtraEditors.TextEdit txtCobEjercicio;
        private DevExpress.XtraEditors.TextEdit txtCobMes;
        private DevExpress.XtraEditors.SimpleButton btnExportarDetalle;
    }
}