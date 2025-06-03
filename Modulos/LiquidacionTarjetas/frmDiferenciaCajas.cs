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

/*
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using Exactus.BL;
using Exactus.BE;
using Exactus.LIBCS;
using Excel = Microsoft.Office.Interop.Excel;
*/


namespace ApssaExactus
{
    public partial class frmDiferenciaCajas : DevExpress.XtraEditors.XtraForm
    {
        //public string HojaXls = null;
        //public string tipo_carga = string.Empty;    // "Excel", "Modificacion"
        //public Boolean PrimeraVez = true;
        //public string ItemFactSeleccionado = string.Empty;       // archivo seleccionado en gvFactura
        //public string cTabXls = null;
        //public string _articulo_cuenta = string.Empty;
        //public Boolean ProcesarTodos = false;
        //public string exactus_tipo_documento = string.Empty;
        //public string exactus_tipo_referencia = string.Empty;

        ////leer PDF
        //string stringPdfFile = string.Empty;
        //string stringPdfOutput = string.Empty;

        //// EXCEL
        //DateTime _FECHA;
        //string _TIPO = "";
        //string _DOCUMENTO = "";
        //string _MONEDA = "";
        //Decimal _SOLES = 0;
        //Decimal _DOLARES = 0;

        //public DataTable dtNC = new DataTable();    // Notas Credito
        //public DataTable dtFA = new DataTable();    //Facturas

        //public DocumentoCP_BE documento_cp_be = null;

        //public string _documento_cp = "";
        //public string _proveedor = "";
        //public DateTime _fecha;
        //public string _tipo = "";
        //public string _documento = "";
        //public string _moneda = "";
        //public Decimal _monto = 0;
        //public Decimal _soles = 0;
        //public Decimal _dolares = 0;



        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        public string cajas = "";

        CargaLookUpBL objCargaLookUpBL = new CargaLookUpBL();

        public frmDiferenciaCajas()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmDiferenciaCajas m_FormDefInstance;

        /// Instancia por defecto
        public static frmDiferenciaCajas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmDiferenciaCajas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------

        private void frmDiferenciaCajas_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);
            var endDate = DateTime.Today.ToString(); 

            this.dpFechaIni.Text = startDate.ToString();
            this.dpFechaFin.Text = endDate.ToString();

            
            //CargaGrillaVacia();
            //CargaGrillaVaciaOtros();
            //cTabXls = "Carga";
            chkFacturas.CheckState = CheckState.Unchecked;

            lookUpEditCaja.Enabled = false;

            Carga_lookUp_Caja();
        }


        #region DIFERENCIAS-CAJAS

        private void btnDiferenciasConsultar_Click(object sender, EventArgs e)
        {

            dFechaIni = Convert.ToDateTime(this.dpFechaIni.Text);  //Convert.ToDateTime("01/10/2014"); //
            dFechaFin = Convert.ToDateTime(this.dpFechaFin.Text);  //Convert.ToDateTime("18/12/2014"); // 
            cajas = null;
            //cajas = this.lookUpEditCaja.EditValue.ToString();

            ////caja = Global.vUserTienda;
            //if (cajas == null)
            //{
            //    cajas = Global.vUserCaja;
            //}

            ObtenerDiferencias();
        }

        public void ObtenerDiferencias()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtDiferencias = new DataTable();
                dtDiferencias = TesoreriaBL.dtDiferenciaCajas_BL(dFechaIni, dFechaFin, cajas, Global.vUserBaseDatos);
                gcDiferencias.DataSource = dtDiferencias;
                ConfiguraGrilla(gvDiferencias);
            }
        }

        private void btnDiferenciasCorregir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Cajas - Diferencias"
                                                       + "\n"
                                                       + "\nEsta seguro de corregir las Diferencias?", "Cajas - Diferencias.", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    ProcesarCajas();
                    MessageBox.Show("Proceso Finalizado !!!", "Cajas - Diferencias.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ProcesarCajas()
        {
            DateTime _FECHA;
            string _CAJA = "";
            Decimal _SOLES = 0;
            Decimal _DOLAR = 0;
            Decimal _SALDO_FINAL_LOC = 0;
            Decimal _SALDO_FINAL_DOL = 0;
            string _FLAG = "";
            int _NUMERO = 0;

            //procesa facturas
            int[] seleccionados;
            seleccionados = gvDiferencias.GetSelectedRows();

            if (seleccionados.GetLength(0) > 0)
            {
                using (WaitDialogForm waitDialog = new WaitDialogForm("corrigiendo las Diferencias", "Espere por favor.."))
                {
                    DataRow rowxls;

                    foreach (int row in seleccionados)
                    {
                        rowxls = gvDiferencias.GetDataRow(row);

                        if ((rowxls["CAJA"] != null) && (rowxls["CAJA"].ToString() != ""))
                        {
                            if ((rowxls["CAJA"] != null) && (rowxls["CAJA"].ToString() != ""))
                            {
                                //_FECHA = (DBNull.Value.Equals(rowxls["FECHA"])) ? null : Convert.ToDateTime((rowxls["FECHA"]));
                                _FECHA = Convert.ToDateTime(rowxls["FECHA"]);
                                _CAJA = (DBNull.Value.Equals(rowxls["CAJA"])) ? String.Empty : rowxls["CAJA"].ToString();
                                _SOLES = (DBNull.Value.Equals(rowxls["SOLES"])) ? 0 : Convert.ToDecimal(rowxls["SOLES"].ToString());
                                _DOLAR = (DBNull.Value.Equals(rowxls["DOLAR"])) ? 0 : Convert.ToDecimal(rowxls["DOLAR"].ToString());
                                _SALDO_FINAL_LOC = (DBNull.Value.Equals(rowxls["SALDO_FINAL_LOC"])) ? 0 : Convert.ToDecimal(rowxls["SALDO_FINAL_LOC"].ToString());
                                _SALDO_FINAL_DOL = (DBNull.Value.Equals(rowxls["SALDO_FINAL_DOL"])) ? 0 : Convert.ToDecimal(rowxls["SALDO_FINAL_DOL"].ToString());
                                _FLAG = (DBNull.Value.Equals(rowxls["FLAG"])) ? String.Empty : rowxls["FLAG"].ToString();
                                _NUMERO = (DBNull.Value.Equals(rowxls["NUMERO"])) ? 0 : Convert.ToInt16(rowxls["NUMERO"].ToString());

                                TesoreriaBL.CorregirCaja_BL(_FECHA, _CAJA, _SOLES, _DOLAR, _SALDO_FINAL_LOC, _SALDO_FINAL_DOL, _FLAG, _NUMERO, Global.vUserBaseDatos);
                            }

                        }

                    }

                }

                MessageBox.Show("Se proceso todos los registros del archivo Excel", "Carga Excel Facturas Proveedores");

            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Carga Excel Facturas Proveedores");
            }

        }





        private void btnDiferenciasExportar_Click(object sender, EventArgs e)
        {
            if (gvDiferencias.RowCount <= 0)
            {
                MessageBox.Show("No existe Informacion a Exportar.", "Documentos GY Pendiente de Aplicacion");
                return;
            }
            else
            {
                gcDiferencias.ShowPrintPreview();
            }
        }

        public void ConfiguraGridExcel()
        {
            gvDiferencias.Appearance.Row.Font = new System.Drawing.Font(gvDiferencias.Appearance.Row.Font, FontStyle.Bold);
            gvDiferencias.Appearance.Row.Options.UseFont = true;
            System.Drawing.Font fnt = new System.Drawing.Font(gvDiferencias.Appearance.Row.Font.Name, 7);
            gvDiferencias.Appearance.HeaderPanel.Font = fnt;
            gvDiferencias.Appearance.Row.Font = fnt;
            gvDiferencias.OptionsView.ShowGroupPanel = false;
            gvDiferencias.OptionsView.ColumnAutoWidth = false;
            gvDiferencias.BestFitColumns();

            // COLOR
            //gvDiferencias.Columns["DOCUMENTO"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["FECHA"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["SOLES"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["DOLARES"].AppearanceCell.BackColor = Color.Bisque;

            ////gvDiferencias.Columns["PROCESAR"].AppearanceCell.BackColor = Color.Azure;
            //gvDiferencias.Columns["PROVEEDOR"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["TIPO"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["FECHA_DOC"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["SUBTOTAL"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["IMPUESTO1"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["MONTO"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["MONEDA"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["CONDICION_PAGO"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["FECHA_VENCE"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["EMBARQUE"].AppearanceCell.BackColor = Color.Bisque;
            //gvDiferencias.Columns["RETENCIONES"].AppearanceCell.BackColor = Color.Bisque;
            ////gvDiferencias.Columns["VALIDACION"].AppearanceCell.BackColor = Color.Azure;
            //gvDiferencias.Columns["VALIDACION"].AppearanceCell.ForeColor = Color.Red;

        }

        #endregion





        #region RUTINAS_VARIOS

        public void Carga_lookUp_Caja()
        {
            DataTable dtCaja = new DataTable();
            dtCaja = objCargaLookUpBL.dtListarCajaBL(Global.vUserBaseDatos);
            lookUpEditCaja.Properties.DataSource = dtCaja;
            lookUpEditCaja.Properties.DisplayMember = "DESCRIPCION";
            lookUpEditCaja.Properties.ValueMember = "CAJA";
            lookUpEditCaja.EditValue = null;
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

        #endregion



    }

}
//EOF