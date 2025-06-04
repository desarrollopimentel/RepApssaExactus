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
    public partial class frmLiquidacionReporte : DevExpress.XtraEditors.XtraForm
    {
        //parametro que recibe de frmEstadoCuentaCliente
        //public DateTime _dFechaIni { get; set; }
        //public DateTime _dFechaFin { get; set; }
        public string _fecha_desde = string.Empty;
        public string _fecha_hasta = string.Empty;
        public string _sucursal = string.Empty;
        public string _tarjeta = string.Empty;
        public string _local = string.Empty;
        public string _dolar = string.Empty;
        public string _pendiente = string.Empty;
        public string _liquidado = string.Empty;
        public string _mensaje = string.Empty;

        //parametros generales
        private SqlCommand Comando = new SqlCommand();
        public string CmdSql = null;        
        
        //parametros del formulario
        private DateTime dFechaIni { get; set; }
        private DateTime dFechaFin { get; set; }
        private string sucursal = string.Empty;
        private string tarjeta = string.Empty;
        public string moneda = string.Empty;
        public string estado = string.Empty;
        public string mensaje = string.Empty;

        public string varTitulo1 { get; set; }
        public string varTitulo2 { get; set; }

        public frmLiquidacionReporte()
        {
            InitializeComponent();
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmLiquidacionReporte m_FormDefInstance;

        /// Instancia por defecto
        public static frmLiquidacionReporte DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmLiquidacionReporte();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmLiquidacionReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'PIMENTELDataSet1.SP_APSSA_LIQUIDAR_TARJETAS_REPORTE' Puede moverla o quitarla según sea necesario.
            //this.SP_APSSA_LIQUIDAR_TARJETAS_REPORTETableAdapter.Fill(this.PIMENTELDataSet1.SP_APSSA_LIQUIDAR_TARJETAS_REPORTE);
            txtFechaDesde.Text = _fecha_desde;   //_dFechaIni.ToString();
            txtFechaHasta.Text = _fecha_hasta;   //_dFechaFin.ToString();
            txtCaja.Text = _sucursal;
            txtTarjetas.Text = _tarjeta;
            txtLocal.Text = _local;
            txtDolar.Text = _dolar;
            txtPendiente.Text = _pendiente;
            txtLiquidado.Text = _liquidado;

            MuestraReporte();   //
            
            this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MuestraReporte();
        }

        public void MuestraReporte()
        {
            dFechaIni = Convert.ToDateTime(this.txtFechaDesde.Text);
            dFechaFin = Convert.ToDateTime(this.txtFechaHasta.Text);
            sucursal = txtCaja.Text;
            tarjeta = txtTarjetas.Text;
            moneda = txtLocal.Text;
            estado = txtDolar.Text;
            mensaje = _mensaje;

            varTitulo1 = "ALFREDO PIMENTEL SEVILLA S.A";
            varTitulo2 = "AV. ANGAMOS OESTE 1795 - SURQUILLO";
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("parTitulo1", varTitulo1);
            parameters[1] = new ReportParameter("parTitulo2", varTitulo2);
            parameters[2] = new ReportParameter("parFechaReporte", DateTime.Today.ToString());
            parameters[3] = new ReportParameter("parFechaDesde", txtFechaDesde.Text);
            parameters[4] = new ReportParameter("parFechaHasta", txtFechaHasta.Text);
            parameters[5] = new ReportParameter("parMensaje1", _mensaje);
            reportViewer1.LocalReport.SetParameters(parameters);

            //limpia los datasource
            reportViewer1.LocalReport.DataSources.Clear();

            //CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
            //CargaSaldoCliente(cliente, Global.vUserBaseDatos);
            //CargaInformacionCliente(cliente, Global.vUserBaseDatos);
            //CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);

            //Liquidaciontarjetas
            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "LiquidacionTarjetas";
            //ContabilidadDL.dtObtenerReporteLiquidacionTarjetas_DL(_fecha_ini, _fecha_fin, _sucursal, _tarjeta, _moneda, _estado, db);
            rds1.Value = CargaLiquidacionTarjetas(dFechaIni, dFechaFin, sucursal, tarjeta, moneda, estado);
            reportViewer1.LocalReport.DataSources.Add(rds1);

            ////SaldoDocumentosCliente
            //ReportDataSource rds1 = new ReportDataSource();
            //rds1.Name = "SaldoDocumentosCliente";
            //rds1.Value = CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
            //reportViewer1.LocalReport.DataSources.Add(rds1);

            ////InformacionCliente
            //ReportDataSource rds2 = new ReportDataSource();
            //rds2.Name = "InformacionCliente";
            //rds2.Value = CargaInformacionCliente(cliente, Global.vUserBaseDatos);
            //reportViewer1.LocalReport.DataSources.Add(rds2);

            ////LetrasEstadoCliente
            //ReportDataSource rds3 = new ReportDataSource();
            //rds3.Name = "LetrasEstadoCliente";
            //rds3.Value = CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);
            //reportViewer1.LocalReport.DataSources.Add(rds3);

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }


        public DataTable CargaLiquidacionTarjetas(DateTime dFecIni, DateTime dFecFin, string sucursal, string tarjeta, string moneda, string estado)
        {
            //EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dtTarjetas = new DataTable();
            //dtObtenerReporteLiquidacionTarjetas_BL(string _operacion, string _asiento, Decimal _numero_operacion, string db)
            //ContabilidadDL.dtObtenerReporteLiquidacionTarjetas_DL(_fecha_ini, _fecha_fin, _sucursal, _tarjeta, _moneda, _estado, db);
            dtTarjetas = ContabilidadBL.dtObtenerReporteLiquidacionTarjetas_BL(dFecIni, dFecFin, sucursal, tarjeta, moneda, estado, Global.vUserBaseDatos);
            return dtTarjetas;
        }

        ////public DataTable CargaSaldoDocumentosCliente(string contrib, string client, DateTime dFecIni, DateTime dFecFin, string baseusuario)
        ////{
        ////    //EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        ////    DataTable dtSaldoDocumentosCliente = new DataTable();
        ////    //dtSaldoDocumentosCliente = objEstadoCuentaBL.dtSaldoDocumentosClienteBL(contrib, client, dFecIni, dFecFin, baseusuario);
        ////    return dtSaldoDocumentosCliente;
        ////}


        ////public DataTable CargaInformacionCliente(string cli, string baseuser)
        ////{
        ////    //EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        ////    DataTable dtInformacionCliente = new DataTable();
        ////    //dtInformacionCliente = objEstadoCuentaBL.dtInformacionClienteBL(cli, baseuser);
        ////    return dtInformacionCliente;
        ////}


        ////public DataTable CargaSaldoCliente(string cli, string baseuser)
        ////{
        ////    //EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        ////    DataTable dtSaldoCliente = new DataTable();
        ////    //dtSaldoCliente = objEstadoCuentaBL.dtSaldoClienteBL(cli, baseuser);
        ////    return dtSaldoCliente;
        ////}

        ////public DataTable CargaLetrasEstadoCliente(string client, DateTime dFecFin, string baseusuario)
        ////{
        ////    //EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        ////    DataTable dtLetrasEstadoCliente = new DataTable();
        ////    //dtLetrasEstadoCliente = objEstadoCuentaBL.dtLetrasEstadoClienteBL(client, dFecFin, baseusuario);
        ////    return dtLetrasEstadoCliente;
        ////}


    }
}

