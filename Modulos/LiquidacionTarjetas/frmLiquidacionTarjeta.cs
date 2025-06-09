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
//using Exactus.BL;
//using Exactus.BE;
//using Exactus.LIBCS;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ApssaExactus
{
    public partial class frmLiquidacionTarjeta : DevExpress.XtraEditors.XtraForm
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



        //
        public Boolean PrimeraVez = true;
        public string varAplicacionDescripcion = "Liquidacion Tarjetas";
        public ParametrosLiquidacion param_liq = null;
        public string cTabXls = null;
        CargaLookUpBL objCargaLookUpBL = new CargaLookUpBL();

        public DateTime dFechaAl { get; set; }
        public DateTime dFechaDeposito { get; set; }
        public string _sucursal_selec = "";     // "CHICLAYO"
        public string _caja_selec = "";         // "0010"
        public string _tarjeta_selec = "";      // "VISANET" 
        public string _moneda_selec = "";       // "L". "D"
        public Decimal _tipo_cambio_selec = 0;  // 3.6910
        public Decimal _numero_opeeracion_selec = 0;  
        public string _liquidado = "";
        public string _ctabco_select = "";
        public string _moneda_ctabco_select = "";
        public bool varExiste = false;


        public Decimal acum_abono = 0;
        public Decimal acum_comision = 0;
        public Decimal acum_neto = 0;


        public string par_operacion = null;
        public string par_tipo_asiento = null;
        public string par_paquete = null;
        public string par_cuenta_banco = null;
        public string par_tipo = null;
        public string par_subtipo = null;

        public string _lin_procesar = null;
        public string _lin_fecha = null;
        public string _lin_nombre = null;
        public string _lin_moneda = null;
        public string _lin_monto_local = null;
        public string _lin_monto_dolar = null;
        public string _lin_tipo_cambio = null;
        public string _lin_monto_liquidar = null;
        public static int contador = 0;
        public string _fecha_deposito_select = null;

        public string varUSUARIO;
        public DateTime varFECHA_PROCESO;
        public DateTime varFECHA_HORA;
        public string varNUM_DOCUMENTO;
        public string varNOMBRE;
        public string varMONEDA;
        public Decimal varMONTO_LOCAL;
        public Decimal varMONTO_DOLAR;
        public Decimal varTIPO_CAMBIO;
        public Decimal varMONTO_LIQUIDAR;
        public string varTIPO_DOCUMENTO;
        public string varFACTURA;
        public string varNUMERO_PAGO;
        public string varSELECC_LIQ;
        public string varCAJA;
        public string varCAJA_DESCRIPCION;
        public string varTIPO_TARJETA;
        public string varPROCESAR;


        public DateTime va_fecha_al;
        public Decimal var_num_operacion = 0;
        public string var_caja = "";
        public string var_tarjeta = "";
        public DateTime var_fecha_deposito;
        public Decimal var_tipo_cambio = 0;
        public string var_moneda = "";
        public string var_asiento_generado = "";
        public string var_resultado_liquidacion = "";

        public string var_ASIENTO_LIQUIDACION = "";

        public string AsientoSeleccionado = "";
        public string TabActivo = "";

        public Boolean GenerarOperacionAutomatico = false;
        public Decimal NumeroOperacionAutomatico = 0;
        

        public frmLiquidacionTarjeta(string _base, string _user)
        {
            InitializeComponent();
            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;
                                    //_password = _pass;      // txtPassword.Text;
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmLiquidacionTarjeta m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frmLiquidacionTarjeta DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmLiquidacionTarjeta(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmLiquidacionTarjeta_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // CARGA_ENTORNO_VARIABLES
            AccederEntornoReportesApssa(_base_datos, _usuario);
            //---------------------------------------------------------------              

            PrimeraVez = true;

            txtBD.Text = _base_datos;

            var fechaActual = DateTime.Today;
            this.deFechaAl.Text = fechaActual.ToString();
            this.deFechaDeposito.Text = fechaActual.ToString();

            this.deFechaLiqIni.Text = fechaActual.ToString();
            this.deFechaLiqFin.Text = fechaActual.ToString();

            //SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_FECHA("TCOM", '26/06/2018');  -- segun fecha del documento
            //SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_FECHA("TVTA", '26/06/2018');  -- segun fecha del documento
            /////DateTime dFechaIni = Convert.ToDateTime(deFechaDeposito.Text);
            Obtener_TipoCambio("TVTA", Convert.ToDateTime(deFechaDeposito.Text));

            //CargaInicialParametros();

            Cargar_Sucursales();
            Cargar_Tarjetas();
            //Cargar_CuentaBancos();
            Cargar_cboCtaBancosLiq();

            //PARAMETROS
            Cargar_cboTipoAsiento();
            Cargar_cboPaquete();
            Cargar_cboCtaBancos();
            Cargar_cboTipo();
            Cargar_cboSubTipo("DEP");
           
            CargaInicialParametros();

            CargarNumeroOperacion();

            ////////txtNroOperacion.ReadOnly = false;  // siempre
            txtCtaBancosLiq.ReadOnly = true;  // siempre

            cboMoneda.Text = "Soles";
            _moneda_selec = "L";
            lblTotalMoneda.Text = "Total S/.";

            txtTotalAbono.ReadOnly = true;

            txtTotalAbono.Text = "0.00";
            txtTotalComision.Text = "0.00";
            txtTotalNeto.Text = "0.00";

            HabilitaFiltros(true);


            /////Cargar_cboCtaBancosLiq();

            //TAB LIQUIDADOS
            xtraTabPageMovBancos.PageVisible = true;
            xtraTabPageFacturaCancela.PageVisible = false;
            cboOrigen.Text= "Liquidacion";    // "Liquidacion" , "Documentos"
            TabActivo = "Liquidacion";
            txtTabActivo.Text = "Liquidacion";
            txtAsientoTabLiquidacion.Visible = true;
            txtAsientoTabDocumento.Visible = false;
            Cargar_SucursalLiquidados();
            Carga_lookUp_Caja();
            //--------------------------------------------------------------------------------------------

            PrimeraVez = false;

            // seteo general
            //txtDocumentoCarga.Enabled = false;
            //txtDocumentoCarga2.Enabled = false;
            //txtCuentaBanco2.Enabled = false;
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


        #region FILTROS_LIQUIDACION

        public void Cargar_cboCtaBancosLiq()
        {
            DataTable dtBancosLiq = new DataTable();
            dtBancosLiq = ContabilidadBL.dtGestionaParametrosTarjetas_BL("CUENTA-BANCO", null, null, null, null, null, Global.vUserBaseDatos);
            this.cboCtaBancosLiq.DataSource = dtBancosLiq;
            this.cboCtaBancosLiq.DisplayMember = "NOMBRE";
            this.cboCtaBancosLiq.ValueMember = "CUENTA_BANCO";
        }


        private void cboCtaBancosLiq_SelectedValueChanged(object sender, EventArgs e)
        {
            if (PrimeraVez == false)
            {
                txtCtaBancosLiq.Text = cboCtaBancosLiq.SelectedValue.ToString();
                _ctabco_select = cboCtaBancosLiq.SelectedValue.ToString();

                if ((_ctabco_select != "") && (_ctabco_select != null))
                {
                    _moneda_ctabco_select = ContabilidadBL.ObtenerMonedaCuentaBanco_BL(_ctabco_select, Global.vUserBaseDatos);
                    //ObtenerMonedaCuentaBanco_BL(string _cuenta_banco, string db)
                    lblmoneda_ctabco_select.Text = _moneda_ctabco_select;

                    CargarNumeroOperacion();  // el numero de Operacion depende de la cuenta   //MAXMAX 

                }

            }

        }


        private void cboMoneda_SelectedValueChanged(object sender, EventArgs e)
        {
            string _mone = cboMoneda.Text;

            if (_mone == "Soles")
            {
                lblTotalMoneda.Text = "Total S/.";
                _moneda_selec = "L";
            }
            else
            {
                lblTotalMoneda.Text = "Total US$";
                _moneda_selec = "D";
            }

        }

        private void cboCaja_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void deFechaDeposito_EditValueChanged(object sender, EventArgs e)
        {
            _fecha_deposito_select = deFechaDeposito.Text;
            Obtener_TipoCambio("TVTA", Convert.ToDateTime(deFechaDeposito.Text));
            txtTipoCambio.Text = _tipo_cambio_selec.ToString();    // _fecha_deposito_select;
        }

        private void HabilitaFiltros(Boolean condicion)
        {
            deFechaAl.Enabled = condicion;
            //////txtNroOperacion.Enabled = false;  // siempre
            cboCaja.Enabled = condicion;
            cboMoneda.Enabled = condicion;
            cboTarjetas.Enabled = condicion;
            deFechaDeposito.Enabled = condicion;
            txtTipoCambio.Enabled = condicion;

            cboCtaBancosLiq.Enabled = condicion;
            //////txtCtaBancosLiq.Enabled = false;  // siempre

        }

        private void Obtener_TipoCambio(string _tipo, DateTime _fecha_select)
        {
            Decimal _tipo_vta = 0;
            Decimal _tipo_compra = 0;
 
            Decimal tc_tes = 0;

            tc_tes = ContabilidadBL.ObtenerTipoCambioFechaBL(_tipo, _fecha_select, Global.vUserBaseDatos);

            _tipo_cambio_selec = tc_tes;

        }

        private void btnPendientesFiltros_Click(object sender, EventArgs e)
        {
            InicializarLiquidacion();
        }

        private void InicializarLiquidacion()
        {
            HabilitaFiltros(true);

            txtTotalAbono.Text = "0.00";
            txtTotalComision.Text = "0.00";
            txtTotalNeto.Text = "0.00";

            acum_abono = 0;
            acum_comision = 0;
            acum_neto = 0;

            //TODO
            LimpiarGridView();
        }

        private void LimpiarGridView()
        {
            // Asignar null al DataSource del GridControl para limpiarlo
            gcAbonos.DataSource = null;

            // Opcional: Refrescar el GridControl para asegurarte de que se actualice visualmente
            gcAbonos.Refresh();
        }



        //private void txtTotalNeto_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    // Permitir números, tecla de retroceso (Backspace) y punto decimal (para decimales)
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //    {
        //        e.Handled = true; // Bloquear el carácter
        //    }

        //    //// Validar que solo haya un punto decimal
        //    //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
        //    //{
        //    //    e.Handled = true;
        //    //}

        //    /*
        //    //////// Permitir solo números, el carácter de punto decimal y la tecla de retroceso
        //    //////if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //    //////{
        //    //////    e.Handled = true; // Cancelar la entrada de teclas no válidas
        //    //////}
        //    //////// Permitir solo un punto decimal
        //    //////TextBox textBox = sender as TextBox;
        //    //////if (e.KeyChar == '.' && textBox.Text.Contains("."))
        //    //////{
        //    //////    e.Handled = true; // Cancelar si ya hay un punto decimal
        //    //////}
        //    //////// Validar que no haya más de dos dígitos después del punto decimal
        //    //////if (!e.Handled && textBox.Text.Contains("."))
        //    //////{
        //    //////    int indexOfDecimal = textBox.Text.IndexOf(".");
        //    //////    string decimals = textBox.Text.Substring(indexOfDecimal + 1);
        //    //////    if (decimals.Length >= 2 && textBox.SelectionStart > indexOfDecimal)
        //    //////    {
        //    //////        e.Handled = true; // Cancelar si ya hay dos dígitos decimales
        //    //////    }
        //    //////}
        //    */
        //}



        //private void txtTotalComision_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Permitir números, tecla de retroceso (Backspace) y punto decimal (para decimales)
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //    {
        //        e.Handled = true; // Bloquear el carácter
        //    }
        //    //// Validar que solo haya un punto decimal
        //    //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
        //    //{
        //    //    e.Handled = true;
        //    //}


        //    /*
        //    //////// Permitir solo números, el carácter de punto decimal y la tecla de retroceso
        //    //////if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //    //////{
        //    //////    e.Handled = true; // Cancelar la entrada de teclas no válidas
        //    //////}
        //    //////// Permitir solo un punto decimal
        //    //////TextBox textBox = sender as TextBox;
        //    //////if (e.KeyChar == '.' && textBox.Text.Contains("."))
        //    //////{
        //    //////    e.Handled = true; // Cancelar si ya hay un punto decimal
        //    //////}
        //    //////// Validar que no haya más de dos dígitos después del punto decimal
        //    //////if (!e.Handled && textBox.Text.Contains("."))
        //    //////{
        //    //////    int indexOfDecimal = textBox.Text.IndexOf(".");
        //    //////    string decimals = textBox.Text.Substring(indexOfDecimal + 1);
        //    //////    if (decimals.Length >= 2 && textBox.SelectionStart > indexOfDecimal)
        //    //////    {
        //    //////        e.Handled = true; // Cancelar si ya hay dos dígitos decimales
        //    //////    }
        //    //////}
        //    */
        //}

        private bool EsDecimalValido(string texto)
        {
            // Patrón para números decimales positivos (permite 123, 123.45, .5, 0.5)
            string patron = @"^\d*\.?\d+$";
            return Regex.IsMatch(texto, patron);
        }

        private bool EsDecimalOK(string expresion)
        {
            decimal resultado;
            return decimal.TryParse(expresion, out resultado);
        }
        private void txtTotalNeto_Leave(object sender, EventArgs e)
        {
            //if (!EsDecimalValido(txtTotalNeto.Text))
            if (!EsDecimalOK(txtTotalNeto.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico positivo válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalNeto.Focus(); // Regresa el foco al campo
                return;
            }

            if (Convert.ToDecimal(txtTotalNeto.Text) < 0 )
            {
                MessageBox.Show("El valor Neto no puede ser negativo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalNeto.Focus(); // Regresa el foco al campo
                return;
            }

            if ( Convert.ToDecimal(txtTotalNeto.Text) > Convert.ToDecimal(txtTotalAbono.Text))
            {
                MessageBox.Show("El valor Neto no puede ser mayor a el valor Total.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalNeto.Focus(); // Regresa el foco al campo
                return;
            }

        }

        private void txtTotalComision_Leave(object sender, EventArgs e)
        {
            //if (!EsDecimalValido(txtTotalComision.Text))
            if (!EsDecimalOK(txtTotalComision.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico positivo válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalComision.Focus(); // Regresa el foco al campo
                return;
            }

            if (Convert.ToDecimal(txtTotalComision.Text) < 0 )
            {
                MessageBox.Show("El valor Neto no puede ser negativo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalComision.Focus(); // Regresa el foco al campo
                return;
            }

            if (Convert.ToDecimal(txtTotalComision.Text) > Convert.ToDecimal(txtTotalAbono.Text))
            {
                MessageBox.Show("El valor Neto no puede ser mayor a el valor Total.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalComision.Focus(); // Regresa el foco al campo
                return;
            }

        }

        private void txtTotalComision_EditValueChanged(object sender, EventArgs e)
        {

            Decimal abon = Convert.ToDecimal(txtTotalAbono.Text);
            Decimal comi = Convert.ToDecimal(txtTotalComision.Text);
            Decimal neto = (abon - comi);   //Convert.ToDecimal(txtTotalNeto.Text);

            //txtTotalComision.Text = "";
            txtTotalNeto.Text = neto.ToString();
        }

        private void txtTotalNeto_EditValueChanged(object sender, EventArgs e)
        {
            Decimal abon = Convert.ToDecimal(txtTotalAbono.Text);
            Decimal neto = Convert.ToDecimal(txtTotalNeto.Text);
            Decimal comi = (abon - neto);      // Convert.ToDecimal(txtTotalComision.Text);

            txtTotalComision.Text = comi.ToString();
            //txtTotalNeto.Text = "";
        }


        #endregion

        #region PARAMETROS_LIQUIDACION

        private void btnParametrosGrabar_Click(object sender, EventArgs e)
        {

            //string _tipo_asiento_desc = cboTipoAsiento.Text;
            //string _tipo_asiento = txtTipoAsiento.Text;
            //string _paquete_desc = cboPaquete.Text;
            //string _paquete = txtPaquete.Text;
            //string _cta_bco_desc = cboCtaBancos.Text;
            //string _cta_bco = txtCtaBancos.Text;
            //string _tipo_desc = cboTipo.Text;
            //string _tipo = txtTipo.Text;
            //string _subtipo_desc = cboSubTipo.Text;
            //string _subtipo = txtSubTipo.Text;

            string save_operacion = "SAVE-PARAMETROS";
            string save_tipo_asiento = txtTipoAsiento.Text;
            string save_paquete = txtPaquete.Text;
            string save_cuenta_banco = txtCtaBancos.Text;
            string save_tipo = txtTipo.Text;
            string save_subtipo = txtSubTipo.Text;

            //BEGIN - TRY
            try
            {
                //PROCESO GRABA
                DialogResult dialogResult = MessageBox.Show("Liquidacion de Tarjetas "
                                                        + "\n"
                                                        + "\nEsta seguro de guardar la informacion?", "Liquidacion de Tarjetas", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
                    {

                        ContabilidadBL.dtGestionaParametrosTarjetas_BL(save_operacion, save_tipo_asiento, save_paquete, save_cuenta_banco, save_tipo, save_subtipo, Global.vUserBaseDatos);

                        CargaInicialParametros();

                    }

                    //
                    MessageBox.Show("Se guardo correctamente.", "Liquidacion de Tarjetas ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //END - TRY

        }

        private void btnParametrosCancelar_Click(object sender, EventArgs e)
        {
            CargaInicialParametros();
        }


        public void CargaInicialParametros()
        {
            CargaDatosParametros("GET-PARAMETROS");

            txtTipoAsiento.Text = param_liq.tipo_asiento;
            txtPaquete.Text = param_liq.paquete;
            txtCtaBancos.Text = param_liq.cuenta_banco;
            txtTipo.Text = param_liq.tipo;
            txtSubTipo.Text = param_liq.subtipo;

            Cargar_cboSubTipo(param_liq.tipo);

            cboTipoAsiento.Text = param_liq.tipo_asiento_desc;   // "Liquidación de Tarjetas de Crédito";
            cboPaquete.Text = param_liq.paquete_desc;            // "Control Bancario";
            cboCtaBancos.Text = param_liq.cuenta_banco_desc;     // "BCO CONTIN.CTA 011-0384-0100006803 HICLA";
            cboTipo.Text = param_liq.tipo_desc;                  //"Depósito";
            cboSubTipo.Text = param_liq.subtipo_desc;            //"Liquidación De Tarjeta De Crédito"; 

            //
            cboCtaBancosLiq.Text = param_liq.cuenta_banco_desc;     // "BCO CONTIN.CTA 011-0384-0100006803 HICLA";
            txtCtaBancosLiq.Text = param_liq.cuenta_banco;

            _ctabco_select = param_liq.cuenta_banco;
            _moneda_ctabco_select = ContabilidadBL.ObtenerMonedaCuentaBanco_BL(param_liq.cuenta_banco, Global.vUserBaseDatos);
            lblmoneda_ctabco_select.Text = _moneda_ctabco_select;

            //cboTipoAsiento.Text = "Liquidación de Tarjetas de Crédito";   // "LQ";             //    Liquidación de Tarjetas de Crédito    //param_liq.tipo_asiento;
            //cboPaquete.Text = "Control Bancario";       // "CB";                 //    Control Bancario      //param_liq.paquete;
            //cboCtaBancos.Text = "BCO CONTIN.CTA 011-0384-0100006803 HICLA";     // "384-0100006803";   //	BCO CONTIN.CTA 011-0384-0100006803 HICLA    //param_liq.cuenta_banco;
            //cboTipo.Text = "Depósito";      // "DEP";  //	Depósito    //param_liq.tipo;
            ////cboSubTipo.Text = "Liquidación De Tarjeta De Crédito";        //"52".ToString() ;   //Liquidación De Tarjeta De Crédito   //param_liq.subtipo;
            //Cargar_cboSubTipo("DEP");

        }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            //cboTipoAsiento.Text = "Liquidación de Tarjetas de Crédito";   // "LQ";             //    Liquidación de Tarjetas de Crédito    //param_liq.tipo_asiento;
            //cboPaquete.Text = "Control Bancario";       // "CB";                 //    Control Bancario      //param_liq.paquete;
            //cboCtaBancos.Text = "BCO CONTIN.CTA 011-0384-0100006803 HICLA";     // "384-0100006803";   //	BCO CONTIN.CTA 011-0384-0100006803 HICLA    //param_liq.cuenta_banco;
            //cboTipo.Text = "Depósito";      // "DEP";  //	Depósito    //param_liq.tipo;
            ////cboSubTipo.Text = "Liquidación De Tarjeta De Crédito";        //"52".ToString() ;   //Liquidación De Tarjeta De Crédito   //param_liq.subtipo;
            //cboSubTipo.SelectedValue = 52;

            CargarNumeroOperacion();

        }

        private void btnParametrosActualizar_Click(object sender, EventArgs e)
        {
            CargaDatosParametros("GET-PARAMETROS");

            //cboTipoAsiento.Text = param_liq.tipo_asiento;
            txtTipoAsiento.Text = param_liq.tipo_asiento;

            //cboPaquete.Text = param_liq.paquete;
            txtPaquete.Text = param_liq.paquete;

            //cboCtaBancos.Text = param_liq.cuenta_banco;
            txtCtaBancos.Text = param_liq.cuenta_banco;

            //cboTipo.Text = param_liq.tipo;
            txtTipo.Text = param_liq.tipo;

            //cboSubTipo.Text = param_liq.subtipo;
            txtSubTipo.Text = param_liq.subtipo;
        }

        public void CargaDatosParametros(string _operacion)
        {
            if (param_liq == null)
                param_liq = new ParametrosLiquidacion();

            //-- 'NUM-OPERACION', 'GET-PARAMETROS', 'SAVE-PARAMETROS', 'TIPO-ASIENTO' , 'PAQUETE','CUENTA-BANCO','TIPO','SUBTIPO'
            //ContabilidadDL.dtGestionaParametrosTarjetas_BL(_operacion, _tipo_asiento, _paquete, _cuenta_banco, _tipo, _subtipo, db);

            par_operacion = _operacion;
            par_tipo_asiento = null;
            par_paquete = null;
            par_cuenta_banco = null;
            par_tipo = null;
            par_subtipo = null;

            DataTable dtParam = new DataTable();
            dtParam = ContabilidadBL.dtGestionaParametrosTarjetas_BL(par_operacion, par_tipo_asiento, par_paquete, par_cuenta_banco, par_tipo, par_subtipo, Global.vUserBaseDatos);

            DataTableReader param = dtParam.CreateDataReader();

            while (param.Read())
            {
                param_liq.tipo_asiento = param[0].ToString();
                param_liq.paquete = param[1].ToString();
                param_liq.cuenta_banco = param[2].ToString();
                param_liq.tipo = param[3].ToString();
                param_liq.subtipo = param[4].ToString();

                param_liq.tipo_asiento_desc = param[5].ToString();
                param_liq.paquete_desc = param[6].ToString();
                param_liq.cuenta_banco_desc = param[7].ToString();
                param_liq.tipo_desc = param[8].ToString();
                param_liq.subtipo_desc = param[9].ToString();

            }

        }

        private void cboTipoAsiento_SelectedValueChanged(object sender, EventArgs e)
        {
            txtTipoAsiento.Text = cboTipoAsiento.SelectedValue.ToString();
        }

        private void cboPaquete_SelectedValueChanged(object sender, EventArgs e)
        {
            txtPaquete.Text = cboPaquete.SelectedValue.ToString();
        }

        private void cboCtaBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCtaBancos.Text = cboCtaBancos.SelectedValue.ToString();
        }

        private void cboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            txtTipo.Text = cboTipo.SelectedValue.ToString();
        }

        private void cboSubTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            txtSubTipo.Text = cboSubTipo.SelectedValue.ToString();
        }

        public void Cargar_cboTipoAsiento()
        {
            DataTable dtTipoAsiento = new DataTable();
            dtTipoAsiento = ContabilidadBL.dtGestionaParametrosTarjetas_BL("TIPO-ASIENTO", null, null, null, null, null, Global.vUserBaseDatos);
            this.cboTipoAsiento.DataSource = dtTipoAsiento;
            this.cboTipoAsiento.DisplayMember = "DESCRIPCION";
            this.cboTipoAsiento.ValueMember = "TIPO_ASIENTO";
        }

        public void Cargar_cboPaquete()
        {
            DataTable dtTipoAsiento = new DataTable();
            dtTipoAsiento = ContabilidadBL.dtGestionaParametrosTarjetas_BL("PAQUETE", null, null, null, null, null, Global.vUserBaseDatos);
            this.cboPaquete.DataSource = dtTipoAsiento;
            this.cboPaquete.DisplayMember = "DESCRIPCION";
            this.cboPaquete.ValueMember = "PAQUETE";
        }

        public void Cargar_cboCtaBancos()
        {
            DataTable dtTipoAsiento = new DataTable();
            dtTipoAsiento = ContabilidadBL.dtGestionaParametrosTarjetas_BL("CUENTA-BANCO", null, null, null, null, null, Global.vUserBaseDatos);
            this.cboCtaBancos.DataSource = dtTipoAsiento;
            this.cboCtaBancos.DisplayMember = "NOMBRE";
            this.cboCtaBancos.ValueMember = "CUENTA_BANCO";
        }



        public void Cargar_cboTipo()
        {
            DataTable dtTipoAsiento = new DataTable();
            dtTipoAsiento = ContabilidadBL.dtGestionaParametrosTarjetas_BL("TIPO", null, null, null, null, null, Global.vUserBaseDatos);
            this.cboTipo.DataSource = dtTipoAsiento;
            this.cboTipo.DisplayMember = "DESCRIPCION";
            this.cboTipo.ValueMember = "TIPO";
        }

        public void Cargar_cboSubTipo(string _tipo_selec)
        {
            DataTable dtTipoAsiento = new DataTable();
            dtTipoAsiento = ContabilidadBL.dtGestionaParametrosTarjetas_BL("SUBTIPO", null, null, null, _tipo_selec, null, Global.vUserBaseDatos);
            this.cboSubTipo.DataSource = dtTipoAsiento;
            this.cboSubTipo.DisplayMember = "DESCRIPCION";
            this.cboSubTipo.ValueMember = "SUBTIPO";
        }

        #endregion


        #region REPORTE_LIQUIDADOS

        private void cboOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            //"Liquidacion" , "Documentos"
            string _tab_rep = cboOrigen.Text;

            if (_tab_rep == "Liquidacion")
            {
                xtraTabPageMovBancos.PageVisible = true;
                xtraTabPageFacturaCancela.PageVisible = false;
                TabActivo = "Liquidacion";
                txtTabActivo.Text = "Liquidacion";
                txtAsientoTabLiquidacion.Visible = true;
                txtAsientoTabDocumento.Visible = false;
            }
            else
            {
                xtraTabPageMovBancos.PageVisible = false;
                xtraTabPageFacturaCancela.PageVisible = true;
                TabActivo = "Documentos";
                txtTabActivo.Text = "Documentos";
                txtAsientoTabLiquidacion.Visible = false;
                txtAsientoTabDocumento.Visible = true;
            }

        }

        public void Carga_lookUp_Caja()
        {
            DataTable dtCaja = new DataTable();
            dtCaja = objCargaLookUpBL.dtListarCajaBL(Global.vUserBaseDatos);    // objCargaLookUpBL.dtListarCuentaBancoBL(Global.vUserBaseDatos);
            lookUpCaja.Properties.DataSource = dtCaja;
            lookUpCaja.Properties.DisplayMember = "DESCRIPCION";
            lookUpCaja.Properties.ValueMember = "CAJA";
            lookUpCaja.EditValue = null;
        }

        private void btnActualizarLiquidados_Click(object sender, EventArgs e)
        {
            DateTime dFechaDesde = Convert.ToDateTime(deFechaLiqIni.Text);
            DateTime dFechaHasta = Convert.ToDateTime(deFechaLiqFin.Text);
            string _caja_liq_selec = cboCajaLiquidados.SelectedValue.ToString();   // "0010"
            string _origen = cboOrigen.Text;    // "Liquidacion" , "Documentos"

            string _cajas_lookUp = this.lookUpCaja.EditValue.ToString();    //"0002, 0003, 0004, 0005, 0006, 0007, 0008, 0009, 0010, 0011, 0012, 0014, 0015, 0016, 0017"

            //LimpiarGridViewLiquidados();

            ////ObtenerAbonosLiquidados(dFechaDesde, dFechaHasta, _caja_liq_selec, _origen);

            if (_origen == "Liquidacion")
            {
                ObtenerAbonosLiquidadosMovBancos(dFechaDesde, dFechaHasta, _cajas_lookUp, _origen);
            }
            else
            {
                ObtenerAbonosLiquidadosFacturaCancela(dFechaDesde, dFechaHasta, _cajas_lookUp, _origen);
            }

            //ReinciargvAbonos();

        }


        public void ObtenerAbonosLiquidadosFacturaCancela(DateTime fecha_desde, DateTime fecha_hasta, string sucursal, string origen)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de los abonos Liquidados ....", "Espere por favor.."))
            {
                DataTable dtFacturaCancela = new DataTable();
                //////dtAbonos = ContabilidadBL.dtObtieneTarjetasListado_BL("PENDIENTE", fecha_al, fecha_deposito, sucursal, tarjeta, moneda, tipo_cambio, fecha_al, fecha_al, Global.vUserBaseDatos);
                //dtLiquidados = ContabilidadBL.dtObtieneTarjetasListado_BL("LIQUIDADO", null, null, null, null, null, null, fecha_desde, fecha_hasta, Global.vUserBaseDatos);
                dtFacturaCancela = ContabilidadBL.dtObtieneTarjetasListado_BL("LIQUIDADO", fecha_desde, fecha_hasta, sucursal, "NULL", "X", 0, fecha_desde, fecha_hasta, origen, Global.vUserBaseDatos);
                
                gcFacturaCancela.DataSource = dtFacturaCancela;
            }

            ConfiguraGrillaLiquidadosFacturaCancela();
        }


        public void ConfiguraGrillaLiquidadosFacturaCancela()
        {
            gvFacturaCancela.OptionsView.ColumnAutoWidth = false;
            gvFacturaCancela.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gvFacturaCancela.Appearance.Row.Font.Name, 7);
            gvFacturaCancela.Appearance.HeaderPanel.Font = fnt;
            gvFacturaCancela.Appearance.Row.Font = fnt;
            gvFacturaCancela.Appearance.Row.Options.UseFont = true;
            gvFacturaCancela.OptionsView.ShowGroupPanel = false;
            gvFacturaCancela.OptionsView.ShowIndicator = false;
            gvFacturaCancela.OptionsBehavior.Editable = true;  //false;
            gvFacturaCancela.OptionsSelection.EnableAppearanceFocusedCell = false;

            //
            gvFacturaCancela.Columns["NOMBRE"].Width = 150;

            //FORMATO
            gvFacturaCancela.Columns["LIQUIDADO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFacturaCancela.Columns["LIQUIDADO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFacturaCancela.Columns["TC_LIQ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFacturaCancela.Columns["TC_LIQ"].DisplayFormat.FormatString = "##,###,###,##0.0000";
            gvFacturaCancela.Columns["LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFacturaCancela.Columns["LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvFacturaCancela.Columns["DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvFacturaCancela.Columns["DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvLiquidados.Columns["TC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvLiquidados.Columns["TC"].DisplayFormat.FormatString = "##,###,###,##0.0000";

        }
        //----------------------

        public void ObtenerAbonosLiquidadosMovBancos(DateTime fecha_desde, DateTime fecha_hasta, string sucursal, string origen)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de los abonos Liquidados ....", "Espere por favor.."))
            {
                DataTable dtMovBancos = new DataTable();
                //////dtAbonos = ContabilidadBL.dtObtieneTarjetasListado_BL("PENDIENTE", fecha_al, fecha_deposito, sucursal, tarjeta, moneda, tipo_cambio, fecha_al, fecha_al, Global.vUserBaseDatos);
                //dtLiquidados = ContabilidadBL.dtObtieneTarjetasListado_BL("LIQUIDADO", null, null, null, null, null, null, fecha_desde, fecha_hasta, Global.vUserBaseDatos);
                dtMovBancos = ContabilidadBL.dtObtieneTarjetasListado_BL("LIQUIDADO", fecha_desde, fecha_hasta, sucursal, "NULL", "X", 0, fecha_desde, fecha_hasta, origen, Global.vUserBaseDatos);
                gcMovBancos.DataSource = dtMovBancos;
            }

            ConfiguraGrillaLiquidadosMovBancos();
        }


        public void ConfiguraGrillaLiquidadosMovBancos()
        {
            gvMovBancos.OptionsView.ColumnAutoWidth = false;
            gvMovBancos.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gvMovBancos.Appearance.Row.Font.Name, 7);
            gvMovBancos.Appearance.HeaderPanel.Font = fnt;
            gvMovBancos.Appearance.Row.Font = fnt;
            gvMovBancos.Appearance.Row.Options.UseFont = true;
            gvMovBancos.OptionsView.ShowGroupPanel = false;
            gvMovBancos.OptionsView.ShowIndicator = false;
            gvMovBancos.OptionsBehavior.Editable = true;  //false;
            gvMovBancos.OptionsSelection.EnableAppearanceFocusedCell = false;

            //
            gvMovBancos.Columns["NOMBRE"].Width = 150;

            //FORMATO
            gvMovBancos.Columns["LIQUIDADO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMovBancos.Columns["LIQUIDADO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvMovBancos.Columns["TC_LIQ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMovBancos.Columns["TC_LIQ"].DisplayFormat.FormatString = "##,###,###,##0.0000";
            gvMovBancos.Columns["LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMovBancos.Columns["LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvMovBancos.Columns["DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMovBancos.Columns["DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvLiquidados.Columns["TC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvLiquidados.Columns["TC"].DisplayFormat.FormatString = "##,###,###,##0.0000";

        }



        public void Cargar_SucursalLiquidados()
        {
            DataTable dtCajaLiquidados = new DataTable();
            dtCajaLiquidados = objCargaLookUpBL.dtListarCajaBL(Global.vUserBaseDatos);
            this.cboCajaLiquidados.DataSource = dtCajaLiquidados;
            this.cboCajaLiquidados.DisplayMember = "DESCRIPCION";
            this.cboCajaLiquidados.ValueMember = "CAJA";
        }

        private void cboCajaLiquidados_SelectedValueChanged(object sender, EventArgs e)
        {

        }



        private void btnExportarLiquidado_Click(object sender, EventArgs e)
        {
            if (gvMovBancos.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Tarjetas de Credito - Liquidados");
                return;
            }
            else
            {
                gcMovBancos.ShowPrintPreview();
            }
        }

        private void btnImprimirLiquidado_Click(object sender, EventArgs e)
        {

        }




        #endregion


        #region FUNCIONES_VARIOS
        public void Cargar_Sucursales()
        {
            DataTable dtCaja = new DataTable();
            dtCaja = objCargaLookUpBL.dtListarCajaBL(Global.vUserBaseDatos);
            this.cboCaja.DataSource = dtCaja;
            this.cboCaja.DisplayMember = "DESCRIPCION";
            this.cboCaja.ValueMember = "CAJA";
        }

        public void Cargar_Tarjetas()
        {
            DataTable dtTarjetas = new DataTable();
            dtTarjetas = objCargaLookUpBL.dtListarTarjetasBL(Global.vUserBaseDatos);
            this.cboTarjetas.DataSource = dtTarjetas;
            this.cboTarjetas.DisplayMember = "DESCRIPCION";
            this.cboTarjetas.ValueMember = "TARJETA";
        }

        public void Cargar_CuentaBancos()
        {
            DataTable dt_cbhist = new DataTable();
            dt_cbhist = objCargaLookUpBL.dtListarCuentaBancoBL(Global.vUserBaseDatos);
            this.cboCtaBancos.DataSource = dt_cbhist;
            this.cboCtaBancos.DisplayMember = "NOMBRE";
            this.cboCtaBancos.ValueMember = "CUENTA_BANCO";
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
            if (xtraTabControl1.SelectedTabPage.Text == "Pendientes")
            {
                cTabXls = "Pendientes";
                //MessageBox.Show("Pendientes....");  
            }
            else if (xtraTabControl1.SelectedTabPage.Text == "Liquidados")
            {
                cTabXls = "Liquidados";
                //MessageBox.Show("Liquidados....");
            }
            else if (xtraTabControl1.SelectedTabPage.Text == "Parametros")
            {
                cTabXls = "Parametros";
                //MessageBox.Show("Parametros....");
            }

        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPage.Text)
            {
                case "Pendientes":
                    cTabXls = "Pendientes";
                    break;
                case "Liquidados":
                    cTabXls = "Liquidados";
                    break;
                case "Parametros":
                    cTabXls = "Parametros";
                    break;
                default:
                    cTabXls = "Pendientes";
                    break;
            }
        }





        #endregion



        private void gvMovBancos_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            AsientoSeleccionado = Convert.ToString(gvMovBancos.GetRowCellValue(gvMovBancos.FocusedRowHandle, "ASIENTO"));

            txtAsientoTabLiquidacion.Text = AsientoSeleccionado;
        }

        private void gvFacturaCancela_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            AsientoSeleccionado = Convert.ToString(gvFacturaCancela.GetRowCellValue(gvFacturaCancela.FocusedRowHandle, "ASIENTO"));

            txtAsientoTabDocumento.Text = AsientoSeleccionado;
        }

        private void btnAsiento_Click(object sender, EventArgs e)
        {
            AsientoSeleccionado = "";

            if (TabActivo == "Liquidacion")
            {
                if (gvMovBancos.RowCount <= 0)
                {
                    MessageBox.Show("No existe Informacion.", "Tarjetas de Credito - Liquidados");
                    return;
                }

                AsientoSeleccionado = txtAsientoTabLiquidacion.Text;
            }
            else
            {
                if (gvFacturaCancela.RowCount <= 0)
                {
                    MessageBox.Show("No existe Informacion.", "Tarjetas de Credito - Liquidados");
                    return;
                }

                AsientoSeleccionado = txtAsientoTabDocumento.Text;

            }


            if (AsientoSeleccionado == "")
            {
                MessageBox.Show("No existe Informacion.", "Tarjetas de Credito - Liquidados");
                return;
            }


            frmLiquidacionAsiento FormAsiento = new frmLiquidacionAsiento();

            FormAsiento._asiento = AsientoSeleccionado;
            //FormAsiento._descripcion_aplicacion = varAplicacionDescripcion;
            //FormAsiento._tipo = TipoOperacionCajaChica;

            FormAsiento.ShowDialog();
            if (FormAsiento.DialogResult == DialogResult.OK)
            {

            }
            else
            {

            }


        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmLiquidacionReporteFiltros FormRpt = new frmLiquidacionReporteFiltros();

            FormRpt.ShowDialog();
            if (FormRpt.DialogResult == DialogResult.OK)
            {

            }
            else
            {

            }

        }




        #region PROCESO_LIQUIDACION

        private void btnTest_Click(object sender, EventArgs e)
        {
            // Obtener los índices de las filas seleccionadas
            int[] selectedRows = gvAbonos.GetSelectedRows();

            // Verificar si hay filas seleccionadas
            if (selectedRows.Length == 0)
            {
                MessageBox.Show("No hay filas seleccionadas para procesar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            varNUM_DOCUMENTO = "";
            varNOMBRE = "";
            varMONEDA = "";
            varMONTO_LOCAL = 0;
            varMONTO_DOLAR = 0;
            varTIPO_CAMBIO = 0;
            varMONTO_LIQUIDAR = 0;
            varTIPO_DOCUMENTO = "";
            varFACTURA = "";
            varNUMERO_PAGO = "";
            varSELECC_LIQ = "";
            varCAJA = "";
            varCAJA_DESCRIPCION = "";
            varTIPO_TARJETA = "";

            acum_abono = 0;
            acum_comision = 0;
            acum_neto = 0;

            // Recorrer las filas seleccionadas y enviar los datos a la base de datos
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0) // Verificar que el índice sea válido
                {

                    varFECHA_HORA = Convert.ToDateTime(gvAbonos.GetRowCellValue(rowHandle, "FECHA_HORA").ToString());   //Convert.ToDateTime(row["FECHA_HORA"]);
                    varNUM_DOCUMENTO = gvAbonos.GetRowCellValue(rowHandle, "NUM_DOCUMENTO").ToString(); //row["NUM_DOCUMENTO"].ToString();
                    varNOMBRE = gvAbonos.GetRowCellValue(rowHandle, "NOMBRE").ToString();  //row["NOMBRE"].ToString();
                    varMONEDA = gvAbonos.GetRowCellValue(rowHandle, "MONEDA").ToString();  //row["MONEDA"].ToString();
                    varMONTO_LOCAL = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LOCAL"));  //Convert.ToDecimal(row["MONTO_LOCAL"]);
                    varMONTO_DOLAR = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_DOLAR"));  //Convert.ToDecimal(row["MONTO_DOLAR"]);
                    varTIPO_CAMBIO = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "TIPO_CAMBIO"));  //Convert.ToDecimal(row["TIPO_CAMBIO"]);
                    varMONTO_LIQUIDAR = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LIQUIDAR"));  //Convert.ToDecimal(row["MONTO_LIQUIDAR"]);
                    varTIPO_DOCUMENTO = gvAbonos.GetRowCellValue(rowHandle, "TIPO_DOCUMENTO").ToString();  //row["TIPO_DOCUMENTO"].ToString();
                    varFACTURA = gvAbonos.GetRowCellValue(rowHandle, "FACTURA").ToString();  //row["FACTURA"].ToString();
                    varNUMERO_PAGO = gvAbonos.GetRowCellValue(rowHandle, "NUMERO_PAGO").ToString();  //row["NUMERO_PAGO"].ToString();
                    //varSELECC_LIQ = row["SELECC_LIQ"].ToString();
                    varCAJA = gvAbonos.GetRowCellValue(rowHandle, "CAJA").ToString();  //row["CAJA"].ToString();
                    varCAJA_DESCRIPCION = gvAbonos.GetRowCellValue(rowHandle, "SUCURSAL").ToString();  //row["CAJA_DESCRIPCION"].ToString();
                    varTIPO_TARJETA = gvAbonos.GetRowCellValue(rowHandle, "TIPO_TARJETA").ToString();  //row["TIPO_TARJETA"].ToString();

                    acum_abono = acum_abono + varMONTO_LIQUIDAR;    ///// varMONTO_LOCAL;


                    if (varMONEDA == "L")
                    {
                        MessageBox.Show("Procesando Soles: " + varTIPO_DOCUMENTO + "/" + varFACTURA + "Monto S/. " + varMONTO_LOCAL.ToString(), "Liquidacion de Tarjetas " + "  ");
                    }
                    else
                    {
                        MessageBox.Show("Procesando Dolares: " + varTIPO_DOCUMENTO + "/" + varFACTURA + "Monto US$ " + varMONTO_DOLAR.ToString(), "Liquidacion de Tarjetas " + "  ");
                    }

    
                }
            }

            MessageBox.Show("Las filas seleccionadas han sido procesadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("MONTO TOTAL SELECCIONADO : "  + acum_abono.ToString(), "Liquidacion de Tarjetas " + "  ");
        }

        private void CargarNumeroOperacion()
        {

            //string _var_cta_bco = txtCtaBancos.Text;      // de parametros
            string _var_cta_bco = txtCtaBancosLiq.Text;     // de lo que el usuario elija al liquidar
            string _var_tipo = txtTipo.Text;
            _numero_opeeracion_selec = ContabilidadBL.ObtenerNumeroOperacion_BL(_var_cta_bco, _var_tipo, Global.vUserBaseDatos);

            txtNroOperacion.Text = _numero_opeeracion_selec.ToString();

        }

        private void gcAbonos_Load(object sender, EventArgs e)
        {
            // Subscribe to the SelectionChanged event
            gvAbonos.SelectionChanged += gvAbonos_SelectionChanged;
        }

        private void btnActualizarPendientes_Click(object sender, EventArgs e)
        {

            string _moneda_select = cboMoneda.Text;       //"Soles"

            switch (_moneda_select)
            {
                case "Soles":
                    _moneda_selec = "L";
                    break;
                case "Dolares":
                    _moneda_selec = "D";
                    break;
                default:
                    // code block
                    break;
            }


            if (_moneda_ctabco_select != _moneda_selec)
            {
                MessageBox.Show("La moneda de la Cuenta de banco debe ser la misma que la moneda seleccionada", "Liquidacion de tarjetas");
                return;
            }

            _ctabco_select = txtCtaBancosLiq.Text;  //cuenta banco

            dFechaAl = Convert.ToDateTime(deFechaAl.Text);               // {10/03/2025 00:00:00}
            dFechaDeposito = Convert.ToDateTime(deFechaDeposito.Text);   // {5/03/2025 00:00:00}
            _sucursal_selec = cboCaja.Text;                   //"CHICLAYO"
            _caja_selec = cboCaja.SelectedValue.ToString();   // "0010"
            _tarjeta_selec = cboTarjetas.Text;                //"VISANET"
            _tipo_cambio_selec = Convert.ToDecimal(txtTipoCambio.Text);

            if (_tipo_cambio_selec <= 0)
            {
                MessageBox.Show("Debe ingresar el Tipo de Cambio para la Liquidacion");
                return;
            }


            //ObtenerAbonos(dFechaAl, dFechaDeposito, "0010", "VISANET", "S");
            ObtenerAbonosPendientes(dFechaAl, dFechaDeposito, _caja_selec, _tarjeta_selec, _moneda_selec, _tipo_cambio_selec);

        }

        public void ObtenerAbonosPendientes(DateTime fecha_al, DateTime fecha_deposito, string sucursal, string tarjeta, string moneda, Decimal tipo_cambio)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de los abonos ....", "Espere por favor.."))
            {
                DataTable dtAbonos = new DataTable();
                ///dtAbonos = ContabilidadBL.dtObtieneTarjetasListado_BL("PENDIENTE", fecha_al, fecha_deposito, sucursal, tarjeta, moneda, tipo_cambio, null, null, Global.vUserBaseDatos);
                dtAbonos = ContabilidadBL.dtObtieneTarjetasListado_BL("PENDIENTE", fecha_al, fecha_deposito, sucursal, tarjeta, moneda, tipo_cambio, fecha_al, fecha_al, "Documentos", Global.vUserBaseDatos);
                gcAbonos.DataSource = dtAbonos;
            }

            ConfiguraGrillaAbonos();

            ////if (gvAbonos.RowCount > 0)
            ////{
            ////    HabilitaFiltros(false);
            ////}

        }

        private void gvAbonos_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            decimal abonos = 0m;
            decimal comision = 0m;
            decimal neto = 0m;

            // Get the selected rows
            int[] selectedRowHandles = gvAbonos.GetSelectedRows();

            // Loop through selected rows and accumulate the values
            foreach (int rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0) // Ensure the row handle is valid
                {
                    abonos += Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LIQUIDAR"));
                    //comision += Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "IMPUESTO"));
                    neto += Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LIQUIDAR"));   //??????
                }
            }

            txtTotalAbono.Text = abonos.ToString("N2"); // Format with 2 decimal places
            //txtTotalComision.Text = comision.ToString("N2");
            txtTotalNeto.Text = neto.ToString("N2");
        }

        public void ConfiguraGrillaAbonos()
        {

            gvAbonos.OptionsView.ColumnAutoWidth = false;
            gvAbonos.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gvAbonos.Appearance.Row.Font.Name, 7);
            gvAbonos.Appearance.HeaderPanel.Font = fnt;
            gvAbonos.Appearance.Row.Font = fnt;
            gvAbonos.Appearance.Row.Options.UseFont = true;
            gvAbonos.OptionsView.ShowGroupPanel = false;
            gvAbonos.OptionsView.ShowIndicator = false;
            gvAbonos.OptionsBehavior.Editable = true;  //false;
            gvAbonos.OptionsSelection.EnableAppearanceFocusedCell = false;

            gvAbonos.OptionsSelection.MultiSelect = true;
            gvAbonos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gvAbonos.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;

            gvAbonos.Columns["FECHA_HORA"].VisibleIndex = 1;
            gvAbonos.Columns["FECHA_HORA"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["FECHA_HORA"].Caption = "FECHA";
            gvAbonos.Columns["FECHA_HORA"].Width = 70;
            gvAbonos.Columns["FECHA_HORA"].Visible = true;

            gvAbonos.Columns["TIPO_DOCUMENTO"].VisibleIndex = 2;
            gvAbonos.Columns["TIPO_DOCUMENTO"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["TIPO_DOCUMENTO"].Caption = "TIPODOC";
            gvAbonos.Columns["TIPO_DOCUMENTO"].Width = 55;
            gvAbonos.Columns["TIPO_DOCUMENTO"].Visible = true;

            gvAbonos.Columns["FACTURA"].VisibleIndex = 3;
            gvAbonos.Columns["FACTURA"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["FACTURA"].Caption = "FACTURA";
            gvAbonos.Columns["FACTURA"].Width = 70;
            gvAbonos.Columns["FACTURA"].Visible = true;

            gvAbonos.Columns["NUM_DOCUMENTO"].VisibleIndex = 4;
            gvAbonos.Columns["NUM_DOCUMENTO"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["NUM_DOCUMENTO"].Caption = "DOCUMENTO";
            gvAbonos.Columns["NUM_DOCUMENTO"].Width = 70;
            gvAbonos.Columns["NUM_DOCUMENTO"].Visible = true;

            gvAbonos.Columns["NOMBRE"].VisibleIndex = 5;
            gvAbonos.Columns["NOMBRE"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["NOMBRE"].Caption = "NOMBRE";
            gvAbonos.Columns["NOMBRE"].Width = 150;
            gvAbonos.Columns["NOMBRE"].Visible = true;

            gvAbonos.Columns["MONEDA"].VisibleIndex = 6;
            gvAbonos.Columns["MONEDA"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["MONEDA"].Caption = "MONED";
            gvAbonos.Columns["MONEDA"].Width = 55;
            gvAbonos.Columns["MONEDA"].Visible = true;
            //MONTO LOCAL
            gvAbonos.Columns["MONTO_LOCAL"].VisibleIndex = 7;
            gvAbonos.Columns["MONTO_LOCAL"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["MONTO_LOCAL"].Caption = "LOCAL";
            gvAbonos.Columns["MONTO_LOCAL"].Width = 75;
            gvAbonos.Columns["MONTO_LOCAL"].Visible = true;
            gvAbonos.Columns["MONTO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvAbonos.Columns["MONTO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //MONTODOLAR
            gvAbonos.Columns["MONTO_DOLAR"].VisibleIndex = 8;
            gvAbonos.Columns["MONTO_DOLAR"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["MONTO_DOLAR"].Caption = "DOLAR";
            gvAbonos.Columns["MONTO_DOLAR"].Width = 75;
            gvAbonos.Columns["MONTO_DOLAR"].Visible = true;
            gvAbonos.Columns["MONTO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvAbonos.Columns["MONTO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //TC
            gvAbonos.Columns["TIPO_CAMBIO"].VisibleIndex = 9;
            gvAbonos.Columns["TIPO_CAMBIO"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["TIPO_CAMBIO"].Caption = "T.C LIQ.";
            gvAbonos.Columns["TIPO_CAMBIO"].Width = 55;
            gvAbonos.Columns["TIPO_CAMBIO"].Visible = true;
            gvAbonos.Columns["TIPO_CAMBIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvAbonos.Columns["TIPO_CAMBIO"].DisplayFormat.FormatString = "##,###,###,##0.0000";
            //MONTO LIQUIDAR
            gvAbonos.Columns["MONTO_LIQUIDAR"].VisibleIndex = 10;
            gvAbonos.Columns["MONTO_LIQUIDAR"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["MONTO_LIQUIDAR"].Caption = "LIQUIDAR";
            gvAbonos.Columns["MONTO_LIQUIDAR"].Width = 75;
            gvAbonos.Columns["MONTO_LIQUIDAR"].Visible = true;
            gvAbonos.Columns["MONTO_LIQUIDAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvAbonos.Columns["MONTO_LIQUIDAR"].DisplayFormat.FormatString = "##,###,###,##0.00";

            gvAbonos.Columns["NUMERO_PAGO"].VisibleIndex = 11;
            gvAbonos.Columns["NUMERO_PAGO"].OptionsColumn.AllowEdit = false;
            gvAbonos.Columns["NUMERO_PAGO"].Caption = "NROPAGO";
            gvAbonos.Columns["NUMERO_PAGO"].Width = 55;
            gvAbonos.Columns["NUMERO_PAGO"].Visible = true;

        }

        private void btnExportarPendientes_Click(object sender, EventArgs e)
        {

            if (gvAbonos.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Liquidacion de Tarjetas - Pendientes");
                return;
            }
            else
            {
                gcAbonos.ShowPrintPreview();
            }
        }



        private void btnLiquidarPendientes_Click(object sender, EventArgs e)
        {
            //validamos la moneda seleccionada con la moneda de la cuenta banco

            string _moneda_select = cboMoneda.Text;       //"Soles"

            switch (_moneda_select)
            {
                case "Soles":
                    _moneda_selec = "L";
                    break;
                case "Dolares":
                    _moneda_selec = "D";
                    break;
                default:
                    // code block
                    break;
            }

            _ctabco_select = cboCtaBancosLiq.SelectedValue.ToString();


            if (_moneda_ctabco_select != _moneda_selec)
            {
                MessageBox.Show("La moneda de la Cuenta de banco debe ser la misma que la moneda seleccionada", "Liquidacion de tarjetas");
                return;
            }

            ////if (Convert.ToDecimal(txtTotalComision.Text) <= 0)
            ////{
            ////    MessageBox.Show("El valor de la comision debe ser mayor a cero.", "Liquidacion de Tarjetas");
            ////    return;
            ////}

            var_moneda = _moneda_selec;
            va_fecha_al = Convert.ToDateTime(deFechaAl.Text);
            var_num_operacion = Convert.ToDecimal(txtNroOperacion.Text);
            var_caja = cboCaja.SelectedValue.ToString();    ////cboCaja.Text;
            var_tarjeta = cboTarjetas.Text;
            var_fecha_deposito = Convert.ToDateTime(deFechaDeposito.Text);
            var_tipo_cambio = Convert.ToDecimal(txtTipoCambio.Text);

            _ctabco_select = txtCtaBancosLiq.Text; //cuenta banco a liquidar

            //validaciones.....   TODO

            if (gvAbonos.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Procesar.", "Carga Excel " + varAplicacionDescripcion + "  --> ERP Exactus");
                return;
            }


            if (var_tarjeta=="YAPE")
            {

                ////MessageBox.Show("Procesando Abonos con YAPE...............", "Liquidacion de YAPE");
                ProcesarLiquidacionYape();

            } else
            {

                if (Convert.ToDecimal(txtTotalComision.Text) <= 0)
                {
                    MessageBox.Show("El valor de la comision debe ser mayor a cero.", "Liquidacion de Tarjetas");
                    return;
                }

                ////MessageBox.Show("Procesando Abonos con Tarjetas...........", "Liquidacion de Tarjetas");
                ProcesarLiquidacionTarjetas();

            }

            ////HabilitaFiltros(true);

            CargarNumeroOperacion(); //MAXMAX

        }

        private void ProcesarLiquidacionTarjetas()
        {

            // Obtener los índices de las filas seleccionadas
            int[] selectedRows = gvAbonos.GetSelectedRows();

            // Verificar si hay filas seleccionadas
            if (selectedRows.Length == 0)
            {
                MessageBox.Show("No hay filas seleccionadas para procesar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // PROCESAR ABONOS TARJETAS
            try
            {
                //PROCESO GRABA
                DialogResult dialogResult = MessageBox.Show("Liquidacion de Abonos con Tarjeta"
                                                        + "\n"
                                                        + "\nEsta seguro de Procesar la informacion?", "Liquidacion de Tarjetas", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información.........Liquidacion  de Abonos con Tarjetas", "Espere por favor.."))
                    {

                        varUSUARIO = Global.vUserUsuario;
                        varFECHA_PROCESO = DateTime.Now;

                        //varFECHA_HORA = null;
                        varNUM_DOCUMENTO = "";
                        varNOMBRE = "";
                        varMONEDA = "";
                        varMONTO_LOCAL = 0;
                        varMONTO_DOLAR = 0;
                        varTIPO_CAMBIO = 0;
                        varMONTO_LIQUIDAR = 0;
                        varTIPO_DOCUMENTO = "";
                        varFACTURA = "";
                        varNUMERO_PAGO = "";
                        varSELECC_LIQ = "";
                        varCAJA = "";
                        varCAJA_DESCRIPCION = "";
                        varTIPO_TARJETA = "";

                        acum_abono = 0;
                        acum_comision = 0;
                        acum_neto = 0;

                        var_asiento_generado = "";
                        var_resultado_liquidacion = "";

                        var_ASIENTO_LIQUIDACION = "";

                        // BEGIN - Iniciar la conexión y la transacción
                        string connectionString = ConexionDC.ConectarBD(Global.vUserBaseDatos);

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlTransaction transaction = conn.BeginTransaction())
                            {
                                try
                                {
                                    // BEGIN - Procesar cada línea
                                    foreach (int rowHandle in selectedRows)
                                    {
                                        if (rowHandle >= 0) // Verificar que el índice sea válido
                                        {
                                            varFECHA_HORA = Convert.ToDateTime(gvAbonos.GetRowCellValue(rowHandle, "FECHA_HORA").ToString());
                                            varNUM_DOCUMENTO = gvAbonos.GetRowCellValue(rowHandle, "NUM_DOCUMENTO").ToString();
                                            varNOMBRE = gvAbonos.GetRowCellValue(rowHandle, "NOMBRE").ToString();
                                            varMONEDA = gvAbonos.GetRowCellValue(rowHandle, "MONEDA").ToString();
                                            varMONTO_LOCAL = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LOCAL"));
                                            varMONTO_DOLAR = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_DOLAR"));
                                            varTIPO_CAMBIO = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "TIPO_CAMBIO"));
                                            varMONTO_LIQUIDAR = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LIQUIDAR"));
                                            varTIPO_DOCUMENTO = gvAbonos.GetRowCellValue(rowHandle, "TIPO_DOCUMENTO").ToString();
                                            varFACTURA = gvAbonos.GetRowCellValue(rowHandle, "FACTURA").ToString();
                                            varNUMERO_PAGO = gvAbonos.GetRowCellValue(rowHandle, "NUMERO_PAGO").ToString();
                                            varCAJA = gvAbonos.GetRowCellValue(rowHandle, "CAJA").ToString();
                                            varCAJA_DESCRIPCION = gvAbonos.GetRowCellValue(rowHandle, "SUCURSAL").ToString();
                                            varTIPO_TARJETA = gvAbonos.GetRowCellValue(rowHandle, "TIPO_TARJETA").ToString();

                                            acum_abono = acum_abono + varMONTO_LIQUIDAR; // en soles o dolares 

                                            ContabilidadBL.dtLiquidacionTajetasDocumento_TRANSAC_BL("LIQUIDAR", varTIPO_DOCUMENTO, varFACTURA, varMONTO_LIQUIDAR, varTIPO_CAMBIO,
                                                                                                    Convert.ToInt16(varNUMERO_PAGO), varCAJA, var_num_operacion, Global.vUserBaseDatos, transaction);
                                        }
                                    }
                                    // END - Procesar cada línea

                                    //Actualizo Acumulados
                                    acum_comision = Convert.ToDecimal(txtTotalComision.Text);
                                    acum_neto = (acum_abono - acum_comision);

                                    //if (varMONEDA == "L")
                                    //{
                                    //    MessageBox.Show("TOTALES S/.:  Abonos: " + acum_abono.ToString() + " Comision: " + acum_comision.ToString() + " Neto:  " + acum_neto.ToString(), "Liquidacion de Tarjetas " + "  ");
                                    //}
                                    //else
                                    //{
                                    //    MessageBox.Show("TOTALES US$:  Abonos: " + acum_abono.ToString() + " Comision: " + acum_comision.ToString() + " Neto:  " + acum_neto.ToString(), "Liquidacion de Tarjetas " + "  ");
                                    //}

                                    //

                                    //ContabilidadBL.dtLiquidarTarjetas_TRANSAC_BL("LIQUIDAR",
                                    //                                                va_fecha_al,   ////_fecha_al, 
                                    //                                                var_num_operacion,   ////_num_operacion, 
                                    //                                                var_caja,    ////_caja, 
                                    //                                                var_tarjeta, ////_tarjeta,
                                    //                                                var_fecha_deposito,   ////_fecha_deposito, 
                                    //                                                var_tipo_cambio,   ////_tipo_cambio, 
                                    //                                                var_moneda,  ////_moneda,
                                    //                                                acum_abono,                 ////_liq_monto, 
                                    //                                                acum_comision,              ////_liq_comis, 
                                    //                                                acum_neto,                  ////_liq_neto,
                                    //                                                param_liq.tipo_asiento,     ////_tipo_asiento, 
                                    //                                                param_liq.paquete,          ////_paquete, 
                                    //                                                _ctabco_select,             ///// param_liq.cuenta_banco,     ////_cuenta_banco, 
                                    //                                                param_liq.tipo,             ////_tipo, 
                                    //                                                param_liq.subtipo,          ////_subtipo,
                                    //                                                Global.vUserUsuario, Global.vUserBaseDatos, transaction); ////_usuario, db);



                                    var_ASIENTO_LIQUIDACION = ContabilidadBL.dtLiquidarTarjetas_TRANSAC_ASIENTO_BL("LIQUIDAR",
                                                                                        va_fecha_al,   ////_fecha_al, 
                                                                                        var_num_operacion,   ////_num_operacion, 
                                                                                        var_caja,    ////_caja, 
                                                                                        var_tarjeta, ////_tarjeta,
                                                                                        var_fecha_deposito,   ////_fecha_deposito, 
                                                                                        var_tipo_cambio,   ////_tipo_cambio, 
                                                                                        var_moneda,  ////_moneda,
                                                                                        acum_abono,                 ////_liq_monto, 
                                                                                        acum_comision,              ////_liq_comis, 
                                                                                        acum_neto,                  ////_liq_neto,
                                                                                        param_liq.tipo_asiento,     ////_tipo_asiento, 
                                                                                        param_liq.paquete,          ////_paquete, 
                                                                                        _ctabco_select,             ///// param_liq.cuenta_banco,     ////_cuenta_banco, 
                                                                                        param_liq.tipo,             ////_tipo, 
                                                                                        param_liq.subtipo,          ////_subtipo,
                                                                                        Global.vUserUsuario, Global.vUserBaseDatos, transaction); ////_usuario, db);

                                    var_resultado_liquidacion = "OK";

                                    // Confirmar la transacción si todo sale bien
                                    transaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    var_resultado_liquidacion = "XX";
                                    // Revertir la transacción si ocurre un error
                                    transaction.Rollback();
                                    throw new Exception("Error al procesar las líneas o el lote: " + ex.Message);
                                }
                            }
                        }
                        // FIN - Iniciar la conexión y la transacción
                    }

                    if (var_resultado_liquidacion == "XX")
                    {
                        MessageBox.Show("Proceso NO Finalizado. ", "Liquidacion de Tarjetas ");
                    }


                    if (var_resultado_liquidacion == "OK")
                    {
                        //var_asiento_generado = ContabilidadBL.ObtenerAsientoGenerado_BL(var_num_operacion, Global.vUserBaseDatos);

                        //if ((var_asiento_generado != "") && var_asiento_generado.Length > 0)
                        if ((var_ASIENTO_LIQUIDACION != "") && var_ASIENTO_LIQUIDACION.Length > 0)
                        {
                            InicializarLiquidacion();
                            //
                            MessageBox.Show("Proceso Finalizado. Se genero el asiento " + var_ASIENTO_LIQUIDACION, "Liquidacion de Tarjetas ");

                            frmLiquidacionAsiento FormAsiento = new frmLiquidacionAsiento();

                            //FormAsiento._asiento = var_asiento_generado;
                            FormAsiento._asiento = var_ASIENTO_LIQUIDACION;

                            FormAsiento.ShowDialog();
                            if (FormAsiento.DialogResult == DialogResult.OK)
                            {

                            }
                            else
                            {

                            }


                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //END - TRY


        }



        private void ProcesarLiquidacionYape()
        {
            GenerarOperacionAutomatico = false;

            // Obtener los índices de las filas seleccionadas
            int[] selectedRows = gvAbonos.GetSelectedRows();

            // Verificar si hay filas seleccionadas
            if (selectedRows.Length == 0)
            {
                MessageBox.Show("Liquidacion de Abonos con YAPE.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            //VALIDA SI SELECCIONO MAS DE 1

            if (selectedRows.Length > 1)
            {
                //////MessageBox.Show("Liquidacion de Abonos con YAPE.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////MessageBox.Show("Ha seleccionado " + selectedRows.Length + " Abonos", "Liquidacion de Abonos con YAPE.");
                ////return;

                try
                {
                    //PROCESO GRABA
                    DialogResult dialogResult = MessageBox.Show("Liquidacion de Abonos con YAPE."
                                                            + "\n"
                                                            + "\nHa seleccionado " + selectedRows.Length + " Abonos, Por lo que el Numero de Operacion sera asignada automaticamente"
                                                            + "\nEsta seguro de Procesar la informacion?", "Liquidacion de Abonos con YAPE.", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        GenerarOperacionAutomatico = true;
                        ////MessageBox.Show("Se asignara el Numero de Operacion automaticamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


            if ((selectedRows.Length > 1) && (GenerarOperacionAutomatico == false) )
            {
                ////MessageBox.Show("((selectedRows.Length > 1) && (GenerarOperacionAutomatico == false) )", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }






            //PROCESAR ABONOS YAPE
            try
            {
                //PROCESO GRABA
                DialogResult dialogResult = MessageBox.Show("Liquidacion de Abonos con YAPE."
                                                        + "\n"
                                                        + "\nEsta seguro de Procesar la informacion?", "Liquidacion de Abonos con YAPE.", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información............Liquidacion de Abonos con YAPE.", "Espere por favor.."))
                    {

                        varUSUARIO = Global.vUserUsuario;
                        varFECHA_PROCESO = DateTime.Now;

                        //varFECHA_HORA = null;
                        varNUM_DOCUMENTO = "";
                        varNOMBRE = "";
                        varMONEDA = "";
                        varMONTO_LOCAL = 0;
                        varMONTO_DOLAR = 0;
                        varTIPO_CAMBIO = 0;
                        varMONTO_LIQUIDAR = 0;
                        varTIPO_DOCUMENTO = "";
                        varFACTURA = "";
                        varNUMERO_PAGO = "";
                        varSELECC_LIQ = "";
                        varCAJA = "";
                        varCAJA_DESCRIPCION = "";
                        varTIPO_TARJETA = "";

                        acum_abono = 0;
                        acum_comision = 0;
                        acum_neto = 0;

                        var_asiento_generado = "";
                        var_resultado_liquidacion = "";

                        var_ASIENTO_LIQUIDACION = "";

                        // BEGIN - Iniciar la conexión y la transacción
                        string connectionString = ConexionDC.ConectarBD(Global.vUserBaseDatos);

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlTransaction transaction = conn.BeginTransaction())
                            {
                                try
                                {
                                    // BEGIN - Procesar cada línea
                                    foreach (int rowHandle in selectedRows)
                                    {
                                        if (rowHandle >= 0) // Verificar que el índice sea válido
                                        {

                                            acum_abono = 0; // inicializar para cada linea

                                            varFECHA_HORA = Convert.ToDateTime(gvAbonos.GetRowCellValue(rowHandle, "FECHA_HORA").ToString());
                                            varNUM_DOCUMENTO = gvAbonos.GetRowCellValue(rowHandle, "NUM_DOCUMENTO").ToString();
                                            varNOMBRE = gvAbonos.GetRowCellValue(rowHandle, "NOMBRE").ToString();
                                            varMONEDA = gvAbonos.GetRowCellValue(rowHandle, "MONEDA").ToString();
                                            varMONTO_LOCAL = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LOCAL"));
                                            varMONTO_DOLAR = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_DOLAR"));
                                            varTIPO_CAMBIO = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "TIPO_CAMBIO"));
                                            varMONTO_LIQUIDAR = Convert.ToDecimal(gvAbonos.GetRowCellValue(rowHandle, "MONTO_LIQUIDAR"));
                                            varTIPO_DOCUMENTO = gvAbonos.GetRowCellValue(rowHandle, "TIPO_DOCUMENTO").ToString();
                                            varFACTURA = gvAbonos.GetRowCellValue(rowHandle, "FACTURA").ToString();
                                            varNUMERO_PAGO = gvAbonos.GetRowCellValue(rowHandle, "NUMERO_PAGO").ToString();
                                            varCAJA = gvAbonos.GetRowCellValue(rowHandle, "CAJA").ToString();
                                            varCAJA_DESCRIPCION = gvAbonos.GetRowCellValue(rowHandle, "SUCURSAL").ToString();
                                            varTIPO_TARJETA = gvAbonos.GetRowCellValue(rowHandle, "TIPO_TARJETA").ToString();

                                            acum_abono = acum_abono + varMONTO_LIQUIDAR; // en soles o dolares 

                                            // DETERMINA NUMERO DE OPERACION  
                                            NumeroOperacionAutomatico = 0;

                                            if (GenerarOperacionAutomatico == false)
                                            {
                                                //////var_num_operacion = Convert.ToDecimal(txtNroOperacion.Text);
                                                NumeroOperacionAutomatico = Convert.ToDecimal(txtNroOperacion.Text);
                                            }
                                            else
                                            {
                                                NumeroOperacionAutomatico = ObtenerNumeroOperacionAutomatico();   // genera correlativo de NumeroOperacionAutomatico
                                            }


                                            if (NumeroOperacionAutomatico == 0)
                                            {
                                                MessageBox.Show("Error al generar Numero de Operacion, Numero: " + NumeroOperacionAutomatico.ToString(), "Liquidacion de Abonos con YAPE.");
                                                return;
                                            }

                                            // REGISTRA ABONO COMO LIQUIDADO
                                            ContabilidadBL.dtLiquidacionTajetasDocumento_TRANSAC_BL("LIQUIDAR", varTIPO_DOCUMENTO, varFACTURA, varMONTO_LIQUIDAR, varTIPO_CAMBIO,
                                                                                                    Convert.ToInt16(varNUMERO_PAGO), varCAJA, NumeroOperacionAutomatico, Global.vUserBaseDatos, transaction);

                                            // GENERA ASIENTO DE LIQUIDACION
                                            //Actualizo Acumulados por cada linea
                                            acum_comision = Convert.ToDecimal(txtTotalComision.Text);
                                            acum_neto = (acum_abono - acum_comision);

                                            var_ASIENTO_LIQUIDACION = ContabilidadBL.dtLiquidarYape_TRANSAC_ASIENTO_BL("LIQUIDAR",
                                                                                                    va_fecha_al,   ////_fecha_al, 
                                                                                                    NumeroOperacionAutomatico,      ////var_num_operacion,   ////_num_operacion, 
                                                                                                    var_caja,    ////_caja, 
                                                                                                    var_tarjeta, ////_tarjeta,
                                                                                                    var_fecha_deposito,   ////_fecha_deposito, 
                                                                                                    var_tipo_cambio,   ////_tipo_cambio, 
                                                                                                    var_moneda,  ////_moneda,
                                                                                                    acum_abono,                 ////_liq_monto, 
                                                                                                    acum_comision,              ////_liq_comis, 
                                                                                                    acum_neto,                  ////_liq_neto,
                                                                                                    param_liq.tipo_asiento,     ////_tipo_asiento, 
                                                                                                    param_liq.paquete,          ////_paquete, 
                                                                                                    _ctabco_select,             ///// param_liq.cuenta_banco,     ////_cuenta_banco, 
                                                                                                    param_liq.tipo,             ////_tipo, 
                                                                                                    param_liq.subtipo,          ////_subtipo,
                                                                                                    Global.vUserUsuario, Global.vUserBaseDatos, transaction); ////_usuario, db);


                                            // MUESTRA ASIENTO GENERADO
                                            if ((var_ASIENTO_LIQUIDACION != "") && var_ASIENTO_LIQUIDACION.Length > 0)
                                            {
                                                //////InicializarLiquidacion();   NOO
                                                //
                                                MessageBox.Show("Proceso Finalizado. Se genero el asiento " + var_ASIENTO_LIQUIDACION, "Liquidacion de Abonos con YAPE.");

                                                frmLiquidacionAsiento FormAsiento = new frmLiquidacionAsiento();

                                                //FormAsiento._asiento = var_asiento_generado;
                                                FormAsiento._asiento = var_ASIENTO_LIQUIDACION;

                                                FormAsiento.ShowDialog();
                                                if (FormAsiento.DialogResult == DialogResult.OK)
                                                {

                                                }
                                                else
                                                {

                                                }
                                            }



                                        }
                                    }
                                    // END - Procesar cada línea

                                    ////////Actualizo Acumulados
                                    //////acum_comision = Convert.ToDecimal(txtTotalComision.Text);
                                    //////acum_neto = (acum_abono - acum_comision);

                                    //////var_ASIENTO_LIQUIDACION = ContabilidadBL.dtLiquidarTarjetas_TRANSAC_ASIENTO_BL("LIQUIDAR",
                                    //////                                                    va_fecha_al,   ////_fecha_al, 
                                    //////                                                    var_num_operacion,   ////_num_operacion, 
                                    //////                                                    var_caja,    ////_caja, 
                                    //////                                                    var_tarjeta, ////_tarjeta,
                                    //////                                                    var_fecha_deposito,   ////_fecha_deposito, 
                                    //////                                                    var_tipo_cambio,   ////_tipo_cambio, 
                                    //////                                                    var_moneda,  ////_moneda,
                                    //////                                                    acum_abono,                 ////_liq_monto, 
                                    //////                                                    acum_comision,              ////_liq_comis, 
                                    //////                                                    acum_neto,                  ////_liq_neto,
                                    //////                                                    param_liq.tipo_asiento,     ////_tipo_asiento, 
                                    //////                                                    param_liq.paquete,          ////_paquete, 
                                    //////                                                    _ctabco_select,             ///// param_liq.cuenta_banco,     ////_cuenta_banco, 
                                    //////                                                    param_liq.tipo,             ////_tipo, 
                                    //////                                                    param_liq.subtipo,          ////_subtipo,
                                    //////                                                    Global.vUserUsuario, Global.vUserBaseDatos, transaction); ////_usuario, db);

                                    var_resultado_liquidacion = "OK";

                                    // Confirmar la transacción si todo sale bien
                                    transaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    var_resultado_liquidacion = "XX";
                                    // Revertir la transacción si ocurre un error
                                    transaction.Rollback();
                                    throw new Exception("Error al procesar las líneas o el lote: " + ex.Message);
                                }
                            }
                        }
                        // FIN - Iniciar la conexión y la transacción
                    }

                    InicializarLiquidacion();


                    ////////if (var_resultado_liquidacion == "XX")
                    ////////{
                    ////////    MessageBox.Show("Proceso NO Finalizado. ", "Liquidacion de Tarjetas ");
                    ////////}


                    ////////if (var_resultado_liquidacion == "OK")
                    ////////{
                    ////////    //var_asiento_generado = ContabilidadBL.ObtenerAsientoGenerado_BL(var_num_operacion, Global.vUserBaseDatos);
                    ////////    //if ((var_asiento_generado != "") && var_asiento_generado.Length > 0)
                    ////////    if ((var_ASIENTO_LIQUIDACION != "") && var_ASIENTO_LIQUIDACION.Length > 0)
                    ////////    {
                    ////////        InicializarLiquidacion();
                    ////////        //
                    ////////        MessageBox.Show("Proceso Finalizado. Se genero el asiento " + var_ASIENTO_LIQUIDACION, "Liquidacion de Tarjetas ");
                    ////////        frmLiquidacionAsiento FormAsiento = new frmLiquidacionAsiento();
                    ////////        //FormAsiento._asiento = var_asiento_generado;
                    ////////        FormAsiento._asiento = var_ASIENTO_LIQUIDACION;
                    ////////        FormAsiento.ShowDialog();
                    ////////        if (FormAsiento.DialogResult == DialogResult.OK)
                    ////////        {
                    ////////        }
                    ////////        else
                    ////////        {
                    ////////        }
                    ////////    }
                    ////////}

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //END - TRY


        }

        private Decimal ObtenerNumeroOperacionAutomatico()
        {
            Decimal _numero_operacion = 0;

            string _var_cta_bco = txtCtaBancosLiq.Text;     // de lo que el usuario elija al liquidar
            string _var_tipo = txtTipo.Text;

            _numero_operacion = ContabilidadBL.ObtenerNumeroOperacion_BL(_var_cta_bco, _var_tipo, Global.vUserBaseDatos);

            return _numero_operacion;
        }


        #endregion












    }
}
//EOF

