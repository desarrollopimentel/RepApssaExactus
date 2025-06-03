namespace ApssaExactus
{
    partial class frmBusca_Articulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusca_Articulo));
            this.gcArticulo = new DevExpress.XtraGrid.GridControl();
            this.gvArticulo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpEditFamilia = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditSubFamilia = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lookUpEditGrupo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnActualizaVersionNivel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnFiltarFamilia = new DevExpress.XtraEditors.SimpleButton();
            this.gridColFAMILIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSUBFAMILIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGRUPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMARCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLINEA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColARTICULO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDESCRIPCION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUNIDAD_ALMACEN = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFamilia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSubFamilia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditGrupo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcArticulo
            // 
            this.gcArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcArticulo.Location = new System.Drawing.Point(6, 50);
            this.gcArticulo.MainView = this.gvArticulo;
            this.gcArticulo.Name = "gcArticulo";
            this.gcArticulo.Size = new System.Drawing.Size(967, 386);
            this.gcArticulo.TabIndex = 1;
            this.gcArticulo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArticulo});
            // 
            // gvArticulo
            // 
            this.gvArticulo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColFAMILIA,
            this.gridColSUBFAMILIA,
            this.gridColGRUPO,
            this.gridColMARCA,
            this.gridColLINEA,
            this.gridColARTICULO,
            this.gridColDESCRIPCION,
            this.gridColUNIDAD_ALMACEN});
            this.gvArticulo.GridControl = this.gcArticulo;
            this.gvArticulo.Name = "gvArticulo";
            this.gvArticulo.OptionsFind.AlwaysVisible = true;
            this.gvArticulo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvArticulo_FocusedRowChanged);
            // 
            // lookUpEditFamilia
            // 
            this.lookUpEditFamilia.Location = new System.Drawing.Point(83, 18);
            this.lookUpEditFamilia.Name = "lookUpEditFamilia";
            this.lookUpEditFamilia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookUpEditFamilia.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditFamilia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFamilia.Properties.NullText = "[Vacío]";
            this.lookUpEditFamilia.Size = new System.Drawing.Size(132, 20);
            this.lookUpEditFamilia.TabIndex = 89;
            this.lookUpEditFamilia.ToolTip = "Seleccione la Familia de Articulo";
            this.lookUpEditFamilia.EditValueChanged += new System.EventHandler(this.lookUpEditFamilia_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(232, 22);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(50, 13);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "SubFamilia";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(47, 25);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 86;
            this.labelControl5.Text = "Familia";
            // 
            // lookUpEditSubFamilia
            // 
            this.lookUpEditSubFamilia.Location = new System.Drawing.Point(287, 18);
            this.lookUpEditSubFamilia.Name = "lookUpEditSubFamilia";
            this.lookUpEditSubFamilia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookUpEditSubFamilia.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditSubFamilia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSubFamilia.Properties.NullText = "[Vacío]";
            this.lookUpEditSubFamilia.Size = new System.Drawing.Size(132, 20);
            this.lookUpEditSubFamilia.TabIndex = 90;
            this.lookUpEditSubFamilia.ToolTip = "Seleccione la SubFamilia de Articulo";
            this.lookUpEditSubFamilia.EditValueChanged += new System.EventHandler(this.lookUpEditSubFamilia_EditValueChanged);
            // 
            // lookUpEditGrupo
            // 
            this.lookUpEditGrupo.Location = new System.Drawing.Point(465, 18);
            this.lookUpEditGrupo.Name = "lookUpEditGrupo";
            this.lookUpEditGrupo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookUpEditGrupo.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditGrupo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditGrupo.Properties.NullText = "[Vacío]";
            this.lookUpEditGrupo.Size = new System.Drawing.Size(132, 20);
            this.lookUpEditGrupo.TabIndex = 91;
            this.lookUpEditGrupo.ToolTip = "Seleccione el Grupo de Articulo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(431, 22);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(29, 13);
            this.labelControl7.TabIndex = 88;
            this.labelControl7.Text = "Grupo";
            // 
            // btnActualizaVersionNivel
            // 
            this.btnActualizaVersionNivel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizaVersionNivel.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizaVersionNivel.Image")));
            this.btnActualizaVersionNivel.Location = new System.Drawing.Point(886, 17);
            this.btnActualizaVersionNivel.Name = "btnActualizaVersionNivel";
            this.btnActualizaVersionNivel.Size = new System.Drawing.Size(87, 23);
            this.btnActualizaVersionNivel.TabIndex = 92;
            this.btnActualizaVersionNivel.Text = "Actualizar";
            this.btnActualizaVersionNivel.ToolTip = "Actualiza informacion segun parametros";
            this.btnActualizaVersionNivel.Click += new System.EventHandler(this.btnActualizaVersionNivel_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.Location = new System.Drawing.Point(516, 442);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 94;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(363, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFiltarFamilia
            // 
            this.btnFiltarFamilia.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltarFamilia.Image")));
            this.btnFiltarFamilia.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFiltarFamilia.Location = new System.Drawing.Point(8, 18);
            this.btnFiltarFamilia.Name = "btnFiltarFamilia";
            this.btnFiltarFamilia.Size = new System.Drawing.Size(29, 22);
            this.btnFiltarFamilia.TabIndex = 97;
            this.btnFiltarFamilia.ToolTip = "Selecciona las Familias a mostrar";
            this.btnFiltarFamilia.ToolTipTitle = "Sugerir Familias";
            this.btnFiltarFamilia.Click += new System.EventHandler(this.btnFiltarFamilia_Click);
            // 
            // gridColFAMILIA
            // 
            this.gridColFAMILIA.Caption = "FAMILIA";
            this.gridColFAMILIA.FieldName = "FAMILIA";
            this.gridColFAMILIA.Name = "gridColFAMILIA";
            this.gridColFAMILIA.Visible = true;
            this.gridColFAMILIA.VisibleIndex = 0;
            this.gridColFAMILIA.Width = 80;
            // 
            // gridColSUBFAMILIA
            // 
            this.gridColSUBFAMILIA.Caption = "SUBFAMILIA";
            this.gridColSUBFAMILIA.FieldName = "SUBFAMILIA";
            this.gridColSUBFAMILIA.Name = "gridColSUBFAMILIA";
            this.gridColSUBFAMILIA.Visible = true;
            this.gridColSUBFAMILIA.VisibleIndex = 1;
            this.gridColSUBFAMILIA.Width = 97;
            // 
            // gridColGRUPO
            // 
            this.gridColGRUPO.Caption = "GRUPO";
            this.gridColGRUPO.FieldName = "GRUPO";
            this.gridColGRUPO.Name = "gridColGRUPO";
            this.gridColGRUPO.Visible = true;
            this.gridColGRUPO.VisibleIndex = 2;
            this.gridColGRUPO.Width = 97;
            // 
            // gridColMARCA
            // 
            this.gridColMARCA.Caption = "MARCA";
            this.gridColMARCA.FieldName = "MARCA";
            this.gridColMARCA.Name = "gridColMARCA";
            this.gridColMARCA.Visible = true;
            this.gridColMARCA.VisibleIndex = 3;
            this.gridColMARCA.Width = 97;
            // 
            // gridColLINEA
            // 
            this.gridColLINEA.Caption = "LINEA";
            this.gridColLINEA.FieldName = "LINEA";
            this.gridColLINEA.Name = "gridColLINEA";
            this.gridColLINEA.Visible = true;
            this.gridColLINEA.VisibleIndex = 4;
            this.gridColLINEA.Width = 97;
            // 
            // gridColARTICULO
            // 
            this.gridColARTICULO.Caption = "ARTICULO";
            this.gridColARTICULO.FieldName = "ARTICULO";
            this.gridColARTICULO.Name = "gridColARTICULO";
            this.gridColARTICULO.Visible = true;
            this.gridColARTICULO.VisibleIndex = 5;
            this.gridColARTICULO.Width = 97;
            // 
            // gridColDESCRIPCION
            // 
            this.gridColDESCRIPCION.Caption = "DESCRIPCION";
            this.gridColDESCRIPCION.FieldName = "DESCRIPCION";
            this.gridColDESCRIPCION.Name = "gridColDESCRIPCION";
            this.gridColDESCRIPCION.Visible = true;
            this.gridColDESCRIPCION.VisibleIndex = 6;
            this.gridColDESCRIPCION.Width = 281;
            // 
            // gridColUNIDAD_ALMACEN
            // 
            this.gridColUNIDAD_ALMACEN.Caption = "UNIDAD";
            this.gridColUNIDAD_ALMACEN.FieldName = "UNIDAD_ALMACEN";
            this.gridColUNIDAD_ALMACEN.Name = "gridColUNIDAD_ALMACEN";
            this.gridColUNIDAD_ALMACEN.Visible = true;
            this.gridColUNIDAD_ALMACEN.VisibleIndex = 7;
            // 
            // frmBusca_Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 472);
            this.Controls.Add(this.btnFiltarFamilia);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizaVersionNivel);
            this.Controls.Add(this.lookUpEditFamilia);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lookUpEditSubFamilia);
            this.Controls.Add(this.lookUpEditGrupo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.gcArticulo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusca_Articulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBusca_Articulo";
            this.Load += new System.EventHandler(this.frmBusca_Articulo_Load);
            //this.Shown += new System.EventHandler(this.frmBusca_Articulo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFamilia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSubFamilia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditGrupo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcArticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArticulo;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lookUpEditFamilia;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lookUpEditSubFamilia;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lookUpEditGrupo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnActualizaVersionNivel;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnFiltarFamilia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFAMILIA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSUBFAMILIA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGRUPO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMARCA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLINEA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColARTICULO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDESCRIPCION;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUNIDAD_ALMACEN;
    }
}