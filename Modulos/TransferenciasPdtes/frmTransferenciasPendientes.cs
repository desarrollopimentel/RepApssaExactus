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
/* 
 * UPDATE : 05/11/2015
 * REMARKS: Se actualizo combos x usuario.  
*/


namespace ApssaExactus
{
    public partial class frmTransferenciasPendientes : DevExpress.XtraEditors.XtraForm
    {
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

        string passwordEncrypt = null;
        public string cUsuarioActual = null;
        //---------------------------------------------------------------------_base, _user, _pass

        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        string sucursal = string.Empty;
        string zonas = string.Empty;


        string paquete = string.Empty;
        string tipobodega = string.Empty;
        string familia = string.Empty;
        string subfamilia = string.Empty;
        string grupo = string.Empty;
        string articulo = string.Empty;
        string moneda = string.Empty;

        public ArticuloBE articulo_be = null;

        public frmTransferenciasPendientes(string _base, string _user)
        {
            InitializeComponent();
            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
            //_password = _pass;      // txtPassword.Text;
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmTransferenciasPendientes m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;
        /// Instancia por defecto
        public static frmTransferenciasPendientes DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmTransferenciasPendientes(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        /*
        DateTime? fechatemp = null;
        DateTime? fecha1 = null;
        DateTime? fecha2 = null;

        fechatemp = DateTime.Today;
        fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
        fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).
        */

        private void frmTransferenciasPendientes_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            //passwordEncrypt = GeneralLibCS.cifrarTextoAES(_password, Global.v_palabraPaso, Global.v_valorRGBSalt, Global.v_algoritmoEncriptacionHASH, Global.v_iteraciones, Global.v_vectorInicial, Global.v_tamanoClave);
            //AccederEntornoReportesApssa(_base_datos, _usuario, passwordEncrypt);
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------                
            // inicializo      
            DateTime? fechatemp = DateTime.Today;
            DateTime? fecha1 = null;
            fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
            //this.dpFechaIni.Text = "01/01/2015";  // Convert.ToString(DateTime.Today);
            this.dpFechaIni.Text = fecha1.ToString();
            this.dpFechaFin.Text = DateTime.Today.ToString();
            //txtDescripcion.ReadOnly = true;
            //txtUnidad.ReadOnly = true;

            Carga_lookUp_Paquete(null);
            //Carga_lookUp_Bodega(null);
            //Carga_lookUp_Familia(null);

            //CargaComboConPreferencias();
        }


        //---------------------------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------------------------


        private void btnProcesarXls_Click(object sender, EventArgs e)
        {
            if (lookUpPaquete.EditValue == null)
            {
                MessageBox.Show("Debe seleccionar una Bodega");
                lookUpPaquete.Focus();
                return;
            }

            //if ((txtArticulo.Text == null) || (txtArticulo.Text == ""))
            //{
            //    MessageBox.Show("Debe seleccionar un articulo!!");
            //    txtArticulo.Focus();
            //    return;
            //}

            //if (DBNull.Value.Equals(lookUpBodega.EditValue))
            //{
            //    MessageBox.Show("Debe seleccionar una Bodega");
            //    return;
            //}
            //else
            //{
            //    if ((lookUpBodega.EditValue.ToString() != null) || (lookUpBodega.EditValue.ToString() != ""))
            //    {
            //        MessageBox.Show("Debe seleccionar una Bodega");
            //        return;
            //    }
            //}



            if ((this.dpFechaIni.Text != null) && (this.dpFechaIni.Text != ""))
            {
                dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
            }

            if ((this.dpFechaFin.Text != null) && (this.dpFechaFin.Text != ""))
            {
                dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);
            }

            //bodega = "SAN BORJA, SAN LUIS, LOS OLIVOS, SURQUILLO, CAJAMARCA, ICA, CHINCHA, MANSICHE, PIEROLA, CHICLAYO, AREQUIPA, AREQUIPA II, HUANCAYO II, PIURA";
            //familia = "LLANTA";

            string _paquete = lookUpPaquete.Text;
            paquete = lookUpPaquete.EditValue.ToString();
            //articulo = txtArticulo.Text;
            //subfamilia = this.cboSubFamilia.Text;
            //grupo = this.cboGrupo.Text;

            //ObtenerArticulosTransacciones(dFechaIni, dFechaFin, bodega, articulo);
            ObtenerTransanferenciasPendientes(dFechaIni, dFechaFin, paquete);
        }

        public void ObtenerTransanferenciasPendientes(DateTime fs1, DateTime fs2, string paq)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtTransf = new DataTable();
                dtTransf = LogisticaBL.dtObtenerTransanferenciasPendientes_BL(fs1, fs2, paq, Global.vUserUsuario, Global.vUserBaseDatos);
                gcTransf.DataSource = dtTransf;
                ConfiguraGridRemRes();
            }
        }


        //public void ObtenerArticulosTransacciones(DateTime fs1, DateTime fs2, string bod, string art)
        //{
        //    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
        //    {
        //        DataTable dtRemRes = new DataTable();
        //        dtRemRes = LogisticaBL.dtObtenerArticuloTransacciones_BL(fs1, fs2, bod, art, Global.vUserBaseDatos);
        //        gcTransf.DataSource = dtRemRes;
        //        ConfiguraGridRemRes();
        //    }
        //}


        public void ConfiguraGridRemRes()
        {

            ConfiguraGrilla(gvTransf);

            ////ordenamiento
            //gvResRem.ClearSorting();
            //gvResRem.Columns["ARTICULO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            ////formateo
            //gvResRem.Columns["DISPONIBLE_ALMACEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvResRem.Columns["DISPONIBLE_ALMACEN"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvResRem.Columns["RESERVADA_ALMACEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvResRem.Columns["RESERVADA_ALMACEN"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvResRem.Columns["REMITIDA_ALMACEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvResRem.Columns["REMITIDA_ALMACEN"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvResRem.Columns["TOTAL_ALMACEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvResRem.Columns["TOTAL_ALMACEN"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvResRem.Columns["CANT_REMITIDA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvResRem.Columns["CANT_REMITIDA"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvResRem.Columns["CANT_PEDIDA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvResRem.Columns["CANT_PEDIDA"].DisplayFormat.FormatString = "##,###,###,##0.00";

            //gvResRem.Columns["ZONA"].Width = 60;
            //gvResRem.Columns["TIPO"].Width = 60;
            //gvResRem.Columns["DOCUMENTO"].Width = 80;
            //gvResRem.Columns["ARTICULO"].Width = 60;
            //gvResRem.Columns["DESCRIPCION"].Width = 250;
            //gvResRem.Columns["RESERV_DOC"].Width = 60;
            //gvResRem.Columns["APLICACION"].Width = 150;
            //gvResRem.Columns["CANT_DISPONIBLE"].Width = 60;
            //gvResRem.Columns["CANT_RESERVADA"].Width = 60;
            //gvResRem.Columns["CANT_TRANSITO"].Width = 60;
            //gvResRem.Columns["CANT_REMITIDA"].Width = 60;
            //gvResRem.Columns["CANT_PEDIDA"].Width = 60;
            //gvResRem.Columns["BODEGA"].Width = 60;
            //gvResRem.Columns["USUARIO"].Width = 60;
            //gvResRem.Columns["FECHA_HORA"].Width = 80;
            //gvResRem.Columns["LOTE"].Width = 60;
            //gvResRem.Columns["LOCALIZACION"].Width = 60;
            //gvResRem.Columns["SERIE_CADENA"].Width = 60;
            //gvResRem.Columns["MODULO_ORIGEN"].Width = 60;

            //gvResRem.Columns["ZONA"].Caption = "ZONA";
            //gvResRem.Columns["TIPO"].Caption = "TIPO";
            //gvResRem.Columns["DOCUMENTO"].Caption = "DOCUMENTO";
            //gvResRem.Columns["ARTICULO"].Caption = "ARTICULO";
            //gvResRem.Columns["DESCRIPCION"].Caption = "DESCRIPCION";
            //gvResRem.Columns["RESERV_DOC"].Caption = "RESERV_DOC";
            //gvResRem.Columns["APLICACION"].Caption = "APLICACION";
            //gvResRem.Columns["CANT_DISPONIBLE"].Caption = "DISPONIBLE";
            //gvResRem.Columns["CANT_RESERVADA"].Caption = "RESERVADA";
            //gvResRem.Columns["CANT_TRANSITO"].Caption = "TRANSITO";
            //gvResRem.Columns["CANT_REMITIDA"].Caption = "REMITIDA";
            //gvResRem.Columns["CANT_PEDIDA"].Caption = "PEDIDA";
            //gvResRem.Columns["BODEGA"].Caption = "BODEGA";
            //gvResRem.Columns["USUARIO"].Caption = "USUARIO";
            //gvResRem.Columns["FECHA_HORA"].Caption = "FECHA_HORA";
            //gvResRem.Columns["LOTE"].Caption = "LOTE";
            //gvResRem.Columns["LOCALIZACION"].Caption = "LOCALIZACION";
            //gvResRem.Columns["SERIE_CADENA"].Caption = "SERIE_CADENA";
            //gvResRem.Columns["MODULO_ORIGEN"].Caption = "MODULO_ORIGEN";

            //gvResRem.Columns["RESERV_DOC"].AppearanceCell.BackColor = Color.WhiteSmoke;

        }


        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            string varAplicacionDescripcion = "";
            if (gvTransf.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", varAplicacionDescripcion + " -- > ERP Exactus");
                return;
            }
            else
            {
                gcTransf.ShowPrintPreview();
            }
        }



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

        public void Carga_lookUp_Paquete(string ctipobodega)
        {
            DataTable dt_bo = new DataTable();
            //dt_bo = Listado_MaestrosBL.Listar_Paquete(ctipobodega, Global.vUserBaseDatos).Tables[0];
            dt_bo = Listado_MaestrosBL.Listar_Paquete(Global.vUserUsuario, Global.vUserBaseDatos).Tables[0];
            lookUpPaquete.Properties.DataSource = dt_bo;
            lookUpPaquete.Properties.DisplayMember = "DESCRIPCION";
            lookUpPaquete.Properties.ValueMember = "PAQUETE";
            lookUpPaquete.EditValue = null;
        }
        public void Carga_lookUp_Bodega(string ctipobodega)
        {
            DataTable dt_bo = new DataTable();
            dt_bo = Listado_MaestrosBL.Listar_Bodega(ctipobodega, Global.vUserBaseDatos).Tables[0];
            lookUpPaquete.Properties.DataSource = dt_bo;
            lookUpPaquete.Properties.DisplayMember = "NOMBRE";
            lookUpPaquete.Properties.ValueMember = "BODEGA";
            lookUpPaquete.EditValue = null;
        }


        //public void Carga_lookUp_Familia(string ctipofamilia)
        //{
        //    DataTable dt_fa = new DataTable();
        //    dt_fa = Listado_MaestrosBL.Listar_Familia(Global.vUserBaseDatos).Tables[0];    //CLASIFICACION,DESCRIPCION
        //    lookUpFamilia.Properties.DataSource = dt_fa;
        //    lookUpFamilia.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpFamilia.Properties.ValueMember = "CLASIFICACION";
        //    lookUpFamilia.EditValue = null;
        //}


        #endregion

        private void btnPreferencia_Click(object sender, EventArgs e)
        {
            //CargaComboConPreferencias();
        }


        //public void CargaComboConPreferencias()
        //{
        //    lookUpBodega.EditValue = "";
        //    lookUpFamilia.EditValue = "";

        //    //lookUpEditBodega.EditValue = "SAN BORJA, SAN LUIS, LOS OLIVOS, SURQUILLO, CAJAMARCA, ICA, CHINCHA, MANSICHE, PIEROLA, CHICLAYO, AREQUIPA, AREQUIPA II, HUANCAYO II, PIURA";
        //    //"0001, 0002, 0003, 0004, 0005, 0006, 0007, 0008, 0009, 0010, 0011, 0012, 0013, 0014"
        //    string preferencia_bodega = "0001, 0002, 0003, 0004, 0005, 0006, 0007, 0008, 0009, 0010, 0011, 0012, 0013, 0014, 0015, 0016, 0017";
        //    string preferencia_familia = "LL";

        //    lookUpBodega.EditValue = preferencia_bodega;
        //    lookUpFamilia.EditValue = preferencia_familia;
        //    //lookUpEditSubFamilia.EditValue = preferencia.subfamilia;
        //    //lookUpEditGrupo.EditValue = preferencia.grupo;

        //    lookUpBodega.Text = "SAN BORJA, SAN LUIS, LOS OLIVOS, SURQUILLO, CAJAMARCA, ICA, CHINCHA, MANSICHE, PIEROLA, CHICLAYO, AREQUIPA, AREQUIPA II, HUANCAYO II, PIURA, EXTERNO VIAS CUSCO, EXTERNO CONSORCIO CAJAMARCA 2, EXTERNO RETAMAS";
        //    lookUpFamilia.Text = "LLANTA";
        //    lookUpFamilia.Refresh();
        //    lookUpBodega.Refresh();
        //}

        //private void txtArticulo_Leave(object sender, EventArgs e)
        //{

        //    if (ComercialBL.ExisteArticuloBL(txtArticulo.Text, Global.vUserBaseDatos) == true)
        //    {
        //        CargaDatosArticulo(txtArticulo.Text);
        //        txtDescripcion.Text = articulo_be.descripcion;
        //        txtUnidad.Text = articulo_be.unidad_almacen;
        //        //txtUnidadsVen.Focus();
        //    }
        //    else
        //    {
        //        txtArticulo.Text = "";
        //        txtArticulo.Focus();
        //        MessageBox.Show("El Articulo No Existe.... Haga Doble Clik en Articulo para mostar los Articulos...");
        //        return;
        //    }

        //}

        //private void txtArticulo_DoubleClick(object sender, EventArgs e)
        //{
        //    MuestraFormularioBusquedaArticulos(txtArticulo.Text, Global.vUserBaseDatos);

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



    }
}