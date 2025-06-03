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

//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;

//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;



namespace ApssaExactus
{
    public partial class frmCargaFacturaCPv5 : DevExpress.XtraEditors.XtraForm
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
        public string cTabXls = null;
        public string tipo_carga = string.Empty;    // "Excel", "Modificacion"
        public Boolean PrimeraVez = true;


        public string ItemFactSeleccionado = string.Empty;       // archivo seleccionado en gvFactura
        ////public string _articulo_cuenta = string.Empty;
        ////public string _articulo_familia = string.Empty;
        ////public Boolean ProcesarTodos = false;
        ////public string exactus_tipo_documento = string.Empty;
        ////public string exactus_tipo_referencia = string.Empty;

        //////leer PDF
        ////string stringPdfFile = string.Empty;
        ////string stringPdfOutput = string.Empty;

        ////// EXCEL
        ////string _PROVEEDOR = "";
        ////string _TIPO = "";
        ////string _DOCUMENTO = "";
        ////DateTime _FECHA_DOC;
        ////DateTime _FECHA_CONTABLE;
        ////DateTime _FECHA_RIGE;   // ADD 2022-12-16
        ////string _EMBARQUE = "";
        ////string _MONEDA = "";
        ////string _CONDICION_PAGO = "";
        //////DateTime _FECHA_VENCE;
        ////Decimal _SUBTOTAL = 0;
        ////Decimal _IMPUESTO1 = 0;
        ////Decimal _MONTO = 0;
        ////string _PROCESAR = "";
        ////string _APLICACION = "";
        ////Decimal _SALDO = 0;
        ////string _SUBTIPO = "";
        ////string _CENTRO_COSTO = "";
        ////string _CUENTA_CONTABLE = "";
        ////string _RUBRO_8_DOC = "";
        ////string _PAQUETE = "";
        ////string _TIPO_ASIENTO = "";
        ////string _TIPO_REFERENCIA = "";
        ////string _DOC_REFERENCIA = "";
        ////Decimal _BASE_IMPUESTO1 = 0;
        ////DateTime _FECHA_VENCE;
        ////string _USUARIO = "";
        ////Decimal _EMB_MONTO_LOCAL = 0;
        ////Decimal _EMB_MONTO_DOLAR = 0;
        ////string _XML_ITEMS = "";
        ////Decimal _DESCUENTO = 0;
        ////Decimal _IMPUESTO2 = 0;
        ////Decimal _RUBRO_1 = 0;
        ////Decimal _RUBRO_2 = 0;
        ////string _CUENTA_BANCARIA = "";
        ////string _NOTAS = "";
        ////string _RUBRO_1_DOC = "";
        ////string _RUBRO_2_DOC = "";
        ////string _RUBRO_3_DOC = "";
        ////string _RUBRO_4_DOC = "";
        ////string _RUBRO_5_DOC = "";
        ////string _RUBRO_6_DOC = "";
        ////string _RUBRO_7_DOC = "";
        ////string _RUBRO_9_DOC = "";
        ////string _RUBRO_10_DOC = "";
        ////string _RETENCIÓN = "";
        ////Decimal _BASE_IMPUESTO2 = 0;
        ////string _CARGADO = "";
        ////string _EMB_REFERENCIA = "";
        ////string _EMB_RUBRO1 = "";
        ////string _EMB_NOTAS = "";
        ////string _EMB_CONDICIONPAGO = "";
        ////string _EMB_PROVEEDOR = "";
        ////string _EMB_EMBARQUE = "";  //add
        ////DateTime _EMB_FECHA_EMBARQUE;  //add
        ////string _EMB_ESTADO = "";  //add
        ////DateTime _EMB_U_FECHAGUIA;  //add
        ////string _EMB_AUDIT_TRANS_INV = "";  //add
        ////string _RETENCIONES = "";  //add
        ////Decimal _DIFERENCIA = 0;

        ////DataSet ds = new DataSet();

        ////public string _EMBARQUE_OC = "";
        ////public string _TIP_DOC_REF = "";
        ////public string _NUM_DOC_REF = "";
        ////public string _DETRACCION = "";
        ////public string _VALIDACION = "";

        ////public bool EsAfectoDetraccion = false;     // si tiene reencache


        public frmCargaFacturaCPv5(string _base, string _user)
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
        private static frmCargaFacturaCPv5 m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frmCargaFacturaCPv5 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCargaFacturaCPv5(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmCargaFacturaCPv5_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------              

            //this.dpFechaProceso.Text = DateTime.Today.ToString();             
            //CargaGrillaVaciaOtros();
            cTabXls = "Carga";
            chkFacturas.CheckState = CheckState.Unchecked;
        }

        #region CARGA_ENTORNO_VARIABLES
        public void ObtenerusuarioActual()
        {
            cUsuarioActual = TesoreriaBL.ObtenerUsuarioActualExactus_BL(Global.vUserBaseDatos);

            //using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de Usuario ....", "Espere por favor.."))
            //{                
            //}
        }
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




        // CARGA
        //-------------------------------------------------------------------------

        #region CARGA_ARCHIVO_EXCEL

        private void btnBuscar_Xls_Click(object sender, EventArgs e)
        {
            CargaArchivoXls();
        }
        private void txtPathXls_DoubleClick(object sender, EventArgs e)
        {
            CargaArchivoXls();
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
                MessageBox.Show("Debe seleccionar un Archivo de Excel y luego una Hoja, para realizar la carga.", "Carga de Documentos FE");
            }
        }
        private void btnLoadXls_Click(object sender, EventArgs e)
        {
            if (gvExcel.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Proceso de Carga de Documentos FE"
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

                        MessageBox.Show("Se sobreescribió las Factura Proveedores");
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
                        txtTipoCarga.Text = tipo_carga.ToUpper();
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
            dtExcel = ComercialBL.CargaExcel(_XlsRuta, _XlsHoja).Tables[0];

            //eliminamos registro en blanco
            for (int i = dtExcel.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtExcel.Rows[i];
                if ((dr["PROVEEDOR"] == null) || (dr["PROVEEDOR"].ToString() == ""))
                    dr.Delete();
            }

            //establece el source de la grilla
            gcExcel.DataSource = dtExcel;
            ConfiguraGridExcel();
            gcExcel.Refresh();

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

//PROCESAR
//CODIGO
//SERIE
//NUMERO
//FECHA_EMISION
//MONTO
//PROVEEDOR
//VALIDACION


            // COLOR
            //gvExcel.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
            gvExcel.Columns["CODIGO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["SERIE"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["NUMERO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["FECHA_EMISION"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["MONTO"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["PROVEEDOR"].AppearanceCell.BackColor = Color.Bisque;
            gvExcel.Columns["VALIDACION"].AppearanceCell.ForeColor = Color.Red;


            gvExcel.Columns["VALIDACION"].Width = 560;


        }


        #endregion

        // EXCEL
        //-------------------------------------------------------------------------

        #region PROCESA_ARCHIVO_EXCEL
        private void btnValidarXls_Click(object sender, EventArgs e)
        {
            ValidarArchivoXLS("ConMensaje");
        }

        private void ValidarArchivoXLS(string _MostarMensaje)
        {
            string cMensajeError = "";
 
            //_procesar
            string _codigo = "";
            string _serie = "";
            string _numero = "";
            DateTime _fecha_emision;
            Decimal _monto = 0;
            string _proveedor = "";
            //_validacion

            if (gvExcel.DataRowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Documentos FE");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Carga Excel Documentos FE"))
                {
                    for (int i = 0; i < gvExcel.DataRowCount; ++i)
                    {
                        DataRow row = gvExcel.GetDataRow(i);

                        cMensajeError = "";

                        if (row["PROVEEDOR"] != null && row["PROVEEDOR"].ToString() != "")
                        {
                            if (row["CODIGO"] != null && row["CODIGO"].ToString() != "")
                            {
                                if ((row["NUMERO"] != null) && (row["NUMERO"].ToString() != ""))
                                {
                                    _codigo = (DBNull.Value.Equals(row["CODIGO"])) ? String.Empty : row["CODIGO"].ToString();
                                    _serie = (DBNull.Value.Equals(row["SERIE"])) ? String.Empty : row["SERIE"].ToString();
                                    _numero = (DBNull.Value.Equals(row["NUMERO"])) ? String.Empty : row["NUMERO"].ToString();
                                    _fecha_emision = (DBNull.Value.Equals(row["FECHA_EMISION"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_EMISION"].ToString());
                                    _monto = (DBNull.Value.Equals(row["MONTO"])) ? 0 : Convert.ToDecimal(row["MONTO"].ToString());
                                    _proveedor = (DBNull.Value.Equals(row["PROVEEDOR"])) ? String.Empty : row["PROVEEDOR"].ToString();

                                    
                                    //_embarque = (DBNull.Value.Equals(row["EMBARQUE"])) ? String.Empty : row["EMBARQUE"].ToString();
                                    //_moneda = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
                                    //_condicion_pago = (DBNull.Value.Equals(row["CONDICION_PAGO"])) ? String.Empty : row["CONDICION_PAGO"].ToString();
                                    //_fecha_contable = (DBNull.Value.Equals(row["FECHA_CONTABLE"])) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(row["FECHA_CONTABLE"].ToString());
                                    //_fecha_vence = (DBNull.Value.Equals(row["FECHA_VENCE"])) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(row["FECHA_VENCE"].ToString());
                                    //_subtotal = (DBNull.Value.Equals(row["SUBTOTAL"])) ? 0 : Convert.ToDecimal(row["SUBTOTAL"].ToString());
                                    //_impuesto1 = (DBNull.Value.Equals(row["IMPUESTO1"])) ? 0 : Convert.ToDecimal(row["IMPUESTO1"].ToString());
   

                                    //if (row["FECHA_VENCE"] == System.DBNull.Value)
                                    //{
                                    //    if (_condicion_pago != "0")
                                    //    {
                                    //        cMensajeError = cMensajeError + "/FECHA_VENCE";
                                    //    }
                                    //}

                                    //if (row["FECHA_CONTABLE"] == System.DBNull.Value)  //add 2022-12/16
                                    //{
                                    //    if (_condicion_pago != "0")
                                    //    {
                                    //        cMensajeError = cMensajeError + "/FECHA_CONTABLE";
                                    //    }
                                    //}


                                    //if (_fecha_vence == Convert.ToDateTime("01/01/1900"))
                                    //{
                                    //    if (_condicion_pago != "0")
                                    //    {
                                    //        cMensajeError = cMensajeError + "/FECHA_VENCE";
                                    //    }
                                    //}

                                    if (_proveedor == null || _proveedor == "")
                                    {
                                        cMensajeError = cMensajeError + "PROVEEDOR";
                                    }
                                    //else if (_tipo == null || _tipo == "")
                                    //{
                                    //    cMensajeError = cMensajeError + "/TIPO";
                                    //}
                                    //else if (_documento == null || _documento == "")
                                    //{
                                    //    cMensajeError = cMensajeError + "/DOCUMENTO";
                                    //}
                                    //else if (_fecha_doc == null)
                                    //{
                                    //    cMensajeError = cMensajeError + "/FECHA_DOC";
                                    //}
                                    //else if (_embarque == null || _embarque == "")
                                    //{
                                    //    cMensajeError = cMensajeError + "/EMBARQUE";
                                    //}
                                    //else if (_moneda == null || _moneda == "")
                                    //{
                                    //    cMensajeError = cMensajeError + "/MONEDA";
                                    //}
                                    //else if (_condicion_pago == null || _condicion_pago == "")
                                    //{
                                    //    cMensajeError = cMensajeError + "/CONDICION_PAGO";
                                    //}
                                    //else if (_fecha_vence == null && _condicion_pago != "0")
                                    //{
                                    //    cMensajeError = cMensajeError + "/FECHA_VENCE";
                                    //}
                                    //else if (_subtotal == 0)
                                    //{
                                    //    cMensajeError = cMensajeError + "/SUBTOTAL";
                                    //}
                                    //else if (_impuesto1 == 0)
                                    //{
                                    //    cMensajeError = cMensajeError + "/IMPUESTO1";
                                    //}
                                    //if (_monto == 0)
                                    //{
                                    //    cMensajeError = cMensajeError + "/MONTO";
                                    //}

                                    //if (_proveedor != null || _proveedor != "")
                                    //{
                                    //    if (!ContabilidadBL.ExisteProveedorBL(_proveedor, "NO", Global.vUserBaseDatos))
                                    //        cMensajeError = cMensajeError + " Error PROVEEDOR";
                                    //}

                                    //if (_embarque != null || _embarque != "")
                                    //{
                                    //    if (_embarque.Substring(0, 2) == "EM")
                                    //    {
                                    //        if (!ContabilidadBL.ExisteEmbarqueBL(_embarque, _proveedor, "NO", Global.vUserBaseDatos))
                                    //            cMensajeError = cMensajeError + " Error EMBARQUE";
                                    //    }
                                    //    else if (_embarque.Substring(0, 2) == "CS")
                                    //    {
                                    //        if (!ContabilidadBL.ExisteCompraSinOcBL("CSOC", _embarque, _proveedor, "NO", Global.vUserBaseDatos))
                                    //            cMensajeError = cMensajeError + " Error CSOC";
                                    //    }
                                    //    else if (_embarque.Substring(0, 2) == "RE")
                                    //    {
                                    //        if (!ContabilidadBL.ExisteCompraSinOcBL("RESO", _embarque, _proveedor, "NO", Global.vUserBaseDatos))
                                    //            cMensajeError = cMensajeError + " Error RESO";
                                    //    }
                                    //}

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

        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            if (gvExcel.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel Facturas Proveedores --> ERP Exactus");
                return;
            }
            else
            {
                gcExcel.ShowPrintPreview();
            }
        }

        private void btnProcesarXls_Click(object sender, EventArgs e)
        {

            Boolean procesar = true;

            ValidarArchivoXLS("SinMensaje");

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

                    if (procesar == true)
                    {
                        DialogResult dlgProcesar = MessageBox.Show("Se procesara unicamente los archivos que NO tengan Validacion Errónea"
                                                                + "\n "
                                                                + "\nEsta seguro de Procesar la informacion?", "Carga Excel Facturas Proveedores --> ERP Exactus", MessageBoxButtons.YesNo);

                        if (dlgProcesar == DialogResult.Yes)
                        {
                            try
                            {
                                if (gvFactura.RowCount > 0)
                                {
                                    for (int i = 0; i < gvFactura.RowCount;)
                                        gvFactura.DeleteRow(i);
                                }

                                ProcesarArchivosXLS();

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

                ValidarFacturas2Exactus("SinMensaje");

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel Facturas Proveedores");
            }
        }

        public void ProcesarArchivosXLS() 
        {
            //int[] seleccionados;
            //seleccionados = gvExcel.GetSelectedRows();

            //if (seleccionados.GetLength(0) > 0)
            //{
            //    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivo Excel ....", "Espere por favor.."))
            //    {
            //        DataRow rowxls;

            //        foreach (int row in seleccionados)
            //        {
            //            rowxls = gvExcel.GetDataRow(row);

            //            if (rowxls["PROVEEDOR"] != null && rowxls["PROVEEDOR"].ToString() != "")
            //            {
            //                if (rowxls["TIPO"] != null && rowxls["TIPO"].ToString() != "")
            //                {
            //                    if ((rowxls["DOCUMENTO"] != null) && (rowxls["DOCUMENTO"].ToString() != ""))
            //                    {
            //                        _PROVEEDOR = (DBNull.Value.Equals(rowxls["PROVEEDOR"])) ? String.Empty : rowxls["PROVEEDOR"].ToString();
            //                        _TIPO = (DBNull.Value.Equals(rowxls["TIPO"])) ? String.Empty : rowxls["TIPO"].ToString();
            //                        _DOCUMENTO = (DBNull.Value.Equals(rowxls["DOCUMENTO"])) ? String.Empty : rowxls["DOCUMENTO"].ToString();
            //                        _FECHA_DOC = (DBNull.Value.Equals(rowxls["FECHA_DOC"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_DOC"].ToString());
            //                        _FECHA_CONTABLE = (DBNull.Value.Equals(rowxls["FECHA_CONTABLE"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_CONTABLE"].ToString());
            //                        _FECHA_RIGE = (DBNull.Value.Equals(rowxls["FECHA_DOC"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_DOC"].ToString());
            //                        _EMBARQUE = (DBNull.Value.Equals(rowxls["EMBARQUE"])) ? String.Empty : rowxls["EMBARQUE"].ToString();
            //                        _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
            //                        _CONDICION_PAGO = (DBNull.Value.Equals(rowxls["CONDICION_PAGO"])) ? String.Empty : rowxls["CONDICION_PAGO"].ToString();
            //                        _FECHA_VENCE = (DBNull.Value.Equals(rowxls["FECHA_VENCE"])) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(rowxls["FECHA_VENCE"].ToString());                                    
            //                        _SUBTOTAL = (DBNull.Value.Equals(rowxls["SUBTOTAL"])) ? 0 : Convert.ToDecimal(rowxls["SUBTOTAL"].ToString());
            //                        _IMPUESTO1 = (DBNull.Value.Equals(rowxls["IMPUESTO1"])) ? 0 : Convert.ToDecimal(rowxls["IMPUESTO1"].ToString());
            //                        _MONTO = (DBNull.Value.Equals(rowxls["MONTO"])) ? 0 : Convert.ToDecimal(rowxls["MONTO"].ToString());
            //                        _RETENCIONES = (DBNull.Value.Equals(rowxls["RETENCIONES"])) ? String.Empty : rowxls["RETENCIONES"].ToString();


            //                        if (_EMBARQUE != null || _EMBARQUE != "")
            //                        {
            //                            if (_EMBARQUE.Substring(0, 2) == "EM")
            //                            {
            //                                DataTable dtEmbarque = new DataTable();
            //                                dtEmbarque = ContabilidadBL.dtObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "VARIOS", Global.vUserBaseDatos);
            //                                for (int k = 0; k < dtEmbarque.Rows.Count; k++)
            //                                {
            //                                    _EMB_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["EMBARQUE"])) ? String.Empty : dtEmbarque.Rows[k]["EMBARQUE"].ToString();
            //                                    _EMB_PROVEEDOR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["PROVEEDOR"])) ? String.Empty : dtEmbarque.Rows[k]["PROVEEDOR"].ToString();
            //                                    _EMB_FECHA_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["FECHA_EMBARQUE"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["FECHA_EMBARQUE"].ToString());
            //                                    _EMB_ESTADO = (DBNull.Value.Equals(dtEmbarque.Rows[k]["ESTADO"])) ? String.Empty : dtEmbarque.Rows[k]["ESTADO"].ToString();
            //                                    _EMB_REFERENCIA = ContabilidadBL.ObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "REFERENCIA", Global.vUserBaseDatos);
            //                                    _EMB_RUBRO1 = (DBNull.Value.Equals(dtEmbarque.Rows[k]["RUBRO1"])) ? String.Empty : dtEmbarque.Rows[k]["RUBRO1"].ToString();
            //                                    _EMB_NOTAS = (DBNull.Value.Equals(dtEmbarque.Rows[k]["NOTAS"])) ? String.Empty : dtEmbarque.Rows[k]["NOTAS"].ToString();
            //                                    _EMB_U_FECHAGUIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["U_FECHAGUIA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["U_FECHAGUIA"].ToString());
            //                                    _EMB_AUDIT_TRANS_INV = (DBNull.Value.Equals(dtEmbarque.Rows[k]["AUDIT_TRANS_INV"])) ? String.Empty : dtEmbarque.Rows[k]["AUDIT_TRANS_INV"].ToString();
            //                                    _EMB_MONTO_LOCAL = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_LOCAL"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_LOCAL"].ToString());
            //                                    _EMB_MONTO_DOLAR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_DOLAR"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_DOLAR"].ToString());
            //                                }
            //                            }
            //                            else if (_EMBARQUE.Substring(0, 2) == "CS")
            //                            {
            //                                DataTable dtEmbarque = new DataTable();
            //                                dtEmbarque = ContabilidadBL.dtObtieneCompraSinOcBL("CSOC", _EMBARQUE, _PROVEEDOR, "SI", Global.vUserBaseDatos);
            //                                for (int k = 0; k < dtEmbarque.Rows.Count; k++)
            //                                {
            //                                    _EMB_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["APLICACION"])) ? String.Empty : dtEmbarque.Rows[k]["APLICACION"].ToString();
            //                                    _EMB_PROVEEDOR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["PROVEEDOR"])) ? String.Empty : dtEmbarque.Rows[k]["PROVEEDOR"].ToString();
            //                                    _EMB_FECHA_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["FECHA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["FECHA"].ToString());
            //                                    _EMB_ESTADO = (DBNull.Value.Equals(dtEmbarque.Rows[k]["ESTADO"])) ? String.Empty : dtEmbarque.Rows[k]["ESTADO"].ToString();
            //                                    _EMB_REFERENCIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["REFERENCIA"])) ? String.Empty : dtEmbarque.Rows[k]["REFERENCIA"].ToString(); //ContabilidadBL.ObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "REFERENCIA", Global.vUserBaseDatos);
            //                                    _EMB_RUBRO1 = (DBNull.Value.Equals(dtEmbarque.Rows[k]["RUBRO1"])) ? String.Empty : dtEmbarque.Rows[k]["RUBRO1"].ToString();
            //                                    _EMB_NOTAS = (DBNull.Value.Equals(dtEmbarque.Rows[k]["NOTAS"])) ? String.Empty : dtEmbarque.Rows[k]["NOTAS"].ToString();
            //                                    _EMB_U_FECHAGUIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["U_FECHAGUIA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["U_FECHAGUIA"].ToString());
            //                                    _EMB_AUDIT_TRANS_INV = (DBNull.Value.Equals(dtEmbarque.Rows[k]["AUDIT_TRANS_INV"])) ? String.Empty : dtEmbarque.Rows[k]["AUDIT_TRANS_INV"].ToString();
            //                                    _EMB_MONTO_LOCAL = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_LOCAL"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_LOCAL"].ToString());
            //                                    _EMB_MONTO_DOLAR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_DOLAR"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_DOLAR"].ToString());
            //                                }
            //                            }
            //                            else if (_EMBARQUE.Substring(0, 2) == "RE")
            //                            {
            //                                //consulta RESO
            //                                DataTable dtEmbarque = new DataTable();
            //                                dtEmbarque = ContabilidadBL.dtObtieneCompraSinOcBL("RESO", _EMBARQUE, _PROVEEDOR, "SI", Global.vUserBaseDatos);
            //                                for (int k = 0; k < dtEmbarque.Rows.Count; k++)
            //                                {
            //                                    _EMB_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["APLICACION"])) ? String.Empty : dtEmbarque.Rows[k]["APLICACION"].ToString();
            //                                    _EMB_PROVEEDOR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["PROVEEDOR"])) ? String.Empty : dtEmbarque.Rows[k]["PROVEEDOR"].ToString();
            //                                    _EMB_FECHA_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["FECHA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["FECHA"].ToString());
            //                                    _EMB_ESTADO = (DBNull.Value.Equals(dtEmbarque.Rows[k]["ESTADO"])) ? String.Empty : dtEmbarque.Rows[k]["ESTADO"].ToString();
            //                                    _EMB_REFERENCIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["REFERENCIA"])) ? String.Empty : dtEmbarque.Rows[k]["REFERENCIA"].ToString(); //ContabilidadBL.ObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "REFERENCIA", Global.vUserBaseDatos);
            //                                    _EMB_RUBRO1 = (DBNull.Value.Equals(dtEmbarque.Rows[k]["RUBRO1"])) ? String.Empty : dtEmbarque.Rows[k]["RUBRO1"].ToString();
            //                                    _EMB_NOTAS = (DBNull.Value.Equals(dtEmbarque.Rows[k]["NOTAS"])) ? String.Empty : dtEmbarque.Rows[k]["NOTAS"].ToString();
            //                                    _EMB_U_FECHAGUIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["U_FECHAGUIA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["U_FECHAGUIA"].ToString());
            //                                    _EMB_AUDIT_TRANS_INV = (DBNull.Value.Equals(dtEmbarque.Rows[k]["AUDIT_TRANS_INV"])) ? String.Empty : dtEmbarque.Rows[k]["AUDIT_TRANS_INV"].ToString();
            //                                    _EMB_MONTO_LOCAL = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_LOCAL"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_LOCAL"].ToString());
            //                                    _EMB_MONTO_DOLAR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_DOLAR"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_DOLAR"].ToString());
            //                                }
            //                            }

            //                        }



            //                        string _LIN_EMBARQUE = "";
            //                        string _LIN_ORDEN_COMPRA = "";
            //                        string _LIN_MONEDA_OC = "";
            //                        string _LIN_ARTICULO = "";
            //                        string _LIN_BODEGA = "";
            //                        Decimal _LIN_CANTIDAD_EMBARCADA = 0;
            //                        Decimal _LIN_CANTIDAD_RECIBIDA = 0;
            //                        Decimal _LIN_PRECIO_UNIT_OC_LOCAL = 0;
            //                        Decimal _LIN_PRECIO_UNIT_OC_DOLAR = 0;
            //                        Decimal _LIN_TC_PRECIO_OC_LOCAL = 0;
            //                        Decimal _LIN_TC_PRECIO_OC_DOLAR = 0;
            //                        Decimal _LIN_MONTO_OC_LOCAL = 0;
            //                        Decimal _LIN_MONTO_OC_DOLAR = 0;

            //                        Decimal MontoTotalEmbarqueLocal = 0;
            //                        Decimal MontoTotalEmbarqueDolar = 0;
            //                        string EmbarqueAplicacion = "";         //  0008-MANSICHE / EM00022679 / GR/00001-0167468
            //                        string EmbarqueXmlItems = "";           //  340005  CA (20.000)   340009  CA (192.000)   

            //                        _DETRACCION = "N";      // inicializa 

            //                        //consulta EMBARQUE_LINEA/CSOC_LINEA
            //                        if (_EMBARQUE != null || _EMBARQUE != "")
            //                        {
            //                            //consulta EMBARQUE_LINEA
            //                            if (_EMBARQUE.Substring(0, 2) == "EM")
            //                            {
            //                                DataTable dtLinea = new DataTable();
            //                                dtLinea = ContabilidadBL.ObtieneDatosEmbarqueLineaOtrosBL(_EMBARQUE, Global.vUserBaseDatos);
            //                                for (int z = 0; z < dtLinea.Rows.Count; z++)
            //                                {
            //                                    _LIN_EMBARQUE = dtLinea.Rows[z]["EMBARQUE"].ToString();
            //                                    _LIN_ORDEN_COMPRA = dtLinea.Rows[z]["ORDEN_COMPRA"].ToString();
            //                                    _LIN_MONEDA_OC = dtLinea.Rows[z]["MONEDA_OC"].ToString();
            //                                    _LIN_ARTICULO = dtLinea.Rows[z]["ARTICULO"].ToString();
            //                                    _LIN_BODEGA = dtLinea.Rows[z]["BODEGA"].ToString();       //bodega
            //                                    _LIN_CANTIDAD_EMBARCADA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_EMBARCADA"]);
            //                                    _LIN_CANTIDAD_RECIBIDA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_RECIBIDA"]);
            //                                    _LIN_PRECIO_UNIT_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_LOCAL"]);
            //                                    _LIN_PRECIO_UNIT_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_DOLAR"]);
            //                                    _LIN_TC_PRECIO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_LOCAL"]);
            //                                    _LIN_TC_PRECIO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_DOLAR"]);
            //                                    _LIN_MONTO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"]);
            //                                    _LIN_MONTO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"]);

            //                                    _articulo_familia = "";
            //                                    //_articulo_familia = ContabilidadBL.ObtieneArticuloFamiliaBL(_LIN_ARTICULO, Global.vUserBaseDatos);

            //                                    _articulo_cuenta = "";
            //                                    //_articulo_cuenta = ContabilidadBL.ObtieneArticuloFamiliaCodigoBL(_LIN_ARTICULO, Global.vUserBaseDatos);

            //                                    if (_articulo_cuenta == "RE")   // reencauche
            //                                    {
            //                                        _DETRACCION = "S";
            //                                    }

            //                                    EmbarqueXmlItems = _LIN_ARTICULO + "  " + _articulo_cuenta + " (" +        //"  CA("+  // TODO prefijo por familia
            //                                                        Math.Truncate(_LIN_CANTIDAD_RECIBIDA).ToString() + ")   ";

            //                                    // acumula total embarque
            //                                    MontoTotalEmbarqueLocal += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"].ToString());
            //                                    MontoTotalEmbarqueDolar += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"].ToString());
            //                                }
            //                            }
            //                            else if (_EMBARQUE.Substring(0, 2) == "CS")  //consulta CSOC_LINEA
            //                            {
            //                                DataTable dtLinea = new DataTable();
            //                                dtLinea = ContabilidadBL.dtObtieneCompraSinOcLineaBL("CSOC", _EMBARQUE, Global.vUserBaseDatos);
            //                                for (int z = 0; z < dtLinea.Rows.Count; z++)
            //                                {
            //                                    _LIN_EMBARQUE = dtLinea.Rows[z]["APLICACION"].ToString();
            //                                    _LIN_ORDEN_COMPRA = dtLinea.Rows[z]["ORDEN_COMPRA"].ToString();
            //                                    _LIN_MONEDA_OC = dtLinea.Rows[z]["MONEDA_OC"].ToString();
            //                                    _LIN_ARTICULO = dtLinea.Rows[z]["ARTICULO"].ToString();
            //                                    _LIN_BODEGA = dtLinea.Rows[z]["BODEGA"].ToString();       //bodega
            //                                    _LIN_CANTIDAD_EMBARCADA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_EMBARCADA"]);
            //                                    _LIN_CANTIDAD_RECIBIDA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_RECIBIDA"]);
            //                                    _LIN_PRECIO_UNIT_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_LOCAL"]);
            //                                    _LIN_PRECIO_UNIT_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_DOLAR"]);
            //                                    _LIN_TC_PRECIO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_LOCAL"]);
            //                                    _LIN_TC_PRECIO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_DOLAR"]);
            //                                    _LIN_MONTO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"]);
            //                                    _LIN_MONTO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"]);

            //                                    _articulo_familia = "";
            //                                    //_articulo_familia = ContabilidadBL.ObtieneArticuloFamiliaBL(_LIN_ARTICULO, Global.vUserBaseDatos);

            //                                    _articulo_cuenta = "";
            //                                    //_articulo_cuenta = ContabilidadBL.ObtieneArticuloFamiliaCodigoBL(_LIN_ARTICULO, Global.vUserBaseDatos);

            //                                    if (_articulo_cuenta == "RE")   // reencauche
            //                                    {
            //                                        _DETRACCION = "S";
            //                                    }

            //                                    EmbarqueXmlItems = _LIN_ARTICULO + "  " + _articulo_cuenta + " (" +        //"  CA("+  // TODO prefijo por familia
            //                                                        Math.Truncate(_LIN_CANTIDAD_RECIBIDA).ToString() + ")   ";

            //                                    // acumula total embarque
            //                                    MontoTotalEmbarqueLocal += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"].ToString());
            //                                    MontoTotalEmbarqueDolar += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"].ToString());
            //                                }

            //                            }
            //                            else if (_EMBARQUE.Substring(0, 2) == "RE")  //consulta RESO_LINEA
            //                            {
            //                                DataTable dtLinea = new DataTable();
            //                                dtLinea = ContabilidadBL.dtObtieneCompraSinOcLineaBL("RESO", _EMBARQUE, Global.vUserBaseDatos);
            //                                for (int z = 0; z < dtLinea.Rows.Count; z++)
            //                                {
            //                                    _LIN_EMBARQUE = dtLinea.Rows[z]["APLICACION"].ToString();
            //                                    _LIN_ORDEN_COMPRA = dtLinea.Rows[z]["ORDEN_COMPRA"].ToString();
            //                                    _LIN_MONEDA_OC = dtLinea.Rows[z]["MONEDA_OC"].ToString();
            //                                    _LIN_ARTICULO = dtLinea.Rows[z]["ARTICULO"].ToString();
            //                                    _LIN_BODEGA = dtLinea.Rows[z]["BODEGA"].ToString();       //bodega
            //                                    _LIN_CANTIDAD_EMBARCADA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_EMBARCADA"]);
            //                                    _LIN_CANTIDAD_RECIBIDA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_RECIBIDA"]);
            //                                    _LIN_PRECIO_UNIT_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_LOCAL"]);
            //                                    _LIN_PRECIO_UNIT_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_DOLAR"]);
            //                                    _LIN_TC_PRECIO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_LOCAL"]);
            //                                    _LIN_TC_PRECIO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_DOLAR"]);
            //                                    _LIN_MONTO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"]);
            //                                    _LIN_MONTO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"]);

            //                                    _articulo_familia = "";
            //                                    //_articulo_familia = ContabilidadBL.ObtieneArticuloFamiliaBL(_LIN_ARTICULO, Global.vUserBaseDatos);

            //                                    _articulo_cuenta = "";
            //                                    //_articulo_cuenta = ContabilidadBL.ObtieneArticuloFamiliaCodigoBL(_LIN_ARTICULO, Global.vUserBaseDatos);

            //                                    if (_articulo_cuenta == "RE")   // reencauche
            //                                    {
            //                                        _DETRACCION = "S";
            //                                    }

            //                                    EmbarqueXmlItems = _LIN_ARTICULO + "  " + _articulo_cuenta + " (" +        //"  CA("+  // TODO prefijo por familia
            //                                                        Math.Truncate(_LIN_CANTIDAD_RECIBIDA).ToString() + ")   ";

            //                                    // acumula total embarque
            //                                    MontoTotalEmbarqueLocal += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"].ToString());
            //                                    MontoTotalEmbarqueDolar += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"].ToString());
            //                                }

            //                            }

            //                        }

            //                        string ctacont = "";
            //                        if (_articulo_cuenta != "")
            //                            ctacont = ContabilidadBL.ObtieneCuentaCompraArticuloBL(_articulo_cuenta, Global.vUserBaseDatos);


            //                        Decimal nDifMontos = 0;

            //                        if (_MONEDA == "USD")
            //                        {
            //                            nDifMontos = _SUBTOTAL - _EMB_MONTO_DOLAR;
            //                        }
            //                        else
            //                        {
            //                            nDifMontos = _SUBTOTAL - _EMB_MONTO_LOCAL;
            //                        }

            //                        //---------------------------------------------------------------------------------------------

            //                        string _ABREV = "";


            //                        switch (_EMB_REFERENCIA.Substring(0, 4))
            //                        {
            //                            case "0001":
            //                                _ABREV = "SB";
            //                                break;
            //                            case "0002":
            //                                _ABREV = "SL";
            //                                break;
            //                            case "0003":
            //                                _ABREV = "LO";
            //                                break;
            //                            case "0004":
            //                                _ABREV = "SQ";
            //                                break;
            //                            case "0005":
            //                                _ABREV = "CJ";
            //                                break;
            //                            case "0006":
            //                                _ABREV = "ICA";
            //                                break;
            //                            case "0007":
            //                                _ABREV = "CHN";
            //                                break;
            //                            case "0008":
            //                                _ABREV = "MAN";
            //                                break;
            //                            case "0009":
            //                                _ABREV = "PIE";
            //                                break;
            //                            case "0010":
            //                                _ABREV = "CHY";
            //                                break;
            //                            case "0011":
            //                                _ABREV = "AQPI";
            //                                break;
            //                            case "0012":
            //                                _ABREV = "AQPII";
            //                                break;
            //                            case "0013":
            //                                _ABREV = "HYO";
            //                                break;
            //                            case "0014":
            //                                _ABREV = "PIU";
            //                                break;
            //                            case "0022":
            //                                _ABREV = "PRI";
            //                                break;
            //                            default:
            //                                _ABREV = "XXX";
            //                                break;
            //                        }


            //                        //---------------------------------------------------------------------------------------------
            //                        string _DESCRIP = "";
            //                        string _DESCRIPCION_ARTICULO = "";

            //                        //_DESCRIPCION_ARTICULO = ContabilidadBL.ObtieneDescripcionArticuloEmbarqueBL(_EMBARQUE, Global.vUserBaseDatos);
            //                        _PROCESAR = "";
            //                        _APLICACION = _ABREV + " / " + _EMBARQUE + " / " + _articulo_familia.TrimEnd(' ');   // FAMILIA  desc// UPDATE: 17/08/2022
            //                        _SALDO = _MONTO;
            //                        _SUBTIPO = "0";
            //                        _CENTRO_COSTO = "00.00.00.00.00";
            //                        _CUENTA_CONTABLE = ctacont;
            //                        _RUBRO_8_DOC = "N";
            //                        _PAQUETE = "CP";
            //                        _TIPO_ASIENTO = "CP";
            //                        _TIPO_REFERENCIA = "GR";
            //                        _DOC_REFERENCIA = _EMB_RUBRO1;
            //                        _BASE_IMPUESTO1 = _SUBTOTAL;
            //                        _USUARIO = Global.vUserUsuario;
            //                        _XML_ITEMS = EmbarqueXmlItems;
            //                        _FECHA_RIGE = _FECHA_RIGE;  // _FECHA_DOC;   14/12/2022
            //                        _DESCUENTO = 0;
            //                        _IMPUESTO2 = 0;
            //                        _RUBRO_1 = 0;
            //                        _RUBRO_2 = 0;
            //                        _CUENTA_BANCARIA = "";
            //                        _NOTAS = "";
            //                        _RUBRO_2_DOC = "";
            //                        _RUBRO_3_DOC = "";
            //                        _RUBRO_4_DOC = "";
            //                        _RUBRO_5_DOC = "";
            //                        _RUBRO_6_DOC = "";
            //                        _RUBRO_7_DOC = "";
            //                        _RUBRO_9_DOC = "";
            //                        _RUBRO_10_DOC = "";
            //                        _RETENCIÓN = "";
            //                        _BASE_IMPUESTO2 = 0;
            //                        _CARGADO = "";
            //                        _EMB_CONDICIONPAGO = "";
            //                        _DIFERENCIA = nDifMontos;    // PDTE
            //                        AgregarFilaGrillaFactura();

            //                    }

            //                }
            //            }

            //        }
            //    }

            //    MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel Facturas Proveedores");

            //    xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;

            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un elemento", "Carga Excel Facturas Proveedores");
            //}

        }

        public void AgregarFilaGrillaFactura()
        {
            DataTable dt = gcFactura.DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            //newRow["PROVEEDOR"] = _PROVEEDOR;
            //newRow["TIPO"] = _TIPO;
            //newRow["DOCUMENTO"] = _DOCUMENTO;
            //newRow["FECHA_DOC"] = _FECHA_DOC;
            //newRow["FECHA_CONTABLE"] = _FECHA_CONTABLE;
            //newRow["FECHA_RIGE"] = _FECHA_RIGE;     // _FECHA_DOC;   14/12/2022
            //newRow["FECHA_VENCE"] = _FECHA_VENCE;
            //newRow["APLICACION"] = _APLICACION;
            //newRow["SUBTOTAL"] = _SUBTOTAL;
            //newRow["DESCUENTO"] = _DESCUENTO;
            //newRow["IMPUESTO1"] = _IMPUESTO1;
            //newRow["IMPUESTO2"] = _IMPUESTO2;
            //newRow["RUBRO_1"] = _RUBRO_1;
            //newRow["RUBRO_2"] = _RUBRO_2;
            //newRow["MONTO"] = _MONTO;
            //newRow["SALDO"] = _SALDO;
            //newRow["MONEDA"] = _MONEDA;
            //newRow["CONDICION_PAGO"] = _CONDICION_PAGO;
            //newRow["CUENTA_BANCARIA"] = _CUENTA_BANCARIA;
            //newRow["NOTAS"] = _NOTAS;
            //newRow["SUBTIPO"] = _SUBTIPO;
            //newRow["CENTRO_COSTO"] = _CENTRO_COSTO;
            //newRow["CUENTA_CONTABLE"] = _CUENTA_CONTABLE;
            //newRow["RUBRO_1_DOC"] = _RUBRO_1_DOC;
            //newRow["RUBRO_2_DOC"] = _RUBRO_2_DOC;
            //newRow["RUBRO_3_DOC"] = _RUBRO_3_DOC;
            //newRow["RUBRO_4_DOC"] = _RUBRO_4_DOC;
            //newRow["RUBRO_5_DOC"] = _RUBRO_5_DOC;
            //newRow["RUBRO_6_DOC"] = _RUBRO_6_DOC;
            //newRow["RUBRO_7_DOC"] = _RUBRO_7_DOC;
            //newRow["RUBRO_8_DOC"] = _RUBRO_8_DOC;
            //newRow["RUBRO_9_DOC"] = _RUBRO_9_DOC;
            //newRow["RUBRO_10_DOC"] = _RUBRO_10_DOC;
            //newRow["PAQUETE"] = _PAQUETE;
            //newRow["TIPO_ASIENTO"] = _TIPO_ASIENTO;
            //newRow["RETENCIÓN"] = _RETENCIÓN;
            //newRow["EMBARQUE"] = _EMBARQUE;
            //newRow["TIPO_REFERENCIA"] = _TIPO_REFERENCIA;
            //newRow["DOC_REFERENCIA"] = _DOC_REFERENCIA;
            //newRow["BASE_IMPUESTO1"] = _BASE_IMPUESTO1;
            //newRow["BASE_IMPUESTO2"] = _BASE_IMPUESTO2;
            //newRow["USUARIO"] = _USUARIO;
            //newRow["CARGADO"] = _CARGADO;
            //newRow["EMB_REFERENCIA"] = _EMB_REFERENCIA;
            //newRow["EMB_RUBRO1"] = _EMB_RUBRO1;
            //newRow["EMB_NOTAS"] = _EMB_NOTAS;
            //newRow["EMB_CONDICIONPAGO"] = _EMB_CONDICIONPAGO;
            //newRow["EMB_MONTO_LOCAL"] = _EMB_MONTO_LOCAL;
            //newRow["EMB_MONTO_DOLAR"] = _EMB_MONTO_DOLAR;
            //newRow["XML_ITEMS"] = _XML_ITEMS;
            //newRow["EMB_PROVEEDOR"] = _EMB_PROVEEDOR;//add
            //newRow["EMB_EMBARQUE"] = _EMB_EMBARQUE;//add
            //newRow["EMB_FECHA_EMBARQUE"] = _EMB_FECHA_EMBARQUE;//add
            //newRow["EMB_ESTADO"] = _EMB_ESTADO;//add
            //newRow["EMB_U_FECHAGUIA"] = _EMB_U_FECHAGUIA;//add
            //newRow["EMB_AUDIT_TRANS_INV"] = _EMB_AUDIT_TRANS_INV;//add
            //newRow["RETENCIONES"] = _RETENCIONES;//add
            //newRow["DIFERENCIA"] = 0;//add

            //newRow["TIP_DOC_REF"] = _TIP_DOC_REF;//add
            //newRow["NUM_DOC_REF"] = _NUM_DOC_REF;//add
            //newRow["EMBARQUE_OC"] = _EMBARQUE_OC;//add
            //newRow["DETRACCION"] = _DETRACCION;  //add
            //newRow["VALIDACION"] = _VALIDACION;  //add
            dt.Rows.InsertAt(newRow, 0);
        }

        #endregion

        // FACTURAS
        //-------------------------------------------------------------------------
        #region PROCESA_FACTURAS_EXACTUS

        private void btnExportarFacturas_Click(object sender, EventArgs e)
        {
            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel Facturas Proveedores  --> ERP Exactus");
                return;
            }
            else
            {

                gcFactura.ShowPrintPreview();
            }
        }

        private void chkFacturas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFacturas.Checked)
            {
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

        private void btnValidarFacturas_Click(object sender, EventArgs e)
        {
            ValidarFacturas2Exactus("ConMensaje");
        }


        private void ValidarFacturas2Exactus(string _MostarMensajeValidacion)
        {
            string cMensajeValidacion = "";


            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Facturas Proveedores  --> ERP Exactus");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando Información....Carga Excel Facturas Proveedores  --> ERP Exactus", "Espere por favor.."))
                {
                    string varPROVEEDOR = "";
                    string varDOCUMENTO = "";
                    string varTIPO = "";

                    for (int i = 0; i < gvFactura.DataRowCount; ++i)
                    {
                        DataRow row = gvFactura.GetDataRow(i);

                        if (row["TIPO"] != null && row["TIPO"].ToString() != "")
                        {
                            if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
                            {
                                varPROVEEDOR = row["PROVEEDOR"].ToString();
                                varTIPO = row["TIPO"].ToString();
                                varDOCUMENTO = row["DOCUMENTO"].ToString();

                                if (ContabilidadBL.ExisteFacturaCP_BL(varPROVEEDOR, varTIPO, varDOCUMENTO, "NO", Global.vUserBaseDatos))
                                {
                                    cMensajeValidacion = cMensajeValidacion + "Factura del Proveedor " + varPROVEEDOR + "N° " + varTIPO + "/" + varDOCUMENTO + " Ya existe en CP ";
                                }

                                gvFactura.SetRowCellValue(i, "VALIDACION", cMensajeValidacion);
                                cMensajeValidacion = "";

                            }
                        }

                    }

                }

                if (_MostarMensajeValidacion == "ConMensaje")
                    MessageBox.Show("Validación Finalizada !!! ");
            }
        }

        private void btnCargar2Exactus_Click(object sender, EventArgs e)
        {
            if (gvFactura.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Facturas Proveedores  --> ERP Exactus");
                return;
            }
            else
            {

                try
                {
                    DialogResult dialogResult = MessageBox.Show("Carga Excel Facturas Proveedores  --> ERP Exactus."
                                                           + "\n"
                                                           + "\nEsta seguro de Procesar la informacion?", "Carga Excel Facturas Proveedores  --> ERP Exactus", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Carga Excel Facturas Proveedores  --> ERP Exactus", "Espere por favor.."))
                        {
                            string varPROVEEDOR = "";
                            string varDOCUMENTO = "";
                            string varTIPO = "";
                            DateTime varFECHA_DOC;
                            DateTime varFECHA_CONTABLE;
                            DateTime varFECHA_RIGE;
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
                            DateTime varFECHA_VENCE;
                            Decimal varBASE_IMPUESTO1 = 0;
                            Decimal varBASE_IMPUESTO2 = 0;
                            string varRUBRO_8_DOC = "";
                            string varCUENTA_CONTABLE = "";
                            string varCENTRO_COSTO = "";
                            string varEMBARQUE = "";
                            DateTime varFECHA_PROCESO = DateTime.Now;
                            string varUSUARIO = "";
                            string varCARGADO = "";

                            string varTIP_DOC_REF = "";
                            string varNUM_DOC_REF = "";
                            string varEMBARQUE_OC = "";
                            string varDETRACCION = "";


                            for (int i = 0; i < gvFactura.DataRowCount; ++i)
                            {
                                DataRow row = gvFactura.GetDataRow(i);

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
                                                varFECHA_CONTABLE = Convert.ToDateTime(row["FECHA_CONTABLE"]);
                                                varFECHA_RIGE = Convert.ToDateTime(row["FECHA_RIGE"]);
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
                                                varUSUARIO = row["USUARIO"].ToString();

                                                varTIP_DOC_REF = row["TIP_DOC_REF"].ToString();     // "O/C"
                                                varNUM_DOC_REF = row["NUM_DOC_REF"].ToString();     // 6000006501	
                                                varEMBARQUE_OC = row["EMBARQUE_OC"].ToString();     // EM00022807 ,EM00022808
                                                varDETRACCION = row["DETRACCION"].ToString();       // S, N

                                                //ContabilidadBL.dtProcesaFacturasOtrosV5_BL(varPROVEEDOR, varDOCUMENTO, varTIPO, varFECHA_DOC, varFECHA_CONTABLE, 
                                                //                                            varFECHA_RIGE, varAPLICACION,
                                                //                                            varMONTO, varSALDO, varSUBTOTAL, varDESCUENTO, varIMPUESTO1, varIMPUESTO2,
                                                //                                            varRUBRO_1, varRUBRO_2, varCONDICION_PAGO, varMONEDA, varSUBTIPO, varFECHA_VENCE,
                                                //                                            varBASE_IMPUESTO1, varBASE_IMPUESTO2, varRUBRO_8_DOC, varCUENTA_CONTABLE,
                                                //                                            varCENTRO_COSTO, varEMBARQUE, varFECHA_PROCESO, varUSUARIO, varDETRACCION, Global.vUserBaseDatos);


                                            }
                                        }
                                        //*
                                    }
                                }

                            }

                        }

                        //
                        MessageBox.Show("Proceso Finalizado !!!", "Carga Excel Facturas Proveedores  --> ERP Exactus");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gvFactura_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (PrimeraVez == true)
            {
                ItemFactSeleccionado = string.Empty;
                PrimeraVez = false;
            }
            else
            {
                ItemFactSeleccionado = Convert.ToString(gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "DOCUMENTO"));

            }
        }

        #endregion



        #region RUTINAS_VARIOS

        public void CargaGrillaVaciaOtros()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información ....", "Espere por favor.."))
            {
                DataTable dtFactura = new DataTable();
                //dtFactura = ContabilidadBL.dtListarFacturaOtrosV5_BL(Global.vUserBaseDatos);
                gcFactura.DataSource = dtFactura;
                ConfiguraGridFactura();
            }
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
            gvFactura.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["PROVEEDOR"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["TIPO"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["DOCUMENTO"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["FECHA_DOC"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["FECHA_CONTABLE"].AppearanceCell.BackColor = Color.Coral;
            gvFactura.Columns["FECHA_RIGE"].AppearanceCell.BackColor = Color.Coral;
            gvFactura.Columns["FECHA_VENCE"].AppearanceCell.BackColor = Color.Coral;
            gvFactura.Columns["APLICACION"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["SUBTOTAL"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["IMPUESTO1"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["MONTO"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["DIFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["SALDO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["SUBTIPO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["CENTRO_COSTO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["CUENTA_CONTABLE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["RUBRO_8_DOC"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["PAQUETE"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["CONDICION_PAGO"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["TIPO_ASIENTO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["TIPO_REFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["DOC_REFERENCIA"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["BASE_IMPUESTO1"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["EMBARQUE"].AppearanceCell.BackColor = Color.Bisque;
            gvFactura.Columns["USUARIO"].AppearanceCell.BackColor = Color.Azure;
            gvFactura.Columns["EMB_REFERENCIA"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_RUBRO1"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_NOTAS"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_CONDICIONPAGO"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_MONTO_LOCAL"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["EMB_MONTO_DOLAR"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["XML_ITEMS"].AppearanceCell.BackColor = Color.LightGray;
            gvFactura.Columns["RETENCIONES"].AppearanceCell.BackColor = Color.Bisque;


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
            gvFactura.Columns["DIFERENCIA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFactura.Columns["DIFERENCIA"].DisplayFormat.FormatString = "##,###,###,##0.00";
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
            //ordenamiento
            gvFactura.ClearSorting();
            gvFactura.Columns["DOCUMENTO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }

        private void gvFactura_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {


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

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Carga")
            {
                cTabXls = "Carga";
            }
            else if (xtraTabControl1.SelectedTabPage.Text == "Browse")
            {
                cTabXls = "Browse";
            }
            else if (xtraTabControl1.SelectedTabPage.Text == "Xml")
            {
                cTabXls = "Xml";
            }


        }


        #endregion


    }
}
//EOF