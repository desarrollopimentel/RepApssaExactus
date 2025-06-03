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
    public partial class frmClienteIndicadorDetalle : DevExpress.XtraEditors.XtraForm
    {
        //public string _zona = string.Empty;                 // default : Empty
        //public string _zona_nombre = string.Empty;
        //public string _vendedor = string.Empty;
        //public string _vendedor_nombre = string.Empty;
        //public string _activo = string.Empty;               // default : S  
        //public string _cliente = string.Empty;              // default : Empty
        //public string _cliente_nombre = string.Empty;       // default : Empty
        //public string _zona_selecc = string.Empty;
        //public string _vendedor_selecc = string.Empty;
        //public string _activo_selecc = string.Empty;
        //public string _cliente_selecc = string.Empty;
        //public string _cliente_nombre_selecc = string.Empty;
        //CargaLookUpBL objCargaLookUpBL = new CargaLookUpBL();        

        public bool _primera_vez = true;

        public Int32 ejercicio = 0;
        public Int32 mes = 0;
        public string mes_descripcion = string.Empty;
        public string cliente = string.Empty;
        public string razon_social = string.Empty;

        private Int32 _ejercicio = 0;
        private Int32 _mes = 0;
        private string _mes_descripcion = string.Empty;
        private string _cliente = string.Empty;
        private string _razon_social = string.Empty;

        public frmClienteIndicadorDetalle()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmClienteIndicadorDetalle m_FormDefInstance;

        /// Instancia por defecto
        public static frmClienteIndicadorDetalle DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmClienteIndicadorDetalle();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frmClienteIndicadorDetalle_Load(object sender, EventArgs e)
        {
            _primera_vez = true;
            _ejercicio = ejercicio;
            _mes = mes;
            _cliente = cliente;
            _razon_social = razon_social;

            txtCobCliente.Text = cliente;
            txtCobClienteNombre.Text = razon_social;
            txtCobEjercicio.Text = ejercicio.ToString();
            txtCobMes.Text = mes_descripcion;

            txtCobCliente.ReadOnly = true;
            txtCobClienteNombre.ReadOnly = true;
            txtCobEjercicio.ReadOnly = true;
            txtCobMes.ReadOnly = true;

            //ObtenerClienteDetalleCobranza(_cliente, _ejercicio, _mes, Global.vUserBaseDatos);
            ObtenerClienteDetalleCobranza(_ejercicio, _mes, _cliente);

            _primera_vez = false;    
        }


        private void btnActualizaClientes_Click(object sender, EventArgs e)
        {
            if (_primera_vez == false)
            {
                //switch (lookUpActivo.Text)
                //{
                //    case "Ambos":
                //        _activo_selecc = "";
                //        break;
                //    case "Si":
                //        _activo_selecc = "S";
                //        break;
                //    case "No":
                //        _activo_selecc = "N";
                //        break;
                //    default:
                //        _activo_selecc = "S";
                //        break;
                //}
            }

            //ObtenerClientes(_zona_selecc, _activo_selecc, _vendedor_selecc, "", Global.vUserBaseDatos);
            ObtenerClienteDetalleCobranza(_ejercicio, _mes, _cliente);
        }





        public void ObtenerClienteDetalleCobranza(Int32 ejerc, Int32 mes, string clie)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtCliente = new DataTable();
                //dtObtenerClienteDetalleCobranzaBL(Int32 _ejercicio, string _mes, string _cliente, string db)
                dtCliente = CreditosBL.dtObtenerClienteDetalleCobranzaBL(ejerc, mes, clie, Global.vUserBaseDatos);
                gcCliente.DataSource = dtCliente;
            }

            ConfiguraGridCliente();
            gcCliente.Refresh();
        }


        public void ConfiguraGridCliente()
        {
            //gvCliente.OptionsView.ColumnAutoWidth = true;
            //Font fnt = new Font(gvCliente.Appearance.Row.Font.Name, 7);
            //gvCliente.Appearance.HeaderPanel.Font = fnt;
            //gvCliente.Appearance.Row.Font = fnt;
            //gvCliente.Appearance.Row.Options.UseFont = true;
            //gvCliente.OptionsView.ShowGroupPanel = false;
            //gvCliente.OptionsView.ShowIndicator = false;
            //gvCliente.OptionsBehavior.Editable = false;
            //gvCliente.OptionsSelection.EnableAppearanceFocusedCell = false;
            ConfiguraGrilla(gvCliente);
            // COLOR
            gvCliente.Columns["CLIENTE"].AppearanceCell.BackColor = Color.Azure;
            gvCliente.Columns["CONDICION_PAGO"].AppearanceCell.BackColor = Color.Azure;
            gvCliente.Columns["FORMA_ABONO"].AppearanceCell.BackColor = Color.Azure;
            gvCliente.Columns["DIAS_MORA"].AppearanceCell.BackColor = Color.Azure;
            gvCliente.Columns["ABONO_SOLES"].AppearanceCell.BackColor = Color.Azure;
            gvCliente.Columns["FACTOR"].AppearanceCell.BackColor = Color.Azure;
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

        private void btnExportarDetalle_Click(object sender, EventArgs e)
        {
            if (gvCliente.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Cobranza Detalle - Cliente.");
                return;
            }
            else
            {
                gcCliente.ShowPrintPreview();
            }
        }





    }
}