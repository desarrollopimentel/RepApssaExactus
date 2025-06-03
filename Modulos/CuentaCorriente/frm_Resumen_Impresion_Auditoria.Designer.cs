namespace ApssaExactus
{
    partial class frm_Resumen_Impresion_Auditoria
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
            this.rpt_docaudi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpt_docaudi
            // 
            this.rpt_docaudi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_docaudi.Location = new System.Drawing.Point(0, 0);
            this.rpt_docaudi.Name = "rpt_docaudi";
            this.rpt_docaudi.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rpt_docaudi.Size = new System.Drawing.Size(863, 582);
            this.rpt_docaudi.TabIndex = 0;
            // 
            // frm_Resumen_Impresion_Auditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 582);
            this.Controls.Add(this.rpt_docaudi);
            this.Name = "frm_Resumen_Impresion_Auditoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carta de Cobranza Auditoria - Alfredo Pimentel Sevilla S.A.";
            this.Load += new System.EventHandler(this.frm_Resumen_Impresion_Auditoria_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_docaudi;
    }
}