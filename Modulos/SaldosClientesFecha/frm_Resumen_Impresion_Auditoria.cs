using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
namespace ApssaExactus
{
    public partial class frm_Resumen_Impresion_Auditoria : Form
    {
        public string pCliente;
        public string pDireccion;
        public int TIPO_REPORTE;
        //public DateTime pFecha;
        //public ReportDataSource rds1;
        public DataTable dt_reporte;
        
        public frm_Resumen_Impresion_Auditoria()
        {
            InitializeComponent();
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frm_Resumen_Impresion_Auditoria m_FormDefInstance;

        /// Instancia por defecto
        public static frm_Resumen_Impresion_Auditoria DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frm_Resumen_Impresion_Auditoria();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ---------------------------------------------------------------------------

        private void frm_Resumen_Impresion_Auditoria_Load(object sender, EventArgs e)
        {
            try
            {
                MuestraReporte();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }
        public void MuestraReporte()
        {
           
            this.rpt_docaudi.LocalReport.DataSources.Clear();

            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "ds_doc_auditoria";
            rds1.Value = dt_reporte;
            rpt_docaudi.LocalReport.DataSources.Add(rds1);
            rpt_docaudi.ProcessingMode = ProcessingMode.Local;
            switch (TIPO_REPORTE)
            {
                case 0:
                    this.rpt_docaudi.LocalReport.ReportEmbeddedResource = "Exactus.Win.Creditos.CartaCobranzaAuditoria.rdlc";
                    break;
                case 1:
                    this.rpt_docaudi.LocalReport.ReportEmbeddedResource = "Exactus.Win.Creditos.CartaCobranzaCreFto1.rdlc";
                    break;
                case 2:
                    this.rpt_docaudi.LocalReport.ReportEmbeddedResource = "Exactus.Win.Creditos.CartaCobranzaCreFto2.rdlc";
                    break;
                case 3:
                    this.rpt_docaudi.LocalReport.ReportEmbeddedResource = "Exactus.Win.Creditos.CartaCobranzaCreFto3.rdlc";
                    break;
                case 4:
                    this.rpt_docaudi.LocalReport.ReportEmbeddedResource = "Exactus.Win.Creditos.CartaCobranzaCreFto4.rdlc";
                    break;
            }
            
            ReportParameter CLIENTE = new ReportParameter("CLIENTE", pCliente);
            this.rpt_docaudi.LocalReport.SetParameters(new ReportParameter[] { CLIENTE });

            ReportParameter DIREC = new ReportParameter("DIRECCION", pDireccion);
            this.rpt_docaudi.LocalReport.SetParameters(new ReportParameter[] { DIREC });

            ReportParameter FECHA = new ReportParameter("FECHA", DateTime.Today.ToString());
            this.rpt_docaudi.LocalReport.SetParameters(new ReportParameter[] { FECHA });
            rpt_docaudi.RefreshReport();
            

        }
    }
}
