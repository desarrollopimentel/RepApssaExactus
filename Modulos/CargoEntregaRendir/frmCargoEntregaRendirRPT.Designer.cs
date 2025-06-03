namespace ApssaExactus
{
    partial class frmCargoEntregaRendirRPT
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
            this.pIMENTELDataSetERBindingSource = new System.Windows.Forms.BindingSource();
            this.pIMENTELDataSetER = new ApssaExactus.PIMENTELDataSetER();
            this.PIMENTELDataSet = new ApssaExactus.PIMENTELDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_APSSA_ARCHIVO_ER_CARGOBindingSource = new System.Windows.Forms.BindingSource();
            this.SP_APSSA_ARCHIVO_ER_CARGOTableAdapter = new ApssaExactus.PIMENTELDataSetERTableAdapters.SP_APSSA_ARCHIVO_ER_CARGOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pIMENTELDataSetERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIMENTELDataSetER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIMENTELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_APSSA_ARCHIVO_ER_CARGOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pIMENTELDataSetERBindingSource
            // 
            this.pIMENTELDataSetERBindingSource.DataSource = this.pIMENTELDataSetER;
            this.pIMENTELDataSetERBindingSource.Position = 0;
            // 
            // pIMENTELDataSetER
            // 
            this.pIMENTELDataSetER.DataSetName = "PIMENTELDataSetER";
            this.pIMENTELDataSetER.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PIMENTELDataSet
            // 
            this.PIMENTELDataSet.DataSetName = "PIMENTELDataSet";
            this.PIMENTELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsER";
            reportDataSource1.Value = this.SP_APSSA_ARCHIVO_ER_CARGOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ApssaExactus.RptCargoEntregaRendir.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(973, 655);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_APSSA_ARCHIVO_ER_CARGOBindingSource
            // 
            this.SP_APSSA_ARCHIVO_ER_CARGOBindingSource.DataMember = "SP_APSSA_ARCHIVO_ER_CARGO";
            this.SP_APSSA_ARCHIVO_ER_CARGOBindingSource.DataSource = this.pIMENTELDataSetER;
            // 
            // SP_APSSA_ARCHIVO_ER_CARGOTableAdapter
            // 
            this.SP_APSSA_ARCHIVO_ER_CARGOTableAdapter.ClearBeforeFill = true;
            // 
            // frmCargoEntregaRendirRPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 655);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCargoEntregaRendirRPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargo Entrega a Rendir";
            this.Load += new System.EventHandler(this.frmCargoEntregaRendirRPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pIMENTELDataSetERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIMENTELDataSetER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIMENTELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_APSSA_ARCHIVO_ER_CARGOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PIMENTELDataSet PIMENTELDataSet;
        private System.Windows.Forms.BindingSource pIMENTELDataSetERBindingSource;
        private PIMENTELDataSetER pIMENTELDataSetER;
        private System.Windows.Forms.BindingSource SP_APSSA_ARCHIVO_ER_CARGOBindingSource;
        private PIMENTELDataSetERTableAdapters.SP_APSSA_ARCHIVO_ER_CARGOTableAdapter SP_APSSA_ARCHIVO_ER_CARGOTableAdapter;
    }
}