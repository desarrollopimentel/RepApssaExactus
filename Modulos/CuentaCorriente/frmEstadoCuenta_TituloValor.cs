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
using DevExpress.Utils;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Exactus.LIBVB;

namespace ApssaExactus
{
    public partial class frmEstadoCuenta_TituloValor : DevExpress.XtraEditors.XtraForm
    {
        //parametro que recibe de frmEstadoCuentaCliente
        public string _cliente = string.Empty;
        public string _clientenombre = string.Empty;
        public string _tipo = string.Empty;
        public string _documento = string.Empty;
        public DateTime _FechaEmision { get; set; }
        public DateTime _FechaVcmto { get; set; }

        //public DateTime _ConstanciaFecha { get; set; }
        public string _ConstanciaFecha = string.Empty;
        public string _ConstanciaInscripcion = string.Empty;

        //public string _mensaje = string.Empty;
        //public string _contribuyente = string.Empty;
        //frmTV._cliente = _cliente;
        //frmTV._tipo = _tipo;
        //frmTV._documento = _documento;


        //parametros generales
        private SqlCommand Comando = new SqlCommand();
        public string CmdSql = null;

        //parametros del formulario
        private DateTime varConstanciaFecha { get; set; }
        private string varConstanciaInscripcion  = string.Empty;


        //private DateTime dFechaIni { get; set; }
        //private DateTime dFechaFin { get; set; }
        //private string contribuyente = string.Empty;
        //private string cliente = string.Empty;
        //public string varTitulo1 { get; set; }
        //public string varTitulo2 { get; set; }

        public frmEstadoCuenta_TituloValor()
        {
            InitializeComponent();
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmEstadoCuenta_TituloValor m_FormDefInstance;

        /// Instancia por defecto
        public static frmEstadoCuenta_TituloValor DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmEstadoCuenta_TituloValor();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmEstadoCuenta_TituloValor_Load(object sender, EventArgs e)
        {
            //dpFechaIni.Text = _dFechaIni.ToString();
            //dpFechaFin.Text = _dFechaFin.ToString();
            txtCliente.Text = _cliente;
            txtClienteNombre.Text = _clientenombre;
            dFechaEmision.Text = _FechaEmision.ToString();
            dFechaVcmto.Text = _FechaVcmto.ToString();
            txtTipoDoc.Text = _tipo;
            txtDocumento.Text = _documento;
            dConstanciaFecha.Text = _ConstanciaFecha.ToString();
            txtConstanciaInscripcion.Text = _ConstanciaInscripcion;

            

            //MuestraReporte();   //

            //this.reportViewer1.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //MuestraReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtConstanciaInscripcion.Text != "" || txtConstanciaInscripcion.Text != string.Empty)
            {
   
                varConstanciaInscripcion = txtConstanciaInscripcion.Text;
                varConstanciaFecha = Convert.ToDateTime(this.dConstanciaFecha.Text);
 

                using (WaitDialogForm waitDialog = new WaitDialogForm("Recuperando información, Espere por favor...", "Estado Cuenta Clientes"))
                {
                    try
                    {

                        GuardarConstanciaInscripcion(varConstanciaFecha, varConstanciaInscripcion);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Ingrese el Numero de Constancia de Inscripcion !!! ");
                return;
            }
        }


        public void GuardarConstanciaInscripcion(DateTime _fecha_const, string _inscrip_const)
        {

            string _tipo_mensaje = "Actualizacion Constancia Inscripcion.";

             DialogResult dialogResult = MessageBox.Show(_tipo_mensaje
                                                    + "\n"
                                                    + "\nEsta seguro de Grabar ?", _tipo_mensaje, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    int resultado = CreditosBL.ActualizarConstanciaInscripcion_BL(txtCliente.Text, txtTipoDoc.Text, txtDocumento.Text, _fecha_const, _inscrip_const, Global.vUserBaseDatos);

                    //ObtenerClausulasLetras();
                    //desactivar controles
                    MessageBox.Show("Se guardó correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }



        //public void MuestraReporte()
        //{
        //    dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
        //    dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);
        //    contribuyente = txtCliente.Text;
        //    cliente = txtCliente.Text;
        //    varTitulo1 = "ALFREDO PIMENTEL SEVILLA S.A";
        //    varTitulo2 = "AV. ANGAMOS OESTE 1795 - SURQUILLO";
        //    ReportParameter[] parameters = new ReportParameter[6];
        //    parameters[0] = new ReportParameter("parTitulo1", varTitulo1);
        //    parameters[1] = new ReportParameter("parTitulo2", varTitulo2);
        //    parameters[2] = new ReportParameter("parFechaReporte", DateTime.Today.ToString());
        //    parameters[3] = new ReportParameter("parFechaDesde", dpFechaIni.Text);
        //    parameters[4] = new ReportParameter("parFechaHasta", dpFechaFin.Text);
        //    parameters[5] = new ReportParameter("parMensaje1", _mensaje);
        //    reportViewer1.LocalReport.SetParameters(parameters);
        //    //limpia los datasource
        //    reportViewer1.LocalReport.DataSources.Clear();
        //    //CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
        //    //CargaSaldoCliente(cliente, Global.vUserBaseDatos);
        //    //CargaInformacionCliente(cliente, Global.vUserBaseDatos);
        //    //CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);
        //    //SaldoDocumentosCliente
        //    ReportDataSource rds1 = new ReportDataSource();
        //    rds1.Name = "SaldoDocumentosCliente";
        //    rds1.Value = CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
        //    reportViewer1.LocalReport.DataSources.Add(rds1);
        //    //InformacionCliente
        //    ReportDataSource rds2 = new ReportDataSource();
        //    rds2.Name = "InformacionCliente";
        //    rds2.Value = CargaInformacionCliente(cliente, Global.vUserBaseDatos);
        //    reportViewer1.LocalReport.DataSources.Add(rds2);
        //    //LetrasEstadoCliente
        //    ReportDataSource rds3 = new ReportDataSource();
        //    rds3.Name = "LetrasEstadoCliente";
        //    rds3.Value = CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);
        //    reportViewer1.LocalReport.DataSources.Add(rds3);
        //    reportViewer1.LocalReport.Refresh();
        //    reportViewer1.RefreshReport();
        //}


        //public DataTable CargaSaldoDocumentosCliente(string contrib, string client, DateTime dFecIni, DateTime dFecFin, string baseusuario)
        //{
        //    EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        //    DataTable dtSaldoDocumentosCliente = new DataTable();
        //    dtSaldoDocumentosCliente = objEstadoCuentaBL.dtSaldoDocumentosClienteBL(contrib, client, dFecIni, dFecFin, baseusuario);
        //    return dtSaldoDocumentosCliente;
        //}


        //public DataTable CargaInformacionCliente(string cli, string baseuser)
        //{
        //    EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        //    DataTable dtInformacionCliente = new DataTable();
        //    dtInformacionCliente = objEstadoCuentaBL.dtInformacionClienteBL(cli, baseuser);
        //    return dtInformacionCliente;
        //}


        //public DataTable CargaSaldoCliente(string cli, string baseuser)
        //{
        //    EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        //    DataTable dtSaldoCliente = new DataTable();
        //    dtSaldoCliente = objEstadoCuentaBL.dtSaldoClienteBL(cli, baseuser);
        //    return dtSaldoCliente;
        //}

        //public DataTable CargaLetrasEstadoCliente(string client, DateTime dFecFin, string baseusuario)
        //{
        //    EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
        //    DataTable dtLetrasEstadoCliente = new DataTable();
        //    dtLetrasEstadoCliente = objEstadoCuentaBL.dtLetrasEstadoClienteBL(client, dFecFin, baseusuario);
        //    return dtLetrasEstadoCliente;
        //}


    }
}

