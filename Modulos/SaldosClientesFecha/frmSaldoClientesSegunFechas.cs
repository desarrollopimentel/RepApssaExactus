using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Exactus.LIBVB;
//using ApssaExactus.LIBCS;
//using ApssaExactus.LIBVB;

namespace ApssaExactus
{
    public partial class frmSaldoClientesSegunFecha : DevExpress.XtraEditors.XtraForm
    {
        //---------------------------------------------------------------------
        // CARGA_ENTORNO_VARIABLES
        //---------------------------------------------------------------------
        public Int32 NumIntentos = 1;
        public string _base_datos = null;
        public string _usuario = null;
        //public string _password = null;
        public UsuarioReporteExactus usuarioreporte = null;
        public static DataSet ds_user;           //Usuario        
        public static DataSet ds_luc;            //Tiendas
        public static DataSet ds_lub;            //Bodegas
        public static DataSet ds_zon;            //Zonas

        string passwordEncrypt = null;
        public string cUsuarioActual = null;
        //---------------------------------------------------------------------_base, _user, _pass
        //---------------------------------------------------------------------

        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }

        public DateTime dFechaIniCanje { get; set; }
        public DateTime dFechaFinCanje { get; set; }


        string contribuyente = string.Empty;
        string cliente = string.Empty;
        public static string vClienteSelecc = null;
        public static string vClienteNombreSelecc = null;
        public string vmensaje = string.Empty;
        public bool TeclaEnter = false;
        public bool EsCobranzaDudoza = false;
        public bool EsClienteCastigado = false;

        public string _cliente = string.Empty;
        public string _tipo = string.Empty;
        public string _documento = string.Empty;
        public string _moneda = string.Empty;
        public string _estado = string.Empty;
        public Decimal _monto = 0;
        public string _referencia = string.Empty;
        public DateTime _fecha_emision { get; set; }
        public DateTime _fecha_vcmto { get; set; }

        public Boolean _ImprimirLetra = false;

        public string _moroso = "";
        public string _cobro_judicial = "";
        public string _formato_letra = "";

        public string _aux_cliente = string.Empty;
        public string _aux_clinete_nombre = string.Empty;

        public Boolean _primera_vez = true;
        public string _analista_code = string.Empty;
        public string _analista_nombre = string.Empty;
        public Int32 ejercicio = 0;

        public DataTable dtCastigado = new DataTable();

        public string TipoOperacionCRUD = string.Empty;

        public string varObservaciones = string.Empty;


        public string clausula = string.Empty;

        public Int16 vID_CLAUSULA = 0;
        public string vTIPO = string.Empty;
        public string vCLAUSULA = string.Empty;
        public string vACTIVO = string.Empty;
        public DateTime vFECHA;

        public string varClausula = string.Empty;
        public DateTime varFecha;
        public string varEstado = string.Empty;
        public string varTipo = string.Empty;

        public FormatoClausula formato_clausula = null;
        public string TipoClausula = string.Empty;

        public string _tipo_canje = string.Empty;
        public string _documento_canje = string.Empty;

        public frmSaldoClientesSegunFecha(string _base, string _user)
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
        private static frmSaldoClientesSegunFecha m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;
        /// ----------------------------------------------------------------------------

        /// Instancia por defecto
        public static frmSaldoClientesSegunFecha DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmSaldoClientesSegunFecha(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmSaldoClientesSegunFecha_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //--------------------------------------------------------------- 

            _primera_vez = true;
            EsClienteCastigado = false;
            //
            //DeshabilitaCajas();
            
            //inicializa campos
            
            //txtEjercicio.ReadOnly = true;
            //valores default   
            dpFechaIni.Text = "01/01/2005";    //DateTime.Today.ToShortDateString();
            dpFechaFin.Text = DateTime.Today.ToShortDateString();
            //txtCliente.Text = "20438933272";   // "20464428730";    // "20504086713"; // "20491793911";    // "20464428730";

            ejercicio = DateTime.Now.Year;
            //CargaCboMes();
            //Carga_lookUp_Analista();
            //Accesos_Usuario();
            
            //FORMATO LETRAS // RDLC, CRYSTAL
            _formato_letra = "CRYSTAL";

            //txtTipoClausula.Visible = false;
            TipoClausula = "CREDITOS"; // "CREDITOS","LEGAL"
            //cmdTIPO.Text = TipoClausula;

            _tipo_canje = "";
            _documento_canje = "";

            DateTime? fechatemp = null;
            DateTime? fecha1 = null;
            DateTime? fecha2 = null;
            fechatemp = DateTime.Today;
            int ano_temp = DateTime.Now.Year;

            if (fechatemp.Value.Month == 12)
            {
                //fecha1 = new DateTime(fechatemp.Value.Year + 1, 0, 1);
                fecha1 = Convert.ToDateTime("01/01/" + ano_temp.ToString());
                fecha2 = new DateTime(fechatemp.Value.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                //fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 0, 1);
                fecha1 = Convert.ToDateTime("01/01/" + ano_temp.ToString());
                fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
            }

            //this.dpFechaIniCanje.Text = Convert.ToString(fecha1);
            //this.dpFechaFinCanje.Text = Convert.ToString(fecha2);

            //dFechaIniCanje = Convert.ToDateTime(this.dpFechaIniCanje.Text);
            //dFechaFinCanje = Convert.ToDateTime(this.dpFechaFinCanje.Text);

            _primera_vez = false;


        }

        //---------------------------------------------------------------------------------------------
        #region CARGA_ENTORNO_VARIABLES
        public void ObtenerusuarioActual()
        {
            cUsuarioActual = EntornoBL.ObtenerUsuarioActualExactus_BL(Global.vUserBaseDatos);

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

                        //txtUsuario.Text = Global.vUserUsuario;
                        //txtNombreUsuario.Text = Global.vUserNombre;

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
                usuarioreporte = new UsuarioReporteExactus();

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

        //private void Accesos_Usuario()
        //{
        //    //LoginBL.UsuarioBL login = new LoginBL.UsuarioBL();        //MAXMAX08112016
        //    //switch (login.dtAccesos_Tag(Global.vUserUsuario, this.tp_auditoria.Tag.ToString(), Global.vUserBaseDatos))
        //    switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.xtraTabPageAuditoria.Tag.ToString(), Global.vUserBaseDatos))
        //    {
        //        case 0:
        //            xtraTabPageAuditoria.PageEnabled=false;// chk_margenes.Enabled = false;
        //            break;
        //        case 1:
        //            xtraTabPageAuditoria.PageEnabled = true;
        //            break;
        //        case 9:
        //            xtraTabPageAuditoria.PageEnabled = false;
        //            break;
        //    }
        //    ///accesos de IMPRESION FORMATO AUDITORIA
        //    //switch (login.dtAccesos_Tag(Global.vUserUsuario,this.grp_TipoImpresion.Tag.ToString(),Global.vUserBaseDatos))
        //    switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.grp_TipoImpresion.Tag.ToString(), Global.vUserBaseDatos))
        //    {
        //        case 0:
        //            grp_TipoImpresion.Properties.Items[0].Enabled = false;
        //            break;
        //        case 1:
        //            grp_TipoImpresion.Properties.Items[0].Enabled = true;
        //            break;
        //        case 9:
        //            grp_TipoImpresion.Properties.Items[0].Enabled = false;
        //            break;
        //    }
        //    //chk_margenes.Enabled = Convert.ToBoolean(login.dtAccesos_Tag(Global.vUserUsuario, chk_margenes.Tag.ToString(), Global.vUserBaseDatos));
        //    ///accesos de IMPRESION LETRA
        //    switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.btnImprimirLetra.Tag.ToString(), Global.vUserBaseDatos))
        //    {
        //        case 0:
        //            btnImprimirLetra.Enabled = false;
        //            btnImprimirLetra2.Enabled = false;
        //            break;
        //        case 1:
        //            btnImprimirLetra.Enabled = true;
        //            btnImprimirLetra2.Enabled = true;
        //            break;
        //        case 9:
        //            btnImprimirLetra.Enabled = false;
        //            btnImprimirLetra2.Enabled = false;
        //            break;
        //    }
        //    ///accesos de ANALISTA CREDITO
        //    switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.panelControlAnalista.Tag.ToString(), Global.vUserBaseDatos))
        //    {
        //        case 0:
        //            panelControlAnalista.Enabled = false;
        //            break;
        //        case 1:
        //            panelControlAnalista.Enabled = true;
        //            break;
        //        case 9:
        //            panelControlAnalista.Enabled = false;
        //            break;
        //    }
        //}

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
            dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);

            using (WaitDialogForm waitDialog = new WaitDialogForm("Recuperando información, Espere por favor...", "Estado Cuenta Clientes"))
            {
                try
                {
                    //VefificarSiEsClienteCastigado(cliente, Global.vUserBaseDatos);
                    //CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
                    ObtenerSaldosClientes( dFechaFin, Global.vUserBaseDatos);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }


        public void ObtenerSaldosClientes(DateTime dFecFin, string baseusuario)
        {
            //EsCobranzaDudoza = false;
            //double sumSaldoLocalCliente = 0;
            //double sumSaldoDolarCliente = 0;

            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dt = new DataTable();
            dt = CreditosBL.dtObtenerSaldosClientesBL( dFecFin, baseusuario);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    // acumula saldo cliente
            //    sumSaldoLocalCliente += Convert.ToDouble(dt.Rows[i]["SALDO_LOCAL"].ToString());
            //    sumSaldoDolarCliente += Convert.ToDouble(dt.Rows[i]["SALDO_DOLAR"].ToString());

            //    if (dt.Rows[i]["COB_DUD"].ToString() == "CBZA.DUDOZA")
            //    {
            //        EsCobranzaDudoza = true;
            //    }
            //}

            // saldo total cliente 
            //txtSaldoLocal.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoLocalCliente));
            //txtSaldoDolares.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoDolarCliente));

            gcDocumentos.DataSource = dt;
            //gcauditoria.DataSource = dt;
            ConfiguraGridEstadoCuenta();


        }




        //public void VefificarSiEsClienteCastigado(string cliente_verif, string baseusuario)
        //{
        //    EsClienteCastigado = false;
        //    //DataTable dtCastigado = new DataTable();
        //    dtCastigado = CreditosBL.dtEsClienteCastigadoBL(cliente_verif, "CA", baseusuario);
        //    if (dtCastigado.Rows.Count > 0)
        //    {
        //        EsClienteCastigado = true;
        //    }
        //    else
        //    {
        //        EsClienteCastigado = false;
        //    }
        //}



        public void CargaSaldoDocumentosCliente(string contrib, string client, DateTime dFecIni, DateTime dFecFin, string baseusuario)
        {
            EsCobranzaDudoza = false;
            double sumSaldoLocalCliente = 0;
            double sumSaldoDolarCliente = 0;

            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dt = new DataTable();
            dt = objEstadoCuentaBL.dtSaldoDocumentosClienteBL(contrib, client, dFecIni, dFecFin, baseusuario);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // acumula saldo cliente
                sumSaldoLocalCliente += Convert.ToDouble(dt.Rows[i]["SALDO_LOCAL"].ToString());
                sumSaldoDolarCliente += Convert.ToDouble(dt.Rows[i]["SALDO_DOLAR"].ToString());

                if (dt.Rows[i]["COB_DUD"].ToString() == "CBZA.DUDOZA")
                {
                    EsCobranzaDudoza = true;
                } 
            }

            if (EsCobranzaDudoza == true)
            {
                vmensaje = "Cobranza Dudosa";
                //lblMensajeCobranzaDudosa.Text = vmensaje;
                //lblMensajeCobranzaDudosa.Visible = true;
                //lblMensajeCobranzaDudosa2.Text = vmensaje;
                //lblMensajeCobranzaDudosa2.Visible = true;
                //lblMensajeLetras.Text = vmensaje;
                //lblMensajeLetras.Visible = true;
                //lblMensajeInformacion.Text = vmensaje;
                //lblMensajeInformacion.Visible = true;
            }
            else
            {
                vmensaje = "               ";
                //lblMensajeCobranzaDudosa.Text = "";
                //lblMensajeCobranzaDudosa.Visible = false;
                //lblMensajeCobranzaDudosa2.Text = "";
                //lblMensajeCobranzaDudosa2.Visible = false;
                //lblMensajeLetras.Text = "";
                //lblMensajeLetras.Visible = false;
                //lblMensajeInformacion.Text = "";
                //lblMensajeInformacion.Visible = false;
            } 


            // saldo total cliente 
            //txtSaldoLocal.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoLocalCliente));
            //txtSaldoDolares.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoDolarCliente));

            gcDocumentos.DataSource = dt;
            //gcauditoria.DataSource = dt;
            ConfiguraGridEstadoCuenta();


        }






        public void ConfiguraGridEstadoCuenta()
        {
            gvDocumentos.OptionsView.ColumnAutoWidth = false;
            gvDocumentos.BestFitColumns();
            Font fnt = new Font(gvDocumentos.Appearance.Row.Font.Name, 8);
            gvDocumentos.Appearance.HeaderPanel.Font = fnt;
            gvDocumentos.Appearance.Row.Font = fnt;
            gvDocumentos.Appearance.Row.Options.UseFont = true;
            gvDocumentos.OptionsView.ShowGroupPanel = false;
            gvDocumentos.OptionsView.ShowIndicator = false;
            gvDocumentos.OptionsBehavior.Editable = false;
            gvDocumentos.OptionsSelection.EnableAppearanceFocusedCell = false;

            ConfiguraGrilla(gvDocumentos);

            //// ordenamiento
            //gvDocumentos.ClearSorting();
            //gvDocumentos.Columns["FECHADOC"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            ////formateo
            //gvDocumentos.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvDocumentos.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvDocumentos.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvDocumentos.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvDocumentos.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvDocumentos.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvDocumentos.Columns["SALDO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvDocumentos.Columns["SALDO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            ////---------------------/*FORMATO PARA GV DE AUTORIA*/--------------------------------------//
            //gvauditoria.OptionsView.ColumnAutoWidth = false;
            //gvauditoria.BestFitColumns();

            //Font fnt2 = new Font(gvauditoria.Appearance.Row.Font.Name, 8);
            //gvauditoria.Appearance.HeaderPanel.Font = fnt2;
            //gvauditoria.Appearance.Row.Font = fnt2;
            //gvauditoria.Appearance.Row.Options.UseFont = true;
            //gvauditoria.OptionsView.ShowGroupPanel = false;
            //gvauditoria.OptionsView.ShowIndicator = false;
            //gvauditoria.OptionsBehavior.Editable = false;//////////////////////////////////
            //gvauditoria.OptionsSelection.EnableAppearanceFocusedCell = false;
            //// ordenamiento
            //gvauditoria.ClearSorting();
            //gvauditoria.Columns["FECHADOC"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //formateo
            //gvDocumentos.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvDocumentos.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["MONTO_SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["MONTO_SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["MONTO_SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["MONTO_SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["SALDO_ACTUAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["SALDO_ACTUAL"].DisplayFormat.FormatString = "##,###,###,##0.00";

            gvDocumentos.Columns["CORRIENTE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["CORRIENTE"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_030"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_030"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_060"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_060"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_090"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_090"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_120"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_120"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_150"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_150"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_180"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_180"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["HASTA_360"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["HASTA_360"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvDocumentos.Columns["MAYOR_360"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvDocumentos.Columns["MAYOR_360"].DisplayFormat.FormatString = "##,###,###,##0.00";

        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (gvDocumentos.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Estado de Cuenta Clientes.");
                return;
            }
            else
            {
                gcDocumentos.ShowPrintPreview();
            }
        }

        //---------------------------------------------------------------------------------------------



        //---------------------------------------------------------------------------------------------




        //private void gvEstadoCuenta_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    _cliente = gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "CLIENTE_REPORTE").ToString();
        //    _tipo = gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "TIPO").ToString();
        //    _documento = gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "DOCUMENTO").ToString();
        //    _monto = Convert.ToDecimal(gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "MONTO"));
        //    _moneda = gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "MONEDA").ToString();
        //    _referencia = gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "DOC_REFERENCIA").ToString();
        //    _fecha_emision = Convert.ToDateTime(gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "FECHADOC"));
        //    //_fecha_vcmto = Convert.ToDateTime(gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "FECHA_VENCE"));
        //    _fecha_vcmto = (DBNull.Value.Equals(gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "FECHA_VENCE"))) ? DateTime.Now : Convert.ToDateTime(gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "FECHA_VENCE").ToString());
        //    _estado = gvDocumentos.GetRowCellValue(gvDocumentos.FocusedRowHandle, "ESTADO").ToString();

        //    //gvEstadoCuenta.OptionsView.EnableAppearanceEvenRow = true;
        //    //gvEstadoCuenta.Appearance.EvenRow.BackColor = Color.Cyan;
        //    ////gvEstadoCuenta.Appearance.EvenRow.Options.UseBackColor = true;
        //    //gvEstadoCuenta.OptionsSelection.MultiSelect = true;
        //    //gvEstadoCuenta.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;

        //}



        #region RUTINAS_VARIAS

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









        #endregion


    }
}

