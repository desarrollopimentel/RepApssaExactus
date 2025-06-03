using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.Collections;
using System.IO;

//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;

//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
using Excel = Microsoft.Office.Interop.Excel;


namespace ApssaExactus
{
    public partial class frmCargoEntregaRendir : DevExpress.XtraEditors.XtraForm
    {
        //---------------------------------------------------------------------
        // CARGA_ENTORNO_VARIABLES
        //---------------------------------------------------------------------
        public Int32 NumIntentos = 1;
        public string _base_datos = null;
        public string _usuario = null;
        //public string _password = null;
        public UsuarioReporte usuarioreporte = null;
        public static DataSet ds_user;           //Usuario        
        public static DataSet ds_luc;            //Tiendas
        public static DataSet ds_lub;            //Bodegas
        public static DataSet ds_zon;            //Zonas

        string passwordEncrypt = null;
        public string cUsuarioActual = null;
        //---------------------------------------------------------------------_base, _user, _pass
        //---------------------------------------------------------------------

        public string HojaXls = null;
        public string tipo_carga = string.Empty;    // "Excel", "Modificacion"

        public string nueva_cadena = string.Empty;
        public Int32 num_random = 0;
        ProcesosBL objprocesoBL = new ProcesosBL();
        DataTable dtXml = new DataTable();      // contiene las rutas de los xml
        DataTable dtFactura = new DataTable();  // facturas generadas de los xml
        DataTable dtExcel = new DataTable();
        XmlDocument doc = new XmlDocument();
        XmlDocument doc_tmp = new XmlDocument();
        public string fileXml = string.Empty;

        public string strCadenaNodo = string.Empty;
        public string strCadenaTexto = string.Empty;
        public string strCadenaValor = string.Empty;
        public string newXml = string.Empty;
        public Boolean PrimeraVez = true;

        public string XmlSeleccionado = string.Empty;            // archivo seleccionado en gvXml
        public string ItemFactSeleccionado = string.Empty;       // archivo seleccionado en gvFactura
        public string cTabXls = null;

        public string strCondicionPagoPDF = string.Empty;       // condicion Pago en el PDF
        public string strRutaXml = string.Empty;                // path del archivo xml en proceso
        public string strXml = string.Empty;                    // cadena que contiene todo el xml  ["<Invoice>", "</Invoice>"]
        public string strInvoiceLine = string.Empty;            // subcadena de InvoiceLine que contiene todos los items ["<cac:InvoiceLine>", "</cac:InvoiceLine>"]
        public string _articulo_cuenta = string.Empty;

        public Boolean ProcesarTodos = false;

        public string exactus_tipo_documento = string.Empty;
        public string exactus_tipo_referencia = string.Empty;

        //leer PDF
        string stringPdfFile = string.Empty;
        string stringPdfOutput = string.Empty;

        public string varAplicacion = "";
        public string varAplicacionDescripcion = "";
        public string varAplicacionTipo = "";

        DataSet ds = new DataSet();

        public string _EMBARQUE_OC = "";
        public string _TIP_DOC_REF = "";
        public string _NUM_DOC_REF = "";
        public string _DETRACCION = "";
        //public string _VALIDACION = "";

        public bool EsAfectoDetraccion = false;     // si tiene reencache

        //CuentaBanco
        //Moneda
        //TipoSalida
        //SubTipoSalida

        // CAJA CHICA        
        public string TipoOperacionCajaChica = "";  // "FF","ER"                //@PAR_TIPO_OPERACION VARCHAR(2),		    -- 'FF' FondoFijo , 'ER' EntregaRendir
        public string DocuOperacionCajaChica = "";  // "FF","ER"                //@PAR_DOCU_OPERACION VARCHAR(18))		    -- ENTREGA RENDIR ó FONDO FIJO

        // FONDO FIJO
        public string FondoFijo = "";
        public string AplicacionFondoFijo = "";
        public string CuentaBancoFondoFijo = "";
        public DateTime FechaFondoFijo ;
        public string MonedaFondoFijo = "";
        public Decimal TipoCambioFondoFijo = 0;
        public Decimal MontoFondoFijo = 0;
        public Decimal MontoLocalFondoFijo = 0;
        public Decimal MontoDolarFondoFijo = 0;
        public string TipoOperacionFondoFijo = "I";

        // ENTREGA A RENDIR
        public string EntregaRendir = "";
        //public string Empleado = "";
        //public string Proveedor = "";
        public string Contribuyente = "";
        public string ResponsableTipo = "";
        public string ResponsableCodigo = "";
        public string Moneda = "";
        public string MonedaER = "";
        public string MonedaERDesc = "";
        public string Aplicacion = "";
        public DateTime FechaEntrega;
        public Decimal Monto = 0;
        public Decimal TipoCambio = 0;
        public string Notas = "";
        public string Responsable = "";
        public DateTime FechaVenc;
        public string Usuario = "";
        public string TipoOperacion = "";

        // DOCUMENTOS_CAJA (solo entrega_rendir)
        public string CuentaBancoER = "";
        public string CuentaBancoERDesc = "";
        public string CuentaBancoNombreER = "";
        public string TipoSalidaER = "";
        public string TipoSalidaERDesc = "";
        public Int32 SubTipoSalidaER = 0;
        public string SubTipoSalidaERDesc = "";
        public string ContribuyenteER = "";
        public string ContribuyenteNombreER = "";
        public string MonedaERdebito = "";
        public string MonedaERdebitoDesc = "";
        public string DocumentoERdebito = "";
        public Decimal MontoERdebito = 0;
        public DateTime FechaERdebito;
        public string AplicacionERdebito = "";
        public string AsientoERdebito = "";
        public string OrdenGiro = "";
        public string TipoContribuyenteER = "";


        //
        public string CuentaBanco = "";
        //public string Moneda = "";
        public string TipoSalida = "";
        public string SubTipoSalida = "";

        public string CuentaBancoCode = "";
        public string MonedaCode = "";
        public string TipoSalidaCode = "";
        public string SubTipoSalidaCode = "";
        public Boolean _primera_vez = true;

        // EXCEL
        public string _PROCESAR;
        public string _VALIDACION;
        public string _DOCUMENTO;
        public string _TIPO;
        public string _SUBTIPODOC;
        public DateTime _FECHA_DOCUMENTO;
        public DateTime _FECHA_CONTABLE;
        public string _CONTRIBUYENTE;
        public string _MONEDA;
        public Decimal _TIPO_CAMBIO;
        public Decimal _SUBTOTAL;
        public Decimal _DESCUENTO;
        public Decimal _IGV;    // _IMPUESTO1;
        public Decimal _IMPUESTO2;
        public Decimal _INAFECTO;    // _RUBRO1;
        public Decimal _RUBRO2;
        public Decimal _MONTO;
        public string _CUENTA_BANCO;
        public string _CUENTA_CONTABLE;
        public string _CENTRO_COSTO;
        public string _APLICACION;
        public string _DESCRIPCION_CUENTA;
        public string _SUCURSAL;
        public string _SCC;
        public string _ADICIONAL;
        public string _DESTINO;


        //**
        public string varPROCESAR = "";
        public string varDOCUMENTO = "";
        public string varTIPO = "";
        public Int16  varSUBTIPODOC = 0;
        public DateTime varFECHA_DOCUMENTO ;
        public DateTime varFECHA_CONTABLE;
        public string varCONTRIBUYENTE = "";
        public string varMONEDA = "";
        public Decimal varTIPO_CAMBIO = 0;
        public Decimal varSUBTOTAL = 0;
        public Decimal varDESCUENTO = 0;
        public Decimal varIGV = 0;  // varIMPUESTO1 = 0;
        public Decimal varIMPUESTO2 = 0;
        public Decimal varINAFECTO; // varRUBRO1 = 0;
        public Decimal varRUBRO2 = 0;
        public Decimal varMONTO = 0;
        public string varCUENTA_BANCO = "";
        public string varCUENTA_CONTABLE = "";
        public string varCENTRO_COSTO = "";
        public string varAPLICACION = "";
        public DateTime varFECHA_PROCESO;
        public string varUSUARIO = "";
        public string varDESCRIPCION_CUENTA = "";
        public string varSUCURSAL = "";
        public string varSCC = "";
        public string varADICIONAL = "";
        public string varDESTINO = "";
        public string varLIQUIDADO = "";
        public string varUSUARIOLIQ = "";
        public string varNOMBRE = ""; //responsable ER
        public string varRESPONSABLE = ""; //responsable generar cargo
        public string varEMPLEADO = "";
        public string varCODIGO = "";

        public string varUSUARIO_LIQUIDACIO = "";
        public DateTime varFECHA_LIQUIDACION;

        //var CARGO
        public bool varSELECCIONADO = false;
        //public string varSUCURSAL = "";
        public string varNUM_DOCUMENTO = "";
        public DateTime varFECHA;
        //public string varTIPO = "";
        //public string varDOCUMENTO = "";
        public string varPROVEEDOR = "";
        public string varNOMBRE_PROV = "";
        //public string varAPLICACION = "";
        //public string varMONEDA = "";
        public Decimal varMONTO_LOCAL = 0;
        public Decimal varMONTO_DOLAR = 0;
        public string varASIENTO = "";
        public string varFONDO_FIJO = "";
        public int varITEM = 0;
        public string varPERIODO = "";
        public string varREEMBOLSADO = "";
        public string varENTREGA_RENDIR = "";
        public Decimal varSALDO_LOCAL = 0;
        public Decimal varSALDO_DOLAR = 0;

        public int NumeroItem = 0;

        DataTable dtCargo = new DataTable();
        DataTable dtCargoDetalle = new DataTable();


        public DateTime dFechaArchIni { get; set; }
        public DateTime dFechaArchFin { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }

        public string cMensajeErrorFondoFijo = "";
        public int NumErroresFondoFijo = 0;
        public bool lDatos_Asiento = false;

        public string _credito_tipo = "";
        public string _credito_asiento = "";

        //NUMERO DE ULTIMO CARGO
        public int NroCargoUltimo = 0;

        //CARGO GENERADO
        public DateTime FecCargoGenerado { get; set; }
        public int NroCargoGenerado = 0;     // NroCargoGenerado = NroCargoUltimo + 1
        public string NroCargoGeneradoImpresion = "";

        //ARCHIVO
        public string FecCargoArchivo = "";
        public string NroCargoArchivo = "";
        public string NroCargoArchivoImpresion = "";

        //CARGO
        public int var_CARGO = 0;
        public int var_ITEM = 0;
        public DateTime var_FECHA_CARGO { get; set; }
        public string var_FONDO_FIJO = "";
        public string var_SUCURSAL = "";
        public string var_APLICACION = "";
        public DateTime var_FECHA_FONDO { get; set; }
        public string var_MONEDA = "";
        public Decimal var_MONTO = 0;
        public Decimal var_MONTO_LOCAL = 0;
        public Decimal var_MONTO_DOLAR = 0;
        public string var_REEMBOLSADO = "";
        public string var_EMPLEADO = "";
        public string var_PROVEEDOR = "";
        public string var_NOMBRE = "";
        public string var_NOMBRE_PROV = "";
        public string var_RESPONSABLE = ""; //responsable generar cargo
        public string var_ENTREGA_RENDIR = "";
        public DateTime var_FECHA_ENTREGA { get; set; }
        public string var_LIQUIDADO = "";
        public string var_CODIGO = "";

        public Decimal var_SALDO = 0;
        public Decimal var_SALDO_LOCAL = 0;
        public Decimal var_SALDO_DOLAR = 0;

        public string var_USUARIO_LIQUIDACION = "";
        public DateTime var_FECHA_LIQUIDACION { get; set; }


        //CAJAS filtro
        public string _cajas;
        public string _cajas_hist;
        CargaLookUpBL objCargaLookUpBL = new CargaLookUpBL();
        public int varNumResponsable = 0;
        public string _liquidado = "";


        public frmCargoEntregaRendir(string _base, string _user)
        {
            InitializeComponent();
            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
                                    //_password = _pass;      // txtPassword.Text;
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmCargoEntregaRendir m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frmCargoEntregaRendir DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCargoEntregaRendir(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmCargoEntregaRendir_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------              
            //seteo general
            varAplicacion = Global.vOpcionFormulario1;              // "FondoFijo" , "EntregaRendir";
            varAplicacionDescripcion = Global.vOpcionFormulario2;   // "Fondo Fijo", "Entrega a Rendir";


            // obtengo primer y ultimo dia del mes actual
            DateTime? fechatemp = null;
            DateTime? fecha1 = null;
            DateTime? fecha2 = null;
            fechatemp = DateTime.Today;
            //fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
            //fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);

            /*
            if (fechatemp.Value.Month == 12)
            {
                //fecha1 = new DateTime(fechatemp.Value.Year + 1, 1, 1);
                //fecha2 = new DateTime(fechatemp.Value.Year + 1, 2, 1).AddDays(-1);
                fecha1 = new DateTime(fechatemp.Value.Year + 1, 0, 1);
                fecha2 = new DateTime(fechatemp.Value.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                //fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1);
                //fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 2, 1).AddDays(-1);
                fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 0, 1);
                fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
            }
            */

            //Primero obtenemos el día actual
            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);
            fecha1 = oPrimerDiaDelMes;
            fecha2 = oUltimoDiaDelMes;
            //deFechaFFIni.Text = fecha1.ToString();
            //deFechaFFFin.Text = fecha2.ToString();
            deFechaCargoProceso.Text = DateTime.Now.ToString();

            //ARCHIVO
            deFechaArchivoIni.Text = fecha1.ToString();
            deFechaArchivoFin.Text = fecha2.ToString();


            dFechaArchIni = Convert.ToDateTime(deFechaArchivoIni.Text);
            dFechaArchFin = Convert.ToDateTime(deFechaArchivoFin.Text);

            if (varAplicacion == "FondoFijo")
            {
            }
            else
            {
                xtraTabControl1.Text = varAplicacionDescripcion;
                xtraTabPageExcel.Text = varAplicacionDescripcion;
                xtraTabPageBrowse.Text = "~";

                //xtraTabPageEntregaRendir.PageEnabled = false;	//entrega
                //xtraTabPageEntregaRendir.PageVisible = false;	//entrega
                xtraTabPageEntregaRendirBrowse.PageEnabled = true;	//entrega
                xtraTabPageEntregaRendirBrowse.PageVisible = true;	//entrega
                //xtraTabPageFondoFijo.PageEnabled = false;    //fondo
                //xtraTabPageFondoFijo.PageVisible = false;    //fondo
                //xtraTabPageFondoFijo.PageEnabled = false;    //fondo
                //xtraTabPageFondoFijoBrowse.PageEnabled = false;    //fondo
                //xtraTabPageFondoFijoBrowse.PageVisible = false;    //fondo

                //xtraTabPageDocumentosCargados.PageEnabled = false;
                //xtraTabPageDocumentosCargados.PageVisible = false;
                xtraTabPageEntregaRendirBrowse.PageEnabled = true;
                xtraTabPageEntregaRendirBrowse.PageVisible = true;
                //xtraTabPageEntregaRendir.PageEnabled = false;
                //xtraTabPageEntregaRendir.PageVisible = false;
                //xtraTabPageCargaExactus.PageEnabled = false;
                //xtraTabPageCargaExactus.PageVisible = false;

                //xtraTabPageCreditos.PageEnabled = false;
                //xtraTabPageCreditos.PageVisible = false;
                //xtraTabPageCargoDetalle.PageEnabled = false;
                //xtraTabPageCargoDetalle.PageVisible = false;

                varAplicacionTipo = "ER";
                TipoOperacionCajaChica = "ER";
                //radioGroupTipoContribuyente.EditValue = "Empleado";
                //deFechaEntregaER.Text = DateTime.Now.ToString();
                //deFechaVencimientoER.Text = DateTime.Now.ToString();
                deFechaERIni.Text = fecha1.ToString();
                deFechaERFin.Text = fecha2.ToString();
                //txtNumeroEntregaER.Text = ContabilidadBL.ObtenerCorrelativoEntregaRendirBL(Global.vUserBaseDatos);
                //txtTipoCambioER.Text = ContabilidadBL.ObtenerTipoCambioBL("TVTA", Global.vUserBaseDatos).ToString();
                //lblFondoFijo.Visible = false; 
                //lblEntregaRendir.Visible = true;
                //lblFondoFijo2.Visible = false;
                //lblEntregaRendir2.Visible = true;
                //txtCuentaBanco2.Visible = false;

                //btnAceptarER.Enabled = false;
                //btnCleanER.Enabled = false;
                //btnUpdateER.Enabled = false;

                _primera_vez = true;
                //CargaGrillaVaciaExcel();
                //CargaGrillaVaciaOtros();
                CargaGrillaVaciaCargos();
                cTabXls = "Carga";
                //chkCargaExactus.CheckState = CheckState.Unchecked;
                //chkCreditos.CheckState = CheckState.Unchecked;
                //chkFF.CheckState = CheckState.Unchecked;

                Carga_lookUp_Caja_ER();
                this.lookUpCuentaBancoER2.Text = "CAJA_CHICA_GER, CAJA_CHICA_AQP, CAJA_CHICA_AQ2, CAJA_CHICA_CAJ, CAJA_CHICA_CHI, CAJA_CHICA_CHN, CAJA_CHICA_HYO, CAJA_CHICA_ICA, CAJA_CHICA_LIN, CAJA_CHICA_LOL, CAJA_CHICA_MAN, CAJA_CHICA_PIE, CAJA_CHICA_PIU, CAJA_CHICA_SBO, CAJA_CHICA_SLU, CAJA_CHICA_SMP, CAJA_CHICA_SUR, CAJA_CHICA_DOLAR, CAJA_CHICA_PRI";
                this.lookUpCuentaBancoER2.Visible = false;
                labelControl57.Visible = false;

                //lookUpCuentaBancoFF_Hist
                Carga_lookUp_CuentaBanco_Hist();
                this.lookUpCuentaBancoFF_Hist.Text = "CAJA_CHICA_GER, CAJA_CHICA_AQP, CAJA_CHICA_AQ2, CAJA_CHICA_CAJ, CAJA_CHICA_CHI, CAJA_CHICA_CHN, CAJA_CHICA_HYO, CAJA_CHICA_ICA, CAJA_CHICA_LIN, CAJA_CHICA_LOL, CAJA_CHICA_MAN, CAJA_CHICA_PIE, CAJA_CHICA_PIU, CAJA_CHICA_SBO, CAJA_CHICA_SLU, CAJA_CHICA_SMP, CAJA_CHICA_SUR, CAJA_CHICA_DOLAR, CAJA_CHICA_PRI";
                this.lookUpCuentaBancoFF_Hist.Visible = false;
                labelControl56.Visible = false;


                ObtenerArchivoERCargoV2(dFechaArchIni, dFechaArchFin, null);

                _liquidado = "S";
                chkLiquidado.Checked = true;

                //------------------------------------------------------------------------
                btnUpdateListaER.Visible = true;
                chkER.Visible = true;
                txtNombreUsuario.Visible = true;
                btnValidarDocsCargoER.Visible = false;
                btnERcargoAgregar.Visible = true;
                btnExportarXlsER2.Visible = true;


                btnUpdateListaER.Location = new System.Drawing.Point(934, 7);
                chkER.Location = new System.Drawing.Point(64, 5);
                txtNombreUsuario.Location = new System.Drawing.Point(240, 10);
                btnValidarDocsCargoER.Location = new System.Drawing.Point(270, 5);
                btnERcargoAgregar.Location = new System.Drawing.Point(564, 5);
                btnExportarXlsER2.Location = new System.Drawing.Point(945, 5);
                //chkER   64; 20
                //btnValidarDocsCargoER   270; 10
                //btnERcargoAgregar     564; 10
                //btnExportarXlsER2    1145; 10
                //------------------------------------------------------------------------

                btnCargoActualizar.Visible = true;
                btnGenerarCargo.Visible = true;
                chkCargo.Visible = true;
                btnCargoQuitar.Visible = false;
                btnCargoGeneradoImprimir.Visible = true;
                btnCargoAgregar.Visible = false;
                btnCargoExportar.Visible = true;

                //btnCargoActualizar.Location = new System.Drawing.Point(758, 20);
                //btnGenerarCargo.Location = new System.Drawing.Point(937, 18);

                chkCargo.Location = new System.Drawing.Point(53, 1);
                btnCargoQuitar.Location = new System.Drawing.Point(207, 1);
                btnCargoGeneradoImprimir.Location = new System.Drawing.Point(544, 1);
                btnCargoAgregar.Location = new System.Drawing.Point(768, 1);
                btnCargoExportar.Location = new System.Drawing.Point(937, 1);

                //btnCargoActualizar    958, 20
                //btnGenerarCargo   1137, 18
//chkCargo  53; 25
//btnCargoQuitar   207; 15
//btnCargoGeneradoImprimir   544; 15
//btnCargoAgregar   968; 15
//btnCargoExportar  1137; 15
                //------------------------------------------------------------------------

                labelControl54.Visible = true;
                txtCargoArchivo.Visible = true;
                btnImprimirArchivo.Visible = true;
                btnExportarArchivo.Visible = true;

                labelControl54.Location = new System.Drawing.Point(154, 1);
                txtCargoArchivo.Location = new System.Drawing.Point(412, 1);
                btnImprimirArchivo.Location = new System.Drawing.Point(568, 1);
                btnExportarArchivo.Location = new System.Drawing.Point(914, 1);

//labelControl54   154; 27
//txtCargoArchivo   412; 20
//btnImprimirArchivo    568; 17
//btnExportarArchivo  1114; 17
                //------------------------------------------------------------------------





                _primera_vez = false;
            }

            // seteo general
            //txtDocumentoCarga.Enabled = false;
            //txtDocumentoCarga2.Enabled = false;
            //txtCuentaBanco2.Enabled = false;
        }

        //---------------------------------------------------------------------------------------------

        #region CARGA_ENTORNO_VARIABLES
        public void AccederEntornoReportesApssa(string base_datos, string usuario)
        {
            //txtBaseDatos.Text = base_datos;
            //txtUsuario.Text = usuario;
            try
            {
                if (LoginBL.DBAutenticarUsuarioSinClave(usuario, base_datos))
                {
                    Global.vUserUsuario = usuario;
                    //Global.vUserClave = password;
                    Global.vUserBaseDatos = base_datos;
                    this.DialogResult = DialogResult.OK;

                    //-----------------------------------------------------------------------
                    // CARGA CONFIGURACION INICIAL / SETTING
                    //-----------------------------------------------------------------------
                    //frmAccesoUsuario FormLogin = new frmAccesoUsuario();
                    //FormLogin.ShowDialog();
                    //if (FormLogin.DialogResult == DialogResult.OK)
                    if (this.DialogResult == DialogResult.OK)
                    {
                        CargaDatosUsuario(Global.vUserUsuario);

                        Global.vUserGrupo = usuarioreporte.grupo;
                        Global.vUserNombre = usuarioreporte.nombre;
                        Global.vUserTienda = usuarioreporte.zona;
                        Global.vUserBodega = usuarioreporte.bodega;
                        Global.vUserClave = usuarioreporte.clave_reporte;
                        Global.vUserTiendaDescrip = usuarioreporte.zona_descrip;
                        Global.vUserBodegaDescrip = usuarioreporte.bodega_descrip;
                        Global.vUserGrupo_a = usuarioreporte.grupo_a;
                        Global.vUserCaja = usuarioreporte.caja;
                        Global.vUserCajaDescrip = usuarioreporte.caja_descrip;

                        txtUsuario.Text = Global.vUserUsuario;
                        txtNombreUsuario.Text = Global.vUserNombre;

                        //MessageBox.Show("Bienvenido....   " + " [" + Global.vUserUsuario + "]  " + usuarioreporte.nombre,
                        //                "Reportes APSSA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //this.Hide();
                    }
                    else
                    {
                        this.Close();
                        Application.Exit();
                        return;
                    }


                }
                else
                {
                    if (NumIntentos == 3)
                    {
                        Global.vUserUsuario = null;
                        Global.vUserClave = null;
                        this.DialogResult = DialogResult.Abort;
                        MessageBox.Show("Sobrepaso el limite de intentos.\nLa aplicacion de cerrara.", "Reportes APSSA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //txtPassword.Text = "";
                        MessageBox.Show("Vuelva a intentar....Tiene " + (3 - NumIntentos).ToString() + "  Intentos mas ..", "Reportes APSSA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NumIntentos++;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        public void CargaDatosUsuario(string user)
        {
            if (usuarioreporte == null)
                usuarioreporte = new UsuarioReporte();

            ds_user = LoginBL.DBCargaDatosUsuario(user, Global.vUserBaseDatos);

            DataTableReader lectoruser = ds_user.Tables[0].CreateDataReader();

            while (lectoruser.Read())
            {
                usuarioreporte.usuario = lectoruser[0].ToString();          // USUARIO
                usuarioreporte.nombre = lectoruser[1].ToString();           // NOMBRE
                usuarioreporte.zona = lectoruser[2].ToString();             // ZONA
                usuarioreporte.bodega = lectoruser[3].ToString();           // BODEGA
                usuarioreporte.clave_reporte = lectoruser[4].ToString();    // CLAVE_REPORTE
                usuarioreporte.grupo = lectoruser[5].ToString();            // GRUPO
                usuarioreporte.zona_descrip = lectoruser[6].ToString();     // ZONA_DESCRIP
                usuarioreporte.bodega_descrip = lectoruser[7].ToString();   // BODEGA_DESCRIP
                usuarioreporte.grupo_a = lectoruser[8].ToString();          // INICIAL DE GRUPO DE ACCESO
                usuarioreporte.caja = lectoruser[9].ToString();             //CAJA
                usuarioreporte.caja_descrip = lectoruser[10].ToString();    //CAJA_DESCRIP

            }

        }

        #endregion

        //---------------------------------------------------------------------------------------------




        /// <summary>
        /// ///
        /// 
        /// </summary>

        #region ENTREGA_A_RENDIR




        public void ObtenerEntregaRendir(DateTime fs1, DateTime fs2)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion Entregas a Rendir ....", "Espere por favor.."))
            {
                DataTable dtER = new DataTable();
                dtER = ContabilidadBL.dtObtieneEntregaRendirBL(fs1, fs2, Global.vUserBaseDatos);
                gcEntregaRendir.DataSource = dtER;
            }

            ConfiguraGrilla(gvEntregaRendir);
        }

        private void ValidarFacturas2ExactusEntregaRendir(string _MostarMensajeValidacion)
        {


        }

        //private void CargaEntregaRendir2Exactus(string _app_tipo_operacion)
        //{
        //    if (gvFactura.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //PROCESO GRABA
        //            DialogResult dialogResult = MessageBox.Show("Carga Excel " + varAplicacionDescripcion + " --> ERP Exactus."
        //                                                   + "\n"
        //                                                   + "\nEsta seguro de Procesar la informacion?", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus", MessageBoxButtons.YesNo);

        //            if (dialogResult == DialogResult.Yes)
        //            {

        //                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Carga Excel " + varAplicacionDescripcion + " --> ERP Exactus", "Espere por favor.."))
        //                {
        //                    varDOCUMENTO = "";
        //                    varTIPO = "";
        //                    varSUBTIPODOC = 0;
        //                    //varFECHA_DOCUMENTO;
        //                    //varFECHA_CONTABLE;
        //                    varCONTRIBUYENTE = "";
        //                    varMONEDA = "";
        //                    varTIPO_CAMBIO = 0;
        //                    varSUBTOTAL = 0;
        //                    varDESCUENTO = 0;
        //                    varIGV = 0;
        //                    varIMPUESTO2 = 0;
        //                    varINAFECTO = 0;
        //                    varRUBRO2 = 0;
        //                    varMONTO = 0;
        //                    varCUENTA_BANCO = "";
        //                    //varCUENTA_CONTABLE = txtCuentaBanco2.Text;
        //                    varCENTRO_COSTO = "";
        //                    varAPLICACION = "";
        //                    varFECHA_PROCESO = DateTime.Now;
        //                    varUSUARIO = Global.vUserUsuario;



        //                    for (int i = 0; i < gvFactura.DataRowCount; ++i)
        //                    {
        //                        DataRow row = gvFactura.GetDataRow(i);
        //                        if (row["PROCESAR"] != System.DBNull.Value)
        //                        {
        //                            if (Convert.ToBoolean(row["PROCESAR"]) == true)
        //                            {
        //                                if (row["TIPO"] != null && row["TIPO"].ToString() != "")
        //                                {

        //                                    if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
        //                                    {
        //                                        varDOCUMENTO = row["DOCUMENTO"].ToString();
        //                                        varTIPO = row["TIPO"].ToString();
        //                                        varSUBTIPODOC = Convert.ToInt16(row["SUBTIPODOC"]);
        //                                        varFECHA_DOCUMENTO = Convert.ToDateTime(row["FECHA_DOCUMENTO"]);
        //                                        varFECHA_CONTABLE = Convert.ToDateTime(row["FECHA_CONTABLE"]);
        //                                        varCONTRIBUYENTE = row["CONTRIBUYENTE"].ToString();
        //                                        varMONEDA = row["MONEDA"].ToString();
        //                                        varTIPO_CAMBIO = Convert.ToDecimal(row["TIPO_CAMBIO"]);
        //                                        varSUBTOTAL = Convert.ToDecimal(row["SUBTOTAL"]);
        //                                        varDESCUENTO = Convert.ToDecimal(row["DESCUENTO"]);
        //                                        varIGV = Convert.ToDecimal(row["IGV"]);        //IMPUESTO1
        //                                        varIMPUESTO2 = Convert.ToDecimal(row["IMPUESTO2"]);
        //                                        varINAFECTO = Convert.ToDecimal(row["INAFECTO"]);       //RUBRO1
        //                                        varRUBRO2 = Convert.ToDecimal(row["RUBRO2"]);
        //                                        varMONTO = Convert.ToDecimal(row["MONTO"]);
        //                                        //varCUENTA_BANCO = row["CUENTA_BANCO"].ToString();
        //                                        varCUENTA_CONTABLE = row["CUENTA_CONTABLE"].ToString();
        //                                        varCENTRO_COSTO = row["CENTRO_COSTO"].ToString();
        //                                        varAPLICACION = row["APLICACION"].ToString();
        //                                        //varFECHA_PROCESO = Convert.ToDateTime(row["FECHA_PROCESO"]);
        //                                        //varUSUARIO = row["USUARIO"].ToString();

        //                                        //MessageBox.Show("Procesando Factura ..... " + varTIPO + "/" + varDOCUMENTO, "Verificacion");

        //                                        ContabilidadBL.dtCargaEntregaRendirBL(varDOCUMENTO, varTIPO, varSUBTIPODOC, varFECHA_DOCUMENTO, varFECHA_CONTABLE, varCONTRIBUYENTE,
        //                                                                              varMONEDA, varTIPO_CAMBIO, varSUBTOTAL, varDESCUENTO, varIGV,
        //                                                                              varIMPUESTO2, varINAFECTO, varRUBRO2, varMONTO, varCUENTA_BANCO,
        //                                                                              varCUENTA_CONTABLE, varCENTRO_COSTO, varAPLICACION, varFECHA_PROCESO,
        //                                                                              varUSUARIO, TipoOperacionCajaChica, txtDocumentoCarga.Text, Global.vUserBaseDatos);


        //                                    }
        //                                }
        //                                //*
        //                            }
        //                        }

        //                    }

        //                }

        //                //
        //                MessageBox.Show("Proceso Finalizado !!!", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }


        //}

        //private void lookUpMonedaER_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        //MonedaER = lookUpMonedaER.EditValue.ToString(); 
        //        if ((lookUpMonedaER.Text != null) && (lookUpMonedaER.Text != string.Empty))
        //        {
        //            MonedaER = lookUpMonedaER.EditValue.ToString(); 
        //            MonedaERDesc = lookUpMonedaER.Text;
        //            txtMonedaER.Text = lookUpMonedaER.Text;
        //        }
        //    }
        //}

        //private void lookUpCuentaBancoER_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        //CuentaBancoER = lookUpCuentaBancoER.EditValue.ToString(); 
        //        if ((lookUpCuentaBancoER.Text != null) && (lookUpCuentaBancoER.Text != string.Empty))
        //        {
        //            CuentaBancoER = lookUpCuentaBancoER.EditValue.ToString(); 
        //            CuentaBancoERDesc = lookUpCuentaBancoER.Text;
        //        }
        //    }
        //}

        //private void lookUpTipoSalidaER_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        //TipoSalidaER = lookUpTipoSalidaER.EditValue.ToString();
        //        if ((lookUpTipoSalidaER.Text != null) && (lookUpTipoSalidaER.Text != string.Empty))
        //        {
        //            TipoSalidaER = lookUpTipoSalidaER.EditValue.ToString(); 
        //            TipoSalidaERDesc = lookUpTipoSalidaER.Text;
        //            Carga_lookUp_SubTipoSalidaER(lookUpTipoSalidaER.EditValue.ToString());
        //        }
        //    }
        //}

        //private void lookUpSubTipoSalidaER_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        //SubTipoSalidaER = lookUpSubTipoSalidaER.EditValue.ToString(); 
        //        if ((lookUpSubTipoSalidaER.Text != null) && (lookUpSubTipoSalidaER.Text != string.Empty))
        //        {
        //            SubTipoSalidaER = Convert.ToInt32(lookUpSubTipoSalidaER.EditValue); 
        //            SubTipoSalidaERDesc = lookUpSubTipoSalida.Text;
        //        }
        //    }
        //}

        //private void lookUpMonedaERdebito_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        //MonedaERdebito = lookUpMonedaERdebito.EditValue.ToString();
        //        if ((lookUpMonedaERdebito.Text != null) && (lookUpMonedaERdebito.Text != string.Empty))
        //        {
        //            MonedaERdebito = lookUpMonedaERdebito.EditValue.ToString(); 
        //            MonedaERdebitoDesc = lookUpMonedaERdebito.Text;
        //        }
        //    }
        //}


        //private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (radioGroupTipoContribuyente.EditValue.ToString() == "Empleado")
        //    {
        //        labelEmpleadoProveedor.Text = "Empleado";
        //    }
        //    else
        //    {
        //        labelEmpleadoProveedor.Text = "Proveedor";
        //    }

        //}


        public void Carga_lookUp_Caja_ER()
        {
            DataTable dtCaja = new DataTable();
            dtCaja = objCargaLookUpBL.dtListarCuentaBancoBL(Global.vUserBaseDatos);
            lookUpCuentaBancoER2.Properties.DataSource = dtCaja;
            lookUpCuentaBancoER2.Properties.DisplayMember = "NOMBRE";
            lookUpCuentaBancoER2.Properties.ValueMember = "CUENTA_BANCO";
            lookUpCuentaBancoER2.EditValue = null;
        }










        //private void gvEntregaRendir_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        //{
        //    //radioGroupTipoContribuyente.Text = "";
        //    //radioGroupTipoContribuyente.EditValue = "Empleado";
        //    string _emp = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "EMPLEADO").ToString();
        //    string _pro = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "PROVEEDOR").ToString();

        //    if (_emp != string.Empty)
        //    {
        //        radioGroupTipoContribuyente.EditValue = "Empleado";
        //        txtEmpleadoProveedor.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "EMPLEADO").ToString();
        //        txtContribuyenteResponsable.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "EMPLEADO").ToString();
        //    }
        //    else
        //    {
        //        radioGroupTipoContribuyente.EditValue = "Proveedor";
        //        txtEmpleadoProveedor.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "PROVEEDOR").ToString();
        //        txtContribuyenteResponsable.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "PROVEEDOR").ToString();
        //    }

        //    txtNumeroEntregaER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "ENTREGA_A_RENDIR").ToString();
        //    //txtEmpleadoProveedor.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "EMPLEADO").ToString();
        //    txtEmpleadoProveedorNombre.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "PROVEEDOR").ToString();
        //    //txtContribuyenteResponsable.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "PROVEEDOR").ToString();
        //    txtContribuyenteNombreResponsable.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "RESPONSABLE").ToString();
        //    txtAplicacionER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "APLICACION").ToString();
        //    lookUpMonedaER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "MONEDA").ToString();
        //    txtMonedaER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "MONEDA").ToString();
        //    txtMontoInicialER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "MONTO").ToString();
        //    txtTipoCambioER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "TIPO_CAMBIO_DOLAR").ToString();
        //    deFechaEntregaER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "FECHA_ENTREGA").ToString();
        //    deFechaVencimientoER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "FECHA_VENC").ToString();
        //    deFechaLiquidacionER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "FECHA_LIQUIDACION").ToString();
        //    deFechaProgramacionER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "FECHA_REG_ENTREGA").ToString();
        //    txtTotalDebitosER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "TOTAL_DEBITOS").ToString();
        //    txtTotalCreditosER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "TOTAL_CREDITOS").ToString();
        //    txtSaldoER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "SALDO").ToString();

        //    txtDocumentoCarga.Text = txtNumeroEntregaER.Text;
        //    txtDocumentoCarga2.Text = txtNumeroEntregaER.Text;

        //    //ObtenerCreditos(TipoOperacionCajaChica, txtNumeroEntregaER.Text); //MAX2018
        //    ObtenerCreditosCargo(TipoOperacionCajaChica, txtNumeroEntregaER.Text); //MAX2018

        //    AplicaFormatoCajasFF();


        //    //varSUCURSAL = ContabilidadBL.dtObtenerSucursalCuentaBancariaBL(lookUpCuentaBanco.Text, Global.vUserBaseDatos);
        //    varSUCURSAL = "";
        //    //lookUpCuentaBancoER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtCuentaBancoNombreER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //lookUpTipoSalidaER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //lookUpSubTipoSalidaER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtContribuyenteER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtContribuyenteNombreER.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //lookUpMonedaERdebito.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtDocumentoERdebito.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtMontoERdebito.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //deFechaERdebito.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtAplicacionERdebito.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtAsientoERdebito.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();
        //    //txtOrdenGiro.Text = gvEntregaRendir.GetRowCellValue(gvEntregaRendir.FocusedRowHandle, "").ToString();

        //}



        private void btnCleanER_Click(object sender, EventArgs e)
        {
            //LimpiarCajasER();
        }

        private void chkER_CheckedChanged(object sender, EventArgs e)
        {
            if (chkER.Checked)
            {
                try
                {
                    Int32 j;
                    for (j = 0; j < gvEntregaRendir.RowCount; j++)
                    {
                        gvEntregaRendir.SetRowCellValue(j, "PROCESAR", true);
                    }

                    gcEntregaRendir.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Int32 j;
                    for (j = 0; j < gvEntregaRendir.RowCount; j++)
                    {
                        gvEntregaRendir.SetRowCellValue(j, "PROCESAR", false);
                    }

                    gcEntregaRendir.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        #endregion


        /// <summary>
        /// ///
        /// 
        /// </summary>

        #region CREDITOS

        //private void btnAsientoCredito_Click(object sender, EventArgs e)
        //{
        //    lDatos_Asiento = false;
        //    frmCajaChicaCreditoAsiento FormAsiento = new frmCajaChicaCreditoAsiento();
        //    FormAsiento._tipo = TipoOperacionCajaChica;
        //    FormAsiento._asiento = _credito_asiento;
        //    FormAsiento._descripcion_aplicacion = varAplicacionDescripcion;
        //    FormAsiento.ShowDialog();
        //    if (FormAsiento.DialogResult == DialogResult.OK)
        //    {
        //        //varU_POSICION = FormAsiento._U_POSICION;
        //        lDatos_Asiento = true;
        //    }
        //    else
        //    {
        //        lDatos_Asiento = false;
        //        //MessageBox.Show("Vuelva a intentar....");  // TODO numero de intentos
        //    }
        //}

        //private void btnExportarCreditos_Click(object sender, EventArgs e)
        //{
        //    if (gvCreditos.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel " + varAplicacionDescripcion + "--> ERP Exactus");
        //        return;
        //    }
        //    else
        //    {
        //        gcCreditos.ShowPrintPreview();
        //    }
        //}

        //private void btnUpdateCreditos_Click(object sender, EventArgs e)
        //{
        //    if (varAplicacion == "FondoFijo")
        //    {
        //        ObtenerCreditosCargo(TipoOperacionCajaChica, txtTransaccionFondoFijo.Text); //14/07/2020
        //    }
        //    else
        //    {
        //        ObtenerCreditosCargo(TipoOperacionCajaChica, txtNumeroEntregaER.Text); //14/07/2020
        //    }
        //}

        //private void gvCreditos_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        //{

        //}

        //public void ObtenerCreditos(string _tipo_credito, string _numero_credito)
        //{
        //    using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion ....", "Espere por favor.."))
        //    {
        //        DataTable dtCreditos = new DataTable();
        //        dtCreditos = ContabilidadBL.dtObtieneCreditosBL(_tipo_credito, _numero_credito, Global.vUserBaseDatos);
        //        gcCreditos.DataSource = dtCreditos;
        //    }

        //    //ConfiguraGrilla(gvCreditos);
        //    ConfiguraGridCreditos();
        //}

        //public void ObtenerCreditosCargo(string _tipo_credito, string _numero_credito)
        //{
        //    using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion ....", "Espere por favor.."))
        //    {
        //        DataTable dtCreditos = new DataTable();
        //        dtCreditos = ContabilidadBL.dtObtieneCreditosCargoBL(_tipo_credito, _numero_credito, Global.vUserBaseDatos);
        //        gcCreditos.DataSource = dtCreditos;
        //    }

        //    //ConfiguraGrilla(gvCreditos);
        //    ConfiguraGridCreditos();
        //}
        //private void gvCreditos_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        //{
        //    if (gvCreditos.RowCount > 0)
        //    {
        //        _credito_asiento = gvCreditos.GetRowCellValue(gvCreditos.FocusedRowHandle, "ASIENTO").ToString();
        //    }
        //}

        //private void chkCreditos_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkCreditos.Checked)
        //    {
        //        // actualiza embarque
        //        try
        //        {
        //            Int32 j;
        //            for (j = 0; j < gvCreditos.RowCount; j++)
        //            {
        //                gvCreditos.SetRowCellValue(j, "PROCESAR", true);
        //            }

        //            gcCreditos.RefreshDataSource();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {

        //        // actualiza embarque
        //        try
        //        {
        //            Int32 j;
        //            for (j = 0; j < gvCreditos.RowCount; j++)
        //            {
        //                gvCreditos.SetRowCellValue(j, "PROCESAR", false);
        //            }

        //            gcCreditos.RefreshDataSource();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //public void ConfiguraGridCreditos()
        //{
        //    //agrego checkbox
        //    gvCreditos.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvCreditos_CustomRowCellEdit);
        //    RepositoryItemCheckEdit repositoryCheckEditCreditos = gcCreditos.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
        //    repositoryCheckEditCreditos.Name = "CheckGenerar";
        //    repositoryCheckEditCreditos.ValueChecked = "True";
        //    repositoryCheckEditCreditos.ValueUnchecked = "False";
        //    gvCreditos.Columns["PROCESAR"].ColumnEdit = repositoryCheckEditCreditos;

        //    //Font fnt = new Font(gvFactura.Appearance.Row.Font.Name, 7);
        //    //gvCreditos.Appearance.HeaderPanel.Font = fnt;
        //    //gvCreditos.Appearance.Row.Font = fnt;
        //    //gvCreditos.Appearance.Row.Options.UseFont = true;
        //    //gvCreditos.OptionsView.ShowGroupPanel = false;
        //    //gvCreditos.OptionsView.ShowIndicator = false;
        //    //gvCreditos.OptionsBehavior.Editable = false;
        //    //gvCreditos.OptionsSelection.EnableAppearanceFocusedCell = false;

        //    gvCreditos.OptionsView.ColumnAutoWidth = false;
        //    gvCreditos.BestFitColumns();
        //    //gvFactura.OptionsView.ColumnAutoWidth = true;
        //    //Font fnt = new Font(gvFactura.Appearance.Row.Font.Name, 7);
        //    System.Drawing.Font fnt = new System.Drawing.Font(gvCreditos.Appearance.Row.Font.Name, 7);
        //    gvCreditos.Appearance.HeaderPanel.Font = fnt;
        //    gvCreditos.Appearance.Row.Font = fnt;
        //    gvCreditos.Appearance.Row.Options.UseFont = true;
        //    gvCreditos.OptionsView.ShowGroupPanel = false;
        //    gvCreditos.OptionsView.ShowIndicator = false;
        //    gvCreditos.OptionsBehavior.Editable = true;  //false;
        //    gvCreditos.OptionsSelection.EnableAppearanceFocusedCell = false;
            
        //}

        //MAXMAX  14/07/2020
        //private void btnCargoAgregar_Click(object sender, EventArgs e)
        //{
        //    if (txtDocumentoCarga2.Text == "" || txtDocumentoCarga2.Text == null)
        //    {
        //        MessageBox.Show("1111Debe seleccionar un Documento.", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ");
        //        return;
        //    }
        //    else
        //    {
        //        if (varAplicacion == "FondoFijo")
        //        {
        //            //CargaCreditoFondoFijo2Cargo(varAplicacionTipo);
        //        }
        //        else
        //        {
        //            //CargaEntregaRendir2Exactus(varAplicacionTipo);
        //            //CargaEntregaRendir2Cargo(varAplicacionTipo);   //PDTE
        //        }

        //    }
        //}

        //public bool ExisteItemSeleccionado()
        //{

        //    bool varExiste = false;
        //    //bool varTrue = true;
        //    // recorre toda la grilla
        //    try
        //    {
        //        Int32 j;
        //        for (j = 0; j < gvCreditos.RowCount; j++)
        //        {
        //            //bool varValor = Convert.ToBoolean(gvCreditos.GetRowCellValue(j, "PROCESAR"));

        //            //gvCreditos.SetRowCellValue(j, "PROCESAR", false);
        //            //if ((bool)gvCreditos.GetRowCellValue(j, "PROCESAR") == true)
        //            //if (varValor == true)
        //            if (Convert.ToBoolean(gvCreditos.GetRowCellValue(j, "PROCESAR")) == true)
        //            {
        //                varExiste = true;
        //                return varExiste;
        //                //if (user.id == (int)gridView.GetRowCellValue(i, "id")) return true;
        //                //return false;
        //            }
        //        }

        //        //gcCreditos.RefreshDataSource();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    return varExiste;

        //}
        //MAXMAX  14/07/2020
        //private void CargaCreditoFondoFijo2Cargo(string _app_tipo_operacion)
        //{
        //    if (gvCreditos.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Procesar.", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ");
        //        return;
        //    }
        //    if (ExisteItemSeleccionado() == false)
        //    {
        //        MessageBox.Show("Debe seleccionar uno o mas Documentos.", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ");
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //PROCESO GRABA
        //            DialogResult dialogResult = MessageBox.Show("Cargo " + varAplicacionDescripcion + " "
        //                                                   + "\n"
        //                                                   + "\nEsta seguro de Procesar la informacion?", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ", MessageBoxButtons.YesNo);

        //            if (dialogResult == DialogResult.Yes)
        //            {

        //                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Cargo Fondo Fijo " + varAplicacionDescripcion + " ", "Espere por favor.."))
        //                {
        //                    //varPROCESAR = "";
        //                    varNUM_DOCUMENTO = "";
        //                    //varFECHA;
        //                    varTIPO = "";
        //                    varDOCUMENTO = "";
        //                    varPROVEEDOR = "";
        //                    varNOMBRE_PROV = "";
        //                    varAPLICACION = "";
        //                    varMONEDA = "";
        //                    varMONTO_LOCAL = 0;
        //                    varMONTO_DOLAR = 0;
        //                    varASIENTO = "";
        //                    varFONDO_FIJO = "";
        //                    varITEM = 0;
        //                    varPERIODO = "";
        //                    varREEMBOLSADO = "";
        //                    varRESPONSABLE = "";

        //                    varUSUARIO = Global.vUserUsuario;
        //                    varFECHA_PROCESO = DateTime.Now;

        //                    // INGRESA DOCUMENTOS_CAJA
        //                    for (int i = 0; i < gvCreditos.DataRowCount; ++i)
        //                    {
        //                        DataRow row = gvCreditos.GetDataRow(i);

        //                        if (row["PROCESAR"] != System.DBNull.Value)
        //                        {
        //                            if (Convert.ToBoolean(row["PROCESAR"]) == true)
        //                            {
        //                                if (row["TIPO"] != null && row["TIPO"].ToString() != "")
        //                                {
        //                                    if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
        //                                    {
        //                                        varSELECCIONADO = Convert.ToBoolean(row["PROCESAR"]);
        //                                        //varSUCURSAL = "";
        //                                        varNUM_DOCUMENTO = row["NUM_DOCUMENTO"].ToString();
        //                                        varFECHA = Convert.ToDateTime(row["FECHA"]);
        //                                        //varFECHA_DOCUMENTO = Convert.ToDateTime(row["FECHA_DOCUMENTO"]);
        //                                        //varFECHA_CONTABLE = Convert.ToDateTime(row["FECHA_CONTABLE"]);
        //                                        varTIPO = row["TIPO"].ToString();
        //                                        varDOCUMENTO = row["DOCUMENTO"].ToString();
        //                                        varPROVEEDOR = row["PROVEEDOR"].ToString();
        //                                        varNOMBRE_PROV = row["NOMBRE_PROV"].ToString();
        //                                        varAPLICACION = row["APLICACION"].ToString();
        //                                        varMONEDA = row["MONEDA"].ToString();
        //                                        varMONTO_LOCAL = Convert.ToDecimal(row["MONTO_LOCAL"]);
        //                                        varMONTO_DOLAR = Convert.ToDecimal(row["MONTO_DOLAR"]);
        //                                        varASIENTO = row["ASIENTO"].ToString();
        //                                        varFONDO_FIJO = row["FONDO_FIJO"].ToString();

        //                                        //Agrega Items al DataTable
        //                                        AgregarFilaGrillaCargo();
        //                                    }
        //                                }
        //                                //*
        //                            }
        //                        }

        //                    }

        //                }

        //                //
        //                MessageBox.Show("Proceso Finalizado !!!", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }


        //}
 
        //public void AgregarFilaGrillaCargo()
        //{
        //    NumeroItem = NumeroItem + 1;
        //    varITEM = NumeroItem;

        //    DataTable dtTmp = gcCargoDetalle.DataSource as DataTable;
        //    DataRow newRow = dtTmp.NewRow();
        //    newRow["PROCESAR"] = varSELECCIONADO;
        //    newRow["ITEM"] = varITEM;
        //    newRow["PERIODO"] = varPERIODO;
        //    newRow["REEMBOLSADO"] = varREEMBOLSADO;
        //    newRow["RESPONSABLE"] = varRESPONSABLE;
        //    newRow["SUCURSAL"] = varSUCURSAL;
        //    newRow["NUM_DOCUMENTO"] = varNUM_DOCUMENTO;
        //    newRow["FECHA"] = varFECHA;
        //    newRow["TIPO"] = varTIPO;
        //    newRow["DOCUMENTO"] = varDOCUMENTO;
        //    newRow["PROVEEDOR"] = varPROVEEDOR;
        //    newRow["NOMBRE_PROV"] = varNOMBRE_PROV;
        //    newRow["APLICACION"] = varAPLICACION;
        //    newRow["MONEDA"] = varMONEDA;
        //    newRow["MONTO_LOCAL"] = varMONTO_LOCAL;
        //    newRow["MONTO_DOLAR"] = varMONTO_DOLAR;
        //    newRow["ASIENTO"] = varASIENTO;
        //    newRow["FONDO_FIJO"] = varFONDO_FIJO;

        //    dtTmp.Rows.InsertAt(newRow, 0);
        //}




        /*
         public void CargaGrillaCreditos()
         {
             using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
             {
                 //dtExcel = ContabilidadBL.dtListarCamposExcelBL(Global.vUserBaseDatos);
                 dtExcel = ContabilidadBL.dtListarCamposExcelCajaChicaBL(Global.vUserBaseDatos);
                 gcExcel.DataSource = dtExcel;
                 ConfiguraGridExcel();
             }
         }
         */
        #endregion


        /// <summary>
        /// ///
        /// 
        /// </summary>

        //#region CARGA_A_EXACTUSS

        ////private void simpleButton2_Click_1(object sender, EventArgs e)
        ////{

        ////}

        ////private void btnValidarFacturas_Click(object sender, EventArgs e)
        ////{
        ////    ValidarFacturas2Exactus("ConMensaje");
        ////}

        ////private void btnExportarFacturas_Click(object sender, EventArgs e)
        ////{
        ////    if (gvFactura.RowCount <= 0)
        ////    {
        ////        MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        ////        return;
        ////    }
        ////    else
        ////    {

        ////        gcFactura.ShowPrintPreview();
        ////    }
        ////}

        ////private void btnCargar2Exactus_Click(object sender, EventArgs e)
        ////{
        ////    if (txtDocumentoCarga.Text == "" || txtDocumentoCarga.Text == null)
        ////    {
        ////        MessageBox.Show("Debe seleccionar un Documento.", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        ////        return;
        ////    }
        ////    else
        ////    {
        ////        if (varAplicacion == "FondoFijo")
        ////        {

        ////        }
        ////        else
        ////        {
        ////            CargaEntregaRendir2Exactus(varAplicacionTipo);
        ////        }

        ////    }

        ////}

        ////private void chkFacturas_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    if (chkCargaExactus.Checked)
        ////    {
        ////        // actualiza embarque
        ////        try
        ////        {
        ////            Int32 j;
        ////            for (j = 0; j < gvFactura.RowCount; j++)
        ////            {
        ////                gvFactura.SetRowCellValue(j, "PROCESAR", true);
        ////            }

        ////            gcFactura.RefreshDataSource();

        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            MessageBox.Show(ex.Message);
        ////        }
        ////    }
        ////    else
        ////    {

        ////        // actualiza embarque
        ////        try
        ////        {
        ////            Int32 j;
        ////            for (j = 0; j < gvFactura.RowCount; j++)
        ////            {
        ////                gvFactura.SetRowCellValue(j, "PROCESAR", false);
        ////            }

        ////            gcFactura.RefreshDataSource();

        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            MessageBox.Show(ex.Message);
        ////        }
        ////    }
        ////}


        //#endregion


        /// <summary>
        /// ///
        /// 
        /// </summary>
        /// 

        //#region CRUD_FONFO_FIJO
        //private void btnNuevoFF_Click(object sender, EventArgs e)
        //{
        //    LimpiarCajasFF();
        //    deFechaFondoFijo.Text = DateTime.Now.ToString();
        //    deFechaFFIni.Text = DateTime.Now.ToString();
        //    deFechaFFFin.Text = DateTime.Now.ToString();
        //    txtTransaccionFondoFijo.Text = ContabilidadBL.ObtenerCorrelativoFondoFijoBL(Global.vUserBaseDatos);
        //    txtTipoCambio.Text = ContabilidadBL.ObtenerTipoCambioBL("TVTA", Global.vUserBaseDatos).ToString();
        //    DesHabilitaCajasFF(false);
        //}

        //private void btnFisrt_Click(object sender, EventArgs e)
        //{
        //    gvFondoFijo.MoveFirst();
        //    CapturaValores("U");
        //}

        //private void btnPrior_Click(object sender, EventArgs e)
        //{
        //    gvFondoFijo.MovePrev();
        //    CapturaValores("U");
        //}

        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    gvFondoFijo.MoveNext();
        //    CapturaValores("U");
        //}

        //private void btnLast_Click(object sender, EventArgs e)
        //{
        //    gvFondoFijo.MoveLast();
        //    CapturaValores("U");
        //}

        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    //CapturaValores("U");
        //    //btnNuevo.Enabled = false;
        //    //btnEditar.Enabled = false;
        //    //btnGrabar.Enabled = true;
        //    //btnCancelar.Enabled = true;
        //    //btnFisrt.Enabled = false;
        //    //btnNext.Enabled = false;
        //    //btnPrior.Enabled = false;
        //    //btnLast.Enabled = false;
        //    //DesHabilitaCajasFF(false);   //HabilitaCajasTXT();

        //    MessageBox.Show("Modificar por Exactus");
        //    return;
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    CapturaValores("U");
        //    btnNuevo.Enabled = true;
        //    btnEditar.Enabled = true;
        //    btnGrabar.Enabled = false;
        //    btnCancelar.Enabled = false;
        //    btnFisrt.Enabled = true;
        //    btnNext.Enabled = true;
        //    btnPrior.Enabled = true;
        //    btnLast.Enabled = true;
        //    //LimpiarCajasFF();
        //    //DesHabilitaCajasFF(true);   //DesHabilitaCajasTXT();

        //    LimpiarCajasFF();
        //    //INICIALIZA
        //    txtTipoCambio.Text = "0.000";
        //    txtMontoFondoFijo.Text = "0.00";
        //    txtMontoLocalFondoFijo.Text = "0.00";
        //    txtMontoDolarFondoFijo.Text = "0.00";
        //    //ASIGNA VALORES DEFAULT
        //    deFechaFondoFijo.Text = DateTime.Now.ToString();
        //    deFechaReembolsar.Text = DateTime.Now.ToString();
        //    deFechaFFIni.Text = DateTime.Now.ToString();
        //    deFechaFFFin.Text = DateTime.Now.ToString();
        //    txtTransaccionFondoFijo.Text = ContabilidadBL.ObtenerCorrelativoFondoFijoBL(Global.vUserBaseDatos);
        //    txtTipoCambio.Text = ContabilidadBL.ObtenerTipoCambioBL("TVTA", Global.vUserBaseDatos).ToString();
        //    DesHabilitaCajasFF(true);
        //}

        //private void btnNuevo_Click(object sender, EventArgs e)
        //{
        //    CapturaValores("I");
        //    btnNuevo.Enabled = false;
        //    btnEditar.Enabled = false;
        //    btnGrabar.Enabled = true;
        //    btnCancelar.Enabled = true;
        //    btnFisrt.Enabled = false;
        //    btnNext.Enabled = false;
        //    btnPrior.Enabled = false;
        //    btnLast.Enabled = false;
        //    //DesHabilitaCajasFF(false);   //HabilitaCajasTXT();
        //    //LimpiarCajasFF();
        //    LimpiarCajasFF();
        //    //INICIALIZA
        //    txtTipoCambio.Text = "0.000";
        //    txtMontoFondoFijo.Text = "0.00";
        //    txtMontoLocalFondoFijo.Text = "0.00";
        //    txtMontoDolarFondoFijo.Text = "0.00";
        //    //ASIGNA VALORES DEFAULT
        //    deFechaFondoFijo.Text = DateTime.Now.ToString();
        //    deFechaReembolsar.Text = DateTime.Now.ToString();
        //    deFechaFFIni.Text = DateTime.Now.ToString();
        //    deFechaFFFin.Text = DateTime.Now.ToString();
        //    txtTransaccionFondoFijo.Text = ContabilidadBL.ObtenerCorrelativoFondoFijoBL(Global.vUserBaseDatos);
        //    txtTipoCambio.Text = ContabilidadBL.ObtenerTipoCambioBL("TVTA", Global.vUserBaseDatos).ToString();
        //    DesHabilitaCajasFF(false);
        //}

        //private void btnGrabar_Click(object sender, EventArgs e)
        //{
        //    btnNuevo.Enabled = true;
        //    btnEditar.Enabled = true;
        //    btnGrabar.Enabled = false;
        //    btnCancelar.Enabled = false;
        //    btnFisrt.Enabled = true;
        //    btnNext.Enabled = true;
        //    btnPrior.Enabled = true;
        //    btnLast.Enabled = true;
        //    DesHabilitaCajasFF(true);   //DesHabilitaCajasTXT();
        //    GrabarFondoFijo();          //GrabarDatosTecnico();
        //    CapturaValores("U");
        //}

        //private void CapturaValores(string _tipooperacionfondofijo)
        //{
        //    TipoOperacionFondoFijo = _tipooperacionfondofijo;        //"I";   //  I-inserta, U-actualiza
        //    FondoFijo = txtTransaccionFondoFijo.Text;
        //    AplicacionFondoFijo = txtAplicacionFondoFijo.Text;
        //    CuentaBancoFondoFijo = lookUpCuentaBanco.EditValue.ToString();
        //    //FechaFondoFijo = Convert.ToDateTime(deFechaFondoFijo.Text);
        //    FechaFondoFijo = (DBNull.Value.Equals(deFechaFondoFijo.Text)) ? DateTime.Now : Convert.ToDateTime(deFechaFondoFijo.Text);
        //    MonedaFondoFijo = lookUpMoneda.EditValue.ToString();
        //    TipoCambioFondoFijo = Convert.ToDecimal(txtTipoCambio.Text);
        //    //MontoFondoFijo = Convert.ToDecimal(txtMontoFondoFijo.Text);
        //    MontoFondoFijo = (DBNull.Value.Equals(txtMontoFondoFijo.Text)) ? 0 : Convert.ToDecimal(txtMontoFondoFijo.Text);
        //    MontoLocalFondoFijo = (DBNull.Value.Equals(txtMontoLocalFondoFijo.Text)) ? 0 : Convert.ToDecimal(txtMontoLocalFondoFijo.Text);
        //    MontoDolarFondoFijo = (DBNull.Value.Equals(txtMontoDolarFondoFijo.Text)) ? 0 : Convert.ToDecimal(txtMontoDolarFondoFijo.Text);
        //    //= (DBNull.Value.Equals(lector_os[75])) ? 0 : Convert.ToDecimal(lector_os[75].ToString());
        //    //= (DBNull.Value.Equals(lector_os[83])) ? String.Empty : lector_os[83].ToString();
        //    //= (DBNull.Value.Equals(lector_os[4])) ? DateTime.Now : Convert.ToDateTime(lector_os[4].ToString());
        //}

        //private void btnValidarFF_Click(object sender, EventArgs e)
        //{

        //    //MessageBox.Show(cMensajeErrorFondoFijo);

        //    //if (ValidarCamposFondoFijo()==true)
        //    //{
        //    //    MessageBox.Show("Debe especificar lo siguiente:  " + "\n"
        //    //                    + cMensajeErrorFondoFijo, "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //    //    return;
        //    //}

        //    NumErroresFondoFijo = 0;

        //    string cMensajeErrorFondoFijo = "";

        //    if ((lookUpCuentaBanco.Text != null) && (lookUpCuentaBanco.Text != string.Empty))
        //    { }     //cMensajeError = "";
        //    else
        //    {
        //        cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + "Error Cuenta Banco" + "\n";
        //        NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //    }

        //    if ((lookUpMoneda.Text != null) && (lookUpMoneda.Text != string.Empty))
        //    { }   //cMensajeError = "";
        //    else
        //    {
        //        cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + "Error Moneda" + "\n";
        //        NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //    }


        //    if (txtTipoCambio.Text == null || txtTipoCambio.Text == "")
        //    {
        //        cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + "Tipo Cambio" + "\n";
        //        NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //    }
        //    else if (txtTransaccionFondoFijo.Text == null || txtTransaccionFondoFijo.Text == "")
        //    {
        //        cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + "Numero Entrega a Rendir" + "\n";
        //        NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //    }
        //    else if (txtMontoFondoFijo.Text == null || txtMontoFondoFijo.Text == "")
        //    {
        //        cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + "Monto Fondo Fijo" + "\n";
        //        NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //    }
        //    else if (deFechaFondoFijo == null)
        //    {
        //        cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + "Fecha Fondo Fijo" + "\n";
        //        NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //    }

        //    if (lookUpMoneda.Text != "")
        //    {
        //        if (!ContabilidadBL.ExisteMonedaBL(lookUpMoneda.Text, Global.vUserBaseDatos))
        //        {
        //            cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + " Error MONEDA" + "\n";
        //            NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //        }
        //    }

        //    if (lookUpCuentaBanco.Text != "")
        //    {
        //        if (!ContabilidadBL.ExisteCuentaBancariaBL(lookUpCuentaBanco.Text, Global.vUserBaseDatos))
        //        {
        //            cMensajeErrorFondoFijo = cMensajeErrorFondoFijo + " Error CUENTA_BANCARIA" + "\n";
        //            NumErroresFondoFijo = NumErroresFondoFijo + 1;
        //        }
        //    }

        //    ////MessageBox.Show("Proceso Finalizado !!!", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //    //if (_MostarMensaje== "ConMensaje")
        //    //{
        //    //    MessageBox.Show("Debe especificar lo siguiente:  " + "\n"
        //    //                    + cMensajeError, "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //    //}

        //    //cMensajeError = "";

        //    //return NumErroresFondoFijo > 0;

        //    //MessageBox.Show(cMensajeErrorFondoFijo);

        //    if (NumErroresFondoFijo > 0)
        //    {
        //        MessageBox.Show("Debe especificar lo siguiente:  " + "\n"
        //                        + cMensajeErrorFondoFijo, "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
        //        return;
        //    }

        //}


        //#endregion


        /// <summary>
        /// ///
        /// 
        /// </summary>
        /// 

        #region RUTINAS_VARIOS
        public void ConfiguraGrilla(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsBehavior.Editable = false;
            gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            gv.OptionsView.ColumnAutoWidth = false;
            gv.BestFitColumns();
            gv.Appearance.Row.Font = new System.Drawing.Font(gv.Appearance.Row.Font, FontStyle.Bold);
            gv.Appearance.Row.Options.UseFont = true;

            System.Drawing.Font fnt = new System.Drawing.Font(gv.Appearance.Row.Font.Name, 7);
            gv.Appearance.HeaderPanel.Font = fnt;
            gv.Appearance.Row.Font = fnt;
        }
        //public void LimpiarCajasFF()
        //{
        //    lookUpCuentaBanco.Text = "";
        //    txtCuentaBancoDescripcion.Text = "";
        //    lookUpMoneda.Text = "";
        //    txtMoneda.Text = "";
        //    txtCuentaBanco.Text = "";
        //    txtTipoCambio.Text = "0";
        //    txtSaldoCuentaBancaria.Text = "";
        //    txtTransaccionFondoFijo.Text = "0";
        //    deFechaFondoFijo.Text = "";
        //    txtMontoFondoFijo.Text = "0";
        //    txtMontoLocalFondoFijo.Text = "0";
        //    txtMontoDolarFondoFijo.Text = "0";
        //    txtAplicacionFondoFijo.Text = "";
        //    lookUpTipoSalida.Text = "";
        //    txtTipoSalida.Text = "";
        //    lookUpSubTipoSalida.Text = "";
        //    txtSubTipoSalida.Text = "";
        //    txtDocumentoSalida.Text = "";
        //    deFechaReembolsar.Text = "";
        //    txtFechaReembolsar.Text = "";
        //    txtContribuyente.Text = "";
        //    txtContribuyenteDescripcion.Text = "";
        //    txtMontoLocalFondoFijo.Text = "0";
        //    txtMontoDolarFondoFijo.Text = "0";
        //}
        //public void LimpiarCajasER()
        //{
        //    //radioGroupTipoContribuyente.Text = "";
        //    txtNumeroEntregaER.Text = "";
        //    txtEmpleadoProveedor.Text = "";
        //    txtEmpleadoProveedorNombre.Text = "";
        //    txtContribuyenteResponsable.Text = "";
        //    txtContribuyenteNombreResponsable.Text = "";
        //    txtAplicacionER.Text = "";
        //    lookUpMonedaER.Text = "";
        //    txtMonedaER.Text = "";
        //    txtMontoInicialER.Text = "";
        //    txtTipoCambioER.Text = "";
        //    deFechaEntregaER.Text = "";
        //    deFechaVencimientoER.Text = "";
        //    deFechaLiquidacionER.Text = "";
        //    deFechaProgramacionER.Text = "";
        //    txtTotalDebitosER.Text = "";
        //    txtTotalCreditosER.Text = "";
        //    txtSaldoER.Text = "";
        //    lookUpCuentaBancoER.Text = "";
        //    txtCuentaBancoNombreER.Text = "";
        //    lookUpTipoSalidaER.Text = "";
        //    lookUpSubTipoSalidaER.Text = "";
        //    txtContribuyenteER.Text = "";
        //    txtContribuyenteNombreER.Text = "";
        //    lookUpMonedaERdebito.Text = "";
        //    txtDocumentoERdebito.Text = "";
        //    txtMontoERdebito.Text = "";
        //    deFechaERdebito.Text = "";
        //    txtAplicacionERdebito.Text = "";
        //    txtAsientoERdebito.Text = "";
        //    txtOrdenGiro.Text = "";
        //}
        //public void DesHabilitaCajasER(Boolean _condicion)
        //{
        //    radioGroupTipoContribuyente.ReadOnly = _condicion;
        //    txtNumeroEntregaER.ReadOnly = _condicion;
        //    txtEmpleadoProveedor.ReadOnly = _condicion;
        //    txtEmpleadoProveedorNombre.ReadOnly = _condicion;
        //    txtContribuyenteResponsable.ReadOnly = _condicion;
        //    txtContribuyenteNombreResponsable.ReadOnly = _condicion;
        //    txtAplicacionER.ReadOnly = _condicion;
        //    lookUpMonedaER.ReadOnly = _condicion;
        //    txtMonedaER.ReadOnly = _condicion;
        //    txtMontoInicialER.ReadOnly = _condicion;
        //    txtTipoCambioER.ReadOnly = _condicion;
        //    deFechaEntregaER.ReadOnly = _condicion;
        //    deFechaVencimientoER.ReadOnly = _condicion;
        //    deFechaLiquidacionER.ReadOnly = _condicion;
        //    deFechaProgramacionER.ReadOnly = _condicion;
        //    txtTotalDebitosER.ReadOnly = _condicion;
        //    txtTotalCreditosER.ReadOnly = _condicion;
        //    txtSaldoER.ReadOnly = _condicion;
        //    lookUpCuentaBancoER.ReadOnly = _condicion;
        //    txtCuentaBancoNombreER.ReadOnly = _condicion;
        //    lookUpTipoSalidaER.ReadOnly = _condicion;
        //    lookUpSubTipoSalidaER.ReadOnly = _condicion;
        //    txtContribuyenteER.ReadOnly = _condicion;
        //    txtContribuyenteNombreER.ReadOnly = _condicion;
        //    lookUpMonedaERdebito.ReadOnly = _condicion;
        //    txtDocumentoERdebito.ReadOnly = _condicion;
        //    txtMontoERdebito.ReadOnly = _condicion;
        //    deFechaERdebito.ReadOnly = _condicion;
        //    txtAplicacionERdebito.ReadOnly = _condicion;
        //    txtAsientoERdebito.ReadOnly = _condicion;
        //    txtOrdenGiro.ReadOnly = _condicion;
        //}

        //public void DesHabilitaCajasFF(Boolean _condicion)
        //{
        //    lookUpCuentaBanco.ReadOnly = _condicion;
        //    txtCuentaBancoDescripcion.ReadOnly = true;
        //    lookUpMoneda.ReadOnly = _condicion;
        //    txtMoneda.ReadOnly = true;
        //    txtCuentaBanco.ReadOnly = _condicion;
        //    txtTipoCambio.ReadOnly = _condicion;
        //    txtSaldoCuentaBancaria.ReadOnly = _condicion;
        //    txtTransaccionFondoFijo.ReadOnly = _condicion;
        //    deFechaFondoFijo.ReadOnly = _condicion;
        //    txtMontoFondoFijo.ReadOnly = _condicion;
        //    txtMontoLocalFondoFijo.ReadOnly = _condicion;
        //    txtMontoDolarFondoFijo.ReadOnly = _condicion;
        //    txtAplicacionFondoFijo.ReadOnly = _condicion;
        //    lookUpTipoSalida.ReadOnly = _condicion;
        //    txtTipoSalida.ReadOnly = _condicion;
        //    lookUpSubTipoSalida.ReadOnly = _condicion;
        //    txtSubTipoSalida.ReadOnly = _condicion;
        //    txtDocumentoSalida.ReadOnly = _condicion;
        //    deFechaReembolsar.ReadOnly = _condicion;
        //    txtFechaReembolsar.ReadOnly = _condicion;
        //    txtContribuyente.ReadOnly = _condicion;
        //    txtContribuyenteDescripcion.ReadOnly = _condicion;
        //    txtMontoLocalFondoFijo.ReadOnly = _condicion;
        //    txtMontoDolarFondoFijo.ReadOnly = _condicion;
        //}
        //private void lookUpCuentaBanco_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        CuentaBanco = lookUpCuentaBanco.Text;
        //        //if (lookUpCuentaBanco.Text != string.Empty)
        //        if ((lookUpCuentaBanco.Text != null) && (lookUpCuentaBanco.Text != string.Empty))
        //        {
        //            CuentaBancoCode = lookUpCuentaBanco.EditValue.ToString();
        //            //txtCuentaBancoDescripcion.Text = lookUpCuentaBanco.EditValue.ToString();
        //            txtCuentaBancoDescripcion.Text = lookUpCuentaBanco.Text;
        //            txtCuentaBanco.Text = lookUpCuentaBanco.EditValue.ToString();
        //        }
        //    }
        //}
        //private void lookUpMoneda_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        Moneda = lookUpMoneda.Text;
        //        //if (lookUpMoneda.Text != string.Empty)
        //        if ((lookUpMoneda.Text != null) && (lookUpMoneda.Text != string.Empty))
        //        {
        //            MonedaCode = lookUpMoneda.EditValue.ToString();
        //            txtMoneda.Text = lookUpMoneda.Text;
        //        }
        //    }
        //}
        //private void lookUpTipoSalida_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        TipoSalida = lookUpTipoSalida.Text;
        //        //if (lookUpTipoSalida.Text != string.Empty)
        //        if ((lookUpTipoSalida.Text != null) && (lookUpTipoSalida.Text != string.Empty))
        //        {
        //            TipoSalidaCode = lookUpTipoSalida.EditValue.ToString();
        //            //Carga_lookUp_SubTipoSalida(TipoSalida);
        //            Carga_lookUp_SubTipoSalida(lookUpTipoSalida.EditValue.ToString());
        //            txtTipoSalida.Text = lookUpTipoSalida.EditValue.ToString();
        //        }
        //    }
        //}
        //private void lookUpSubTipoSalida_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_primera_vez == false)
        //    {
        //        SubTipoSalida = lookUpSubTipoSalida.Text;
        //        //if (lookUpSubTipoSalida.Text != string.Empty)
        //        if ((lookUpSubTipoSalida.Text != null) && (lookUpSubTipoSalida.Text != string.Empty))
        //        {
        //            SubTipoSalidaCode = lookUpSubTipoSalida.EditValue.ToString();
        //            txtSubTipoSalida.Text = lookUpSubTipoSalida.EditValue.ToString();
        //        }
        //    }
        //}


        //public void Carga_lookUp_CuentaBanco()
        //{
        //    DataTable dt_cb = new DataTable();
        //    dt_cb = TablasExactusBL.dtObtenerCuentaBancoBL(Global.vUserBaseDatos);
        //    lookUpCuentaBanco.Properties.DataSource = dt_cb;
        //    lookUpCuentaBanco.Properties.DisplayMember = "NOMBRE";
        //    lookUpCuentaBanco.Properties.ValueMember = "CUENTA_BANCO";
        //    lookUpCuentaBanco.EditValue = null;
        //}
        //public void Carga_lookUp_Moneda()
        //{
        //    DataTable dt_mo = new DataTable();
        //    dt_mo = TablasExactusBL.dtObtenerMonedaBL(Global.vUserBaseDatos);
        //    lookUpMoneda.Properties.DataSource = dt_mo;
        //    lookUpMoneda.Properties.DisplayMember = "NOMBRE";
        //    lookUpMoneda.Properties.ValueMember = "MONEDA";
        //    //lookUpMoneda.Properties.DisplayMember = "MONEDA";
        //    //lookUpMoneda.Properties.ValueMember = "NOMBRE";
        //    lookUpMoneda.EditValue = null;
        //}
        //public void Carga_lookUp_TipoSalida()
        //{
        //    DataTable dt_ts = new DataTable();
        //    dt_ts = TablasExactusBL.dtObtenerTipoSalidaBL(Global.vUserBaseDatos);
        //    lookUpTipoSalida.Properties.DataSource = dt_ts;
        //    lookUpTipoSalida.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpTipoSalida.Properties.ValueMember = "TIPO";
        //    lookUpTipoSalida.EditValue = null;
        //}
        //public void Carga_lookUp_SubTipoSalida(string tiposalida)
        //{
        //    DataTable dt_su = new DataTable();
        //    dt_su = TablasExactusBL.dtObtenerSubTipoSalidaBL(tiposalida, Global.vUserBaseDatos);
        //    lookUpSubTipoSalida.Properties.DataSource = dt_su;
        //    lookUpSubTipoSalida.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpSubTipoSalida.Properties.ValueMember = "SUBTIPO";
        //    lookUpSubTipoSalida.EditValue = null;
        //}
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Carga")
            {
                cTabXls = "Carga";
                //MessageBox.Show("Carga....");  
            }
            else if (xtraTabControl1.SelectedTabPage.Text == "Browse")
            {
                cTabXls = "Browse";
                //MessageBox.Show("Browse....");
            }
            else if (xtraTabControl1.SelectedTabPage.Text == "Xml")
            {
                cTabXls = "Xml";
                //MessageBox.Show("Xml....");
            }

        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPage.Text)
            {
                case "Carga":
                    cTabXls = "Carga";
                    break;
                case "Browse":
                    cTabXls = "Browse";
                    break;
                case "Xml":
                    cTabXls = "xml";
                    break;
                default:
                    cTabXls = "Carga";
                    break;
            }
        }
        //public void Carga_lookUp_MonedaER()
        //{
        //    DataTable dt_mo = new DataTable();
        //    dt_mo = TablasExactusBL.dtObtenerMonedaBL(Global.vUserBaseDatos);
        //    lookUpMonedaER.Properties.DataSource = dt_mo;
        //    lookUpMonedaER.Properties.DisplayMember = "NOMBRE";
        //    lookUpMonedaER.Properties.ValueMember = "MONEDA";
        //    lookUpMonedaER.EditValue = null;
        //}
        //public void Carga_lookUp_TipoSalidaER()
        //{
        //    DataTable dt_ts = new DataTable();
        //    dt_ts = TablasExactusBL.dtObtenerTipoSalidaBL(Global.vUserBaseDatos);
        //    lookUpTipoSalidaER.Properties.DataSource = dt_ts;
        //    lookUpTipoSalidaER.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpTipoSalidaER.Properties.ValueMember = "TIPO";
        //    lookUpTipoSalidaER.EditValue = null;
        //}
        //public void Carga_lookUp_SubTipoSalidaER(string tiposalida)
        //{
        //    DataTable dt_su = new DataTable();
        //    dt_su = TablasExactusBL.dtObtenerSubTipoSalidaBL(tiposalida, Global.vUserBaseDatos);
        //    lookUpSubTipoSalidaER.Properties.DataSource = dt_su;
        //    lookUpSubTipoSalidaER.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpSubTipoSalidaER.Properties.ValueMember = "SUBTIPO";
        //    lookUpSubTipoSalidaER.EditValue = null;
        //}
        //public void Carga_lookUp_CuentaBancoER()
        //{
        //    DataTable dt_cb = new DataTable();
        //    dt_cb = TablasExactusBL.dtObtenerCuentaBancoBL(Global.vUserBaseDatos);
        //    lookUpCuentaBancoER.Properties.DataSource = dt_cb;
        //    lookUpCuentaBancoER.Properties.DisplayMember = "NOMBRE";
        //    lookUpCuentaBancoER.Properties.ValueMember = "CUENTA_BANCO";
        //    lookUpCuentaBancoER.EditValue = null;
        //}
        //public void Carga_lookUp_MonedaERdebito()
        //{
        //    DataTable dt_mo = new DataTable();
        //    dt_mo = TablasExactusBL.dtObtenerMonedaBL(Global.vUserBaseDatos);
        //    lookUpMonedaERdebito.Properties.DataSource = dt_mo;
        //    lookUpMonedaERdebito.Properties.DisplayMember = "NOMBRE";
        //    lookUpMonedaERdebito.Properties.ValueMember = "MONEDA";
        //    lookUpMonedaERdebito.EditValue = null;
        //}





        #endregion


        /// <summary>
        /// ///
        /// 
        /// </summary>
        /// 

        //#region CARGO-DETALLE_FONDO_FIJO

        //private void chkFF_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFF.Checked)
        //    {
        //         try
        //        {
        //            Int32 j;
        //            for (j = 0; j < gvFondoFijo.RowCount; j++)
        //            {
        //                gvFondoFijo.SetRowCellValue(j, "PROCESAR", true);
        //            }

        //            gcFondoFijo.RefreshDataSource();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Int32 j;
        //            for (j = 0; j < gvFondoFijo.RowCount; j++)
        //            {
        //                gvFondoFijo.SetRowCellValue(j, "PROCESAR", false);
        //            }

        //            gcFondoFijo.RefreshDataSource();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}


        //public void CargaGrillaVaciaCargosDetalle()
        //{
        //    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
        //    {
        //        dtCargoDetalle = ContabilidadBL.dtListarCamposCargoDetalleCajaChicaBL(Global.vUserBaseDatos);
        //        gcCargoDetalle.DataSource = dtCargoDetalle;
        //        ConfiguraGridCargoDetalle();
        //    }
        //}
        //private void gvCargoDetalle_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        //{

        //}
        //public void ConfiguraGridCargoDetalle()
        //{
        //    //agrego checkbox            
        //    gvCargoDetalle.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvCargoDetalle_CustomRowCellEdit);
        //    RepositoryItemCheckEdit repositoryCheckEdit1 = gcCargoDetalle.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
        //    repositoryCheckEdit1.Name = "CheckGenerar";
        //    repositoryCheckEdit1.ValueChecked = "True";
        //    repositoryCheckEdit1.ValueUnchecked = "False";
        //    gvCargoDetalle.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;

        //    RepositoryItemLookUpEdit LookUpContable = new RepositoryItemLookUpEdit();
        //    //ds_listatec = ContabilidadBL.ListarContablesBL(null, Global.vUserBaseDatos);
        //    LookUpContable.DataSource = ContabilidadBL.ListarContablesBL(null, Global.vUserBaseDatos);
        //    LookUpContable.DisplayMember = "NOMBRE";
        //    LookUpContable.ValueMember = "USUARIO";

        //    gvCargoDetalle.Columns["RESPONSABLE"].ColumnEdit = LookUpContable;

        //    //Font fnt = new Font(gvCargoDetalle.Appearance.Row.Font.Name, 7);
        //    //gvCargoDetalle.Appearance.HeaderPanel.Font = fnt;
        //    //gvCargoDetalle.Appearance.Row.Font = fnt;
        //    //gvCargoDetalle.Appearance.Row.Options.UseFont = true;
        //    //gvCargoDetalle.OptionsView.ShowGroupPanel = false;
        //    //gvCargoDetalle.OptionsView.ShowIndicator = false;
        //    //gvCargoDetalle.OptionsBehavior.Editable = false;
        //    //gvCargoDetalle.OptionsSelection.EnableAppearanceFocusedCell = false;

        //    gvCargoDetalle.OptionsView.ColumnAutoWidth = false;
        //    gvCargoDetalle.BestFitColumns();
        //    //gvCargoDetalle.OptionsView.ColumnAutoWidth = true;
        //    //Font fnt = new Font(gvCargo.Appearance.Row.Font.Name, 7);
        //    System.Drawing.Font fnt = new System.Drawing.Font(gvCargoDetalle.Appearance.Row.Font.Name, 7);
        //    gvCargoDetalle.Appearance.HeaderPanel.Font = fnt;
        //    gvCargoDetalle.Appearance.Row.Font = fnt;
        //    gvCargoDetalle.Appearance.Row.Options.UseFont = true;
        //    gvCargoDetalle.OptionsView.ShowGroupPanel = false;
        //    gvCargoDetalle.OptionsView.ShowIndicator = false;
        //    gvCargoDetalle.OptionsBehavior.Editable = true;  //false;
        //    gvCargoDetalle.OptionsSelection.EnableAppearanceFocusedCell = false;

        //}


        //private void btnCargoQuitar_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnCargoAgregar_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnCargoExportar_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnCargoImprimir_Click(object sender, EventArgs e)
        //{

        //}



        //#endregion


        //#region CARGO_FONDO_FIJO
        private void gvCargo_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

        }

        //private void btnCargoQuitar_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnCargoAgregar_Click_2(object sender, EventArgs e)
        //{

        //}





        public void CargaGrillaVaciaCargos()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
            {
                //MAXMAX
                //dtCargo = ContabilidadBL.dtListarCamposCargoCajaChicaBL(Global.vUserBaseDatos);

                if (varAplicacion == "FondoFijo")
                {
                    dtCargo = ContabilidadBL.dtListarCamposCargoCajaChicaBL(Global.vUserBaseDatos);
                }
                else
                {
                    dtCargo = ContabilidadBL.dtListarCamposCargoCajaChicaER_BL(Global.vUserBaseDatos);
                }

                gcCargo.DataSource = dtCargo;
                ConfiguraGridCargo();
            }
        }

        public void ConfiguraGridCargo()
        {
            //agrego checkbox            
            gvCargo.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvCargo_CustomRowCellEdit);
            RepositoryItemCheckEdit repositoryCheckEdit1 = gcCargo.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            repositoryCheckEdit1.Name = "CheckGenerar";
            repositoryCheckEdit1.ValueChecked = "True";
            repositoryCheckEdit1.ValueUnchecked = "False";
            gvCargo.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;

            RepositoryItemLookUpEdit LookUpContable = new RepositoryItemLookUpEdit();
            //ds_listatec = ContabilidadBL.ListarContablesBL(null, Global.vUserBaseDatos);
            LookUpContable.DataSource = ContabilidadBL.ListarContablesBL(null, Global.vUserBaseDatos);
            LookUpContable.DisplayMember = "NOMBRE";
            LookUpContable.ValueMember = "USUARIO";

            gvCargo.Columns["RESPONSABLE"].ColumnEdit = LookUpContable;

            //Font fnt = new Font(gvCargo.Appearance.Row.Font.Name, 7);
            //gvCargo.Appearance.HeaderPanel.Font = fnt;
            //gvCargo.Appearance.Row.Font = fnt;
            //gvCargo.Appearance.Row.Options.UseFont = true;
            //gvCargo.OptionsView.ShowGroupPanel = false;
            //gvCargo.OptionsView.ShowIndicator = false;
            //gvCargo.OptionsBehavior.Editable = false;
            //gvCargo.OptionsSelection.EnableAppearanceFocusedCell = false;

            gvCargo.OptionsView.ColumnAutoWidth = false;
            gvCargo.BestFitColumns();
            //gvCargo.OptionsView.ColumnAutoWidth = true;
            //Font fnt = new Font(gvCargo.Appearance.Row.Font.Name, 7);
            System.Drawing.Font fnt = new System.Drawing.Font(gvCargo.Appearance.Row.Font.Name, 7);
            gvCargo.Appearance.HeaderPanel.Font = fnt;
            gvCargo.Appearance.Row.Font = fnt;
            gvCargo.Appearance.Row.Options.UseFont = true;
            gvCargo.OptionsView.ShowGroupPanel = false;
            gvCargo.OptionsView.ShowIndicator = false;
            gvCargo.OptionsBehavior.Editable = true;  //false;
            gvCargo.OptionsSelection.EnableAppearanceFocusedCell = false;

            // COLOR
            gvCargo.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Bisque;

            if (varAplicacion == "FondoFijo")
            {
                gvCargo.Columns["FONDO_FIJO"].AppearanceCell.BackColor = Color.Bisque; ;
            }
            else
            {
                gvCargo.Columns["ENTREGA_A_RENDIR"].AppearanceCell.BackColor = Color.Bisque;
            }
            gvCargo.Columns["RESPONSABLE"].AppearanceCell.BackColor = Color.Bisque;
            //formateo
            //gvCargo.Columns["MONTO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvCargo.Columns["MONTO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvCargo.Columns["MONTO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvCargo.Columns["MONTO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //ordenamiento
            gvCargo.ClearSorting();
            gvCargo.Columns["ITEM"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            gvCargo.Columns["RESPONSABLE"].Width = 200;
            //gvCargo.Columns["PEDIDO_LINEA"].OptionsColumn.AllowEdit = false;
            //gvCargo.Columns["PEDIDO_LINEA"].Caption = "ITEM";
            //gvCargo.Columns["PEDIDO_LINEA"].Visible = true;
        }


        ////PROCESAR SELECCIONADOS
        //private void btnFFcargoAgregar_Click(object sender, EventArgs e)
        //{
        //    //inicializa grilla Cargo
        //    CargaGrillaVaciaCargos();
        //    //carga grilla
        //    CargaFondoFijo2Cargo(varAplicacionTipo);
        //}

        //public bool ExisteItemSeleccionadoFF()
        //{

        //    bool varExiste = false;

        //    try
        //    {
        //        Int32 j;
        //        for (j = 0; j < gvFondoFijo.RowCount; j++)
        //        {
        //            if (gvFondoFijo.GetRowCellValue(j, "PROCESAR") != System.DBNull.Value)
        //            {
        //                if (gvFondoFijo.GetRowCellValue(j, "PROCESAR").ToString().Replace("  ", "") != "")  //MAXERROR
        //                { 
        //                    if (Convert.ToBoolean(gvFondoFijo.GetRowCellValue(j, "PROCESAR")) == true)
        //                    {
        //                        varExiste = true;
        //                        return varExiste;
        //                    }
        //                }
        //            }
        //        }

        //        //gcFondoFijo.RefreshDataSource();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    return varExiste;

        //}
        ////MAXMAX  14/07/2020
        //private void CargaFondoFijo2Cargo(string _app_tipo_operacion)
        //{
        //    if (gvFondoFijo.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Procesar.", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ");
        //        return;
        //    }
        //    if (ExisteItemSeleccionadoFF() == false)
        //    {
        //        MessageBox.Show("Debe seleccionar uno o mas Documentos.", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ");
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //PROCESO GRABA
        //            DialogResult dialogResult = MessageBox.Show("Cargo " + varAplicacionDescripcion + " "
        //                                                   + "\n"
        //                                                   + "\nEsta seguro de Procesar la informacion?", "Cargo Fondo Fijo " + varAplicacionDescripcion + " ", MessageBoxButtons.YesNo);

        //            if (dialogResult == DialogResult.Yes)
        //            {

        //                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Cargo Fondo Fijo " + varAplicacionDescripcion + " ", "Espere por favor.."))
        //                {
        //                    //varPROCESAR = "";
        //                    varNUM_DOCUMENTO = "";
        //                    //varFECHA;
        //                    varTIPO = "";
        //                    varDOCUMENTO = "";
        //                    varPROVEEDOR = "";
        //                    varNOMBRE_PROV = "";
        //                    varAPLICACION = "";
        //                    varMONEDA = "";
        //                    varMONTO_LOCAL = 0;
        //                    varMONTO_DOLAR = 0;
        //                    varASIENTO = "";
        //                    varFONDO_FIJO = "";
        //                    varITEM = 0;
        //                    varPERIODO = "";
        //                    varREEMBOLSADO = "";
        //                    varRESPONSABLE = "";

        //                    varUSUARIO = Global.vUserUsuario;
        //                    varFECHA_PROCESO = DateTime.Now;

        //                    // INGRESA DOCUMENTOS_CAJA
        //                    for (int i = 0; i < gvFondoFijo.DataRowCount; ++i)
        //                    {
        //                        DataRow row = gvFondoFijo.GetDataRow(i);

        //                        if (row["PROCESAR"] != System.DBNull.Value)
        //                        {
        //                            //Cadena = Cadena.Replace("  ", " ");
        //                            if (row["PROCESAR"].ToString().Replace("  ", "") != "")  //MAXERROR
        //                            {
        //                                if (Convert.ToBoolean(row["PROCESAR"]) == true)  //MAXERROR
        //                                {
        //                                    if (row["FONDO_FIJO"] != null && row["FONDO_FIJO"].ToString() != "")
        //                                    {
        //                                        varSELECCIONADO = Convert.ToBoolean(row["PROCESAR"]);
        //                                        //varITEM
        //                                        varFONDO_FIJO = row["FONDO_FIJO"].ToString();
        //                                        varSUCURSAL = row["SUCURSAL"].ToString();
        //                                        varPERIODO = row["APLICACION"].ToString();
        //                                        varFECHA = Convert.ToDateTime(row["FECHA_FONDO"]);
        //                                        varMONEDA = row["MONEDA"].ToString();
        //                                        varMONTO_LOCAL = Convert.ToDecimal(row["MONTO_LOCAL"]);
        //                                        varMONTO_DOLAR = Convert.ToDecimal(row["MONTO_DOLAR"]);
        //                                        //varREEMBOLSADO = row["REEMBOLSADO"].ToString();
        //                                        varREEMBOLSADO =(row["REEMBOLSADO"].ToString() == "S" ? "SI REEMBOLSADO" : "NO REEMBOLSADO");
        //                                        varRESPONSABLE = "";

        //                                        //Agrega Items al DataTable
        //                                        AgregarFilaGrillaFF();
        //                                    }
        //                                    //*
        //                                }
        //                            }
        //                        }

        //                    }

        //                }

        //                //
        //                //xtraTabControl2.SelectedTabPage = xtraTabPageCargaExactus;
        //                xtraTabControl2.SelectedTabPage = xtraTabPageCargo;
        //                MessageBox.Show("Documentos Seleccionados, Asignar Responsable", "Cargo Fondo Fijo");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }


        //}

        //public void AgregarFilaGrillaFF()
        //{
        //    NumeroItem = NumeroItem + 1;
        //    varITEM = NumeroItem;

        //    DataTable dtTC = gcCargo.DataSource as DataTable;
        //    DataRow newRow = dtTC.NewRow();
        //    newRow["PROCESAR"] = varSELECCIONADO;
        //    newRow["ITEM"] = varITEM;
        //    newRow["FONDO_FIJO"] = varFONDO_FIJO;
        //    newRow["SUCURSAL"] = varSUCURSAL;
        //    newRow["PERIODO"] = varPERIODO;
        //    newRow["FECHA"] = varFECHA;
        //    newRow["MONEDA"] = varMONEDA;
        //    newRow["MONTO_LOCAL"] = varMONTO_LOCAL;
        //    newRow["MONTO_DOLAR"] = varMONTO_DOLAR;
        //    newRow["REEMBOLSADO"] = varREEMBOLSADO;
        //    newRow["RESPONSABLE"] = varRESPONSABLE;            

        //    dtTC.Rows.InsertAt(newRow, 0);
        //}



        //#endregion




        private void chkCargo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCargo.Checked)
            {
                try
                {
                    Int32 j;
                    for (j = 0; j < gvCargo.RowCount; j++)
                    {
                        gvCargo.SetRowCellValue(j, "PROCESAR", true);
                    }

                    gcCargo.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Int32 j;
                    for (j = 0; j < gvCargo.RowCount; j++)
                    {
                        gvCargo.SetRowCellValue(j, "PROCESAR", false);
                    }

                    gcCargo.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnFFcargoQuitar_Click(object sender, EventArgs e)
        {

        }










        //public void Carga_lookUp_Caja()
        //{
        //    DataTable dtCaja = new DataTable();
        //    dtCaja = objCargaLookUpBL.dtListarCuentaBancoBL(Global.vUserBaseDatos);
        //    lookUpCuentaBancoFF.Properties.DataSource = dtCaja;
        //    lookUpCuentaBancoFF.Properties.DisplayMember = "NOMBRE";
        //    lookUpCuentaBancoFF.Properties.ValueMember = "CUENTA_BANCO";
        //    lookUpCuentaBancoFF.EditValue = null;
        //}

        public void Carga_lookUp_CuentaBanco_Hist()
        {
            DataTable dt_cbhist = new DataTable();
            dt_cbhist = objCargaLookUpBL.dtListarCuentaBancoBL(Global.vUserBaseDatos);  //TablasExactusBL.dtObtenerCuentaBancoBL(Global.vUserBaseDatos);
            lookUpCuentaBancoFF_Hist.Properties.DataSource = dt_cbhist;
            lookUpCuentaBancoFF_Hist.Properties.DisplayMember = "NOMBRE";
            lookUpCuentaBancoFF_Hist.Properties.ValueMember = "CUENTA_BANCO";
            lookUpCuentaBancoFF_Hist.EditValue = null;
        }


        //public void ReinciargvFondoFijo()
        //{
        //    chkFF.Checked = false;

        //    if (gvFondoFijo.RowCount > 0)
        //    {
        //        //MessageBox.Show("No existe Informacion a Exportar.", "Archivo-Cargo Fondo Fijo");
        //        //return;
        //        try
        //        {
        //            Int32 j;
        //            for (j = 0; j < gvFondoFijo.RowCount; j++)
        //            {
        //                gvFondoFijo.SetRowCellValue(j, "PROCESAR", false);
        //            }

        //            gcFondoFijo.RefreshDataSource();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //    }
        //}


        //public int ValidarResponsablegvFondoFijo()
        //{
        //    //chkFF.Checked = false;
        //    varNumResponsable = 0;

        //    if (gvCargo.RowCount > 0)
        //    {
        //        //MessageBox.Show("No existe Informacion a Exportar.", "Archivo-Cargo Fondo Fijo");
        //        //return;
        //        try
        //        {
        //            for (int i = 0; i < gvCargo.DataRowCount; ++i)
        //            {
        //                DataRow row = gvCargo.GetDataRow(i);

        //                if ((row["FONDO_FIJO"] != null) && (row["FONDO_FIJO"].ToString() != ""))
        //                {
        //                    if ((row["RESPONSABLE"] != null) && (row["RESPONSABLE"].ToString() != ""))
        //                    {
        //                        //var_RESPONSABLE = row["RESPONSABLE"].ToString();
        //                        varNumResponsable = varNumResponsable + 1;
        //                    }
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }

        //    return varNumResponsable;
        //}


        //MAXMAX  09/09/2022
        //----------------------------------------------------------------------
        #region GENERAR_CARGO_CONTABILIDAD (comunes)
        //----------------------------------------------------------------------
        private void btnCargoActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnValidarDocsCargoFF_Click(object sender, EventArgs e)
        {

        }
        private void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            if (gvCargo.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Generar Cargo Fondo Fijo");
                return;
            }
            else
            {
                if (varAplicacion == "FondoFijo")
                {
                    //GenerarCargoFondoFijo();
                }
                else
                {
                    GenerarCargoEntregaRendir();
                }
            }
        }

        private int ObtenerUltimoCargoGenerado()
        {
            int _ultimo_cargo = 0;
            
            if (varAplicacion == "FondoFijo")
            {

                _ultimo_cargo = ContabilidadBL.ObtenerUltimoFFCargoBL(Global.vUserBaseDatos);
            }
            else
            {
                _ultimo_cargo = ContabilidadBL.ObtenerUltimoERCargoBL(Global.vUserBaseDatos);
            }
            return _ultimo_cargo;
        }
        public void RecargaGrilla_gvCargo()
        {
            //eliminamos registro con RESPONSABLE ASIGNADO
            for (int i = dtCargo.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtCargo.Rows[i];
                if ((dr["RESPONSABLE"] != null) && (dr["RESPONSABLE"].ToString() != ""))
                    dr.Delete();
            }

            //establece el source de la grilla
            gcCargo.DataSource = dtCargo;
            //ConfiguraGridExcel();
            gcCargo.Refresh();
        }

        //private void GenerarCargoFondoFijo()
        //{
        //    try
        //    {
        //        //VALIDAR CAMPO RESPONSABLE

        //        if (ValidarResponsablegvFondoFijo() > 0)
        //        {
        //            //PROCESO GRABA
        //            DialogResult dialogResult = MessageBox.Show("Generar Cargo Fondo Fijo."
        //                                                   + "\nSe procesara solamente los Fondos que tengan Asignado un Responsable"
        //                                                   + "\nEsta seguro de Procesar la informacion?", "Cargo Fondo Fijo", MessageBoxButtons.YesNo);

        //            if (dialogResult == DialogResult.Yes)
        //            {

        //                //NroCargoUltimo = ContabilidadBL.ObtenerUltimoFFCargoBL(Global.vUserBaseDatos);
        //                NroCargoUltimo = ObtenerUltimoCargoGenerado();
        //                NroCargoGenerado = NroCargoUltimo + 1;
        //                NroCargoGeneradoImpresion = NroCargoGenerado.ToString().PadLeft(8, '0');
        //                FecCargoGenerado = Convert.ToDateTime(deFechaCargoProceso.Text);

        //                if (NroCargoGeneradoImpresion == "" || NroCargoGeneradoImpresion == null)
        //                {
        //                    MessageBox.Show("Debe Generar el Cargo.", "Cargo Fondo Fijo");
        //                    return;
        //                }
        //                else
        //                {
        //                    if (varAplicacion == "FondoFijo")
        //                    {

        //                        GrabarCargoEntregaRendir(NroCargoGenerado, FecCargoGenerado);
        //                    }
        //                    else
        //                    {

        //                    }

        //                    txtCargo.Text = NroCargoGeneradoImpresion;
        //                }


        //                //TODO: RECARGAR GRILLA, SIN LOS QUE TENGAN RESPONSABLE
        //                RecargaGrilla_gvCargo();
        //                //TODO: RECARGA GRILLA gvFondoFijo
        //                //Recarga grilla gvFondoFijo();
        //                CargarGillaFondoFijo();
        //                //recarga grilla gvArchivo
        //                //ObtenerArchivoFFCargoV2(dFechaArchIni, dFechaArchFin, _cajas_hist);
        //                CargarGrilla_gvArchivo();
        //                //Actulizar correlativo a mostrar
        //                NroCargoUltimo = ObtenerUltimoCargoGenerado();
        //                txtCargo.Text = (NroCargoUltimo + 1).ToString().PadLeft(8, '0');  //NroCargoUltimo + 1 ;
        //                                                                                  //MAXMAX
        //                MessageBox.Show("Proceso Finalizado. Se ha generado el cargo N°" + NroCargoGeneradoImpresion + " ", "Cargo Fondo Fijo");
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("No existe Informacion a Procesar. Debe haber minimo un Responsable Asignado", "Generar Cargo Fondo Fijo");
        //            return;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void GenerarCargoEntregaRendir()
        {
            try
            {
                //VALIDAR CAMPO RESPONSABLE

                if (ValidarResponsablegvEntregaRendir() > 0)
                {
                    //PROCESO GRABA
                    DialogResult dialogResult = MessageBox.Show("Generar Cargo Entrega Rendir."
                                                            + "\nSe procesara solamente los Fondos que tengan Asignado un Responsable"
                                                            + "\nEsta seguro de Procesar la informacion?", "Cargo Entrega Rendir", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        //NroCargoUltimo = ContabilidadBL.ObtenerUltimoFFCargoBL(Global.vUserBaseDatos);
                        NroCargoUltimo = ObtenerUltimoCargoGenerado();
                        NroCargoGenerado = NroCargoUltimo + 1;
                        NroCargoGeneradoImpresion = NroCargoGenerado.ToString().PadLeft(8, '0');
                        FecCargoGenerado = Convert.ToDateTime(deFechaCargoProceso.Text);

                        if (NroCargoGeneradoImpresion == "" || NroCargoGeneradoImpresion == null)
                        {
                            MessageBox.Show("Debe Generar el Cargo.", "Cargo Entrega Rendir");
                            return;
                        }
                        else
                        {
                            GrabarCargoEntregaRendir(NroCargoGenerado, FecCargoGenerado);
                            txtCargo.Text = NroCargoGeneradoImpresion;
                        }


                        //TODO: RECARGAR GRILLA, SIN LOS QUE TENGAN RESPONSABLE
                        RecargaGrilla_gvCargo();
                        //TODO: RECARGA GRILLA gvFondoFijo
                        //Recarga grilla gvFondoFijo();
                        //CargarGillaFondoFijo();
                        CargarGillaEntregaRendir();
                        //recarga grilla gvArchivo
                        //ObtenerArchivoFFCargoV2(dFechaArchIni, dFechaArchFin, _cajas_hist);
                        CargarGrilla_gvArchivo();
                        //Actulizar correlativo a mostrar
                        NroCargoUltimo = ObtenerUltimoCargoGenerado();
                        txtCargo.Text = (NroCargoUltimo + 1).ToString().PadLeft(8, '0');  //NroCargoUltimo + 1 ;
                                                                                          //MAXMAX
                        MessageBox.Show("Proceso Finalizado. Se ha generado el cargo N°" + NroCargoGeneradoImpresion + " ", "Cargo Entrega Rendir");
                    }

                }
                else
                {
                    MessageBox.Show("No existe Informacion a Procesar. Debe haber minimo un Responsable Asignado", "Generar Cargo Entrega Rendir");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GrabarCargoFondoFijo(int _num_cargo, DateTime _fec_cargo)
        {
            try
            {
                //PROCESO GRABA
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....   ", "Espere por favor.."))
                {
                    //CARGO
                    var_CARGO = _num_cargo;
                    var_FECHA_CARGO = _fec_cargo;
                    var_ITEM = 0;
                    var_FONDO_FIJO = "";
                    //var_FECHA_FONDO = null;
                    var_SUCURSAL = "";
                    var_APLICACION = "";
                    var_MONEDA = "";
                    var_MONTO = 0;
                    var_MONTO_LOCAL = 0;
                    var_MONTO_DOLAR = 0;
                    var_REEMBOLSADO = "";
                    var_RESPONSABLE = "";


                    // INGRESA ITEMS
                    for (int i = 0; i < gvCargo.DataRowCount; ++i)
                    {
                        DataRow row = gvCargo.GetDataRow(i);

                        if ((row["FONDO_FIJO"] != null) && (row["FONDO_FIJO"].ToString() != ""))
                        {
                            if ((row["RESPONSABLE"] != null) && (row["RESPONSABLE"].ToString() != ""))
                            {
                                //var_CARGO = _num_cargo;
                                //var_FECHA_CARGO = _fec_cargo;
                                var_ITEM = Convert.ToInt16(row["ITEM"]);
                                var_FONDO_FIJO = row["FONDO_FIJO"].ToString();
                                var_FECHA_FONDO = Convert.ToDateTime(row["FECHA"]);
                                var_SUCURSAL = row["SUCURSAL"].ToString();
                                var_APLICACION = row["PERIODO"].ToString();
                                var_MONEDA = row["MONEDA"].ToString();
                                if (var_MONEDA == "SOL")
                                {
                                    var_MONTO = Convert.ToDecimal(row["MONTO_LOCAL"]);
                                }
                                else
                                {
                                    var_MONTO = Convert.ToDecimal(row["MONTO_DOLAR"]);
                                }

                                var_MONTO_LOCAL = Convert.ToDecimal(row["MONTO_LOCAL"]);
                                var_MONTO_DOLAR = Convert.ToDecimal(row["MONTO_DOLAR"]);
                                var_REEMBOLSADO = row["REEMBOLSADO"].ToString();
                                var_RESPONSABLE = row["RESPONSABLE"].ToString();

                                ContabilidadBL.dtGrabarFFCargoBL(var_CARGO, var_FECHA_CARGO, var_ITEM, var_FONDO_FIJO,
                                                                 var_FECHA_FONDO, var_SUCURSAL, var_APLICACION, var_MONEDA,
                                                                 var_MONTO, var_MONTO_LOCAL, var_MONTO_DOLAR, var_REEMBOLSADO,
                                                                 var_RESPONSABLE, Global.vUserBaseDatos);

                            }
                        }
                    }

                    // TODO: falta borrar de la grilla los items que ya se generaron cargo
                    // EliminarFondosConResponsableAsignadogvCargo();



                }

                //
                //MessageBox.Show("Proceso Finalizado !!!", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void GrabarCargoEntregaRendir(int _num_cargo, DateTime _fec_cargo)
        {
            try
            {
                //PROCESO GRABA
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....   ", "Espere por favor.."))
                {
                    //CARGO
                    var_CARGO = _num_cargo;
                    var_ITEM = 0;
                    var_FECHA_CARGO = _fec_cargo;
                    var_ENTREGA_RENDIR = "";
                    //var_FECHA_ENTREGA;
                    var_APLICACION = "";
                    var_MONEDA = "";
                    var_MONTO = 0;
                    var_CODIGO = "";
                    var_NOMBRE_PROV = "";
                    var_LIQUIDADO = "";
                    var_USUARIO_LIQUIDACION = "";
                    //var_FECHA_LIQUIDACION;
                    var_RESPONSABLE = "";
                    var_SUCURSAL = "";
                    //var_REEMBOLSADO = "";
                    //var_EMPLEADO = "";
                    //var_PROVEEDOR = "";

                    // INGRESA ITEMS
                    for (int i = 0; i < gvCargo.DataRowCount; ++i)
                    {
                        DataRow row = gvCargo.GetDataRow(i);

                        if ((row["ENTREGA_A_RENDIR"] != null) && (row["ENTREGA_A_RENDIR"].ToString() != ""))
                        {
                            if ((row["RESPONSABLE"] != null) && (row["RESPONSABLE"].ToString() != ""))
                            {
                                //var_CARGO = _num_cargo;
                                var_ITEM = Convert.ToInt16(row["ITEM"]);
                                //var_FECHA_CARGO = _fec_cargo;
                                var_ENTREGA_RENDIR = row["ENTREGA_A_RENDIR"].ToString();
                                var_FECHA_ENTREGA = Convert.ToDateTime(row["FECHA"]);                                
                                var_APLICACION = row["APLICACION"].ToString();
                                var_MONEDA = row["MONEDA"].ToString();
                                var_MONTO = Convert.ToDecimal(row["MONTO"]);
                                var_LIQUIDADO = row["LIQUIDADO"].ToString();
                                var_USUARIO_LIQUIDACION = row["USUARIO_LIQUIDACIO"].ToString(); //MAXMAX
                                //var_USUARIO_LIQUIDACION = row["USUARIOLIQ"].ToString(); //
                                var_FECHA_LIQUIDACION = Convert.ToDateTime(row["FECHA_LIQUIDACION"]);
                                var_CODIGO = row["CODIGO"].ToString();
                                var_NOMBRE_PROV = row["NOMBRE_PROV"].ToString();   // responsable ER
                                var_RESPONSABLE = row["RESPONSABLE"].ToString(); // responsable generar Cargo
                                var_SUCURSAL = row["SUCURSAL"].ToString();

                                ContabilidadBL.dtGrabarERCargo_BL(var_CARGO, var_ITEM, var_FECHA_CARGO, var_ENTREGA_RENDIR,
                                                                 var_FECHA_ENTREGA, var_APLICACION, var_MONEDA,
                                                                 var_MONTO, var_CODIGO, var_NOMBRE_PROV,
                                                                 var_LIQUIDADO, var_USUARIO_LIQUIDACION, var_FECHA_LIQUIDACION,
                                                                 var_RESPONSABLE, var_SUCURSAL, Global.vUserBaseDatos);

                            }
                        }
                    }

                    // TODO: falta borrar de la grilla los items que ya se generaron cargo
                    // EliminarFondosConResponsableAsignadogvCargo();
                }

                //
                //MessageBox.Show("Proceso Finalizado !!!", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //----------------------------------------------------------------------
        #endregion  // GENERAR_CARGO_CONTABILIDAD (comunes)
        //----------------------------------------------------------------------



        //MAXMAX  09/09/2022
        //----------------------------------------------------------------------
        #region GENERAR_ARCHIVO_CARGOS (comunes)
        //----------------------------------------------------------------------

        private void btnActualizarArchivo_Click(object sender, EventArgs e)
        {
            CargarGrilla_gvArchivo();
        }

        private void CargarGrilla_gvArchivo()
        {
            dFechaArchIni = Convert.ToDateTime(deFechaArchivoIni.Text);
            dFechaArchFin = Convert.ToDateTime(deFechaArchivoFin.Text);

            _cajas_hist = this.lookUpCuentaBancoFF_Hist.EditValue.ToString();

            //caja = Global.vUserTienda;
            if (_cajas_hist == null)
            {
                _cajas_hist = "TODOS";   // Global.vUserCaja;
            }

            //ObtenerArchivoFFCargo(dFechaArchIni, dFechaArchFin);
            //ObtenerArchivoFFCargoV2(dFechaArchIni, dFechaArchFin, _cajas_hist);
            if (varAplicacion == "FondoFijo")
            {
                ObtenerArchivoFFCargoV2(dFechaArchIni, dFechaArchFin, _cajas_hist);
            }
            else
            {
                ObtenerArchivoERCargoV2(dFechaArchIni, dFechaArchFin, _cajas_hist);
            }

        }

        private void btnExportarArchivo_Click(object sender, EventArgs e)
        {
            if (gvArchivo.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Archivo-Cargo Fondo Fijo");
                return;
            }
            else
            {
                gcArchivo.ShowPrintPreview();
            }
        }

        private void gvArchivo_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvArchivo.RowCount > 0)
            {
                //FecCargoArchivo = gvArchivo.GetRowCellValue(gvArchivo.FocusedRowHandle, "FECHA_CARGO").ToString();
                FecCargoArchivo = gvArchivo.GetRowCellValue(gvArchivo.FocusedRowHandle, "FECHA_CARGO").ToString();
                NroCargoArchivo = gvArchivo.GetRowCellValue(gvArchivo.FocusedRowHandle, "CARGO").ToString();
                NroCargoArchivoImpresion = NroCargoArchivo.PadLeft(8, '0');
                txtCargoArchivo.Text = NroCargoArchivoImpresion;
                //txtCodigoPais.Text = txtCodigoPais.Text.PadLeft(3, '0');
            }

        }

        private void btnImprimirArchivo_Click(object sender, EventArgs e)
        {
            if (varAplicacion == "FondoFijo")
            {
                //MessageBox.Show("....FondoFijo");
                frmCargoFondoFijoRPT frmCargo = new frmCargoFondoFijoRPT();
                frmCargo._numerocargo = Convert.ToInt16(NroCargoArchivo);   // txtCargoArchivo.Text;
                frmCargo._fechacargo = Convert.ToDateTime(FecCargoArchivo);
                frmCargo.ShowDialog();
            }
            else
            {
                //MessageBox.Show("....EntregaRendir");
                frmCargoEntregaRendirRPT frmCargo = new frmCargoEntregaRendirRPT();
                frmCargo._numerocargo = Convert.ToInt16(NroCargoArchivo);   // txtCargoArchivo.Text;
                frmCargo._fechacargo = Convert.ToDateTime(FecCargoArchivo);
                frmCargo.ShowDialog();
            }
        }


        //----------------------------------------------------------------------
        #endregion  // GENERAR_ARCHIVO_CARGOS (comunes)
        //----------------------------------------------------------------------



        //MAXMAX  09/09/2022
        //----------------------------------------------------------------------
        #region GENERAR_CARGO_FONDO_FIJO
        //----------------------------------------------------------------------

        //ARCHIVO
        public void ObtenerArchivoFFCargoV2(DateTime fs1, DateTime fs2, string caja_hist)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo informacion de Archivo Cargo Fondo Fijo ....", "Espere por favor.."))
            {
                DataTable dtArc = new DataTable();
                dtArc = ContabilidadBL.dtObtieneArchivoFFCargoV2_BL(fs1, fs2, caja_hist, 0, Global.vUserBaseDatos);
                gcArchivo.DataSource = dtArc;
            }

            ConfiguraGrilla(gvArchivo);
            //ConfiguraGrillaFF();
        }

        //----------------------------------------------------------------------
        #endregion    //GENERAR_CARGO_FONDO_FIJO
        //----------------------------------------------------------------------




        //MAXMAX  09/09/2022
        //----------------------------------------------------------------------
        #region GENERAR_CARGO_ENTREGA_RENDIR
        //----------------------------------------------------------------------

        private void chkLiquidado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLiquidado.Checked)
            {
                _liquidado = "S";
            }
            else
            {
                _liquidado = "N";
            }
        }


        public void ObtenerArchivoERCargoV2(DateTime fs1, DateTime fs2, string caja_hist)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo informacion de Archivo Cargo Fondo Fijo ....", "Espere por favor.."))
            {
                DataTable dtArc = new DataTable();
                //dtArc = ContabilidadBL.dtObtieneArchivoFFCargoV2_BL(fs1, fs2, caja_hist, 0, Global.vUserBaseDatos);
                dtArc = ContabilidadBL.dtObtieneArchivoERCargo_BL(fs1, fs2, caja_hist, 0, Global.vUserBaseDatos);
                gcArchivo.DataSource = dtArc;
            }

            ConfiguraGrilla(gvArchivo);
            //ConfiguraGrillaFF();
        }
        public int ValidarResponsablegvEntregaRendir()
        {
            //chkFF.Checked = false;
            varNumResponsable = 0;

            if (gvCargo.RowCount > 0)
            {
                //MessageBox.Show("No existe Informacion a Exportar.", "Archivo-Cargo Fondo Fijo");
                //return;
                try
                {
                    for (int i = 0; i < gvCargo.DataRowCount; ++i)
                    {
                        DataRow row = gvCargo.GetDataRow(i);

                        if ((row["ENTREGA_A_RENDIR"] != null) && (row["ENTREGA_A_RENDIR"].ToString() != ""))
                        {
                            if ((row["RESPONSABLE"] != null) && (row["RESPONSABLE"].ToString() != ""))
                            {
                                //var_RESPONSABLE = row["RESPONSABLE"].ToString();
                                varNumResponsable = varNumResponsable + 1;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return varNumResponsable;
        }

        private void lookUpCuentaBancoER2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateListaER_Click(object sender, EventArgs e)
        {
            //dFechaIni = Convert.ToDateTime(deFechaERIni.Text);  //Convert.ToDateTime(deFechaFondoFijo.Text);
            //dFechaFin = Convert.ToDateTime(deFechaERFin.Text);
            //ObtenerEntregaRendir(dFechaIni, dFechaFin);

            CargarGillaEntregaRendir();
        }

        private void CargarGillaEntregaRendir()
        {
            dFechaIni = Convert.ToDateTime(deFechaERIni.Text);  //Convert.ToDateTime(deFechaFondoFijo.Text);
            dFechaFin = Convert.ToDateTime(deFechaERFin.Text);
            //_liquidado = null;
            _cajas = this.lookUpCuentaBancoER2.EditValue.ToString();

            //caja = Global.vUserTienda;
            if (_cajas == null)
            {
                _cajas = "TODOS";   // Global.vUserCaja;
            }
            // respuesta: "0001, 0002, 0003, 0004, 0005, 0006, 0007, 0008, 0009, 0010, 0011, 0012, 0013, 0014, 0015"
            // "CAJA_CHICA_GER, CAJA_CHICA_AQP, CAJA_CHICA_AQ2, CAJA_CHICA_CAJ, CAJA_CHICA_CHI, CAJA_CHICA_CHN, CAJA_CHICA_HYO, CAJA_CHICA_ICA, CAJA_CHICA_LIN, CAJA_CHICA_LOL, CAJA_CHICA_MAN, CAJA_CHICA_PIE, CAJA_CHICA_PIU, CAJA_CHICA_SBO, CAJA_CHICA_SLU, CAJA_CHICA_SMP, CAJA_CHICA_SUR, CAJA_CHICA_DOLAR, CAJA_CHICA_PRI"

            //chkCargo

            //ObtenerFondoFijoCargo(dFechaIni, dFechaFin);
            //ObtenerFondoFijoCargoV2(dFechaIni, dFechaFin, _cajas);
            ObtenerEntregaRendirV2(dFechaIni, dFechaFin, _cajas, _liquidado);
            //ReinciargvFondoFijo();
            ReinciargvEntregaRendir();
        }


        public void ReinciargvEntregaRendir()
        {
            chkER.Checked = false;

            if (gvEntregaRendir.RowCount > 0)
            {
                //MessageBox.Show("No existe Informacion a Exportar.", "Archivo-Cargo Fondo Fijo");
                //return;
                try
                {
                    Int32 j;
                    for (j = 0; j < gvEntregaRendir.RowCount; j++)
                    {
                        gvEntregaRendir.SetRowCellValue(j, "PROCESAR", false);
                    }

                    gcEntregaRendir.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        public void ObtenerEntregaRendirV2(DateTime fs1, DateTime fs2, string cajas, string liquidado)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion Entregas a Rendir ....", "Espere por favor.."))
            {
                DataTable dtER = new DataTable();
                //dtER = ContabilidadBL.dtObtieneEntregaRendirBL(fs1, fs2, cajas, Global.vUserBaseDatos);
                dtER = ContabilidadBL.dtObtieneEntregaRendirV2_BL(fs1, fs2, cajas, liquidado, Global.vUserBaseDatos);
                gcEntregaRendir.DataSource = dtER;
            }

            //ConfiguraGrilla(gvEntregaRendir);
            ConfiguraGrillaER();
        }



        private void gvEntregaRendir_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

        }
        public void ConfiguraGrillaER()
        {
            //gv.OptionsView.ShowGroupPanel = false;
            //gv.OptionsView.ShowIndicator = false;
            //gv.OptionsBehavior.Editable = false;
            //gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            //gv.OptionsView.ColumnAutoWidth = false;
            //gv.BestFitColumns();
            //gv.Appearance.Row.Font = new System.Drawing.Font(gv.Appearance.Row.Font, FontStyle.Bold);
            //gv.Appearance.Row.Options.UseFont = true;

            //System.Drawing.Font fnt = new System.Drawing.Font(gv.Appearance.Row.Font.Name, 7);
            //gv.Appearance.HeaderPanel.Font = fnt;
            //gv.Appearance.Row.Font = fnt;

            //agrego checkbox            
            gvEntregaRendir.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvEntregaRendir_CustomRowCellEdit);
            RepositoryItemCheckEdit repositoryCheckEdit1 = gcEntregaRendir.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            repositoryCheckEdit1.Name = "CheckGenerar";
            repositoryCheckEdit1.ValueChecked = "True";
            repositoryCheckEdit1.ValueUnchecked = "False";
            gvEntregaRendir.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;

            //Font fnt = new Font(gvFactura.Appearance.Row.Font.Name, 7);
            //gvFactura.Appearance.HeaderPanel.Font = fnt;
            //gvFactura.Appearance.Row.Font = fnt;
            //gvFactura.Appearance.Row.Options.UseFont = true;
            //gvFactura.OptionsView.ShowGroupPanel = false;
            //gvFactura.OptionsView.ShowIndicator = false;
            //gvFactura.OptionsBehavior.Editable = false;
            //gvFactura.OptionsSelection.EnableAppearanceFocusedCell = false;

            gvEntregaRendir.OptionsView.ColumnAutoWidth = false;
            gvEntregaRendir.BestFitColumns();
            //gvFactura.OptionsView.ColumnAutoWidth = true;
            //Font fnt = new Font(gvFactura.Appearance.Row.Font.Name, 7);
            System.Drawing.Font fnt = new System.Drawing.Font(gvEntregaRendir.Appearance.Row.Font.Name, 7);
            gvEntregaRendir.Appearance.HeaderPanel.Font = fnt;
            gvEntregaRendir.Appearance.Row.Font = fnt;
            gvEntregaRendir.Appearance.Row.Options.UseFont = true;
            gvEntregaRendir.OptionsView.ShowGroupPanel = false;
            gvEntregaRendir.OptionsView.ShowIndicator = false;
            gvEntregaRendir.OptionsBehavior.Editable = true;  //false;
            gvEntregaRendir.OptionsSelection.EnableAppearanceFocusedCell = false;

            //formateo
            gvEntregaRendir.Columns["NOMBRE_PROV"].Width = 170; //RESPONSABLE
            //gvEntregaRendir.Columns["TIPO_CAMBIO_DOLAR"].Caption = "T.C";
            //gvEntregaRendir.Columns["TIPO_CAMBIO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvEntregaRendir.Columns["TIPO_CAMBIO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";

            gvEntregaRendir.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEntregaRendir.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvEntregaRendir.Columns["SALDO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvEntregaRendir.Columns["SALDO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvEntregaRendir.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvEntregaRendir.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvEntregaRendir.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvEntregaRendir.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvEntregaRendir.Columns["TOTAL_CREDITOS"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvEntregaRendir.Columns["TOTAL_CREDITOS"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvEntregaRendir.Columns["TOTAL_DEBITOS"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvEntregaRendir.Columns["TOTAL_DEBITOS"].DisplayFormat.FormatString = "##,###,###,##0.00";
        }



        private void btnValidarDocsCargoER_Click(object sender, EventArgs e)
        {

        }

        private void btnERcargoAgregar_Click(object sender, EventArgs e)
        {
            //inicializa grilla Cargo
            //CargaGrillaVaciaCargos();
            //carga grilla
            //CargaFondoFijo2Cargo(varAplicacionTipo);
            CargaEntregaRendir2Cargo(varAplicacionTipo);  // varAplicacionTipo = "ER", "FF"
        }

        private void btnExportarXlsER2_Click(object sender, EventArgs e)
        {
            if (gvEntregaRendir.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Entrega a Rendir");
                return;
            }
            else
            {
                gcEntregaRendir.ShowPrintPreview();
            }
        }



        private void CargaEntregaRendir2Cargo(string _app_tipo_operacion)
        {
            if (gvEntregaRendir.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Cargo Entrega a Rendir " + varAplicacionDescripcion + " ");
                return;
            }
            if (ExisteItemSeleccionadoER() == false)
            {
                MessageBox.Show("Debe seleccionar uno o mas Documentos.", "Cargo Entrega a Rendir " + varAplicacionDescripcion + " ");
                return;
            }
            else
            {
                try
                {
                    //PROCESO GRABA
                    DialogResult dialogResult = MessageBox.Show("Cargo " + varAplicacionDescripcion + " "
                                                           + "\n"
                                                           + "\nEsta seguro de Procesar la informacion?", "Cargo Entrega a Rendir " + varAplicacionDescripcion + " ", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Cargo Entrega a Rendir " + varAplicacionDescripcion + " ", "Espere por favor.."))
                        {
                            //varPROCESAR = "";
                            varNUM_DOCUMENTO = "";
                            //varFECHA;
                            varTIPO = "";
                            varDOCUMENTO = "";
                            varEMPLEADO = "";
                            varPROVEEDOR = "";
                            varNOMBRE_PROV = "";
                            varAPLICACION = "";
                            varMONEDA = "";
                            varMONTO = 0;
                            varSALDO_LOCAL = 0;
                            varSALDO_DOLAR = 0;
                            varASIENTO = "";
                            //varFONDO_FIJO = "";
                            varENTREGA_RENDIR = "";
                            varITEM = 0;
                            varPERIODO = "";
                            varREEMBOLSADO = "";
                            varRESPONSABLE = "";
                            varLIQUIDADO = "";
                            varUSUARIOLIQ = "";
                            varRESPONSABLE = "";
                            varCODIGO = "";

                            varUSUARIO = Global.vUserUsuario;
                            varFECHA_PROCESO = DateTime.Now;

                            NumeroItem = 0;

                            // INGRESA DOCUMENTOS_CAJA
                            for (int i = 0; i < gvEntregaRendir.DataRowCount; ++i)
                            {
                                DataRow row = gvEntregaRendir.GetDataRow(i);

                                if (row["PROCESAR"] != System.DBNull.Value)
                                {
                                    //Cadena = Cadena.Replace("  ", " ");
                                    if (row["PROCESAR"].ToString().Replace("  ", "") != "")  //MAXERROR
                                    {
                                        if (Convert.ToBoolean(row["PROCESAR"]) == true)  //MAXERROR
                                        {
                                            if (row["ENTREGA_A_RENDIR"] != null && row["ENTREGA_A_RENDIR"].ToString() != "")
                                            {
                                                varSELECCIONADO = Convert.ToBoolean(row["PROCESAR"]);
                                                //varITEM
                                                varENTREGA_RENDIR = row["ENTREGA_A_RENDIR"].ToString();
                                                varFECHA = Convert.ToDateTime(row["FECHA_ENTREGA"]);
                                                varMONEDA = row["MONEDA"].ToString();
                                                varMONTO = Convert.ToDecimal(row["MONTO"]);
                                                varAPLICACION = row["APLICACION"].ToString();
                                                varCODIGO = row["CODIGO"].ToString();
                                                varNOMBRE_PROV = row["NOMBRE_PROV"].ToString();
                                                varRESPONSABLE = "";
                                                varLIQUIDADO = row["LIQUIDADO"].ToString();
                                                varUSUARIOLIQ = row["USUARIO_LIQUIDACIO"].ToString();
                                                varFECHA_LIQUIDACION = Convert.ToDateTime(row["FECHA_LIQUIDACION"]);
                                                varUSUARIO_LIQUIDACIO = row["USUARIO_LIQUIDACIO"].ToString();
                                                //varFONDO_FIJO = row["FONDO_FIJO"].ToString();
                                                //varSUCURSAL = row["SUCURSAL"].ToString();
                                                //varSALDO_LOCAL = Convert.ToDecimal(row["SALDO_LOCAL"]);
                                                //varSALDO_DOLAR = Convert.ToDecimal(row["SALDO_DOLAR"]);
                                                //varREEMBOLSADO = row["REEMBOLSADO"].ToString();
                                                //varREEMBOLSADO = (row["LIQUIDADO"].ToString() == "S" ? "SI LIQUIDADO" : "NO LIQUIDADO");
                                                //varEMPLEADO = row["EMPLEADO"].ToString();
                                                //varPROVEEDOR = row["PROVEEDOR"].ToString();
                                                //Agrega Items al DataTable
                                                AgregarFilaGrillaER();
                                            }
                                            //*
                                        }
                                    }
                                }

                            }

                        }

                        //
                        //xtraTabControl2.SelectedTabPage = xtraTabPageCargaExactus;
                        xtraTabControl2.SelectedTabPage = xtraTabPageCargo;
                        MessageBox.Show("Documentos Seleccionados, Asignar Responsable", "Cargo Entrega a Rendir");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        public void AgregarFilaGrillaER()
        {
            NumeroItem = NumeroItem + 1;
            varITEM = NumeroItem;

            DataTable dtTC = gcCargo.DataSource as DataTable;
            DataRow newRow = dtTC.NewRow();

            newRow["PROCESAR"] = varSELECCIONADO;
            newRow["ITEM"] = varITEM;
            newRow["ENTREGA_A_RENDIR"] = varENTREGA_RENDIR;
            newRow["FECHA"] = varFECHA;
            newRow["MONEDA"] = varMONEDA;
            newRow["MONTO"] = varMONTO;
            newRow["APLICACION"] = varAPLICACION;
            newRow["CODIGO"] = varCODIGO;
            newRow["NOMBRE_PROV"] = varNOMBRE_PROV;
            newRow["RESPONSABLE"] = varRESPONSABLE;
            newRow["LIQUIDADO"] = varLIQUIDADO;
            newRow["USUARIOLIQ"] = varUSUARIOLIQ;
            newRow["SUCURSAL"] = varSUCURSAL;
            newRow["USUARIO_LIQUIDACIO"] = varUSUARIO_LIQUIDACIO;
            newRow["FECHA_LIQUIDACION"] = varFECHA_LIQUIDACION;
            dtTC.Rows.InsertAt(newRow, 0);


            /*
            newRow["PROCESAR"] = varSELECCIONADO;
            newRow["ITEM"] = varITEM;
            //newRow["FONDO_FIJO"] = varFONDO_FIJO;
            newRow["ENTREGA_A_RENDIR"] = varENTREGA_RENDIR;
            //newRow["SUCURSAL"] = varSUCURSAL;
            newRow["APLICACION"] = varAPLICACION;
            newRow["FECHA"] = varFECHA;
            newRow["MONEDA"] = varMONEDA;
            newRow["MONTO"] = varMONTO;

            newRow["LIQUIDADO"] = varLIQUIDADO;
            newRow["USUARIOLIQ"] = varUSUARIOLIQ;

            //newRow["SALDO_LOCAL"] = varMONTO_LOCAL;
            //newRow["SALDO_DOLAR"] = varMONTO_DOLAR;
            //newRow["REEMBOLSADO"] = varREEMBOLSADO;
            //newRow["EMPLEADO"] = varEMPLEADO;
            //newRow["PROVEEDOR"] = varPROVEEDOR;
            newRow["CODIGO"] = varCODIGO;
            newRow["NOMBRE_PROV"] = varNOMBRE_PROV;
            newRow["RESPONSABLE"] = varRESPONSABLE;
            dtTC.Rows.InsertAt(newRow, 0);
            */
        }

        public bool ExisteItemSeleccionadoER()
        {

            bool varExiste = false;

            try
            {
                Int32 j;
                for (j = 0; j < gvEntregaRendir.RowCount; j++)
                {
                    if (gvEntregaRendir.GetRowCellValue(j, "PROCESAR") != System.DBNull.Value)
                    {
                        if (gvEntregaRendir.GetRowCellValue(j, "PROCESAR").ToString().Replace("  ", "") != "")  //MAXERROR
                        {
                            if (Convert.ToBoolean(gvEntregaRendir.GetRowCellValue(j, "PROCESAR")) == true)
                            {
                                varExiste = true;
                                return varExiste;
                            }
                        }
                    }
                }

                //gcFondoFijo.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return varExiste;

        }


        //private void btnCargoExportar_Click_1(object sender, EventArgs e)
        //{
        //    if (gvCargo.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Exportar.", "Cargo Fondo Fijo");
        //        return;
        //    }
        //    else
        //    {
        //        gcCargo.ShowPrintPreview();
        //    }
        //}
        private void btnCargoExportar_Click(object sender, EventArgs e)
        {
            if (gvCargo.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Cargo Fondo Fijo");
                return;
            }
            else
            {
                gcCargo.ShowPrintPreview();
            }
        }

        private void btnCargoGeneradoImprimir_Click(object sender, EventArgs e)
        {
            //txtCargo
            //NroCargoArchivo = gvArchivo.GetRowCellValue(gvArchivo.FocusedRowHandle, "CARGO").ToString();
            //NroCargoArchivoImpresion = NroCargoArchivo.PadLeft(8, '0');
            //txtCargoArchivo.Text = NroCargoArchivoImpresion;

            if (txtCargo.Text == "" || txtCargo.Text == null)
            {
                MessageBox.Show("Primero debe Generar el Cargo.", "Cargo Fondo Fijos");
                return;
            }
            else
            {
                frmCargoFondoFijoRPT frmCargo = new frmCargoFondoFijoRPT();
                frmCargo._numerocargo = Convert.ToInt16(txtCargo.Text);      //Convert.ToInt16(NroCargoGenerado);   // txtCargoArchivo.Text;
                frmCargo._fechacargo = Convert.ToDateTime(deFechaCargoProceso.Text);  //Convert.ToDateTime(FecCargoGenerado);
                frmCargo.ShowDialog();
            }
        }

        //private void btnCargoGeneradoImprimir_Click(object sender, EventArgs e)
        //{
        //    //txtCargo
        //    //NroCargoArchivo = gvArchivo.GetRowCellValue(gvArchivo.FocusedRowHandle, "CARGO").ToString();
        //    //NroCargoArchivoImpresion = NroCargoArchivo.PadLeft(8, '0');
        //    //txtCargoArchivo.Text = NroCargoArchivoImpresion;

        //    if (txtCargo.Text == "" || txtCargo.Text == null)
        //    {
        //        MessageBox.Show("Primero debe Generar el Cargo.", "Cargo Fondo Fijos");
        //        return;
        //    }
        //    else
        //    {
        //        frmCargoFondoFijoRPT frmCargo = new frmCargoFondoFijoRPT();
        //        frmCargo._numerocargo = Convert.ToInt16(txtCargo.Text);      //Convert.ToInt16(NroCargoGenerado);   // txtCargoArchivo.Text;
        //        frmCargo._fechacargo = Convert.ToDateTime(deFechaCargoProceso.Text);  //Convert.ToDateTime(FecCargoGenerado);
        //        frmCargo.ShowDialog();
        //    }
        //}

        //----------------------------------------------------------------------
        #endregion   //GENERAR_CARGO_ENTREGA_RENDIR
        //----------------------------------------------------------------------



    }
}
//EOF
