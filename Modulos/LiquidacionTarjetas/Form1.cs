using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace ApssaExactus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            CargarGilla();
            // Subscribe to the SelectionChanged event
            gridView1.SelectionChanged += gridView1_SelectionChanged;
        }


        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal subtotal = 0m;
            decimal impuesto = 0m;
            decimal total = 0m;

            // Get the selected rows
            int[] selectedRowHandles = gridView1.GetSelectedRows();

            // Loop through selected rows and accumulate the values
            foreach (int rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0) // Ensure the row handle is valid
                {
                    // Get the values from the SUBTOTAL, IMPUESTO, and TOTAL columns
                    subtotal += Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle, "SUBTOTAL"));
                    impuesto += Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle, "IMPUESTO"));
                    total += Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle, "TOTAL"));
                }
            }

            // Update the TextBox controls with the calculated totals
            txtSubTotal.Text = subtotal.ToString("N2"); // Format with 2 decimal places
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }

        private void CargarGilla()
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion de los abonos ....", "Espere por favor.."))
            {
                DataTable dtAbonos = new DataTable();
                dtAbonos = dtObtienerDatos_BL("APSSA_OS");
                gridControl1.DataSource = dtAbonos;
            }

            ConfiguraGrilla();

        }


        public void ConfiguraGrilla()
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            System.Drawing.Font fnt = new System.Drawing.Font(gridView1.Appearance.Row.Font.Name, 7);
            gridView1.Appearance.HeaderPanel.Font = fnt;
            gridView1.Appearance.Row.Font = fnt;
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsBehavior.Editable = true;  //false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;

            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;

            gridView1.Columns["NOMBRE_CLIENTE"].Width = 300;

            gridView1.Columns["SUBTOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["SUBTOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gridView1.Columns["IMPUESTO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["IMPUESTO"].DisplayFormat.FormatString = "##,###,###,##0.00";
            gridView1.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["TOTAL"].DisplayFormat.FormatString = "##,###,###,##0.00";
        }

        public static DataTable dtObtienerDatos_BL( string db)
        {
            return dtObtienerDatos_DL(db);
        }

        public static DataTable dtObtienerDatos_DL(string db)
        {

            string strSql = @"  SELECT
                                FECHA_PEDIDO,PEDIDO,CLIENTE,NOMBRE_CLIENTE,
                                TOTAL_MERCADERIA AS SUBTOTAL,
                                TOTAL_IMPUESTO1 AS IMPUESTO,
                                TOTAL_A_FACTURAR AS TOTAL
				                FROM PEDIDO (NOLOCK) ";

            return SqlHelper.ExecuteDataset(ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static string ConectarBD(string base_datos)
        {
            string CadenaConexion = null;

            if (base_datos == "APSSA_OS")
            {
                CadenaConexion = "Server=DESKTOP-MFCS;Database=APSSA_OS;User Id=sa;Password=sql12345;";
            }

            return CadenaConexion;
        }


    }
}
