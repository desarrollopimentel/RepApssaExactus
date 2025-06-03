using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using System.IO;
//using DLL_EntidadNegocio;
//using eReceptor_DLL;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
using System.Net.Mail;
using System.Net;
//using Exactus.BE;
//using Exactus.BL;

namespace ApssaExactus
{
    public partial class frm_FacturasSinCargos : Form
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

        public static string vClienteSelecc = null;
        public static string vClienteNombreSelecc = null;
        public static int contador = 0;
        public static string vEmail_Cliente = string.Empty;

        //public static WEBSERVICE_APSSA.WSComprobanteSoapClient oServis = new WEBSERVICE_APSSA.WSComprobanteSoapClient();
        //public static WEBSERVICE_APSSA.ENPeticion oENPeticion = new WEBSERVICE_APSSA.ENPeticion();
        //public static WEBSERVICE_APSSA.ENRespuestaPDF oENRespuestaPDF = new WEBSERVICE_APSSA.ENRespuestaPDF();
        //public static WEBSERVICE_APSSA.ENRespuestaXML oENRespuestaXML = new WEBSERVICE_APSSA.ENRespuestaXML();
 

        public static ServiceReferenceGRR.ServicioGuiaRemisionRemitenteClient oGRServis = new ServiceReferenceGRR.ServicioGuiaRemisionRemitenteClient();
        public static ServiceReferenceGRR.en_ComprobanteConsultarRI oComprobanteConsultarRI = new ServiceReferenceGRR.en_ComprobanteConsultarRI();
        public static ServiceReferenceGRR.ene_ConsultarRI oConsultarRI = new ServiceReferenceGRR.ene_ConsultarRI();
        public static ServiceReferenceGRR.ens_ResultadoRI oResultadoRI = new ServiceReferenceGRR.ens_ResultadoRI();
        //public static ServiceReferenceGRR.en_ResultadoConsultarRI oen_ResultadoConsultarRI = new ServiceReferenceGRR.en_ResultadoConsultarRI();
        //public static ServiceReferenceGRR.ConsultarRI_GRRRequest oConsultarRI_GRRRequest = new ServiceReferenceGRR.ConsultarRI_GRRRequest();
        //public static ServiceReferenceGRR.ConsultarRI_GRRRequestBody oConsultarRI_GRRRequestBody = new ServiceReferenceGRR.ConsultarRI_GRRRequestBody();
        //public static ServiceReferenceGRR.ConsultarRI_GRRResponse oConsultarRI_GRRResponse = new ServiceReferenceGRR.ConsultarRI_GRRResponse();
        //public static ServiceReferenceGRR.ConsultarRI_GRRResponseBody oConsultarRI_GRRResponseBody = new ServiceReferenceGRR.ConsultarRI_GRRResponseBody();


        public string cNumeroGuiaRemision = string.Empty;
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        public string zona = string.Empty;
        public string tienda = string.Empty;
        public string opcion = string.Empty;
        DataTable dtFacturas = new DataTable();

        public string documentoGRE = string.Empty;
        public string serieGRE = string.Empty;
        public string numeroGRE = string.Empty;
        public string rutaGRE = string.Empty;
        public frm_FacturasSinCargos(string _base, string _user)
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
        private static frm_FacturasSinCargos m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frm_FacturasSinCargos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frm_FacturasSinCargos(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frm_ObtenerGRE_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------     
            // inicializo  
            DateTime? fechatemp = null;
            //DateTime? fecha1 = null;
            //DateTime? fecha2 = null;
            fechatemp = DateTime.Today;

            //if (fechatemp.Value.Month + 1 < 12)
            //{
            //    fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
            //    fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
            //}
            //else
            //{
            //    fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
            //    fecha2 = new DateTime(fechatemp.Value.Year + 1, 1, 1).AddDays(-1);
            //}

            //this.dpFechaIni.Text = Convert.ToString(fecha1);
            //this.dpFechaFin.Text = Convert.ToString(fecha2);

            this.dpFechaIni.Text = Convert.ToString(fechatemp);
            this.dpFechaFin.Text = Convert.ToString(fechatemp);

            //this.cboTipoFecha.Text = "Documento";
            this.cboAprobado.Text = "Sin Aprobar";
            this.cboCargo.Text = "Sin Cargo";

            //Configuracion
            //CargaCboZona();
            //CargaCboTienda();

            txtUsuario.Visible = false;
            txtNombreUsuario.Visible = false;

            xtraTabPage2.PageEnabled = false;

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




        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (gvFacturas.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Consulta Guias de Remision Electronicas");
                return;
            }
            else
            {
                gcFacturas.ShowPrintPreview();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if ((this.dpFechaIni.Text != null) && (this.dpFechaIni.Text != ""))
            {
                dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
            }

            if ((this.dpFechaFin.Text != null) && (this.dpFechaFin.Text != ""))
            {
                dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);
            }

            string aprobado = this.cboAprobado.EditValue.ToString();  // Todos, Sin Aprobar, Aprobado
            string cargo = this.cboCargo.EditValue.ToString();        // Todos, Sin Cargo, Con Cargo
            string proveedor = null;
            //////string _aprobado = aprobado.Substring(0, 1).ToUpper();             // T, S, A
            //////string _cargo = cargo.Substring(0, 1).ToUpper();                   // T, S , C

            string _aprobado = "";
            string _cargo = "";

            switch (aprobado.Substring(0, 1).ToUpper()) // T, S, A // Todos, Sin Aprobar, Aprobado
            {
                case "T":   // code block
                    _aprobado = null;
                    break;
                case "S":   // code block
                    _aprobado = "N";
                    break;
                case "A":   // code block
                    _aprobado = "S";
                    break;
                default:
                    _aprobado = null;
                    break;
            }


            switch (cargo.Substring(0, 1).ToUpper()) // T, S , C   // Todos, Sin Cargo, Con Cargo
            {
                case "T":   // code block
                    _cargo = null;
                    break;
                case "S":   // code block
                    _cargo = "N";
                    break;
                case "C":   // code block
                    _cargo = "S";
                    break;
                default:
                    _cargo = null;
                    break;
            }


            //ObtenerInventarios(dFechaFin, _tipo_fecha_doc, _moneda, tienda);
            ObtenerFacturas(dFechaIni, dFechaFin, proveedor, _aprobado, _cargo);

            //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FACTURAS_CP_SIN_CARGO]
            //(@FECHA_INI DATETIME,
            //@FECHA_FIN DATETIME, 
            //@PROVEEDOR VARCHAR(20) = null,
            //@APROBADO VARCHAR(1) = null,	-- S, N
            //@CARGO VARCHAR(1) = null	    -- S, N

        }

        //---------------------------------------------------------------------------------------------
        #region PARAMETROS
        public void CargaCboZona()
        {
            DataSet ds_zona = new DataSet();
            ds_zona = Listado_MaestrosBL.Listar_Sucursal2(Global.vUserUsuario, Global.vUserBaseDatos);
            foreach (DataRow Row in ds_zona.Tables[0].Rows)
            {
                this.cboZona.Properties.Items.Add(Row["Nombre"]);
            }
        }

        public void CargaCboTienda()
        {
            DataSet ds_tienda = new DataSet();
            ds_tienda = Listado_MaestrosBL.Listar_Zonas2(Global.vUserUsuario, Global.vUserBaseDatos);
            foreach (DataRow Row in ds_tienda.Tables[0].Rows)
            {
                this.cboTienda.Properties.Items.Add(Row["Nombre"]);
            }
        }

        public void CargaCboTiendaEnZona(string sucursal)
        {
            this.cboTienda.Properties.Items.Clear();

            DataSet ds_tiendas = new DataSet();
            ds_tiendas = Listado_MaestrosBL.Listado_ZonasInSucursal2(Global.vUserUsuario, sucursal, Global.vUserBaseDatos);
            foreach (DataRow Row in ds_tiendas.Tables[0].Rows)
            {
                this.cboTienda.Properties.Items.Add(Row["Nombre"]);
            }
        }

        private void cboZona_EditValueChanged(object sender, EventArgs e)
        {
            zona = cboZona.Text;
            if (cboZona.Text != string.Empty)
            {
                CargaCboTiendaEnZona(zona);
            }
        }

        #endregion PARAMETROS
        //---------------------------------------------------------------------------------------------

        public void ObtenerFacturas(DateTime var_fecini, DateTime var_fecfin, string var_proveedor, string var_aprobado, string var_cargo)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                dtFacturas = ContabilidadBL.dtListarDocumentosCP_BL(var_fecini, var_fecfin, var_proveedor, var_aprobado, var_cargo, Global.vUserBaseDatos);
                gcFacturas.DataSource = dtFacturas;
                //ConfiguraGridGuias();
                ConfiguraGrilla(gvFacturas);
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

        public void ConfiguraGridGuias()
        {
            gvFacturas.OptionsView.ColumnAutoWidth = false;
            gvFacturas.BestFitColumns();

            Font fnt = new Font(gvFacturas.Appearance.Row.Font.Name, 7);
            gvFacturas.Appearance.HeaderPanel.Font = fnt;
            gvFacturas.Appearance.Row.Font = fnt;
            gvFacturas.Appearance.Row.Options.UseFont = true;
            gvFacturas.OptionsView.ShowGroupPanel = false;
            gvFacturas.OptionsView.ShowIndicator = false;
            gvFacturas.OptionsBehavior.Editable = false;
            gvFacturas.OptionsSelection.EnableAppearanceFocusedCell = false;
            //// ordenamiento
            ////gvGuias.ClearSorting();
            ////gvGuias.Columns["FECHA"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            ////formateo
            //gvGuias.Columns["RESERV_DOC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvGuias.Columns["RESERV_DOC"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvGuias.Columns["CANT_DISPONIBLE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvGuias.Columns["CANT_DISPONIBLE"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvGuias.Columns["CANT_RESERVADA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvGuias.Columns["CANT_RESERVADA"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvGuias.Columns["CANT_TRANSITO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvGuias.Columns["CANT_TRANSITO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvGuias.Columns["CANT_REMITIDA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvGuias.Columns["CANT_REMITIDA"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvGuias.Columns["CANT_PEDIDA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvGuias.Columns["CANT_PEDIDA"].DisplayFormat.FormatString = "##,###,###,##0.00";

            //gvGuias.Columns["ZONA"].Width = 60;
            //gvGuias.Columns["TIPO"].Width = 60;
            //gvGuias.Columns["DOCUMENTO"].Width = 80;
            //gvGuias.Columns["ARTICULO"].Width = 60;
            //gvGuias.Columns["DESCRIPCION"].Width = 250;
            //gvGuias.Columns["RESERV_DOC"].Width = 60;
            //gvGuias.Columns["APLICACION"].Width = 150;
            //gvGuias.Columns["CANT_DISPONIBLE"].Width = 60;
            //gvGuias.Columns["CANT_RESERVADA"].Width = 60;
            //gvGuias.Columns["CANT_TRANSITO"].Width = 60;
            //gvGuias.Columns["CANT_REMITIDA"].Width = 60;
            //gvGuias.Columns["CANT_PEDIDA"].Width = 60;
            //gvGuias.Columns["BODEGA"].Width = 60;
            //gvGuias.Columns["USUARIO"].Width = 60;
            //gvGuias.Columns["FECHA_HORA"].Width = 80;
            //gvGuias.Columns["LOTE"].Width = 60;
            //gvGuias.Columns["LOCALIZACION"].Width = 60;
            //gvGuias.Columns["SERIE_CADENA"].Width = 60;
            //gvGuias.Columns["MODULO_ORIGEN"].Width = 60;

            //gvGuias.Columns["ZONA"].Caption = "ZONA";
            //gvGuias.Columns["TIPO"].Caption = "TIPO";
            //gvGuias.Columns["DOCUMENTO"].Caption = "DOCUMENTO";
            //gvGuias.Columns["ARTICULO"].Caption = "ARTICULO";
            //gvGuias.Columns["DESCRIPCION"].Caption = "DESCRIPCION";
            //gvGuias.Columns["RESERV_DOC"].Caption = "RESERV_DOC";
            //gvGuias.Columns["APLICACION"].Caption = "APLICACION";
            //gvGuias.Columns["CANT_DISPONIBLE"].Caption = "DISPONIBLE";
            //gvGuias.Columns["CANT_RESERVADA"].Caption = "RESERVADA";
            //gvGuias.Columns["CANT_TRANSITO"].Caption = "TRANSITO";
            //gvGuias.Columns["CANT_REMITIDA"].Caption = "REMITIDA";
            //gvGuias.Columns["CANT_PEDIDA"].Caption = "PEDIDA";
            //gvGuias.Columns["BODEGA"].Caption = "BODEGA";
            //gvGuias.Columns["USUARIO"].Caption = "USUARIO";
            //gvGuias.Columns["FECHA_HORA"].Caption = "FECHA_HORA";
            //gvGuias.Columns["LOTE"].Caption = "LOTE";
            //gvGuias.Columns["LOCALIZACION"].Caption = "LOCALIZACION";
            //gvGuias.Columns["SERIE_CADENA"].Caption = "SERIE_CADENA";
            //gvGuias.Columns["MODULO_ORIGEN"].Caption = "MODULO_ORIGEN";

            //gvGuias.Columns["RESERV_DOC"].AppearanceCell.BackColor = Color.WhiteSmoke;

        }

        private void gvGuias_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //documentoGRE = (DBNull.Value.Equals(gvGuias.GetRowCellValue(gvGuias.FocusedRowHandle, "DOCUMENTO"))) ? "" : (gvGuias.GetRowCellValue(gvGuias.FocusedRowHandle, "DOCUMENTO").ToString());
            //txtDocumentoSeleccionado.Text = documentoGRE;
        }

        /*
        private void btnObtenerPDF_Click(object sender, EventArgs e)
        {
            if (documentoGRE != "")
            {
                if (documentoGRE.Contains("-"))
                {                   
                    int longigut = documentoGRE.Length;               // 13
                    int long_ser = documentoGRE.LastIndexOf("-");     // 4
                    int long_num = (longigut - long_ser - 1);         // 13-4-1
                    
                    serieGRE = documentoGRE.Substring(0, long_ser);
                    numeroGRE = documentoGRE.Substring(long_ser+1, long_num);
                    GenerarPDF(serieGRE, Convert.ToInt16(numeroGRE));
                    VisualizarPDF(rutaGRE);
                }
            }
        }

        public void GenerarPDF(string _serie, Int16 _numero)
        {
            oConsultarRI.at_NumeroDocumentoIdentidad = "20100025915";
            oComprobanteConsultarRI.at_Serie = _serie;      // txtSerie.Text;   //"T007";
            oComprobanteConsultarRI.at_Numero = _numero;    // Convert.ToInt16(txtNumero.Text);    //13;
            oConsultarRI.ent_Comprobante = oComprobanteConsultarRI;
            oResultadoRI = oGRServis.ConsultarRI_GRR(oConsultarRI);

            string CadenaError = "";
            rutaGRE="";

            if (!(oResultadoRI == null))
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Cargando PDF, Espere por favor...", "<<<<Cargando Información>>>>"))
                {
                    FileStream fst;
                    BinaryWriter bwt;
                    fst = new FileStream("C:\\EXACTUSERP\\PDF\\" + "\\" + oResultadoRI.ent_Resultado.at_NombreRI, FileMode.Create, FileAccess.ReadWrite);
                    rutaGRE = "C:\\EXACTUSERP\\PDF\\" + "\\" + oResultadoRI.ent_Resultado.at_NombreRI;
                    bwt = new BinaryWriter(fst);
                    bwt.Write(oResultadoRI.ent_Resultado.at_ArchivoRI);
                    //bwt.Close();
                }

                //frm_VisualizadorGRE frm_pdf = new frm_VisualizadorGRE();
                //frm_pdf.path = rutaGRE;
                //frm_pdf.Show();

            }
            else
            {
                MessageBox.Show("no hay nada " + CadenaError);
            }
        }

        public void VisualizarPDF(string _ruta)
        {
            frm_VisualizadorGRE frm_pdf = new frm_VisualizadorGRE();
            frm_pdf.path = _ruta;
            frm_pdf.Show();
        }
        private void btnGR_PDF_Click(object sender, EventArgs e)
        {
            oConsultarRI.at_NumeroDocumentoIdentidad = "20100025915";
            oComprobanteConsultarRI.at_Serie = txtSerie.Text;   //"T007";
            oComprobanteConsultarRI.at_Numero = Convert.ToInt16(txtNumero.Text);    //13;
            oConsultarRI.ent_Comprobante = oComprobanteConsultarRI;

            oResultadoRI = oGRServis.ConsultarRI_GRR(oConsultarRI);

            string CadenaError = "";
            string ruta;

            if (!(oResultadoRI == null))
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("Cargando PDF, Espere por favor...", "<<<<Cargando Información>>>>"))
                {
                    FileStream fst;
                    BinaryWriter bwt;
                    //fst = new FileStream("C:\\EXACTUSERP\\PDF\\" + "\\" + oResultadoRI.ent_Resultado.at_NombreRI, FileMode.Create, FileAccess.ReadWrite);
                    //ruta = "C:\\EXACTUSERP\\PDF\\" + "\\" + oResultadoRI.ent_Resultado.at_NombreRI;
                    fst = new FileStream("C:\\EXACTUSERP\\PDF\\" + oResultadoRI.ent_Resultado.at_NombreRI, FileMode.Create, FileAccess.ReadWrite);
                    ruta = "C:\\EXACTUSERP\\PDF\\" + oResultadoRI.ent_Resultado.at_NombreRI;
                    bwt = new BinaryWriter(fst);
                    bwt.Write(oResultadoRI.ent_Resultado.at_ArchivoRI);
                    bwt.Close();
                }
                frm_VisualizadorGRE frm_pdf = new frm_VisualizadorGRE();
                frm_pdf.path = ruta;
                frm_pdf.Show();

            }
            else
            {
                MessageBox.Show("no hay nada " + CadenaError);
            }
        }
        */


    }
}
