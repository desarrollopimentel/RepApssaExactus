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

namespace ApssaExactus
{
    public partial class frmEstadoCuentaCliente : DevExpress.XtraEditors.XtraForm
    {
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        string contribuyente = string.Empty;
        string cliente = string.Empty;
        public static string vClienteSelecc = null;
        public static string vClienteNombreSelecc = null;
        public string vmensaje = string.Empty;
        public bool TeclaEnter = false;
        public bool EsCobranzaDudoza = false;

        public frmEstadoCuentaCliente()
        {
            InitializeComponent();
        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmEstadoCuentaCliente m_FormDefInstance;

        /// Instancia por defecto
        public static frmEstadoCuentaCliente DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmEstadoCuentaCliente();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// -------------------------------------------------------------------------

        private void frmEstadoCuentaCliente_Load(object sender, EventArgs e)
        {
            //
            DeshabilitaCajas();
            
            //inicializa campos
            txtCliente.Text = "";
            txtClienteNombre.Text = "";
            labelMensaje1.Text = "";
            labelMensaje1.Visible = false;
            labelMensaje2.Text = "";
            labelMensaje2.Visible = false;
            labelMensaje3.Text = "";
            labelMensaje3.Visible = false;
            
            //valores default   
            dpFechaIni.Text = "01/01/2005";    //DateTime.Today.ToShortDateString();
            dpFechaFin.Text = DateTime.Today.ToShortDateString();
            //txtCliente.Text = "20438933272";   // "20464428730";    // "20504086713"; // "20491793911";    // "20464428730";
            Accesos_Usuario();
        }

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

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            contribuyente = txtCliente.Text;
            cliente = txtCliente.Text;
            dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);
            dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);
            labelMensaje1.Visible = false;
            CargaSaldoDocumentosCliente(contribuyente, cliente, dFechaIni, dFechaFin, Global.vUserBaseDatos);            
            CargaInformacionCliente(cliente, Global.vUserBaseDatos);
            CargaLetrasEstadoCliente(cliente, dFechaFin, Global.vUserBaseDatos);
            //CargaSaldoCliente(cliente, Global.vUserBaseDatos);
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
                labelMensaje1.Text = vmensaje;
                labelMensaje1.Visible = true;
                labelMensaje2.Text = vmensaje;
                labelMensaje2.Visible = true;
                labelMensaje3.Text = vmensaje;
                labelMensaje3.Visible = true;
            }
            else
            {
                vmensaje = "               ";
                labelMensaje1.Text = "";
                labelMensaje1.Visible = false;
                labelMensaje2.Text = "";
                labelMensaje2.Visible = false;
                labelMensaje3.Text = "";
                labelMensaje3.Visible = false;
            } 


            // saldo total cliente 
            txtSaldoLocal.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoLocalCliente));
            txtSaldoDolares.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumSaldoDolarCliente));

            gcEstadoCuenta.DataSource = dt;
            gcauditoria.DataSource = dt;
            ConfiguraGridEstadoCuenta();                       

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
            double nDisponible = 0;
            EstadoCuentaBL objEstadoCuentaBL = new EstadoCuentaBL();
            DataTable dt2 = new DataTable();
            dt2 = objEstadoCuentaBL.dtInformacionClienteBL(cli, baseuser);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
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
                }
                else
                {
                    checkCobroJudicial.Checked = false;
                }

                if (dt2.Rows[i]["MOROSO"].ToString() == "S")
                {
                    checkMoroso.Checked = true;
                }
                else
                {
                    checkMoroso.Checked = false;
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
            gvLetras.OptionsView.ColumnAutoWidth = false;
            gvLetras.BestFitColumns();

            Font fnt = new Font(gvLetras.Appearance.Row.Font.Name, 8);
            gvLetras.Appearance.HeaderPanel.Font = fnt;
            gvLetras.Appearance.Row.Font = fnt;
            gvLetras.Appearance.Row.Options.UseFont = true;
            gvLetras.OptionsView.ShowGroupPanel = false;
            gvLetras.OptionsView.ShowIndicator = false;
            gvLetras.OptionsBehavior.Editable = false;
            gvLetras.OptionsSelection.EnableAppearanceFocusedCell = false;
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
            gvEstadoCuenta.OptionsView.ColumnAutoWidth = false;
            gvEstadoCuenta.BestFitColumns();

            Font fnt = new Font(gvEstadoCuenta.Appearance.Row.Font.Name, 8);
            gvEstadoCuenta.Appearance.HeaderPanel.Font = fnt;
            gvEstadoCuenta.Appearance.Row.Font = fnt;
            gvEstadoCuenta.Appearance.Row.Options.UseFont = true;
            gvEstadoCuenta.OptionsView.ShowGroupPanel = false;
            gvEstadoCuenta.OptionsView.ShowIndicator = false;
            gvEstadoCuenta.OptionsBehavior.Editable=false;
            gvEstadoCuenta.OptionsSelection.EnableAppearanceFocusedCell= false;
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
            //---------------------/*FORMATO PARA GV DE AUTORIA*/--------------------------------------//
            gvauditoria.OptionsView.ColumnAutoWidth = false;
            gvauditoria.BestFitColumns();

            Font fnt2 = new Font(gvauditoria.Appearance.Row.Font.Name, 8);
            gvauditoria.Appearance.HeaderPanel.Font = fnt2;
            gvauditoria.Appearance.Row.Font = fnt2;
            gvauditoria.Appearance.Row.Options.UseFont = true;
            gvauditoria.OptionsView.ShowGroupPanel = false;
            gvauditoria.OptionsView.ShowIndicator = false;
            gvauditoria.OptionsBehavior.Editable = false;//////////////////////////////////
            gvauditoria.OptionsSelection.EnableAppearanceFocusedCell = false;
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
            //frmBusca._cliente = txtCliente.Text;
            //frmBusca._clientenombre = txtClienteNombre.Text;
            //txtCliente.Text = "";
            //txtClienteNombre.Text = "";
            //frmBusca.ShowDialog();
            //if (vClienteSelecc != null)
            //{
            //    txtCliente.Text = vClienteSelecc;
            //    txtClienteNombre.Text = vClienteNombreSelecc;
            //}
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
            txtMonedaLinea.Enabled = false;
            txtMaximoLinea.Enabled = false;
            txtConsumidoLinea.Enabled = false;
            txtDisponibleLinea.Enabled = false;

            txtSaldoLocal.Enabled = false;
            txtSaldoDolares.Enabled = false;

            txtEmitidaSOL.Enabled = false;
            txtEmitidaDOL.Enabled = false;
            txtBancoSOL.Enabled = false;
            txtBancoDOL.Enabled = false;
            txtTransitoSOL.Enabled = false;
            txtTransitoDOL.Enabled = false;
            txtCarteraSOL.Enabled = false;
            txtCarteraDOL.Enabled = false;
            txtProtestadaSOL.Enabled = false;
            txtProtestadaDOL.Enabled = false;
            txtLetrasSOL.Enabled = false;
            txtLetrasDOL.Enabled = false;
            
            txtMAXIMO.Enabled = false;
            textDISPONIBLE.Enabled = false;
            textSALDO_LOCAL.Enabled = false;
            textSALDO_DOLAR.Enabled = false;
            textSALDO_CREDITO.Enabled = false;

            textCLIENTE.Enabled = false;
            textNOMBRE.Enabled = false;
            textMULTIMONEDA.Enabled = false;
            textMONEDA.Enabled = false;
            textCONDICION_PAGO.Enabled = false;
            textNIVEL_PRECIO.Enabled = false;
            textMONEDA_NIVEL.Enabled = false;
            textACTIVO.Enabled = false;
            textCATEGORIA_CLIENTE.Enabled = false;
            textMOROSO.Enabled = false;
            textU_ACTIVIDAD.Enabled = false;
            textU_SUBACTIVIDAD.Enabled = false;
            textU_CATEGORIACREDITO.Enabled = false;
            txtMAXIMO.Enabled = false;
            textEXCEDER_LIMITE.Enabled = false;
            textDISPONIBLE.Enabled = false;
            textSALDO_LOCAL.Enabled = false;
            textSALDO_DOLAR.Enabled = false;
            textSALDO_CREDITO.Enabled = false;
            textZONA.Enabled = false;
            textRUTA.Enabled = false;
            textVENDEDOR.Enabled = false;
            textCOBRADOR.Enabled = false;
            textCOBRO_JUDICIAL.Enabled = false;
            textDIRECCION.Enabled = false;
            textZONA_NOMBRE.Enabled = false;
            textRUTA_DESC.Enabled = false;
            textVENDEDOR_NOMBRE.Enabled = false;
            textCOBRADOR_NOMBRE.Enabled = false;
            textCOND_PAGO.Enabled = false;
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
            gcEstadoCuenta.ShowPrintPreview();
        }

        private void btnXlsLetrasEstado_Click_1(object sender, EventArgs e)
        {
            gcLetras.ShowPrintPreview();
        }

        private void btnImprimeEstadoCuenta_Click_1(object sender, EventArgs e)
        {
            //frmEstadoCuentaClienteRPT frmEC = new frmEstadoCuentaClienteRPT();
            //frmEC._dFechaIni = dFechaIni;
            //frmEC._dFechaFin = dFechaFin;
            //frmEC._cliente = cliente;
            //frmEC._contribuyente = contribuyente;
            //frmEC._mensaje = vmensaje;
            //frmEC.ShowDialog();
        }

        private void btnImprimeLetrasEstado_Click_1(object sender, EventArgs e)
        {
            //frmLetrasporCobrarClienteRPT frmLetra = new frmLetrasporCobrarClienteRPT();
            //frmLetra._dFechaIni = dFechaIni;
            //frmLetra._dFechaFin = dFechaFin;
            //frmLetra._cliente = cliente;
            //frmLetra._contribuyente = contribuyente;
            //frmLetra._mensaje = vmensaje;
            //frmLetra.ShowDialog();
        }

        //---------------------------------------------------------------------------------------------

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

                /*
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
                */
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Estado de Cuenta de Clientes");
            }

           
            
        }



        


    }
}

