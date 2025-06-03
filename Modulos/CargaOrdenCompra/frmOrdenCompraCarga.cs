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
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Newtonsoft.JSON;


namespace ApssaExactus
{
    public partial class frmOrdenCompraCarga : DevExpress.XtraEditors.XtraForm
    {
        //----------------------------------------------------------
        // CARGA_ENTORNO_VARIABLES
        public Int32 NumIntentos = 1;
        public string _base_datos = null;
        public string _usuario = null;
        //public string _password = null;
        public UsuarioReporte usuarioreporte = null;
        public static DataSet ds_user;           //Usuario        
        public static DataSet ds_luc;            //Tiendas
        public static DataSet ds_lub;            //Bodegas
        public static DataSet ds_zon;            //Zonas
        //---------------------------------------------------------------------_base, _user, _pass

        string passwordEncrypt = null;
        public string cUsuarioActual = null;
        //----------------------------------------------------------

        public string HojaXls = null;
        public string tipo_carga = string.Empty;    // "Excel", "Modificacion"

        //public string nueva_cadena = string.Empty;
        //public Int32 num_random = 0;
        //ProcesosBL objprocesoBL = new ProcesosBL();
        //DataTable dtXml = new DataTable();      // contiene las rutas de los xml
        //DataTable dtDetail = new DataTable();   // lineas generadas de los xml
        //DataTable dtMaster = new DataTable();   // lineas generadas de los xml
        //DataTable dtExcel = new DataTable();
        //XmlDocument doc = new XmlDocument();
        //XmlDocument doc_tmp = new XmlDocument();
        //public string fileXml = string.Empty;

        public string varAplicacion = "";
        public string varAplicacionDescripcion = "";
        public string varAplicacionTipo = "";


        public string _PROCESAR;
        public string _VALIDACION;
        public string _SHIPTO = "";
        public string _NUMERO_PEDIDO = "";
        public DateTime _FECHA_PEDIDO;
        public string _MONEDA = "";
        public Decimal _TOTAL = 0;
        public string _CODIGO = "";
        public Decimal _CANTIDAD = 0;
        public Decimal _PRECIO = 0;
        public Decimal _IGV = 0;
        public DateTime _FECHA_ENTREGA;
        public string _RUBRO3 = "";
        public string _RUBRO5 = "";
        public Decimal _TOTAL_MERCADERIA = 0;
        public Decimal _TOTAL_IMPUESTO = 0;
        public Decimal _TOTAL_ORDEN = 0;

        public string varSHIPTO = "";
        public string varNUMERO_PEDIDO = "";
        public DateTime varFECHA_PEDIDO;
        public string varMONEDA = "";
        public Decimal varTOTAL = 0;
        public string varCODIGO = "";
        public Decimal varCANTIDAD = 0;
        public Decimal varPRECIO = 0;
        public Decimal varIGV = 0;
        public DateTime varFECHA_ENTREGA;
        public string varRUBRO3 = "";
        public string varRUBRO5 = "";


        public string cTabXls = null;
        public Boolean _primera_vez = true;
        public Decimal _TIPO_CAMBIO;
        public DateTime _FECHA_PROCESO;
        public Boolean PrimeraVez = true;
        public string ItemFactSeleccionado = string.Empty;
        public DateTime dFechaProceso { get; set; }

        public string varPEDIDO_ACTUAL = "";
        public string varPEDIDO_NUEVO = "";

        public Decimal acumSUBTOTAL = 0;
        public Decimal acumIMPUESTO = 0;
        public Decimal acumTOTAL = 0;

        DataTable dtExcel = new DataTable();
        DataTable dtMaster = new DataTable();
        DataTable dtDetail = new DataTable();

        public OrdenCompra orden_compra = null;
        public OrdenCompraLinea orden_linea = null;
        public string UsuarioComprador = string.Empty;

        public Int32 num_random = 0;
        public string sql_tmp_carga_oc = string.Empty;

        public frmOrdenCompraCarga(string _base, string _user)
        {
            InitializeComponent();

            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
            //_password = _pass;      // txtPassword.Text;
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmOrdenCompraCarga m_FormDefInstance;
        private static string _base;
        private static string _user;
        /// Instancia por defecto
        public static frmOrdenCompraCarga DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmOrdenCompraCarga(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmOrdenCompraCarga_Load(object sender, EventArgs e)
        {
            //--------------------------------------
            // CARGA_ENTORNO_VARIABLES
            //passwordEncrypt = GeneralLibCS.cifrarTextoAES(_password, Global.v_palabraPaso, Global.v_valorRGBSalt, Global.v_algoritmoEncriptacionHASH, Global.v_iteraciones, Global.v_vectorInicial, Global.v_tamanoClave);
            //AccederEntornoReportesApssa(_base_datos, _usuario, passwordEncrypt);
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //--------------------------------------               

            //seteo general
            varAplicacion = "Carga Orden Compra";              // "FondoFijo" , "EntregaRendir";
            varAplicacionDescripcion = "Carga Orden Compra";   // "Fondo Fijo", "Entrega a Rendir";

            xtraTabControlMain.Text = varAplicacionDescripcion;
            xtraTabPageMainExcel.Text = varAplicacionDescripcion;
            xtraTabPageMainBrowse.Text = "~";
            xtraTabPageSecondaryExcel.PageEnabled = true;	//documentos

            deFechaProceso.Text = DateTime.Now.ToString();

            _primera_vez = true;
            CargaGrillaVaciaExcel();
            CargaGrillaVaciaDetail();
            CargaGrillaVaciaMaster();
            cTabXls = "Carga";
            chkDetail.CheckState = CheckState.Unchecked;
            //
            //TipoSalida = "FAC";
            //SubTipoSalida = "0";

            ////usuario comprador
            //UsuarioComprador = RecuperarUsuarioComprador(Global.vUserUsuario);
            //txtUsuarioComprador.Text = UsuarioComprador;

            if ( (UsuarioComprador!="") && (UsuarioComprador.Length != 0) )
            {
                lblUsuarioCompradorMensaje.Text = "";
                lblUsuarioCompradorMensaje.Visible = false;
                btnExcelProcesar.Enabled = true;
            }
            else
            {
                lblUsuarioCompradorMensaje.Text = "ATENCION: El usuario debe estar registrado como usuario Comprador en el ERP Exactus.";
                lblUsuarioCompradorMensaje.Visible = true;
                lblUsuarioCompradorMensaje.ForeColor = Color.Red;
                btnExcelProcesar.Enabled = false;
                btnExcelProcesar.ForeColor = Color.Gray;
            }

            ObtenerusuarioActual();

            txtUsuarioActual.Text = cUsuarioActual;
            txtUsuarioActual.Enabled = false;

            _primera_vez = false;

        }

        //---------------------------------------------------------------------------------------------


        public void ObtenerusuarioActual()
        {
            //cUsuarioActual = LogisticaDL.ObtenerUsuarioActualExactus_BL(Global.vUserBaseDatos);
            cUsuarioActual = LogisticaBL.ObtenerUsuarioActualExactus_BL(Global.vUserBaseDatos);
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de Usuario ....", "Espere por favor.."))
            //{                
            //}
        }



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

                        //usuario comprador
                        UsuarioComprador = RecuperarUsuarioComprador(Global.vUserUsuario);
                        txtUsuarioComprador.Text = UsuarioComprador;

                        txtUsuario.Text = UsuarioComprador;     // Global.vUserUsuario;
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

        public string RecuperarUsuarioComprador(string _usuario_exactus)
        {
            //btnExcelLoad
            string _usuario_comprador = "";
            _usuario_comprador = LogisticaBL.ObtenerUsuarioCompradorBL(_usuario_exactus, Global.vUserBaseDatos);

            return _usuario_comprador ;
        }


        #region CARGA_ARCHIVO_EXCEL

        public void CargaGrillaVaciaExcel()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
            {
                dtExcel = LogisticaBL.dtListarCamposExcelOrdenCompra_BL(Global.vUserBaseDatos);
                gcExcel.DataSource = dtExcel;
                ConfiguraGridExcel();
            }
        }

        private void btnBuscar_Xls_Click(object sender, EventArgs e)
        {
            CargaArchivoXls();
        }

        private void txtPathXls_DoubleClick(object sender, EventArgs e)
        {
            CargaArchivoXls();
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {

            dFechaProceso = Convert.ToDateTime(deFechaProceso.Text);

            _FECHA_PROCESO = dFechaProceso;


            if (gvExcel.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Proceso de Carga de " + varAplicacionDescripcion + "."
                                                       + "\n"
                                                       + "\nEsta seguro de Cargar, la informacion se sobreescribirá ?", "Carga de Hoja de Excel", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        CargarInformacionXls();
                        //CorrigeCodigoSubTipo(1, "");
                        //actualizo el grid control 
                        gcExcel.RefreshDataSource();
                        MessageBox.Show("Se sobreescribió las Lineas de la Orden");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                CargarInformacionXls();
            }

            // valida informacion
            if (gvExcel.RowCount > 0)
            {
                //CorrigeCodigoSubTipo(1, "");
                ValidarArchivoXLS("SinMensaje");        // MAXMAX 10/08/2017
            }

        }
        public void CargarInformacionXls()
        {
            if (cboHojas.SelectedItem != null)
            {
                HojaXls = cboHojas.SelectedItem.ToString();

                if ((txtPathXls.Text == "") || (txtPathXls.Text.Substring(0, 2) == "<<"))
                {
                    MessageBox.Show("Debe seleccionar el archivo Excel");
                }
                else if ((cboHojas.Text == "") || (cboHojas.Text.Substring(0, 2) == "<<"))
                {
                    MessageBox.Show("Seleccione la hoja a cargar");
                }
                else
                {
                    try
                    {
                        CargarExcel(txtPathXls.Text, HojaXls);
                        tipo_carga = "Excel";
                        //txtTipoCarga.Text = tipo_carga.ToUpper();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Archivo de Excel y una Hoja, para realizar la carga.", "Carga Archivo Excel");
            }
        }

        public void CargarExcel(string _XlsRuta, string _XlsHoja)
        {
            DataTable dtExcel = new DataTable();
            dtExcel = LogisticaBL.CargaExcel_BL(_XlsRuta, _XlsHoja).Tables[0];
            //eliminamos registro en blanco
            for (int i = dtExcel.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtExcel.Rows[i];
                if ((dr["SHIPTO"] == null) || (dr["SHIPTO"].ToString() == ""))
                    dr.Delete();
            }

            //establece el source de la grilla
            gcExcel.DataSource = dtExcel;
            ConfiguraGridExcel();
            gcExcel.Refresh();
        }

        public void CargaArchivoXls()
        {
            string FileXls = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                FileXls = openFileDialog1.FileName;

            if (FileXls != null)
            {
                Excel.Application ExcelApp = new Excel.Application();
                Excel.Workbook ExcelWorkbook = default(Excel.Workbook);

                ExcelWorkbook = ExcelApp.Workbooks.Open(Filename: FileXls);

                foreach (Excel.Worksheet sheet in ExcelWorkbook.Worksheets)
                {
                    cboHojas.Items.Add(sheet.Name);
                    txtPathXls.Text = FileXls;
                }

                ExcelWorkbook.Close();
                ExcelWorkbook = null;

                ExcelApp.Quit();
                ExcelApp = null;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Archivo de Excel y luego una Hoja, para realizar la carga.", "Carga Orden de Compra");
            }
        }

        public void ConfiguraGridExcel()
        {
            gvExcel.Appearance.Row.Font = new System.Drawing.Font(gvExcel.Appearance.Row.Font, FontStyle.Bold);
            gvExcel.Appearance.Row.Options.UseFont = true;
            System.Drawing.Font fnt = new System.Drawing.Font(gvExcel.Appearance.Row.Font.Name, 7);
            gvExcel.Appearance.HeaderPanel.Font = fnt;
            gvExcel.Appearance.Row.Font = fnt;
            gvExcel.OptionsView.ShowGroupPanel = false;
            gvExcel.OptionsView.ColumnAutoWidth = false;
            gvExcel.BestFitColumns();

            // COLOR
            //gvExcel.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["VALIDACION"].AppearanceCell.ForeColor = Color.Red;
            gvExcel.Columns["SHIPTO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["NUMERO_PEDIDO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["FECHA_PEDIDO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["TOTAL"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["CODIGO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["CANTIDAD"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["PRECIO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["IGV"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["FECHA_ENTREGA"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["RUBRO3"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["RUBRO5"].AppearanceCell.BackColor = Color.Bisque;
        }

        public void ActualizarGrid()
        {
            Int32 k;
            for (k = 0; k < gvExcel.RowCount; k++)
            {
                DataRow row = gvExcel.GetDataRow(k);
                gvExcel.SetRowCellValue(k, "V", "*");
                //gvExcel.SetRowCellValue(k, "IDPERIODO", Convert.ToInt32(txtIdPeriodo.Text));
            }

            gcExcel.RefreshDataSource();
        }

        private void btnExcelValidar_Click(object sender, EventArgs e)
        {
            //CorrigeCodigoSubTipo(1, "");
            ValidarArchivoXLS("ConMensaje");
        }

        private void ActualizaGrillaArchivoXLS(int nFila, string cError)
        {
            // ACTUALIZO GRILLA
            try
            {
                Int32 j;
                for (j = 0; j < gvExcel.RowCount; j++)
                {
                    if (j == nFila)
                    {
                        gvExcel.SetRowCellValue(j, "VALIDACION", cError);
                    }
                }

                //actualizo el grid control 
                gcExcel.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcelExportar_Click(object sender, EventArgs e)
        {
            if (gvExcel.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel " + varAplicacionDescripcion + "--> ERP Exactus");
                return;
            }
            else
            {
                gcExcel.ShowPrintPreview();
            }
        }

        private void btnExcelProcesar_Click(object sender, EventArgs e)
        {
            int[] seleccionadosx;
            seleccionadosx = gvExcel.GetSelectedRows();

            if (seleccionadosx.GetLength(0) <= 0)
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + varAplicacionDescripcion + "");
            }
            else
            {
                ProcesarLineasExcelSeleccionados();
                CrearDataTableMaster();
                UpdateGridDetail();

                gcMaster.RefreshDataSource();
                //MessageBox.Show("Se sobreescribió las Lineas de la Orden");
            }
        }

        public void ProcesarLineasExcelSeleccionados()
        {

            Boolean procesar = true;

            ValidarArchivoXLS("SinMensaje");

            //procesa rows
            int[] seleccionados;
            seleccionados = gvExcel.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando informacion ....", "Espere por favor.."))
                {
                    DataRow rowxls;

                    foreach (int row in seleccionados)
                    {
                        rowxls = gvExcel.GetDataRow(row);

                        if (rowxls["VALIDACION"] != null && rowxls["VALIDACION"].ToString() != "")
                        {
                            procesar = false;
                        }

                    }

                    // si todo OK                          // Procesa informacion
                    if (procesar == true)
                    {
                        DialogResult dlgProcesar = MessageBox.Show("Se procesara unicamente los archivos que NO tengan Validacion Errónea"
                                                                + "\n "
                                                                + "\nEsta seguro de Procesar la informacion?", "Carga Excel " + varAplicacionDescripcion + " --> ERP Exactus", MessageBoxButtons.YesNo);

                        if (dlgProcesar == DialogResult.Yes)
                        {
                            try
                            {
                                if (gvDetail.RowCount > 0)
                                {
                                    for (int i = 0; i < gvDetail.RowCount;)
                                        gvDetail.DeleteRow(i);
                                }

                                ProcesarArchivoExcelOrdenCompra();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe corregir los errores o seleccionar solo los registros sin error de validacion", "Validacion Erronea.!!!");
                    }
                }

                ValidarPedidos2Exactus("SinMensaje");

            }
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + varAplicacionDescripcion + "");
            //}
        }

        /*
        public void ConfiguraGrid()
        {
            gvExcel.Appearance.Row.Font = new System.Drawing.Font(gvExcel.Appearance.Row.Font, FontStyle.Bold);
            gvExcel.Appearance.Row.Options.UseFont = true;
            System.Drawing.Font fnt = new System.Drawing.Font(gvExcel.Appearance.Row.Font.Name, 7);
            gvExcel.Appearance.HeaderPanel.Font = fnt;
            gvExcel.Appearance.Row.Font = fnt;
            gvExcel.OptionsView.ShowGroupPanel = false;
            gvExcel.OptionsView.ColumnAutoWidth = false;
            gvExcel.BestFitColumns();

            // COLOR
            gvExcel.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
            gvExcel.Columns["PROVEEDOR"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["TIPO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["DOCUMENTO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["FECHA_DOC"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["APLICACION"].AppearanceCell.BackColor = Color.Azure;
            gvExcel.Columns["SUBTOTAL"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["IMPUESTO1"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["MONTO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["CONDICION_PAGO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;
            //ADICIONAL
            //DESTINO
            //DESCRIPCION_CUENTA
            //SUCURSAL
            //SCC
            gvExcel.Columns["ADICIONAL"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["MONTO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["DESTINO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["DESCRIPCION_CUENTA"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["SUCURSAL"].AppearanceCell.BackColor = Color.Azure;
            gvExcel.Columns["SCC"].AppearanceCell.BackColor = Color.Azure;

            //gvExcel.Columns["SALDO"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["SUBTIPO"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["CENTRO_COSTO"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["CUENTA_CONTABLE"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["FECHA_CONTABLE"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["RUBRO_8_DOC"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["PAQUETE"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["TIPO_ASIENTO"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["TIPO_REFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["DOC_REFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["BASE_IMPUESTO1"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["EMBARQUE"].AppearanceCell.BackColor = Color.LightSalmon;
            //gvExcel.Columns["USUARIO"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["FECHA_VENCE"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["EMB_REFERENCIA"].AppearanceCell.BackColor = Color.LightGray;
            //gvExcel.Columns["EMB_RUBRO1"].AppearanceCell.BackColor = Color.LightGray;
            //gvExcel.Columns["EMB_NOTAS"].AppearanceCell.BackColor = Color.LightGray;
            //gvExcel.Columns["EMB_CONDICIONPAGO"].AppearanceCell.BackColor = Color.LightGray;
            //gvExcel.Columns["EMB_MONTO_LOCAL"].AppearanceCell.BackColor = Color.LightGray;
            //gvExcel.Columns["EMB_MONTO_DOLAR"].AppearanceCell.BackColor = Color.LightGray;
            //gvExcel.Columns["XML_ITEMS"].AppearanceCell.BackColor = Color.LightGray;
        }
        */

        private void InicializaVariablesXLS()
        {
            _PROCESAR = "";
            _VALIDACION = "";
            _SHIPTO = "";
            _NUMERO_PEDIDO = "";
            DateTime? _FECHA_PEDIDO = null;
            _MONEDA = "";
            _TOTAL = 0;
            _CODIGO = "";
            _CANTIDAD = 0;
            _PRECIO = 0;
            _IGV = 0;
            DateTime? _FECHA_ENTREGA = null;
            _RUBRO3 = "";
            _RUBRO5 = "";

        }

        public void ProcesarArchivoExcelOrdenCompra()
        {
            //procesa rows
            int[] seleccionados;
            seleccionados = gvExcel.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivo Excel ....", "Espere por favor.."))
                {

                    DataRow rowxls;

                    foreach (int row in seleccionados)
                    {
                        rowxls = gvExcel.GetDataRow(row);

                        if ((rowxls["SHIPTO"] != null) && (rowxls["SHIPTO"].ToString() != ""))
                        {
                            if (rowxls["NUMERO_PEDIDO"] != null && rowxls["NUMERO_PEDIDO"].ToString() != "")
                            {
                                if (rowxls["CODIGO"] != null && rowxls["CODIGO"].ToString() != "")
                                {
                                    _SHIPTO = (DBNull.Value.Equals(rowxls["SHIPTO"])) ? String.Empty : rowxls["SHIPTO"].ToString();
                                    _NUMERO_PEDIDO = (DBNull.Value.Equals(rowxls["NUMERO_PEDIDO"])) ? String.Empty : rowxls["NUMERO_PEDIDO"].ToString();
                                    _FECHA_PEDIDO = (DBNull.Value.Equals(rowxls["FECHA_PEDIDO"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_PEDIDO"].ToString());
                                    _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
                                    _TOTAL = (DBNull.Value.Equals(rowxls["TOTAL"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL"].ToString());
                                    _CODIGO = (DBNull.Value.Equals(rowxls["CODIGO"])) ? String.Empty : rowxls["CODIGO"].ToString();
                                    _CANTIDAD = (DBNull.Value.Equals(rowxls["CANTIDAD"])) ? 0 : Convert.ToDecimal(rowxls["CANTIDAD"].ToString());
                                    _PRECIO = (DBNull.Value.Equals(rowxls["PRECIO"])) ? 0 : Convert.ToDecimal(rowxls["PRECIO"].ToString());
                                    _IGV = (DBNull.Value.Equals(rowxls["IGV"])) ? 0 : Convert.ToDecimal(rowxls["IGV"].ToString());
                                    _FECHA_ENTREGA = (DBNull.Value.Equals(rowxls["FECHA_ENTREGA"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_ENTREGA"].ToString());
                                    _RUBRO3 = (DBNull.Value.Equals(rowxls["RUBRO3"])) ? String.Empty : rowxls["RUBRO3"].ToString();
                                    _RUBRO5 = (DBNull.Value.Equals(rowxls["RUBRO5"])) ? String.Empty : rowxls["RUBRO5"].ToString();

                                    //MessageBox.Show("verificando excel....");
                                    //Validacion con Valores por omision       //MAXMAX
                                    if (_TIPO_CAMBIO == 0)
                                    {
                                        _TIPO_CAMBIO = ContabilidadBL.ObtenerTipoCambioFechaBL("TVTA", _FECHA_PROCESO, Global.vUserBaseDatos);
                                    }

                                    //Agrega Items al DataTable
                                    AgregarFilaGrillaDetail();

                                }

                            }
                        }

                    }
                }

                //MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel " + varAplicacionDescripcion + "");

                //xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;
                xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryDetail;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + varAplicacionDescripcion + "");
            }

        }

        private void ValidarArchivoXLS(string _MostarMensaje)
        {
            string cMensajeError = "";

            string _shipto = "";
            string _numero_pedido = "";
            DateTime _fecha_pedido;
            string _moneda = "";
            Decimal _total = 0;
            string _codigo = "";
            Decimal _cantidad = 0;
            Decimal _precio = 0;
            Decimal _igv = 0;
            DateTime _fecha_entrega;
            string _rubro3 = "";
            string _rubro5 = "";

            if (gvExcel.DataRowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel " + varAplicacionDescripcion + "");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Carga Excel " + varAplicacionDescripcion + ""))
                {
                    for (int i = 0; i < gvExcel.DataRowCount; ++i)
                    {
                        DataRow row = gvExcel.GetDataRow(i);

                        cMensajeError = "";

                        if (row["SHIPTO"] != null && row["SHIPTO"].ToString() != "")
                        {
                            if (row["NUMERO_PEDIDO"] != null && row["NUMERO_PEDIDO"].ToString() != "")
                            {
                                if (row["CODIGO"] != null && row["CODIGO"].ToString() != "")
                                {
                                    _shipto = (DBNull.Value.Equals(row["SHIPTO"])) ? String.Empty : row["SHIPTO"].ToString();
                                    _numero_pedido = (DBNull.Value.Equals(row["NUMERO_PEDIDO"])) ? String.Empty : row["NUMERO_PEDIDO"].ToString();
                                    _fecha_pedido = (DBNull.Value.Equals(row["FECHA_PEDIDO"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_PEDIDO"].ToString());
                                    _moneda = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
                                    _total = (DBNull.Value.Equals(row["TOTAL"])) ? 0 : Convert.ToDecimal(row["TOTAL"].ToString());
                                    _codigo = (DBNull.Value.Equals(row["CODIGO"])) ? String.Empty : row["CODIGO"].ToString();
                                    _cantidad = (DBNull.Value.Equals(row["CANTIDAD"])) ? 0 : Convert.ToDecimal(row["CANTIDAD"].ToString());
                                    _precio = (DBNull.Value.Equals(row["PRECIO"])) ? 0 : Convert.ToDecimal(row["PRECIO"].ToString());
                                    _igv = (DBNull.Value.Equals(row["IGV"])) ? 0 : Convert.ToDecimal(row["IGV"].ToString());
                                    _fecha_entrega = (DBNull.Value.Equals(row["FECHA_ENTREGA"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_ENTREGA"].ToString());
                                    _rubro3 = (DBNull.Value.Equals(row["RUBRO3"])) ? String.Empty : row["RUBRO3"].ToString();
                                    _rubro5 = (DBNull.Value.Equals(row["RUBRO5"])) ? String.Empty : row["RUBRO5"].ToString();

                                    //aqui
                                    gvExcel.SetRowCellValue(i, "VALIDACION", cMensajeError);
                                    cMensajeError = "";

                                }
                            }
                        }
                    }
                }

                if (_MostarMensaje == "ConMensaje")
                    MessageBox.Show("Validación Finalizada !!! ");
            }

        }


        #endregion


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
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControlMain.SelectedTabPage.Text == "Carga")
            {
                cTabXls = "Carga";
            }
            else if (xtraTabControlMain.SelectedTabPage.Text == "Browse")
            {
                cTabXls = "Browse";
            }
            else if (xtraTabControlMain.SelectedTabPage.Text == "Xml")
            {
                cTabXls = "Xml";
            }

        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            switch (xtraTabControlMain.SelectedTabPage.Text)
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

        #endregion


        #region DETAIL
        public void CargaGrillaVaciaDetail()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
            {
                dtDetail = LogisticaBL.dtListarCamposExactusOrdenCompra_BL(Global.vUserBaseDatos);
                gcDetail.DataSource = dtDetail;
                ConfiguraGridDetail();
            }
        }
        public void AgregarFilaGrillaDetail()
        {
            DataTable dt = gcDetail.DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["PROCESAR"] = _PROCESAR;
            newRow["VALIDACION"] = _VALIDACION;

            newRow["SHIPTO"] = _SHIPTO;
            newRow["NUMERO_PEDIDO"] = _NUMERO_PEDIDO;
            newRow["FECHA_PEDIDO"] = _FECHA_PEDIDO;
            newRow["MONEDA"] = _MONEDA;
            newRow["TOTAL"] = _TOTAL;
            newRow["CODIGO"] = _CODIGO;
            newRow["CANTIDAD"] = _CANTIDAD;
            newRow["PRECIO"] = _PRECIO;
            newRow["IGV"] = _IGV;
            newRow["FECHA_ENTREGA"] = _FECHA_ENTREGA;
            newRow["RUBRO3"] = _RUBRO3;
            newRow["RUBRO5"] = _RUBRO5;
            dt.Rows.InsertAt(newRow, 0);
        }
        public void ConfiguraGridDetail()
        {
            //agrego checkbox            
            gvDetail.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvDetail_CustomRowCellEdit);
            RepositoryItemCheckEdit repositoryCheckEdit1 = gcDetail.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            repositoryCheckEdit1.Name = "CheckGenerar";
            repositoryCheckEdit1.ValueChecked = "True";
            repositoryCheckEdit1.ValueUnchecked = "False";
            gvDetail.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;

            gvDetail.OptionsView.ColumnAutoWidth = false;
            gvDetail.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gvDetail.Appearance.Row.Font.Name, 7);
            gvDetail.Appearance.HeaderPanel.Font = fnt;
            gvDetail.Appearance.Row.Font = fnt;
            gvDetail.Appearance.Row.Options.UseFont = true;
            gvDetail.OptionsView.ShowGroupPanel = false;
            gvDetail.OptionsView.ShowIndicator = false;
            gvDetail.OptionsBehavior.Editable = true;  //false;
            gvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;

            // COLOR
            gvDetail.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Bisque;


            gvDetail.Columns["SHIPTO"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["NUMERO_PEDIDO"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["FECHA_PEDIDO"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["TOTAL"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["CODIGO"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["CANTIDAD"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["PRECIO"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["IGV"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["FECHA_ENTREGA"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["RUBRO3"].AppearanceCell.BackColor = Color.Bisque;
            gvDetail.Columns["RUBRO5"].AppearanceCell.BackColor = Color.Bisque;

            //formateo
            gvDetail.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDetail.Columns["TOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDetail.Columns["CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDetail.Columns["CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDetail.Columns["PRECIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDetail.Columns["PRECIO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDetail.Columns["IGV"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDetail.Columns["IGV"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //ordenamiento
            gvDetail.ClearSorting();
            gvDetail.Columns["NUMERO_PEDIDO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }
        private void gvDetail_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {


        }
        private void chkDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDetail.Checked)
            {
                // actualiza embarque
                try
                {
                    Int32 j;
                    for (j = 0; j < gvDetail.RowCount; j++)
                    {
                        gvDetail.SetRowCellValue(j, "PROCESAR", true);
                    }

                    gcDetail.RefreshDataSource();

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
                    for (j = 0; j < gvDetail.RowCount; j++)
                    {
                        gvDetail.SetRowCellValue(j, "PROCESAR", false);
                    }

                    gcDetail.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnDetailValidar_Click(object sender, EventArgs e)
        {
            ValidarPedidos2Exactus("ConMensaje");
        }
        private void ValidarPedidos2Exactus(string _OpcionMensaje)
        {
            ValidarPedidos2ExactusOrdenCompra(_OpcionMensaje);
        }
        private void ValidarPedidos2ExactusOrdenCompra(string _MostarMensajeValidacion)
        {
            string cMensajeValidacion = "";


            if (gvDetail.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel " + varAplicacionDescripcion + " --> ERP Exactus");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando Información....Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus", "Espere por favor.."))
                {

                    for (int i = 0; i < gvDetail.DataRowCount; ++i)
                    {
                        DataRow row = gvDetail.GetDataRow(i);

                        if (row["SHIPTO"] != null && row["SHIPTO"].ToString() != "")
                        {
                            if ((row["NUMERO_PEDIDO"] != null) && (row["NUMERO_PEDIDO"].ToString() != ""))
                            {
                                //actualizar Grilla
                                gvDetail.SetRowCellValue(i, "VALIDACION", cMensajeValidacion);
                                cMensajeValidacion = "";
                            }
                        }

                    }

                }

                if (_MostarMensajeValidacion == "ConMensaje")
                    MessageBox.Show("Validación Finalizada !!! ");
            }

        }
        private void btnDetailExportar_Click(object sender, EventArgs e)
        {
            if (gvDetail.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
                return;
            }
            else
            {

                gcDetail.ShowPrintPreview();
            }
        }


        //private void btnCargar2Exactus_Click(object sender, EventArgs e)
        //{
        //CargaPedido2Exactus();
        //}


        //private void CargaPedido2Exactus()
        //{
        //    if (gvDetail.RowCount <= 0)
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
        //                    varSHIPTO = "";
        //                    varNUMERO_PEDIDO = "";
        //                    DateTime? varFECHA_PEDIDO = null;
        //                    varMONEDA = "";
        //                    varTOTAL = 0;
        //                    varCODIGO = "";
        //                    varCANTIDAD = 0;
        //                    varPRECIO = 0;
        //                    varIGV = 0;
        //                    DateTime? varFECHA_ENTREGA = null;
        //                    varRUBRO3 = "";
        //                    varRUBRO5 = "";
        //                    //MAXMAX

        //                    // INGRESA DOCUMENTOS_CAJA
        //                    for (int i = 0; i < gvDetail.DataRowCount; ++i)
        //                    {
        //                        DataRow row = gvDetail.GetDataRow(i);

        //                        if (row["PROCESAR"] != System.DBNull.Value)
        //                        {
        //                            if (Convert.ToBoolean(row["PROCESAR"]) == true)
        //                            {
        //                                if (row["SHIPTO"] != null && row["SHIPTO"].ToString() != "")
        //                                {
        //                                    if ((row["NUMERO_PEDIDO"] != null) && (row["NUMERO_PEDIDO"].ToString() != ""))
        //                                    {
        //                                        varSHIPTO = row["SHIPTO"].ToString();
        //                                        varNUMERO_PEDIDO = row["NUMERO_PEDIDO"].ToString();
        //                                        varFECHA_PEDIDO = Convert.ToDateTime(row["FECHA_PEDIDO"]);
        //                                        varMONEDA = row["MONEDA"].ToString();
        //                                        varTOTAL = Convert.ToDecimal(row["TOTAL"]);
        //                                        varCODIGO = row["CODIGO"].ToString();
        //                                        varCANTIDAD = Convert.ToDecimal(row["CANTIDAD"]);
        //                                        varPRECIO = Convert.ToDecimal(row["PRECIO"]);
        //                                        varIGV = Convert.ToDecimal(row["IGV"]);
        //                                        varFECHA_ENTREGA = Convert.ToDateTime(row["FECHA_ENTREGA"]);
        //                                        varRUBRO3 = row["RUBRO3"].ToString();
        //                                        varRUBRO5 = row["RUBRO5"].ToString();
        //                                        //MAXMAX

        //                                        MessageBox.Show("Procesando Pedido " + varNUMERO_PEDIDO);

        //                                        ////UPDATE 2022-07-11  (EMBARQUE)
        //                                        //ContabilidadBL.dtCargaFondoFijoV3_BL(varDOCUMENTO, varTIPO, varSUBTIPODOC, varFECHA_DOCUMENTO, varFECHA_CONTABLE, varCONTRIBUYENTE,
        //                                        //                                      varMONEDA, varTIPO_CAMBIO, varSUBTOTAL, varDESCUENTO, varIGV,
        //                                        //                                      varIMPUESTO2, varINAFECTO, varRUBRO2, varMONTO, varCUENTA_BANCO,
        //                                        //                                      varCUENTA_CONTABLE, varCENTRO_COSTO, varEMBARQUE, varAPLICACION, varFECHA_PROCESO,
        //                                        //                                      varUSUARIO, TipoOperacionCajaChica, FondoFijo, Global.vUserBaseDatos);
        //                                    }
        //                                }
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


        private void btnDetailJson_Click(object sender, EventArgs e)
        {
            //DataTableToJSONWithJSONNet(dtDetail);
            GenerarJSON();
        }




        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        private void btnCrearMaster_Click(object sender, EventArgs e)
        {
            CrearDataTableMaster();
        }


        private void CrearDataTableMaster()
        {
            //procesa rows
            int[] seleccionados;
            seleccionados = gvExcel.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivo Excel ....", "Espere por favor.."))
                {

                    varSHIPTO = "";
                    varNUMERO_PEDIDO = "";
                    DateTime? varFECHA_PEDIDO = null;
                    varMONEDA = "";
                    varTOTAL = 0;
                    varCODIGO = "";
                    varCANTIDAD = 0;
                    varPRECIO = 0;
                    varIGV = 0;
                    DateTime? varFECHA_ENTREGA = null;
                    varRUBRO3 = "";
                    varRUBRO5 = "";

                    Decimal acumTOTAL = 0;
                    Decimal acumSUBTOTAL = 0;
                    Decimal acumIMPUESTO = 0;

                    DataRow rowxls;

                    foreach (int row in seleccionados)
                    {
                        rowxls = gvExcel.GetDataRow(row);

                        if ((rowxls["SHIPTO"] != null) && (rowxls["SHIPTO"].ToString() != ""))
                        {
                            if (rowxls["NUMERO_PEDIDO"] != null && rowxls["NUMERO_PEDIDO"].ToString() != "")
                            {
                                if (rowxls["CODIGO"] != null && rowxls["CODIGO"].ToString() != "")
                                {
                                    _SHIPTO = (DBNull.Value.Equals(rowxls["SHIPTO"])) ? String.Empty : rowxls["SHIPTO"].ToString();
                                    _NUMERO_PEDIDO = (DBNull.Value.Equals(rowxls["NUMERO_PEDIDO"])) ? String.Empty : rowxls["NUMERO_PEDIDO"].ToString();
                                    _FECHA_PEDIDO = (DBNull.Value.Equals(rowxls["FECHA_PEDIDO"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_PEDIDO"].ToString());
                                    _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
                                    _TOTAL = (DBNull.Value.Equals(rowxls["TOTAL"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL"].ToString());
                                    _CODIGO = (DBNull.Value.Equals(rowxls["CODIGO"])) ? String.Empty : rowxls["CODIGO"].ToString();
                                    _CANTIDAD = (DBNull.Value.Equals(rowxls["CANTIDAD"])) ? 0 : Convert.ToDecimal(rowxls["CANTIDAD"].ToString());
                                    _PRECIO = (DBNull.Value.Equals(rowxls["PRECIO"])) ? 0 : Convert.ToDecimal(rowxls["PRECIO"].ToString());
                                    _IGV = (DBNull.Value.Equals(rowxls["IGV"])) ? 0 : Convert.ToDecimal(rowxls["IGV"].ToString());
                                    _FECHA_ENTREGA = (DBNull.Value.Equals(rowxls["FECHA_ENTREGA"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_ENTREGA"].ToString());
                                    _RUBRO3 = (DBNull.Value.Equals(rowxls["RUBRO3"])) ? String.Empty : rowxls["RUBRO3"].ToString();
                                    _RUBRO5 = (DBNull.Value.Equals(rowxls["RUBRO5"])) ? String.Empty : rowxls["RUBRO5"].ToString();

                                    //Validacion con Valores por omision       //MAXMAX
                                    if (_TIPO_CAMBIO == 0)
                                    {
                                        _TIPO_CAMBIO = ContabilidadBL.ObtenerTipoCambioFechaBL("TVTA", _FECHA_PROCESO, Global.vUserBaseDatos);
                                    }

                                    //string cadSearchExpression = "SHIPTO = '331065' AND NUMERO_PEDIDO = '4000125952' ";
                                    string cadSearchExpression = "SHIPTO = '" + _SHIPTO + "' AND NUMERO_PEDIDO = '" + _NUMERO_PEDIDO + "' ";
                                    string cadSortOrder = "SHIPTO, NUMERO_PEDIDO ASC";
                                    DataRow[] foundRows = dtMaster.Select(cadSearchExpression, cadSortOrder);

                                    if (foundRows.Length == 0)
                                        AgregarFilaTableMaster();
                                }

                            }
                        }

                    }

                    AcumulaPorShiptoPedido();
                    //refresca
                    gcMaster.DataSource = dtMaster;
                    UpdateGridMaster();

                }

                MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel " + varAplicacionDescripcion + "");

                //xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;
                xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryDetail;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + varAplicacionDescripcion + "");
            }

        }


        private void AcumulaPorShiptoPedido()
        {
            //recorremos el datatable dtDetail
            for (int i = 0; i < dtMaster.Rows.Count; i++)
            {
                string _shipto = string.Empty;
                string _numero_pedido = string.Empty;

                //acumulados por SHIPTO y NUMERO_PEDIDO
                Decimal _acumTOTAL = 0;
                Decimal _acumSUBTOTAL = 0;
                Decimal _acumIMPUESTO = 0;

                _shipto = dtMaster.Rows[i]["SHIPTO"].ToString();
                _numero_pedido = dtMaster.Rows[i]["NUMERO_PEDIDO"].ToString();

                string _SearchExpression = "SHIPTO = '" + _shipto + "' AND NUMERO_PEDIDO = '" + _numero_pedido + "' ";
                string _SortOrder = "SHIPTO, NUMERO_PEDIDO ASC";

                DataRow[] foundRows;

                foundRows = dtDetail.Select(_SearchExpression, _SortOrder);

                // Print column 0 of each returned row.
                for (int j = 0; j < foundRows.Length; j++)
                {
                    _acumTOTAL += Convert.ToDecimal(Convert.ToDecimal(foundRows[j]["TOTAL"]));
                    _acumSUBTOTAL += (Convert.ToDecimal(foundRows[j]["CANTIDAD"]) * Convert.ToDecimal(foundRows[j]["PRECIO"]));
                    _acumIMPUESTO += (_acumTOTAL - _acumSUBTOTAL);
                }

                //reemplaza valores acumulados
                dtMaster.Rows[i]["TOTAL"] = _acumTOTAL;
                dtMaster.Rows[i]["SUBTOTAL"] = _acumSUBTOTAL;
                dtMaster.Rows[i]["IMPUESTO"] = (_acumTOTAL - _acumSUBTOTAL);   //_acumIMPUESTO; 
            }

        }


        private void UpdateGridMaster()
        {
            gcMaster.RefreshDataSource();

            //try
            //{
            //    Int32 j;
            //    for (j = 0; j < gvMaster.RowCount; j++)
            //    {
            //        gvMaster.SetRowCellValue(j, "REAJUSTE", 777);
            //        //gvMaster.SetRowCellValue(j, "TIPO_EQUIPO_CS", varTIPO_EQUIPO_CS);
            //        //gvMaster.SetRowCellValue(j, "USUARIO_MODIFICA", varUSUARIO);
            //        //gvMaster.SetRowCellValue(j, "DETALLE_FALLA", varDETALLE_FALLA);
            //        //gvMasters.SetRowCellValue(j, "SOLUCION_FALLA", varSOLUCION_FALLA);
            //        //gvMaster.SetRowCellValue(j, "CONFIRMADA", varCONFIRMADA);
            //    }

            //    //actualizo el grid control 
            //    gcMaster.RefreshDataSource();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        public void AgregarFilaTableMaster()
        {
            //DataTable dt = gcDetail.DataSource as DataTable;
            //DataTable dtMaster = new DataTable();
            DataRow newRow = dtMaster.NewRow();
            newRow["PROCESAR"] = _PROCESAR;
            newRow["VALIDACION"] = _VALIDACION;
            newRow["SHIPTO"] = _SHIPTO;
            newRow["NUMERO_PEDIDO"] = _NUMERO_PEDIDO;
            newRow["FECHA_PEDIDO"] = _FECHA_PEDIDO;
            newRow["MONEDA"] = _MONEDA;
            newRow["SUBTOTAL"] = 0;
            newRow["IMPUESTO"] = 0;
            newRow["TOTAL"] = 0;
            newRow["FECHA_ENTREGA"] = _FECHA_ENTREGA;
            newRow["RUBRO3"] = _RUBRO3;
            newRow["RUBRO5"] = _RUBRO5;
            dtMaster.Rows.InsertAt(newRow, 0);
        }

        private void CargarDataTableMaster()
        {
            if (gvDetail.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Cargar a DataTable");
                return;
            }
            else
            {
                try
                {
                    //PROCESO GRABA
                    DialogResult dialogResult = MessageBox.Show("Carga Excel " + varAplicacionDescripcion + " --> ERP Exactus."
                                                           + "\n"
                                                           + "\nEsta seguro de Procesar la informacion?", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Carga Excel " + varAplicacionDescripcion + " --> ERP Exactus", "Espere por favor.."))
                        {
                            varSHIPTO = "";
                            varNUMERO_PEDIDO = "";
                            DateTime? varFECHA_PEDIDO = null;
                            varMONEDA = "";
                            varTOTAL = 0;
                            varCODIGO = "";
                            varCANTIDAD = 0;
                            varPRECIO = 0;
                            varIGV = 0;
                            DateTime? varFECHA_ENTREGA = null;
                            varRUBRO3 = "";
                            varRUBRO5 = "";

                            varPEDIDO_ACTUAL = "";
                            varPEDIDO_NUEVO = "";

                            acumSUBTOTAL = 0;
                            acumIMPUESTO = 0;
                            acumTOTAL = 0;

                            for (int i = 0; i < gvDetail.DataRowCount; ++i)
                            {
                                DataRow row = gvDetail.GetDataRow(i);

                                if (row["PROCESAR"] != System.DBNull.Value)
                                {
                                    if (Convert.ToBoolean(row["PROCESAR"]) == true)
                                    {
                                        if (row["SHIPTO"] != null && row["SHIPTO"].ToString() != "")
                                        {
                                            if ((row["NUMERO_PEDIDO"] != null) && (row["NUMERO_PEDIDO"].ToString() != ""))
                                            {
                                                varSHIPTO = row["SHIPTO"].ToString();
                                                varNUMERO_PEDIDO = row["NUMERO_PEDIDO"].ToString();
                                                varFECHA_PEDIDO = Convert.ToDateTime(row["FECHA_PEDIDO"]);
                                                varMONEDA = row["MONEDA"].ToString();
                                                varCODIGO = row["CODIGO"].ToString();
                                                varFECHA_ENTREGA = Convert.ToDateTime(row["FECHA_ENTREGA"]);
                                                varRUBRO3 = row["RUBRO3"].ToString();
                                                varRUBRO5 = row["RUBRO5"].ToString();
                                                varCANTIDAD = Convert.ToDecimal(row["CANTIDAD"]);       // OK
                                                varPRECIO = Convert.ToDecimal(row["PRECIO"]);           // OK
                                                varIGV = Convert.ToDecimal(row["IGV"]);                 // OK
                                                varTOTAL = Convert.ToDecimal(row["TOTAL"]);             // OK

                                                //MessageBox.Show("Procesando Pedido " + varNUMERO_PEDIDO);

                                                if (varNUMERO_PEDIDO == varPEDIDO_NUEVO)
                                                {
                                                    //acumula
                                                    acumSUBTOTAL = acumSUBTOTAL + (varCANTIDAD * varIGV);
                                                    acumIMPUESTO = acumIMPUESTO + varIGV;
                                                    acumTOTAL = acumTOTAL + ((varCANTIDAD * varIGV) + varIGV);
                                                }
                                                else
                                                {
                                                    AgregarFilaGrillaMaster();
                                                    varPEDIDO_NUEVO = varNUMERO_PEDIDO;
                                                    //acumula
                                                    acumSUBTOTAL = acumSUBTOTAL + (varCANTIDAD * varIGV);
                                                    acumIMPUESTO = acumIMPUESTO + varIGV;
                                                    acumTOTAL = acumTOTAL + ((varCANTIDAD * varIGV) + varIGV);
                                                }

                                                //public string varPEDIDO_ACTUAL = "";
                                                //public string varPEDIDO_NUEVO = "";
                                            }
                                        }
                                    }
                                }

                            }

                        }
                        //
                        MessageBox.Show("Proceso Finalizado !!!", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void AgregarFilaGrillaMaster()
        {
            DataTable dt = gcMaster.DataSource as DataTable;
            DataRow newFila = dt.NewRow();
            newFila["PROCESAR"] = _PROCESAR;
            newFila["VALIDACION"] = _VALIDACION;

            newFila["SHIPTO"] = _SHIPTO;
            newFila["NUMERO_PEDIDO"] = _NUMERO_PEDIDO;
            newFila["FECHA_PEDIDO"] = _FECHA_PEDIDO;
            newFila["MONEDA"] = _MONEDA;
            newFila["TOTAL"] = _TOTAL;
            newFila["CODIGO"] = _CODIGO;
            newFila["CANTIDAD"] = _CANTIDAD;
            newFila["PRECIO"] = _PRECIO;
            newFila["IGV"] = _IGV;
            newFila["FECHA_ENTREGA"] = _FECHA_ENTREGA;
            newFila["RUBRO3"] = _RUBRO3;
            newFila["RUBRO5"] = _RUBRO5;
            dt.Rows.InsertAt(newFila, 0);
        }

        #endregion


        #region MASTER

        public void ConfiguraGridMaster()
        {
            //agrego checkbox            
            gvMaster.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvMaster_CustomRowCellEdit);
            RepositoryItemCheckEdit repositoryCheckEdit1 = gcDetail.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            repositoryCheckEdit1.Name = "CheckGenerar";
            repositoryCheckEdit1.ValueChecked = "True";
            repositoryCheckEdit1.ValueUnchecked = "False";
            gvMaster.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;

            gvMaster.OptionsView.ColumnAutoWidth = false;
            gvMaster.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gvMaster.Appearance.Row.Font.Name, 7);
            gvMaster.Appearance.HeaderPanel.Font = fnt;
            gvMaster.Appearance.Row.Font = fnt;
            gvMaster.Appearance.Row.Options.UseFont = true;
            gvMaster.OptionsView.ShowGroupPanel = false;
            gvMaster.OptionsView.ShowIndicator = false;
            gvMaster.OptionsBehavior.Editable = true;  //false;
            gvMaster.OptionsSelection.EnableAppearanceFocusedCell = false;

            // COLOR
            gvMaster.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Bisque;

            gvMaster.Columns["SHIPTO"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["NUMERO_PEDIDO"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["FECHA_PEDIDO"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["SUBTOTAL"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["IMPUESTO"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["TOTAL"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["FECHA_ENTREGA"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["RUBRO3"].AppearanceCell.BackColor = Color.Bisque;
            gvMaster.Columns["RUBRO5"].AppearanceCell.BackColor = Color.Bisque;

            //formateo
            gvMaster.Columns["SUBTOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMaster.Columns["SUBTOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvMaster.Columns["IMPUESTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMaster.Columns["IMPUESTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvMaster.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMaster.Columns["TOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //ordenamiento
            gvMaster.ClearSorting();
            gvMaster.Columns["NUMERO_PEDIDO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }

        private void gvMaster_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

        }
        public void CargaGrillaVaciaMaster()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
            {
                dtMaster = LogisticaBL.dtListarCamposExactusOrdenCompraMaster_BL(Global.vUserBaseDatos);
                gcMaster.DataSource = dtMaster;
                ConfiguraGridMaster();
            }
        }
        private void btnMasterCargar2Exactus_Click(object sender, EventArgs e)
        {

        }

        private void btnMasterValidar_Click(object sender, EventArgs e)
        {

        }

        private void btnMasterExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnMasterJson_Click(object sender, EventArgs e)
        {

        }

        private void txtPathXls_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMasterJson_Click_1(object sender, EventArgs e)
        {
            //GenerarJSON();
            GenerarJSONv2();
        }

        public void GenerarJSONv2()
        {
            string _shipto = string.Empty;
            string _numero_pedido = string.Empty;

            if (orden_compra == null)
                orden_compra = new OrdenCompra();


            //recorremos el datatable dtMaster
            for (int i = 0; i < dtMaster.Rows.Count; i++)
            {
                DataSet dsOC = new DataSet();

                _shipto = dtMaster.Rows[i]["SHIPTO"].ToString();
                _numero_pedido = dtMaster.Rows[i]["NUMERO_PEDIDO"].ToString();

                string _SearchExpression = "SHIPTO = '" + _shipto + "' AND NUMERO_PEDIDO = '" + _numero_pedido + "' ";
                string _SortOrder = "SHIPTO, NUMERO_PEDIDO ASC";

                //MAESTRO
                DataTable OrdenCompra = new DataTable();
                OrdenCompra = dtMaster.Clone();
                OrdenCompra.TableName = "OrdenCompra";
                dsOC.Tables.Add(OrdenCompra);
                DataRow[] drResultsCab;
                drResultsCab = dtMaster.Select(_SearchExpression, _SortOrder);
                foreach (DataRow dr in drResultsCab)
                {
                    object[] row = dr.ItemArray;
                    OrdenCompra.Rows.Add(row);
                }


                //DETALLE
                DataTable OrdenCompraLinea = new DataTable();
                OrdenCompraLinea = dtDetail.Clone();
                OrdenCompraLinea.TableName = "OrdenCompraLinea";
                dsOC.Tables.Add(OrdenCompraLinea);
                DataRow[] drResultsDet;
                drResultsDet = dtDetail.Select(_SearchExpression, _SortOrder);
                foreach (DataRow dr in drResultsDet)
                {
                    object[] row = dr.ItemArray;
                    OrdenCompraLinea.Rows.Add(row);
                }

                JsonSerializerSettings settings = new JsonSerializerSettings();
                //settings.Converters.Add(new CustomDataSetConverter());
                settings.Formatting = Newtonsoft.Json.Formatting.Indented;

                //string json = JsonConvert.SerializeObject(x, settings);
                string json = JsonConvert.SerializeObject(dsOC, settings);
                json = json.Replace('"', '\"');
                object jsonObj = JsonConvert.DeserializeObject(json);
                //var listProductos = JsonConvert.DeserializeObject<List<ExpandoObject>>(productos);
                //LogisticaBL.CargarOrdenesCompraTest2_BL("CABANILLAS", jsonObj, Global.vUserBaseDatos);

                LogisticaBL.CargarJSON_BL(json, Global.vUserBaseDatos);
                MessageBox.Show("JSON generado.", "Cargar Orden de Compra");

            }

            MessageBox.Show("Carga completada!!!.", "Cargar Orden de Compra");

        }


        //Console.WriteLine(json);
        //LogisticaBL.CargarOrdenesCompraV2_DL("CABANILLAS", json, Global.vUserBaseDatos);
        //dtCargarOrdenesCompraV2_BL(string _usuario, string _json, string db)
        //LogisticaBL.dtCargarOrdenesCompraV2_BL("CABANILLAS", json, Global.vUserBaseDatos);
        //bool grabar = LogisticaBL.CargarOrdenesCompraV2_BL("CABANILLAS", json, Global.vUserBaseDatos);

        //LogisticaBL.CargarOrdenesCompraTest1_BL("CABANILLAS", json, Global.vUserBaseDatos);


        public void GenerarJSON()
        {

            string _shipto = string.Empty;
            string _numero_pedido = string.Empty;

            if (orden_compra == null)
                orden_compra = new OrdenCompra();


            //recorremos el datatable dtMaster
            for (int i = 0; i < dtMaster.Rows.Count; i++)
            {
                orden_compra.shipto = dtMaster.Rows[i]["SHIPTO"].ToString();
                orden_compra.numero_pedido = dtMaster.Rows[i]["NUMERO_PEDIDO"].ToString();
                orden_compra.fecha_pedido = Convert.ToDateTime(dtMaster.Rows[i]["FECHA_PEDIDO"]);
                orden_compra.moneda = dtMaster.Rows[i]["MONEDA"].ToString();
                orden_compra.subtotal = Convert.ToDecimal(dtMaster.Rows[i]["SUBTOTAL"]);
                orden_compra.impuesto = Convert.ToDecimal(dtMaster.Rows[i]["IMPUESTO"]);
                orden_compra.total = Convert.ToDecimal(dtMaster.Rows[i]["TOTAL"]);
                orden_compra.fecha_entrega = Convert.ToDateTime(dtMaster.Rows[i]["FECHA_ENTREGA"]);
                orden_compra.rubro3 = dtMaster.Rows[i]["RUBRO3"].ToString();
                orden_compra.rubro5 = dtMaster.Rows[i]["RUBRO5"].ToString();

                _shipto = dtMaster.Rows[i]["SHIPTO"].ToString();
                _numero_pedido = dtMaster.Rows[i]["NUMERO_PEDIDO"].ToString();

                string _SearchExpression = "SHIPTO = '" + _shipto + "' AND NUMERO_PEDIDO = '" + _numero_pedido + "' ";
                string _SortOrder = "SHIPTO, NUMERO_PEDIDO ASC";

                if (orden_linea == null)
                    orden_linea = new OrdenCompraLinea();

                DataRow[] foundRows;

                foundRows = dtDetail.Select(_SearchExpression, _SortOrder);

                for (int k = 0; k < foundRows.Length; k++)
                {

                    orden_linea.shipto = dtDetail.Rows[k]["SHIPTO"].ToString();
                    orden_linea.numero_pedido = dtDetail.Rows[k]["NUMERO_PEDIDO"].ToString();
                    orden_linea.fecha_pedido = Convert.ToDateTime(dtDetail.Rows[k]["FECHA_PEDIDO"]);
                    orden_linea.moneda = dtDetail.Rows[k]["MONEDA"].ToString();
                    orden_linea.total = Convert.ToDecimal(dtDetail.Rows[k]["TOTAL"]);
                    orden_linea.codigo = dtDetail.Rows[k]["CODIGO"].ToString();
                    orden_linea.cantidad = Convert.ToDecimal(dtDetail.Rows[k]["CANTIDAD"]);
                    orden_linea.precio = Convert.ToDecimal(dtDetail.Rows[k]["PRECIO"]);
                    orden_linea.igv = Convert.ToDecimal(dtDetail.Rows[k]["IGV"]);
                    orden_linea.fecha_entrega = Convert.ToDateTime(dtDetail.Rows[k]["FECHA_ENTREGA"]);
                    orden_linea.rubro3 = dtDetail.Rows[k]["RUBRO3"].ToString();
                    orden_linea.rubro5 = dtDetail.Rows[k]["RUBRO5"].ToString();

                }

                //orden_compra.Detalle = orden_linea;
                orden_compra.OrdenDetalle.Add(orden_linea);
            }

            //TO json
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(orden_compra);
            //return JSONString;
            MessageBox.Show("JSON generado.", "Cargar Orden de Compra");
        }

        private void btnMasterCargar2Exactus_Click_1(object sender, EventArgs e)
        {
            GenerarJSONv2();
        }

        private void btnTestJSON_Click(object sender, EventArgs e)
        {
            //LogisticaBL.TestCargarJSON_BL(Global.vUserBaseDatos);


            LogisticaBL.TestCargarJSON_BL(Global.vUserBaseDatos);

            MessageBox.Show("Carga completada!!!.", "TEST Cargar JSON");
        }

        private void btnDetailCargar2Exactus_Click(object sender, EventArgs e)
        {
            ///GrabarDetailLine();
            Random rnd = new Random();
            num_random = rnd.Next(10000000, 99999999);
            sql_tmp_carga_oc = "DBO.BORRAR_TMP_CARGA_OC_" + num_random.ToString();

            CrearTablaTemporalCargaOC(sql_tmp_carga_oc);
            CargarTablaTemporalCargaOC2(sql_tmp_carga_oc);
            //cargar tablas
            RecuperarTablaTemporalCargaOC(sql_tmp_carga_oc);

            LogisticaBL.CargarOrdenCompra_BL(sql_tmp_carga_oc, "LISTAR", Global.vUserBaseDatos);

            xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryDetail;

        }

        private void GrabarDetailLine()
        {
            //procesa rows
            int[] seleccionadosOK;
            seleccionadosOK = gvDetail.GetSelectedRows();

            if (seleccionadosOK.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivo Excel ....", "Espere por favor.."))
                {

                    _SHIPTO = "";
                    _NUMERO_PEDIDO = "";
                    DateTime? _FECHA_PEDIDO = null;
                    _MONEDA = "";
                    _TOTAL = 0;
                    _CODIGO = "";
                    _CANTIDAD = 0;
                    _PRECIO = 0;
                    _IGV = 0;
                    DateTime? _FECHA_ENTREGA = null;
                    _RUBRO3 = "";
                    _RUBRO5 = "";

                    _TOTAL_MERCADERIA = 0;
                    _TOTAL_IMPUESTO = 0;
                    _TOTAL_ORDEN = 0;

                    DataRow rowxls;

                    foreach (int row in seleccionadosOK)
                    {
                        rowxls = gvDetail.GetDataRow(row);

                        if ((rowxls["SHIPTO"] != null) && (rowxls["SHIPTO"].ToString() != ""))
                        {
                            if (rowxls["NUMERO_PEDIDO"] != null && rowxls["NUMERO_PEDIDO"].ToString() != "")
                            {
                                if (rowxls["CODIGO"] != null && rowxls["CODIGO"].ToString() != "")
                                {
                                    _SHIPTO = (DBNull.Value.Equals(rowxls["SHIPTO"])) ? String.Empty : rowxls["SHIPTO"].ToString();
                                    _NUMERO_PEDIDO = (DBNull.Value.Equals(rowxls["NUMERO_PEDIDO"])) ? String.Empty : rowxls["NUMERO_PEDIDO"].ToString();
                                    _FECHA_PEDIDO = (DBNull.Value.Equals(rowxls["FECHA_PEDIDO"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_PEDIDO"].ToString());
                                    _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
                                    _TOTAL = (DBNull.Value.Equals(rowxls["TOTAL"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL"].ToString());
                                    _CODIGO = (DBNull.Value.Equals(rowxls["CODIGO"])) ? String.Empty : rowxls["CODIGO"].ToString();
                                    _CANTIDAD = (DBNull.Value.Equals(rowxls["CANTIDAD"])) ? 0 : Convert.ToDecimal(rowxls["CANTIDAD"].ToString());
                                    _PRECIO = (DBNull.Value.Equals(rowxls["PRECIO"])) ? 0 : Convert.ToDecimal(rowxls["PRECIO"].ToString());
                                    _IGV = (DBNull.Value.Equals(rowxls["IGV"])) ? 0 : Convert.ToDecimal(rowxls["IGV"].ToString());
                                    _FECHA_ENTREGA = (DBNull.Value.Equals(rowxls["FECHA_ENTREGA"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_ENTREGA"].ToString());
                                    _RUBRO3 = (DBNull.Value.Equals(rowxls["RUBRO3"])) ? String.Empty : rowxls["RUBRO3"].ToString();
                                    _RUBRO5 = (DBNull.Value.Equals(rowxls["RUBRO5"])) ? String.Empty : rowxls["RUBRO5"].ToString();

                                    _TOTAL_MERCADERIA = (DBNull.Value.Equals(rowxls["TOTAL_MERCADERIA"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL_MERCADERIA"].ToString());
                                    _TOTAL_IMPUESTO = (DBNull.Value.Equals(rowxls["TOTAL_IMPUESTO"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL_IMPUESTO"].ToString());
                                    _TOTAL_ORDEN = (DBNull.Value.Equals(rowxls["TOTAL_ORDEN"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL_ORDEN"].ToString());


                                    ////Validacion con Valores por omision       //MAXMAX
                                    //if (_TIPO_CAMBIO == 0)
                                    //{
                                    //    _TIPO_CAMBIO = ContabilidadBL.ObtenerTipoCambioFechaBL("TVTA", _FECHA_PROCESO, Global.vUserBaseDatos);
                                    //}

                                    ////string cadSearchExpression = "SHIPTO = '331065' AND NUMERO_PEDIDO = '4000125952' ";
                                    //string cadSearchExpression = "SHIPTO = '" + _SHIPTO + "' AND NUMERO_PEDIDO = '" + _NUMERO_PEDIDO + "' ";
                                    //string cadSortOrder = "SHIPTO, NUMERO_PEDIDO ASC";
                                    //DataRow[] foundRows = dtMaster.Select(cadSearchExpression, cadSortOrder);

                                    //if (foundRows.Length == 0)
                                    //    AgregarFilaTableMaster();
                                }

                            }
                        }

                    }

                    AcumulaPorShiptoPedido();
                    //refresca
                    gcMaster.DataSource = dtMaster;
                    UpdateGridMaster();

                }

                MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel " + varAplicacionDescripcion + "");

                //xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;
                xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryDetail;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + varAplicacionDescripcion + "");
            }

        }


        #endregion


        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            UpdateGridDetail();
        }

        private void UpdateGridDetail()
        {
            //acumulados por SHIPTO y NUMERO_PEDIDO
            Decimal _acumSUBTOTAL = 0;
            Decimal _acumIMPUESTO = 0;
            Decimal _acumTOTAL = 0;
            string _shipto = string.Empty;
            string _numero_pedido = string.Empty;
            //string _SearchExpression = "";
            //string _SortOrder = "";

            //recorremos el datatable dtMaster
            for (int i = 0; i < dtMaster.Rows.Count; i++)
            {
                _shipto = dtMaster.Rows[i]["SHIPTO"].ToString();
                _numero_pedido = dtMaster.Rows[i]["NUMERO_PEDIDO"].ToString();
                _acumSUBTOTAL = Convert.ToDecimal(dtMaster.Rows[i]["SUBTOTAL"]);
                _acumIMPUESTO = Convert.ToDecimal(dtMaster.Rows[i]["IMPUESTO"]);
                _acumTOTAL = Convert.ToDecimal(dtMaster.Rows[i]["TOTAL"]);


                //_SearchExpression = "SHIPTO = '" + _shipto + "' AND NUMERO_PEDIDO = '" + _numero_pedido + "' ";
                //_SortOrder = "SHIPTO, NUMERO_PEDIDO ASC";

                //DataRow[] foundRows;
                //foundRows = dtDetail.Select(_SearchExpression, _SortOrder);

                for (int j = 0; j < dtDetail.Rows.Count; j++)
                {
                    if ((dtDetail.Rows[j]["SHIPTO"].ToString() == _shipto) && (dtDetail.Rows[j]["NUMERO_PEDIDO"].ToString() == _numero_pedido))
                    {
                        dtDetail.Rows[j]["TOTAL_MERCADERIA"] = _acumSUBTOTAL;
                        dtDetail.Rows[j]["TOTAL_IMPUESTO"] = _acumIMPUESTO;
                        dtDetail.Rows[j]["TOTAL_ORDEN"] = _acumTOTAL;
                    }
                }

            }

            //refresh
            gcDetail.RefreshDataSource();

        }

        private void btnCargaTemporal_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            num_random = rnd.Next(10000000, 99999999);
            sql_tmp_carga_oc = "DBO.BORRAR_TMP_CARGA_OC_" + num_random.ToString();

            CrearTablaTemporalCargaOC(sql_tmp_carga_oc);
            CargarTablaTemporalCargaOC2(sql_tmp_carga_oc);
            //cargar tablas
            RecuperarTablaTemporalCargaOC(sql_tmp_carga_oc);

            LogisticaBL.CargarOrdenCompra_BL(sql_tmp_carga_oc, "CABANILLAS", Global.vUserBaseDatos);
        }


        public void CrearTablaTemporalCargaOC(string _sql_tmp_carga_oc)
        {
            try
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Informacion....", "Espere por favor.."))
                {
                    // crea tablas temporales
                    LogisticaBL.dsCrearTablaTemporalCargaOC_BL(_sql_tmp_carga_oc, "CREAR", Global.vUserBaseDatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarTablaTemporalCargaOC2(string _sql_tmp_carga_oc)
        {
 
            if (gvDetail.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Orden Compra  --> ERP Exactus");
                return;
            }
            else
            {

                try
                {
                    //PROCESO GRABA
                    DialogResult dialogResult = MessageBox.Show("Carga Excel Orden Compra  --> ERP Exactus."
                                                           + "\n"
                                                           + "\nEsta seguro de Procesar la informacion?", "Carga Excel Orden Compra  --> ERP Exactus", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Carga Excel Orden Compra  --> ERP Exactus", "Espere por favor.."))
                        {
                            for (int i = 0; i < gvDetail.DataRowCount; ++i)
                            {
                                DataRow row = gvDetail.GetDataRow(i);

                                if (row["PROCESAR"] != System.DBNull.Value)
                                {
                                    if (Convert.ToBoolean(row["PROCESAR"]) == true)
                                    {
                                        if ((row["SHIPTO"] != null) && (row["SHIPTO"].ToString() != ""))
                                        {
                                            if (row["NUMERO_PEDIDO"] != null && row["NUMERO_PEDIDO"].ToString() != "")
                                            {
                                                if (row["CODIGO"] != null && row["CODIGO"].ToString() != "")
                                                {
                                                    _SHIPTO = (DBNull.Value.Equals(row["SHIPTO"])) ? String.Empty : row["SHIPTO"].ToString();
                                                    _NUMERO_PEDIDO = (DBNull.Value.Equals(row["NUMERO_PEDIDO"])) ? String.Empty : row["NUMERO_PEDIDO"].ToString();
                                                    _FECHA_PEDIDO = (DBNull.Value.Equals(row["FECHA_PEDIDO"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_PEDIDO"].ToString());
                                                    _MONEDA = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
                                                    _TOTAL = (DBNull.Value.Equals(row["TOTAL"])) ? 0 : Convert.ToDecimal(row["TOTAL"].ToString());
                                                    _CODIGO = (DBNull.Value.Equals(row["CODIGO"])) ? String.Empty : row["CODIGO"].ToString();
                                                    _CANTIDAD = (DBNull.Value.Equals(row["CANTIDAD"])) ? 0 : Convert.ToDecimal(row["CANTIDAD"].ToString());
                                                    _PRECIO = (DBNull.Value.Equals(row["PRECIO"])) ? 0 : Convert.ToDecimal(row["PRECIO"].ToString());
                                                    _IGV = (DBNull.Value.Equals(row["IGV"])) ? 0 : Convert.ToDecimal(row["IGV"].ToString());
                                                    _FECHA_ENTREGA = (DBNull.Value.Equals(row["FECHA_ENTREGA"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_ENTREGA"].ToString());
                                                    _RUBRO3 = (DBNull.Value.Equals(row["RUBRO3"])) ? String.Empty : row["RUBRO3"].ToString();
                                                    _RUBRO5 = (DBNull.Value.Equals(row["RUBRO5"])) ? String.Empty : row["RUBRO5"].ToString();

                                                    _TOTAL_MERCADERIA = (DBNull.Value.Equals(row["TOTAL_MERCADERIA"])) ? 0 : Convert.ToDecimal(row["TOTAL_MERCADERIA"].ToString());
                                                    _TOTAL_IMPUESTO = (DBNull.Value.Equals(row["TOTAL_IMPUESTO"])) ? 0 : Convert.ToDecimal(row["TOTAL_IMPUESTO"].ToString());
                                                    _TOTAL_ORDEN = (DBNull.Value.Equals(row["TOTAL_ORDEN"])) ? 0 : Convert.ToDecimal(row["TOTAL_ORDEN"].ToString());

                                                    LogisticaBL.CargaTablaTemporalCargaOC_BL(sql_tmp_carga_oc, _SHIPTO, _NUMERO_PEDIDO, _FECHA_PEDIDO, _MONEDA, _TOTAL, _CODIGO, _CANTIDAD, _PRECIO,
                                                                                             _IGV, _FECHA_ENTREGA, _RUBRO3, _RUBRO5, _TOTAL_MERCADERIA, _TOTAL_IMPUESTO, _TOTAL_ORDEN,
                                                                                             "CABANILLAS", Global.vUserBaseDatos);

                                                    //MessageBox.Show("Grabando registro" + _NUMERO_PEDIDO, "Carga Excel " + varAplicacionDescripcion + "");

                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }

                        //
                        //xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryDetail;
                        //xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryTest;
                        MessageBox.Show("Proceso Finalizado !!!", "Carga Orden Compra  --> ERP Exactus");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
   


        }
        private void CargarTablaTemporalCargaOC(string _sql_tmp_carga_oc)
        {
            //procesa rows
            int[] seleccionadosOK;
            seleccionadosOK = gvDetail.GetSelectedRows();

            if (seleccionadosOK.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivo Excel ....", "Espere por favor.."))
                {

                    DataRow rowxls;

                    foreach (int row in seleccionadosOK)
                    {
                        rowxls = gvDetail.GetDataRow(row);

                        if ((rowxls["SHIPTO"] != null) && (rowxls["SHIPTO"].ToString() != ""))
                        {
                            if (rowxls["NUMERO_PEDIDO"] != null && rowxls["NUMERO_PEDIDO"].ToString() != "")
                            {
                                if (rowxls["CODIGO"] != null && rowxls["CODIGO"].ToString() != "")
                                {
                                    _SHIPTO = (DBNull.Value.Equals(rowxls["SHIPTO"])) ? String.Empty : rowxls["SHIPTO"].ToString();
                                    _NUMERO_PEDIDO = (DBNull.Value.Equals(rowxls["NUMERO_PEDIDO"])) ? String.Empty : rowxls["NUMERO_PEDIDO"].ToString();
                                    _FECHA_PEDIDO = (DBNull.Value.Equals(rowxls["FECHA_PEDIDO"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_PEDIDO"].ToString());
                                    _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
                                    _TOTAL = (DBNull.Value.Equals(rowxls["TOTAL"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL"].ToString());
                                    _CODIGO = (DBNull.Value.Equals(rowxls["CODIGO"])) ? String.Empty : rowxls["CODIGO"].ToString();
                                    _CANTIDAD = (DBNull.Value.Equals(rowxls["CANTIDAD"])) ? 0 : Convert.ToDecimal(rowxls["CANTIDAD"].ToString());
                                    _PRECIO = (DBNull.Value.Equals(rowxls["PRECIO"])) ? 0 : Convert.ToDecimal(rowxls["PRECIO"].ToString());
                                    _IGV = (DBNull.Value.Equals(rowxls["IGV"])) ? 0 : Convert.ToDecimal(rowxls["IGV"].ToString());
                                    _FECHA_ENTREGA = (DBNull.Value.Equals(rowxls["FECHA_ENTREGA"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_ENTREGA"].ToString());
                                    _RUBRO3 = (DBNull.Value.Equals(rowxls["RUBRO3"])) ? String.Empty : rowxls["RUBRO3"].ToString();
                                    _RUBRO5 = (DBNull.Value.Equals(rowxls["RUBRO5"])) ? String.Empty : rowxls["RUBRO5"].ToString();

                                    _TOTAL_MERCADERIA = (DBNull.Value.Equals(rowxls["TOTAL_MERCADERIA"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL_MERCADERIA"].ToString());
                                    _TOTAL_IMPUESTO = (DBNull.Value.Equals(rowxls["TOTAL_IMPUESTO"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL_IMPUESTO"].ToString());
                                    _TOTAL_ORDEN = (DBNull.Value.Equals(rowxls["TOTAL_ORDEN"])) ? 0 : Convert.ToDecimal(rowxls["TOTAL_ORDEN"].ToString());

                                    LogisticaBL.CargaTablaTemporalCargaOC_BL(sql_tmp_carga_oc, _SHIPTO, _NUMERO_PEDIDO, _FECHA_PEDIDO, _MONEDA, _TOTAL, _CODIGO, _CANTIDAD, _PRECIO,
                                                                             _IGV, _FECHA_ENTREGA, _RUBRO3, _RUBRO5, _TOTAL_MERCADERIA, _TOTAL_IMPUESTO, _TOTAL_ORDEN,
                                                                             "CABANILLAS", Global.vUserBaseDatos);


                                }

                            }
                        }

                        MessageBox.Show("Grabando registro"+ _NUMERO_PEDIDO, "Carga Excel " + varAplicacionDescripcion + "");

                    }

                    //AcumulaPorShiptoPedido();
                    //refresca
                    //gcMaster.DataSource = dtMaster;
                    //UpdateGridMaster();

                }

                MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel " + varAplicacionDescripcion + "");

                //xtraTabControlSecondary.SelectedTabPage = xtraTabPageSecondaryDetail;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + varAplicacionDescripcion + "");
            }

        }


        public void RecuperarTablaTemporalCargaOC(string _sql_tmp_carga_oc)
        {
            DataTable dtTest = new DataTable();
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo registros...", "Procesando Información"))
            {
                dtTest = LogisticaBL.dtListarTablaTemporalCargaOC_BL(_sql_tmp_carga_oc, "LISTAR", Global.vUserBaseDatos);   //dtListarTablaTemporalCargaOC_BL(string _file, string _opcion, string db)
            }

            gcTest.DataSource = dtTest;
            ConfiguraGridTest();
        }

        public void ConfiguraGridTest()
        {
            gvTest.Appearance.Row.Font = new System.Drawing.Font(gvTest.Appearance.Row.Font, FontStyle.Bold);
            gvTest.Appearance.Row.Options.UseFont = true;
            System.Drawing.Font fnt = new System.Drawing.Font(gvTest.Appearance.Row.Font.Name, 7);
            gvTest.Appearance.HeaderPanel.Font = fnt;
            gvTest.Appearance.Row.Font = fnt;
            gvTest.OptionsView.ShowGroupPanel = false;
            gvTest.OptionsView.ColumnAutoWidth = false;
            gvTest.BestFitColumns();

        }




        /*
        using Newtonsoft.JSON;

        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JSONConvert.SerializeObject(table);
            return JSONString;
        }
        */

    }
}
//EOF