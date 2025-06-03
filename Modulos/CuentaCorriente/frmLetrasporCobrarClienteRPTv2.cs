using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Exactus.LIBVB;

namespace ApssaExactus
{
    public partial class frmLetrasporCobrarClienteRPTv2 : DevExpress.XtraEditors.XtraForm
    {
        //parametro que recibe de frmEstadoCuentaCliente
        public DateTime _dFechaIni { get; set; }
        public DateTime _dFechaFin { get; set; }
        public string _contribuyente = string.Empty;
        public string _cliente = string.Empty;
        public string _clientenombre = string.Empty;
        public string _mensaje = string.Empty;

        //parametros generales
        private SqlCommand Comando = new SqlCommand();
        public string CmdSql = null;        
        
        //parametros del formulario
        private DateTime dFechaIni { get; set; }
        private DateTime dFechaFin { get; set; }
        private string contribuyente = string.Empty;
        private string cliente = string.Empty;

        public string varTitulo1 { get; set; }
        public string varTitulo2 { get; set; }

        public frmLetrasporCobrarClienteRPTv2()
        {
            InitializeComponent();
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmLetrasporCobrarClienteRPTv2 m_FormDefInstance;

        /// Instancia por defecto
        public static frmLetrasporCobrarClienteRPTv2 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmLetrasporCobrarClienteRPTv2();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmLetrasporCobrarClienteRPTv2_Load(object sender, EventArgs e)
        {
            dpFechaIni.Text = _dFechaIni.ToString();
            dpFechaFin.Text = _dFechaFin.ToString();
            txtCliente.Text = _cliente;
            txtClienteNombre.Text = "";

            MuestraReporte();   //

            this.reportViewer1.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MuestraReporte();
        }

        public void MuestraReporte()
        {
            dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
            dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);
            contribuyente = txtCliente.Text;
            cliente = txtCliente.Text;


            varTitulo1 = "ALFREDO PIMENTEL SEVILLA S.A";
            varTitulo2 = "AV. ANGAMOS OESTE 1795 - SURQUILLO";
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("parTitulo1", varTitulo1);
            parameters[1] = new ReportParameter("parTitulo2", varTitulo2);
            parameters[2] = new ReportParameter("parFechaReporte", DateTime.Today.ToString());
            parameters[3] = new ReportParameter("parFechaDesde", dpFechaIni.Text);
            parameters[4] = new ReportParameter("parFechaHasta", dpFechaFin.Text);
            parameters[5] = new ReportParameter("parMensaje1", _mensaje);
            reportViewer1.LocalReport.SetParameters(parameters);

            //limpia los datasource
            reportViewer1.LocalReport.DataSources.Clear();

            //CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
            //CargaSaldoCliente(cliente, Global.vUserBaseDatos);
            //CargaInformacionCliente(cliente, Global.vUserBaseDatos);
            //CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);


            //InformacionCliente
            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "InformacionCliente";
            rds1.Value = CargaInformacionCliente(cliente, Global.vUserBaseDatos);
            reportViewer1.LocalReport.DataSources.Add(rds1);

            //LetrasEstadoCliente
            ReportDataSource rds2 = new ReportDataSource();
            rds2.Name = "LetrasEstadoCliente";
            rds2.Value = CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);
            reportViewer1.LocalReport.DataSources.Add(rds2);

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }



        public DataTable CargaInformacionCliente(string cli, string baseuser)
        {
            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dtInformacionCliente = new DataTable();
            dtInformacionCliente = objEstadoCuentaBL.dtInformacionClienteBL(cli, baseuser);
            return dtInformacionCliente;
        }


        public DataTable CargaLetrasEstadoCliente(string client, DateTime dFecFin, string baseusuario)
        {
            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dtLetrasEstadoCliente = new DataTable();
            dtLetrasEstadoCliente = objEstadoCuentaBL.dtLetrasEstadoClienteBL(client, dFecFin, baseusuario);
            return dtLetrasEstadoCliente;
        }



    }
}

