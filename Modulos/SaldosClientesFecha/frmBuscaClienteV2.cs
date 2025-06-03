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
    public partial class frmBuscaClienteV2 : DevExpress.XtraEditors.XtraForm
    {
        //parametros entrada
        public bool _Origen_PDF;
        public string _cliente;
        public string _clientenombre;
        public bool _Origen_FacDev;

        //parametros salida
        public string _cliente_out;
        public string _clientenombre_out;

        public frmBuscaClienteV2()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmBuscaClienteV2 m_FormDefInstance;

        /// Instancia por defecto
        public static frmBuscaClienteV2 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmBuscaClienteV2();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frmBuscaClienteV2_Load(object sender, EventArgs e)
        {
            // inicializa param out
            _cliente_out="";
            _clientenombre_out="";

            // valores recibidos del form anterior frmEstadoCuentaCliente
            txtCliente.Text = _cliente;
            txtClienteNombre.Text =_clientenombre;

            // captura valores seleccionados en este form
            txtCliente_Selecc.Text = string.Empty;
            txtClienteNombre_Selecc.Text = string.Empty;

            txtCliente_Selecc.Enabled = false;
            txtClienteNombre_Selecc.Enabled = false;

            //this.txtCliente.Properties.Mask.EditMask = "\\p{Lu}+";
            //this.txtCliente.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            //this.txtClienteNombre.Properties.Mask.EditMask = "\\p{Lu}+";
            //this.txtClienteNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

            txtClienteNombre.Focus();

            ConfiguraGridCliente();
            if (txtCliente.Text != "" || txtClienteNombre.Text != "")
            {
                CargaClientes(_cliente, _clientenombre,Global.vUserBaseDatos);
            }
        }


        private void txtCliente_DoubleClick(object sender, EventArgs e)
        {
            CargaClientes(txtCliente.Text, "", Global.vUserBaseDatos);
        }

        private void txtClienteNombre_DoubleClick(object sender, EventArgs e)
        {
            CargaClientes("", txtClienteNombre.Text, Global.vUserBaseDatos);
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    CargaClientes(txtCliente.Text, "", Global.vUserBaseDatos);
                    break;
            }            
            
        }

        private void txtClienteNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    CargaClientes("", txtClienteNombre.Text, Global.vUserBaseDatos);
                    break;
            } 
        }





        private void gvCliente_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtCliente_Selecc.Text = gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "CLIENTE").ToString();
            //txtClienteNombre_Selecc.Text = gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "NOMBRE").ToString();
            _cliente_out = gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "CLIENTE").ToString();
            _clientenombre_out = gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "NOMBRE").ToString();
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            //frmEstadoCuentaClientev3.vClienteSelecc = txtCliente_Selecc.Text;
            //frmEstadoCuentaClientev3.vClienteNombreSelecc = txtClienteNombre_Selecc.Text;
            this.Close();
        }


        private void gcCliente_DoubleClick(object sender, EventArgs e)
        {
            //frmEstadoCuentaClientev3.vClienteSelecc = txtCliente_Selecc.Text;
            //frmEstadoCuentaClientev3.vClienteNombreSelecc = txtClienteNombre_Selecc.Text;
            this.Close();
        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //frmEstadoCuentaClientev3.vClienteSelecc = txtCliente_Selecc.Text;
            //frmEstadoCuentaClientev3.vClienteNombreSelecc = txtClienteNombre_Selecc.Text;
            this.Close();
        }



        #region RUTINAS

        public void CargaClientes(string cliente_, string clientenombre_, string baseusuario)
        {
            EntidadesExactusBL objEntidadesExactusBL = new EntidadesExactusBL();

            DataTable dt = new DataTable();
            dt = objEntidadesExactusBL.dtBuscarClienteBL(cliente_, clientenombre_, baseusuario);
            gcCliente.DataSource = dt;
            ConfiguraGridCliente();
        }

        public void ConfiguraGridCliente()
        {
            gvCliente.OptionsView.ColumnAutoWidth = false;
            gvCliente.BestFitColumns();

            Font fnt = new Font(gvCliente.Appearance.Row.Font.Name, 8);
            gvCliente.Appearance.HeaderPanel.Font = fnt;
            gvCliente.Appearance.Row.Font = fnt;
            gvCliente.Appearance.Row.Options.UseFont = true;
            gvCliente.OptionsView.ShowGroupPanel = false;
            //gvCliente.OptionsView.ShowIndicator = false;

            gvCliente.OptionsBehavior.Editable = false;
            gvCliente.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        #endregion


    }
}

