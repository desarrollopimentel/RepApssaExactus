namespace ApssaExactus
{
    partial class frmBuscaClienteV2
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
            this.gcCliente = new DevExpress.XtraGrid.GridControl();
            this.gvCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtClienteNombre = new DevExpress.XtraEditors.TextEdit();
            this.txtClienteNombre_Selecc = new DevExpress.XtraEditors.TextEdit();
            this.txtCliente_Selecc = new DevExpress.XtraEditors.TextEdit();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteNombre_Selecc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente_Selecc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCliente
            // 
            this.gcCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCliente.Location = new System.Drawing.Point(3, 47);
            this.gcCliente.MainView = this.gvCliente;
            this.gcCliente.Name = "gcCliente";
            this.gcCliente.Size = new System.Drawing.Size(627, 317);
            this.gcCliente.TabIndex = 0;
            this.gcCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCliente});
            this.gcCliente.DoubleClick += new System.EventHandler(this.gcCliente_DoubleClick);
            // 
            // gvCliente
            // 
            this.gvCliente.GridControl = this.gcCliente;
            this.gvCliente.Name = "gvCliente";
            this.gvCliente.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCliente_FocusedRowChanged);
            //this.gvCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvCliente_KeyPress);
            this.gvCliente.DoubleClick += new System.EventHandler(this.gvCliente_DoubleClick);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(3, 21);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(137, 20);
            this.txtCliente.TabIndex = 1;
            //this.txtCliente.EditValueChanged += new System.EventHandler(this.txtCliente_EditValueChanged);
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(146, 21);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(484, 20);
            this.txtClienteNombre.TabIndex = 2;
            this.txtClienteNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClienteNombre_KeyPress);
            // 
            // txtClienteNombre_Selecc
            // 
            this.txtClienteNombre_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClienteNombre_Selecc.Location = new System.Drawing.Point(149, 373);
            this.txtClienteNombre_Selecc.Name = "txtClienteNombre_Selecc";
            this.txtClienteNombre_Selecc.Size = new System.Drawing.Size(481, 20);
            this.txtClienteNombre_Selecc.TabIndex = 4;
            this.txtClienteNombre_Selecc.Visible = false;
            // 
            // txtCliente_Selecc
            // 
            this.txtCliente_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente_Selecc.Location = new System.Drawing.Point(3, 373);
            this.txtCliente_Selecc.Name = "txtCliente_Selecc";
            this.txtCliente_Selecc.Size = new System.Drawing.Size(140, 20);
            this.txtCliente_Selecc.TabIndex = 3;
            this.txtCliente_Selecc.Visible = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.Location = new System.Drawing.Point(509, 370);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(118, 23);
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
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "RUC";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(149, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "NOMBRE";
            // 
            // frmBuscaClienteV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 397);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtClienteNombre);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.gcCliente);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.txtClienteNombre_Selecc);
            this.Controls.Add(this.txtCliente_Selecc);
            this.Name = "frmBuscaClienteV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Cliente por:";
            this.Load += new System.EventHandler(this.frmBuscaClienteV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteNombre_Selecc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente_Selecc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCliente;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.TextEdit txtClienteNombre;
        private DevExpress.XtraEditors.TextEdit txtClienteNombre_Selecc;
        private DevExpress.XtraEditors.TextEdit txtCliente_Selecc;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}