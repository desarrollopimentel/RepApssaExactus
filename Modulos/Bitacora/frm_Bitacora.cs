using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
//using Excel = Microsoft.Office.Interop.Excel;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Exactus.LIBVB;
//using ApssaExactus.LIBCS;
//using ApssaExactus.LIBVB;
using System.Threading.Tasks;
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.XtraScheduler;



namespace ApssaExactus
{
    public partial class frm_Bitacora : DevExpress.XtraEditors.XtraForm
    {
        //public DateTime dFechaIni { get; set; }
        //public DateTime dFechaFin { get; set; }


        //public string articulo = string.Empty;
        //public string bodega = string.Empty;
        //public string nombre = string.Empty;
        //public string stock = string.Empty;

        //string tipobodega = string.Empty;
        //string familia = string.Empty;
        //string subfamilia = string.Empty;
        //string grupo = string.Empty;

        //string moneda = string.Empty;

        //public ArticuloBE articulo_be = null;


        //---------------------------------------------------------------------
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
        public Boolean primeraVez = false;
        public DateTime var_fecha_ini { get; set; }
        public DateTime var_fecha_fin { get; set; }
        public DateTime fechaBitacora { get; set; }

        string sucursal = string.Empty;
        string zonas = string.Empty;

        public DateTime varFecha { get; set; }
        public string varSucursal = "";
        public string varTienda = "";
        public string varTipo = "";
        public string varOrigen = "";
        public string varUsuario = "";


        public frm_Bitacora(string _base, string _user)
        {
            InitializeComponent();

            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
            //_password = _pass;      // txtPassword.Text;
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frm_Bitacora m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frm_Bitacora DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frm_Bitacora(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frm_Bitacora_Load(object sender, EventArgs e)
        {
            //--------------------------------------
            // CARGA_ENTORNO_VARIABLES
            //_base_datos = "PIMENTEL";    // txtBaseDatos.Text
            //_usuario = "MCABANILLASS";   // txtUsuario.Text;
            //_password = "12345";         // txtPassword.Text;

            //AccederEntornoReportesApssa(_base_datos, _usuario, _password );

            //passwordEncrypt = GeneralLibCS.cifrarTextoAES(_password, Global.v_palabraPaso, Global.v_valorRGBSalt, Global.v_algoritmoEncriptacionHASH, Global.v_iteraciones, Global.v_vectorInicial, Global.v_tamanoClave);
            //AccederEntornoReportesApssa(_base_datos, _usuario, passwordEncrypt);

            AccederEntornoReportesApssa(_base_datos, _usuario);
            //--------------------------------------              

            primeraVez = true;

            //setting
            txtUsuario.Visible = false;
            txtBaseDatos.Visible = false;
            txtPassword.Visible = false;

            //articuloSelec.Visible = false;
            //lblGridActivo.Visible = false;
            //xtraTabPageParametros.PageVisible = false;
            //xtraTabPageParametros.PageEnabled = false;

            DateTime? fechatemp = null;
            DateTime? fecha1 = null;
            DateTime? fecha2 = null;
            fechatemp = DateTime.Today;

            //Configuracion
            CargaCboSucursal();
            CargaCboZona();

            cboSucursal.Text = "CHICLAYO";
            cboZona.Text = "CHICLAYO";


            fechaBitacora = DateTime.Today;
            calendarControl1.HighlightTodayCell = DefaultBoolean.False;
            calendarControl1.HighlightHolidays = true;
            calendarControl1.ShowClearButton = false;
            calendarControl1.ShowTodayButton = false;
            calendarControl1.ShowHeader = true;
            calendarControl1.ShowWeekNumbers = false;
            calendarControl1.ShowToolTips = true;



            if (fechatemp.Value.Month + 1 < 12)
            {
                fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
                fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
            }
            else
            {
                fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
                fecha2 = new DateTime(fechatemp.Value.Year + 1, 1, 1).AddDays(-1);
            }

            var_fecha_ini = Convert.ToDateTime(fecha1); // Convert.ToDateTime("01/07/2022");
            var_fecha_fin = Convert.ToDateTime(fecha2); // DateTime.Today;

        }

        //---------------------------------------------------------------------------------------------

        #region CARGA_ENTORNO_VARIABLES

        //public void AccederEntornoReportesApssa(string base_datos, string usuario, string password)
        public void AccederEntornoReportesApssa(string base_datos, string usuario)
        {
            //usuario = txtUsuario.Text;
            //password = txtPassword.Text;
            txtBaseDatos.Text = base_datos;
            txtUsuario.Text = usuario;
            //txtPassword.Text = password;

            try
            {
                //if (LoginBL.DBAutenticarUsuario(usuario, password, txtBaseDatos.Text))
                if (LoginBL.DBAutenticarUsuarioSinClave(usuario, txtBaseDatos.Text))
                {
                    Global.vUserUsuario = usuario;
                    //Global.vUserClave = password;
                    Global.vUserBaseDatos = txtBaseDatos.Text;
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
                        txtPassword.Text = "";
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

        private void cboSucursal_EditValueChanged(object sender, EventArgs e)
        {
            sucursal = cboSucursal.Text;
            if (cboSucursal.Text != string.Empty)
            {
                CargaCboZonaInSucursal(sucursal);
            }
        }

        private void cboZona_EditValueChanged(object sender, EventArgs e)
        {

        }


        //EXEC[PIMENTEL].[SP_APSSA_BITACORA_CONSUMER] '20/03/2024','CHICLAYO','RESUMEN', NULL;
        //EXEC[PIMENTEL].[SP_APSSA_BITACORA_CONSUMER] '20/03/2024','CHICLAYO','DETALLE', 'FACTURACION';
        //EXEC[PIMENTEL].[SP_APSSA_BITACORA_CONSUMER] '20/03/2024','CHICLAYO','DETALLE', 'VENTAS';
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_BITACORA_CONSUMER]
        //(@FECHA_REP DATETIME,
        // @TIENDA    VARCHAR(1000),
        // @TIPO VARCHAR(250),		--'RESUMEN' , 'DETALLE'
        // @ORIGEN VARCHAR(250) )

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //fechaBitacora = DateTime.Today;
            //varFecha = fechaBitacora;
            if (primeraVez == true)
            {
                varFecha = DateTime.Today;
            } else
            {
                varFecha = fechaBitacora;
            }
           
            varSucursal = cboSucursal.Text;
            varTienda = cboZona.Text;
            varTipo = "RESUMEN";    // --'RESUMEN', 'DETALLE'
            varOrigen = "NINGUNO";  // --'FACTURACION', 'VENTAS'
            varUsuario = Global.vUserUsuario;
            CargarBitacora();
        }

        public void CargarBitacora()
        {
            DataTable dtParametros = new DataTable();
            //dtObtieneBitacoraBL(DateTime _fecha, string _tienda, string _tipo, string _origen, string _usuario, string db)
            dtParametros = ComercialBL.dtObtieneBitacoraBL(varFecha, varSucursal, varTipo, varOrigen, varUsuario, Global.vUserBaseDatos);
            gcBitacora.DataSource = dtParametros;
            ConfiguraGrilla(gvBitacora);
            FormatoGrilla(gvBitacora);
        }


        #region RUTINAS_VARIOS
        public void CargaCboSucursal()
        {
            DataSet ds_su = new DataSet();
            ds_su = Listado_MaestrosBL.Listar_Sucursal2(Global.vUserUsuario, Global.vUserBaseDatos);
            foreach (DataRow Row in ds_su.Tables[0].Rows)
            {
                this.cboSucursal.Properties.Items.Add(Row["Nombre"]);
            }
        }

        public void CargaCboZona()
        {
            DataSet ds_zonas = new DataSet();
            ds_zonas = Listado_MaestrosBL.Listar_Zonas2(Global.vUserUsuario, Global.vUserBaseDatos);
            foreach (DataRow Row in ds_zonas.Tables[0].Rows)
            {
                this.cboZona.Properties.Items.Add(Row["Nombre"]);
            }
        }

        public void CargaCboZonaInSucursal(string sucursal)
        {
            this.cboZona.Properties.Items.Clear();

            DataSet ds_zonas = new DataSet();
            ds_zonas = Listado_MaestrosBL.Listado_ZonasInSucursal2(Global.vUserUsuario, sucursal, Global.vUserBaseDatos);
            foreach (DataRow Row in ds_zonas.Tables[0].Rows)
            {
                this.cboZona.Properties.Items.Add(Row["Nombre"]);
            }
        }


        private void calendarControl1_Click(object sender, EventArgs e)
        {
            calendarControl1.CalendarAppearance.DayCellHighlighted.BackColor = Color.IndianRed;
            calendarControl1.CalendarAppearance.DayCellSelected.BackColor = Color.IndianRed;
            ////Substring(int startIndex, int length)
            //string _fecha = calendarControl1.SelectionStart.ToShortDateString();
            ////string _ano = calendarControl1.SelectionStart.ToShortDateString().Substring(6, 4);
            ////string _mes = calendarControl1.SelectionStart.ToShortDateString().Substring(3, 2);
            ////string _dia = calendarControl1.SelectionStart.ToShortDateString().Substring(0, 2);
            ////string _fechaselect = _ano + "-" + _mes + "-" + _dia;
            ////MessageBox.Show(_fechaselect);
            //fechaBitacora = Convert.ToDateTime(_fecha);
            primeraVez = false;
            varFecha = Convert.ToDateTime(calendarControl1.SelectionStart.ToShortDateString());

            CargarBitacora();

        }

        private void btnExportarResumen_Click(object sender, EventArgs e)
        {
            if (gvBitacora.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.");
                return;
            }
            else
            {
                gcBitacora.ShowPrintPreview();
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


        public void FormatoGrilla(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            // COLOR
            gv.Columns["LINEA"].AppearanceCell.BackColor = Color.LightYellow;
            gv.Columns["FAC_CANTIDAD"].AppearanceCell.BackColor = Color.LightGray;
            gv.Columns["FAC_SOLES"].AppearanceCell.BackColor = Color.LightGray;
            gv.Columns["FAC_MARGEN"].AppearanceCell.BackColor = Color.LightGray;
            gv.Columns["VTA_CANTIDAD"].AppearanceCell.BackColor = Color.Bisque;
            gv.Columns["VTA_SOLES"].AppearanceCell.BackColor = Color.Bisque;
            gv.Columns["VTA_MARGEN"].AppearanceCell.BackColor = Color.Bisque;
            gv.Columns["CYS_CUOTA"].AppearanceCell.BackColor = Color.LightSkyBlue;
            gv.Columns["CYS_AVANCE"].AppearanceCell.BackColor = Color.LightSkyBlue;
            gv.Columns["CYS_STOCK"].AppearanceCell.BackColor = Color.LightSkyBlue;

            //formateo
            gv.Columns["FAC_CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["FAC_CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.0";
            gv.Columns["FAC_SOLES"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["FAC_SOLES"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gv.Columns["FAC_MARGEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["FAC_MARGEN"].DisplayFormat.FormatString = "{0:p2}";

            gv.Columns["VTA_CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["VTA_CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.0";
            gv.Columns["VTA_SOLES"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["VTA_SOLES"].DisplayFormat.FormatString = "##,###,###,##0.000";
            gv.Columns["VTA_MARGEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["VTA_MARGEN"].DisplayFormat.FormatString = "{0:p2}";

            //column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //column.DisplayFormat.FormatString = "#.00 \"%\"";
            //// or  
            //column.DisplayFormat.FormatString = "{0} %";

            //Use the "p4" mask that divides values by 100 together with the "{0:p4}" or "{0:P4}" format.
            //Use the "{0:n4} %" format together with the "P4" mask.

            gv.Columns["CYS_CUOTA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["CYS_CUOTA"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gv.Columns["CYS_AVANCE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["CYS_AVANCE"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gv.Columns["CYS_STOCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["CYS_STOCK"].DisplayFormat.FormatString = "##,###,###,##0.0";

            gv.Columns["LINEA"].Width = 110;
            gv.Columns["FAC_CANTIDAD"].Width = 60;
            gv.Columns["FAC_SOLES"].Width = 60;
            gv.Columns["FAC_MARGEN"].Width = 60;
            gv.Columns["VTA_CANTIDAD"].Width = 60;
            gv.Columns["VTA_SOLES"].Width = 60;
            gv.Columns["VTA_MARGEN"].Width = 60;
            gv.Columns["CYS_CUOTA"].Width = 60;
            gv.Columns["CYS_AVANCE"].Width = 60;
            gv.Columns["CYS_STOCK"].Width = 60;


        }

        private void btnFacturacionExportar_Click(object sender, EventArgs e)
        {
            if (gvFacturacion.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.");
                return;
            }
            else
            {
                gcFacturacion.ShowPrintPreview();
            }
        }

        private void btnVentasExportar_Click(object sender, EventArgs e)
        {
            if (gvVentas.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.");
                return;
            }
            else
            {
                gcVentas.ShowPrintPreview();
            }
        }

        private void btnVentasActualizar_Click(object sender, EventArgs e)
        {

            //if (primeraVez == true)
            //{
            //    varFecha = DateTime.Today;
            //}
            //else
            //{
            //    varFecha = fechaBitacora;
            //}
            //varSucursal = cboSucursal.Text;
            //varTienda = cboZona.Text;
            //varTipo = "RESUMEN";    // --'RESUMEN', 'DETALLE'
            //varOrigen = "NINGUNO";  // --'FACTURACION', 'VENTAS'
            //varUsuario = Global.vUserUsuario;

            DataTable dtVentas = new DataTable();
            dtVentas = ComercialBL.dtObtieneBitacoraBL(varFecha, varSucursal, "DETALLE", "VENTAS", varUsuario, Global.vUserBaseDatos);
            gcVentas.DataSource = dtVentas;
            ConfiguraGrilla(gvVentas);
            //FormatoGrilla(gvVentas);
        }

        private void btnFacturacionActualizar_Click(object sender, EventArgs e)
        {
            //if (primeraVez == true)
            //{
            //    varFecha = DateTime.Today;
            //}
            //else
            //{
            //    varFecha = fechaBitacora;
            //}
            //varSucursal = cboSucursal.Text;
            //varTienda = cboZona.Text;
            //varTipo = "RESUMEN";    // --'RESUMEN', 'DETALLE'
            //varOrigen = "NINGUNO";  // --'FACTURACION', 'VENTAS'
            //varUsuario = Global.vUserUsuario;

            DataTable dtFacturacion = new DataTable();
            dtFacturacion = ComercialBL.dtObtieneBitacoraBL(varFecha, varSucursal, "DETALLE", "FACTURACION", varUsuario, Global.vUserBaseDatos);
            gcFacturacion.DataSource = dtFacturacion;
            ConfiguraGrilla(gvFacturacion);
            //FormatoGrilla(gvFacturacion);
        }








        //        //// COLOR
        //        gv.Columns["BODEGA"].AppearanceCell.BackColor = Color.LightGray;
        //        gv.Columns["NOMBRE"].AppearanceCell.BackColor = Color.LightGray;
        //        gv.Columns["DISPONIBLE"].AppearanceCell.BackColor = Color.Bisque;
        //        gv.Columns["RESERVADO"].AppearanceCell.BackColor = Color.Bisque;
        //        gv.Columns["REMITIDO"].AppearanceCell.BackColor = Color.Bisque;
        //        gv.Columns["STOCK"].AppearanceCell.BackColor = Color.Bisque;

        //        //gvKardex.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
        //        //gvKardex.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;




        //    ////formateo
        //    //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.00";
        //    //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
        //    //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
        //    //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatString = "##,###,###,##0";


        #endregion




















        //=================================================================================================================================


        //public void CargarParametros(string modulo, string aplicacion)
        //{
        //    DataTable dtParametros = new DataTable();
        //    dtParametros = LogisticaBL.dtCargarParametrosKardex_BL(modulo, aplicacion, Global.vUserBaseDatos);
        //    gcParametros.DataSource = dtParametros;
        //    ConfiguraGrilla(gvParametros);
        //}

        //private void txtArticulo_Enter(object sender, EventArgs e)
        //{
        //    //if ((txtArticulo.Text != null) && (txtArticulo.Text != ""))
        //    //{
        //    //    CargaDatosArticulo(txtArticulo.Text);
        //    //    txtArticuloDescripcion.Text = articulo_be.descripcion;
        //    //    txtArticuloUnidad.Text = articulo_be.unidad_almacen;
        //    //}
        //    //else
        //    //{
        //    //    MuestraFormBuscaArticulo();
        //    //}
        //}

        //private void txtArticulo_Leave(object sender, EventArgs e)
        //{
        //    if ((txtArticulo.Text != null) && (txtArticulo.Text != ""))
        //    {
        //        CargaDatosArticulo(txtArticulo.Text);
        //        txtArticuloDescripcion.Text = articulo_be.descripcion;
        //        txtArticuloUnidad.Text = articulo_be.unidad_almacen;
        //    }
        //    else
        //    {
        //        MuestraFormBuscaArticulo();
        //    }
        //}

        //private void txtArticulo_DoubleClick(object sender, EventArgs e)
        //{
        //    MuestraFormBuscaArticulo();
        //}

        //private void txtArticuloDescripcion_DoubleClick(object sender, EventArgs e)
        //{
        //    MuestraFormBuscaArticulo();
        //}


        //public void MuestraFormBuscaArticulo()
        //{
        //    frmBuscaArticulo frmBusca = new frmBuscaArticulo();
        //    frmBusca._articulo_in = txtArticulo.Text;
        //    frmBusca._articulodescripcion_in = txtArticuloDescripcion.Text;

        //    frmBusca.ShowDialog();
        //    if ((frmBusca._articulo_out != null) && (frmBusca._articulo_out != ""))
        //    {
        //        txtArticulo.Text = frmBusca._articulo_out;
        //        txtArticuloDescripcion.Text = frmBusca._articulodescripcion_out;
        //        txtArticuloUnidad.Text = frmBusca._unidad_out;
        //    }
        //}

        //private void btnProcesarXls_Click(object sender, EventArgs e)
        //{
        //    if ((txtArticulo.Text == null) || (txtArticulo.Text == ""))
        //    {
        //        MessageBox.Show("Debe seleccionar un articulo!!");
        //        txtArticulo.Focus();
        //        return;
        //    }

        //    articulo = txtArticulo.Text;
        //    //@OPERACION VARCHAR(25)) -- EXISTENCIA, RESERVADO, TRANSITO, REMITIDO, KARDEX
        //    //ObtenerArticuloExistencias(articulo);
        //}


        //public void ConfiguraGridExistencia(DevExpress.XtraGrid.Views.Grid.GridView gv)
        //{
        //    //gvKardex.Appearance.Row.Font = new System.Drawing.Font(gvKardex.Appearance.Row.Font, FontStyle.Bold);
        //    //gvKardex.Appearance.Row.Options.UseFont = true;
        //    //System.Drawing.Font fnt = new System.Drawing.Font(gvKardex.Appearance.Row.Font.Name, 7);
        //    //gvKardex.Appearance.HeaderPanel.Font = fnt;
        //    //gvKardex.Appearance.Row.Font = fnt;
        //    //gvKardex.OptionsView.ShowGroupPanel = false;
        //    //gvKardex.OptionsView.ColumnAutoWidth = false;
        //    //gvKardex.BestFitColumns();

        //    if (gv.RowCount > 0)
        //    {
        //        //// COLOR
        //        gv.Columns["BODEGA"].AppearanceCell.BackColor = Color.LightGray;
        //        gv.Columns["NOMBRE"].AppearanceCell.BackColor = Color.LightGray;
        //        gv.Columns["DISPONIBLE"].AppearanceCell.BackColor = Color.Bisque;
        //        gv.Columns["RESERVADO"].AppearanceCell.BackColor = Color.Bisque;
        //        gv.Columns["REMITIDO"].AppearanceCell.BackColor = Color.Bisque;
        //        gv.Columns["STOCK"].AppearanceCell.BackColor = Color.Bisque;

        //        //gvKardex.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
        //        //gvKardex.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;

        //    }


        //    ////formateo
        //    //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.00";
        //    //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
        //    //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
        //    //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatString = "##,###,###,##0.00000";
        //    //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatString = "##,###,###,##0";
        //}
        //public void ConfiguraGrilla(DevExpress.XtraGrid.Views.Grid.GridView gv)
        //{
        //    gv.OptionsView.ShowGroupPanel = false;
        //    gv.OptionsView.ShowIndicator = false;
        //    gv.OptionsBehavior.Editable = false;
        //    gv.OptionsSelection.EnableAppearanceFocusedCell = false;
        //    gv.OptionsView.ColumnAutoWidth = false;
        //    gv.BestFitColumns();
        //    gv.Appearance.Row.Font = new System.Drawing.Font(gv.Appearance.Row.Font, FontStyle.Bold);
        //    gv.Appearance.Row.Options.UseFont = true;

        //    System.Drawing.Font fnt = new System.Drawing.Font(gv.Appearance.Row.Font.Name, 7);
        //    gv.Appearance.HeaderPanel.Font = fnt;
        //    gv.Appearance.Row.Font = fnt;
        //}

        //public void Carga_lookUp_Bodega(string ctipobodega)
        //{
        //    DataTable dt_bo = new DataTable();
        //    dt_bo = Listado_MaestrosBL.Listar_Bodega(ctipobodega, Global.vUserBaseDatos).Tables[0];
        //    lookUpBodega.Properties.DataSource = dt_bo;
        //    lookUpBodega.Properties.DisplayMember = "NOMBRE";
        //    lookUpBodega.Properties.ValueMember = "BODEGA";
        //    lookUpBodega.EditValue = null;
        //}


        //public void Carga_lookUp_Familia(string ctipofamilia)
        //{
        //    DataTable dt_fa = new DataTable();
        //    dt_fa = Listado_MaestrosBL.Listar_Familia(Global.vUserBaseDatos).Tables[0];    //CLASIFICACION,DESCRIPCION
        //    lookUpFamilia.Properties.DataSource = dt_fa;
        //    lookUpFamilia.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpFamilia.Properties.ValueMember = "CLASIFICACION";
        //    lookUpFamilia.EditValue = null;
        //}



        //public void MuestraFormularioBusquedaArticulos(string art, string bd)
        //{
        //    frmBusca_Articulo frmArt = new frmBusca_Articulo();
        //    frmArt.familia = null;
        //    frmArt.subfamilia = null;
        //    frmArt.grupo = null;
        //    frmArt._articulo = txtArticulo.Text;
        //    frmArt.ShowDialog();
        //    if (frmArt.DialogResult == DialogResult.OK)
        //    {
        //        //txtArticulo.Text = frmArt._vendedor_selecc;
        //        //txtArticulo_Nombre.Text = frmArt._vendedor_nombre_selecc;
        //    }
        //    else
        //    {
        //        //MessageBox.Show("Vuelva a intentar....");  // TODO numero de intentos
        //    }
        //}

        //public void CargaDatosArticulo(string vendedorOK)
        //{
        //    if (articulo_be == null)
        //        articulo_be = new ArticuloBE();
        //    DataTable dtArt = new DataTable();
        //    dtArt = ComercialBL.CargaDatosArticuloBL(vendedorOK, Global.vUserBaseDatos);
        //    DataTableReader lectoruser = dtArt.CreateDataReader();
        //    while (lectoruser.Read())
        //    {
        //        articulo_be.articulo = lectoruser[0].ToString();
        //        articulo_be.descripcion = lectoruser[1].ToString();
        //        articulo_be.unidad_almacen = lectoruser[2].ToString();
        //    }
        //}

        //private void gcExistencia_Click(object sender, EventArgs e)
        //{
        //    lblGridActivo.Text = "gcExistencia";
        //}



        //private void gvExistencia_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        //{
        //    bodega = (DBNull.Value.Equals(gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "BODEGA"))) ? "" : (gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "BODEGA").ToString());
        //    nombre = (DBNull.Value.Equals(gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "NOMBRE"))) ? "" : (gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "NOMBRE").ToString());
        //    stock = (DBNull.Value.Equals(gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "STOCK"))) ? "" : (gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "STOCK").ToString());

        //    lblBodega.Text = "Bodega: " + nombre.ToUpper();
        //    bodegaSelec.Text = bodega.ToUpper();
        //    articuloSelec.Text = txtArticulo.Text.ToUpper();
        //    StockSelect.Text = stock;

        //    bodegaSelec2.Text = bodega.ToUpper();
        //    StockSelect2.Text = stock;

        //    //-------------------------------------------
        //    //this.dpFechaIni.Text = Convert.ToString(fecha1);
        //    //this.dpFechaFin.Text = Convert.ToString(fecha2);

        //    var_fecha_ini = Convert.ToDateTime(this.dpFechaIni.Text);    // Convert.ToDateTime(fecha1); // Convert.ToDateTime("01/07/2022");
        //    var_fecha_fin = Convert.ToDateTime(this.dpFechaFin.Text);    // Convert.ToDateTime(fecha2); // DateTime.Today;
        //    //-------------------------------------------

        //    if ((txtArticulo.Text != null) && (txtArticulo.Text != ""))
        //    {
        //        ObtenerArticuloReservados(txtArticulo.Text, bodega);
        //        ObtenerArticuloTransitos(txtArticulo.Text, bodega);
        //        ObtenerArticuloRemitidos(txtArticulo.Text, bodega);
        //        //ObtenerArticuloKardex(txtArticulo.Text, bodega);
        //        ObtenerArticuloKardexV2(txtArticulo.Text, bodega, var_fecha_ini, var_fecha_fin);
        //        ObtenerArticuloTransacciones(txtArticulo.Text, bodega, var_fecha_ini, var_fecha_fin);
        //    }

        //}



        //public void ObtenerArticuloExistencias(string _art)
        //{
        //    //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    //{
        //        DataTable dtExistencias = new DataTable();
        //        dtExistencias = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, "0099", "EXISTENCIA", Global.vUserBaseDatos);
        //        gcExistencia.DataSource = dtExistencias;
        //        ConfiguraGrilla(gvExistencia);
        //        ConfiguraGridExistencia(gvExistencia);
        //    //}
        //}


        //public void ObtenerArticuloReservados(string _art, string _bod)
        //{
        //    //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    //{
        //        DataTable dtReservados = new DataTable();
        //        dtReservados = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "RESERVADO", Global.vUserBaseDatos);
        //        gcReservado.DataSource = dtReservados;
        //        ConfiguraGrilla(gvReservado);
        //    //}
        //}

        //public void ObtenerArticuloTransitos(string _art, string _bod)
        //{
        //    //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    //{
        //        DataTable dtTransitos = new DataTable();
        //        dtTransitos = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "TRANSITO", Global.vUserBaseDatos);
        //        gcTransito.DataSource = dtTransitos;
        //        ConfiguraGrilla(gvTransito);
        //    //}
        //}

        //public void ObtenerArticuloRemitidos(string _art, string _bod)
        //{
        //    //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    //{
        //        DataTable dtRemitidos = new DataTable();
        //        dtRemitidos = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "REMITIDO", Global.vUserBaseDatos);
        //        gcRemitido.DataSource = dtRemitidos;
        //        ConfiguraGrilla(gvRemitido);
        //    //}
        //}

        //public void ObtenerArticuloKardex(string _art, string _bod)
        //{
        //    //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    //{
        //        DataTable dtKardex = new DataTable();
        //        dtKardex = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "KARDEX", Global.vUserBaseDatos);
        //        gcKardex.DataSource = dtKardex;
        //        ConfiguraGrilla(gvKardex);
        //    //}
        //}


        //public void ObtenerArticuloKardexV2(string _art, string _bod, DateTime fecha_ini, DateTime fecha_fin)
        //{
        //    //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    //{
        //    DataTable dtKardex = new DataTable();
        //    dtKardex = LogisticaBL.dtObtenerArticuloExistenciasV2_BL(_art, _bod, "KARDEX", fecha_ini, fecha_fin, Global.vUserBaseDatos);
        //    gcKardex.DataSource = dtKardex;
        //    ConfiguraGrilla(gvKardex);
        //    //}
        //}

        //public void ObtenerArticuloTransacciones(string _art, string _bod, DateTime fecha_ini, DateTime fecha_fin)
        //{
        //    DataTable dtTransacc = new DataTable();
        //    dtTransacc = LogisticaBL.dtObtenerArticuloTransacciones_BL(_art, _bod, "TRANSACCIONES", fecha_ini, fecha_fin, Global.vUserBaseDatos);
        //    gcTransacciones.DataSource = dtTransacc;
        //    ConfiguraGrilla(gvTransacciones);
        //}

        //private void btnExportarXls_Click(object sender, EventArgs e)
        //{
        //    string varAplicacionDescripcion = "";
        //    if (gvKardex.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe Informacion a Exportar.", varAplicacionDescripcion + " -- > ERP Exactus");
        //        return;
        //    }
        //    else
        //    {
        //        gcKardex.ShowPrintPreview();
        //    }
        //}


        //public void ExportarGrid(GridControl control, DevExpress.XtraGrid.Views.Grid.GridView gv)
        //{
        //    if (gv.DataRowCount > 0)
        //    {
        //        control.ShowPrintPreview();
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hay informacion que Exportar");
        //    }
        //}


        //private void xtraTabDetalle_Click(object sender, EventArgs e)
        //{
        //    switch (xtraTabDetalle.SelectedTabPage.Text)
        //    {
        //        case "Reservado":
        //            lblGridActivo.Text = "gcReservado";
        //            break;
        //        case "Transito":
        //            lblGridActivo.Text = "gcTransito";
        //            break;
        //        case "Remitido":
        //            lblGridActivo.Text = "gcRemitido";
        //            break;
        //        case "Kardex":
        //            lblGridActivo.Text = "gcKardex";
        //            break;
        //        case "Transacciones":
        //            lblGridActivo.Text = "gcTransacciones";
        //            break;
        //        default:
        //            lblGridActivo.Text = "gcKardex";    //"gcExistencia";
        //            break;
        //    }
        //}

        //private void btnExportarXls_Click_1(object sender, EventArgs e)
        //{
        //    //ExportarGrid(gcVenta, gvVenta);

        //    switch (lblGridActivo.Text)
        //    {
        //        case "gcReservado":
        //            //lblGridActivo.Text = "gcReservado";
        //            ExportarGrid(gcReservado, gvReservado);
        //            break;
        //        case "gcTransito":
        //            //lblGridActivo.Text = "gcTransito";
        //            ExportarGrid(gcTransito, gvTransito);
        //            break;
        //        case "gcRemitido":
        //            //lblGridActivo.Text = "gcRemitido";
        //            ExportarGrid(gcRemitido, gvRemitido);
        //            break;
        //        case "gcKardex":
        //            //lblGridActivo.Text = "gcKardex";
        //            ExportarGrid(gcKardex, gvKardex);
        //            break;
        //        case "gcTransacciones":
        //            //lblGridActivo.Text = "gcKardex";
        //            ExportarGrid(gcTransacciones, gvTransacciones);
        //            break;
        //        default:
        //            //lblGridActivo.Text = "gcExistencia";
        //            ExportarGrid(gcExistencia, gvExistencia);
        //            break;
        //    }
        //}





        //=================================================================================================================================



    }
}
