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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using Exactus.BL;
using Exactus.BE;
using Exactus.LIBCS;
using Exactus.LIBVB;

namespace Exactus.Win
{
    public partial class frmFacturaVista : DevExpress.XtraEditors.XtraForm
    {

        //Factura
        public string vTipoDocumento = null;
        public string vFactura = null;

        Factura factura = null;
        Factura_Linea factura_linea = null;
        Vendedor vendedor = null;



        public DateTime v_fecha ;
        public string v_cliente = null;
        public string v_nombre_cliente = null;
        public string v_tipo_documento = null;
        public string v_factura = null;
        public string v_pedido = null;
        public string v_tipo_original = null;
        public string v_factura_original = null;
        public decimal v_total_impuesto1 = 0;
        public decimal v_total_factura = 0;
        public string v_condicion_pago = null;
        public string v_vendedor = null;
        public string v_zona = null;
        public string v_ruta = null;
        public string v_anulada = null;
        public string v_cobrada = null;
        public string v_moneda_factura = null;
        public decimal v_tipo_cambio = 0;
        public string v_nivel_precio = null;


        /*
        //public string vNumPedido = null;
        public string vcPedOrdenServicio = null;    //ORDEN SERVICIO
        public string vcPedido = null;          //PEDIDO
        public DateTime vdPedFecha;
        public string vcPedCliente = null;
        public string vcPedCodCli = null;
        public string vcPedCodCondicion = null;
        public string vcPedCodVen = null;
        public string vcPedMoneda = null;
        public Decimal vnPedMonto = 0;
        public Decimal vnPedIgv = 0;
        public Decimal vnPedTotal = 0;
        public string vcPedZona = null;
        public string vcPedBodega = null;
        public string vcPedBoleta = null;           //BOLETA
        public string vcPedTecnico = null;
        public string vcPedArticulo = null;
        public string vcPedCotizacion = null;       //COTIZACION
        public string vcPedEstado = null; 

        // datos del vehiculo
        public string varU_POSICION = null;
        public string varU_DNI = null;
        public string varU_NOMBRE = null;
        public string varU_APELLIDO = null;
        public string varU_DIRECCION = null;
        public string varU_EMAIL = null;
        public string varU_TELEFONO = null;
        public string varU_PLACA = null;
        public string varU_TIPOVEHICULO = null;
        public string varU_MODELO = null;
        public string varU_MARCA = null;
        public Int32 varU_KILOMETRAJE = 0;
        public string varU_CHASIS = null;
        public string varU_ENTREGADO = null;
        public string varU_SERVICIOMINA = "NO";     //  null;  NO DEBE SER NULO
        public string varU_TIPOVEHICULO_DESCRIP = null;

        //Boleta_Falla boleta_falla = null;
        //Boleta_Estado boleta_estado = null;
        //PedidoVehiculo pedidovehiculo = null;
        Vendedor vendedor = null;
        OrdenNumerador ordennumerador = null;
        Tienda tienda = null;
        Localizacion localizacion = null;
        Departamento departamento = null;
        //Orden_Servicio orden_servicio = null;
        Orden_Servicio_Linea orden_servicio_linea = null;
        Estado estado = null;

        // variables temporales
        public string varBOLETA = null;
        public string varPEDIDO = null;
        public string varU_OSERVICIO = null;
        public string varTECNICO = null;
        public string varARTICULO = null;
        public Int32 varLINEA = 0;
        public string varESTADO_PEDIDO = null;  //P.ESTADO AS ESTADO_PEDIDO, B.ESTADO AS ESTADO_BOLETA, E.ESTADO AS ESTADO_BOLETA_ESTADO
        public string varESTADO_BOLETA = null;
        public string varESTADO_BOLETA_ESTADO = null;
        public string varLOCALIZACION = null;
        public string varDEPARTAMENTO = null;
        public string varUSUARIO_ULT_MOD = null;
        public string varNOTAS_CLIENTE = null;
        public string varHORAS_COBRO = null;
        public Int32 varORDEN_ASIGNACION = 0;
        public string varUSUARIO = null;
        public DateTime varFEC_HR_INICIO;
        public DateTime varFEC_HR_ORIGINAL;
        //public DateTime varFEC_HR_INICIO = (DateTime?)null;
        //public DateTime varFEC_HR_ORIGINAL = (DateTime?)null;
        public string varUSUARIO_MODIFICA = null;

        public string varFALLA = null;
        public string varTIPO_EQUIPO_CS = null;
        public string varDETALLE_FALLA = null;
        public string varSOLUCION_FALLA = null;
        public string varCONFIRMADA = null;

        public string varCODPROV = null;
        public string varDESCRIPCION = null;


        public Int32 varUltimaOrden = 0;
        public Int32 NumColumnas = 0;

        DateTime? Date1 = (DateTime?)DateTime.Now;
        DateTime? Date2 = (DateTime?)null;

        public bool lServicio_OK = true;
        public bool lTieneOrden_OK = false;
        public bool lDatos_Vehiculo = false;
        public bool lRegistro_Fallas = false;
        public bool lBoleta_OK = true;

        // Parametros
        public static DataSet ds_listapedido;   //Pedidos
        public static DataSet ds_listadeserv;   //Servicios
        public static DataSet ds_vende;         //Vendedores
        public static DataSet ds_listatec;      //Tecnicos
        public static DataSet ds_tienda;        //Tiendas
        public static DataSet ds_tien;
        public static DataSet ds_localizacion;  //Localizacion
        public static DataSet ds_local;
        public static DataSet ds_departamento;  //Departamento
        public static DataSet ds_depar;
        public static DataSet ds_numord;        //Numerador Orden Servicios
        public static DataSet ds_vehiculo;      //Datos del vehiculo
        public static DataSet ds_os;            //Orden Servicio
        public static DataSet ds_osl;           //Orden Servicio Linea
        public static DataSet ds_est;           //Estado
        public static DataSet ds_estado;
        public static DataSet ds_osl_aux;           //Orden Servicio Linea
        */


        //public FormatInfo DisplayFormat { get; }

        public frmFacturaVista()
        {
            InitializeComponent();
        }

        /// ------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmFacturaVista m_FormDefInstance;

        /// Instancia por defecto
        public static frmFacturaVista DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmFacturaVista();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------

        private void frmFacturaVista_Load(object sender, EventArgs e)
        {

            //public string vTipoDocumento = null;
            //public string vFactura = null;

            ObtenerFacturaCabecera(vTipoDocumento, vFactura);
            CargarFacturaCabecera(vTipoDocumento, vFactura);

            ObtenerFacturaLinea(vTipoDocumento, vFactura);

            /*
            //instancia dataset
            LimpiaDataSets();

            //Configuracion
            ConfiguraGrid();
            LimpiarTextos();

            //Cabecera
            txtZona.Text = vcPedZona;
            txtFecha.Text = vdPedFecha.ToShortDateString();  //vdPedFecha.ToString()
            txtReferencia.Text = vcPedido;
            txtCliente.Text = vcPedCliente;
            txtCodCli.Text = vcPedCodCli;
            txtCodCondicion.Text = vcPedCodCondicion;
            txtCodVen.Text = vcPedCodVen;
            txtMoneda.Text = vcPedMoneda;
            txtMonto.Text = vnPedMonto.ToString();
            txtIgv.Text = vnPedIgv.ToString();
            txtTotal.Text = vnPedTotal.ToString();
            Carga_lookUp_Tiendas();
            Carga_lookUp_Localizacion();
            Carga_lookUp_Departamentos();
            CargaDatosTienda(vcPedZona);
            lookUpEditTienda.Text = tienda.nombre;   //vcPedZona;
            CargaDatoVendedor(txtCodVen.Text);    
            txtVendedor.Text = vendedor.nombre;

            txtLocalizacion.Text = vcPedBodega;
            
            CargaDatosLocalizacion(vcPedBodega);
            lookUpEditLocalizacion.Text = localizacion.descripcion;

            CargaDatosDepartamento(vcPedZona);
            lookUpEditDepartamento.Text = departamento.descripcion;
            txtDepartamento.Text = departamento.departamento;

            CargaDatosEstado(vcPedEstado);
            lookUpEditEstado.Text = estado.descripcion;

            //Carga datos del vehiculo
            CargaDatoPedidoVehiculo(vcPedido);

            //Cargar Pedido para actualizar Orden
            Cargar_PedidoUpdateOrdenServicioDetalle(vcPedido);
            
            //Cargar OSL copia
            Cargar_OSL(vcPedOrdenServicio);

            //Detalle
            Mostrar_OrdenServicioDetalle(vcPedOrdenServicio);

            txtOServicio.Text = vcPedOrdenServicio;

            SoloLecturaTextos();
            */
        }


        private void ObtenerFacturaLinea(string _tipo, string _factura)
        {
            using (WaitDialogForm waitDialog = new WaitDialogForm("Obteniendo Informacion del Documento ....", "Espere por favor.."))
            {
                DataTable dtFacturaLinea = new DataTable();
                dtFacturaLinea = ComercialBL.dtObtenerDatosFacturaLineaBL(_tipo, _factura, Global.vUserBaseDatos);
                gcFactura.DataSource = dtFacturaLinea;
            }

            ConfiguraGrilla(gvFactura);
        }

        public void ObtenerFacturaCabecera(string _tipo, string _factura)
        {
            if (factura == null)
                factura = new Factura();

            DataTable dtFactura = new DataTable();
            dtFactura = ComercialBL.dtObtenerDatosFacturaCabeceraBL( _tipo, _factura, Global.vUserBaseDatos);

            DataTableReader lector = dtFactura.CreateDataReader();

            while (lector.Read())
            {
                factura.fecha = Convert.ToDateTime(lector[0]);
                factura.cliente = lector[1].ToString();
                factura.nombre_cliente = lector[2].ToString();
                factura.tipo_documento = lector[3].ToString();
                factura.factura = lector[4].ToString();
                factura.pedido = lector[5].ToString();
                factura.tipo_original = lector[6].ToString();
                factura.factura_original = lector[7].ToString();
                factura.total_impuesto1 = Convert.ToDecimal(lector[8]);
                factura.total_factura = Convert.ToDecimal(lector[9]);
                factura.condicion_pago = lector[10].ToString();
                factura.vendedor = lector[11].ToString();
                factura.zona = lector[12].ToString();
                factura.ruta = lector[13].ToString();
                factura.anulada = lector[14].ToString();
                factura.cobrada = lector[15].ToString();
                factura.moneda_factura = lector[16].ToString();
                factura.tipo_cambio = Convert.ToDecimal(lector[17]);
                factura.nivel_precio = lector[18].ToString();
            }


        }


        public void CargarFacturaCabecera(string _tipo, string _factura)
        {
            txtCliente_Nombre.Text = factura.nombre_cliente;
            txtCliente.Text = factura.cliente;
            txtCondicion.Text = factura.condicion_pago;
            txtNivelPrecio.Text = "";
            txtVendedor.Text = factura.vendedor;
            txtCondicion_descripcion.Text = "";
            txtNivelPrecio_Descripcion.Text = "";
            //txtVendedor.Text = "";
            txtFactura.Text = factura.factura;
            txtFecha.Text = factura.fecha.ToString();
            txtPedido.Text = factura.pedido;
            txtMoneda.Text = factura.moneda_factura;
            txtTCambio.Text = factura.tipo_cambio.ToString();
            //txtMonto.Text = "";
            //txtImpuesto.Text = "";
            //txtTotal.Text = "";
            txtZona.Text = factura.zona;
            txtLocalizacion.Text = "";
            txtDepartamento.Text = "";
            txtFactura.Text = "";

            txtMonto.Text = (factura.total_factura - factura.total_impuesto1).ToString();
            txtImpuesto.Text = factura.total_impuesto1.ToString();
            txtTotal.Text = factura.total_factura.ToString();

            txtTipoOriginal.Text = factura.tipo_original;
            txtFacturaOriginal.Text = factura.factura_original;

            //factura.tipo_documento ;
            //
            //
            //
            //
            //
            //

            //factura.ruta ;
            //factura.anulada ;
            //factura.cobrada ;
            //factura.nivel_precio 

            CargaDatoVendedor(txtVendedor.Text);
            txtVendedor_Nombre.Text = vendedor.nombre;


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



        #region GRILLAS
        /*
        private void gvOrdenServicioDetalle_ShowingEditor(object sender, CancelEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view.FocusedColumn.FieldName == "TECNICO")
            //    e.Cancel = true;
            //var grid = sender as GridView;
            //if (grid.FocusedColumn.FieldName == "TECNICO") 
            //{
            //    var row = grid.GetRow(grid.FocusedRowHandle) as // your model;
            //    // note that previous line should be different in case of for example a DataTable datasource
            //    grid.ActiveEditor.Properties.ReadOnly = // your condition based on the current row object                         
            // }
        }

        private void gvOrdenServicioDetalle_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            //ColumnView view = sender as ColumnView;
            //if (e.Column.FieldName == "CANTIDAD" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //{
            //    //int currencyType = (int)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "CurrencyType");
            //    decimal CANTIDAD = Convert.ToDecimal(e.Value);
            //}

            //if (e.Column.FieldName == "PRECIO" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //{
            //    //int currencyType = (int)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "CurrencyType");
            //    decimal PRECIO = Convert.ToDecimal(e.Value);
            //}
        }

        private void gvOrdenServicioDetalle_DoubleClick(object sender, EventArgs e)
        {
            frmBoletaServicio_RegistroFallas FormFallas = new frmBoletaServicio_RegistroFallas();
            FormFallas.vcNumBoleta = vcPedBoleta;
            FormFallas.vcTecnico = vcPedTecnico;
            FormFallas.ShowDialog();

            if (FormFallas.DialogResult == DialogResult.OK)
            {
                varBOLETA = vcPedBoleta;
                varFALLA = FormFallas._FALLA;
                varTIPO_EQUIPO_CS = FormFallas._TIPO_EQUIPO_CS;
                varUSUARIO = Global.vUserUsuario;
                varDETALLE_FALLA = FormFallas._DETALLE_FALLA;
                varSOLUCION_FALLA = FormFallas._SOLUCION_FALLA;
                varCONFIRMADA = FormFallas._TIPO_EQUIPO_CS_DESCRIP;


                // ACTUALIZO GRILLA
                try
                {
                    Int32 j;
                    for (j = 0; j < gvFactura.RowCount; j++)
                    {
                        gvFactura.SetRowCellValue(j, "FALLA", varFALLA);
                        gvFactura.SetRowCellValue(j, "TIPO_EQUIPO_CS", varTIPO_EQUIPO_CS);
                        gvFactura.SetRowCellValue(j, "USUARIO", varUSUARIO);
                        gvFactura.SetRowCellValue(j, "DETALLE_FALLA", varDETALLE_FALLA);
                        gvFactura.SetRowCellValue(j, "SOLUCION_FALLA", varSOLUCION_FALLA);
                        gvFactura.SetRowCellValue(j, "CONFIRMADA", varCONFIRMADA);
                    }

                    //actualizo el grid control 
                    gcFactura.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                //MessageBox.Show("Vuelva a intentar....");  // TODO numero de intentos
                //Application.Exit();
                //return;
            }

            //MessageBox.Show("Registro de Fallas");
        }

        private void gvOrdenServicioDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //vcPedBoleta = gvOrdenServicioDetalle.GetRowCellValue(gvOrdenServicioDetalle.FocusedRowHandle, "BOLETA").ToString();
            //vcPedTecnico = gvOrdenServicioDetalle.GetRowCellValue(gvOrdenServicioDetalle.FocusedRowHandle, "TECNICO").ToString();
            //vcPedArticulo = gvOrdenServicioDetalle.GetRowCellValue(gvOrdenServicioDetalle.FocusedRowHandle, "ARTICULO").ToString();

        }

        */
        #endregion


        #region BOTONES

        private void btnCerrarFactura_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion


        #region RUTINAS

        public void CargaDatoVendedor(string codven)
        {
            if (vendedor == null)
                vendedor = new Vendedor();

            DataTable dtVendedor = new DataTable();
            dtVendedor = ComercialBL.CargaDatoVendedor(codven, Global.vUserBaseDatos).Tables[0];

            DataTableReader lector = dtVendedor.CreateDataReader();

            //ds_vende = ComercialBL.CargaDatoVendedor(codven, Global.vUserBaseDatos);
            //DataTableReader lector = ds_vende.Tables[0].CreateDataReader();

            while (lector.Read())
            {
                vendedor.vendedor = lector[0].ToString();
                vendedor.nombre = lector[1].ToString();
                vendedor.empleado = lector[2].ToString();
            }

        }


        private void lookUpEditTienda_EditValueChanged(object sender, EventArgs e)
        {
            //txtZona.Text = lookUpEditTienda.Text;
        }

        private void lookUpEditLocalizacion_EditValueChanged(object sender, EventArgs e)
        {
            txtLocalizacion.Text = lookUpEditLocalizacion.GetColumnValue("LOCALIZACION").ToString();
        }

        private void lookUpEditDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            txtDepartamento.Text = lookUpEditDepartamento.GetColumnValue("DEPARTAMENTO").ToString();
        }



        private void SumaMontos()
        {
            double sumMonto = 0;
            double sumIgv = 0;
            double sumTotal = 0;

            for (int i = 0; i < gvFactura.DataRowCount; ++i)
            {
                DataRow row = gvFactura.GetDataRow(i);
                //sumMonto += Convert.ToDouble(row["Pena45"].ToString());
                //sumIgv += Convert.ToDouble(row["Pena90"].ToString());
                //sumTotal += Convert.ToDouble(row["Pena90"].ToString());
            }

            txtMonto.Text = sumMonto.ToString();
            txtImpuesto.Text = sumIgv.ToString();
            txtTotal.Text = sumTotal.ToString();
        }


        public void LimpiarTextos()
        {
            txtCliente_Nombre.Text = "";
            txtCliente.Text = "";
            txtCondicion.Text = "";
            txtNivelPrecio.Text = "";
            txtVendedor.Text = "";
            txtCondicion_descripcion.Text = "";
            txtNivelPrecio_Descripcion.Text = "";
            txtVendedor_Nombre.Text = "";
            txtFactura.Text = "";
            txtFecha.Text = "";
            txtPedido.Text = "";
            txtMoneda.Text = "";
            txtTCambio.Text = "";
            txtMonto.Text = "";
            txtImpuesto.Text = "";
            txtTotal.Text = "";
            txtZona.Text = "";
            txtVendedor.Text = "";
            txtLocalizacion.Text = "";
            txtDepartamento.Text = "";
            txtFactura.Text = "";

        }

        public void SoloLecturaTextos()
        {
            txtCliente_Nombre.Properties.ReadOnly = true;
            txtCliente.Properties.ReadOnly = true;
            txtCondicion.Properties.ReadOnly = true;
            txtNivelPrecio.Properties.ReadOnly = true;
            txtVendedor.Properties.ReadOnly = true;
            txtCondicion_descripcion.Properties.ReadOnly = true;
            txtNivelPrecio_Descripcion.Properties.ReadOnly = true;
            txtVendedor_Nombre.Properties.ReadOnly = true;
            txtFactura.Properties.ReadOnly = true;
            txtFecha.Properties.ReadOnly = true;
            txtPedido.Properties.ReadOnly = true;
            txtMoneda.Properties.ReadOnly = true;
            txtTCambio.Properties.ReadOnly = true;
            txtMonto.Properties.ReadOnly = true;
            txtImpuesto.Properties.ReadOnly = true;
            txtTotal.Properties.ReadOnly = true;
            txtZona.Properties.ReadOnly = true;
            txtVendedor.Properties.ReadOnly = true;
            txtLocalizacion.Properties.ReadOnly = true;
            txtDepartamento.Properties.ReadOnly = true;
            txtFactura.Properties.ReadOnly = true;
        }


        public void ConfiguraGrid()
        {
            //gvBolServDetalle
            gvFactura.OptionsView.ColumnAutoWidth = false;
            gvFactura.BestFitColumns();
            gvFactura.OptionsView.ShowGroupPanel = false;

            //GridColumn.AppereanceCell.Font = Font("Arial", 12, FontStyle.Bold);
            gvFactura.Appearance.Row.Font = new Font(gvFactura.Appearance.Row.Font, FontStyle.Bold);
            gvFactura.Appearance.Row.Options.UseFont = true;

            Font fnt = new Font(gvFactura.Appearance.Row.Font.Name, 7);
            gvFactura.Appearance.HeaderPanel.Font = fnt;
            gvFactura.Appearance.Row.Font = fnt;
            gvFactura.OptionsView.ShowGroupPanel = false;
            gvFactura.OptionsView.ShowIndicator = false;

        }

        #endregion


    }
}

