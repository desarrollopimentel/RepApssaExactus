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
/*
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
*/
//using Exactus.BL;
using Exactus.BE;
//using Exactus.LIBCS;
using Excel = Microsoft.Office.Interop.Excel;



namespace ApssaExactus
{
    public partial class frmAplicacionesGY : DevExpress.XtraEditors.XtraForm
    {
        public string HojaXls = null;
        public string tipo_carga = string.Empty;    // "Excel", "Modificacion"
        public Boolean PrimeraVez = true;
        public string ItemFactSeleccionado = string.Empty;       // archivo seleccionado en gvFactura
        public string cTabXls = null;
        public string _articulo_cuenta = string.Empty;
        public Boolean ProcesarTodos = false;
        public string exactus_tipo_documento = string.Empty;
        public string exactus_tipo_referencia = string.Empty;

        //leer PDF
        string stringPdfFile = string.Empty;
        string stringPdfOutput = string.Empty;

        // EXCEL
        DateTime _FECHA;
        string _TIPO = "";
        string _DOCUMENTO = "";
        string _MONEDA = "";
        Decimal _SOLES = 0;
        Decimal _DOLARES = 0;

        public DataTable dtNC = new DataTable();    // Notas Credito
        public DataTable dtFA = new DataTable();    //Facturas

        public DocumentoCP_BE documento_cp_be = null;

        public string _documento_cp = "";
        public string _proveedor = "";
        public DateTime _fecha;
        public string _tipo = "";
        public string _documento = "";
        public string _moneda = "";
        public Decimal _monto = 0;
        public Decimal _soles = 0;
        public Decimal _dolares = 0;

        public frmAplicacionesGY()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmAplicacionesGY m_FormDefInstance;

        /// Instancia por defecto
        public static frmAplicacionesGY DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmAplicacionesGY();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmAplicacionesGY_Load(object sender, EventArgs e)
        {


            btnCargaTemp.Visible = false;
            btnCargaGrid.Visible = false;
            btnValidarXls.Visible = false;

            //this.dpFechaProceso.Text = DateTime.Today.ToString();             
            //CargaGrillaVacia();
            //CargaGrillaVaciaOtros();
            cTabXls = "Carga";
            chkFacturas.CheckState = CheckState.Unchecked;
            InicializaDataTables();
        }


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
                MessageBox.Show("Debe seleccionar un Archivo de Excel y luego una Hoja, para realizar la carga.", "Carga Documentos CP");
            }
        }

        #endregion


        #region GENERA_TEMPORAL_DESDE_PIMENTEL.TEMP_APSSA_APLICA_MASIVA_NC

        private void btnGenerarTemp_Click(object sender, EventArgs e)
        {
            //preguntar si esta seguro, se elimnara info anterior
            //DELETE TABLA TEMPORAL PIMENTEL.TEMP_APSSA_APLICA_MASIVA_NC;
            TesoreriaBL.EliminarPendientesGY_BL("TEMP-LIMPIAR", null, Global.vUserBaseDatos);

            GrabarInformacionTemporal();

            GenerarAplicacion();
        }


        public void GrabarInformacionTemporal()
        {
            //
            string tmp_proveedor = "";
            DateTime tmp_fecha;
            string tmp_documento = "";
            string tmp_moneda = "";
            Decimal tmp_monto = 0;

            //CARGAR  dtExcel a tabla temporal PIMENTEL.TEMP_APSSA_APLICA_MASIVA_NC
            if (gvExcel.DataRowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Grabando Temporal Documentos GY");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Grabando Temporal Documentos GY"))
                {
                    for (int i = 0; i < gvExcel.DataRowCount; ++i)
                    {
                        DataRow row = gvExcel.GetDataRow(i);

                        if (row["DOCUMENTO"] != null && row["DOCUMENTO"].ToString() != "")
                        {
                            if ((row["MONEDA"] != null) && (row["MONEDA"].ToString() != ""))
                            {
                                tmp_proveedor = (DBNull.Value.Equals(row["PROVEEDOR"])) ? String.Empty : row["PROVEEDOR"].ToString();
                                tmp_fecha = (DBNull.Value.Equals(row["FECHA"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA"].ToString());
                                tmp_documento = (DBNull.Value.Equals(row["DOCUMENTO"])) ? String.Empty : row["DOCUMENTO"].ToString();
                                tmp_moneda = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
                                tmp_monto = (DBNull.Value.Equals(row["MONTO"])) ? 0 : Convert.ToDecimal(row["MONTO"].ToString());

                                //grabar
                                //TesoreriaDL.InsertarTempGY_DL(_prov,_fec,_docu,_mone,_monto, db);
                                TesoreriaBL.InsertarTempGY_BL(tmp_proveedor, tmp_fecha, tmp_documento, tmp_moneda, tmp_monto, Global.vUserBaseDatos);

                            }
                        }


                    } //fin for

                }

            }
        }

        public void GenerarAplicacion()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Generando Aplicaciones ....", "Espere por favor.."))
            {
                DataTable dtAplicado = new DataTable();
                dtAplicado = TesoreriaBL.GenerarAplicacionGY_BL(Global.vUserBaseDatos);
                gcAplicado.DataSource = dtAplicado;
                ConfiguraGrilla(gvAplicado);
            }

            MessageBox.Show("Se genero las aplicaciones", "Aplicacion Documentos GY");
        }


        private void GeneraTemporalGY(string _MostarMensaje)
        {
            string cMensajeError = "";

            string proveedor = "";
            string tipo_debito = "";
            string debito = "";
            string tipo_credito = "";
            string credito = "";
            Decimal monto_aplica = 0;
            DateTime fecha_aplica;
            string procesado = "";
            DateTime fecha_proceso;

            if (gvNC.DataRowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Documentos GY - Nota de Credito");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Documentos GY - Nota de Credito"))
                {
                    for (int i = 0; i < gvNC.DataRowCount; ++i)
                    {
                        DataRow row = gvNC.GetDataRow(i);

                        cMensajeError = "";

                        if (row["DOCUMENTO"] != null && row["DOCUMENTO"].ToString() != "")
                        {
                            if ((row["MONEDA"] != null) && (row["MONEDA"].ToString() != ""))
                            {
                                _documento = (DBNull.Value.Equals(row["DOCUMENTO"])) ? String.Empty : row["DOCUMENTO"].ToString();
                                _moneda = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
                                _tipo = _documento.Substring(0, 2);

                                if (_documento == null || _documento == "")
                                {
                                    cMensajeError = cMensajeError + "/DOCUMENTO";
                                }
                                else if (_moneda == null)
                                {
                                    cMensajeError = cMensajeError + "/MONEDA";
                                }
                                else if (_tipo != "01" && _tipo != "07")
                                {
                                    cMensajeError = cMensajeError + "/TIPO";
                                }

                                //verificar si existe documento
                                if (_documento != null || _documento != "")
                                {
                                    if (!TesoreriaBL.ExisteDocumentoCP_BL("DOCUMENTO", _documento, Global.vUserBaseDatos))
                                        cMensajeError = cMensajeError + " Error DOCUMENTO";
                                }

                                //verificar  moneda
                                if (_moneda != "SOL" && _moneda != "USD")
                                {
                                    cMensajeError = cMensajeError + " Error MONEDA";
                                }


                                CargaDatosDocumentoCP(_documento);

                                _fecha = documento_cp_be.fecha;

                                if (_moneda == "USD")
                                {
                                    _soles = 0;
                                    _dolares = documento_cp_be.saldo;
                                }
                                else
                                {
                                    _soles = documento_cp_be.saldo;
                                    _dolares = 0;
                                }

                                //actualiza grillagvExcel
                                //gvExcel.SetRowCellValue(i, "VALIDACION", i.ToString());
                                gvExcel.SetRowCellValue(i, "FECHA", _fecha.ToString());
                                gvExcel.SetRowCellValue(i, "SOLES", _soles.ToString());      //_soles.ToString());
                                gvExcel.SetRowCellValue(i, "DOLARES", _dolares.ToString());    //_dolares.ToString());

                                //aqui
                                //gvExcel.SetRowCellValue(i, "VALIDACION", cMensajeError);
                                gvExcel.SetRowCellValue(i, "VALIDACION", i.ToString());
                                gcExcel.Refresh();
                                cMensajeError = "";

                                //CargaDatosDocumentoCP(_documento);
                                //_fecha = documento_cp_be.fecha;
                                //_soles = documento_cp_be.saldo_soles;
                                //_dolares = documento_cp_be.saldo_dolares;

                                //gvExcel.SetRowCellValue(i, "FECHA", _fecha.ToString());
                                //gvExcel.SetRowCellValue(i, "SOLES", i.ToString());      //_soles.ToString());
                                //gvExcel.SetRowCellValue(i, "DOLARES", i.ToString());    //_dolares.ToString());
                                //gvExcel.RefreshDataSource();


                                //------------------------------------------------
                                _FECHA = _fecha;
                                _TIPO = _tipo;
                                _DOCUMENTO = _documento;
                                _MONEDA = _moneda;
                                _SOLES = _soles;
                                _DOLARES = _dolares;

                                if (_TIPO == "07")
                                {
                                    AgregarItemDataTable_NC();
                                }
                                else
                                {
                                    AgregarItemDataTable_FA();
                                }
                            }
                        }


                    } //fin for

                    gcExcel.RefreshDataSource();
                    gcExcel.Refresh();

                    //TERMINO 

                    ////linked
                    //gcFA.DataSource = dtFA;
                    //gcNC.DataSource = dtNC;
                    ////configurar
                    //ConfiguraGrilla(gvFA);
                    //ConfiguraGrilla(gvNC);

                    //gcFA.RefreshDataSource();
                    //gcNC.RefreshDataSource();
                    //gcFA.Refresh();
                    //gcNC.Refresh();

                }

                if (_MostarMensaje == "ConMensaje")
                    MessageBox.Show("Validación Finalizada !!! ");
            }

        }

        private void btnCargaTemp_Click(object sender, EventArgs e)
        {
            //TesoreriaBL.EliminarPendientesGY_BL("LIMPIAR", null, Global.vUserBaseDatos);

            GrabarInformacionTemporal();
        }

        #endregion


        #region HISTORICO-PIMENTEL.APLICA_MASIVA_NC 

        private void btnExportarPendientes_Click(object sender, EventArgs e)
        {
            if (gvPendientes.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Documentos GY Pendiente de Aplicacion");
                return;
            }
            else
            {
                gcPendientes.ShowPrintPreview();
            }
        }

        private void btnPendientesEliminar_Click(object sender, EventArgs e)
        {
            EliminarPendientes();
            ObtenerPendientes();
        }

        private void btnPendientesConsultar_Click(object sender, EventArgs e)
        {
            ObtenerPendientes();
        }

        public void ObtenerPendientes()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtPendientes = new DataTable();
                dtPendientes = TesoreriaBL.CargaDatosDocumentoCP_BL("HIST-PENDIENTES", null, Global.vUserBaseDatos);
                gcPendientes.DataSource = dtPendientes;
                ConfiguraGrilla(gvPendientes);

            }
        }

        public void EliminarPendientes()
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Aplicaciones GY - Pendientes."
                                                       + "\n"
                                                       + "\nEsta seguro de Eliminar los Pendientes?", "Aplicaciones GY - Pendientes.", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    using (WaitDialogForm waitDialog = new WaitDialogForm("Eliminando los Pendientes de Aplicacion GY", "Espere por favor.."))
                    {
                        TesoreriaBL.EliminarPendientesGY_BL("HIST-ELIMINAR", null, Global.vUserBaseDatos);
                    }

                    //
                    MessageBox.Show("Proceso Finalizado !!!", "Aplicaciones GY - Pendientes.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        #endregion


        #region APLICADOS-PIMENTEL.APSSA_APLICA_MASIVA_NC

        private void btnAplicadoDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //PROCESO GRABA
                DialogResult dialogResult = MessageBox.Show("Pendiente GY - Temporal"
                                                       + "\n"
                                                       + "\nEsta seguro de eliminar los Pendientes de aplicaion GY (Temporal)?", "Pendiente GY - Temporal", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    using (WaitDialogForm waitDialog = new WaitDialogForm("Eliminando Pendientes de aplicaion GY (Temporal)", "Espere por favor.."))
                    {
                        EliminarAplicados();
                        ObtenerAplicados();
                    }

                    //
                    MessageBox.Show("Proceso Finalizado !!!", "Pendientes de aplicaion GY (Temporal)");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnAplicadoUpdate_Click(object sender, EventArgs e)
        {
            ObtenerAplicados();
        }


        private void btnAplicadoSave_Click(object sender, EventArgs e)
        {
            GrabarAplicado();
        }

        public void EliminarAplicados()
        {
            TesoreriaBL.EliminarPendientesGY_BL("APLI-ELIMINAR", null, Global.vUserBaseDatos);
        }

        public void ObtenerAplicados()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtAplicado = new DataTable();
                dtAplicado = TesoreriaBL.CargaDatosDocumentoCP_BL("APLI-APLICADOS", null, Global.vUserBaseDatos);
                gcAplicado.DataSource = dtAplicado;
                ConfiguraGrilla(gvAplicado);
            }
        }

        public void GrabarAplicado()
        {
            if (gvAplicado.DataRowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Grabando Temporal Documentos GY");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Grabando Temporal Documentos GY"))
                {
                     TesoreriaBL.GrabarHistGY_BL("APLI-GRABAR",null, Global.vUserBaseDatos);
                }

                MessageBox.Show("Se grabo las aplicaciones en el Historico", "Grabando Temporal Documentos GY");

            }
        }
        #endregion






        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------




        // EXCEL
        //-------------------------------------------------------------------------

        #region PROCESA_ARCHIVO_EXCEL


        //private void ValidarArchivoXLS(string _MostarMensaje)
        //{
        //    string cMensajeError = "";
        //    string _proveedor = "";
        //    string _tipo = "";
        //    string _documento = "";
        //    DateTime _fecha_doc;
        //    string _embarque = "";
        //    string _moneda = "";
        //    string _condicion_pago = "";
        //    DateTime _fecha_vence;
        //    Decimal _subtotal = 0;
        //    Decimal _impuesto1 = 0;
        //    Decimal _monto = 0;
        //    Int16 NumDias = 0;

        //    if (gvExcel.DataRowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Facturas Proveedores");
        //        return;
        //    }
        //    else
        //    {
        //        using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Carga Excel Facturas Proveedores"))
        //        {
        //            for (int i = 0; i < gvExcel.DataRowCount; ++i)
        //            {
        //                DataRow row = gvExcel.GetDataRow(i);

        //                cMensajeError = "";

        //                if (row["PROVEEDOR"] != null && row["PROVEEDOR"].ToString() != "")
        //                {
        //                    if (row["TIPO"] != null && row["TIPO"].ToString() != "")
        //                    {
        //                        if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
        //                        {
        //                            _proveedor = (DBNull.Value.Equals(row["PROVEEDOR"])) ? String.Empty : row["PROVEEDOR"].ToString();
        //                            _tipo = (DBNull.Value.Equals(row["TIPO"])) ? String.Empty : row["TIPO"].ToString();
        //                            _documento = (DBNull.Value.Equals(row["DOCUMENTO"])) ? String.Empty : row["DOCUMENTO"].ToString();
        //                            _fecha_doc = (DBNull.Value.Equals(row["FECHA_DOC"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_DOC"].ToString());
        //                            _embarque = (DBNull.Value.Equals(row["EMBARQUE"])) ? String.Empty : row["EMBARQUE"].ToString();
        //                            _moneda = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
        //                            _condicion_pago = (DBNull.Value.Equals(row["CONDICION_PAGO"])) ? String.Empty : row["CONDICION_PAGO"].ToString();
        //                            //_fecha_vence = (DBNull.Value.Equals(row["FECHA_VENCE"])) ? DateTime.Now : Convert.ToDateTime(row["FECHA_VENCE"].ToString());
        //                            _fecha_vence = (DBNull.Value.Equals(row["FECHA_VENCE"])) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(row["FECHA_VENCE"].ToString());
        //                            _subtotal = (DBNull.Value.Equals(row["SUBTOTAL"])) ? 0 : Convert.ToDecimal(row["SUBTOTAL"].ToString());
        //                            _impuesto1 = (DBNull.Value.Equals(row["IMPUESTO1"])) ? 0 : Convert.ToDecimal(row["IMPUESTO1"].ToString());
        //                            _monto = (DBNull.Value.Equals(row["MONTO"])) ? 0 : Convert.ToDecimal(row["MONTO"].ToString());

        //                            // num dias segun codicion de pago
        //                            NumDias = Convert.ToInt16(ContabilidadBL.ObtenerDiasNeto_BL(_condicion_pago, Global.vUserBaseDatos));

        //                            //DateTime today = DateTime.Now;
        //                            //DateTime answer = today.AddDays(36);
        //                            //Console.WriteLine("Today: {0:dddd}", today);
        //                            //Console.WriteLine("36 days from today: {0:dddd}", answer);

        //                            //if (row["FECHA_VENCE"] == System.DBNull.Value)
        //                            //{
        //                            //    if (_condicion_pago != "0")
        //                            //    {
        //                            //        //cMensajeError = cMensajeError + "/FECHA_VENCE";
        //                            //        _fecha_vence = _fecha_doc.AddDays(NumDias);
        //                            //    }
        //                            //    else
        //                            //    {
        //                            //        _fecha_vence = _fecha_doc;
        //                            //    }
        //                            //}

        //                            if (_fecha_vence == Convert.ToDateTime("01/01/1900"))
        //                            {
        //                                if (_condicion_pago != "0")
        //                                {
        //                                    //cMensajeError = cMensajeError + "/FECHA_VENCE";
        //                                    _fecha_vence = _fecha_doc.AddDays(NumDias);
        //                                }
        //                                else
        //                                {
        //                                    _fecha_vence = _fecha_doc;
        //                                }

        //                                gvExcel.SetRowCellValue(i, "FECHA_VENCE", _fecha_vence);
        //                            }


        //                            if (_proveedor == null || _proveedor == "")
        //                            {
        //                                cMensajeError = cMensajeError + "PROVEEDOR";
        //                            }
        //                            else if (_tipo == null || _tipo == "")
        //                            {
        //                                cMensajeError = cMensajeError + "/TIPO";
        //                            }
        //                            else if (_documento == null || _documento == "")
        //                            {
        //                                cMensajeError = cMensajeError + "/DOCUMENTO";
        //                            }
        //                            else if (_fecha_doc == null)
        //                            {
        //                                cMensajeError = cMensajeError + "/FECHA_DOC";
        //                            }
        //                            else if (_moneda == null || _moneda == "")
        //                            {
        //                                cMensajeError = cMensajeError + "/MONEDA";
        //                            }
        //                            else if (_condicion_pago == null || _condicion_pago == "")
        //                            {
        //                                cMensajeError = cMensajeError + "/CONDICION_PAGO";
        //                            }
        //                            //else if (_fecha_vence == null && _condicion_pago != "0")
        //                            //{
        //                            //    cMensajeError = cMensajeError + "/FECHA_VENCE";
        //                            //}
        //                            else if (_subtotal == 0)
        //                            {
        //                                cMensajeError = cMensajeError + "/SUBTOTAL";
        //                            }
        //                            //else if (_impuesto1 == 0)
        //                            //{
        //                            //    cMensajeError = cMensajeError + "/IMPUESTO1";
        //                            //}
        //                            if (_monto == 0)
        //                            {
        //                                cMensajeError = cMensajeError + "/MONTO";
        //                            }

        //                            if (_subtotal + _impuesto1 != _monto)
        //                            {
        //                                cMensajeError = cMensajeError + "/montos";
        //                            }

        //                            //if (_embarque == null && _embarque == "")
        //                            //{
        //                            //    cMensajeError = cMensajeError + "/EMBARQUE";
        //                            //}

        //                            //verificar si existe proveedor
        //                            if (_proveedor != null || _proveedor != "")
        //                            {
        //                                if (!ContabilidadBL.ExisteProveedorBL(_proveedor, "NO", Global.vUserBaseDatos))
        //                                    cMensajeError = cMensajeError + " Error PROVEEDOR";
        //                            }

        //                            //verificar si existe embarque o COMPRA_SIN_OC      // CSIN / EDCM / CSOC / RESO
        //                            if (_embarque != null && _embarque != "")
        //                            {
        //                                //MessageBox.Show(_embarque.Substring(0, 2));
        //                                if (_embarque.Substring(0, 2) == "EM")
        //                                {
        //                                    if (!ContabilidadBL.ExisteEmbarqueBL(_embarque, _proveedor, "NO", Global.vUserBaseDatos))
        //                                        cMensajeError = cMensajeError + " Error EMBARQUE";
        //                                }
        //                                else if (_embarque.Substring(0, 2) == "CS")
        //                                {
        //                                    if (!ContabilidadBL.ExisteCompraSinOcBL("CSOC", _embarque, _proveedor, "NO", Global.vUserBaseDatos))
        //                                        cMensajeError = cMensajeError + " Error CSOC";
        //                                }
        //                                else if (_embarque.Substring(0, 2) == "RE")
        //                                {
        //                                    if (!ContabilidadBL.ExisteCompraSinOcBL("RESO", _embarque, _proveedor, "NO", Global.vUserBaseDatos))
        //                                        cMensajeError = cMensajeError + " Error RESO";
        //                                }

        //                            }

        //                            //aqui
        //                            gvExcel.SetRowCellValue(i, "VALIDACION", cMensajeError);
        //                            cMensajeError = "";
        //                        }

        //                    }
        //                }
        //            }
        //        }

        //        if (_MostarMensaje == "ConMensaje")
        //            MessageBox.Show("Validación Finalizada !!! ");
        //    }

        //}



        //private void btnProcesarXls_Click(object sender, EventArgs e)
        //{
        //    //ProcesarArchivosXLS();

        //    Boolean procesar = true;

        //    ValidarArchivoXLS("SinMensaje");

        //    //procesa facturas
        //    int[] seleccionados;
        //    seleccionados = gvExcel.GetSelectedRows();

        //    if (seleccionados.GetLength(0) > 0)
        //    {
        //        using (WaitDialogForm waitDialog = new WaitDialogForm("Validando informacion ....", "Espere por favor.."))
        //        {
        //            DataRow rowxls;

        //            foreach (int row in seleccionados)
        //            {
        //                rowxls = gvExcel.GetDataRow(row);

        //                if (rowxls["VALIDACION"] != null && rowxls["VALIDACION"].ToString() != "")
        //                {
        //                    procesar = false;
        //                }

        //            }

        //            // si todo OK
        //            if (procesar == true)
        //            {
        //                //ProcesarArchivosXLS();
        //                // Procesa informacion
        //                DialogResult dlgProcesar = MessageBox.Show("Se procesara unicamente los archivos que NO tengan Validacion Errónea"
        //                                                        + "\n "
        //                                                        + "\nEsta seguro de Procesar la informacion?", "Carga Excel Facturas Proveedores --> ERP Exactus", MessageBoxButtons.YesNo);

        //                if (dlgProcesar == DialogResult.Yes)
        //                {
        //                    try
        //                    {
        //                        //debe eliminar registros de gcFactura antes de cargar
        //                        if (gvFactura.RowCount > 0)
        //                        {
        //                            for (int i = 0; i < gvFactura.RowCount;)
        //                                gvFactura.DeleteRow(i);
        //                        }

        //                        ProcesarArchivosXLS();

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox.Show(ex.Message);
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("Debe corregir los errores o seleccionar solo los registros sin error de validacion", "Validacion Erronea.!!!");
        //            }
        //        }

        //        //MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel Facturas Proveedores");
        //        //xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;

        //        // validar facturas
        //        ValidarFacturas2Exactus("SinMensaje");

        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe seleccionar un elemento", "Carga Excel Facturas Proveedores");
        //    }
        //}

        //public void ProcesarArchivosXLS()  // MAXMAX 15082017
        //{
        //    //procesa facturas
        //    int[] seleccionados;
        //    seleccionados = gvExcel.GetSelectedRows();

        //    if (seleccionados.GetLength(0) > 0)
        //    {
        //        using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando archivo Excel ....", "Espere por favor.."))
        //        {
        //            DataRow rowxls;

        //            foreach (int row in seleccionados)
        //            {
        //                rowxls = gvExcel.GetDataRow(row);

        //                if (rowxls["PROVEEDOR"] != null && rowxls["PROVEEDOR"].ToString() != "")
        //                {
        //                    if (rowxls["TIPO"] != null && rowxls["TIPO"].ToString() != "")
        //                    {
        //                        if ((rowxls["DOCUMENTO"] != null) && (rowxls["DOCUMENTO"].ToString() != ""))
        //                        {
        //                            _PROVEEDOR = (DBNull.Value.Equals(rowxls["PROVEEDOR"])) ? String.Empty : rowxls["PROVEEDOR"].ToString();
        //                            _TIPO = (DBNull.Value.Equals(rowxls["TIPO"])) ? String.Empty : rowxls["TIPO"].ToString();
        //                            _DOCUMENTO = (DBNull.Value.Equals(rowxls["DOCUMENTO"])) ? String.Empty : rowxls["DOCUMENTO"].ToString();
        //                            _FECHA_DOC = (DBNull.Value.Equals(rowxls["FECHA_DOC"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_DOC"].ToString());
        //                            _EMBARQUE = (DBNull.Value.Equals(rowxls["EMBARQUE"])) ? String.Empty : rowxls["EMBARQUE"].ToString();
        //                            _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
        //                            _CONDICION_PAGO = (DBNull.Value.Equals(rowxls["CONDICION_PAGO"])) ? String.Empty : rowxls["CONDICION_PAGO"].ToString();
        //                            //_FECHA_VENCE = (DBNull.Value.Equals(rowxls["FECHA_VENCE"])) ? DateTime.Now : Convert.ToDateTime(rowxls["FECHA_VENCE"].ToString());
        //                            _FECHA_VENCE = (DBNull.Value.Equals(rowxls["FECHA_VENCE"])) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(rowxls["FECHA_VENCE"].ToString());
        //                            _SUBTOTAL = (DBNull.Value.Equals(rowxls["SUBTOTAL"])) ? 0 : Convert.ToDecimal(rowxls["SUBTOTAL"].ToString());
        //                            _IMPUESTO1 = (DBNull.Value.Equals(rowxls["IMPUESTO1"])) ? 0 : Convert.ToDecimal(rowxls["IMPUESTO1"].ToString());
        //                            _MONTO = (DBNull.Value.Equals(rowxls["MONTO"])) ? 0 : Convert.ToDecimal(rowxls["MONTO"].ToString());
        //                            _RETENCIONES = (DBNull.Value.Equals(rowxls["RETENCIONES"])) ? String.Empty : rowxls["RETENCIONES"].ToString();

        //                            Int16 NumDias = 0;

        //                            // num dias segun codicion de pago
        //                            NumDias = Convert.ToInt16(ContabilidadBL.ObtenerDiasNeto_BL(_CONDICION_PAGO, Global.vUserBaseDatos));

        //                            //if (row["FECHA_VENCE"] == System.DBNull.Value)
        //                            //if (_FECHA_VENCE == System.DBNull.Value)
        //                            //{
        //                            //    if (_CONDICION_PAGO != "0")
        //                            //    {
        //                            //        //cMensajeError = cMensajeError + "/FECHA_VENCE";
        //                            //        _FECHA_VENCE = _FECHA_DOC.AddDays(NumDias);
        //                            //    }
        //                            //    else
        //                            //    {
        //                            //        _FECHA_VENCE = _FECHA_DOC;
        //                            //    }
        //                            //}

        //                            if (_FECHA_VENCE == Convert.ToDateTime("01/01/1900"))
        //                            {
        //                                if (_CONDICION_PAGO != "0")
        //                                {
        //                                    //cMensajeError = cMensajeError + "/FECHA_VENCE";
        //                                    _FECHA_VENCE = _FECHA_DOC.AddDays(NumDias);
        //                                }
        //                                else
        //                                {
        //                                    _FECHA_VENCE = _FECHA_DOC;
        //                                }
        //                            }


        //                            //CONSECUTIVOS: CSIN / EDCM / CSOC / RESO

        //                            //consulta EMBARQUE/CSOC
        //                            if (_EMBARQUE != null && _EMBARQUE != "")
        //                            {
        //                                if (_EMBARQUE.Substring(0, 2) == "EM")
        //                                {
        //                                    //consulta EMBARQUE
        //                                    DataTable dtEmbarque = new DataTable();
        //                                    dtEmbarque = ContabilidadBL.dtObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "VARIOS", Global.vUserBaseDatos);
        //                                    for (int k = 0; k < dtEmbarque.Rows.Count; k++)
        //                                    {
        //                                        _EMB_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["EMBARQUE"])) ? String.Empty : dtEmbarque.Rows[k]["EMBARQUE"].ToString();
        //                                        _EMB_PROVEEDOR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["PROVEEDOR"])) ? String.Empty : dtEmbarque.Rows[k]["PROVEEDOR"].ToString();
        //                                        _EMB_FECHA_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["FECHA_EMBARQUE"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["FECHA_EMBARQUE"].ToString());
        //                                        _EMB_ESTADO = (DBNull.Value.Equals(dtEmbarque.Rows[k]["ESTADO"])) ? String.Empty : dtEmbarque.Rows[k]["ESTADO"].ToString();
        //                                        _EMB_REFERENCIA = ContabilidadBL.ObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "REFERENCIA", Global.vUserBaseDatos);
        //                                        _EMB_RUBRO1 = (DBNull.Value.Equals(dtEmbarque.Rows[k]["RUBRO1"])) ? String.Empty : dtEmbarque.Rows[k]["RUBRO1"].ToString();
        //                                        _EMB_NOTAS = (DBNull.Value.Equals(dtEmbarque.Rows[k]["NOTAS"])) ? String.Empty : dtEmbarque.Rows[k]["NOTAS"].ToString();
        //                                        _EMB_U_FECHAGUIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["U_FECHAGUIA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["U_FECHAGUIA"].ToString());
        //                                        _EMB_AUDIT_TRANS_INV = (DBNull.Value.Equals(dtEmbarque.Rows[k]["AUDIT_TRANS_INV"])) ? String.Empty : dtEmbarque.Rows[k]["AUDIT_TRANS_INV"].ToString();
        //                                        _EMB_MONTO_LOCAL = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_LOCAL"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_LOCAL"].ToString());
        //                                        _EMB_MONTO_DOLAR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_DOLAR"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_DOLAR"].ToString());
        //                                    }
        //                                }
        //                                else if (_EMBARQUE.Substring(0, 2) == "CS")
        //                                {
        //                                    //consulta CSOC
        //                                    DataTable dtEmbarque = new DataTable();
        //                                    dtEmbarque = ContabilidadBL.dtObtieneCompraSinOcBL("CSOC", _EMBARQUE, _PROVEEDOR, "SI", Global.vUserBaseDatos);
        //                                    for (int k = 0; k < dtEmbarque.Rows.Count; k++)
        //                                    {
        //                                        _EMB_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["APLICACION"])) ? String.Empty : dtEmbarque.Rows[k]["APLICACION"].ToString();
        //                                        _EMB_PROVEEDOR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["PROVEEDOR"])) ? String.Empty : dtEmbarque.Rows[k]["PROVEEDOR"].ToString();
        //                                        _EMB_FECHA_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["FECHA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["FECHA"].ToString());
        //                                        _EMB_ESTADO = (DBNull.Value.Equals(dtEmbarque.Rows[k]["ESTADO"])) ? String.Empty : dtEmbarque.Rows[k]["ESTADO"].ToString();
        //                                        _EMB_REFERENCIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["REFERENCIA"])) ? String.Empty : dtEmbarque.Rows[k]["REFERENCIA"].ToString(); //ContabilidadBL.ObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "REFERENCIA", Global.vUserBaseDatos);
        //                                        _EMB_RUBRO1 = (DBNull.Value.Equals(dtEmbarque.Rows[k]["RUBRO1"])) ? String.Empty : dtEmbarque.Rows[k]["RUBRO1"].ToString();
        //                                        _EMB_NOTAS = (DBNull.Value.Equals(dtEmbarque.Rows[k]["NOTAS"])) ? String.Empty : dtEmbarque.Rows[k]["NOTAS"].ToString();
        //                                        _EMB_U_FECHAGUIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["U_FECHAGUIA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["U_FECHAGUIA"].ToString());
        //                                        _EMB_AUDIT_TRANS_INV = (DBNull.Value.Equals(dtEmbarque.Rows[k]["AUDIT_TRANS_INV"])) ? String.Empty : dtEmbarque.Rows[k]["AUDIT_TRANS_INV"].ToString();
        //                                        _EMB_MONTO_LOCAL = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_LOCAL"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_LOCAL"].ToString());
        //                                        _EMB_MONTO_DOLAR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_DOLAR"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_DOLAR"].ToString());
        //                                    }
        //                                }
        //                                else if (_EMBARQUE.Substring(0, 2) == "RE")
        //                                {
        //                                    //consulta RESO
        //                                    DataTable dtEmbarque = new DataTable();
        //                                    dtEmbarque = ContabilidadBL.dtObtieneCompraSinOcBL("RESO", _EMBARQUE, _PROVEEDOR, "SI", Global.vUserBaseDatos);
        //                                    for (int k = 0; k < dtEmbarque.Rows.Count; k++)
        //                                    {
        //                                        _EMB_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["APLICACION"])) ? String.Empty : dtEmbarque.Rows[k]["APLICACION"].ToString();
        //                                        _EMB_PROVEEDOR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["PROVEEDOR"])) ? String.Empty : dtEmbarque.Rows[k]["PROVEEDOR"].ToString();
        //                                        _EMB_FECHA_EMBARQUE = (DBNull.Value.Equals(dtEmbarque.Rows[k]["FECHA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["FECHA"].ToString());
        //                                        _EMB_ESTADO = (DBNull.Value.Equals(dtEmbarque.Rows[k]["ESTADO"])) ? String.Empty : dtEmbarque.Rows[k]["ESTADO"].ToString();
        //                                        _EMB_REFERENCIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["REFERENCIA"])) ? String.Empty : dtEmbarque.Rows[k]["REFERENCIA"].ToString(); //ContabilidadBL.ObtieneDatosEmbarqueOtrosBL(_EMBARQUE, "REFERENCIA", Global.vUserBaseDatos);
        //                                        _EMB_RUBRO1 = (DBNull.Value.Equals(dtEmbarque.Rows[k]["RUBRO1"])) ? String.Empty : dtEmbarque.Rows[k]["RUBRO1"].ToString();
        //                                        _EMB_NOTAS = (DBNull.Value.Equals(dtEmbarque.Rows[k]["NOTAS"])) ? String.Empty : dtEmbarque.Rows[k]["NOTAS"].ToString();
        //                                        _EMB_U_FECHAGUIA = (DBNull.Value.Equals(dtEmbarque.Rows[k]["U_FECHAGUIA"])) ? DateTime.Now : Convert.ToDateTime(dtEmbarque.Rows[k]["U_FECHAGUIA"].ToString());
        //                                        _EMB_AUDIT_TRANS_INV = (DBNull.Value.Equals(dtEmbarque.Rows[k]["AUDIT_TRANS_INV"])) ? String.Empty : dtEmbarque.Rows[k]["AUDIT_TRANS_INV"].ToString();
        //                                        _EMB_MONTO_LOCAL = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_LOCAL"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_LOCAL"].ToString());
        //                                        _EMB_MONTO_DOLAR = (DBNull.Value.Equals(dtEmbarque.Rows[k]["MONTO_DOLAR"])) ? 0 : Convert.ToDecimal(dtEmbarque.Rows[k]["MONTO_DOLAR"].ToString());
        //                                    }
        //                                }

        //                            }



        //                            string _LIN_EMBARQUE = "";
        //                            string _LIN_ORDEN_COMPRA = "";
        //                            string _LIN_MONEDA_OC = "";
        //                            string _LIN_ARTICULO = "";
        //                            string _LIN_BODEGA = "";
        //                            Decimal _LIN_CANTIDAD_EMBARCADA = 0;
        //                            Decimal _LIN_CANTIDAD_RECIBIDA = 0;
        //                            Decimal _LIN_PRECIO_UNIT_OC_LOCAL = 0;
        //                            Decimal _LIN_PRECIO_UNIT_OC_DOLAR = 0;
        //                            Decimal _LIN_TC_PRECIO_OC_LOCAL = 0;
        //                            Decimal _LIN_TC_PRECIO_OC_DOLAR = 0;
        //                            Decimal _LIN_MONTO_OC_LOCAL = 0;
        //                            Decimal _LIN_MONTO_OC_DOLAR = 0;

        //                            Decimal MontoTotalEmbarqueLocal = 0;
        //                            Decimal MontoTotalEmbarqueDolar = 0;
        //                            string EmbarqueAplicacion = "";         //  0008-MANSICHE / EM00022679 / GR/00001-0167468
        //                            string EmbarqueXmlItems = "";           //  340005  CA (20.000)   340009  CA (192.000)   

        //                            _DETRACCION = "N";      // inicializa 

        //                            //consulta EMBARQUE_LINEA/CSOC_LINEA
        //                            if (_EMBARQUE != null && _EMBARQUE != "")
        //                            {
        //                                //consulta EMBARQUE_LINEA
        //                                if (_EMBARQUE.Substring(0, 2) == "EM")
        //                                {
        //                                    DataTable dtLinea = new DataTable();
        //                                    dtLinea = ContabilidadBL.ObtieneDatosEmbarqueLineaOtrosBL(_EMBARQUE, Global.vUserBaseDatos);
        //                                    for (int z = 0; z < dtLinea.Rows.Count; z++)
        //                                    {
        //                                        _LIN_EMBARQUE = dtLinea.Rows[z]["EMBARQUE"].ToString();
        //                                        _LIN_ORDEN_COMPRA = dtLinea.Rows[z]["ORDEN_COMPRA"].ToString();
        //                                        _LIN_MONEDA_OC = dtLinea.Rows[z]["MONEDA_OC"].ToString();
        //                                        _LIN_ARTICULO = dtLinea.Rows[z]["ARTICULO"].ToString();
        //                                        _LIN_BODEGA = dtLinea.Rows[z]["BODEGA"].ToString();       //bodega
        //                                        _LIN_CANTIDAD_EMBARCADA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_EMBARCADA"]);
        //                                        _LIN_CANTIDAD_RECIBIDA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_RECIBIDA"]);
        //                                        _LIN_PRECIO_UNIT_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_LOCAL"]);
        //                                        _LIN_PRECIO_UNIT_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_DOLAR"]);
        //                                        _LIN_TC_PRECIO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_LOCAL"]);
        //                                        _LIN_TC_PRECIO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_DOLAR"]);
        //                                        _LIN_MONTO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"]);
        //                                        _LIN_MONTO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"]);

        //                                        _articulo_cuenta = "";
        //                                        _articulo_cuenta = ContabilidadBL.ObtieneArticuloFamiliaCodigoBL(_LIN_ARTICULO, Global.vUserBaseDatos);

        //                                        if (_articulo_cuenta == "RE")   // reencauche
        //                                        {
        //                                            _DETRACCION = "S";
        //                                        }

        //                                        EmbarqueXmlItems = _LIN_ARTICULO + "  " + _articulo_cuenta + " (" +        //"  CA("+  // TODO prefijo por familia
        //                                                            Math.Truncate(_LIN_CANTIDAD_RECIBIDA).ToString() + ")   ";

        //                                        // acumula total embarque
        //                                        MontoTotalEmbarqueLocal += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"].ToString());
        //                                        MontoTotalEmbarqueDolar += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"].ToString());
        //                                    }
        //                                }
        //                                else if (_EMBARQUE.Substring(0, 2) == "CS")  //consulta CSOC_LINEA
        //                                {
        //                                    DataTable dtLinea = new DataTable();
        //                                    dtLinea = ContabilidadBL.dtObtieneCompraSinOcLineaBL("CSOC", _EMBARQUE, Global.vUserBaseDatos);
        //                                    for (int z = 0; z < dtLinea.Rows.Count; z++)
        //                                    {
        //                                        _LIN_EMBARQUE = dtLinea.Rows[z]["APLICACION"].ToString();
        //                                        _LIN_ORDEN_COMPRA = dtLinea.Rows[z]["ORDEN_COMPRA"].ToString();
        //                                        _LIN_MONEDA_OC = dtLinea.Rows[z]["MONEDA_OC"].ToString();
        //                                        _LIN_ARTICULO = dtLinea.Rows[z]["ARTICULO"].ToString();
        //                                        _LIN_BODEGA = dtLinea.Rows[z]["BODEGA"].ToString();       //bodega
        //                                        _LIN_CANTIDAD_EMBARCADA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_EMBARCADA"]);
        //                                        _LIN_CANTIDAD_RECIBIDA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_RECIBIDA"]);
        //                                        _LIN_PRECIO_UNIT_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_LOCAL"]);
        //                                        _LIN_PRECIO_UNIT_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_DOLAR"]);
        //                                        _LIN_TC_PRECIO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_LOCAL"]);
        //                                        _LIN_TC_PRECIO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_DOLAR"]);
        //                                        _LIN_MONTO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"]);
        //                                        _LIN_MONTO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"]);

        //                                        _articulo_cuenta = "";
        //                                        _articulo_cuenta = ContabilidadBL.ObtieneArticuloFamiliaCodigoBL(_LIN_ARTICULO, Global.vUserBaseDatos);

        //                                        if (_articulo_cuenta == "RE")   // reencauche
        //                                        {
        //                                            _DETRACCION = "S";
        //                                        }

        //                                        EmbarqueXmlItems = _LIN_ARTICULO + "  " + _articulo_cuenta + " (" +        //"  CA("+  // TODO prefijo por familia
        //                                                            Math.Truncate(_LIN_CANTIDAD_RECIBIDA).ToString() + ")   ";

        //                                        // acumula total embarque
        //                                        MontoTotalEmbarqueLocal += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"].ToString());
        //                                        MontoTotalEmbarqueDolar += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"].ToString());
        //                                    }

        //                                }
        //                                else if (_EMBARQUE.Substring(0, 2) == "RE")  //consulta RESO_LINEA
        //                                {
        //                                    DataTable dtLinea = new DataTable();
        //                                    dtLinea = ContabilidadBL.dtObtieneCompraSinOcLineaBL("RESO", _EMBARQUE, Global.vUserBaseDatos);
        //                                    for (int z = 0; z < dtLinea.Rows.Count; z++)
        //                                    {
        //                                        _LIN_EMBARQUE = dtLinea.Rows[z]["APLICACION"].ToString();
        //                                        _LIN_ORDEN_COMPRA = dtLinea.Rows[z]["ORDEN_COMPRA"].ToString();
        //                                        _LIN_MONEDA_OC = dtLinea.Rows[z]["MONEDA_OC"].ToString();
        //                                        _LIN_ARTICULO = dtLinea.Rows[z]["ARTICULO"].ToString();
        //                                        _LIN_BODEGA = dtLinea.Rows[z]["BODEGA"].ToString();       //bodega
        //                                        _LIN_CANTIDAD_EMBARCADA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_EMBARCADA"]);
        //                                        _LIN_CANTIDAD_RECIBIDA = Convert.ToDecimal(dtLinea.Rows[z]["CANTIDAD_RECIBIDA"]);
        //                                        _LIN_PRECIO_UNIT_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_LOCAL"]);
        //                                        _LIN_PRECIO_UNIT_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["PRECIO_UNIT_OC_DOLAR"]);
        //                                        _LIN_TC_PRECIO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_LOCAL"]);
        //                                        _LIN_TC_PRECIO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["TC_PRECIO_OC_DOLAR"]);
        //                                        _LIN_MONTO_OC_LOCAL = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"]);
        //                                        _LIN_MONTO_OC_DOLAR = Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"]);

        //                                        _articulo_cuenta = "";
        //                                        _articulo_cuenta = ContabilidadBL.ObtieneArticuloFamiliaCodigoBL(_LIN_ARTICULO, Global.vUserBaseDatos);

        //                                        if (_articulo_cuenta == "RE")   // reencauche
        //                                        {
        //                                            _DETRACCION = "S";
        //                                        }

        //                                        EmbarqueXmlItems = _LIN_ARTICULO + "  " + _articulo_cuenta + " (" +        //"  CA("+  // TODO prefijo por familia
        //                                                            Math.Truncate(_LIN_CANTIDAD_RECIBIDA).ToString() + ")   ";

        //                                        // acumula total embarque
        //                                        MontoTotalEmbarqueLocal += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_LOCAL"].ToString());
        //                                        MontoTotalEmbarqueDolar += Convert.ToDecimal(dtLinea.Rows[z]["MONTO_OC_DOLAR"].ToString());
        //                                    }

        //                                }

        //                            }




        //                            //Asigna cuenta contable DEFAULT
        //                            string ctacont = "";
        //                            if (_articulo_cuenta != "")
        //                                ctacont = ContabilidadBL.ObtieneCuentaCompraArticuloBL(_articulo_cuenta, Global.vUserBaseDatos);

        //                            //if (EmbarqueXmlItems.Contains("PR") == true)
        //                            //{
        //                            //    ctacont = "28.1.1.1.03";
        //                            //}
        //                            //else if (EmbarqueXmlItems.Contains("CA") == true)
        //                            //{
        //                            //    ctacont = "28.1.1.1.02";
        //                            //}
        //                            //else if (EmbarqueXmlItems.Contains("LL") == true)
        //                            //{
        //                            //    ctacont = "28.1.1.1.01";
        //                            //}

        //                            Decimal nDifMontos = 0;

        //                            if (_MONEDA == "USD")
        //                            {
        //                                nDifMontos = _SUBTOTAL - _EMB_MONTO_DOLAR;
        //                            }
        //                            else
        //                            {
        //                                nDifMontos = _SUBTOTAL - _EMB_MONTO_LOCAL;
        //                            }

        //                            _PROCESAR = "";
        //                            //_APLICACION = _EMB_REFERENCIA + " / " + _EMBARQUE + " / " + _EMB_RUBRO1;                       //pdte   //  0008-MANSICHE / EM00022679 / GR/00001-0167468
        //                            _APLICACION = _PROVEEDOR  + " / " + _TIPO + " / " + _DOCUMENTO;
        //                            _SALDO = _MONTO;
        //                            _SUBTIPO = "0";
        //                            _CENTRO_COSTO = "00.00.00.00.00";
        //                            //_CUENTA_CONTABLE = ctacont;
        //                            _CUENTA_CONTABLE = "42.1.2.1.01";   // goodyear  // ctacont;
        //                            _FECHA_CONTABLE = _FECHA_DOC;
        //                            _RUBRO_8_DOC = "N";         // NO ASOCIA PARTE DE INGRE='N'
        //                            _PAQUETE = "CP";
        //                            _TIPO_ASIENTO = "CP";
        //                            _TIPO_REFERENCIA = "GR";
        //                            _DOC_REFERENCIA = _EMB_RUBRO1;
        //                            _BASE_IMPUESTO1 = _SUBTOTAL;
        //                            //_FECHA_VENCE = _FECHA_VCMTO;    // _FECHA_DOC;
        //                            _USUARIO = Global.vUserUsuario;
        //                            _XML_ITEMS = EmbarqueXmlItems;
        //                            _FECHA_RIGE = _FECHA_DOC;
        //                            _DESCUENTO = 0;
        //                            _IMPUESTO2 = 0;
        //                            _RUBRO_1 = 0;
        //                            _RUBRO_2 = 0;
        //                            _CUENTA_BANCARIA = "";
        //                            _NOTAS = "";
        //                            //_RUBRO_1_DOC = "";
        //                            _RUBRO_2_DOC = "";
        //                            _RUBRO_3_DOC = "";
        //                            _RUBRO_4_DOC = "";
        //                            _RUBRO_5_DOC = "";
        //                            _RUBRO_6_DOC = "";
        //                            _RUBRO_7_DOC = "";
        //                            _RUBRO_9_DOC = "";
        //                            _RUBRO_10_DOC = "";
        //                            _RETENCIÓN = "";
        //                            _BASE_IMPUESTO2 = 0;
        //                            _CARGADO = "";
        //                            _EMB_CONDICIONPAGO = "";
        //                            _DIFERENCIA = nDifMontos;    // PDTE
        //                            ////actualiza columnas
        //                            //gvExcel.SetRowCellValue(i, "PROCESAR", cMensajeError);
        //                            //cMensajeError = "";

        //                            //Agrega Items al DataTable
        //                            AgregarFilaGrillaFactura();

        //                        }

        //                    }
        //                }

        //            }
        //        }

        //        MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel Facturas Proveedores");

        //        xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;

        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe seleccionar un elemento", "Carga Excel Facturas Proveedores");
        //    }

        //}

        //public void AgregarFilaGrillaFactura()
        //{
        //    DataTable dt = gcFactura.DataSource as DataTable;
        //    DataRow newRow = dt.NewRow();
        //    newRow["PROVEEDOR"] = _PROVEEDOR;
        //    newRow["TIPO"] = _TIPO;
        //    newRow["DOCUMENTO"] = _DOCUMENTO;
        //    newRow["FECHA_DOC"] = _FECHA_DOC;
        //    newRow["FECHA_RIGE"] = _FECHA_DOC;
        //    newRow["APLICACION"] = _APLICACION;
        //    newRow["SUBTOTAL"] = _SUBTOTAL;
        //    newRow["DESCUENTO"] = _DESCUENTO;
        //    newRow["IMPUESTO1"] = _IMPUESTO1;
        //    newRow["IMPUESTO2"] = _IMPUESTO2;
        //    newRow["RUBRO_1"] = _RUBRO_1;
        //    newRow["RUBRO_2"] = _RUBRO_2;
        //    newRow["MONTO"] = _MONTO;
        //    newRow["SALDO"] = _SALDO;
        //    newRow["MONEDA"] = _MONEDA;
        //    newRow["CONDICION_PAGO"] = _CONDICION_PAGO;
        //    newRow["CUENTA_BANCARIA"] = _CUENTA_BANCARIA;
        //    newRow["NOTAS"] = _NOTAS;
        //    newRow["SUBTIPO"] = _SUBTIPO;
        //    newRow["CENTRO_COSTO"] = _CENTRO_COSTO;
        //    newRow["CUENTA_CONTABLE"] = _CUENTA_CONTABLE;
        //    newRow["FECHA_CONTABLE"] = _FECHA_DOC;
        //    newRow["RUBRO_1_DOC"] = _RUBRO_1_DOC;
        //    newRow["RUBRO_2_DOC"] = _RUBRO_2_DOC;
        //    newRow["RUBRO_3_DOC"] = _RUBRO_3_DOC;
        //    newRow["RUBRO_4_DOC"] = _RUBRO_4_DOC;
        //    newRow["RUBRO_5_DOC"] = _RUBRO_5_DOC;
        //    newRow["RUBRO_6_DOC"] = _RUBRO_6_DOC;
        //    newRow["RUBRO_7_DOC"] = _RUBRO_7_DOC;
        //    newRow["RUBRO_8_DOC"] = _RUBRO_8_DOC;
        //    newRow["RUBRO_9_DOC"] = _RUBRO_9_DOC;
        //    newRow["RUBRO_10_DOC"] = _RUBRO_10_DOC;
        //    newRow["PAQUETE"] = _PAQUETE;
        //    newRow["TIPO_ASIENTO"] = _TIPO_ASIENTO;
        //    newRow["RETENCIÓN"] = _RETENCIÓN;
        //    newRow["EMBARQUE"] = _EMBARQUE;
        //    newRow["TIPO_REFERENCIA"] = _TIPO_REFERENCIA;
        //    newRow["DOC_REFERENCIA"] = _DOC_REFERENCIA;
        //    newRow["BASE_IMPUESTO1"] = _BASE_IMPUESTO1;
        //    newRow["BASE_IMPUESTO2"] = _BASE_IMPUESTO2;
        //    newRow["FECHA_VENCE"] = _FECHA_VENCE;
        //    newRow["USUARIO"] = _USUARIO;
        //    newRow["CARGADO"] = _CARGADO;
        //    newRow["EMB_REFERENCIA"] = _EMB_REFERENCIA;
        //    newRow["EMB_RUBRO1"] = _EMB_RUBRO1;
        //    newRow["EMB_NOTAS"] = _EMB_NOTAS;
        //    newRow["EMB_CONDICIONPAGO"] = _EMB_CONDICIONPAGO;
        //    newRow["EMB_MONTO_LOCAL"] = _EMB_MONTO_LOCAL;
        //    newRow["EMB_MONTO_DOLAR"] = _EMB_MONTO_DOLAR;
        //    newRow["XML_ITEMS"] = _XML_ITEMS;
        //    newRow["EMB_PROVEEDOR"] = _EMB_PROVEEDOR;//add
        //    newRow["EMB_EMBARQUE"] = _EMB_EMBARQUE;//add
        //    newRow["EMB_FECHA_EMBARQUE"] = _EMB_FECHA_EMBARQUE;//add
        //    newRow["EMB_ESTADO"] = _EMB_ESTADO;//add
        //    newRow["EMB_U_FECHAGUIA"] = _EMB_U_FECHAGUIA;//add
        //    newRow["EMB_AUDIT_TRANS_INV"] = _EMB_AUDIT_TRANS_INV;//add
        //    newRow["RETENCIONES"] = _RETENCIONES;//add
        //    newRow["DIFERENCIA"] = 0;//add

        //    newRow["TIP_DOC_REF"] = _TIP_DOC_REF;//add
        //    newRow["NUM_DOC_REF"] = _NUM_DOC_REF;//add
        //    newRow["EMBARQUE_OC"] = _EMBARQUE_OC;//add
        //    newRow["DETRACCION"] = _DETRACCION;  //add
        //    newRow["VALIDACION"] = _VALIDACION;  //add
        //    dt.Rows.InsertAt(newRow, 0);
        //}


        #endregion











        #region RUTINAS_VARIOS
        

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




        #endregion


        













        public void InicializaDataTables()
        {
            //NC
            dtNC.Columns.Add("FECHA");
            dtNC.Columns.Add("TIPO");
            dtNC.Columns.Add("DOCUMENTO");
            dtNC.Columns.Add("MONEDA");
            dtNC.Columns.Add("SOLES");
            dtNC.Columns.Add("DOLARES");

            //FA
            dtFA.Columns.Add("FECHA");
            dtFA.Columns.Add("TIPO");
            dtFA.Columns.Add("DOCUMENTO");
            dtFA.Columns.Add("MONEDA");
            dtFA.Columns.Add("SOLES");
            dtFA.Columns.Add("DOLARES");
        }

        private void btnCargaGrid_Click(object sender, EventArgs e)
        {
            CargarGrillas();
        }

        public void CargarGrillas()
        {

            //linked
            gcFA.DataSource = dtFA;
            ConfiguraGrilla(gvFA);
            //gcFA.RefreshDataSource();
            gcFA.Refresh();

            //configurar
            gcNC.DataSource = dtNC;
            ConfiguraGrilla(gvNC);
            //gcNC.RefreshDataSource();
            gcNC.Refresh();
        }

        #region CARGA_DOCUMENTOS_GY

        private void btnLoadXls_Click(object sender, EventArgs e)
        {
            if (gvExcel.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Proceso de Carga de Documentos GY."
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
                //ValidarArchivoXLS("SinMensaje");        // MAXMAX 09122021
                ValidarDocumentosGY("SinMensaje");
                CargarGrillas();
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
                if ((dr["DOCUMENTO"] == null) || (dr["DOCUMENTO"].ToString() == ""))
                    dr.Delete();
            }

            //-----------------------------------------------------
            // add columns 
            dtExcel.Columns.Add("FECHA");
            dtExcel.Columns.Add("MONTO");
            dtExcel.Columns.Add("SOLES");
            dtExcel.Columns.Add("DOLARES");
            dtExcel.Columns.Add("PROVEEDOR");
            //-----------------------------------------------------

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

            // COLOR
            //gvExcel.Columns["DOCUMENTO"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["FECHA"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["SOLES"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["DOLARES"].AppearanceCell.BackColor = Color.Bisque;

            ////gvExcel.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["PROVEEDOR"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["TIPO"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["FECHA_DOC"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["SUBTOTAL"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["IMPUESTO1"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["MONTO"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["CONDICION_PAGO"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["FECHA_VENCE"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["EMBARQUE"].AppearanceCell.BackColor = Color.Bisque;
            //gvExcel.Columns["RETENCIONES"].AppearanceCell.BackColor = Color.Bisque;
            ////gvExcel.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;
            //gvExcel.Columns["VALIDACION"].AppearanceCell.ForeColor = Color.Red;

        }


        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            if (gvExcel.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Carga Documentos GY --> ERP Exactus");
                return;
            }
            else
            {
                gcExcel.ShowPrintPreview();
            }
        }

        private void btnValidarXls_Click(object sender, EventArgs e)
        {
            ValidarDocumentosGY("ConMensaje");
        }


        private void ValidarDocumentosGY(string _MostarMensaje)
        {
            string cMensajeError = "";
            string _tipo = "";
            string _documento = "";
            string _moneda = "";

            if (gvExcel.DataRowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Documentos GY");
                return;
            }
            else
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando información, Espere por favor...", "Carga Excel Documentos GY"))
                {
                    for (int i = 0; i < gvExcel.DataRowCount; ++i)
                    {
                        DataRow row = gvExcel.GetDataRow(i);

                        cMensajeError = "";

                        if (row["DOCUMENTO"] != null && row["DOCUMENTO"].ToString() != "")
                        {
                            if ((row["MONEDA"] != null) && (row["MONEDA"].ToString() != ""))
                            {
                                _documento = (DBNull.Value.Equals(row["DOCUMENTO"])) ? String.Empty : row["DOCUMENTO"].ToString();
                                _moneda = (DBNull.Value.Equals(row["MONEDA"])) ? String.Empty : row["MONEDA"].ToString();
                                _tipo = _documento.Substring(0, 2);

                                if (_documento == null || _documento == "")
                                {
                                    cMensajeError = cMensajeError + "/DOCUMENTO";
                                }
                                else if (_moneda == null)
                                {
                                    cMensajeError = cMensajeError + "/MONEDA";
                                }
                                else if (_tipo != "01" && _tipo != "07")
                                {
                                    cMensajeError = cMensajeError + "/TIPO";
                                }

                                //verificar si existe documento
                                if (_documento != null || _documento != "")
                                {
                                    if (!TesoreriaBL.ExisteDocumentoCP_BL("DOCUMENTO", _documento, Global.vUserBaseDatos))
                                        cMensajeError = cMensajeError + " Error DOCUMENTO";
                                }

                                //verificar  moneda
                                if (_moneda != "SOL" && _moneda != "USD")
                                {
                                    cMensajeError = cMensajeError + " Error MONEDA";
                                }


                                CargaDatosDocumentoCP(_documento);

                                _proveedor = documento_cp_be.proveedor;
                                _documento_cp = documento_cp_be.documento;
                                _fecha = documento_cp_be.fecha;
                                _monto = documento_cp_be.monto;

                                if (_moneda == "USD")
                                {
                                    _soles = 0;
                                    _dolares = documento_cp_be.saldo;
                                }
                                else
                                {
                                    _soles = documento_cp_be.saldo;
                                    _dolares = 0;
                                }

                                //actualiza grillagvExcel
                                //gvExcel.SetRowCellValue(i, "VALIDACION", i.ToString());
                                gvExcel.SetRowCellValue(i, "PROVEEDOR", _proveedor.ToString());
                                gvExcel.SetRowCellValue(i, "FECHA", _fecha.ToString());
                                gvExcel.SetRowCellValue(i, "MONTO", _monto.ToString());
                                gvExcel.SetRowCellValue(i, "SOLES", _soles.ToString());      //_soles.ToString());
                                gvExcel.SetRowCellValue(i, "DOLARES", _dolares.ToString());    //_dolares.ToString());

                                //aqui
                                gvExcel.SetRowCellValue(i, "VALIDACION", cMensajeError);
                                //gvExcel.SetRowCellValue(i, "VALIDACION", i.ToString());
                                gcExcel.Refresh();
                                cMensajeError = "";

                                //CargaDatosDocumentoCP(_documento);
                                //_fecha = documento_cp_be.fecha;
                                //_soles = documento_cp_be.saldo_soles;
                                //_dolares = documento_cp_be.saldo_dolares;

                                //gvExcel.SetRowCellValue(i, "FECHA", _fecha.ToString());
                                //gvExcel.SetRowCellValue(i, "SOLES", i.ToString());      //_soles.ToString());
                                //gvExcel.SetRowCellValue(i, "DOLARES", i.ToString());    //_dolares.ToString());
                                //gvExcel.RefreshDataSource();


                                //------------------------------------------------
                                _FECHA = _fecha;
                                _TIPO = _tipo;
                                _DOCUMENTO = _documento_cp; // _documento;
                                _MONEDA = _moneda;
                                _SOLES = _soles;
                                _DOLARES = _dolares;

                                if (_TIPO == "07")
                                {
                                    AgregarItemDataTable_NC();
                                }
                                else
                                {
                                    AgregarItemDataTable_FA();
                                }
                            }
                        }


                    } //fin for

                    gcExcel.RefreshDataSource();
                    gcExcel.Refresh();

                    //TERMINO 

                    ////linked
                    //gcFA.DataSource = dtFA;
                    //gcNC.DataSource = dtNC;
                    ////configurar
                    //ConfiguraGrilla(gvFA);
                    //ConfiguraGrilla(gvNC);

                    //gcFA.RefreshDataSource();
                    //gcNC.RefreshDataSource();
                    //gcFA.Refresh();
                    //gcNC.Refresh();

                }

                if (_MostarMensaje == "ConMensaje")
                    MessageBox.Show("Validación Finalizada !!! ");
            }

        }


        public void CargaDatosDocumentoCP(string docuOK)
        {
            if (documento_cp_be == null)
                documento_cp_be = new DocumentoCP_BE();
            DataTable dtDocu = new DataTable();
            dtDocu = TesoreriaBL.CargaDatosDocumentoCP_BL("DATOS", docuOK, Global.vUserBaseDatos);
            DataTableReader lectoruser = dtDocu.CreateDataReader();
            while (lectoruser.Read())
            {
                //SELECT FECHA, TIPO, DOCUMENTO,MONEDA,MONTO_LOCAL, MONTO_DOLAR, SALDO_LOCAL, SALDO_DOLAR, PROVEEDOR
                documento_cp_be.fecha = Convert.ToDateTime(lectoruser[0].ToString());
                documento_cp_be.tipo = lectoruser[1].ToString();
                documento_cp_be.documento = lectoruser[2].ToString();
                documento_cp_be.moneda = lectoruser[3].ToString();
                documento_cp_be.monto = Convert.ToDecimal(lectoruser[4].ToString());
                documento_cp_be.saldo = Convert.ToDecimal(lectoruser[5].ToString());
                documento_cp_be.monto_soles = Convert.ToDecimal(lectoruser[6].ToString());
                documento_cp_be.monto_dolares = Convert.ToDecimal(lectoruser[7].ToString());
                documento_cp_be.saldo_soles = Convert.ToDecimal(lectoruser[8].ToString());
                documento_cp_be.saldo_dolares = Convert.ToDecimal(lectoruser[9].ToString());
                documento_cp_be.proveedor = lectoruser[10].ToString();

                //_fecha = documento_cp_be.fecha;                
                //_soles = documento_cp_be.monto_soles;       // documento_cp_be.saldo_soles;
                //_dolares = documento_cp_be.monto_dolares;   // documento_cp_be.saldo_dolares;

            }
        }


        public void ProcesarDocumentosGY()
        {
            //procesa facturas
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

                        if ((rowxls["DOCUMENTO"] != null) && (rowxls["DOCUMENTO"].ToString() != ""))
                        {
                            if ((rowxls["MONEDA"] != null) && (rowxls["MONEDA"].ToString() != ""))
                            {
                                _DOCUMENTO = (DBNull.Value.Equals(rowxls["DOCUMENTO"])) ? String.Empty : rowxls["DOCUMENTO"].ToString();
                                _MONEDA = (DBNull.Value.Equals(rowxls["MONEDA"])) ? String.Empty : rowxls["MONEDA"].ToString();
                                _TIPO = _DOCUMENTO.Substring(0, 2);

                                //_FECHA = null;
                                _SOLES = 0;
                                _DOLARES = 0;

                                //Asigna cuenta contable DEFAULT
                                //string ctacont = "";
                                //if (_articulo_cuenta != "")
                                //    ctacont = ContabilidadBL.ObtieneCuentaCompraArticuloBL(_articulo_cuenta, Global.vUserBaseDatos);

                                //Agrega Items al DataTable
                                //AgregarFilaGrillaFactura();
                                if (_TIPO == "07")
                                {
                                    AgregarItemDataTable_NC();
                                }
                                else
                                {
                                    AgregarItemDataTable_FA();
                                }

                            }

                        }

                    }

                    //TERMINO 

                    //linked
                    gcFA.DataSource = dtFA;
                    gcNC.DataSource = dtNC;
                    //configurar
                    ConfiguraGrilla(gvFA);
                    ConfiguraGrilla(gvNC);

                }

                MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel Facturas Proveedores");

                xtraTabControl1.SelectedTabPage = xtraTabPageBrowse;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel Facturas Proveedores");
            }

        }


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
        public void AgregarItemDataTable_NC()
        {
            //DataTable dt = gcFactura.DataSource as DataTable;
            DataRow row_NC = dtNC.NewRow();
            row_NC["FECHA"] = _FECHA;
            row_NC["TIPO"] = _TIPO;
            row_NC["DOCUMENTO"] = _DOCUMENTO;
            row_NC["MONEDA"] = _MONEDA;
            row_NC["SOLES"] = _SOLES;
            row_NC["DOLARES"] = _DOLARES;

            dtNC.Rows.InsertAt(row_NC, 0);
        }

        public void AgregarItemDataTable_FA()
        {
            //DataTable dt = gcFactura.DataSource as DataTable;
            DataRow row_FA = dtFA.NewRow();
            row_FA["FECHA"] = _FECHA;
            row_FA["TIPO"] = _TIPO;
            row_FA["DOCUMENTO"] = _DOCUMENTO;
            row_FA["MONEDA"] = _MONEDA;
            row_FA["SOLES"] = _SOLES;
            row_FA["DOLARES"] = _DOLARES;

            dtFA.Rows.InsertAt(row_FA, 0);
        }

        #endregion



        // CARGA
        //-------------------------------------------------------------------------


        // FACTURAS
        //-------------------------------------------------------------------------
        //#region PROCESA_FACTURAS_EXACTUS

        //private void btnExportarFacturas_Click(object sender, EventArgs e)
        //{
        //    if (gvFactura.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Exportar.", "Carga Excel Documentos GY  --> ERP Exactus");
        //        return;
        //    }
        //    else
        //    {

        //        gcFactura.ShowPrintPreview();
        //    }
        //}

        //private void chkFacturas_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFacturas.Checked)
        //    {
        //        // actualiza embarque
        //        try
        //        {
        //            Int32 j;
        //            for (j = 0; j < gvFactura.RowCount; j++)
        //            {
        //                gvFactura.SetRowCellValue(j, "PROCESAR", true);
        //            }

        //            gcFactura.RefreshDataSource();

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
        //            for (j = 0; j < gvFactura.RowCount; j++)
        //            {
        //                gvFactura.SetRowCellValue(j, "PROCESAR", false);
        //            }

        //            gcFactura.RefreshDataSource();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }


        //}

        //private void btnValidarFacturas_Click(object sender, EventArgs e)
        //{
        //    ValidarFacturas2Exactus("ConMensaje");
        //}


        //private void ValidarFacturas2Exactus(string _MostarMensajeValidacion)
        //{
        //    string cMensajeValidacion = "";


        //    if (gvFactura.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Documentos GY  --> ERP Exactus");
        //        return;
        //    }
        //    else
        //    {
        //        using (WaitDialogForm waitDialog = new WaitDialogForm("Validando Información....Carga Excel Documentos GY  --> ERP Exactus", "Espere por favor.."))
        //        {
        //            string varPROVEEDOR = "";
        //            string varDOCUMENTO = "";
        //            string varTIPO = "";

        //            for (int i = 0; i < gvFactura.DataRowCount; ++i)
        //            {
        //                DataRow row = gvFactura.GetDataRow(i);

        //                //if (row["PROCESAR"] != System.DBNull.Value)
        //                //{
        //                //if (Convert.ToBoolean(row["PROCESAR"]) == true)
        //                //{
        //                if (row["TIPO"] != null && row["TIPO"].ToString() != "")
        //                {
        //                    if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
        //                    {
        //                        varPROVEEDOR = row["PROVEEDOR"].ToString();
        //                        varTIPO = row["TIPO"].ToString();
        //                        varDOCUMENTO = row["DOCUMENTO"].ToString();

        //                        // verificar 
        //                        //ContabilidadBL.ExisteFacturaCP_BL(varPROVEEDOR, varTIPO, varDOCUMENTO, Global.vUserBaseDatos);

        //                        //if (!ContabilidadBL.ExisteFacturaCP_BL(varPROVEEDOR, varTIPO, varDOCUMENTO, "NO", Global.vUserBaseDatos))
        //                        if (ContabilidadBL.ExisteFacturaCP_BL(varPROVEEDOR, varTIPO, varDOCUMENTO, "NO", Global.vUserBaseDatos))
        //                        {
        //                            //cMensajeValidacion = cMensajeValidacion + " Error EMBARQUE";
        //                            cMensajeValidacion = cMensajeValidacion + "Factura del Proveedor " + varPROVEEDOR + "N° " + varTIPO + "/" + varDOCUMENTO + " Ya existe en CP ";
        //                            //MessageBox.Show("Factura  del Proveedor " + varPROVEEDOR + "N° " + varTIPO + "/" + varDOCUMENTO + "Ya existe en CP ");
        //                        }

        //                        //actualizar Grilla
        //                        gvFactura.SetRowCellValue(i, "VALIDACION", cMensajeValidacion);
        //                        cMensajeValidacion = "";


        //                    }
        //                }

        //                //}
        //                //}

        //            }

        //        }

        //        if (_MostarMensajeValidacion == "ConMensaje")
        //            MessageBox.Show("Validación Finalizada !!! ");
        //    }
        //}

        //private void btnCargar2Exactus_Click(object sender, EventArgs e)
        //{
        //    if (gvFactura.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel Documentos GY  --> ERP Exactus");
        //        return;
        //    }
        //    else
        //    {

        //        try
        //        {
        //            //PROCESO GRABA
        //            DialogResult dialogResult = MessageBox.Show("Carga Excel Facturas Proveedores  --> ERP Exactus."
        //                                                   + "\n"
        //                                                   + "\nEsta seguro de Procesar la informacion?", "Carga Excel Documentos GY  --> ERP Exactus", MessageBoxButtons.YesNo);

        //            if (dialogResult == DialogResult.Yes)
        //            {

        //                using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....Carga Excel Documentos GY  --> ERP Exactus", "Espere por favor.."))
        //                {
        //                    string varPROVEEDOR = "";
        //                    string varDOCUMENTO = "";
        //                    string varTIPO = "";
        //                    DateTime varFECHA_DOC;
        //                    //DateTime? varFECHA_DOC = null;
        //                    string varAPLICACION = "";
        //                    Decimal varMONTO = 0;
        //                    Decimal varSALDO = 0;
        //                    Decimal varSUBTOTAL = 0;
        //                    Decimal varDESCUENTO = 0;
        //                    Decimal varIMPUESTO1 = 0;
        //                    Decimal varIMPUESTO2 = 0;
        //                    Decimal varRUBRO_1 = 0;
        //                    Decimal varRUBRO_2 = 0;
        //                    string varCONDICION_PAGO = "";
        //                    string varMONEDA = "";
        //                    Int16 varSUBTIPO = 0;
        //                    DateTime varFECHA_VENCE; // = row["FECHA_VENCE"].ToString();
        //                                             //DateTime? varFECHA_VENCE = null;
        //                    Decimal varBASE_IMPUESTO1 = 0;
        //                    Decimal varBASE_IMPUESTO2 = 0;
        //                    string varRUBRO_8_DOC = "";
        //                    string varCUENTA_CONTABLE = "";
        //                    string varCENTRO_COSTO = "";
        //                    string varEMBARQUE = "";
        //                    DateTime varFECHA_PROCESO;  // = row["FECHA_PROCESO"].ToString();
        //                                                //DateTime? varFECHA_PROCESO = null;
        //                    string varUSUARIO = "";
        //                    string varCARGADO = "";

        //                    string varTIP_DOC_REF = "";
        //                    string varNUM_DOC_REF = "";
        //                    string varEMBARQUE_OC = "";
        //                    string varDETRACCION = "";


        //                    for (int i = 0; i < gvFactura.DataRowCount; ++i)
        //                    {
        //                        DataRow row = gvFactura.GetDataRow(i);

        //                        //repositoryCheckEdit1.ValueChecked = "True";
        //                        //repositoryCheckEdit1.ValueUnchecked = "False";
        //                        //gvFactura.Columns["PROCESAR"].ColumnEdit = repositoryCheckEdit1;
        //                        //gvFactura.SetRowCellValue(j, "PROCESAR", false);

        //                        //if (Convert.ToBoolean(row["PROCESAR"]) == true)
        //                        //if ( (row["PROCESAR"] != null) && (Convert.ToBoolean(row["PROCESAR"]) != null) && (Convert.ToBoolean(row["PROCESAR"]) == true))
        //                        //if ((row["CARGADO"] != null) && (row["CARGADO"].ToString() == "X"))
        //                        if (row["PROCESAR"] != System.DBNull.Value)
        //                        {
        //                            if (Convert.ToBoolean(row["PROCESAR"]) == true)
        //                            {
        //                                //**
        //                                if (row["TIPO"] != null && row["TIPO"].ToString() != "")
        //                                {

        //                                    if ((row["DOCUMENTO"] != null) && (row["DOCUMENTO"].ToString() != ""))
        //                                    {

        //                                        varPROVEEDOR = row["PROVEEDOR"].ToString();
        //                                        varDOCUMENTO = row["DOCUMENTO"].ToString();
        //                                        varTIPO = row["TIPO"].ToString();
        //                                        varFECHA_DOC = Convert.ToDateTime(row["FECHA_DOC"]);
        //                                        varAPLICACION = row["APLICACION"].ToString();
        //                                        varMONTO = Convert.ToDecimal(row["MONTO"].ToString());
        //                                        varSALDO = Convert.ToDecimal(row["SALDO"].ToString());
        //                                        varSUBTOTAL = Convert.ToDecimal(row["SUBTOTAL"].ToString());
        //                                        varDESCUENTO = Convert.ToDecimal(row["DESCUENTO"].ToString());
        //                                        varIMPUESTO1 = Convert.ToDecimal(row["IMPUESTO1"].ToString());
        //                                        varIMPUESTO2 = Convert.ToDecimal(row["IMPUESTO2"].ToString());
        //                                        varRUBRO_1 = Convert.ToDecimal(row["RUBRO_1"].ToString());
        //                                        varRUBRO_2 = Convert.ToDecimal(row["RUBRO_2"].ToString());
        //                                        varCONDICION_PAGO = row["CONDICION_PAGO"].ToString();
        //                                        varMONEDA = row["MONEDA"].ToString();
        //                                        varSUBTIPO = Convert.ToInt16(row["SUBTIPO"]);
        //                                        varFECHA_VENCE = Convert.ToDateTime(row["FECHA_VENCE"]);
        //                                        varBASE_IMPUESTO1 = Convert.ToDecimal(row["BASE_IMPUESTO1"].ToString());
        //                                        varBASE_IMPUESTO2 = Convert.ToDecimal(row["BASE_IMPUESTO2"].ToString());
        //                                        varRUBRO_8_DOC = row["RUBRO_8_DOC"].ToString();
        //                                        varCUENTA_CONTABLE = row["CUENTA_CONTABLE"].ToString();
        //                                        varCENTRO_COSTO = row["CENTRO_COSTO"].ToString();
        //                                        varEMBARQUE = row["EMBARQUE"].ToString();
        //                                        varFECHA_PROCESO = Convert.ToDateTime(row["FECHA_CONTABLE"]);
        //                                        varUSUARIO = row["USUARIO"].ToString();

        //                                        varTIP_DOC_REF = row["TIP_DOC_REF"].ToString();     // "O/C"
        //                                        varNUM_DOC_REF = row["NUM_DOC_REF"].ToString();     // 6000006501	
        //                                        varEMBARQUE_OC = row["EMBARQUE_OC"].ToString();     // EM00022807 ,EM00022808
        //                                        varDETRACCION = row["DETRACCION"].ToString();       // S, N

        //                                        //MessageBox.Show("Procesando Factura ..... " + varTIPO + "/" + varDOCUMENTO, "Verificacion");

        //                                        //ContabilidadBL.dtProcesaFacturasOtros2BL(varPROVEEDOR, varDOCUMENTO, varTIPO, varFECHA_DOC, varAPLICACION,
        //                                        //                                        varMONTO, varSALDO, varSUBTOTAL, varDESCUENTO, varIMPUESTO1, varIMPUESTO2,
        //                                        //                                        varRUBRO_1, varRUBRO_2, varCONDICION_PAGO, varMONEDA, varSUBTIPO, varFECHA_VENCE,
        //                                        //                                        varBASE_IMPUESTO1, varBASE_IMPUESTO2, varRUBRO_8_DOC, varCUENTA_CONTABLE,
        //                                        //                                        varCENTRO_COSTO, varEMBARQUE, varFECHA_PROCESO, varUSUARIO, varDETRACCION, Global.vUserBaseDatos);

        //                                        ContabilidadBL.dtProcesaDocumentosGY_BL(varPROVEEDOR, varDOCUMENTO, varTIPO, varFECHA_DOC, varAPLICACION,
        //                                                                                varMONTO, varSALDO, varSUBTOTAL, varDESCUENTO, varIMPUESTO1, varIMPUESTO2,
        //                                                                                varRUBRO_1, varRUBRO_2, varCONDICION_PAGO, varMONEDA, varSUBTIPO, varFECHA_VENCE,
        //                                                                                varBASE_IMPUESTO1, varBASE_IMPUESTO2, varRUBRO_8_DOC, varCUENTA_CONTABLE,
        //                                                                                varCENTRO_COSTO, varEMBARQUE, varFECHA_PROCESO, varUSUARIO, varDETRACCION, Global.vUserBaseDatos);

        //                                    }
        //                                }
        //                                //*
        //                            }
        //                        }

        //                    }

        //                }

        //                //
        //                MessageBox.Show("Proceso Finalizado !!!", "Carga Excel Documentos GY  --> ERP Exactus");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void gvFactura_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        //{
        //    if (PrimeraVez == true)
        //    {
        //        ItemFactSeleccionado = string.Empty;
        //        //txtOuter.Text = "";
        //        PrimeraVez = false;
        //    }
        //    else
        //    {
        //        ItemFactSeleccionado = Convert.ToString(gvFactura.GetRowCellValue(gvFactura.FocusedRowHandle, "DOCUMENTO"));

        //        //doc_tmp.Load(ItemFactSeleccionado);
        //        //txtOuter.Text = doc_tmp.DocumentElement.OuterXml;
        //        //txtXML_Path.Text = ItemFactSeleccionado;
        //    }
        //}

        //#endregion



    }

}
//EOF