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
//using ApssaExactus.LIBCS;
//using ApssaExactus.LIBVB;
using CrystalDecisions.Shared;


namespace ApssaExactus
{
    public partial class frmEstadoCuentaClienteCANJE_CR_2023 : DevExpress.XtraEditors.XtraForm
    {
        //parametro que recibe de frmEstadoCuentaCliente
        //public DateTime _dFechaIni { get; set; }
        //public DateTime _dFechaFin { get; set; }
        //public string _contribuyente = string.Empty;
        //public string _cliente = string.Empty;
        //public string _clientenombre = string.Empty;
        //public string _mensaje = string.Empty;
        public string _ClienteLetra = string.Empty;
        public string _TipoDocumento = string.Empty;
        public string _NroDocumento = string.Empty;
        public Decimal _MontoLetra = 0;
        public string _MonedaLetra = string.Empty;
        public string _Referencia = string.Empty;
        public DateTime _FechaEmision { get; set; }
        public DateTime _FechaVcmto { get; set; }

        //variables temporales
        public string _documento = "";
        public string _cliente = "";
        public string _tipo_canje = "";
        public string _documento_canje = "";
        public Decimal _monto = 0;
        public string _moneda = "";
        public string _moneda_nombre = "";
        public string _nombre = "";
        public string _direccion = "";
        public string _contribuyente = "";
        public string _telefono = "";
        public string _aval = "";
        public string _aval_nombre = "";
        public string _aval_direccion = "";
        public string _aval_telefono = "";
        public DateTime _fecha { get; set; }
        public DateTime _fecha_documento { get; set; }
        public DateTime _fecha_vence { get; set; }

        public string _lugar_giro = "";
        public string _monto_en_letras = "";
        public string _formato_fecha_emision = "";  // texto =>   2018 06 23
        public string _formato_fecha_vcmto = "";    // texto =>   2018 06 23

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

        public frmEstadoCuentaClienteCANJE_CR_2023()
        {
            InitializeComponent();
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmEstadoCuentaClienteCANJE_CR_2023 m_FormDefInstance;

        /// Instancia por defecto
        public static frmEstadoCuentaClienteCANJE_CR_2023 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmEstadoCuentaClienteCANJE_CR_2023();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmEstadoCuentaClienteCANJE_CR_2023_Load(object sender, EventArgs e)
        {
            LimpiarCajas();
            ConvierteFechas();
            CargarDatosLetra(); // MostrarDatos();
            MuestraReporte();
            HabilitarCajas(true);

            //LetraCliente2 oReporte = new LetraCliente2();
            LetraClienteCreditosCanje oReporteCanje = new LetraClienteCreditosCanje();

            ///
            ///---------------------------------------------------------------------------------------------
            //CrystalDecisions.CrystalReports.Engine.PrintOptions oPrintOptions = oReporte.PrintOptions;
            //oPrintOptions.PrinterName = @"\\SURQ-SIS-054\EPSON LX-300+II ESC/P";
            //oPrintOptions.DissociatePageSizeAndPrinterPaperSize = false;
            //oPrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
            //oPrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            ///---------------------------------------------------------------------------------------------
            ///
            oReporteCanje.SetDatabaseLogon("prometeo", "prometeo");

            Creditos_Reportes datos = new Creditos_Reportes();
            oReporteCanje.SetDataSource(datos);
            oReporteCanje.SetParameterValue("@CLIENTE", _ClienteLetra);
            oReporteCanje.SetParameterValue("@TIPO", _TipoDocumento);
            oReporteCanje.SetParameterValue("@DOCUMENTO", _NroDocumento);
            crystalReportViewer1.ReportSource = oReporteCanje;
            crystalReportViewer1.Refresh();
        }


        public void ConvierteFechas()
        {

            _formato_fecha_emision = _FechaEmision.Year.ToString().PadLeft(4, '0') +" "+
                                     _FechaEmision.Month.ToString().PadLeft(2, '0') +" "+
                                     _FechaEmision.Day.ToString().PadLeft(2, '0');

            _formato_fecha_vcmto = _FechaVcmto.Year.ToString().PadLeft(4, '0') + " " +
                                   _FechaVcmto.Month.ToString().PadLeft(2, '0') + " " +
                                   _FechaVcmto.Day.ToString().PadLeft(2, '0');


        }


        public void MuestraReporte()
        {
            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("parMontoEnLetra", _monto_en_letras);
            parameters[1] = new ReportParameter("parLugarGiro", _lugar_giro);
            parameters[2] = new ReportParameter("parReferencia", _Referencia);
            parameters[3] = new ReportParameter("parFechaEmision", _formato_fecha_emision);
            parameters[4] = new ReportParameter("parFechaVcmto", _formato_fecha_vcmto);
            //reportViewer1.LocalReport.SetParameters(parameters);

            //limpia los datasource
            //reportViewer1.LocalReport.DataSources.Clear();

            //Datos Letra
            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "dsLetra";
            rds1.Value = CargaDatosLetra(_ClienteLetra, "L/C", _NroDocumento, Global.vUserBaseDatos);
            //reportViewer1.LocalReport.DataSources.Add(rds1);

            //LugarGiro
            ReportDataSource rds2 = new ReportDataSource();
            rds2.Name = "dsLugarGiro";
            rds2.Value = CargaLugarGiro("L/C", _NroDocumento, Global.vUserBaseDatos);
            //reportViewer1.LocalReport.DataSources.Add(rds2);
            //reportViewer1.LocalReport.Refresh();
            //reportViewer1.RefreshReport();
        }


        public DataTable CargaDatosLetra(string _cli, string _tip, string _doc, string baseuser)
        {
            DataTable dtDatos = new DataTable();
            dtDatos = CreditosBL.dtObtenerDatosLetras_BL(_cli, _tip, _doc, baseuser);
            return dtDatos;
        }


        public DataTable CargaLugarGiro(string _tip, string _doc, string baseuser)
        {
            DataTable dtLugar = new DataTable();
            dtLugar = CreditosBL.dtObtenerLugarGiroLetra_BL(_tip, _doc, baseuser);
            return dtLugar;
        }




        #region RUTINAS_VARIOS
        private string Numero2Letras(Decimal mont, string mone)
        {
            string NumeroEnLetras = string.Empty;
            NumeroEnLetras = Conversores.NumeroALetras(mont, mone);
            return NumeroEnLetras;
            //MessageBox.Show(NumeroEnLetras);
        }

        public void LimpiarCajas()
        {
            txtNumeroLetra.Text = "";
            txtRefGirador.Text = "";
            txtLugarGiro.Text = "";
            txtFechaGiro.Text = "";
            txtFechaVcmto.Text = "";
            txtMonedaLetra.Text = "";
            txtMontoLetra.Text = "";
            txtGirador.Text = "";
            txtGiradorDNI.Text = "";
            txtGiradorTelf.Text = "";
            txtGiradorDireccion.Text = "";
            txtAval.Text = "";
            txtAvalDNI.Text = "";
            txtAvalTelf.Text = "";
            txtAvalDireccion.Text = "";
        }

        public void CargarDatosLetra()
        {
            CargaDatosLetra();
            //txtSaldoCuentaBancaria.Text = (ContabilidadBL.dtObtenerDatosCuentaBancariaBL(txtCuentaBanco.Text, Global.vUserBaseDatos)).Rows[0]["SALDO"].ToString();
            _lugar_giro = CreditosBL.dtObtenerLugarGiroLetra_BL("L/C", _NroDocumento, Global.vUserBaseDatos).Rows[0]["NOMBRE_ZONA"].ToString();
            //Numero2Letras(Convert.ToDecimal(_monto), _moneda);
            _monto_en_letras = Numero2Letras(_MontoLetra, _MonedaLetra);

            txtNumeroLetra.Text = _NroDocumento;
            txtRefGirador.Text = _Referencia;
            //txtLugarGiro.Text = CreditosBL.ObtenerLugarGiroLetra_BL("L/C", _NroDocumento, Global.vUserBaseDatos);
            txtFechaGiro.Text = _FechaEmision.ToString();
            txtFechaVcmto.Text = _FechaVcmto.ToString();
            txtMonedaLetra.Text = _MonedaLetra;
            txtMontoLetra.Text = _MontoLetra.ToString();
            txtGirador.Text = _nombre;
            txtGiradorDNI.Text = _cliente;
            txtGiradorTelf.Text = _telefono;
            txtGiradorDireccion.Text = _direccion;
            txtAval.Text = _aval_nombre;
            txtAvalDNI.Text = _aval;
            txtAvalTelf.Text = _aval_telefono;
            txtAvalDireccion.Text = _aval_direccion;
            txtMontoEnLEtras.Text = _monto_en_letras;
        }


        public void CargaDatosLetra()
        {
            DataTable dtLetra = new DataTable();
            dtLetra = CreditosBL.dtObtenerDatosLetras_BL(_ClienteLetra, "L/C", _NroDocumento, Global.vUserBaseDatos);
            DataTableReader lector = dtLetra.CreateDataReader();

            while (lector.Read())
            {
                _documento = lector[0].ToString();
                _cliente = lector[1].ToString();
                _tipo_canje = lector[2].ToString();
                _documento_canje = lector[3].ToString();
                _fecha = Convert.ToDateTime(lector[4]);
                _fecha_documento = Convert.ToDateTime(lector[5]);
                _monto = Convert.ToDecimal(lector[6]);
                _moneda = lector[7].ToString();
                _moneda_nombre = lector[8].ToString();
                _nombre = lector[9].ToString();
                _direccion = lector[10].ToString();
                _contribuyente = lector[11].ToString();
                _telefono = lector[12].ToString();
                _fecha_vence = Convert.ToDateTime(lector[13]);
                _aval = lector[14].ToString();
                _aval_nombre = lector[15].ToString();
                _aval_direccion = lector[16].ToString();
                _aval_telefono = lector[17].ToString();

            }

        }

        public void HabilitarCajas(Boolean flag)
        {
            txtNumeroLetra.ReadOnly = flag;
            txtRefGirador.ReadOnly = flag;
            txtLugarGiro.ReadOnly = flag;
            txtFechaGiro.ReadOnly = flag;
            txtFechaVcmto.ReadOnly = flag;
            txtMonedaLetra.ReadOnly = flag;
            txtMontoLetra.ReadOnly = flag;
            txtGirador.ReadOnly = flag;
            txtGiradorDNI.ReadOnly = flag;
            txtGiradorTelf.ReadOnly = flag;
            txtGiradorDireccion.ReadOnly = flag;
            txtAval.ReadOnly = flag;
            txtAvalDNI.ReadOnly = flag;
            txtAvalTelf.ReadOnly = flag;
            txtAvalDireccion.ReadOnly = flag;
        }




        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ConvierteFechas();

            txtFecINI.Text = _formato_fecha_emision;
            txtFecFIN.Text = _formato_fecha_vcmto;
        }



    }
}
