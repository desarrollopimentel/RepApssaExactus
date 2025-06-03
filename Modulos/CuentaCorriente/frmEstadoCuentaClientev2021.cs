using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
//using Exactus.LIBVB;
using DevExpress.Utils;

namespace ApssaExactus
{
    public partial class frmEstadoCuentaClientev2021 : DevExpress.XtraEditors.XtraForm
    {
        //---------------------------------------------------------------------
        // CARGA_ENTORNO_VARIABLES
        //---------------------------------------------------------------------
        public Int32 NumIntentos = 1;
        public string _base_datos = null;
        public string _usuario = null;
        //public string _password = null;
        //public UsuarioReporte usuarioreporte = null;
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

        //public frmEstadoCuentaClientev2021()
        //{
        //    InitializeComponent();
        //}

        public frmEstadoCuentaClientev2021(string _base, string _user)
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
        private static frmEstadoCuentaClientev2021 m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;
        /// ----------------------------------------------------------------------------

        /// Instancia por defecto
        public static frmEstadoCuentaClientev2021 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmEstadoCuentaClientev2021(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmEstadoCuentaClientev2021_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //--------------------------------------------------------------- 

            _primera_vez = true;
            EsClienteCastigado = false;
            //
            DeshabilitaCajas();
            
            //inicializa campos
            txtCliente.Text = "";
            txtClienteNombre.Text = "";
            lblMensajeCobranzaDudosa.Text = "";
            lblMensajeCobranzaDudosa.Visible = false;
            lblMensajeCobranzaDudosa2.Text = "";
            lblMensajeCobranzaDudosa2.Visible = false;
            lblMensajeLetras.Text = "";
            lblMensajeLetras.Visible = false;
            lblMensajeInformacion.Text = "";
            lblMensajeInformacion.Visible = false;
            lblMensajeIndicadores.Text = "";
            lblMensajeIndicadores.Visible = false;

            lblMensajeHistorico.Visible = false;
            lblMensajeEstado.Visible = false;
            lblMensajeInformacion.Visible = false;
            lblDetalleClienteCastigo.Visible = false;
            
            txtEjercicio.ReadOnly = true;
            //valores default   
            dpFechaIni.Text = "01/01/2005";    //DateTime.Today.ToShortDateString();
            dpFechaFin.Text = DateTime.Today.ToShortDateString();
            //txtCliente.Text = "20438933272";   // "20464428730";    // "20504086713"; // "20491793911";    // "20464428730";

            ejercicio = DateTime.Now.Year;
            CargaCboMes();
            Carga_lookUp_Analista();
            Accesos_Usuario();

            //default
            cboMes.Text = "ENERO";
            txtMes.Text = "1";

            //FORMATO LETRAS
            _formato_letra = "RDLC";    //"CRYSTAL";   // RDLC, CRYSTAL
            radioGroupFormatoLetra.SelectedIndex = 0;  // 1;
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

        private void Accesos_Usuario()
        {
            //LoginBL.UsuarioBL login = new LoginBL.UsuarioBL();        //MAXMAX08112016

            //switch (login.dtAccesos_Tag(Global.vUserUsuario, this.tp_auditoria.Tag.ToString(), Global.vUserBaseDatos))
            switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.tp_auditoria.Tag.ToString(), Global.vUserBaseDatos))
            {
                case 0:
                    tp_auditoria.PageEnabled=false;// chk_margenes.Enabled = false;

                    break;
                case 1:
                    tp_auditoria.PageEnabled = true;
                    break;
                case 9:
                    tp_auditoria.PageEnabled = false;
                    break;

            }
            ///accesos de IMPRESION FORMATO AUDITORIA
            //switch (login.dtAccesos_Tag(Global.vUserUsuario,this.grp_TipoImpresion.Tag.ToString(),Global.vUserBaseDatos))
            switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.grp_TipoImpresion.Tag.ToString(), Global.vUserBaseDatos))
            {
                case 0:
                    grp_TipoImpresion.Properties.Items[0].Enabled = false;
                    break;
                case 1:
                    grp_TipoImpresion.Properties.Items[0].Enabled = true;
                    break;
                case 9:
                    grp_TipoImpresion.Properties.Items[0].Enabled = false;
                    break;

            }

            //chk_margenes.Enabled = Convert.ToBoolean(login.dtAccesos_Tag(Global.vUserUsuario, chk_margenes.Tag.ToString(), Global.vUserBaseDatos));


            ///accesos de IMPRESION LETRA
            switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.btnImprimirLetra.Tag.ToString(), Global.vUserBaseDatos))
            {
                case 0:
                    btnImprimirLetra.Enabled = false;
                    btnImprimirLetra2.Enabled = false;
                    break;
                case 1:
                    btnImprimirLetra.Enabled = true;
                    btnImprimirLetra2.Enabled = true;
                    break;
                case 9:
                    btnImprimirLetra.Enabled = false;
                    btnImprimirLetra2.Enabled = false;
                    break;
            }

            ///accesos de ANALISTA CREDITO
            switch (LoginBL.UsuarioBL.dtAccesos_Tag(Global.vUserUsuario, this.panelControlAnalista.Tag.ToString(), Global.vUserBaseDatos))
            {
                case 0:
                    panelControlAnalista.Enabled = false;
                    break;
                case 1:
                    panelControlAnalista.Enabled = true;
                    break;
                case 9:
                    panelControlAnalista.Enabled = false;
                    break;
            }



        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text!="" || txtCliente.Text != string.Empty)
            {
                contribuyente = txtCliente.Text;
                cliente = txtCliente.Text;
                dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
                dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);
                lblMensajeCobranzaDudosa.Visible = false;
                lblMensajeCobranzaDudosa2.Visible = false;

                using (WaitDialogForm waitDialog = new WaitDialogForm("Recuperando información, Espere por favor...", "Estado Cuenta Clientes"))
                {
                    try
                    {
                        VefificarSiEsClienteCastigado(cliente, Global.vUserBaseDatos);
                        CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
                        CargaInformacionCliente(cliente, Global.vUserBaseDatos);
                        CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);
                        //CargaSaldoCliente(cliente, Global.vUserBaseDatos);
                        //historico
                        CargaDocumentosClienteHistorico(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);
                        ObtenerClienteIndicadores(ejercicio, cliente, Global.vUserBaseDatos);
                        //int anioActual = DateTime.Now.Year;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (EsClienteCastigado == true)
                {
                    //mostrar form
                    frmShowClienteCastigados frmCastigado = new frmShowClienteCastigados();
                    frmCastigado._cliente = txtCliente.Text;
                    frmCastigado._cliente_nombre = txtClienteNombre.Text;
                    frmCastigado.ShowDialog();
                }


            }
            else
            {
                MessageBox.Show("Ingrese un Cliente correcto !!! ");
                return;
            }
        }

        public void VefificarSiEsClienteCastigado(string cliente_verif, string baseusuario)
        {
            EsClienteCastigado = false;

            //DataTable dtCastigado = new DataTable();
            dtCastigado = CreditosBL.dtEsClienteCastigadoBL(cliente_verif, "CA", baseusuario);
            if (dtCastigado.Rows.Count > 0)
            {
                EsClienteCastigado = true;
                lblDetalleClienteCastigo.Visible = true;
            }
            else
            {
                EsClienteCastigado = false;
                lblDetalleClienteCastigo.Visible = false;
            }

        }

        //dtDocumentosClienteHistoricoBL
        public void ObtenerClienteIndicadores(Int32 ejerc, string client, string baseusuario)
        {
            DataTable dtIndi = new DataTable();
            dtIndi = CreditosBL.dtObtenerClienteIndicadoresBL(ejerc, client, baseusuario);
            gcIndicador.DataSource = dtIndi;
            ConfiguraGrilla(gvIndicador);
        }


        //dtDocumentosClienteHistoricoBL
        public void CargaDocumentosClienteHistorico(string contrib, string client, DateTime dFecIni, DateTime dFecFin, string baseusuario)
        {
            DataTable dtHist = new DataTable();
            dtHist = CreditosBL.dtDocumentosClienteHistoricoBL(contrib, client, dFecIni, dFecFin, baseusuario);
            gcHistorico.DataSource = dtHist;
            ConfiguraGrilla(gvHistorico);
        }



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
                lblMensajeCobranzaDudosa.Text = vmensaje;
                lblMensajeCobranzaDudosa.Visible = true;
                lblMensajeCobranzaDudosa2.Text = vmensaje;
                lblMensajeCobranzaDudosa2.Visible = true;
                lblMensajeLetras.Text = vmensaje;
                lblMensajeLetras.Visible = true;
                lblMensajeInformacion.Text = vmensaje;
                lblMensajeInformacion.Visible = true;
            }
            else
            {
                vmensaje = "               ";
                lblMensajeCobranzaDudosa.Text = "";
                lblMensajeCobranzaDudosa.Visible = false;
                lblMensajeCobranzaDudosa2.Text = "";
                lblMensajeCobranzaDudosa2.Visible = false;
                lblMensajeLetras.Text = "";
                lblMensajeLetras.Visible = false;
                lblMensajeInformacion.Text = "";
                lblMensajeInformacion.Visible = false;
            } 


            // saldo total cliente 
            txtSaldoLocal.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoLocalCliente));
            txtSaldoDolares.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoDolarCliente));

            gcEstadoCuenta.DataSource = dt;
            gcauditoria.DataSource = dt;
            ConfiguraGridEstadoCuenta();
            ConfiguraGridAuditoria();

        }

        public void CargaSaldoCliente(string cli, string baseuser)
        {
            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();            
            DataTable dt1 = new DataTable();
            dt1 = objEstadoCuentaBL.dtSaldoClienteBL(cli, baseuser);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //txtSaldoLocal.Text = dt1.Rows[i]["saldo_local"].ToString();
                //txtSaldoDolares.Text = dt1.Rows[i]["saldo_dolar"].ToString();
                //txtSaldoLocal.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt1.Rows[i]["SALDO_LOCAL"].ToString()));
                //txtSaldoLocal.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt1.Rows[i]["SALDO_DOLAR"].ToString()));
            }
        }

        public void CargaInformacionCliente(string cli, string baseuser)
        {
            _moroso = "";
            _cobro_judicial = "";
            double nDisponible = 0;
            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dt2 = new DataTable();
            dt2 = objEstadoCuentaBL.dtInformacionClienteBL(cli, baseuser);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                textANALISTA.Text = dt2.Rows[i]["ANALISTA"].ToString();
                textANALISTA_NOMBRE.Text = dt2.Rows[i]["ANALISTA_NOMBRE"].ToString();
                txtClienteNombre.Text = dt2.Rows[i]["NOMBRE"].ToString();                
                textCLIENTE.Text = dt2.Rows[i]["CLIENTE"].ToString();
                textNOMBRE.Text = dt2.Rows[i]["NOMBRE"].ToString();
                textMULTIMONEDA.Text = dt2.Rows[i]["MULTIMONEDA"].ToString();
                textMONEDA.Text = dt2.Rows[i]["MONEDA"].ToString();
                textCONDICION_PAGO.Text = dt2.Rows[i]["CONDICION_PAGO"].ToString();
                textNIVEL_PRECIO.Text = dt2.Rows[i]["NIVEL_PRECIO"].ToString();
                textMONEDA_NIVEL.Text = dt2.Rows[i]["MONEDA_NIVEL"].ToString();
                textACTIVO.Text = dt2.Rows[i]["ACTIVO"].ToString();
                textCATEGORIA_CLIENTE.Text = dt2.Rows[i]["CATEGORIA_CLIENTE"].ToString();
                textU_ACTIVIDAD.Text = dt2.Rows[i]["U_ACTIVIDAD"].ToString();
                textU_SUBACTIVIDAD.Text = dt2.Rows[i]["U_SUBACTIVIDAD"].ToString();
                textU_CATEGORIACREDITO.Text = dt2.Rows[i]["U_CATEGORIACREDITO"].ToString();
                txtMAXIMO.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt2.Rows[i]["LIMITE_CREDITO"].ToString()));
                txtMAXIMO.Properties.DisplayFormat.FormatString = "N2";
                txtMAXIMO.Properties.Mask.EditMask = "##,###,###,000.00";
                txtMAXIMO.Properties.Mask.UseMaskAsDisplayFormat = true;
                textEXCEDER_LIMITE.Text = dt2.Rows[i]["EXCEDER_LIMITE"].ToString();
                nDisponible = (Convert.ToDouble(dt2.Rows[i]["LIMITE_CREDITO"]) - Convert.ToDouble(dt2.Rows[i]["CONSUMIDO_LINEA"]));
                textDISPONIBLE.Text = nDisponible.ToString();
                textDISPONIBLE.Properties.DisplayFormat.FormatString = "N2";
                textDISPONIBLE.Properties.Mask.EditMask = "##,###,###,##0.00";
                textDISPONIBLE.Properties.Mask.UseMaskAsDisplayFormat = true;
                textSALDO_LOCAL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt2.Rows[i]["SALDO_LOCAL"].ToString()));
                textSALDO_DOLAR.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt2.Rows[i]["SALDO_DOLAR"].ToString()));
                textSALDO_CREDITO.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt2.Rows[i]["SALDO_CREDITO"].ToString()));
                textZONA.Text = dt2.Rows[i]["ZONA"].ToString();
                textRUTA.Text = dt2.Rows[i]["RUTA"].ToString();
                textVENDEDOR.Text = dt2.Rows[i]["VENDEDOR"].ToString();
                textCOBRADOR.Text = dt2.Rows[i]["COBRADOR"].ToString();
                textDIRECCION.Text = dt2.Rows[i]["DIRECCION"].ToString();
                textZONA_NOMBRE.Text = dt2.Rows[i]["ZONA_NOMBRE"].ToString();
                textRUTA_DESC.Text = dt2.Rows[i]["RUTA_DESC"].ToString();
                textVENDEDOR_NOMBRE.Text = dt2.Rows[i]["VENDEDOR_NOMBRE"].ToString();
                textCOBRADOR_NOMBRE.Text = dt2.Rows[i]["COBRADOR_NOMBRE"].ToString();
                textCOND_PAGO.Text = dt2.Rows[i]["COND_PAGO"].ToString();
                txtMonedaLinea.Text = dt2.Rows[i]["MONEDA"].ToString();
                txtMaximoLinea.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt2.Rows[i]["LIMITE_CREDITO"].ToString()));
                txtMaximoLinea.Properties.DisplayFormat.FormatString = "N2";
                txtMaximoLinea.Properties.Mask.EditMask = "##,###,###,##0.00";
                txtMaximoLinea.Properties.Mask.UseMaskAsDisplayFormat = true;
                txtConsumidoLinea.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(dt2.Rows[i]["CONSUMIDO_LINEA"].ToString()));
                //txtDisponibleLinea.Text = string.Format("{0:#,##0.##}", ((Convert.ToDouble(dt2.Rows[i]["LIMITE_CREDITO"]) - Convert.ToDouble(dt2.Rows[i]["CONSUMIDO_LINEA"])).ToString()));
                //txtDisponibleLinea.Text = string.Format("{0:#,##0.##}", nDisponible.ToString());
                txtDisponibleLinea.Text = nDisponible.ToString();
                txtDisponibleLinea.Properties.DisplayFormat.FormatString = "N2";
                txtDisponibleLinea.Properties.Mask.EditMask = "##,###,###,###.##";
                txtDisponibleLinea.Properties.Mask.UseMaskAsDisplayFormat = true;

                if (Convert.ToDouble(dt2.Rows[i]["LIMITE_CREDITO"].ToString())>0)
                {
                    checkLimiteCredito.Checked = true;
                }
                else
                {
                    checkLimiteCredito.Checked = false;
                }

                if (dt2.Rows[i]["EXCEDER_LIMITE"].ToString() == "S")
                {
                    checkExcederLimite.Checked = true;
                }
                else
                {
                    checkExcederLimite.Checked = false;
                }

                //textCOBRO_JUDICIAL.Text = dt2.Rows[i]["COBRO_JUDICIAL"].ToString();
                //textMOROSO.Text = dt2.Rows[i]["MOROSO"].ToString();
                if (dt2.Rows[i]["COBRO_JUDICIAL"].ToString() == "S")
                {
                    checkCobroJudicial.Checked = true;
                    _cobro_judicial = "COBRO JUDICIAL";
                }
                else
                {
                    checkCobroJudicial.Checked = false;
                    _cobro_judicial = "";
                }

                if (dt2.Rows[i]["MOROSO"].ToString() == "S")
                {
                    checkMoroso.Checked = true;
                    _moroso = "MOROSO";
                }
                else
                {
                    checkMoroso.Checked = false;
                    _moroso = "";
                }
            }

            if (EsClienteCastigado == true)
            {
                lblMensajeHistorico.Text = "CLIENTE CASTIGADO";
                lblMensajeEstado.Text = "CLIENTE CASTIGADO";
                lblMensajeInformacion.Text = "CLIENTE CASTIGADO";
                lblDetalleClienteCastigo.Text = "Ver Detalle en Historico";

                lblMensajeHistorico.Visible = true;
                lblMensajeEstado.Visible = true;
                lblMensajeInformacion.Visible = true;
                lblDetalleClienteCastigo.Visible = true;
            }
            else
            {

                lblMensajeHistorico.Text = _moroso + " " + _cobro_judicial;
                lblMensajeEstado.Text = _moroso + " " + _cobro_judicial;
                lblMensajeInformacion.Text = _moroso + " " + _cobro_judicial;

                if ((_cobro_judicial != "") || (_moroso != ""))
                {
                    lblMensajeHistorico.Visible = true;
                    lblMensajeEstado.Visible = true;
                    lblMensajeInformacion.Visible = true;
                }
                else
                {
                    lblMensajeHistorico.Visible = false;
                    lblMensajeEstado.Visible = false;
                    lblMensajeInformacion.Visible = false;
                }
            }

        }


        public void CargaLetrasEstadoCliente(string client, DateTime dFecFin, string baseusuario)
        {
            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dt3 = new DataTable();
            dt3 = objEstadoCuentaBL.dtLetrasEstadoClienteBL(client, dFecFin, baseusuario);
            gcLetras.DataSource = dt3;
            ConfiguraGridLetra();
            ResumenLetras();
        }

        public void ConfiguraGridLetra()
        {
            //gvLetras.OptionsView.ColumnAutoWidth = false;
            //gvLetras.BestFitColumns();
            //Font fnt = new Font(gvLetras.Appearance.Row.Font.Name, 8);
            //gvLetras.Appearance.HeaderPanel.Font = fnt;
            //gvLetras.Appearance.Row.Font = fnt;
            //gvLetras.Appearance.Row.Options.UseFont = true;
            //gvLetras.OptionsView.ShowGroupPanel = false;
            //gvLetras.OptionsView.ShowIndicator = false;
            //gvLetras.OptionsBehavior.Editable = false;
            //gvLetras.OptionsSelection.EnableAppearanceFocusedCell = false;

            ConfiguraGrilla(gvLetras);
            // ordenamiento
            gvLetras.ClearSorting();
            gvLetras.Columns["FECHA"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //formateo
            gvLetras.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvLetras.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvLetras.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvLetras.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvLetras.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvLetras.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
        }


        public void ConfiguraGridEstadoCuenta()
        {
            //gvEstadoCuenta.OptionsView.ColumnAutoWidth = false;
            //gvEstadoCuenta.BestFitColumns();
            //Font fnt = new Font(gvEstadoCuenta.Appearance.Row.Font.Name, 8);
            //gvEstadoCuenta.Appearance.HeaderPanel.Font = fnt;
            //gvEstadoCuenta.Appearance.Row.Font = fnt;
            //gvEstadoCuenta.Appearance.Row.Options.UseFont = true;
            //gvEstadoCuenta.OptionsView.ShowGroupPanel = false;
            //gvEstadoCuenta.OptionsView.ShowIndicator = false;
            //gvEstadoCuenta.OptionsBehavior.Editable=false;
            //gvEstadoCuenta.OptionsSelection.EnableAppearanceFocusedCell= false;

            ConfiguraGrilla(gvEstadoCuenta);
            // ordenamiento
            gvEstadoCuenta.ClearSorting();
            gvEstadoCuenta.Columns["FECHADOC"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //formateo
            gvEstadoCuenta.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEstadoCuenta.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvEstadoCuenta.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEstadoCuenta.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvEstadoCuenta.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEstadoCuenta.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvEstadoCuenta.Columns["SALDO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEstadoCuenta.Columns["SALDO"].DisplayFormat.FormatString = "##,###,###,##0.00";
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
            ////formateo
            //gvauditoria.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvauditoria.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvauditoria.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvauditoria.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvauditoria.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvauditoria.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvauditoria.Columns["SALDO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvauditoria.Columns["SALDO"].DisplayFormat.FormatString = "##,###,###,##0.00";
        }


        public void ConfiguraGridAuditoria()
        {
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

            ConfiguraGrilla(gvauditoria);

            // ordenamiento
            gvauditoria.ClearSorting();
            gvauditoria.Columns["FECHADOC"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //formateo
            gvauditoria.Columns["MONTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvauditoria.Columns["MONTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvauditoria.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvauditoria.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvauditoria.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvauditoria.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvauditoria.Columns["SALDO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvauditoria.Columns["SALDO"].DisplayFormat.FormatString = "##,###,###,##0.00";
        }


        public void MuestraFormBuscaCliente()
        {
            //frmBuscaCliente frmBusca = new frmBuscaCliente();
            frmBuscaClienteV2 frmBusca = new frmBuscaClienteV2();
            frmBusca._cliente = txtCliente.Text;
            frmBusca._clientenombre = txtClienteNombre.Text;
            txtCliente.Text = "";
            txtClienteNombre.Text = "";
            frmBusca.ShowDialog();
            //if (vClienteSelecc != null)
            //{
            //    txtCliente.Text = vClienteSelecc;
            //    txtClienteNombre.Text = vClienteNombreSelecc;
            //}
            if ((frmBusca._cliente_out != null) && (frmBusca._cliente_out != ""))
            {
                txtCliente.Text = frmBusca._cliente_out;
                txtClienteNombre.Text = frmBusca._clientenombre_out;
            }
        }

        private void ResumenLetras()
        {
            double sumEmitidaSOL = 0;
            double sumBancoSOL = 0;
            double sumTransitoSOL = 0;
            double sumProtestadaSOL = 0;
            double sumCarteraSOL = 0;
            double sumEmitidaDOL = 0;
            double sumBancoDOL = 0;
            double sumTransitoDOL = 0;
            double sumProtestadaDOL = 0;
            double sumCarteraDOL = 0;
            double sumLetrasSOL = 0;
            double sumLetrasDOL = 0;

            for (int i = 0; i < gvLetras.DataRowCount; ++i)
            {
                DataRow row = gvLetras.GetDataRow(i);

                sumLetrasSOL += Convert.ToDouble(row["SALDO_LOCAL"].ToString());
                sumLetrasDOL += Convert.ToDouble(row["SALDO_DOLAR"].ToString());

                switch (row["ESTADO_FINAL"].ToString())
                {
                    case "EC":    //EC , EN CARTERA
                        sumCarteraSOL += Convert.ToDouble(row["SALDO_LOCAL"].ToString());
                        sumCarteraDOL += Convert.ToDouble(row["SALDO_DOLAR"].ToString());
                        break;
                    case "PR":   //PR , PROTESTADA
                        sumProtestadaSOL += Convert.ToDouble(row["SALDO_LOCAL"].ToString());
                        sumProtestadaDOL += Convert.ToDouble(row["SALDO_DOLAR"].ToString());
                        break;
                    case "BA":    //BA , EN BANCO
                        sumBancoSOL += Convert.ToDouble(row["SALDO_LOCAL"].ToString());
                        sumBancoDOL += Convert.ToDouble(row["SALDO_DOLAR"].ToString());
                        break;
                    case "TR":    //TR , EN TRANSITO
                        sumTransitoSOL += Convert.ToDouble(row["SALDO_LOCAL"].ToString());
                        sumTransitoDOL += Convert.ToDouble(row["SALDO_DOLAR"].ToString());
                        break;
                    case "EM":   //EM , EMITIDA
                        sumEmitidaSOL += Convert.ToDouble(row["SALDO_LOCAL"].ToString());
                        sumEmitidaDOL += Convert.ToDouble(row["SALDO_DOLAR"].ToString());
                        break;
                    case "CA":    //CA , CANCELADO
                        //
                        break;
                    default:
                        break;
                }

            }

            txtEmitidaSOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumEmitidaSOL));
            txtBancoSOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumBancoSOL));
            txtTransitoSOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumTransitoSOL));
            txtProtestadaSOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumProtestadaSOL));
            txtCarteraSOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumCarteraSOL));
            txtEmitidaDOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumEmitidaDOL));
            txtBancoDOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumBancoDOL));
            txtTransitoDOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumTransitoDOL));
            txtProtestadaDOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumProtestadaDOL));
            txtCarteraDOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumCarteraDOL));
            txtLetrasSOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumLetrasSOL));
            txtLetrasDOL.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumLetrasDOL));
        }



        public void DeshabilitaCajas()
        {
            txtMonedaLinea.ReadOnly = true;
            txtMaximoLinea.ReadOnly = true;
            txtConsumidoLinea.ReadOnly = true;
            txtDisponibleLinea.ReadOnly = true;

            txtSaldoLocal.ReadOnly = true;
            txtSaldoDolares.ReadOnly = true;

            txtEmitidaSOL.ReadOnly = true;
            txtEmitidaDOL.ReadOnly = true;
            txtBancoSOL.ReadOnly = true;
            txtBancoDOL.ReadOnly = true;
            txtTransitoSOL.ReadOnly = true;
            txtTransitoDOL.ReadOnly = true;
            txtCarteraSOL.ReadOnly = true;
            txtCarteraDOL.ReadOnly = true;
            txtProtestadaSOL.ReadOnly = true;
            txtProtestadaDOL.ReadOnly = true;
            txtLetrasSOL.ReadOnly = true;
            txtLetrasDOL.ReadOnly = true;
            
            txtMAXIMO.ReadOnly = true;
            textDISPONIBLE.ReadOnly = true;
            textSALDO_LOCAL.ReadOnly = true;
            textSALDO_DOLAR.ReadOnly = true;
            textSALDO_CREDITO.ReadOnly = true;

            textCLIENTE.ReadOnly = true;
            textNOMBRE.ReadOnly = true;
            textMULTIMONEDA.ReadOnly = true;
            textMONEDA.ReadOnly = true;
            textCONDICION_PAGO.ReadOnly = true;
            textNIVEL_PRECIO.ReadOnly = true;
            textMONEDA_NIVEL.ReadOnly = true;
            textACTIVO.ReadOnly = true;
            textCATEGORIA_CLIENTE.ReadOnly = true;
            textMOROSO.ReadOnly = true;
            textU_ACTIVIDAD.ReadOnly = true;
            textU_SUBACTIVIDAD.ReadOnly = true;
            textU_CATEGORIACREDITO.ReadOnly = true;
            txtMAXIMO.ReadOnly = true;
            textEXCEDER_LIMITE.ReadOnly = true;
            textDISPONIBLE.ReadOnly = true;
            textSALDO_LOCAL.ReadOnly = true;
            textSALDO_DOLAR.ReadOnly = true;
            textSALDO_CREDITO.ReadOnly = true;
            textZONA.ReadOnly = true;
            textRUTA.ReadOnly = true;
            textVENDEDOR.ReadOnly = true;
            textCOBRADOR.ReadOnly = true;
            textCOBRO_JUDICIAL.ReadOnly = true;
            textDIRECCION.ReadOnly = true;
            textZONA_NOMBRE.ReadOnly = true;
            textRUTA_DESC.ReadOnly = true;
            textVENDEDOR_NOMBRE.ReadOnly = true;
            textCOBRADOR_NOMBRE.ReadOnly = true;
            textCOND_PAGO.ReadOnly = true;

            textANALISTA.ReadOnly = true;
            textANALISTA_NOMBRE.ReadOnly = true;
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                _aux_cliente = "";
                _aux_clinete_nombre = "";

                if (ComercialBL.ExisteClienteBL(txtCliente.Text, Global.vUserBaseDatos) == true)
                {
                    CargaDatosCliente(txtCliente.Text);
                    //_aux_cliente = "";
                    txtClienteNombre.Text = _aux_clinete_nombre ;
                }
                else
                {
                    txtCliente.Text = "";
                    txtClienteNombre.Text = "";
                    txtCliente.Focus();
                    MessageBox.Show("El Cliente No Existe....  Ingrese un Cliente correcto !!! ");
                    return;
                }
            }


        }


        public void CargaDatosCliente(string clienteOK)
        {
            DataTable dtCli= new DataTable();
            dtCli = ComercialBL.CargaDatosClienteBL(clienteOK, Global.vUserBaseDatos);      // CLIENTE, NOMBRE
            _aux_cliente = dtCli.Rows[0]["CLIENTE"].ToString();
            _aux_clinete_nombre = dtCli.Rows[0]["NOMBRE"].ToString();
        }

        private void txtClienteNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    MuestraFormBuscaCliente();
                    break;
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    MuestraFormBuscaCliente();
                    break;
            }
        }


        private void txtClienteNombre_DoubleClick(object sender, EventArgs e)
        {
            MuestraFormBuscaCliente();
        }

        private void txtCliente_DoubleClick(object sender, EventArgs e)
        {
            MuestraFormBuscaCliente();
        }

        //---------------------------------------------------------------------------------------------

        private void btnXlsEstadoCuenta_Click_1(object sender, EventArgs e)
        {
            //gcEstadoCuenta.ShowPrintPreview();
            if (gvEstadoCuenta.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Estado de Cuenta Clientes.");
                return;
            }
            else
            {
                gcEstadoCuenta.ShowPrintPreview();
            }
        }

        private void btnXlsLetrasEstado_Click_1(object sender, EventArgs e)
        {
            //gcLetras.ShowPrintPreview();
            if (gvLetras.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Estado Cuenta - Letras");
                return;
            }
            else
            {
                gcLetras.ShowPrintPreview();
            }
        }

        private void btnImprimeEstadoCuenta_Click_1(object sender, EventArgs e)
        {
            //frmEstadoCuentaClienteRPT frmEC = new frmEstadoCuentaClienteRPT();
            frmEstadoCuentaClienteRPTv2 frmEC = new frmEstadoCuentaClienteRPTv2();
            frmEC._dFechaIni = dFechaIni;
            frmEC._dFechaFin = dFechaFin;
            frmEC._cliente = cliente;
            frmEC._contribuyente = contribuyente;
            frmEC._mensaje = vmensaje;
            frmEC.ShowDialog();
        }

        private void btnImprimeLetrasEstado_Click_1(object sender, EventArgs e)
        {
            //frmLetrasporCobrarClienteRPT frmLetra = new frmLetrasporCobrarClienteRPT();
            frmLetrasporCobrarClienteRPTv2 frmLetra = new frmLetrasporCobrarClienteRPTv2();
            frmLetra._dFechaIni = dFechaIni;
            frmLetra._dFechaFin = dFechaFin;
            frmLetra._cliente = cliente;
            frmLetra._contribuyente = contribuyente;
            frmLetra._mensaje = vmensaje;
            frmLetra.ShowDialog();
        }

        //---------------------------------------------------------------------------------------------


        private void gvLetras_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            _cliente = gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "CLIENTE").ToString();
            _tipo = gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "TIPO").ToString();
            _documento = gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "DOCUMENTO").ToString();
            _monto = Convert.ToDecimal(gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "MONTO"));
            _moneda = gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "MONEDA").ToString();
            _referencia = gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "DOC_REFERENCIA").ToString();
            _fecha_emision = Convert.ToDateTime(gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "FECHA"));
            //_fecha_vcmto = Convert.ToDateTime(gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "VCMTO"));
            _fecha_vcmto = (DBNull.Value.Equals(gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "VCMTO"))) ? DateTime.Now : Convert.ToDateTime(gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "VCMTO").ToString());
            _estado = gvLetras.GetRowCellValue(gvLetras.FocusedRowHandle, "ESTADO").ToString();

        }

        private void gvEstadoCuenta_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _cliente = gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "CLIENTE_REPORTE").ToString();
            _tipo = gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "TIPO").ToString();
            _documento = gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "DOCUMENTO").ToString();
            _monto = Convert.ToDecimal(gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "MONTO"));
            _moneda = gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "MONEDA").ToString();
            _referencia = gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "DOC_REFERENCIA").ToString();
            _fecha_emision = Convert.ToDateTime(gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "FECHADOC"));
            //_fecha_vcmto = Convert.ToDateTime(gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "FECHA_VENCE"));
            _fecha_vcmto = (DBNull.Value.Equals(gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "FECHA_VENCE"))) ? DateTime.Now : Convert.ToDateTime(gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "FECHA_VENCE").ToString());
            _estado = gvEstadoCuenta.GetRowCellValue(gvEstadoCuenta.FocusedRowHandle, "ESTADO").ToString();
        }

        private void btnImprimirLetra_Click(object sender, EventArgs e)
        {
            switch (radioGroupFormatoLetra.SelectedIndex)
            {
                case 0:
                    _formato_letra = "RDLC";
                    break;
                case 1:
                    _formato_letra = "CRYSTAL";
                    break;
                default:
                    MessageBox.Show("Debe seleccionar un formato de impresión", "Estado de cuenta de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            //MessageBox.Show("Formato de Impresion de LETRA: " + _formato_letra, "Letras Formato Impresion");

            if (_estado.ToUpper() != "EMITIDA")
            {
                MessageBox.Show("El estado de la Letra debe ser EMITIDA", "Impresion de Letra de Clientes");
                return;
            }
            else
            {
                //frmEstadoCuentaClienteLETRAv2 frmImpLetra = new frmEstadoCuentaClienteLETRAv2();
                //frmEstadoCuentaClienteLETRA_CRv2 frmImpLetra = new frmEstadoCuentaClienteLETRA_CRv2();
                //frmEstadoCuentaClienteLETRA_CRv3 frmImpLetra = new frmEstadoCuentaClienteLETRA_CRv3();
                //frmEstadoCuentaClienteLETRA1aval frmImpLetra = new frmEstadoCuentaClienteLETRA1aval();

                if (_formato_letra == "RDLC")
                {
                    frmEstadoCuentaClienteLETRAv2 frmImpLetra = new frmEstadoCuentaClienteLETRAv2();
                    frmImpLetra._ClienteLetra = _cliente;
                    frmImpLetra._TipoDocumento = _tipo;
                    frmImpLetra._NroDocumento = _documento;
                    frmImpLetra._MontoLetra = _monto;
                    frmImpLetra._MonedaLetra = _moneda;
                    frmImpLetra._Referencia = _referencia;
                    frmImpLetra._FechaEmision = _fecha_emision;
                    frmImpLetra._FechaVcmto = _fecha_vcmto;
                    frmImpLetra.ShowDialog();
                }


                if (_formato_letra == "CRYSTAL")
                {
                    frmEstadoCuentaClienteLETRA_CRv3 frmImpLetraCR = new frmEstadoCuentaClienteLETRA_CRv3();
                    frmImpLetraCR._ClienteLetra = _cliente;
                    frmImpLetraCR._TipoDocumento = _tipo;
                    frmImpLetraCR._NroDocumento = _documento;
                    frmImpLetraCR._MontoLetra = _monto;
                    frmImpLetraCR._MonedaLetra = _moneda;
                    frmImpLetraCR._Referencia = _referencia;
                    frmImpLetraCR._FechaEmision = _fecha_emision;
                    frmImpLetraCR._FechaVcmto = _fecha_vcmto;
                    frmImpLetraCR.ShowDialog();
                }

            }
            //}
        }

        private void btnImprimirLetra2_Click(object sender, EventArgs e)
        {
            switch (radioGroupFormatoLetra.SelectedIndex)
            {
                case 0:
                    _formato_letra = "RDLC";
                    break;
                case 1:
                    _formato_letra = "CRYSTAL";
                    break;
                default:
                    MessageBox.Show("Debe seleccionar un formato de impresión", "Estado de cuenta de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            //MessageBox.Show("Formato de Impresion de LETRA: " + _formato_letra, "Letras Formato Impresion");

            if (_tipo.ToUpper() != "L/C")
            {
                MessageBox.Show("El Documento debe ser LETRA.", "Impresion de Letra de Clientes");
                return;
            }
            else
            {
                    if (_estado.ToUpper() != "EMITIDA")
                    {
                        MessageBox.Show("El estado de la Letra debe ser EMITIDA", "Impresion de Letra de Clientes");
                        return;

                    }
                    else
                    {
                        //frmEstadoCuentaClienteLETRAv2 frmImpLetra = new frmEstadoCuentaClienteLETRAv2();
                        //frmEstadoCuentaClienteLETRA_CRv2 frmImpLetra = new frmEstadoCuentaClienteLETRA_CRv2();
                        //frmEstadoCuentaClienteLETRA_CRv3 frmImpLetra = new frmEstadoCuentaClienteLETRA_CRv3();
                        //frmEstadoCuentaClienteLETRA1aval frmImpLetra = new frmEstadoCuentaClienteLETRA1aval();
                        //frmImpLetra._ClienteLetra = _cliente;
                        //frmImpLetra._TipoDocumento = _tipo;
                        //frmImpLetra._NroDocumento = _documento;
                        //frmImpLetra._MontoLetra = _monto;
                        //frmImpLetra._MonedaLetra = _moneda;
                        //frmImpLetra._Referencia = _referencia;
                        //frmImpLetra._FechaEmision = _fecha_emision;
                        //frmImpLetra._FechaVcmto = _fecha_vcmto;
                        //frmImpLetra.ShowDialog();


                        if (_formato_letra == "RDLC")
                        {
                            frmEstadoCuentaClienteLETRAv2 frmImpLetra = new frmEstadoCuentaClienteLETRAv2();
                            frmImpLetra._ClienteLetra = _cliente;
                            frmImpLetra._TipoDocumento = _tipo;
                            frmImpLetra._NroDocumento = _documento;
                            frmImpLetra._MontoLetra = _monto;
                            frmImpLetra._MonedaLetra = _moneda;
                            frmImpLetra._Referencia = _referencia;
                            frmImpLetra._FechaEmision = _fecha_emision;
                            frmImpLetra._FechaVcmto = _fecha_vcmto;
                            frmImpLetra.ShowDialog();
                        }


                        if (_formato_letra == "CRYSTAL")
                        {
                            frmEstadoCuentaClienteLETRA_CRv3 frmImpLetraCR = new frmEstadoCuentaClienteLETRA_CRv3();
                            frmImpLetraCR._ClienteLetra = _cliente;
                            frmImpLetraCR._TipoDocumento = _tipo;
                            frmImpLetraCR._NroDocumento = _documento;
                            frmImpLetraCR._MontoLetra = _monto;
                            frmImpLetraCR._MonedaLetra = _moneda;
                            frmImpLetraCR._Referencia = _referencia;
                            frmImpLetraCR._FechaEmision = _fecha_emision;
                            frmImpLetraCR._FechaVcmto = _fecha_vcmto;
                            frmImpLetraCR.ShowDialog();
                        }

                }
                //}
            }


        }

        private void btnExportarHistorico_Click(object sender, EventArgs e)
        {
            if (gvHistorico.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Documentos Historicos.");
                return;
            }
            else
            {
                gcHistorico.ShowPrintPreview();
            }
        }


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

        #region AUDITORIA

        private void btnAuditoriaExportarExcel_Click(object sender, EventArgs e)
        {
            if (gvauditoria.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Documentos Auditoria.");
                return;
            }
            else
            {
                gcauditoria.ShowPrintPreview();
            }
        }

        private void btnAuditoriaImprimir_Click(object sender, EventArgs e)
        {
            //string valor;
            int[] seleccionados;
            seleccionados = gvauditoria.GetSelectedRows();
            if (seleccionados.GetLength(0) > 0)
            {
                DataTable dtdoc_auditoria = new DataTable();
                dtdoc_auditoria.Columns.Add("documento");
                dtdoc_auditoria.Columns.Add("fecha_emi");
                dtdoc_auditoria.Columns.Add("fecha_ven");
                dtdoc_auditoria.Columns.Add("dias_venc");
                dtdoc_auditoria.Columns.Add("Imp_usd");
                dtdoc_auditoria.Columns.Add("Imp_sol");
                dtdoc_auditoria.Columns.Add("Doc_ref");
                dtdoc_auditoria.Columns.Add("Estado");
                dtdoc_auditoria.Columns.Add("Moneda");
                dtdoc_auditoria.Columns.Add("Monto_USD");
                dtdoc_auditoria.Columns.Add("Monto_SOL");


                DataRow dr_dtdoc;// = dtdoc_auditoria.NewRow();
                DataRow fila_gvaudi;


                foreach (int row in seleccionados)
                {
                    fila_gvaudi = gvauditoria.GetDataRow(row);
                    //valor = Convert.ToString(fila[0].ToString());

                    //Renglon = miDataTable.NewRow()
                    //Renglon("Nombre") = "Luis"
                    //Renglon("Sexo") = "Masculino"
                    //miDataTable.Rows.Add(Renglon)
                    dr_dtdoc = dtdoc_auditoria.NewRow();
                    dr_dtdoc["documento"] = Convert.ToString(fila_gvaudi["TIPO"].ToString()) + "#" + Convert.ToString(fila_gvaudi["DOCUMENTO"].ToString());
                    dr_dtdoc["fecha_emi"] = Convert.ToString(fila_gvaudi["FECHADOC"].ToString());
                    dr_dtdoc["fecha_ven"] = Convert.ToString(fila_gvaudi["FECHA_VENCE"].ToString());
                    dr_dtdoc["dias_venc"] = Convert.ToString(fila_gvaudi["ATRASO_VCMTO"].ToString());
                    dr_dtdoc["Imp_usd"] = Convert.ToString(fila_gvaudi["SALDO_DOLAR"].ToString());
                    dr_dtdoc["Imp_sol"] = Convert.ToString(fila_gvaudi["SALDO_LOCAL"].ToString());
                    dr_dtdoc["Doc_ref"] = Convert.ToString(fila_gvaudi["DOC_REFERENCIA"].ToString());
                    dr_dtdoc["Estado"] = Convert.ToString(fila_gvaudi["ESTADO"].ToString());
                    dr_dtdoc["Moneda"] = Convert.ToString(fila_gvaudi["MONEDA"].ToString());
                    //dr_dtdoc["MontoUSD"]=
                    if (Convert.ToString(fila_gvaudi["MONEDA"].ToString()) == "USD")
                    {
                        dr_dtdoc["Monto_USD"] = Convert.ToString(fila_gvaudi["SALDO_DOLAR"].ToString());
                    }
                    else
                    {
                        dr_dtdoc["Monto_USD"] = "0.00";
                    }


                    if (Convert.ToString(fila_gvaudi["MONEDA"].ToString()) == "SOL")
                    {
                        dr_dtdoc["Monto_SOL"] = Convert.ToString(fila_gvaudi["SALDO_LOCAL"].ToString());
                    }
                    else
                    {
                        dr_dtdoc["Monto_SOL"] = "0.00";
                    }

                    dtdoc_auditoria.Rows.Add(dr_dtdoc);
                }
                frm_Resumen_Impresion_Auditoria frmaudi = new frm_Resumen_Impresion_Auditoria();

                frmaudi.pCliente = this.textNOMBRE.Text;
                frmaudi.pDireccion = this.textDIRECCION.Text;
                frmaudi.dt_reporte = dtdoc_auditoria;
                switch (grp_TipoImpresion.SelectedIndex)
                {
                    case 0:
                        frmaudi.TIPO_REPORTE = 0;
                        frmaudi.Text = "Carta de Cobranza Auditoria - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 1:
                        frmaudi.TIPO_REPORTE = 1;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 1 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 2:
                        frmaudi.TIPO_REPORTE = 2;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 2 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 3:
                        frmaudi.TIPO_REPORTE = 3;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 3 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 4:
                        frmaudi.TIPO_REPORTE = 4;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 4 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    default:
                        MessageBox.Show("Debe seleccionar un formato de impresión", "Estado de cuenta de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }
                frmaudi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Estado de Cuenta de Clientes");
            }
        }




        private void btn_auditoria_imprimir_Click(object sender, EventArgs e)
        {
            //string valor;
            int[] seleccionados;
            seleccionados = gvauditoria.GetSelectedRows();
            if (seleccionados.GetLength(0) > 0)
            {
                DataTable dtdoc_auditoria = new DataTable();
                dtdoc_auditoria.Columns.Add("documento");
                dtdoc_auditoria.Columns.Add("fecha_emi");
                dtdoc_auditoria.Columns.Add("fecha_ven");
                dtdoc_auditoria.Columns.Add("dias_venc");
                dtdoc_auditoria.Columns.Add("Imp_usd");
                dtdoc_auditoria.Columns.Add("Imp_sol");
                dtdoc_auditoria.Columns.Add("Doc_ref");
                dtdoc_auditoria.Columns.Add("Estado");
                dtdoc_auditoria.Columns.Add("Moneda");
                dtdoc_auditoria.Columns.Add("Monto_USD");
                dtdoc_auditoria.Columns.Add("Monto_SOL");


                DataRow dr_dtdoc;// = dtdoc_auditoria.NewRow();
                DataRow fila_gvaudi;


                foreach (int row in seleccionados)
                {
                    fila_gvaudi = gvauditoria.GetDataRow(row);
                    //valor = Convert.ToString(fila[0].ToString());

                    //Renglon = miDataTable.NewRow()
                    //Renglon("Nombre") = "Luis"
                    //Renglon("Sexo") = "Masculino"
                    //miDataTable.Rows.Add(Renglon)
                    dr_dtdoc = dtdoc_auditoria.NewRow();
                    dr_dtdoc["documento"] = Convert.ToString(fila_gvaudi["TIPO"].ToString()) + "#" + Convert.ToString(fila_gvaudi["DOCUMENTO"].ToString());
                    dr_dtdoc["fecha_emi"] = Convert.ToString(fila_gvaudi["FECHADOC"].ToString());
                    dr_dtdoc["fecha_ven"] = Convert.ToString(fila_gvaudi["FECHA_VENCE"].ToString());
                    dr_dtdoc["dias_venc"] = Convert.ToString(fila_gvaudi["ATRASO_VCMTO"].ToString());
                    dr_dtdoc["Imp_usd"] = Convert.ToString(fila_gvaudi["SALDO_DOLAR"].ToString());
                    dr_dtdoc["Imp_sol"] = Convert.ToString(fila_gvaudi["SALDO_LOCAL"].ToString());
                    dr_dtdoc["Doc_ref"] = Convert.ToString(fila_gvaudi["DOC_REFERENCIA"].ToString());
                    dr_dtdoc["Estado"] = Convert.ToString(fila_gvaudi["ESTADO"].ToString());
                    dr_dtdoc["Moneda"] = Convert.ToString(fila_gvaudi["MONEDA"].ToString());
                    //dr_dtdoc["MontoUSD"]=
                    if (Convert.ToString(fila_gvaudi["MONEDA"].ToString()) == "USD")
                    {
                        dr_dtdoc["Monto_USD"] = Convert.ToString(fila_gvaudi["SALDO_DOLAR"].ToString());
                    }
                    else
                    {
                        dr_dtdoc["Monto_USD"] = "0.00";
                    }


                    if (Convert.ToString(fila_gvaudi["MONEDA"].ToString()) == "SOL")
                    {
                        dr_dtdoc["Monto_SOL"] = Convert.ToString(fila_gvaudi["SALDO_LOCAL"].ToString());
                    }
                    else
                    {
                        dr_dtdoc["Monto_SOL"] = "0.00";
                    }

                    dtdoc_auditoria.Rows.Add(dr_dtdoc);
                }
                frm_Resumen_Impresion_Auditoria frmaudi = new frm_Resumen_Impresion_Auditoria();

                frmaudi.pCliente = this.textNOMBRE.Text;
                frmaudi.pDireccion = this.textDIRECCION.Text;
                frmaudi.dt_reporte = dtdoc_auditoria;
                switch (grp_TipoImpresion.SelectedIndex)
                {
                    case 0:
                        frmaudi.TIPO_REPORTE = 0;
                        frmaudi.Text = "Carta de Cobranza Auditoria - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 1:
                        frmaudi.TIPO_REPORTE = 1;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 1 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 2:
                        frmaudi.TIPO_REPORTE = 2;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 2 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 3:
                        frmaudi.TIPO_REPORTE = 3;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 3 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    case 4:
                        frmaudi.TIPO_REPORTE = 4;
                        frmaudi.Text = "Carta de Cobranza Creditos Formato 4 - Alfredo Pimentel Sevilla S.A.";
                        break;
                    default:
                        MessageBox.Show("Debe seleccionar un formato de impresión", "Estado de cuenta de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }
                frmaudi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Estado de Cuenta de Clientes");
            }

        }



        #endregion

        private void lookUpAnalista_EditValueChanged(object sender, EventArgs e)
        {
            if (_primera_vez == false)
            {
                _analista_nombre = lookUpAnalista.EditValue.ToString();

                if ((lookUpAnalista.Text != null) && (lookUpAnalista.Text != string.Empty))
                {
                    _analista_code = lookUpAnalista.Text; 
                    textANALISTA.Text = lookUpAnalista.Text;
                    textANALISTA_NOMBRE.Text = lookUpAnalista.EditValue.ToString(); 
                }
            }
        }

        public void Carga_lookUp_Analista()
        {
            DataTable dtAnal = new DataTable();
            //CreditosDL.dtObtenerAnalistasCC_DL(_anal, _documento, _combo, _tipo,  db);
            //EXEC PIMENTEL.SP_APSSA_GET_ANALISTA_CC NULL,'SI','SI',NULL;
            dtAnal = CreditosBL.dtObtenerAnalistasCC_BL(null, "SI", "SI",null, Global.vUserBaseDatos);
            lookUpAnalista.Properties.DataSource = dtAnal;
            //lookUpAnalista.Properties.DisplayMember = "NOMBRE";
            //lookUpAnalista.Properties.ValueMember = "ANALISTA";
            lookUpAnalista.Properties.DisplayMember = "ANALISTA";
            lookUpAnalista.Properties.ValueMember = "NOMBRE";
            lookUpAnalista.EditValue = null;
            //lookUpAnalista.BestFitColumns();
        }

        private void btnGrabarInfCliente_Click(object sender, EventArgs e)
        {

        }

        private void gvIndicador_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtCuentaContable.Text = gvConcepto.GetRowCellValue(gvConcepto.FocusedRowHandle, "CUENTA_CONTABLE").ToString();
            //txtDescripcion.Text = gvConcepto.GetRowCellValue(gvConcepto.FocusedRowHandle, "DESCRIPCION").ToString();
            //txtTipoGasto.Text = gvConcepto.GetRowCellValue(gvConcepto.FocusedRowHandle, "TIPO_GASTO").ToString();
            //txtRubro.Text = gvConcepto.GetRowCellValue(gvConcepto.FocusedRowHandle, "RUBRO").ToString();
            //txtRubroEri.Text = gvConcepto.GetRowCellValue(gvConcepto.FocusedRowHandle, "RUBROS_ERI").ToString();

            txtEjercicio.Text = gvIndicador.GetRowCellValue(gvIndicador.FocusedRowHandle, "EJERCICIO").ToString();
            

        }

        public void CargaCboMes()
        {
            DataTable dtMes = new DataTable();
            dtMes = ContabilidadBL.dtObtenerMesesBL(Global.vUserBaseDatos);
            foreach (DataRow Row in dtMes.Rows)
            {
                this.cboMes.Properties.Items.Add(Row["MES"]);
            }
        }

        private void btnIndicadorVerDetalle_Click(object sender, EventArgs e)
        {
            if (gvIndicador.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a mostrar.", "Indicadores Cliente.");
                return;
            }
            else
            {
                frmClienteIndicadorDetalle frmIndDet = new frmClienteIndicadorDetalle();
                frmIndDet.ejercicio = Convert.ToInt32(txtEjercicio.Text);
                frmIndDet.mes = Convert.ToInt32(txtMes.Text);
                frmIndDet.cliente = txtCliente.Text;
                frmIndDet.razon_social = txtClienteNombre.Text;
                frmIndDet.mes_descripcion = cboMes.Text;
                frmIndDet.ShowDialog();
            }

        }

        private void cboMes_SelectedValueChanged(object sender, EventArgs e)
        {
            //txtMes.Text = cboMes.Text.Substring(0, 3);
            txtMes.Text = (cboMes.SelectedIndex + 1).ToString();
        }

        private void btnExportarIndicador_Click(object sender, EventArgs e)
        {
            if (gvIndicador.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Indicadores Cliente.");
                return;
            }
            else
            {
                gcIndicador.ShowPrintPreview();
            }
        }




    }
}

