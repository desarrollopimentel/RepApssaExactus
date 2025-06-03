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
using ApssaExactus.LIBCS;
using ApssaExactus.LIBVB;
using System.Threading.Tasks;
using System.Diagnostics;
using DevExpress.XtraGrid;



/* 
 * UPDATE : 2023/04/03
 * REMARKS: Formulario para privilegios Tesoreria
*/

namespace ApssaExactus
{
    public partial class frm_PrivilegiosTesoreria3 : DevExpress.XtraEditors.XtraForm
    {
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        string sucursal = string.Empty;
        string zonas = string.Empty;

        public string articulo = string.Empty;
        public string bodega = string.Empty;
        public string nombre = string.Empty;
        public string stock = string.Empty;

        string tipobodega = string.Empty;
        string familia = string.Empty;
        string subfamilia = string.Empty;
        string grupo = string.Empty;

        string moneda = string.Empty;

        public ArticuloBE articulo_be = null;
        public DateTime var_fecha_ini { get; set; }
        public DateTime var_fecha_fin { get; set; }

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

        public frm_PrivilegiosTesoreria3(string _base, string _user)
        {
            InitializeComponent();

            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
            //_password = _pass;      // txtPassword.Text;
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frm_PrivilegiosTesoreria3 m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frm_PrivilegiosTesoreria3 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frm_PrivilegiosTesoreria3(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frm_PrivilegiosTesoreria3_Load(object sender, EventArgs e)
        {
            //--------------------------------------
            // CARGA_ENTORNO_VARIABLES
            //passwordEncrypt = GeneralLibCS.cifrarTextoAES(_password, Global.v_palabraPaso, Global.v_valorRGBSalt, Global.v_algoritmoEncriptacionHASH, Global.v_iteraciones, Global.v_vectorInicial, Global.v_tamanoClave);
            //AccederEntornoReportesApssa(_base_datos, _usuario, passwordEncrypt);
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //--------------------------------------              

            //setting
            //txtUsuario.Visible = false;
            //txtBaseDatos.Visible = false;
            //txtPassword.Visible = false;

            //articuloSelec.Visible = false;
            //lblGridActivo.Visible = false;
            //xtraTabPageParametros.PageEnabled = false;
            xtraTabPageControlSA.PageEnabled = false;
            xtraTabPageControlCA.PageEnabled = false;

            DateTime? fechatemp = null;
            DateTime? fecha1 = null;
            DateTime? fecha2 = null;
            fechatemp = DateTime.Today;

            if (fechatemp.Value.Month == 12)
            {
                fecha1 = new DateTime(fechatemp.Value.Year + 1, 0, 1);
                fecha2 = new DateTime(fechatemp.Value.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 0, 1);
                fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
            }

            txtUsuario.ReadOnly = true;
            txtNombreUsuario.ReadOnly = true;

            var_fecha_ini = Convert.ToDateTime(fecha1); // Convert.ToDateTime("01/07/2022");
            var_fecha_fin = Convert.ToDateTime(fecha2); // DateTime.Today;


            ActualizarGrillas();
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

        //public void MuestraFormBuscaArticulo()
        //{
        //    frmBuscaArticulo frmBusca = new frmBuscaArticulo();
        //    frmBusca._articulo_in = txtUsuario.Text;
        //    frmBusca._articulodescripcion_in = txtNombreUsuario.Text;

        //    frmBusca.ShowDialog();
        //    if ((frmBusca._articulo_out != null) && (frmBusca._articulo_out != ""))
        //    {
        //        txtUsuario.Text = frmBusca._articulo_out;
        //        txtNombreUsuario.Text = frmBusca._articulodescripcion_out;
        //        txtArticuloUnidad.Text = frmBusca._unidad_out;
        //    }
            
        //}

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrillas();
        }

        public void ActualizarGrillas()
        {
            //SinAcceso
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de Existencias ....", "Espere por favor.."))
            {
                DataTable dtSinAcceso = new DataTable();
                dtSinAcceso = TesoreriaBL.dtCargarUsuarioBancosAccesos_BL(0, Global.vUserBaseDatos);
                gcSinAcceso.DataSource = dtSinAcceso;
            }

            ConfiguraGrilla(gvSinAcceso);

            //ConAcceso
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de Existencias ....", "Espere por favor.."))
            {
                DataTable dtConAcceso = new DataTable();
                dtConAcceso = TesoreriaBL.dtCargarUsuarioBancosAccesos_BL(1, Global.vUserBaseDatos);
                gcConAcceso.DataSource = dtConAcceso;
            }

            ConfiguraGrilla(gvConAcceso);
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


    
        #region RUTINAS_VARIOS

        //public void ConfiguraGridKardex()
        //public void ConfiguraGrilla(DevExpress.XtraGrid.Views.Grid.GridView gv)
        public void ConfiguraGridExistencia(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            //gvKardex.Appearance.Row.Font = new System.Drawing.Font(gvKardex.Appearance.Row.Font, FontStyle.Bold);
            //gvKardex.Appearance.Row.Options.UseFont = true;
            //System.Drawing.Font fnt = new System.Drawing.Font(gvKardex.Appearance.Row.Font.Name, 7);
            //gvKardex.Appearance.HeaderPanel.Font = fnt;
            //gvKardex.Appearance.Row.Font = fnt;
            //gvKardex.OptionsView.ShowGroupPanel = false;
            //gvKardex.OptionsView.ColumnAutoWidth = false;
            //gvKardex.BestFitColumns();

            if (gv.RowCount > 0)
            {
                //// COLOR
                gv.Columns["BODEGA"].AppearanceCell.BackColor = Color.LightGray;
                gv.Columns["NOMBRE"].AppearanceCell.BackColor = Color.LightGray;
                gv.Columns["DISPONIBLE"].AppearanceCell.BackColor = Color.Bisque;
                gv.Columns["RESERVADO"].AppearanceCell.BackColor = Color.Bisque;
                gv.Columns["REMITIDO"].AppearanceCell.BackColor = Color.Bisque;
                gv.Columns["STOCK"].AppearanceCell.BackColor = Color.Bisque;

                //gvKardex.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
                //gvKardex.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;

            }


            ////formateo
            //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
            //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
            //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatString = "##,###,###,##0";
        }
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

        #endregion









        public void MuestraFormularioBusquedaArticulos(string art, string bd)
        {
            frmBusca_Articulo frmArt = new frmBusca_Articulo();
            frmArt.familia = null;
            frmArt.subfamilia = null;
            frmArt.grupo = null;
            frmArt._articulo = txtUsuario.Text;
            frmArt.ShowDialog();
            if (frmArt.DialogResult == DialogResult.OK)
            {
                //txtArticulo.Text = frmArt._vendedor_selecc;
                //txtArticulo_Nombre.Text = frmArt._vendedor_nombre_selecc;
            }
            else
            {
                //MessageBox.Show("Vuelva a intentar....");  // TODO numero de intentos
            }
        }

        public void CargaDatosArticulo(string vendedorOK)
        {
            if (articulo_be == null)
                articulo_be = new ArticuloBE();
            DataTable dtArt = new DataTable();
            dtArt = ComercialBL.CargaDatosArticuloBL(vendedorOK, Global.vUserBaseDatos);
            DataTableReader lectoruser = dtArt.CreateDataReader();
            while (lectoruser.Read())
            {
                articulo_be.articulo = lectoruser[0].ToString();
                articulo_be.descripcion = lectoruser[1].ToString();
                articulo_be.unidad_almacen = lectoruser[2].ToString();
            }
        }


        public void ExportarGrid(GridControl control, DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            if (gv.DataRowCount > 0)
            {
                control.ShowPrintPreview();
            }
            else
            {
                MessageBox.Show("No hay informacion que Exportar");
            }
        }


        private void btnAccesoOtorgar_Click(object sender, EventArgs e)
        {
            if (gvSinAcceso.RowCount > 0)
            {
                //DialogResult dialogResult = MessageBox.Show("Privilegios Tesoreria " + "."
                //                                           + "\n"
                //                                           + "\nEsta seguro de seguir?", "Privilegios Tesoreria", MessageBoxButtons.YesNo);

                DialogResult dialogResult = DialogResult.Yes;

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        OtorgarAccesos();

                        //MessageBox.Show("Se otorgo los accesos!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                //CargarInformacionXls();
            }

            ActualizarGrillas();

            MessageBox.Show("Se otorgo los accesos de los usuario seleccionados !!");

        }

        private void btnAccesoRetirar_Click(object sender, EventArgs e)
        {
            if (gvConAcceso.RowCount > 0)
            {
                DialogResult dialogResult = DialogResult.Yes;

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        RetirarAccesos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                //CargarInformacionXls();
            }

            ActualizarGrillas();

            MessageBox.Show("Se retiro los accesos de los usuario seleccionados !!");
        }

        private void OtorgarAccesos()
        {
            int[] seleccionados;
            seleccionados = gvSinAcceso.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando informacion ....", "Espere por favor.."))
                {
                    DataRow rowxls;

                    foreach (int row in seleccionados)
                    {
                        rowxls = gvSinAcceso.GetDataRow(row);

                        if (rowxls["USUARIO"] != null && rowxls["USUARIO"].ToString() != "")
                        {
                            _usuario = rowxls["USUARIO"].ToString();
                            
                            TesoreriaBL.ActualizarAccesosUsuario_BL(_usuario, 1, Global.vUserUsuario, Global.vUserBaseDatos); // 1 - dar acceso
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + "");
            }
        }


        private void RetirarAccesos()
        {
            int[] seleccionados;
            seleccionados = gvConAcceso.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Validando informacion ....", "Espere por favor.."))
                {
                    DataRow rowxls;

                    foreach (int row in seleccionados)
                    {
                        rowxls = gvConAcceso.GetDataRow(row);

                        if (rowxls["USUARIO"] != null && rowxls["USUARIO"].ToString() != "")
                        {
                            _usuario = rowxls["USUARIO"].ToString();

                            TesoreriaBL.ActualizarAccesosUsuario_BL(_usuario, 0, Global.vUserUsuario, Global.vUserBaseDatos); // 0 - retira acceso
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel " + "");
            }
        }

        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            string varAplicacionDescripcion = "";
            if (gvConAcceso.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", varAplicacionDescripcion + " -- > Privilegios Tesoreria");
                return;
            }
            else
            {
                gcConAcceso.ShowPrintPreview();
            }
        }



    }
}
