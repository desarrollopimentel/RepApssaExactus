using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
//using Exactus.BE;
//using Exactus.BL;
//using Exactus.LIBCS;
//using Exactus.LIBVB;
using DevExpress.Utils;

namespace ApssaExactus
{
    public partial class frmLiquidacionAsiento : DevExpress.XtraEditors.XtraForm
    {
        public string cCaption = "Asiento Contable";
        public string _asiento = null;
        //public string _descripcion_aplicacion = null;
        //public string _tipo = null;

        public DataTable dtAsiento = new DataTable();
        public double sumDEBITO_LOCAL = 0;
        public double sumDEBITO_DOLAR = 0;
        public double sumCREDITO_LOCAL = 0;
        public double sumCREDITO_DOLAR = 0;

        public frmLiquidacionAsiento()
        {
            InitializeComponent();
        }

        private void frmLiquidacionAsiento_Load(object sender, EventArgs e)
        {
            this.Text = cCaption;
            txtAsiento.ReadOnly = true;  // siempre
            txtAsiento.Text = _asiento;

            CargarDiario("DIARIO", _asiento, 99);

        }


        private void CargarDiario(string _par_operacion, string _par_asiento, Decimal _par_numero)
        {
            sumDEBITO_LOCAL = 0;
            sumDEBITO_DOLAR = 0;
            sumCREDITO_LOCAL = 0;
            sumCREDITO_DOLAR = 0;

            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion ....", "Espere por favor.."))
            {
                //DataTable dtAsiento = new DataTable();
                dtAsiento = null;
                ///dtAsiento = ContabilidadDL.dtObtenerAsientoLiquidacion_DL(_par_operacion, _par_asiento, _par_numero, Global.vUserBaseDatos);  // ContabilidadBL.dtObtieneAsientoCreditosBL(_tipo, _asiento, Global.vUserBaseDatos);
                dtAsiento = ContabilidadDL.dtObtenerAsientoLiquidacion_DL(_par_operacion, _par_asiento, Global.vUserBaseDatos);  // ContabilidadBL.dtObtieneAsientoCreditosBL(_tipo, _asiento, Global.vUserBaseDatos);
                gcAsiento.DataSource = dtAsiento;

                ConfiguraGrilla(gvAsiento);

                //DEBITO_LOCAL,DEBITO_DOLAR,CREDITO_LOCAL,CREDITO_DOLAR
                for (int i = 0; i < dtAsiento.Rows.Count; i++)
                {
                    // acumula saldo cliente
                    sumDEBITO_LOCAL += Convert.ToDouble(dtAsiento.Rows[i]["DEBITO_LOCAL"].ToString());
                    sumDEBITO_DOLAR += Convert.ToDouble(dtAsiento.Rows[i]["DEBITO_DOLAR"].ToString());
                    sumCREDITO_LOCAL += Convert.ToDouble(dtAsiento.Rows[i]["CREDITO_LOCAL"].ToString());
                    sumCREDITO_DOLAR += Convert.ToDouble(dtAsiento.Rows[i]["CREDITO_DOLAR"].ToString());
                }

                txtDebitoLocal.Text = sumDEBITO_LOCAL.ToString();
                txtCreditoLocal.Text = sumCREDITO_LOCAL.ToString();
                txtDebitoDolar.Text = sumDEBITO_DOLAR.ToString();
                txtCreditoDolar.Text = sumCREDITO_DOLAR.ToString();
                txtDiferenciaSoles.Text = (sumDEBITO_LOCAL- sumCREDITO_LOCAL).ToString();
                txtDiferenciaDolares.Text = (sumDEBITO_DOLAR- sumCREDITO_DOLAR).ToString();

                txtDiferenciaSoles.Text = (Convert.ToDecimal(txtDebitoLocal.Text) - Convert.ToDecimal(txtCreditoLocal.Text)).ToString();
                txtDiferenciaDolares.Text = (Convert.ToDecimal(txtDebitoDolar.Text) - Convert.ToDecimal(txtCreditoDolar.Text) ).ToString();


                txtCreditoLocal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtCreditoLocal.Properties.Mask.EditMask = "n2";
                txtCreditoLocal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtCreditoLocal.Properties.DisplayFormat.FormatString = "n2";


                //txtDiferenciaSoles.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                //txtDiferenciaSoles.Properties.Mask.EditMask = "n2";
                //txtDiferenciaSoles.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //txtDiferenciaSoles.Properties.DisplayFormat.FormatString = "##,###,###,##0.00";

                //= "##,###,###,##0.00";
                //textEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //textEdit1.Properties.DisplayFormat.FormatString = "ID: {0:d4}";


                ////txtDebitoLocal.Properties.Mask.EditMask = "n2";
                ////txtDebitoLocal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                ////txtCreditoLocal.Properties.Mask.EditMask = "n2";
                ////txtCreditoLocal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                ////txtDebitoDolar.Properties.Mask.EditMask = "n2";
                ////txtDebitoDolar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                ////txtCreditoDolar.Properties.Mask.EditMask = "n2";
                ////txtCreditoDolar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                ////txtDiferenciaSoles.Properties.Mask.EditMask = "n2";
                ////txtDiferenciaSoles.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                ////txtDiferenciaDolares.Properties.Mask.EditMask = "n2";
                ////txtDiferenciaDolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            }

            //ConfiguraGrilla(gvAsiento);
        }


        public void ConfiguraGrilla(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsBehavior.Editable = false;
            gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            gv.OptionsView.ColumnAutoWidth = false;
            ////gv.BestFitColumns();
            gv.Appearance.Row.Font = new System.Drawing.Font(gv.Appearance.Row.Font, FontStyle.Bold);
            gv.Appearance.Row.Options.UseFont = true;

            System.Drawing.Font fnt = new System.Drawing.Font(gv.Appearance.Row.Font.Name, 7);
            gv.Appearance.HeaderPanel.Font = fnt;
            gv.Appearance.Row.Font = fnt;

            //FORMATO
            gv.Columns["DEBITO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["DEBITO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gv.Columns["DEBITO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["DEBITO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gv.Columns["CREDITO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["CREDITO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gv.Columns["CREDITO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns["CREDITO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Boolean TodoOK = true;

            try
            {
                //AlmacenaDatoPedidoVehiculo();
                MessageBox.Show("Se Guardo Correctamente la Información.", "Datos del Vehiculo");
                this.DialogResult = DialogResult.OK;    //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            if (gvAsiento.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Liquidacion de tarjetas ");
                return;
            }
            else
            {
                gcAsiento.ShowPrintPreview();
            }
        }




    }
}
 