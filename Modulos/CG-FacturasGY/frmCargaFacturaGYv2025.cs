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

using iText;
//using ApssaExactus.LIBCS;
//using ApssaExactus.LIBVB;


namespace ApssaExactus
{
    public partial class frmCargaFacturaGYv2025 : DevExpress.XtraEditors.XtraForm
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


        public string nueva_cadena = string.Empty;
        public Int32 num_random = 0;
        ProcesosBL objprocesoBL = new ProcesosBL();
        DataTable dtXml = new DataTable();      // contiene las rutas de los xml
        DataTable dtFactura = new DataTable();  // facturas generadas de los xml
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

        public Boolean ProcesarTodos = false;

        public string exactus_tipo_documento = string.Empty;
        public string exactus_tipo_referencia = string.Empty;

        public string text_Fecha_Emision = string.Empty;
        public string text_Fecha_Vence = string.Empty;
        DateTime? tmp_Fecha_Vence = null;               // add
        DateTime? tmp_Fecha_Emision = null;               // add
        public string strFechaVencimiento = string.Empty;
        public Int16 tmp_Dias = 0;


        //linea
        public string strXmlItem001 = string.Empty;
        public string item001 = string.Empty;
        public string strXmlItem002 = string.Empty;
        public string item002 = string.Empty;
        public string strXmlItem003 = string.Empty;
        public string item003 = string.Empty;
        public string strXmlItem004 = string.Empty;
        public string item004 = string.Empty;
        public string strXmlItem005 = string.Empty;
        public string item005 = string.Empty;
        public string strXmlItem006 = string.Empty;
        public string item006 = string.Empty;
        public string strXmlItem007 = string.Empty;
        public string item007 = string.Empty;
        public string strXmlItem008 = string.Empty;
        public string item008 = string.Empty;
        public string strXmlItem009 = string.Empty;
        public string item009 = string.Empty;
        public string strXmlItem010 = string.Empty;
        public string item010 = string.Empty;
        public string strXmlItem011 = string.Empty;
        public string item011 = string.Empty;
        public string strXmlItem012 = string.Empty;
        public string item012 = string.Empty;
        public string strXmlItem013 = string.Empty;
        public string item013 = string.Empty;
        public string strXmlItem014 = string.Empty;
        public string item014 = string.Empty;
        public string strXmlItem015 = string.Empty;
        public string item015 = string.Empty;
        public string strXmlItem016 = string.Empty;
        public string item016 = string.Empty;
        public string strXmlItem017 = string.Empty;
        public string item017 = string.Empty;
        public string strXmlItem018 = string.Empty;
        public string item018 = string.Empty;
        public string strXmlItem019 = string.Empty;
        public string item019 = string.Empty;
        public string strXmlItem020 = string.Empty;
        public string item020 = string.Empty;
        public string strXmlItem021 = string.Empty;
        public string item021 = string.Empty;
        public string strXmlItem022 = string.Empty;
        public string item022 = string.Empty;
        public string strXmlItem023 = string.Empty;
        public string item023 = string.Empty;
        public string strXmlItem024 = string.Empty;
        public string item024 = string.Empty;
        public string strXmlItem025 = string.Empty;
        public string item025 = string.Empty;

        //DateTime FechaReporte = DateTime.Now;
        //this.dpFechaFin.Text = DateTime.Today.ToString(); 
        //DateTime? someDate = null;
        //DateTime variableName = DateTime.MinValue;

        //XML
        string xml_Proveedor = string.Empty;
        string xml_Tipo = string.Empty;
        string xml_Documento = string.Empty;
        DateTime? xml_Fecha_Doc = null;
        DateTime? xml_Fecha_Rige = null;
        string xml_Aplicacion = string.Empty;
        Decimal xml_Subtotal = 0;
        Decimal xml_Descuento = 0;
        Decimal xml_Impuesto1 = 0;
        Decimal xml_Impuesto2 = 0;
        Decimal xml_Rubro_1 = 0;
        Decimal xml_Rubro_2 = 0;
        Decimal xml_Monto = 0;
        Decimal xml_Saldo = 0;
        string xml_Moneda = string.Empty;
        string xml_Condicion_Pago = string.Empty;
        string xml_Cuenta_Bancaria = string.Empty;
        string xml_Notas = string.Empty;
        string xml_Subtipo = string.Empty;
        string xml_Centro_Costo = string.Empty;
        string xml_Cuenta_Contable = string.Empty;
        DateTime? xml_Fecha_Contable = null;
        string xml_Rubro_1_Doc = string.Empty;
        string xml_Rubro_2_Doc = string.Empty;
        string xml_Rubro_3_Doc = string.Empty;
        string xml_Rubro_4_Doc = string.Empty;
        string xml_Rubro_5_Doc = string.Empty;
        string xml_Rubro_6_Doc = string.Empty;
        string xml_Rubro_7_Doc = string.Empty;
        string xml_Rubro_8_Doc = string.Empty;
        string xml_Rubro_9_Doc = string.Empty;
        string xml_Rubro_10_Doc = string.Empty;
        string xml_Paquete = string.Empty;
        string xml_Tipo_Asiento = string.Empty;
        string xml_Retención = string.Empty;
        string xml_Embarque = string.Empty;
        string xml_Tipo_Referencia = string.Empty;
        string xml_Doc_Referencia = string.Empty;
        string xml_Doc_ReferenciaGR = string.Empty;
        Decimal xml_Base_Impuesto1 = 0;                 // add
        Decimal xml_Base_Impuesto2 = 0;                 // add
        DateTime? xml_Fecha_Vence = null;               // add
        string xml_Usuario = string.Empty;              // add
        string xml_Cargado = string.Empty;              // add

        string xml_Emb_Referencia = string.Empty;       // add
        string xml_Emb_Rubro1 = string.Empty;           // add
        string xml_Emb_Notas = string.Empty;            // add
        string xml_Emb_CondicionPago = string.Empty;    // add
        Decimal xml_Emb_Monto_Local = 0;                // add
        Decimal xml_Emb_Monto_Dolar = 0;                // add
        string xml_Xml_Items = string.Empty;            // add

        //variables
        string var1001 = string.Empty;
        string var1002 = string.Empty;
        string var1003 = string.Empty;
        string var1004 = string.Empty;
        string var1005 = string.Empty;
        string var2001 = string.Empty;
        string var2002 = string.Empty;
        string var2003 = string.Empty;
        string var2004 = string.Empty;
        string var2005 = string.Empty;
        string var3001 = string.Empty;

        //leer PDF
        string stringPdfFile = string.Empty;
        string stringPdfOutput = string.Empty;


        DataSet ds = new DataSet();

        //public frmCargaFacturaGYv2025()
        //{
        //    InitializeComponent();
        //}

        public frmCargaFacturaGYv2025(string _base, string _user)
        {
            try
            {
                InitializeComponent();
                _base_datos = _base;    // txtBaseDatos.Text
                _usuario = _user;       // txtUsuario.Text;
                //_password = _pass;      // txtPassword.Text;
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmCargaFacturaGYv2025 m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frmCargaFacturaGYv2025 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCargaFacturaGYv2025(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmCargaFacturaGYv2024_Load(object sender, EventArgs e)
        {

            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------  

            this.dpFechaProceso.Text = DateTime.Today.ToString();
            CargaGrillaVacia();
            cTabXls = "Carga";
            chkFacturas.CheckState = CheckState.Unchecked;
        }

        #region CARGA_ENTORNO_VARIABLES
        public void ObtenerusuarioActual()
        {
            cUsuarioActual = TesoreriaBL.ObtenerUsuarioActualExactus_BL(Global.vUserBaseDatos);

        }
        public void AccederEntornoReportesApssa(string base_datos, string usuario)
        {
            try
            {
                if (LoginBL.DBAutenticarUsuarioSinClave(usuario, base_datos))
                {
                    Global.vUserUsuario = usuario;
                    Global.vUserBaseDatos = base_datos;
                    this.DialogResult = DialogResult.OK;

                    //-----------------------------------------------------------------------
                    // CARGA CONFIGURACION INICIAL / SETTING
                    //-----------------------------------------------------------------------
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
                        txtBaseDatos.Text = Global.vUserBaseDatos;

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





        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            string xml_Cabecera = string.Empty;
            string xMonto = string.Empty;
            string xImpuesto = string.Empty;
            string xTotal = string.Empty;
            string xCondicionPago = string.Empty;
            string[] files = null;
            //string[] filesPdf = null;
            string filePdf = string.Empty;

            DataTable dtXmlPath = new DataTable();
            dtXmlPath.Columns.Add("VERSION"); //agrego nueva columna
            dtXmlPath.Columns.Add("FECHA"); //agrego nueva columna
            dtXmlPath.Columns.Add("DOCUMENTO"); //agrego nueva columna
            dtXmlPath.Columns.Add("MONTO"); //agrego nueva columna
            dtXmlPath.Columns.Add("IMPUESTO"); //agrego nueva columna
            dtXmlPath.Columns.Add("TOTAL"); //agrego nueva columna
            dtXmlPath.Columns.Add("VCMTO"); //agrego nueva columna MAXMAX
            dtXmlPath.Columns.Add("DIAS"); //agrego nueva columna MAXMAX
            dtXmlPath.Columns.Add("CONDPAGO"); //agrego nueva columna
            dtXmlPath.Columns.Add("ARCHIVO_PDF"); //agrego nueva columna

            FolderBrowserDialog d = new FolderBrowserDialog();
            DialogResult response = d.ShowDialog();
            if (response == DialogResult.OK)
            {
                files = Directory.GetFiles(d.SelectedPath, "*.xml");

                foreach (string file in files)
                {
                    DataRow newRow2 = dtXmlPath.NewRow();
                    newRow2["DOCUMENTO"] = file;
                    xml_Cabecera = CargaTabla_dtXmlPath(file);
                    //xml_Proveedor = ExtraeCadenaEnXML21("<cac:PartyIdentification>", "</cac:PartyIdentification>", strXml);
                    //xml_Proveedor = xml_Proveedor.Replace("<cbc:ID>", "");  // "<cbc:ID> 20100012856 </cbc:ID>";
                    //xml_Proveedor = xml_Proveedor.Replace("</cbc:ID>", "");  // "<cbc:ID> 20100012856 </cbc:ID>";
                    newRow2["VERSION"] = ExtraeCadenaEnXML21("<cbc:UBLVersionID>", "</cbc:UBLVersionID>", xml_Cabecera);
                    //newRow2["FECHA"] = ExtraerValorEnXml_OK(xml_Cabecera, "/Prueba", "IssueDate");
                    text_Fecha_Emision = ExtraerValorEnXml_OK(xml_Cabecera, "/Prueba", "IssueDate");  //MAXMAX
                    tmp_Fecha_Emision = Convert.ToDateTime(text_Fecha_Emision); //MAXMAX
                    newRow2["FECHA"] = text_Fecha_Emision;
                    xImpuesto = ExtraerValorEnXml_OK(xml_Cabecera, "/Prueba/TaxTotal", "TaxAmount");
                    xTotal = ExtraerValorEnXml_OK(xml_Cabecera, "/Prueba/LegalMonetaryTotal", "PayableAmount");
                    xMonto = (Convert.ToDecimal(xTotal) - Convert.ToDecimal(xImpuesto)).ToString();
                    filePdf = ExisteArchivoPDF(file);     //file.Replace("xml", "pdf");

                    text_Fecha_Vence = ExtraeCadenaEnXML21("<cbc:PaymentDueDate>", "</cbc:PaymentDueDate>", xml_Cabecera); //MAXMAX
                    tmp_Fecha_Vence = Convert.ToDateTime(text_Fecha_Vence); //MAXMAX
                                                                            
                    DateTime fechaUno = Convert.ToDateTime(text_Fecha_Emision);
                    DateTime fechaDos = Convert.ToDateTime(text_Fecha_Vence);
                    TimeSpan difFechas = fechaDos - fechaUno;
                    Int32 nDIas = difFechas.Days;
                    tmp_Dias = Convert.ToInt16(nDIas);
                    //xCondicionPago = BuscarCondicioPagoEnPDF(filePdf);  //MAXMAX
                    xCondicionPago = DeterminaCondicionPago(tmp_Dias);
                    newRow2["MONTO"] = xMonto;
                    newRow2["IMPUESTO"] = xImpuesto;
                    newRow2["TOTAL"] = xTotal;
                    newRow2["VCMTO"] = text_Fecha_Vence;
                    newRow2["DIAS"] = tmp_Dias;
                    newRow2["CONDPAGO"] = xCondicionPago;
                    newRow2["ARCHIVO_PDF"] = filePdf;
                    dtXmlPath.Rows.InsertAt(newRow2, 0);
                }

            }

            gcXmlPath.DataSource = dtXmlPath;
            ConfiguraGridFacturaXmlPath();
            MessageBox.Show("Se cargó todos los archivos XML de la carpeta indicada.");

        }


        public string DeterminaCondicionPago(Int16 _ndias)
        {
            string condicPago = "";

            //string dias = "45";   // diasPDF.Substring(0, 2);

            int s = _ndias;  // Convert.ToInt32(dias);

            switch (s)
            {
                case 0:
                    {
                        condicPago = "0";
                        break;
                    }
                case 7:
                    {
                        condicPago = "F07D";
                        break;
                    }
                case 15:
                    {
                        condicPago = "F15D";
                        break;
                    }
                case 30:
                    {
                        condicPago = "F30D";
                        break;
                    }
                case 45:
                    {
                        condicPago = "F45D";
                        break;
                    }

                case 60:
                    {
                        condicPago = "F60D";
                        break;
                    }
                case 90:
                    {
                        condicPago = "F90D";
                        break;
                    }
                case 120:
                    {
                        condicPago = "F120D";
                        break;
                    }
                case 180:
                    {
                        condicPago = "F180D";
                        break;
                    }
                default:
                    {
                        condicPago = "F30D";        //
                        break;
                    }
            }

            return condicPago;
        }

        public string ExisteArchivoPDF(string file_xml)
        {
            string ArchivoPdfEnCarpeta = "";

            if (File.Exists(file_xml.Replace("xml", "pdf")))
            {
                ArchivoPdfEnCarpeta = file_xml.Replace("xml", "pdf");
            }
            else
            {
                ArchivoPdfEnCarpeta = "";
            }

            return ArchivoPdfEnCarpeta;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //ProcesaXML();
            ProcesaXML21();
            BuscarEmbarque();

        }


        public void BuscarEmbarque()
        {

        }


        #region PROCESA_XML
        public string CargaTabla_dtXmlPath(string file_xml)
        {
            string xml_proceso_carga = string.Empty;
            string xml_cabecera = string.Empty;

            InicializaVariablesXml();

            doc.Load(file_xml);
            xml_proceso_carga = doc.DocumentElement.OuterXml;

            // extrae subcadena condatos fecha, montos
            xml_cabecera = ExtraeStringCabecera_OK("</ext:UBLExtensions>", "</cac:LegalMonetaryTotal>", xml_proceso_carga);
            //MessageBox.Show(xml_cabecera);
            return xml_cabecera;
        }

        public string ExtraeStringCabecera_OK(string cadena_item_ini, string cadena_item_fin, string cadena_entrada)
        {
            string cadenaTexto = "Esto es una prueba";
            int posi1 = cadenaTexto.IndexOf("una");

            string cCadenaInput = cadena_entrada;
            string cCadenaOutput = string.Empty;
            string cCadNodo = string.Empty;

            int ini_item_xx = cCadenaInput.LastIndexOf(cadena_item_ini);
            int ini_item = cCadenaInput.IndexOf(cadena_item_ini);  // okok 23112021     + 1
            int fin_item = cCadenaInput.LastIndexOf(cadena_item_fin);
            int lon_item_ini = cadena_item_ini.Length;
            int lon_item_fin = cadena_item_fin.Length;

            int mx_ini_cad = ini_item + lon_item_ini;
            int mx_fin_cad = fin_item - ini_item + 5;

            //cCadNodo = cCadenaInput.Substring(ini_item + lon_item_ini, fin_item - ini_item + lon_item_fin);
            //cCadNodo = cCadenaInput.Substring(ini_item + lon_item_ini, (fin_item - ini_item + 5));   // OKOK
            cCadNodo = cCadenaInput.Substring(mx_ini_cad, mx_fin_cad);   // okok 23112021
            cCadenaOutput = cCadNodo;

            return cCadenaOutput;
        }


        public void ProcesaXML21()
        {
            //procesa facturas
            int[] seleccionados;
            seleccionados = gvXmlPath.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivos XML 2.1 ....", "Espere por favor.."))
                {
                    DataRow fila_xml;

                    foreach (int row in seleccionados)
                    {
                        fila_xml = gvXmlPath.GetDataRow(row);

                        strRutaXml = Convert.ToString(fila_xml["DOCUMENTO"].ToString());
                        strCondicionPagoPDF = Convert.ToString(fila_xml["CONDPAGO"].ToString());
                        strFechaVencimiento = Convert.ToString(fila_xml["VCMTO"].ToString());
                        ProcesaXml21(strRutaXml, strCondicionPagoPDF, strFechaVencimiento);

                        //MessageBox.Show("Documento : "+Convert.ToString(fila_gvaudi["DOCUMENTO"].ToString())+" Fecha : "+Convert.ToString(fila_gvaudi["FECHA"].ToString()));
                    }
                }

                MessageBox.Show("Se proceso todos los archivos XML", "Generar Archivo de Carga GY");

                xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Generar Archivo de Carga GY");
            }

        }


        public string ObtieneTipoDocumento21(string cad_ent)
        {
            exactus_tipo_documento = "";

            switch (cad_ent)
            {
                case "01":
                    exactus_tipo_documento = "FAC";
                    break;
                case "03":
                    exactus_tipo_documento = "BOL";
                    break;
                case "07":
                    exactus_tipo_documento = "N/C";
                    break;
                case "08":
                    exactus_tipo_documento = "N/D";
                    break;
                case "09":
                    exactus_tipo_documento = "GR";
                    break;
                case "12":
                    exactus_tipo_documento = "";
                    break;
                case "31":
                    exactus_tipo_documento = "";
                    break;
                default:
                    exactus_tipo_documento = "";
                    break;
            }
            /*  A.	Catálogo No. 01: Código de Tipo de documento 
                01	FACTURA
                03	BOLETA DE VENTA                               
                07	NOTA DE CREDITO                               
                08  NOTA DE DEBITO                               
                09  GUIA DE REMISIÓN REMITENTE 
                12  TICKET DE MAQUINA REGISTRADORA
                31	GUIA DE REMISIÓN TRANSPORTISTA                              

            */
            return exactus_tipo_documento;
        }

        public void ProcesaXml21(string arhivo_xml, string condic_pago_pdf, string fec_vcmto)
        {
            InicializaVariablesXml();

            doc.Load(arhivo_xml);
            strXml = doc.DocumentElement.OuterXml;
            txtXML_Contenido.Text = strXml;

            xml_Proveedor = ExtraeCadenaEnXML21("<cac:PartyIdentification>", "</cac:PartyIdentification>", strXml);
            xml_Proveedor = xml_Proveedor.Replace("<cbc:ID>", "");  // "<cbc:ID> 20100012856 </cbc:ID>";
            xml_Proveedor = xml_Proveedor.Replace("</cbc:ID>", "");  // "<cbc:ID> 20100012856 </cbc:ID>";

            //xml_Tipo = ObtieneTipoDocumento(strXml, "cbc:InvoiceTypeCode>");         //ExtraeCadena_OK(strXml, "cbc:InvoiceTypeCode>");
            //Console.WriteLine("En un \"lugar\" de la mancha...");
            //xml_Tipo = ExtraeCadenaEnXML21("Tipo de Operacion\">", "</cbc:InvoiceTypeCode>", strXml).Replace(">", "");
            //xml_Tipo = ObtieneTipoDocumento21(ExtraeCadenaEnXML21("Tipo de Operacion\">", "</cbc:InvoiceTypeCode>", strXml).Replace(">", ""));
            ////xml_Tipo = ObtieneTipoDocumento21(ExtraeCadenaEnXML21("Tipo de Operacion\">", "</cbc:InvoiceTypeCode>", strXml).Replace(">", ""));
            //MAXMAX2024
            //xml_Tipo = ObtieneTipoDocumento21(ExtraeCadenaEnXML21("Tipo de Operacion", "</cbc:InvoiceTypeCode>", strXml).Replace(">", ""));

            string _tipo_docum_xml = ExtraeCadenaEnXML21("<cbc:InvoiceTypeCode", "</cbc:InvoiceTypeCode>", strXml);
            int _tipo_inicio = _tipo_docum_xml.LastIndexOf(">");
            int _tipo_largo = _tipo_docum_xml.Length;
            //xml_Tipo = ExtraeCadenaEnXML21(">", "</cbc:InvoiceTypeCode>", _tipo_docum_xml);
            string cad_xml_Tipo = _tipo_docum_xml.Substring((_tipo_inicio + 1), (_tipo_largo - (_tipo_inicio + 1)));

            xml_Tipo = GetTipoDocumento(cad_xml_Tipo);

            //xml_Documento = ExtraeNumFac_OK(strXml, "<cbc:ID>", "</cbc:ID>", "FE14");
            xml_Documento = ExtraeCadenaEnXML21("<cbc:ID>", "</cbc:ID>", strXml);

            //xml_Fecha_Doc = Convert.ToDateTime(ExtraeCadena_OK(strXml, "cbc:IssueDate>"));  // OKOK
            string xml_Fecha_Doc_previo = ExtraeCadenaEnXML2021("<cbc:IssueDate>", "</cbc:IssueDate>", strXml);  // okok 23112021            
            xml_Fecha_Doc = Convert.ToDateTime(xml_Fecha_Doc_previo);  // okok 23112021
            xml_Fecha_Rige = Convert.ToDateTime(this.dpFechaProceso.Text);
            //xml_Moneda = ExtraeCadena_OK(strXml, "cbc:DocumentCurrencyCode>");
            // listName = "Currency">USD</cbc:DocumentCurrencyCode 
            xml_Moneda = ExtraeCadenaEnXML21("listName=\"Currency\">", "</cbc:DocumentCurrencyCode>", strXml).Replace(">", "");

            xml_Cuenta_Bancaria = "";
            xml_Notas = "";
            xml_Subtipo = "0";
            xml_Centro_Costo = "00.00.00.00.00";
            xml_Cuenta_Contable = "42.1.2.1.01";
            xml_Fecha_Contable = Convert.ToDateTime(this.dpFechaProceso.Text);
            xml_Rubro_1_Doc = "";
            xml_Rubro_2_Doc = "";
            xml_Rubro_3_Doc = "";
            xml_Rubro_4_Doc = "";
            xml_Rubro_5_Doc = "";
            xml_Rubro_6_Doc = "";
            xml_Rubro_7_Doc = "";
            xml_Rubro_8_Doc = "N";
            xml_Rubro_9_Doc = "";
            xml_Rubro_10_Doc = "";
            xml_Paquete = "CP";
            xml_Tipo_Asiento = "CP";
            xml_Retención = "";

            ////OrdenCompra = ExtraeSubCadena_OK(strXml, "cac:OrderReference>", "cbc:ID>"); // TODO se requiere embarque,  por ahora muestra Orden de Compra 
            ////xml_Tipo_Referencia = ExtraeSubCadena_OK(strXml, "cac:DespatchDocumentReference>", "cbc:DocumentTypeCode>");
            ////xml_Tipo_Referencia = ObtieneTipoReferencia(strXml, "cac:DespatchDocumentReference>", "cbc:DocumentTypeCode>");//ExtraeSubCadena_OK(strXml, "cac:DespatchDocumentReference>", "cbc:DocumentTypeCode>");
            ////xml_Doc_Referencia = ExtraeSubCadena_OK(strXml, "cac:DespatchDocumentReference>", "cbc:ID>");

            // NRO_GUIA (DocumentTypeCode='09')
            ////string varDocRef21 = ExtraeCadenaEnXML21("<cac:DespatchDocumentReference>", "</cac:DespatchDocumentReference>", strXml);
            ////string cadAuxGYXML_000 = "listAgencyName=\"PE:SUNAT\" listName=\"Tipo de Documento\" listURI=\"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01\">";
            ////xml_Doc_Referencia = ExtraeCadenaEnXML21("<cbc:ID>", "</cbc:ID>", varDocRef21);
            ////xml_Tipo_Referencia = ExtraeCadenaEnXML21("<cbc:DocumentTypeCode", "</cbc:DocumentTypeCode>", varDocRef21).Replace(cadAuxGYXML_000, "");

            // NRO_ORDEN_COMPRA
            string varDocRefOC = ExtraeCadenaEnXML21("<tci:AdditionalInformationRequest>", "</tci:AdditionalInformationRequest>", strXml);
            //string cadAuxGYXML_000 = "listAgencyName=\"PE:SUNAT\" listName=\"Tipo de Documento\" listURI=\"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01\">";
            xml_Doc_Referencia = ExtraeCadenaEnXML21("<tci:NroPedido>", "</tci:NroPedido>", varDocRefOC);
            //xml_Tipo_Referencia = ExtraeCadenaEnXML21("<cbc:DocumentTypeCode", "</cbc:DocumentTypeCode>", varDocRefOC).Replace(cadAuxGYXML_000, "");
            xml_Tipo_Referencia = "OC";

            // OBTENER EMBARQUE
            // xml_Embarque = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "EMBARQUE", Global.vUserBaseDatos);    // con Guia Remision 09
            xml_Embarque = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "EMBARQUE_OC", Global.vUserBaseDatos);    // con Orden de Compra
            xml_Doc_ReferenciaGR = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "GUIAREMI_OC", Global.vUserBaseDatos);    // con Orden de Compra

            xml_Condicion_Pago = condic_pago_pdf;   // BuscarCondicioPagoEnPDF("C:\\TEMP\\FACT_GY\\xml\\ultimos\\20100012856-01-F014-0042813-Invoice.pdf");

            xml_Fecha_Vence = Convert.ToDateTime(fec_vcmto); // MAXMAX

            xml_Usuario = Global.vUserUsuario;            // add
            xml_Cargado = "N";                            // add


            ////xml_Emb_Referencia = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "REFERENCIA", Global.vUserBaseDatos);
            ////xml_Emb_Rubro1 = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "RUBRO1", Global.vUserBaseDatos);
            ////xml_Emb_Notas = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "NOTAS", Global.vUserBaseDatos);
            ////string _sol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "SOLES", Global.vUserBaseDatos);
            ////string _dol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "DOLARES", Global.vUserBaseDatos);

            ////Referencia GuiaRemision (RUBRO1)
            //xml_Emb_Referencia = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_ReferenciaGR, "REFERENCIA", Global.vUserBaseDatos);
            //xml_Emb_Rubro1 = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_ReferenciaGR, "RUBRO1", Global.vUserBaseDatos);
            //xml_Emb_Notas = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_ReferenciaGR, "NOTAS", Global.vUserBaseDatos);
            //string _sol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_ReferenciaGR, "SOLES", Global.vUserBaseDatos);
            //string _dol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_ReferenciaGR, "DOLARES", Global.vUserBaseDatos);


            //Referencia EMBARQUE(EMBARQUE)
            xml_Emb_Referencia = xml_Embarque;  // ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_ReferenciaGR, "REFERENCIA", Global.vUserBaseDatos);
            xml_Emb_Rubro1 = ContabilidadBL.ObtieneEmbarqueFacturaGyBL_V2(xml_Emb_Referencia, "RUBRO1", Global.vUserBaseDatos);
            xml_Emb_Notas = ContabilidadBL.ObtieneEmbarqueFacturaGyBL_V2(xml_Emb_Referencia, "NOTAS", Global.vUserBaseDatos);
            string _sol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL_V2(xml_Emb_Referencia, "SOLES", Global.vUserBaseDatos);
            string _dol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL_V2(xml_Emb_Referencia, "DOLARES", Global.vUserBaseDatos);


            if (_sol == "")
            {
                xml_Emb_Monto_Local = 0;
            }
            else
            {
                xml_Emb_Monto_Local = Convert.ToDecimal(_sol);
            }


            if (_dol == "")
            {
                xml_Emb_Monto_Dolar = 0;
            }
            else
            {
                xml_Emb_Monto_Dolar = Convert.ToDecimal(_dol);
            }

            xml_Emb_CondicionPago = "";

            ProcesaXmlTotales(arhivo_xml, strXml);       

        }


        public void ProcesaXmlTotales(string xmlfile, string xmldocument)
        {
            string xMonto = string.Empty;
            string xImpuesto = string.Empty;
            string xTotal = string.Empty;
            string xml_Cabecera = string.Empty;

            XmlDocument doc_aux = new XmlDocument();
            doc_aux.Load(xmlfile);
            //MX2019
            xml_Cabecera = ExtraeStringCabecera_OK("</ext:UBLExtensions>", "</cac:LegalMonetaryTotal>", doc_aux.DocumentElement.OuterXml);
            xImpuesto = ExtraerValorEnXml_OK(xml_Cabecera, "/Prueba/TaxTotal", "TaxAmount");
            xTotal = ExtraerValorEnXml_OK(xml_Cabecera, "/Prueba/LegalMonetaryTotal", "PayableAmount");
            xMonto = (Convert.ToDecimal(xTotal) - Convert.ToDecimal(xImpuesto)).ToString();

            xml_Subtotal = Convert.ToDecimal(xMonto);
            xml_Descuento = 0;
            xml_Impuesto1 = Convert.ToDecimal(xImpuesto);
            xml_Impuesto2 = 0;
            xml_Rubro_1 = 0;
            xml_Rubro_2 = 0;
            xml_Monto = Convert.ToDecimal(xTotal);
            xml_Saldo = Convert.ToDecimal(xTotal);

            xml_Base_Impuesto1 = Convert.ToDecimal(xMonto);
            xml_Base_Impuesto2 = 0;

            ///xml_Aplicacion = " " + xml_Emb_Referencia + " / " + xml_Embarque + " / " + xml_Tipo_Referencia + "/" + xml_Doc_Referencia;      //MAXMAX
            xml_Aplicacion = " " + xml_Embarque + " / " + xml_Tipo_Referencia + "/" + xml_Doc_Referencia;      //MAXMAX

            nueva_cadena = "";
            Item_ProcesaInvoiceLineXml_OK(xmldocument);  //  MAXMAX    

            AgregarFIla();

        }

        public string GetTipoDocumento(string cad_xml)
        {
            exactus_tipo_documento = "";

            switch (cad_xml)
            {
                case "01":
                    exactus_tipo_documento = "FAC";
                    break;
                case "03":
                    exactus_tipo_documento = "BOL";
                    break;
                case "07":
                    exactus_tipo_documento = "N/C";
                    break;
                case "08":
                    exactus_tipo_documento = "N/D";
                    break;
                case "09":
                    exactus_tipo_documento = "GR";
                    break;
                case "12":
                    exactus_tipo_documento = "";
                    break;
                case "31":
                    exactus_tipo_documento = "";
                    break;
                default:
                    exactus_tipo_documento = "XXX";
                    break;
            }
            /*  A.	Catálogo No. 01: Código de Tipo de documento 
                01	FACTURA
                03	BOLETA DE VENTA                               
                07	NOTA DE CREDITO                               
                08  NOTA DE DEBITO                               
                09  GUIA DE REMISIÓN REMITENTE 
                12  TICKET DE MAQUINA REGISTRADORA
                31	GUIA DE REMISIÓN TRANSPORTISTA                              

            */
            return exactus_tipo_documento;
        }

        public string ExtraeCadenaEnXML2021(string cadena_item_ini, string cadena_item_fin, string cadena_entrada)
        {
            string cCadNodo = string.Empty;
            string cCadenaInput = string.Empty;
            string cCadenaOutput = string.Empty;

            cCadenaInput = cadena_entrada;

            //int ini_item = cCadenaInput.IndexOf(cadena_item_ini);
            //int fin_item = cCadenaInput.IndexOf(cadena_item_fin);

            // okok 23112021
            int ini_item = cCadenaInput.IndexOf(cadena_item_ini) ;                // okok 23112021
            int fin_item = cCadenaInput.IndexOf(cadena_item_fin) ;                // okok 23112021   

            int lon_item_ini = cadena_item_ini.Length;
            int lon_item_fin = cadena_item_fin.Length;

            cCadNodo = cCadenaInput.Substring(ini_item, fin_item - ini_item + lon_item_fin);
            cCadenaOutput = cCadNodo;

            //cadena.Replace(" ", "");
            //"Tipo de Operacion\">01</cbc:InvoiceTypeCode>"
            cCadenaOutput = cCadenaOutput.Replace(cadena_item_ini, "");  // quitamos la cad ini
            cCadenaOutput = cCadenaOutput.Replace(cadena_item_fin, "");  // quitamos la cad fin


            return cCadenaOutput;
        }


        public string ExtraeCadenaEnXML21(string cadena_item_ini, string cadena_item_fin, string cadena_entrada)
        {
            string cCadNodo = string.Empty;
            string cCadenaInput = string.Empty;
            string cCadenaOutput = string.Empty;

            cCadenaInput = cadena_entrada;

            //int ini_item = cCadenaInput.IndexOf(cadena_item_ini);
            //int fin_item = cCadenaInput.IndexOf(cadena_item_fin);

            // okok 23112021
            int ini_item = cCadenaInput.IndexOf(cadena_item_ini) ;                // okok 23112021
            int fin_item = cCadenaInput.IndexOf(cadena_item_fin) ;                // okok 23112021   

            int lon_item_ini = cadena_item_ini.Length;
            int lon_item_fin = cadena_item_fin.Length;

            cCadNodo = cCadenaInput.Substring(ini_item, fin_item - ini_item + lon_item_fin);
            cCadenaOutput = cCadNodo;

            //cadena.Replace(" ", "");
            //"Tipo de Operacion\">01</cbc:InvoiceTypeCode>"
            cCadenaOutput = cCadenaOutput.Replace(cadena_item_ini, "");  // quitamos la cad ini
            cCadenaOutput = cCadenaOutput.Replace(cadena_item_fin, "");  // quitamos la cad fin


            return cCadenaOutput;
        }

        public string ObtieneTipoDocumento(string cad_ent, string cad_bus)
        {
            exactus_tipo_documento = "";

            switch (ExtraeCadena_OK(cad_ent, cad_bus))
            {
                case "01":
                    exactus_tipo_documento = "FAC";
                    break;
                case "03":
                    exactus_tipo_documento = "BOL";
                    break;
                case "07":
                    exactus_tipo_documento = "N/C";
                    break;
                case "08":
                    exactus_tipo_documento = "N/D";
                    break;
                case "09":
                    exactus_tipo_documento = "GR";
                    break;
                case "12":
                    exactus_tipo_documento = "";
                    break;
                case "31":
                    exactus_tipo_documento = "";
                    break;
                default:
                    exactus_tipo_documento = "";
                    break;
            }
            /*  A.	Catálogo No. 01: Código de Tipo de documento 
                01	FACTURA
                03	BOLETA DE VENTA                               
                07	NOTA DE CREDITO                               
                08  NOTA DE DEBITO                               
                09  GUIA DE REMISIÓN REMITENTE 
                12  TICKET DE MAQUINA REGISTRADORA
                31	GUIA DE REMISIÓN TRANSPORTISTA                              

            */
            return exactus_tipo_documento;
        }

        public string ObtieneTipoReferencia(string cad_ent, string cad_nod, string cad_bus)
        {

            exactus_tipo_referencia = "";

            switch (ExtraeSubCadena_OK(cad_ent, cad_nod, cad_bus))
            {
                case "01":
                    exactus_tipo_referencia = "FAC";
                    break;
                case "03":
                    exactus_tipo_referencia = "BOL";
                    break;
                case "07":
                    exactus_tipo_referencia = "N/C";
                    break;
                case "08":
                    exactus_tipo_referencia = "N/D";
                    break;
                case "09":
                    exactus_tipo_referencia = "GR";
                    break;
                default:
                    exactus_tipo_referencia = "FAC";
                    break;
            }

            return exactus_tipo_referencia;
        }

        public void Item_ProcesaInvoiceLineXml_OK(string mi_xml)
        {
            //determina numero de items contenido en el xml   2,7515,9967
            //string re = GeneralLibCS.BuscaStringEnString("<cac:InvoiceLine>", strXml);       // devuelve numero que veces que ocurre y las posisiones
            string re = GeneralLibCS.BuscaStringEnString("<cac:InvoiceLine>", mi_xml);         // devuelve numero que veces que ocurre y las posisiones
            int nNumItems = Convert.ToInt32(re.Substring(0, re.IndexOf(",")));                 // numero de items en xml
            string posicion_Items = re.Substring((re.IndexOf(",")) + 1, re.Length - ((re.IndexOf(",")) + 1));   // posiciones de inicio de cada item
            string cadena_aux = string.Empty;

            //inicializa lineas
            //InicializaVariableItemXml();


            // extrae subcadena de InvoiceLine
            strInvoiceLine = ExtraeStringInvoiceLine_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", mi_xml);
            cadena_aux = strInvoiceLine;

            //MessageBox.Show("Cadena xml con Todos los Items: " + nNumItems.ToString() + "\n" + strInvoiceLine, "XML");

            //MAXMAX
            //nueva_cadena = "";

            // procesa item por item
            int j = 0;
            for (j = 0; j <= nNumItems - 1; j++)
            {
                Item_ProcesaItemsXml_OK(cadena_aux, j + 1, posicion_Items);
            }

            //MessageBox.Show("Se Procesaron todos los Item de la Factura " + strRutaXml);
        }

        public void Item_ProcesaItemsXml_OK(string cadena_xml_aux, int num_item, string pos)
        {
            string cadena_item = string.Empty;

            cadena_item = ObtieneStringItemXml_OK(cadena_xml_aux, num_item, pos);

            // procesa item a generar fila
            Item_GeneraFilaItem(cadena_item);

        }

        public void Item_GeneraFilaItem(string cadena_item)
        {
            string cadena_xml = cadena_item;
            string codigo_gy = string.Empty;

            //xml_Subtotal = Convert.ToDecimal(ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine", "LineExtensionAmount"));
            //xml_Descuento = 0;  // Convert.ToDecimal(ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine/AllowanceCharge", "Amount"));
            //xml_Impuesto1 = Convert.ToDecimal(ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine/TaxTotal", "TaxAmount"));
            //xml_Impuesto2 = 0;
            //xml_Rubro_1 = 0;
            //xml_Rubro_2 = 0;
            //xml_Monto = xml_Subtotal + xml_Impuesto1;
            //xml_Saldo = xml_Subtotal + xml_Impuesto1;

            codigo_gy = ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine/Item/SellersItemIdentification", "ID");
            xml_Xml_Items = "SQ COD " +
                             codigo_gy + " " +
                             ObtieneAbrevCodigo_OK(codigo_gy) + "(" +        //"  CA("+  // TODO prefijo por familia
                             ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine", "InvoicedQuantity") +
                             ")   " +
                             xml_Tipo_Referencia + "/" + xml_Doc_Referencia;      // TODO   Ccodigo de guia GR

            //nueva_cadena = nueva_cadena + xml_Xml_Items;    //MAXMAX
            nueva_cadena = nueva_cadena + codigo_gy + "  " +
                                          ObtieneAbrevCodigo_OK(codigo_gy) + " (" +        //"  CA("+  // TODO prefijo por familia
                                          ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine", "InvoicedQuantity") + ")   ";


            //MessageBox.Show("Cadena xml del Item "+"\n" + cadena_item, "XML ITEM");
            //AgregarFIla();

        }


        ////------------------------------------------------------------------------------------------------------------------------

        public void ProcesaInvoiceLineXml_OK()
        {
            //determina numero de items contenido en el xml   2,7515,9967
            string re = GeneralLibCS.BuscaStringEnString("<cac:InvoiceLine>", strXml);       // devuelve numero que veces que ocurre y las posisiones
            int nNumItems = Convert.ToInt32(re.Substring(0, re.IndexOf(",")));               // numero de items en xml
            string posicion_Items = re.Substring((re.IndexOf(",")) + 1, re.Length - ((re.IndexOf(",")) + 1));   // posiciones de inicio de cada item
            string cadena_aux = string.Empty;

            //inicializa lineas
            InicializaVariableItemXml();


            // extrae subcadena de InvoiceLine
            strInvoiceLine = ExtraeStringInvoiceLine_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXml);
            cadena_aux = strInvoiceLine;

            //MessageBox.Show("Cadena xml con Todos los Items: " + nNumItems.ToString() + "\n" + strInvoiceLine, "XML");

            // procesa item por item
            int j = 0;
            for (j = 0; j <= nNumItems - 1; j++)
            {
                ProcesaItemsXml_OK(cadena_aux, j + 1, posicion_Items);
            }

            //MessageBox.Show("Se Procesaron todos los Item de la Factura " + strRutaXml);
        }

        public void ProcesaItemsXml_OK(string cadena_xml_aux, int num_item, string pos)
        {
            string cadena_item = string.Empty;

            cadena_item = ObtieneStringItemXml_OK(cadena_xml_aux, num_item, pos);

            // procesa item a generar fila
            GeneraFilaItem(cadena_item);

        }

        public void GeneraFilaItem(string cadena_item)
        {
            string cadena_xml = cadena_item;
            string codigo_gy = string.Empty;

            xml_Subtotal = Convert.ToDecimal(ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine", "LineExtensionAmount"));
            xml_Descuento = 0;  // Convert.ToDecimal(ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine/AllowanceCharge", "Amount"));
            xml_Impuesto1 = Convert.ToDecimal(ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine/TaxTotal", "TaxAmount"));
            xml_Impuesto2 = 0;
            xml_Rubro_1 = 0;
            xml_Rubro_2 = 0;
            xml_Monto = xml_Subtotal + xml_Impuesto1;
            xml_Saldo = xml_Subtotal + xml_Impuesto1;

            codigo_gy = ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine/Item/SellersItemIdentification", "ID");
            xml_Xml_Items = "SQ COD " +
                             codigo_gy + " " +
                             ObtieneAbrevCodigo_OK(codigo_gy) + "(" +        //"  CA("+  // TODO prefijo por familia
                             ExtraerValorEnXml_OK(cadena_xml, "/Prueba/InvoiceLine", "InvoicedQuantity") +
                             ")   " +
                             xml_Tipo_Referencia + "/" + xml_Doc_Referencia;      // TODO   Ccodigo de guia GR

            //MessageBox.Show("Cadena xml del Item "+"\n" + cadena_item, "XML ITEM");
            AgregarFIla();

        }

        public void AgregarFIla()
        {

            //Asigna cuenta contable DEFAULT
            xml_Cuenta_Contable = "42.1.2.1.01";

            string strItems = null;
            strItems = nueva_cadena;

            if (strItems.Contains("LL") == true)
            {
                xml_Cuenta_Contable = "28.1.1.1.01";
            }
            else if (strItems.Contains("CA") == true)
            {
                xml_Cuenta_Contable = "28.1.1.1.02";
            }
            else if (strItems.Contains("PR") == true)
            {
                xml_Cuenta_Contable = "28.1.1.1.03";
            }

            /*
            28.1.1.1.01  LLANTAS
            28.1.1.1.02 CAMARAS
            28.1.1.1.03 PROTECTORES
            */

            Decimal xml_Diferencia = 0;

            if (xml_Moneda == "SOL")
                xml_Diferencia = xml_Subtotal - xml_Emb_Monto_Local;

            if (xml_Moneda == "USD")
                xml_Diferencia = xml_Subtotal - xml_Emb_Monto_Dolar;


            DataTable dt = gcFactura.DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["PROVEEDOR"] = xml_Proveedor;
            newRow["TIPO"] = xml_Tipo;
            newRow["DOCUMENTO"] = xml_Documento;
            newRow["FECHA_DOC"] = xml_Fecha_Doc;
            newRow["FECHA_RIGE"] = xml_Fecha_Doc;   //xml_Fecha_Rige;
            newRow["APLICACION"] = xml_Aplicacion;
            newRow["SUBTOTAL"] = xml_Subtotal;
            newRow["DESCUENTO"] = xml_Descuento;
            newRow["IMPUESTO1"] = xml_Impuesto1;
            newRow["IMPUESTO2"] = xml_Impuesto2;
            newRow["RUBRO_1"] = xml_Rubro_1;
            newRow["RUBRO_2"] = xml_Rubro_2;
            newRow["MONTO"] = xml_Monto;
            newRow["SALDO"] = xml_Saldo;
            newRow["MONEDA"] = xml_Moneda;
            newRow["CONDICION_PAGO"] = xml_Condicion_Pago;
            newRow["CUENTA_BANCARIA"] = xml_Cuenta_Bancaria;
            newRow["NOTAS"] = xml_Notas;
            newRow["SUBTIPO"] = xml_Subtipo;
            newRow["CENTRO_COSTO"] = xml_Centro_Costo;
            newRow["CUENTA_CONTABLE"] = xml_Cuenta_Contable;
            newRow["FECHA_CONTABLE"] = xml_Fecha_Doc;   //xml_Fecha_Contable;
            newRow["RUBRO_1_DOC"] = xml_Rubro_1_Doc;
            newRow["RUBRO_2_DOC"] = xml_Rubro_2_Doc;
            newRow["RUBRO_3_DOC"] = xml_Rubro_3_Doc;
            newRow["RUBRO_4_DOC"] = xml_Rubro_4_Doc;
            newRow["RUBRO_5_DOC"] = xml_Rubro_5_Doc;
            newRow["RUBRO_6_DOC"] = xml_Rubro_6_Doc;
            newRow["RUBRO_7_DOC"] = xml_Rubro_7_Doc;
            newRow["RUBRO_8_DOC"] = xml_Rubro_8_Doc;
            newRow["RUBRO_9_DOC"] = xml_Rubro_9_Doc;
            newRow["RUBRO_10_DOC"] = xml_Rubro_10_Doc;
            newRow["PAQUETE"] = xml_Paquete;
            newRow["TIPO_ASIENTO"] = xml_Tipo_Asiento;
            newRow["RETENCIÓN"] = xml_Retención;
            newRow["EMBARQUE"] = xml_Embarque;
            newRow["TIPO_REFERENCIA"] = xml_Tipo_Referencia;
            newRow["DOC_REFERENCIA"] = xml_Doc_Referencia;
            newRow["BASE_IMPUESTO1"] = xml_Base_Impuesto1;      // add
            newRow["BASE_IMPUESTO2"] = xml_Base_Impuesto2;      // add
            newRow["FECHA_VENCE"] = xml_Fecha_Vence;        // PENDIENTE
            newRow["USUARIO"] = xml_Usuario;
            newRow["CARGADO"] = xml_Cargado;
            newRow["EMB_REFERENCIA"] = xml_Emb_Referencia;
            newRow["EMB_RUBRO1"] = xml_Emb_Rubro1;
            newRow["EMB_NOTAS"] = xml_Emb_Notas;
            newRow["EMB_CONDICIONPAGO"] = xml_Emb_CondicionPago;
            newRow["EMB_MONTO_LOCAL"] = xml_Emb_Monto_Local;    // add
            newRow["EMB_MONTO_DOLAR"] = xml_Emb_Monto_Dolar;    // add
            newRow["XML_ITEMS"] = nueva_cadena; // xml_Xml_Items;
            newRow["DIFERENCIA"] = xml_Diferencia;  // MAXMAXMAX
            dt.Rows.InsertAt(newRow, 0);
        }




        private void gvXmlPath_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (PrimeraVez == true)
            {
                XmlSeleccionado = string.Empty;
                txtOuter.Text = "";
                PrimeraVez = false;
            }
            else
            {
                XmlSeleccionado = Convert.ToString(gvXmlPath.GetRowCellValue(gvXmlPath.FocusedRowHandle, "DOCUMENTO"));
                //carga xml
                doc.Load(XmlSeleccionado);
                txtOuter.Text = doc.DocumentElement.OuterXml;
                txtXML_Path.Text = XmlSeleccionado;
            }
        }

        private void gvFactura_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (PrimeraVez == true)
            {
                ItemFactSeleccionado = string.Empty;
                txtOuter.Text = "";
                PrimeraVez = false;
            }
            else
            {
                ItemFactSeleccionado = Convert.ToString(gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "DOCUMENTO"));

                //doc_tmp.Load(ItemFactSeleccionado);
                //txtOuter.Text = doc_tmp.DocumentElement.OuterXml;
                //txtXML_Path.Text = ItemFactSeleccionado;
            }
        }

        private void btnXlsExportar_Click(object sender, EventArgs e)
        {
            if (gvXmlPath.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "XML - Facturas GY");
                return;
            }
            else
            {
                gcXmlPath.ShowPrintPreview();
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

        private void gvXml_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "GENERAR?")
            {
                e.RepositoryItem = (sender as GridView).GridControl.RepositoryItems["CheckGenerar"];
            }
        }

        public void CargaGrillaVacia()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
            {
                ////DataTable dtFactura = new DataTable();
                dtFactura = objprocesoBL.dtListarFacturasGy_BL(Global.vUserBaseDatos);
                gcFactura.DataSource = dtFactura;
                ConfiguraGridFactura();
            }
        }

        public void InicializaVariableItemXml()
        {
            strXmlItem001 = string.Empty;
            item001 = string.Empty;
            strXmlItem002 = string.Empty;
            item002 = string.Empty;
            strXmlItem003 = string.Empty;
            item003 = string.Empty;
            strXmlItem004 = string.Empty;
            item004 = string.Empty;
            strXmlItem005 = string.Empty;
            item005 = string.Empty;
            strXmlItem006 = string.Empty;
            item006 = string.Empty;
            strXmlItem007 = string.Empty;
            item007 = string.Empty;
            strXmlItem008 = string.Empty;
            item008 = string.Empty;
            strXmlItem009 = string.Empty;
            item009 = string.Empty;
            strXmlItem010 = string.Empty;
            item010 = string.Empty;
            strXmlItem011 = string.Empty;
            item011 = string.Empty;
            strXmlItem012 = string.Empty;
            item012 = string.Empty;
            strXmlItem013 = string.Empty;
            item013 = string.Empty;
            strXmlItem014 = string.Empty;
            item014 = string.Empty;
            strXmlItem015 = string.Empty;
            item015 = string.Empty;
            strXmlItem016 = string.Empty;
            item016 = string.Empty;
            strXmlItem017 = string.Empty;
            item017 = string.Empty;
            strXmlItem018 = string.Empty;
            item018 = string.Empty;
            strXmlItem019 = string.Empty;
            item019 = string.Empty;
            strXmlItem020 = string.Empty;
            item020 = string.Empty;
            strXmlItem021 = string.Empty;
            item021 = string.Empty;
            strXmlItem022 = string.Empty;
            item022 = string.Empty;
            strXmlItem023 = string.Empty;
            item023 = string.Empty;
            strXmlItem024 = string.Empty;
            item024 = string.Empty;
            strXmlItem025 = string.Empty;
            item025 = string.Empty;

        }

        public void InicializaVariablesXml()
        {
            xml_Proveedor = string.Empty;
            xml_Tipo = string.Empty;
            xml_Documento = string.Empty;
            xml_Fecha_Doc = null;               //DateTime? xml_Fecha_Doc = null;
            xml_Fecha_Rige = null;              //DateTime? xml_Fecha_Rige = null;    
            xml_Aplicacion = string.Empty;
            xml_Subtotal = 0;
            xml_Descuento = 0;
            xml_Impuesto1 = 0;
            xml_Impuesto2 = 0;
            xml_Rubro_1 = 0;
            xml_Rubro_2 = 0;
            xml_Monto = 0;
            xml_Saldo = 0;
            xml_Moneda = string.Empty;
            xml_Condicion_Pago = string.Empty;
            xml_Cuenta_Bancaria = string.Empty;
            xml_Notas = string.Empty;
            xml_Subtipo = string.Empty;
            xml_Centro_Costo = string.Empty;
            xml_Cuenta_Contable = string.Empty;
            xml_Fecha_Contable = null;          //DateTime? xml_Fecha_Contable = null;            
            xml_Rubro_1_Doc = string.Empty;
            xml_Rubro_2_Doc = string.Empty;
            xml_Rubro_3_Doc = string.Empty;
            xml_Rubro_4_Doc = string.Empty;
            xml_Rubro_5_Doc = string.Empty;
            xml_Rubro_6_Doc = string.Empty;
            xml_Rubro_7_Doc = string.Empty;
            xml_Rubro_8_Doc = string.Empty;
            xml_Rubro_9_Doc = string.Empty;
            xml_Rubro_10_Doc = string.Empty;
            xml_Paquete = string.Empty;
            xml_Tipo_Asiento = string.Empty;
            xml_Retención = string.Empty;
            xml_Embarque = string.Empty;
            xml_Tipo_Referencia = string.Empty;
            xml_Doc_Referencia = string.Empty;

        }

        public void ConfiguraGridFacturaXmlPath()
        {
            //gvXmlPath.OptionsView.ColumnAutoWidth = false;
            //gvXmlPath.BestFitColumns();

            //Font fnt2 = new Font(gvXmlPath.Appearance.Row.Font.Name, 8);
            //gvXmlPath.Appearance.HeaderPanel.Font = fnt2;
            //gvXmlPath.Appearance.Row.Font = fnt2;
            //gvXmlPath.Appearance.Row.Options.UseFont = true;
            //gvXmlPath.OptionsView.ShowGroupPanel = false;
            //gvXmlPath.OptionsView.ShowIndicator = false;
            //gvXmlPath.OptionsBehavior.Editable = false;//////////////////////////////////
            //gvXmlPath.OptionsSelection.EnableAppearanceFocusedCell = false;

            // ordenamiento
            gvXmlPath.ClearSorting();
            gvXmlPath.Columns["FECHA"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //formateo
            gvXmlPath.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvXmlPath.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvXmlPath.Columns["IMPUESTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvXmlPath.Columns["IMPUESTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvXmlPath.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvXmlPath.Columns["TOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";

            gvXmlPath.Columns["VERSION"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gvXmlPath.Columns["FECHA"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gvXmlPath.Columns["DOCUMENTO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gvXmlPath.Columns["VCMTO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            gvXmlPath.Columns["VERSION"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gvXmlPath.Columns["FECHA"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gvXmlPath.Columns["DOCUMENTO"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gvXmlPath.Columns["VCMTO"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            gvXmlPath.Columns["VERSION"].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            gvXmlPath.Columns["FECHA"].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            gvXmlPath.Columns["DOCUMENTO"].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            gvXmlPath.Columns["VCMTO"].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            gvXmlPath.Columns["VERSION"].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            gvXmlPath.Columns["FECHA"].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            gvXmlPath.Columns["DOCUMENTO"].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            gvXmlPath.Columns["VCMTO"].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
        }



        public void ConfiguraGridFactura()
        {
            //agrego checkbox            
            gvFactura.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvFactura_CustomRowCellEdit);
            RepositoryItemCheckEdit repositoryCheckEdit1 = gcFactura.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            repositoryCheckEdit1.Name = "CheckGenerar";
            repositoryCheckEdit1.ValueChecked = "True";
            repositoryCheckEdit1.ValueUnchecked = "False";
            gvFactura.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;

            gvFactura.OptionsView.ColumnAutoWidth = false;
            gvFactura.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gvFactura.Appearance.Row.Font.Name, 7);
            gvFactura.Appearance.HeaderPanel.Font = fnt;
            gvFactura.Appearance.Row.Font = fnt;
            gvFactura.Appearance.Row.Options.UseFont = true;
            gvFactura.OptionsView.ShowGroupPanel = false;
            gvFactura.OptionsView.ShowIndicator = false;
            gvFactura.OptionsBehavior.Editable = true;  //false;
            gvFactura.OptionsSelection.EnableAppearanceFocusedCell = false;

            // COLOR
            gvFactura.Columns["PROCESAR"].AppearanceCell.BackColor = Color.LightYellow;
            gvFactura.Columns["PROVEEDOR"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["TIPO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["DOCUMENTO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["FECHA_DOC"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["APLICACION"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["SUBTOTAL"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["IMPUESTO1"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["MONTO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["SALDO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["MONEDA"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["DIFERENCIA"].AppearanceCell.BackColor = Color.Coral;
            gvFactura.Columns["SUBTIPO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["CENTRO_COSTO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["CUENTA_CONTABLE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["FECHA_CONTABLE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["RUBRO_8_DOC"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["PAQUETE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["CONDICION_PAGO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["TIPO_ASIENTO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["TIPO_REFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["DOC_REFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["BASE_IMPUESTO1"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["EMBARQUE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["USUARIO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["FECHA_VENCE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["EMB_REFERENCIA"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_RUBRO1"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_NOTAS"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_CONDICIONPAGO"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_MONTO_LOCAL"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_MONTO_DOLAR"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["XML_ITEMS"].AppearanceCell.BackColor = Color.LightGray;

            //EDITABLE
            //gvFactura.Columns["PROVEEDOR"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["TIPO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["DOCUMENTO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["FECHA_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["FECHA_RIGE"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["APLICACION"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["SUBTOTAL"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["DESCUENTO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["IMPUESTO1"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["IMPUESTO2"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_1"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_2"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["MONTO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["SALDO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["MONEDA"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["CONDICION_PAGO"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["CUENTA_BANCARIA"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["NOTAS"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["SUBTIPO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["CENTRO_COSTO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["CUENTA_CONTABLE"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["FECHA_CONTABLE"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["RUBRO_1_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_2_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_3_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_4_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_5_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_6_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_7_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_8_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_9_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RUBRO_10_DOC"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["PAQUETE"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["TIPO_ASIENTO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["RETENCION"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["EMBARQUE"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["TIPO_REFERENCIA"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["DOC_REFERENCIA"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["BASE_IMPUESTO1"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["BASE_IMPUESTO2"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["FECHA_VENCE"].OptionsColumn.AllowEdit = true;
            //gvFactura.Columns["USUARIO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["CARGADO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["EMB_REFERENCIA"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["EMB_RUBRO1"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["EMB_NOTAS"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["EMB_CONDICIONPAGO"].OptionsColumn.AllowEdit = false;
            //gvFactura.Columns["XML_ITEMS"].OptionsColumn.AllowEdit = false;

            //formateo
            gvFactura.Columns["SUBTOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["SUBTOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["DESCUENTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["DESCUENTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["IMPUESTO1"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["IMPUESTO1"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["IMPUESTO2"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["IMPUESTO2"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["SALDO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["SALDO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["BASE_IMPUESTO1"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["BASE_IMPUESTO1"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["BASE_IMPUESTO2"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["BASE_IMPUESTO2"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["EMB_MONTO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["EMB_MONTO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["EMB_MONTO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["EMB_MONTO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFactura.Columns["DIFERENCIA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["DIFERENCIA"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //ordenamiento
            gvFactura.ClearSorting();
            gvFactura.Columns["DOCUMENTO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }

        //**************************************************************************************************************************************************
        // cadenas de busqueda
        //**************************************************************************************************************************************************

        public string ExtraeSubCadena_OK(string cadena_entrada, string cadena_nodo, string cadena_busqueda)
        {
            string cCadXml = cadena_entrada;
            string cCadNodo = string.Empty;
            string cCadena = string.Empty;

            //busca nodo
            int ini_Nodo = cCadXml.IndexOf(cadena_nodo);
            int fin_Nodo = cCadXml.LastIndexOf(cadena_nodo);
            int lon_Nodo = cadena_nodo.Length;
            cCadNodo = cCadXml.Substring(ini_Nodo + lon_Nodo, fin_Nodo - (ini_Nodo + lon_Nodo + 2));
            //busca cadena en el nodo
            int ini = cCadNodo.IndexOf(cadena_busqueda);
            int fin = cCadNodo.LastIndexOf(cadena_busqueda);
            int LongitudCadena = cadena_busqueda.Length;
            cCadena = cCadNodo.Substring(ini + LongitudCadena, fin - (ini + LongitudCadena + 2));
            return cCadena;
        }

        public string ExtraeCadena_OK(string cadena_entrada, string cadena_busqueda)
        {
            string cCadXml = cadena_entrada;
            string cCadena = string.Empty;
            int ini = cCadXml.IndexOf(cadena_busqueda);
            int fin = cCadXml.LastIndexOf(cadena_busqueda);
            int LongitudCadena = cadena_busqueda.Length;
            cCadena = cCadXml.Substring(ini + LongitudCadena, fin - (ini + LongitudCadena + 2));
            return cCadena;
        }

        public string ExtraeNumFac_OK(string cadena_entrada, string cadena_ini, string cadena_fin, string constante)
        {
            string cCadXml = cadena_entrada;
            string cCadena = string.Empty;

            //cCadena = strXml.Substring(ini_Nodo - (constante.Length), 12);
            //<cbc:ID>F014-0012029</cbc:ID>
            //F014-0012029

            //busca cadena base
            int ini_Nodo = cCadXml.IndexOf(cadena_ini + constante);
            cCadena = cCadXml.Substring(ini_Nodo + (cadena_ini.Length), 12);

            return cCadena;
        }

        public string ExtraeStringInvoiceLine_OK(string cadena_item_ini, string cadena_item_fin, string cadena_entrada)
        {

            string cCadenaInput = cadena_entrada;
            string cCadenaOutput = string.Empty;
            string cCadNodo = string.Empty;

            int ini_item = cCadenaInput.IndexOf(cadena_item_ini);
            int fin_item = cCadenaInput.LastIndexOf(cadena_item_fin);
            int lon_item_ini = cadena_item_ini.Length;
            int lon_item_fin = cadena_item_fin.Length;

            cCadNodo = cCadenaInput.Substring(ini_item, fin_item - ini_item + lon_item_fin);
            cCadenaOutput = cCadNodo;

            return cCadenaOutput;
        }

        public string ExtraeStringItemFactura_OK(string cadena_item_ini, string cadena_item_fin, string cadena_entrada)
        {
            string cCadNodo = string.Empty;
            string cCadenaInput = string.Empty;
            string cCadenaOutput = string.Empty;

            cCadenaInput = cadena_entrada;

            int ini_item = cCadenaInput.IndexOf(cadena_item_ini);
            int fin_item = cCadenaInput.IndexOf(cadena_item_fin);
            int lon_item_ini = cadena_item_ini.Length;
            int lon_item_fin = cadena_item_fin.Length;

            cCadNodo = cCadenaInput.Substring(ini_item, fin_item - ini_item + lon_item_fin);
            cCadenaOutput = cCadNodo;

            return cCadenaOutput;
        }

        public string ExtraerValorEnXml_OK(string cadena_entrada, string nodo_raiz, string nodo_buscar)
        {
            string cadena_input = cadena_entrada;
            string cadena_output = string.Empty;
            string xmlstr = string.Empty;

            xmlstr = xmlstr + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xmlstr = xmlstr + "<Prueba>";
            xmlstr = xmlstr + EliminarPrefijoEnXml_OK(cadena_input);
            xmlstr = xmlstr + "</Prueba>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes(nodo_raiz);

            foreach (XmlNode node in nodes)
            {
                cadena_output = node.SelectSingleNode(nodo_buscar).InnerText;
            }

            return cadena_output;
        }

        public string EliminarPrefijoEnXml_OK(string cadena_entrada)
        {
            string cadena_input = cadena_entrada;
            string cadena_output = string.Empty;
            string NewCad = string.Empty;

            //quitamos los prefijos
            NewCad = cadena_input.Replace("ext:", "");
            NewCad = NewCad.Replace("sac:", "");
            NewCad = NewCad.Replace("cac:", "");
            NewCad = NewCad.Replace("cbc:", "");
            cadena_output = NewCad;

            return cadena_output;
        }

        public string ObtieneStringItemXml_OK(string cadena_xml_tmp, int numero_item, string posicion)
        {
            string strXmlItem = string.Empty;

            switch (numero_item)
            {
                case 1:
                    strXmlItem001 = cadena_xml_tmp;
                    item001 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem001);
                    strXmlItem = item001;
                    break;
                case 2:
                    strXmlItem002 = strXmlItem001.Substring(item001.Length, strXmlItem001.Length - item001.Length);
                    item002 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem002);
                    strXmlItem = item002;
                    break;
                case 3:
                    strXmlItem003 = strXmlItem002.Substring(item002.Length, strXmlItem002.Length - item002.Length);
                    item003 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem003);
                    strXmlItem = item003;
                    break;
                case 4:
                    strXmlItem004 = strXmlItem003.Substring(item003.Length, strXmlItem003.Length - item003.Length);
                    item004 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem004);
                    strXmlItem = item004;
                    break;
                case 5:
                    strXmlItem005 = strXmlItem004.Substring(item004.Length, strXmlItem004.Length - item004.Length);
                    item005 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem005);
                    strXmlItem = item005;
                    break;
                case 6:
                    strXmlItem006 = strXmlItem005.Substring(item005.Length, strXmlItem005.Length - item005.Length);
                    item006 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem006);
                    strXmlItem = item006;
                    break;
                case 7:
                    strXmlItem007 = strXmlItem006.Substring(item006.Length, strXmlItem006.Length - item006.Length);
                    item007 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem007);
                    strXmlItem = item007;
                    break;
                case 8:
                    strXmlItem008 = strXmlItem007.Substring(item007.Length, strXmlItem007.Length - item007.Length);
                    item008 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem008);
                    strXmlItem = item008;
                    break;
                case 9:
                    strXmlItem009 = strXmlItem008.Substring(item008.Length, strXmlItem008.Length - item008.Length);
                    item009 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem009);
                    strXmlItem = item009;
                    break;
                case 10:
                    strXmlItem010 = strXmlItem009.Substring(item009.Length, strXmlItem009.Length - item009.Length);
                    item010 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem010);
                    strXmlItem = item010;
                    break;
                case 11:
                    strXmlItem011 = strXmlItem010.Substring(item010.Length, strXmlItem010.Length - item010.Length);
                    item011 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem011);
                    strXmlItem = item011;
                    break;
                case 12:
                    strXmlItem012 = strXmlItem011.Substring(item011.Length, strXmlItem011.Length - item011.Length);
                    item012 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem012);
                    strXmlItem = item012;
                    break;
                case 13:
                    strXmlItem013 = strXmlItem012.Substring(item012.Length, strXmlItem012.Length - item012.Length);
                    item013 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem013);
                    strXmlItem = item013;
                    break;
                case 14:
                    strXmlItem014 = strXmlItem013.Substring(item013.Length, strXmlItem013.Length - item013.Length);
                    item014 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem014);
                    strXmlItem = item014;
                    break;
                case 15:
                    strXmlItem015 = strXmlItem014.Substring(item014.Length, strXmlItem014.Length - item014.Length);
                    item015 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem015);
                    strXmlItem = item015;
                    break;
                case 16:
                    strXmlItem016 = strXmlItem015.Substring(item015.Length, strXmlItem015.Length - item015.Length);
                    item016 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem016);
                    strXmlItem = item016;
                    break;
                case 17:
                    strXmlItem017 = strXmlItem016.Substring(item016.Length, strXmlItem016.Length - item016.Length);
                    item017 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem017);
                    strXmlItem = item017;
                    break;
                case 18:
                    strXmlItem018 = strXmlItem017.Substring(item017.Length, strXmlItem017.Length - item017.Length);
                    item018 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem018);
                    strXmlItem = item018;
                    break;
                case 19:
                    strXmlItem019 = strXmlItem018.Substring(item018.Length, strXmlItem018.Length - item018.Length);
                    item019 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem019);
                    strXmlItem = item019;
                    break;
                case 20:
                    strXmlItem020 = strXmlItem019.Substring(item019.Length, strXmlItem019.Length - item019.Length);
                    item020 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem020);
                    strXmlItem = item020;
                    break;
                case 21:
                    strXmlItem021 = strXmlItem020.Substring(item020.Length, strXmlItem020.Length - item020.Length);
                    item021 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem021);
                    strXmlItem = item021;
                    break;
                case 22:
                    strXmlItem022 = strXmlItem021.Substring(item021.Length, strXmlItem021.Length - item021.Length);
                    item022 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem022);
                    strXmlItem = item022;
                    break;
                case 23:
                    strXmlItem023 = strXmlItem022.Substring(item022.Length, strXmlItem022.Length - item022.Length);
                    item023 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem023);
                    strXmlItem = item023;
                    break;
                case 24:
                    strXmlItem024 = strXmlItem023.Substring(item023.Length, strXmlItem023.Length - item023.Length);
                    item024 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem024);
                    strXmlItem = item024;
                    break;
                case 25:
                    strXmlItem025 = strXmlItem024.Substring(item024.Length, strXmlItem024.Length - item024.Length);
                    item025 = ExtraeStringItemFactura_OK("<cac:InvoiceLine>", "</cac:InvoiceLine>", strXmlItem025);
                    strXmlItem = item025;
                    break;
                default:
                    break;
            }

            return strXmlItem;
        }

        public string ObtieneAbrevCodigo_OK(string codigo_gy)
        {
            string cadena_output = string.Empty;

            switch (GeneralLibCS.Left(codigo_gy, 2))
            {
                case "18":
                    cadena_output = "LL";
                    break;
                case "34":
                    cadena_output = "CA";
                    break;
                case "38":
                    cadena_output = "PR";
                    break;
                default:
                    cadena_output = "LL";
                    break;
            }

            return cadena_output;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int[] seleccionados;
            seleccionados = gvXmlPath.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                DataRow fila_xml;

                foreach (int row in seleccionados)
                {
                    fila_xml = gvXmlPath.GetDataRow(row);

                    strRutaXml = Convert.ToString(fila_xml["DOCUMENTO"].ToString());
                    //ProcesaXml(strRutaXml);
                    strCondicionPagoPDF = Convert.ToString(fila_xml["CONDPAGO"].ToString());
                    ////ProcesaXml(strRutaXml, strCondicionPagoPDF); //MAX2025

                    //MessageBox.Show("Documento : "+Convert.ToString(fila_gvaudi["DOCUMENTO"].ToString())+" Fecha : "+Convert.ToString(fila_gvaudi["FECHA"].ToString()));
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Generar Archivo de Carga GY");
            }
        }

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

        //**************************************************************************************************************************************************
        //**************************************************************************************************************************************************

        #endregion

        #region PROCESA_FACTURAS_GY
        private void btnExportarFacturas_Click(object sender, EventArgs e)
        {
            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Carga Facturas GY --> ERP Exactus");
                return;
            }
            else
            {

                gcFactura.ShowPrintPreview();
            }
        }

        private void btnProcesarFacturas_Click(object sender, EventArgs e)
        {

            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Facturas GY");
                return;
            }
            else
            {

                try
                {
                    //procesa facturas GY
                    DialogResult dialogResult = MessageBox.Show("Proceso Facturas GY."
                                                           + "\n"
                                                           + "\nEsta seguro de Procesar la informacion?", "Facturas GY", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Facturas GY", "Espere por favor.."))
                        {

                            //VALIDACIONES
                            //if (vNIVEL_PRECIO == null || vNIVEL_PRECIO == "")
                            //{
                            //    MessageBox.Show("Debe ingresar el Nivel de Precio");
                            //    return;
                            //}
                            //else if (vMONEDA == null || vMONEDA == "")
                            //{
                            //    MessageBox.Show("Debe ingresar la Moneda");
                            //    return;
                            //}
                            //else
                            //if (vVERSION ==0)
                            //{
                            //    MessageBox.Show("Debe ingresar la Version");
                            //    return;
                            //}

                            string varPROVEEDOR = "";
                            string varTIPO = "";
                            string varDOCUMENTO = "";
                            string varTIPO_REFERENCIA = "";
                            string varDOC_REFERENCIA = "";
                            string varEMBARQUE = "";

                            // recorre grilla
                            for (int i = 0; i < gvFactura.DataRowCount; ++i)
                            {
                                DataRow row = gvFactura.GetDataRow(i);

                                if (row["PROVEEDOR"] != null && row["PROVEEDOR"].ToString() != "")
                                {
                                    if (row["TIPO"] != null && row["TIPO"].ToString() != "")
                                    {
                                        if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
                                        {
                                            varPROVEEDOR = row["PROVEEDOR"].ToString();
                                            varTIPO = row["TIPO"].ToString();
                                            varDOCUMENTO = row["DOCUMENTO"].ToString();
                                            varTIPO_REFERENCIA = row["TIPO_REFERENCIA"].ToString();
                                            varDOC_REFERENCIA = row["DOC_REFERENCIA"].ToString();
                                            varEMBARQUE = row["EMBARQUE"].ToString();

                                            //if ((row["EMBARQUE"] == null) && (row["EMBARQUE"].ToString() == ""))
                                            if ((varEMBARQUE == null) || (varEMBARQUE == ""))
                                            {
                                                //ubica embarque en tabla embarque
                                                varEMBARQUE = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(varDOC_REFERENCIA, "EMBARQUE", Global.vUserBaseDatos);

                                                //temporal determina embarque
                                                //Random rnd = new Random();
                                                //num_random = rnd.Next(10000000, 99999999);                                                
                                                //varEMBARQUE = "EM" + num_random.ToString();     //'EM00021734'
                                                //varEMBARQUE = ObtieneEmbarquePrueba();

                                                if ((varEMBARQUE != null) || (varEMBARQUE != ""))
                                                {
                                                    // actualiza embarque
                                                    try
                                                    {
                                                        Int32 j;
                                                        for (j = 0; j < gvFactura.RowCount; j++)
                                                        {
                                                            if (row["PROVEEDOR"].ToString() == varPROVEEDOR)
                                                            {
                                                                if (row["TIPO"].ToString() == varTIPO)
                                                                {
                                                                    if ((row["DOCUMENTO"].ToString() == varDOCUMENTO))
                                                                    {
                                                                        if (row["TIPO_REFERENCIA"].ToString() == varTIPO_REFERENCIA)
                                                                        {
                                                                            if ((row["DOC_REFERENCIA"].ToString() == varDOC_REFERENCIA))
                                                                            {
                                                                                gvFactura.SetRowCellValue(j, "EMBARQUE", varEMBARQUE);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        }

                                                        ////actualizo el grid control 
                                                        //gcFactura.RefreshDataSource();

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show(ex.Message);
                                                    }
                                                }
                                            }


                                        }
                                    }
                                }
                            }

                            //actualizo el grid control 
                            gcFactura.RefreshDataSource();

                        }

                    }
                    //MessageBox.Show("Se genero la Orden de Servicio N° " + varU_OSERVICIO, "Orden de Servicio");
                    //this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private string ObtieneEmbarquePrueba()
        {
            //temporal determina embarque
            string _embarque = string.Empty;
            Random rnd = new Random();
            num_random = rnd.Next(10000000, 99999999);
            _embarque = "EM" + num_random.ToString();     //'EM00021734'
            return _embarque;
        }

        private void btnCargar2Exactus_Click(object sender, EventArgs e)
        {
            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Facturas GY --> ERP Exactus");
                return;
            }
            else
            {

                try
                {

                    //PROCESO GRABA
                    DialogResult dialogResult = MessageBox.Show("Carga Facturas GY --> ERP Exactus."
                                                           + "\n"
                                                           + "\nEsta seguro de Procesar la informacion?", "Carga Facturas GY --> ERP Exactus", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Carga Facturas GY --> ERP Exactus", "Espere por favor.."))
                        {
                            string varPROVEEDOR = "";
                            string varDOCUMENTO = "";
                            string varTIPO = "";
                            DateTime varFECHA_DOC;
                            //DateTime? varFECHA_DOC = null;
                            string varAPLICACION = "";
                            Decimal varMONTO = 0;
                            Decimal varSALDO = 0;
                            Decimal varSUBTOTAL = 0;
                            Decimal varDESCUENTO = 0;
                            Decimal varIMPUESTO1 = 0;
                            Decimal varIMPUESTO2 = 0;
                            Decimal varRUBRO_1 = 0;
                            Decimal varRUBRO_2 = 0;
                            string varCONDICION_PAGO = "";
                            string varMONEDA = "";
                            Int16 varSUBTIPO = 0;
                            DateTime varFECHA_VENCE; // = row["FECHA_VENCE"].ToString();
                                                     //DateTime? varFECHA_VENCE = null;
                            Decimal varBASE_IMPUESTO1 = 0;
                            Decimal varBASE_IMPUESTO2 = 0;
                            string varRUBRO_8_DOC = "";
                            string varCUENTA_CONTABLE = "";
                            string varCENTRO_COSTO = "";
                            string varEMBARQUE = "";
                            DateTime varFECHA_PROCESO;  // = row["FECHA_PROCESO"].ToString();
                                                        //DateTime? varFECHA_PROCESO = null;
                            string varUSUARIO = "";
                            string varCARGADO = "";


                            for (int i = 0; i < gvFactura.DataRowCount; ++i)
                            {
                                DataRow row = gvFactura.GetDataRow(i);

                                //repositoryCheckEdit1.ValueChecked = "True";
                                //repositoryCheckEdit1.ValueUnchecked = "False";
                                //gvFactura.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;
                                //gvFactura.SetRowCellValue(j, "PROCESAR", false);

                                //if (Convert.ToBoolean(row["PROCESAR"]) == true)
                                //if ( (row["PROCESAR"] != null) && (Convert.ToBoolean(row["PROCESAR"]) != null) && (Convert.ToBoolean(row["PROCESAR"]) == true))
                                //if ((row["CARGADO"] != null) && (row["CARGADO"].ToString() == "X"))
                                if (row["PROCESAR"] != System.DBNull.Value)
                                {
                                    if (Convert.ToBoolean(row["PROCESAR"]) == true)
                                    {
                                        //**
                                        if (row["TIPO"] != null && row["TIPO"].ToString() != "")
                                        {

                                            if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
                                            {

                                                varPROVEEDOR = row["PROVEEDOR"].ToString();
                                                varDOCUMENTO = row["DOCUMENTO"].ToString();
                                                varTIPO = row["TIPO"].ToString();
                                                varFECHA_DOC = Convert.ToDateTime(row["FECHA_DOC"]);
                                                varAPLICACION = row["APLICACION"].ToString();
                                                varMONTO = Convert.ToDecimal(row["MONTO"].ToString());
                                                varSALDO = Convert.ToDecimal(row["SALDO"].ToString());
                                                varSUBTOTAL = Convert.ToDecimal(row["SUBTOTAL"].ToString());
                                                varDESCUENTO = Convert.ToDecimal(row["DESCUENTO"].ToString());
                                                varIMPUESTO1 = Convert.ToDecimal(row["IMPUESTO1"].ToString());
                                                varIMPUESTO2 = Convert.ToDecimal(row["IMPUESTO2"].ToString());
                                                varRUBRO_1 = Convert.ToDecimal(row["RUBRO_1"].ToString());
                                                varRUBRO_2 = Convert.ToDecimal(row["RUBRO_2"].ToString());
                                                varCONDICION_PAGO = row["CONDICION_PAGO"].ToString();
                                                varMONEDA = row["MONEDA"].ToString();
                                                varSUBTIPO = Convert.ToInt16(row["SUBTIPO"]);
                                                varFECHA_VENCE = Convert.ToDateTime(row["FECHA_VENCE"]);
                                                varBASE_IMPUESTO1 = Convert.ToDecimal(row["BASE_IMPUESTO1"].ToString());
                                                varBASE_IMPUESTO2 = Convert.ToDecimal(row["BASE_IMPUESTO2"].ToString());
                                                varRUBRO_8_DOC = row["RUBRO_8_DOC"].ToString();
                                                varCUENTA_CONTABLE = row["CUENTA_CONTABLE"].ToString();
                                                varCENTRO_COSTO = row["CENTRO_COSTO"].ToString();
                                                varEMBARQUE = row["EMBARQUE"].ToString();
                                                varFECHA_PROCESO = Convert.ToDateTime(row["FECHA_CONTABLE"]);
                                                varUSUARIO = row["USUARIO"].ToString();

                                                //MessageBox.Show("Procesando Factura ..... " + varTIPO + "/" + varDOCUMENTO, "Verificacion");


                                                //graba
                                                //ContabilidadBL.dtProcesaFacturasGyBL(varPROVEEDOR, varDOCUMENTO, varTIPO, varFECHA_DOC, varAPLICACION,
                                                //                                        varMONTO, varSALDO, varSUBTOTAL, varDESCUENTO, varIMPUESTO1, varIMPUESTO2,
                                                //                                        varRUBRO_1, varRUBRO_2, varCONDICION_PAGO, varMONEDA, varSUBTIPO, varFECHA_VENCE,
                                                //                                        varBASE_IMPUESTO1, varBASE_IMPUESTO2, varRUBRO_8_DOC, varCUENTA_CONTABLE,
                                                //                                        varCENTRO_COSTO, varEMBARQUE, varFECHA_PROCESO, varUSUARIO, Global.vUserBaseDatos);

                                                ContabilidadBL.dtProcesaFacturasGyV2_BL(varPROVEEDOR, varDOCUMENTO, varTIPO, varFECHA_DOC, varAPLICACION,
                                                                                        varMONTO, varSALDO, varSUBTOTAL, varDESCUENTO, varIMPUESTO1, varIMPUESTO2,
                                                                                        varRUBRO_1, varRUBRO_2, varCONDICION_PAGO, varMONEDA, varSUBTIPO, varFECHA_VENCE,
                                                                                        varBASE_IMPUESTO1, varBASE_IMPUESTO2, varRUBRO_8_DOC, varCUENTA_CONTABLE,
                                                                                        varCENTRO_COSTO, varEMBARQUE, varFECHA_PROCESO, varUSUARIO, Global.vUserBaseDatos);



                                            }
                                        }
                                        //*
                                    }
                                }

                            }

                        }
                    }

                    //
                    MessageBox.Show("Proceso Finalizado !!!", "Carga Facturas GY --> ERP Exactus");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        /*
            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Facturas GY --> ERP Exactus");
                return;
            }
            else
            {

                try
                {

                    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
                    {

                        //MessageBox.Show("Se genero la   " + varFACTURA,  "Carga Facturas GY --> ERP Exactus");
                        //this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            

            }
        }
        */






        #endregion

        private void gvFactura_FocusedRowChanged_1(object sender, FocusedRowChangedEventArgs e)
        {
            //sucursal = gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "SUCURSAL").ToString();
            //descripcion = gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "DESCRIPCION").ToString();
            //txtTienda_Unidad.Text = gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "TIENDA_UNIDADES").ToString();
            //txtTienda_Monto.Text = gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "TIENDA_MONTO").ToString();
        }

        private void gvFactura_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {


        }

        private void chkFacturas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFacturas.Checked)
            {
                // actualiza embarque
                try
                {
                    Int32 j;
                    for (j = 0; j < gvFactura.RowCount; j++)
                    {
                        gvFactura.SetRowCellValue(j, "PROCESAR", true);
                    }

                    gcFactura.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                // actualiza embarque
                try
                {
                    Int32 j;
                    for (j = 0; j < gvFactura.RowCount; j++)
                    {
                        gvFactura.SetRowCellValue(j, "PROCESAR", false);
                    }

                    gcFactura.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ActualizaGrilla();
        }

        private void ActualizaGrilla()
        {
            string varPROVEEDOR = "";
            string varDOCUMENTO = "";
            string varTIPO = "";

            for (int i = 0; i < gvFactura.DataRowCount; ++i)
            {
                DataRow row = gvFactura.GetDataRow(i);

                if (row["PROCESAR"] != System.DBNull.Value)
                {
                    if (Convert.ToBoolean(row["PROCESAR"]) == true)
                    {
                        varPROVEEDOR = row["PROVEEDOR"].ToString();
                        varDOCUMENTO = row["DOCUMENTO"].ToString();
                        varTIPO = row["TIPO"].ToString();

                        MessageBox.Show("Procesando Factura ..... " + varTIPO + "/" + varDOCUMENTO, "Verificacion");
                    }
                }

            }

        }





        //=========================================================================================
        /*
        //SIN USO
        public string BuscarCondicioPagoEnPDF_V2(string _ruta_del_pdf)
        {
            string codigo_retorno;

            if (_ruta_del_pdf == "")
            {
                codigo_retorno = "0";
            }
            else
            {
                stringPdfFile = _ruta_del_pdf;
                textBox1.Text = "";
                int pageNumber = 1;

                var text = new StringBuilder();

                using (var pdfReader = new PdfReader(stringPdfFile))
                {
                    var rect = new System.util.RectangleJ(385, 655, 25, 40);      //CONDICION PAGO

                    var filters = new RenderFilter[1];
                    filters[0] = new RegionTextRenderFilter(rect);

                    ITextExtractionStrategy strategy =
                        new FilteredTextRenderListener(
                            new LocationTextExtractionStrategy(),
                            filters);

                    var currentText = PdfTextExtractor.GetTextFromPage(
                        pdfReader,
                        pageNumber,
                        strategy);

                    currentText =
                        Encoding.UTF8.GetString(Encoding.Convert(
                            Encoding.Default,
                            Encoding.UTF8,
                            Encoding.Default.GetBytes(currentText)));

                    text.Append(currentText);
                }

                ////
                //condicion_pago
                //------------------------
                //0       CONTADO
                //ANTC    ANTICIPO
                //F07D    FACTURA 07 DIAS
                //F15D    FACTURA 15 DIAS
                //F30D    FACTURA 30 DIAS
                //F45D    FACTURA 45 DIAS
                //F60D    FACTURA 60 DIAS
                //F90D    FACTURA 90 DIAS
                ////

                string textoExtraido = text.ToString();

                if (textoExtraido.Contains("A la vista") == true)
                {
                    codigo_retorno = "0";
                }
                else
                {
                    string cadenaTexto = textoExtraido;
                    string diasPDF = cadenaTexto.Substring((cadenaTexto.IndexOf("Pago:") + 6), ((cadenaTexto.IndexOf("dias") + 5) - (cadenaTexto.IndexOf("Pago:") + 6 + 1)));

                    if (String.IsNullOrEmpty(diasPDF))
                    {
                        codigo_retorno = "0";
                    }
                    else
                    {
                        string dias = diasPDF.Substring(0, 2);

                        int s = Convert.ToInt32(dias);
                        switch (s)
                        {
                            case 7:
                                {
                                    codigo_retorno = "F07D";
                                    break;
                                }
                            case 15:
                                {
                                    codigo_retorno = "F15D";
                                    break;
                                }
                            case 30:
                                {
                                    codigo_retorno = "F30D";
                                    break;
                                }
                            case 45:
                                {
                                    codigo_retorno = "F45D";
                                    break;
                                }

                            case 60:
                                {
                                    codigo_retorno = "F60D";
                                    break;
                                }
                            case 90:
                                {
                                    codigo_retorno = "F90D";
                                    break;
                                }
                            default:
                                {
                                    codigo_retorno = "0";
                                    break;
                                }
                        }
                    }

                }

            }

            return codigo_retorno;
        }

        public string BuscarCondicioPagoEnPDF(string _ruta_del_pdf)
        {
            string codigo_retorno;

            if (_ruta_del_pdf == "")
            {
                codigo_retorno = "0";
            }
            else
            {
                stringPdfFile = _ruta_del_pdf;
                textBox1.Text = "";
                int pageNumber = 1;

                var text = new StringBuilder();

                using (var pdfReader = new PdfReader(stringPdfFile))
                {
                    var rect = new System.util.RectangleJ(385, 655, 25, 40);      //CONDICION PAGO

                    var filters = new RenderFilter[1];
                    filters[0] = new RegionTextRenderFilter(rect);

                    ITextExtractionStrategy strategy =
                        new FilteredTextRenderListener(
                            new LocationTextExtractionStrategy(),
                            filters);

                    var currentText = PdfTextExtractor.GetTextFromPage(
                        pdfReader,
                        pageNumber,
                        strategy);

                    currentText =
                        Encoding.UTF8.GetString(Encoding.Convert(
                            Encoding.Default,
                            Encoding.UTF8,
                            Encoding.Default.GetBytes(currentText)));

                    text.Append(currentText);
                }

                ////
                //condicion_pago
                //------------------------
                //0       CONTADO
                //ANTC    ANTICIPO
                //F07D    FACTURA 07 DIAS
                //F15D    FACTURA 15 DIAS
                //F30D    FACTURA 30 DIAS
                //F45D    FACTURA 45 DIAS
                //F60D    FACTURA 60 DIAS
                //F90D    FACTURA 90 DIAS
                ////

                string textoExtraido = text.ToString();

                if (textoExtraido.Contains("A la vista") == true)
                {
                    codigo_retorno = "0";
                }
                else
                {
                    string cadenaTexto = textoExtraido;
                    string diasPDF = cadenaTexto.Substring((cadenaTexto.IndexOf("Pago:") + 6), ((cadenaTexto.IndexOf("dias") + 5) - (cadenaTexto.IndexOf("Pago:") + 6 + 1)));

                    if (String.IsNullOrEmpty(diasPDF))
                    {
                        codigo_retorno = "0";
                    }
                    else
                    {
                        string dias = diasPDF.Substring(0, 2);

                        int s = Convert.ToInt32(dias);
                        switch (s)
                        {
                            case 7:
                                {
                                    codigo_retorno = "F07D";
                                    break;
                                }
                            case 15:
                                {
                                    codigo_retorno = "F15D";
                                    break;
                                }
                            case 30:
                                {
                                    codigo_retorno = "F30D";
                                    break;
                                }
                            case 45:
                                {
                                    codigo_retorno = "F45D";
                                    break;
                                }

                            case 60:
                                {
                                    codigo_retorno = "F60D";
                                    break;
                                }
                            case 90:
                                {
                                    codigo_retorno = "F90D";
                                    break;
                                }
                            default:
                                {
                                    codigo_retorno = "0";
                                    break;
                                }
                        }
                    }

                }

            }

            return codigo_retorno;
        }

        */
        //=========================================================================================



        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------
        /*
        public void ProcesaXML()
        {
            //procesa facturas
            int[] seleccionados;
            seleccionados = gvXmlPath.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivos XML ....", "Espere por favor.."))
                {
                    DataRow fila_xml;

                    foreach (int row in seleccionados)
                    {
                        fila_xml = gvXmlPath.GetDataRow(row);

                        strRutaXml = Convert.ToString(fila_xml["DOCUMENTO"].ToString());
                        strCondicionPagoPDF = Convert.ToString(fila_xml["CONDPAGO"].ToString());
                        ProcesaXml(strRutaXml, strCondicionPagoPDF);

                        //MessageBox.Show("Documento : "+Convert.ToString(fila_gvaudi["DOCUMENTO"].ToString())+" Fecha : "+Convert.ToString(fila_gvaudi["FECHA"].ToString()));
                    }
                }

                MessageBox.Show("Se proceso todos los archivos XML", "Generar Archivo de Carga GY");

                xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Generar Archivo de Carga GY");
            }

        }


        public void ProcesaXml(string arhivo_xml, string condic_pago_pdf)
        {
            InicializaVariablesXml();

            doc.Load(arhivo_xml);
            strXml = doc.DocumentElement.OuterXml;
            txtXML_Contenido.Text = strXml;

            //ExtraeSubCadena_OK(string cadena_entrada, string cadena_nodo, string cadena_busqueda)

            //carga valores
            xml_Proveedor = "20100012856"; // ExtraeSubCadena_OK(strXml, "cac:AccountingSupplierParty>", "cbc:CustomerAssignedAccountID>");
            //xml_Tipo = ExtraeCadena_OK(strXml, "cbc:InvoiceTypeCode>");
            xml_Tipo = ObtieneTipoDocumento(strXml, "cbc:InvoiceTypeCode>");         //ExtraeCadena_OK(strXml, "cbc:InvoiceTypeCode>");
            xml_Documento = ExtraeNumFac_OK(strXml, "<cbc:ID>", "</cbc:ID>", "FE14");
            xml_Fecha_Doc = Convert.ToDateTime(ExtraeCadena_OK(strXml, "cbc:IssueDate>"));
            xml_Fecha_Rige = Convert.ToDateTime(this.dpFechaProceso.Text);
            xml_Moneda = ExtraeCadena_OK(strXml, "cbc:DocumentCurrencyCode>");
            xml_Cuenta_Bancaria = "";
            xml_Notas = "";
            xml_Subtipo = "0";
            xml_Centro_Costo = "00.00.00.00.00";
            xml_Cuenta_Contable = "42.1.2.1.01";
            xml_Fecha_Contable = Convert.ToDateTime(this.dpFechaProceso.Text);
            xml_Rubro_1_Doc = "";
            xml_Rubro_2_Doc = "";
            xml_Rubro_3_Doc = "";
            xml_Rubro_4_Doc = "";
            xml_Rubro_5_Doc = "";
            xml_Rubro_6_Doc = "";
            xml_Rubro_7_Doc = "";
            xml_Rubro_8_Doc = "N";
            xml_Rubro_9_Doc = "";
            xml_Rubro_10_Doc = "";
            xml_Paquete = "CP";
            xml_Tipo_Asiento = "CP";
            xml_Retención = "";
            //OrdenCompra = ExtraeSubCadena_OK(strXml, "cac:OrderReference>", "cbc:ID>"); // TODO se requiere embarque,  por ahora muestra Orden de Compra 
            //xml_Tipo_Referencia = ExtraeSubCadena_OK(strXml, "cac:DespatchDocumentReference>", "cbc:DocumentTypeCode>");
            xml_Tipo_Referencia = ObtieneTipoReferencia(strXml, "cac:DespatchDocumentReference>", "cbc:DocumentTypeCode>");//ExtraeSubCadena_OK(strXml, "cac:DespatchDocumentReference>", "cbc:DocumentTypeCode>");
            xml_Doc_Referencia = ExtraeSubCadena_OK(strXml, "cac:DespatchDocumentReference>", "cbc:ID>");
            //xml_Embarque = objprocesoBL.BuscarEmbarque_BL(xml_Tipo_Referencia, xml_Doc_Referencia, Global.vUserBaseDatos);
            //xml_Embarque = objprocesoBL.BuscarEmbarque_BL("09","001-0135833", Global.vUserBaseDatos);

            //varEMBARQUE = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(varDOC_REFERENCIA, Global.vUserBaseDatos);
            xml_Embarque = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "EMBARQUE", Global.vUserBaseDatos);

            //xml_Condicion_Pago = "0"; //TODO
            xml_Condicion_Pago = condic_pago_pdf;   // BuscarCondicioPagoEnPDF("C:\\TEMP\\FACT_GY\\xml\\ultimos\\20100012856-01-F014-0042813-Invoice.pdf");

            //string xml_Fecha_Vence = string.Empty;      // add
            //string xml_Usuario = string.Empty;          // add
            //string xml_Cargado = string.Empty;          // add
            xml_Fecha_Vence = xml_Fecha_Doc;              // add
            xml_Usuario = Global.vUserUsuario;            // add
            xml_Cargado = "N";                            // add

            //string xml_Emb_Referencia = string.Empty;       // add
            //string xml_Emb_Rubro1 = string.Empty;           // add
            //string xml_Emb_Notas = string.Empty;            // add
            //string xml_Emb_CondicionPago = string.Empty;    // add
            //string xml_Xml_Items = string.Empty;            // add
            xml_Emb_Referencia = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "REFERENCIA", Global.vUserBaseDatos);
            xml_Emb_Rubro1 = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "RUBRO1", Global.vUserBaseDatos);
            xml_Emb_Notas = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "NOTAS", Global.vUserBaseDatos);
            string _sol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "SOLES", Global.vUserBaseDatos);
            string _dol = ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "DOLARES", Global.vUserBaseDatos);
            //xml_Emb_Monto_Local = Convert.ToDecimal(ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "SOLES", Global.vUserBaseDatos));
            //xml_Emb_Monto_Dolar = Convert.ToDecimal(ContabilidadBL.ObtieneEmbarqueFacturaGyBL(xml_Doc_Referencia, "DOLARES", Global.vUserBaseDatos));

            //xml_Emb_Monto_Local = 
            //xml_Emb_Monto_Dolar = Convert.ToDecimal(_dol);

            if (_sol == "")
            {
                xml_Emb_Monto_Local = 0;
            }
            else
            {
                xml_Emb_Monto_Local = Convert.ToDecimal(_sol);
            }


            if (_dol == "")
            {
                xml_Emb_Monto_Dolar = 0;
            }
            else
            {
                xml_Emb_Monto_Dolar = Convert.ToDecimal(_dol);
            }

            xml_Emb_CondicionPago = "";

            // procesa items de xml
            //ProcesaInvoiceLineXml_OK();

            //extrae montos totales
            //ProcesaXmlTotales(arhivo_xml);        //MAXMAX
            ProcesaXmlTotales(arhivo_xml, strXml);

            // procesa items de xml
            //Item_ProcesaInvoiceLineXml_OK(strXml);  //  MAXMAX            

        }





        */
        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------

    }
}

//EOF