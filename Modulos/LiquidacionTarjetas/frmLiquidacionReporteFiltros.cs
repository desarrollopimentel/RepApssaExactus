using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApssaExactus
{
    public partial class frmLiquidacionReporteFiltros : Form
    {

        CargaLookUpBL objCargaLookUpBL = new CargaLookUpBL();

        public frmLiquidacionReporteFiltros()
        {
            InitializeComponent();
        }

        private void frmLiquidacionReporteFiltros_Load(object sender, EventArgs e)
        {

            var fechaActual = DateTime.Today;
            this.deFechaDesde.Text = fechaActual.ToString();
            this.deFechaHasta.Text = fechaActual.ToString();

            Cargar_Sucursales();
            Cargar_Tarjetas();



        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ////Global.vUserUsuario = null;
            ////Global.vUserClave = null;
            ////Global.vUserBaseDatos = null;
            ////Global.vUserAPSSADB = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime rep_dFechaDesde = Convert.ToDateTime(deFechaDesde.Text);               // {10/03/2025 00:00:00}
            DateTime rep_dFechaHasta = Convert.ToDateTime(deFechaHasta.Text);   // {5/03/2025 00:00:00}
            string rep_caja = cboCaja.SelectedValue.ToString();   // "0010"
            string rep_tarjeta = cboTarjetas.Text;                //"VISANET"

            string rep_moneda = "L";
            string rep_estado = "T";
            string rep_mensaje = "XXXXxxxx";

            string rep_checkLocal = "N";         // checkLocal.Text;
            string rep_checkDolar = "N";         // checkDolar.Text;
            string rep_checkPendiente = "N";     // checkPendiente.Text;
            string rep_checkLiquidado = "N";     // checkLiquidado.Text;

            if (checkLocal.Checked == true){
                rep_checkLocal = "S";
            } else{
                rep_checkLocal = "N";  }

            if (checkDolar.Checked == true){
                rep_checkDolar = "S";
            }
            else {
                rep_checkDolar = "N"; }

            if (checkPendiente.Checked == true) {
                rep_checkPendiente = "S";
            }
            else
            {
                rep_checkPendiente = "N"; }

            if (checkLiquidado.Checked == true){
                rep_checkLiquidado = "S";
            }
            else{
                rep_checkLiquidado = "N"; }


            frmLiquidacionReporte frmRpt = new frmLiquidacionReporte();
            frmRpt._fecha_desde = rep_dFechaDesde.ToString();
            frmRpt._fecha_hasta = rep_dFechaHasta.ToString();
            frmRpt._sucursal = rep_caja;
            frmRpt._tarjeta = rep_tarjeta;
            frmRpt._local = rep_checkLocal;
            frmRpt._dolar = rep_checkDolar;
            frmRpt._pendiente = rep_checkPendiente;
            frmRpt._liquidado = rep_checkLiquidado;
            frmRpt._mensaje = rep_mensaje;
            frmRpt.ShowDialog();

            ////parametro que recibe de frmEstadoCuentaCliente
            //public DateTime _dFechaIni { get; set; }
            //public DateTime _dFechaFin { get; set; }
            //public string _sucursal = string.Empty;
            //public string _tarjeta = string.Empty;
            //public string _moneda = string.Empty;
            //public string _estado = string.Empty;
            //public string _mensaje = string.Empty;

    }




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









    }
}
