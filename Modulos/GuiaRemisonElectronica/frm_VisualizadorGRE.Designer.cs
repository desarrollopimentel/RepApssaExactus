namespace ApssaExactus
{
    partial class frm_VisualizadorGRE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_VisualizadorGRE));
            this.PDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDF)).BeginInit();
            this.SuspendLayout();
            // 
            // PDF
            // 
            this.PDF.Enabled = true;
            this.PDF.Location = new System.Drawing.Point(-1, -1);
            this.PDF.MaximumSize = new System.Drawing.Size(800, 730);
            this.PDF.MinimumSize = new System.Drawing.Size(800, 700);
            this.PDF.Name = "PDF";
            this.PDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDF.OcxState")));
            this.PDF.Size = new System.Drawing.Size(800, 730);
            this.PDF.TabIndex = 0;
            // 
            // frm_VisualizadorGRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 691);
            this.Controls.Add(this.PDF);
            this.MaximumSize = new System.Drawing.Size(800, 804);
            this.MinimumSize = new System.Drawing.Size(800, 604);
            this.Name = "frm_VisualizadorGRE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guia Remision Electronica";
            this.Load += new System.EventHandler(this.frm_VisualizadorGRE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDF;

    }
}