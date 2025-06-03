using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;
//using DevExpress.Data.PivotGrid;
using System.Globalization;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Exactus.LIBVB;
//using ApssaExactus.LIBCS;
//using ApssaExactus.LIBVB;

namespace ApssaExactus
{
    public partial class frmTaller_Consultas : DevExpress.XtraEditors.XtraForm
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

        public string cliente = string.Empty;
        public string placa = string.Empty;
        public string nombre = string.Empty;
        public string tabSeleccionado = string.Empty;
        public frmTaller_Consultas(string _base, string _user)
        {
            InitializeComponent();
            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
            //_password = _pass;      // txtPassword.Text;
        }

        /// ------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmTaller_Consultas m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frmTaller_Consultas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmTaller_Consultas(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------

        private void frmTaller_Consultas_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            //passwordEncrypt = GeneralLibCS.cifrarTextoAES(_password, Global.v_palabraPaso, Global.v_valorRGBSalt, Global.v_algoritmoEncriptacionHASH, Global.v_iteraciones, Global.v_vectorInicial, Global.v_tamanoClave);
            //AccederEntornoReportesApssa(_base_datos, _usuario, passwordEncrypt);
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------               

            labelControl20.Visible = true;

            //prueba
            //PerfilUsuario = "";          ////CENTRO_SUR, NORTE

            btnExcel.Enabled = true;

            TabPagePedidos.PageEnabled = true;
            TabPageFacturas.PageEnabled = true;
            TabPageServicios.PageEnabled = true;
            TabPageServiciosDetalle.PageEnabled = true;
            TabPageNorte.PageEnabled = false;
            //groupControl1.Enabled = true;
            tabSeleccionado = "Pedidos";
            txtSeleccionado.Text = "Pedidos";


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


        private void btnProcesar_Click(object sender, EventArgs e)
        {
            cliente = txtCliente.Text;
            placa = txtPlaca.Text;
            nombre = txtNombre.Text;

            if (txtCliente.Text=="" & txtPlaca.Text=="" & txtNombre.Text == "")
            {
                MessageBox.Show("Debe seleccionar al menos un filtro!!");
            }
            else
            {
                //--'PEDIDO', 'FACTURA', 'OSERVICIO','DETALLESERV'
                ObtieneInformacionHistoricoPedidos(cliente, placa, nombre, "PEDIDO");
                ObtieneInformacionHistoricoFacturas(cliente, placa, nombre, "FACTURA");
                ObtieneInformacionHistoricoServicios(cliente, placa, nombre, "OSERVICIO");
                ObtieneInformacionHistoricoDetalleServicios(cliente, placa, nombre, "DETALLESERV");
            }


        }

        public void ObtieneInformacionHistoricoPedidos(string _cliente, string _placa, string _nombre, string _origen)
        {
            DataTable dtCliente = new DataTable();
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion Historica Pedidos...", "Procesando Información"))
            {
                dtCliente = ComercialBL.dtObtieneInformacionHistorico_BL(_cliente, _placa, _nombre, _origen, Global.vUserBaseDatos);
            }

            gcPedidos.DataSource = dtCliente;
            ConfiguraGridVentas(gvPedidos);
        }

        public void ObtieneInformacionHistoricoFacturas(string _cliente, string _placa, string _nombre, string _origen)
        {
            DataTable dtFacturas = new DataTable();
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion Historica Facturas...", "Procesando Información"))
            {
                dtFacturas = ComercialBL.dtObtieneInformacionHistorico_BL(_cliente, _placa, _nombre, _origen, Global.vUserBaseDatos);
            }

            gcFacturas.DataSource = dtFacturas;
            ConfiguraGridVentas(gvFacturas);
        }

        public void ObtieneInformacionHistoricoServicios(string _cliente, string _placa, string _nombre, string _origen)
        {
            DataTable dtServicios = new DataTable();
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion Historica Servicios...", "Procesando Información"))
            {
                dtServicios = ComercialBL.dtObtieneInformacionHistorico_BL(_cliente, _placa, _nombre, _origen, Global.vUserBaseDatos);
            }

            gcServicios.DataSource = dtServicios;
            ConfiguraGridVentas(gvServicios);
        }

        public void ObtieneInformacionHistoricoDetalleServicios(string _cliente, string _placa, string _nombre, string _origen)
        {
            DataTable dtDetalleServicios = new DataTable();
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion Historica Detalle Servicios...", "Procesando Información"))
            {
                dtDetalleServicios = ComercialBL.dtObtieneInformacionHistorico_BL(_cliente, _placa, _nombre, _origen, Global.vUserBaseDatos);
            }

            gcDetalleServicios.DataSource = dtDetalleServicios;
            ConfiguraGridVentas(gvDetalleServicios);
         }



        public void ConfiguraGridVentas(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.OptionsView.ShowGroupPanel = true;
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
            tabSeleccionado = xtraTabControl1.SelectedTabPage.Text;
            txtSeleccionado.Text = tabSeleccionado;     // xtraTabControl1.SelectedTabPage.Text;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //if (gvPedidos.RowCount <= 0)
            //{
            //    MessageBox.Show("No existe Informacion a Exportar.", "Consultas Taller");
            //    return;
            //}
            //else
            //{
            //    gcPedidos.ShowPrintPreview();
            //}


            if (tabSeleccionado == "Pedidos") {
                if (gvPedidos.RowCount <= 0)
                {
                    MessageBox.Show("No existe Informacion a Exportar.", "Consultas Taller - Pedidos");
                    return;
                }
                else
                {
                    gcPedidos.ShowPrintPreview();
                }
            }

            if (tabSeleccionado == "Facturas")
            {
                if (gvFacturas.RowCount <= 0)
                {
                    MessageBox.Show("No existe Informacion a Exportar.", "Consultas Taller - Facturas");
                    return;
                }
                else
                {
                    gcFacturas.ShowPrintPreview();
                }
            }

            if (tabSeleccionado == "Servicios")
            {
                if (gvServicios.RowCount <= 0)
                {
                    MessageBox.Show("No existe Informacion a Exportar.", "Consultas Taller - Servicios");
                    return;
                }
                else
                {
                    gcServicios.ShowPrintPreview();
                }
            }

            if (tabSeleccionado == "ServiciosDetalle")
            {
                if (gvDetalleServicios.RowCount <= 0)
                {
                    MessageBox.Show("No existe Informacion a Exportar.", "Consultas Taller - ServiciosDetalle");
                    return;
                }
                else
                {
                    gcDetalleServicios.ShowPrintPreview();
                }
            }

        }






    }
}
 