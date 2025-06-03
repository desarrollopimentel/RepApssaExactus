using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;
using Exactus.BL;
using Exactus.BE;
using Exactus.LIBCS;
using Exactus.LIBVB;
using System.Threading.Tasks;
using System.Diagnostics;
using DevExpress.XtraGrid;

//using System.Data.SqlClient;



/* 
 * UPDATE : 07/12/2021
 * REMARKS: Kardex Apssa
*/


namespace Exactus.Win
{
    public partial class frm_ConsultaArticulos_Kardex_V2 : DevExpress.XtraEditors.XtraForm
    {
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        string sucursal = string.Empty;
        string zonas = string.Empty;

        public string articulo = string.Empty;
        public string bodega = string.Empty;
        public string nombre = string.Empty;
        public string stock = string.Empty;

        string tipobodega = string.Empty;
        string familia = string.Empty;
        string subfamilia = string.Empty;
        string grupo = string.Empty;

        string moneda = string.Empty;

        public ArticuloBE articulo_be = null;
        public DateTime var_fecha_ini { get; set; }
        public DateTime var_fecha_fin { get; set; }

        public frm_ConsultaArticulos_Kardex_V2()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frm_ConsultaArticulos_Kardex_V2 m_FormDefInstance;

        /// Instancia por defecto
        public static frm_ConsultaArticulos_Kardex_V2 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frm_ConsultaArticulos_Kardex_V2();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        /*
        DateTime? fechatemp = null;
        DateTime? fecha1 = null;
        DateTime? fecha2 = null;

        fechatemp = DateTime.Today;
        fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
        fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).
        */

        private void frm_ConsultaArticulos_Kardex_V2_Load(object sender, EventArgs e)
        {
            //setting
            articuloSelec.Visible = false;
            lblGridActivo.Visible = false;
            //xtraTabPageParametros.PageVisible = false;
            xtraTabPageParametros.PageEnabled = false;

            DateTime? fechatemp = null;
            DateTime? fecha1 = null;
            DateTime? fecha2 = null;
            fechatemp = DateTime.Today;

            if (fechatemp.Value.Month == 12)
            {
                fecha1 = new DateTime(fechatemp.Value.Year + 1, 0, 1);
                fecha2 = new DateTime(fechatemp.Value.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                fecha1 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 0, 1);
                fecha2 = new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
            }

            this.dpFechaIni.Text = Convert.ToString(fecha1);
            this.dpFechaFin.Text = Convert.ToString(fecha2);

            txtArticuloDescripcion.ReadOnly = false;
            txtArticuloUnidad.ReadOnly = true;
            lblGridActivo.Text = "";
            CargarParametros("ALMACEN", "CONSULTA_EXISTENCIAS_V2");
            //var_fecha_ini = Convert.ToDateTime("01/07/2022");
            //var_fecha_fin = DateTime.Today;

            var_fecha_ini = Convert.ToDateTime(fecha1); // Convert.ToDateTime("01/07/2022");
            var_fecha_fin = Convert.ToDateTime(fecha2); // DateTime.Today;

        }


        public void CargarParametros(string modulo, string aplicacion)
        {
            DataTable dtParametros = new DataTable();
            dtParametros = LogisticaBL.dtCargarParametrosKardex_BL(modulo, aplicacion, Global.vUserBaseDatos);
            gcParametros.DataSource = dtParametros;
            ConfiguraGrilla(gvParametros);
        }

        private void txtArticulo_Enter(object sender, EventArgs e)
        {
            //if ((txtArticulo.Text != null) && (txtArticulo.Text != ""))
            //{
            //    CargaDatosArticulo(txtArticulo.Text);
            //    txtArticuloDescripcion.Text = articulo_be.descripcion;
            //    txtArticuloUnidad.Text = articulo_be.unidad_almacen;
            //}
            //else
            //{
            //    MuestraFormBuscaArticulo();
            //}
        }

        private void txtArticulo_Leave(object sender, EventArgs e)
        {
            if ((txtArticulo.Text != null) && (txtArticulo.Text != ""))
            {
                CargaDatosArticulo(txtArticulo.Text);
                txtArticuloDescripcion.Text = articulo_be.descripcion;
                txtArticuloUnidad.Text = articulo_be.unidad_almacen;
            }
            else
            {
                MuestraFormBuscaArticulo();
            }
        }

        private void txtArticulo_DoubleClick(object sender, EventArgs e)
        {
            MuestraFormBuscaArticulo();
        }

        private void txtArticuloDescripcion_DoubleClick(object sender, EventArgs e)
        {
            MuestraFormBuscaArticulo();
        }


        public void MuestraFormBuscaArticulo()
        {
            frmBuscaArticulo frmBusca = new frmBuscaArticulo();
            frmBusca._articulo_in = txtArticulo.Text;
            frmBusca._articulodescripcion_in = txtArticuloDescripcion.Text;

            frmBusca.ShowDialog();
            if ((frmBusca._articulo_out != null) && (frmBusca._articulo_out != ""))
            {
                txtArticulo.Text = frmBusca._articulo_out;
                txtArticuloDescripcion.Text = frmBusca._articulodescripcion_out;
                txtArticuloUnidad.Text = frmBusca._unidad_out;
            }
            
        }

        private void btnProcesarXls_Click(object sender, EventArgs e)
        {
            if ((txtArticulo.Text == null) || (txtArticulo.Text == ""))
            {
                MessageBox.Show("Debe seleccionar un articulo!!");
                txtArticulo.Focus();
                return;
            }

            articulo = txtArticulo.Text;
            //@OPERACION VARCHAR(25)) -- EXISTENCIA, RESERVADO, TRANSITO, REMITIDO, KARDEX
            ObtenerArticuloExistencias(articulo);
        }

        private void gvExistencia_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            bodega = (DBNull.Value.Equals(gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "BODEGA"))) ? "" : (gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "BODEGA").ToString());
            nombre = (DBNull.Value.Equals(gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "NOMBRE"))) ? "" : (gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "NOMBRE").ToString());
            stock = (DBNull.Value.Equals(gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "STOCK"))) ? "" : (gvExistencia.GetRowCellValue(gvExistencia.FocusedRowHandle, "STOCK").ToString());

            lblBodega.Text = "Bodega: " + nombre.ToUpper();
            bodegaSelec.Text = bodega.ToUpper();
            articuloSelec.Text = txtArticulo.Text.ToUpper();
            StockSelect.Text = stock;

            //-------------------------------------------
            //this.dpFechaIni.Text = Convert.ToString(fecha1);
            //this.dpFechaFin.Text = Convert.ToString(fecha2);

            var_fecha_ini = Convert.ToDateTime(this.dpFechaIni.Text);    // Convert.ToDateTime(fecha1); // Convert.ToDateTime("01/07/2022");
            var_fecha_fin = Convert.ToDateTime(this.dpFechaFin.Text);    // Convert.ToDateTime(fecha2); // DateTime.Today;
            //-------------------------------------------

            if ((txtArticulo.Text != null) && (txtArticulo.Text != ""))
            {
                ObtenerArticuloReservados(txtArticulo.Text, bodega);
                ObtenerArticuloTransitos(txtArticulo.Text, bodega);
                ObtenerArticuloRemitidos(txtArticulo.Text, bodega);
                //ObtenerArticuloKardex(txtArticulo.Text, bodega);
                ObtenerArticuloKardexV2(txtArticulo.Text, bodega, var_fecha_ini, var_fecha_fin);
            }

        }



        public void ObtenerArticuloExistencias(string _art)
        {
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            //{
                DataTable dtExistencias = new DataTable();
                dtExistencias = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, "0099", "EXISTENCIA", Global.vUserBaseDatos);
                gcExistencia.DataSource = dtExistencias;
                ConfiguraGrilla(gvExistencia);
                ConfiguraGridExistencia(gvExistencia);
            //}
        }


        public void ObtenerArticuloReservados(string _art, string _bod)
        {
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            //{
                DataTable dtReservados = new DataTable();
                dtReservados = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "RESERVADO", Global.vUserBaseDatos);
                gcReservado.DataSource = dtReservados;
                ConfiguraGrilla(gvReservado);
            //}
        }

        public void ObtenerArticuloTransitos(string _art, string _bod)
        {
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            //{
                DataTable dtTransitos = new DataTable();
                dtTransitos = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "TRANSITO", Global.vUserBaseDatos);
                gcTransito.DataSource = dtTransitos;
                ConfiguraGrilla(gvTransito);
            //}
        }

        public void ObtenerArticuloRemitidos(string _art, string _bod)
        {
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            //{
                DataTable dtRemitidos = new DataTable();
                dtRemitidos = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "REMITIDO", Global.vUserBaseDatos);
                gcRemitido.DataSource = dtRemitidos;
                ConfiguraGrilla(gvRemitido);
            //}
        }

        public void ObtenerArticuloKardex(string _art, string _bod)
        {
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            //{
                DataTable dtKardex = new DataTable();
                dtKardex = LogisticaBL.dtObtenerArticuloExistencias_BL(_art, _bod, "KARDEX", Global.vUserBaseDatos);
                gcKardex.DataSource = dtKardex;
                ConfiguraGrilla(gvKardex);
            //}
        }


        public void ObtenerArticuloKardexV2(string _art, string _bod, DateTime fecha_ini, DateTime fecha_fin)
        {
            //using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            //{
            DataTable dtKardex = new DataTable();
            dtKardex = LogisticaBL.dtObtenerArticuloExistenciasV2_BL(_art, _bod, "KARDEX", fecha_ini, fecha_fin, Global.vUserBaseDatos);
            gcKardex.DataSource = dtKardex;
            ConfiguraGrilla(gvKardex);
            //}
        }

        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            string varAplicacionDescripcion = "";
            if (gvKardex.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", varAplicacionDescripcion + " -- > ERP Exactus");
                return;
            }
            else
            {
                gcKardex.ShowPrintPreview();
            }
        }



        #region RUTINAS_VARIOS

        //public void ConfiguraGridKardex()
        //public void ConfiguraGrilla(DevExpress.XtraGrid.Views.Grid.GridView gv)
        public void ConfiguraGridExistencia(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            //gvKardex.Appearance.Row.Font = new System.Drawing.Font(gvKardex.Appearance.Row.Font, FontStyle.Bold);
            //gvKardex.Appearance.Row.Options.UseFont = true;
            //System.Drawing.Font fnt = new System.Drawing.Font(gvKardex.Appearance.Row.Font.Name, 7);
            //gvKardex.Appearance.HeaderPanel.Font = fnt;
            //gvKardex.Appearance.Row.Font = fnt;
            //gvKardex.OptionsView.ShowGroupPanel = false;
            //gvKardex.OptionsView.ColumnAutoWidth = false;
            //gvKardex.BestFitColumns();

            if (gv.RowCount > 0)
            {
                //// COLOR
                gv.Columns["BODEGA"].AppearanceCell.BackColor = Color.LightGray;
                gv.Columns["NOMBRE"].AppearanceCell.BackColor = Color.LightGray;
                gv.Columns["DISPONIBLE"].AppearanceCell.BackColor = Color.Bisque;
                gv.Columns["RESERVADO"].AppearanceCell.BackColor = Color.Bisque;
                gv.Columns["REMITIDO"].AppearanceCell.BackColor = Color.Bisque;
                gv.Columns["STOCK"].AppearanceCell.BackColor = Color.Bisque;

                //gvKardex.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
                //gvKardex.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;

            }


            ////formateo
            //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["CANTIDAD"].DisplayFormat.FormatString = "##,###,###,##0.00";
            //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["COSTO_UNITARIO_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
            //gvKardex.Columns["COSTO_TOTAL_LOCAL"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["COSTO_UNITARIO_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;      //IMPUESTO1
            //gvKardex.Columns["COSTO_TOTAL_DOLAR"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["TIPO_CAMBIO"].DisplayFormat.FormatString = "##,###,###,##0.00000";
            //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gvKardex.Columns["AUDIT_TRANS_INV"].DisplayFormat.FormatString = "##,###,###,##0";
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

        //public void Carga_lookUp_Bodega(string ctipobodega)
        //{
        //    DataTable dt_bo = new DataTable();
        //    dt_bo = Listado_MaestrosBL.Listar_Bodega(ctipobodega, Global.vUserBaseDatos).Tables[0];
        //    lookUpBodega.Properties.DataSource = dt_bo;
        //    lookUpBodega.Properties.DisplayMember = "NOMBRE";
        //    lookUpBodega.Properties.ValueMember = "BODEGA";
        //    lookUpBodega.EditValue = null;
        //}


        //public void Carga_lookUp_Familia(string ctipofamilia)
        //{
        //    DataTable dt_fa = new DataTable();
        //    dt_fa = Listado_MaestrosBL.Listar_Familia(Global.vUserBaseDatos).Tables[0];    //CLASIFICACION,DESCRIPCION
        //    lookUpFamilia.Properties.DataSource = dt_fa;
        //    lookUpFamilia.Properties.DisplayMember = "DESCRIPCION";
        //    lookUpFamilia.Properties.ValueMember = "CLASIFICACION";
        //    lookUpFamilia.EditValue = null;
        //}


        #endregion









        public void MuestraFormularioBusquedaArticulos(string art, string bd)
        {
            frmBusca_Articulo frmArt = new frmBusca_Articulo();
            frmArt.familia = null;
            frmArt.subfamilia = null;
            frmArt.grupo = null;
            frmArt._articulo = txtArticulo.Text;
            frmArt.ShowDialog();
            if (frmArt.DialogResult == DialogResult.OK)
            {
                //txtArticulo.Text = frmArt._vendedor_selecc;
                //txtArticulo_Nombre.Text = frmArt._vendedor_nombre_selecc;
            }
            else
            {
                //MessageBox.Show("Vuelva a intentar....");  // TODO numero de intentos
            }
        }

        public void CargaDatosArticulo(string vendedorOK)
        {
            if (articulo_be == null)
                articulo_be = new ArticuloBE();
            DataTable dtArt = new DataTable();
            dtArt = ComercialBL.CargaDatosArticuloBL(vendedorOK, Global.vUserBaseDatos);
            DataTableReader lectoruser = dtArt.CreateDataReader();
            while (lectoruser.Read())
            {
                articulo_be.articulo = lectoruser[0].ToString();
                articulo_be.descripcion = lectoruser[1].ToString();
                articulo_be.unidad_almacen = lectoruser[2].ToString();
            }
        }

        private void gcExistencia_Click(object sender, EventArgs e)
        {
            lblGridActivo.Text = "gcExistencia";
        }

        private void xtraTabDetalle_Click(object sender, EventArgs e)
        {
            switch (xtraTabDetalle.SelectedTabPage.Text)
            {
                case "Reservado":
                    lblGridActivo.Text = "gcReservado";
                    break;
                case "Transito":
                    lblGridActivo.Text = "gcTransito";
                    break;
                case "Remitido":
                    lblGridActivo.Text = "gcRemitido";
                    break;
                case "Kardex":
                    lblGridActivo.Text = "gcKardex";
                    break;
                default:
                    lblGridActivo.Text = "gcKardex";    //"gcExistencia";
                    break;
            }

        }

        private void btnExportarXls_Click_1(object sender, EventArgs e)
        {
            //ExportarGrid(gcVenta, gvVenta);

            switch (lblGridActivo.Text)
            {
                case "gcReservado":
                    //lblGridActivo.Text = "gcReservado";
                    ExportarGrid(gcReservado, gvReservado);
                    break;
                case "gcTransito":
                    //lblGridActivo.Text = "gcTransito";
                    ExportarGrid(gcTransito, gvTransito);
                    break;
                case "gcRemitido":
                    //lblGridActivo.Text = "gcRemitido";
                    ExportarGrid(gcRemitido, gvRemitido);
                    break;
                case "gcKardex":
                    //lblGridActivo.Text = "gcKardex";
                    ExportarGrid(gcKardex, gvKardex);
                    break;
                default:
                    //lblGridActivo.Text = "gcExistencia";
                    ExportarGrid(gcExistencia, gvExistencia);
                    break;
            }
        }

        public void ExportarGrid(GridControl control, DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            if (gv.DataRowCount > 0)
            {
                control.ShowPrintPreview();
            }
            else
            {
                MessageBox.Show("No hay informacion que Exportar");
            }
        }

        private void gvReservado_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            lblGridActivo.Text = "gcReservado";
        }

        private void gvTransito_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            lblGridActivo.Text = "gcTransito";
        }

        private void gvRemitido_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            lblGridActivo.Text = "gcRemitido";
        }

        private void gvKardex_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            lblGridActivo.Text = "gcKardex";
        }

        private void gvParametros_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }




    }
}
