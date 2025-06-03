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
using ApssaExactus.LIBCS;
using ApssaExactus.LIBVB;

namespace ApssaExactus
{
    public partial class frmBuscaArticulo : DevExpress.XtraEditors.XtraForm
    {
        //parametros entrada
        public string _articulo_in;
        public string _articulodescripcion_in;
        //parametros salida
        public string _articulo_out;
        public string _articulodescripcion_out;
        public string _unidad_out;

        public frmBuscaArticulo()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmBuscaArticulo m_FormDefInstance;

        /// Instancia por defecto
        public static frmBuscaArticulo DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmBuscaArticulo();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frmBuscaArticulo_Load(object sender, EventArgs e)
        {
            // inicializa param out
            _articulo_out="";
            _articulodescripcion_out="";

            // valores recibidos del form anterior frmEstadoCuentaCliente
            txtArticulo_Buscar.Text = _articulo_in;
            txtArticuloDescripcion_Buscar.Text =_articulodescripcion_in;

            // captura valores seleccionados en este form
            txtArticulo_Selecc.Text = string.Empty;
            txtArticuloDescripcion_Selecc.Text = string.Empty;
            txtUnidad_Selecc.Text = string.Empty;

            txtArticulo_Selecc.Enabled = false;
            txtArticuloDescripcion_Selecc.Enabled = false;
            txtUnidad_Selecc.Enabled = false;

            txtArticuloDescripcion_Buscar.Focus();

            ConfiguraGridArticulo();
            if (txtArticulo_Buscar.Text != "" || txtArticuloDescripcion_Buscar.Text != "")
            {
                CargaArticulos(_articulo_in, _articulodescripcion_in,Global.vUserBaseDatos);
            }
        }


        private void txtArticulo_Buscar_DoubleClick(object sender, EventArgs e)
        {
            CargaArticulos(txtArticulo_Buscar.Text, "", Global.vUserBaseDatos);
        }

        private void txtArticuloDescripcion_Buscar_DoubleClick(object sender, EventArgs e)
        {
            CargaArticulos("", txtArticuloDescripcion_Buscar.Text, Global.vUserBaseDatos);
        }

        private void txtArticulo_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    CargaArticulos(txtArticulo_Buscar.Text, "", Global.vUserBaseDatos);
                    break;
            }            
            
        }

        private void txtArticuloDescripcion_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    CargaArticulos("", txtArticuloDescripcion_Buscar.Text, Global.vUserBaseDatos);
                    break;
            } 
        }

        private void gvArticulo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _articulo_out = gvArticulo.GetRowCellValue(gvArticulo.FocusedRowHandle, "ARTICULO").ToString();
            _articulodescripcion_out = gvArticulo.GetRowCellValue(gvArticulo.FocusedRowHandle, "DESCRIPCION").ToString();
            _unidad_out = gvArticulo.GetRowCellValue(gvArticulo.FocusedRowHandle, "UNIDAD").ToString();

            txtArticulo_Selecc.Text = _articulo_out;
            txtArticuloDescripcion_Selecc.Text = _articulodescripcion_out;
        }

        private void gvArticulo_DoubleClick(object sender, EventArgs e)
        {
            //frmEstadoCuentaClientev3.vClienteSelecc = txtArticulo_Selecc.Text;
            //frmEstadoCuentaClientev3.vClienteNombreSelecc = txtArticuloDescripcion_Selecc.Text;
            //this.Close();
        }


        private void gcArticulo_DoubleClick(object sender, EventArgs e)
        {
            //frmEstadoCuentaClientev3.vClienteSelecc = txtArticulo_Selecc.Text;
            //frmEstadoCuentaClientev3.vClienteNombreSelecc = txtArticuloDescripcion_Selecc.Text;
            //this.Close();
        }






        #region RUTINAS

        public void CargaArticulos(string articulo_, string articulodescripcion_, string baseusuario)
        {
            EntidadesExactusBL objEntidadesExactusBL = new EntidadesExactusBL();

            DataTable dt = new DataTable();
            dt = objEntidadesExactusBL.dtBuscarArticuloBL(articulo_, articulodescripcion_, baseusuario);
            gcArticulo.DataSource = dt;
            ConfiguraGridArticulo();
        }

        public void ConfiguraGridArticulo()
        {
            gvArticulo.OptionsView.ColumnAutoWidth = false;
            gvArticulo.BestFitColumns();

            Font fnt = new Font(gvArticulo.Appearance.Row.Font.Name, 8);
            gvArticulo.Appearance.HeaderPanel.Font = fnt;
            gvArticulo.Appearance.Row.Font = fnt;
            gvArticulo.Appearance.Row.Options.UseFont = true;
            gvArticulo.OptionsView.ShowGroupPanel = false;
            //gvArticulo.OptionsView.ShowIndicator = false;

            gvArticulo.OptionsBehavior.Editable = false;
            gvArticulo.OptionsSelection.EnableAppearanceFocusedCell = false;
        }


        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ////frmEstadoCuentaClientev3.vClienteSelecc = txtArticulo_Selecc.Text;
            ////frmEstadoCuentaClientev3.vClienteNombreSelecc = txtArticuloDescripcion_Selecc.Text;
            //this.Close();


            Boolean TodoOK = true;

            if (TodoOK == false)
            {
                MessageBox.Show("Existe Información Errónea.", "Consulta Vendedores");
                return;
            }
            else
            {
                try
                {
                    txtArticulo_Selecc.Text = _articulo_out;
                    txtArticuloDescripcion_Selecc.Text = _articulodescripcion_out;
                    txtUnidad_Selecc.Text = _unidad_out;

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }

        public static bool VerificarDatosGrid(DevExpress.XtraGrid.Views.Grid.GridView gvArticulo)
        {
            if (gvArticulo.RowCount > 0)
                return true;
            else
                MessageBox.Show("No existe informacion a procesar");
            return false;
        }




    }
}

