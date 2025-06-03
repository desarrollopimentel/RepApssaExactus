namespace ApssaExactus
{
    partial class frmBuscaArticulo
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
            this.gcArticulo = new DevExpress.XtraGrid.GridControl();
            this.gvArticulo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtArticulo_Buscar = new DevExpress.XtraEditors.TextEdit();
            this.txtArticuloDescripcion_Buscar = new DevExpress.XtraEditors.TextEdit();
            this.txtArticuloDescripcion_Selecc = new DevExpress.XtraEditors.TextEdit();
            this.txtArticulo_Selecc = new DevExpress.XtraEditors.TextEdit();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtUnidad_Selecc = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo_Buscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticuloDescripcion_Buscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticuloDescripcion_Selecc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo_Selecc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidad_Selecc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcArticulo
            // 
            this.gcArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcArticulo.Location = new System.Drawing.Point(3, 47);
            this.gcArticulo.MainView = this.gvArticulo;
            this.gcArticulo.Name = "gcArticulo";
            this.gcArticulo.Size = new System.Drawing.Size(627, 317);
            this.gcArticulo.TabIndex = 0;
            this.gcArticulo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArticulo});
            this.gcArticulo.DoubleClick += new System.EventHandler(this.gcArticulo_DoubleClick);
            // 
            // gvArticulo
            // 
            this.gvArticulo.GridControl = this.gcArticulo;
            this.gvArticulo.Name = "gvArticulo";
            this.gvArticulo.OptionsView.ShowGroupPanel = false;
            this.gvArticulo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvArticulo_FocusedRowChanged);
            this.gvArticulo.DoubleClick += new System.EventHandler(this.gvArticulo_DoubleClick);
            // 
            // txtArticulo_Buscar
            // 
            this.txtArticulo_Buscar.Location = new System.Drawing.Point(3, 21);
            this.txtArticulo_Buscar.Name = "txtArticulo_Buscar";
            this.txtArticulo_Buscar.Size = new System.Drawing.Size(137, 20);
            this.txtArticulo_Buscar.TabIndex = 1;
            this.txtArticulo_Buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArticulo_Buscar_KeyPress);
            // 
            // txtArticuloDescripcion_Buscar
            // 
            this.txtArticuloDescripcion_Buscar.Location = new System.Drawing.Point(146, 21);
            this.txtArticuloDescripcion_Buscar.Name = "txtArticuloDescripcion_Buscar";
            this.txtArticuloDescripcion_Buscar.Size = new System.Drawing.Size(484, 20);
            this.txtArticuloDescripcion_Buscar.TabIndex = 2;
            this.txtArticuloDescripcion_Buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArticuloDescripcion_Buscar_KeyPress);
            // 
            // txtArticuloDescripcion_Selecc
            // 
            this.txtArticuloDescripcion_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArticuloDescripcion_Selecc.Location = new System.Drawing.Point(149, 373);
            this.txtArticuloDescripcion_Selecc.Name = "txtArticuloDescripcion_Selecc";
            this.txtArticuloDescripcion_Selecc.Size = new System.Drawing.Size(379, 20);
            this.txtArticuloDescripcion_Selecc.TabIndex = 4;
            this.txtArticuloDescripcion_Selecc.Visible = false;
            // 
            // txtArticulo_Selecc
            // 
            this.txtArticulo_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArticulo_Selecc.Location = new System.Drawing.Point(3, 373);
            this.txtArticulo_Selecc.Name = "txtArticulo_Selecc";
            this.txtArticulo_Selecc.Size = new System.Drawing.Size(140, 20);
            this.txtArticulo_Selecc.TabIndex = 3;
            this.txtArticulo_Selecc.Visible = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.Location = new System.Drawing.Point(343, 370);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(110, 23);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "Aceptar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "ARTICULO";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(149, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "DESCRIPCION";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(178, 370);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 23);
            this.btnCancelar.TabIndex = 96;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtUnidad_Selecc
            // 
            this.txtUnidad_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnidad_Selecc.Location = new System.Drawing.Point(534, 373);
            this.txtUnidad_Selecc.Name = "txtUnidad_Selecc";
            this.txtUnidad_Selecc.Size = new System.Drawing.Size(96, 20);
            this.txtUnidad_Selecc.TabIndex = 97;
            this.txtUnidad_Selecc.Visible = false;
            // 
            // frmBuscaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 397);
            this.Controls.Add(this.txtUnidad_Selecc);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtArticuloDescripcion_Buscar);
            this.Controls.Add(this.txtArticulo_Buscar);
            this.Controls.Add(this.gcArticulo);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.txtArticuloDescripcion_Selecc);
            this.Controls.Add(this.txtArticulo_Selecc);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Articulo por:";
            this.Load += new System.EventHandler(this.frmBuscaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo_Buscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticuloDescripcion_Buscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticuloDescripcion_Selecc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo_Selecc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidad_Selecc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcArticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArticulo;
        private DevExpress.XtraEditors.TextEdit txtArticulo_Buscar;
        private DevExpress.XtraEditors.TextEdit txtArticuloDescripcion_Buscar;
        private DevExpress.XtraEditors.TextEdit txtArticuloDescripcion_Selecc;
        private DevExpress.XtraEditors.TextEdit txtArticulo_Selecc;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.TextEdit txtUnidad_Selecc;
    }
}