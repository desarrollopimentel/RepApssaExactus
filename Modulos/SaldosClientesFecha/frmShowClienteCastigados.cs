using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Reporting.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Controls;
//using Exactus.BL;
//using Exactus.BE;


namespace ApssaExactus
{
    public partial class frmShowClienteCastigados : DevExpress.XtraEditors.XtraForm
    {
        public string _cliente = string.Empty;              // default : Empty
        public string _cliente_nombre = string.Empty;       // default : Empty


        public bool _primera_vez = true;
        public DataTable dtCastigo = new DataTable();

        public frmShowClienteCastigados()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmShowClienteCastigados m_FormDefInstance;

        /// Instancia por defecto
        public static frmShowClienteCastigados DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmShowClienteCastigados();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frmShowClienteCastigados_Load(object sender, EventArgs e)
        {
            _primera_vez = true;

            txtCliente.Text = _cliente;
            txtClienteNombre.Text = _cliente_nombre;

            txtCliente.ReadOnly = true;
            txtClienteNombre.ReadOnly = true;
            txtProvSoles.ReadOnly = true;
            txtProvDolar.ReadOnly = true;
            txtCastSoles.ReadOnly = true;
            txtCastDolar.ReadOnly = true;
            txtDespSoles.ReadOnly = true;
            txtDespDolar.ReadOnly = true;            

            ObtenerDocumentoClienteCastigado(_cliente);
            TotalizarClienteCastigado(_cliente);

            _primera_vez = false;    
        }





        private void btnActualizaClientes_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoClienteCastigado(_cliente);
            TotalizarClienteCastigado(_cliente);

        }



        public void ObtenerDocumentoClienteCastigado(string cliente_)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                //DataTable dtCastigo = new DataTable();
                dtCastigo.Clear();
                dtCastigo = CreditosBL.dtEsClienteCastigadoBL(cliente_, "CA, PR, DP", Global.vUserBaseDatos);
                gcCliente.DataSource = dtCastigo;
            }

            ConfiguraGridCliente();
            gcCliente.Refresh();
        }


        public void TotalizarClienteCastigado(string cliente)
        {
            //"CA, PR, DP",
            double sumProvLocal = 0;
            double sumProvDolar = 0;
            double sumCastLocal = 0;
            double sumCastDolar = 0;
            double sumDespLocal = 0;
            double sumDespDolar = 0;

            for (int i = 0; i < dtCastigo.Rows.Count; i++)
            {
                // acumula saldo cliente
                if (dtCastigo.Rows[i]["ESTADO"].ToString() == "PR")
                {
                    sumProvLocal += Convert.ToDouble(dtCastigo.Rows[i]["PROVISION_LOCAL"].ToString());
                    sumProvDolar += Convert.ToDouble(dtCastigo.Rows[i]["PROVISION_DOLAR"].ToString());
                }

                if (dtCastigo.Rows[i]["ESTADO"].ToString() == "CA")
                {
                    sumCastLocal += Convert.ToDouble(dtCastigo.Rows[i]["PROVISION_LOCAL"].ToString());
                    sumCastDolar += Convert.ToDouble(dtCastigo.Rows[i]["PROVISION_DOLAR"].ToString());
                }

                if (dtCastigo.Rows[i]["ESTADO"].ToString() == "DP")
                {
                    sumDespLocal += Convert.ToDouble(dtCastigo.Rows[i]["PROVISION_LOCAL"].ToString());
                    sumDespDolar += Convert.ToDouble(dtCastigo.Rows[i]["PROVISION_DOLAR"].ToString());
                }

                txtProvSoles.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumProvLocal));
                txtProvDolar.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumProvDolar));
                txtCastSoles.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumCastLocal));
                txtCastDolar.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumCastDolar));
                txtDespSoles.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumDespLocal));
                txtDespDolar.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(sumDespDolar));

            }

        }


        public void ConfiguraGridCliente()
        {
            ConfiguraGrilla(gvCliente);
            // COLOR
            gvCliente.Columns["CLIENTE"].AppearanceCell.BackColor = Color.Azure;
            gvCliente.Columns["NOMBRE"].AppearanceCell.BackColor = Color.Azure;

            gvCliente.Columns["PROVISION_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvCliente.Columns["PROVISION_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvCliente.Columns["PROVISION_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvCliente.Columns["PROVISION_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";

            gvCliente.Columns["SALDO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvCliente.Columns["SALDO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gvCliente.Columns["SALDO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvCliente.Columns["SALDO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00";
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

        private void gvCliente_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //_cliente_selecc = gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "CLIENTE").ToString();
            //_cliente_nombre_selecc = gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "NOMBRE").ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Boolean TodoOK = true;

            if (TodoOK == false)
            {
                MessageBox.Show("Existe Información Errónea.", "Consulta Clientes");
                return;
            }
            else
            {
                try
                {
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnExportarHistorico_Click(object sender, EventArgs e)
        {
            if (gvCliente.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Clientes Castigados");
                return;
            }
            else
            {
                gcCliente.ShowPrintPreview();
            }
        }


    }
}