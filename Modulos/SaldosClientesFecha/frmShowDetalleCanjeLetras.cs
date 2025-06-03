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
    public partial class frmShowDetalleCanjeLetras : DevExpress.XtraEditors.XtraForm
    {
        public string cliente = string.Empty;               // default : Empty
        public string cliente_nombre = string.Empty;        // default : Empty
        public string tipo_canje = string.Empty;            // default : Empty
        public string documento_canje = string.Empty;       // default : Empty


        public bool _primera_vez = true;
        public DataTable dtDetalles = new DataTable();

        public frmShowDetalleCanjeLetras()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmShowDetalleCanjeLetras m_FormDefInstance;

        /// Instancia por defecto
        public static frmShowDetalleCanjeLetras DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmShowDetalleCanjeLetras();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frmShowDetalleCanjeLetras_Load(object sender, EventArgs e)
        {
            _primera_vez = true;

            txtCliente.Text = cliente;
            txtClienteNombre.Text = cliente_nombre;
            txtTipoCanje.Text = tipo_canje;
            txtDocumentoCanje.Text = documento_canje;
            txtCliente.ReadOnly = true;
            txtClienteNombre.ReadOnly = true;
            txtTipoCanje.ReadOnly = true;
            txtDocumentoCanje.ReadOnly = true;

            ObtenerDetalleCanje(tipo_canje, documento_canje);

            _primera_vez = false;    
        }

        public void ObtenerDetalleCanje(string _tipo_canje, string _documento_canje)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                dtDetalles.Clear();
                dtDetalles = CreditosBL.dtDetalleCanjeLetraBL(_tipo_canje, _documento_canje, Global.vUserBaseDatos);
                gcDetalles.DataSource = dtDetalles;
            }

            gcDetalles.Refresh();
            ConfiguraGrilla(gvDetalles);
        }



        private void btnActualizaClientes_Click(object sender, EventArgs e)
        {
            ObtenerDetalleCanje(txtTipoCanje.Text, txtDocumentoCanje.Text);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Boolean TodoOK = true;

            if (TodoOK == false)
            {
                MessageBox.Show("Existe Información Errónea.", "Consulta Canjes");
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

        

    }

}