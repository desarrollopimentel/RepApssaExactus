using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApssaExactus
{
    class ComercialBE
    {
    }

    public class VendedorCuotaBE
    {
        public string vendedor { get; set; }
        public string nombre { get; set; }
    }
    public class ClienteCuotaBE
    {
        public string cliente { get; set; }
        public string nombre { get; set; }
    }

    public class ArticuloStockBE
    {
        public string articulo { get; set; }
        public Decimal cant_disponible { get; set; }
        public Decimal cant_reservada { get; set; }
        public Decimal cant_remitida { get; set; }
    }

    public class ArticuloBE
    {
        public string articulo { get; set; }
        public string descripcion { get; set; }
        public string unidad_almacen { get; set; }
    }

    public class Tmp_CostProm
    {
        public string articulo { get; set; }
        public string descripcion { get; set; }
        public string moneda { get; set; }
        public Decimal costo_promedio { get; set; }
        public Decimal cantidad_en_bodega { get; set; }
        public Decimal costo_en_bodega { get; set; }
        public string familia { get; set; }
        public string subfamilia { get; set; }
        public string grupo { get; set; }
        public string marca { get; set; }
    }

    public class Tmp_CostRepos
    {
        public string articulo { get; set; }
        public string moneda { get; set; }
        public Decimal costo_reposicion { get; set; }
        public string descripcion { get; set; }
    }

    public class Pedido
    {
        public string pedido { get; set; }
        public string estado { get; set; }
        public DateTime fecha_pedido { get; set; }
        public DateTime fecha_prometida { get; set; }
        public DateTime fecha_prox_embarqu { get; set; }
        public DateTime fecha_ult_embarque { get; set; }
        public DateTime fecha_ult_cancelac { get; set; }
        public string orden_compra { get; set; }
        public DateTime fecha_orden { get; set; }
        public string tarjeta_credito { get; set; }
        public string embarcar_a { get; set; }
        public string direc_embarque { get; set; }
        public string direccion_factura { get; set; }
        public string rubro1 { get; set; }
        public string rubro2 { get; set; }
        public string rubro3 { get; set; }
        public string rubro4 { get; set; }
        public string rubro5 { get; set; }
        public string observaciones { get; set; }
        public string comentario_cxc { get; set; }
        public decimal total_mercaderia { get; set; }
        public decimal monto_anticipo { get; set; }
        public decimal monto_flete { get; set; }
        public decimal monto_seguro { get; set; }
        public decimal monto_documentacio { get; set; }
        public string tipo_descuento1 { get; set; }
        public string tipo_descuento2 { get; set; }
        public decimal monto_descuento1 { get; set; }
        public decimal monto_descuento2 { get; set; }
        public decimal porc_descuento1 { get; set; }
        public decimal porc_descuento2 { get; set; }
        public decimal total_impuesto1 { get; set; }
        public decimal total_impuesto2 { get; set; }
        public decimal total_a_facturar { get; set; }
        public decimal porc_comi_vendedor { get; set; }
        public decimal porc_comi_cobrador { get; set; }
        public decimal total_cancelado { get; set; }
        public decimal total_unidades { get; set; }
        public string impreso { get; set; }
        public DateTime fecha_hora { get; set; }
        public decimal descuento_volumen { get; set; }
        public string tipo_pedido { get; set; }
        public string moneda_pedido { get; set; }
        public Int32 version_np { get; set; }
        public string autorizado { get; set; }
        public string doc_a_generar { get; set; }
        public string clase_pedido { get; set; }
        public string moneda { get; set; }
        public string nivel_precio { get; set; }
        public string cobrador { get; set; }
        public string ruta { get; set; }
        public string usuario { get; set; }
        public string condicion_pago { get; set; }
        public string bodega { get; set; }
        public string zona { get; set; }
        public string vendedor { get; set; }
        public string cliente { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_corporac { get; set; }
        public string cliente_origen { get; set; }
        public string pais { get; set; }
        public Int32 subtipo_doc_cxc { get; set; }
        public string tipo_doc_cxc { get; set; }
        public string backorder { get; set; }
        public string contrato { get; set; }
        public decimal porc_intcte { get; set; }
        public string descuento_cascada { get; set; }
        public decimal tipo_cambio { get; set; }
        public string fijar_tipo_cambio { get; set; }
        public string origen_pedido { get; set; }
        public string desc_direc_embarque { get; set; }
        public string division_geografica1 { get; set; }
        public string division_geografica2 { get; set; }
        public decimal base_impuesto1 { get; set; }
        public decimal base_impuesto2 { get; set; }
        public string nombre_cliente { get; set; }
        public DateTime fecha_proyectada { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public string tipo_documento { get; set; }
        public string version_cotizacion { get; set; }
        public string razon_cancela_coti { get; set; }
        public string des_cancela_coti { get; set; }
        public string cambios_coti { get; set; }
        public string cotizacion_padre { get; set; }
        public string u_posicion { get; set; }
        public string u_dni { get; set; }
        public string u_nombre { get; set; }
        public string u_apellido { get; set; }
        public string u_direccion { get; set; }
        public string u_email { get; set; }
        public string u_telefono { get; set; }
        public string u_placa { get; set; }
        public string u_marca { get; set; }
        public string u_modelo { get; set; }
        public decimal monto_afecto_percepcion { get; set; }
        public string flag_monto_documentacion { get; set; }
        public string u_chasis { get; set; }
        public string u_tipovehiculo { get; set; }
        public string u_entregado { get; set; }
        public Int32 u_kilometraje { get; set; }
        public string u_serviciomina { get; set; }
        public string u_oservicio { get; set; }
    }

    public class Pedido_Linea
    {
        public string pedido { get; set; }
        public Int32 pedido_linea { get; set; }
        public string bodega { get; set; }
        public string lote { get; set; }
        public string localizacion { get; set; }
        public string articulo { get; set; }
        public string estado { get; set; }
        public DateTime fecha_entrega { get; set; }
        public Int32 linea_usuario { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal cantidad_pedida { get; set; }
        public decimal cantidad_a_factura { get; set; }
        public decimal cantidad_facturada { get; set; }
        public decimal cantidad_reservada { get; set; }
        public decimal cantidad_bonificad { get; set; }
        public decimal cantidad_cancelada { get; set; }
        public string tipo_descuento { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal porc_descuento { get; set; }
        public string descripcion { get; set; }
        public string comentario { get; set; }
        public Int32 pedido_linea_bonif { get; set; }
        public string unidad_distribucio { get; set; }
        public DateTime fecha_prometida { get; set; }
        public Int32 linea_orden_compra { get; set; }
        public string proyecto { get; set; }
        public string fase { get; set; }
        public string centro_costo { get; set; }
        public string cuenta_contable { get; set; }
        public string u_boleta { get; set; }
        public string boleta_cs { get; set; }
        public string u_doc_ref { get; set; }
        public string u_tecnico { get; set; }
        public string u_oservicio { get; set; }

    }

    public class Orden_Servicio
    {
        public string oservicio { get; set; }
        public string estado { get; set; }
        public DateTime fecha_servicio { get; set; }
        public DateTime fecha_prometida { get; set; }
        public DateTime fecha_prox_embarqu { get; set; }
        public DateTime fecha_ult_embarque { get; set; }
        public DateTime fecha_ult_cancelac { get; set; }
        public string orden_compra { get; set; }
        public DateTime fecha_orden { get; set; }
        public string tarjeta_credito { get; set; }
        public string embarcar_a { get; set; }
        public string direc_embarque { get; set; }
        public string direccion_factura { get; set; }
        public string rubro1 { get; set; }
        public string rubro2 { get; set; }
        public string rubro3 { get; set; }
        public string rubro4 { get; set; }
        public string rubro5 { get; set; }
        public string observaciones { get; set; }
        public string comentario_cxc { get; set; }
        public decimal total_mercaderia { get; set; }
        public decimal monto_anticipo { get; set; }
        public decimal monto_flete { get; set; }
        public decimal monto_seguro { get; set; }
        public decimal monto_documentacio { get; set; }
        public string tipo_descuento1 { get; set; }
        public string tipo_descuento2 { get; set; }
        public decimal monto_descuento1 { get; set; }
        public decimal monto_descuento2 { get; set; }
        public decimal porc_descuento1 { get; set; }
        public decimal porc_descuento2 { get; set; }
        public decimal total_impuesto1 { get; set; }
        public decimal total_impuesto2 { get; set; }
        public decimal total_a_facturar { get; set; }
        public decimal porc_comi_vendedor { get; set; }
        public decimal porc_comi_cobrador { get; set; }
        public decimal total_cancelado { get; set; }
        public decimal total_unidades { get; set; }
        public string impreso { get; set; }
        public DateTime fecha_hora { get; set; }
        public decimal descuento_volumen { get; set; }
        public string tipo_servicio { get; set; }
        public string moneda_servicio { get; set; }
        public Int32 version_np { get; set; }
        public string autorizado { get; set; }
        public string doc_a_generar { get; set; }
        public string clase_servicio { get; set; }
        public string moneda { get; set; }
        public string nivel_precio { get; set; }
        public string cobrador { get; set; }
        public string ruta { get; set; }
        public string usuario { get; set; }
        public string condicion_pago { get; set; }
        public string bodega { get; set; }
        public string zona { get; set; }
        public string vendedor { get; set; }
        public string cliente { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_corporac { get; set; }
        public string cliente_origen { get; set; }
        public string pais { get; set; }
        public Int32 subtipo_doc_cxc { get; set; }
        public string tipo_doc_cxc { get; set; }
        public string backorder { get; set; }
        public string contrato { get; set; }
        public decimal porc_intcte { get; set; }
        public string descuento_cascada { get; set; }
        public decimal tipo_cambio { get; set; }
        public string fijar_tipo_cambio { get; set; }
        public string origen_pedido { get; set; }
        public string desc_direc_embarque { get; set; }
        public string division_geografica1 { get; set; }
        public string division_geografica2 { get; set; }
        public decimal base_impuesto1 { get; set; }
        public decimal base_impuesto2 { get; set; }
        public decimal monto_afecto_percepcion { get; set; }
        public string flag_monto_documentacion { get; set; }
        public string nombre_cliente { get; set; }
        public DateTime fecha_proyectada { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public string tipo_documento { get; set; }
        public string version_cotizacion { get; set; }
        public string razon_cancela_coti { get; set; }
        public string des_cancela_coti { get; set; }
        public string cambios_coti { get; set; }
        public string cotizacion_padre { get; set; }
        public string u_posicion { get; set; }
        public string u_dni { get; set; }
        public string u_nombre { get; set; }
        public string u_apellido { get; set; }
        public string u_direccion { get; set; }
        public string u_email { get; set; }
        public string u_telefono { get; set; }
        public string u_placa { get; set; }
        public string u_marca { get; set; }
        public string u_modelo { get; set; }
        public string u_chasis { get; set; }
        public string u_tipovehiculo { get; set; }
        public string u_entregado { get; set; }
        public Int32 u_kilometraje { get; set; }
        public string u_serviciomina { get; set; }
        public string u_oservicio { get; set; }
        public string pedido { get; set; }

    }

    public class Orden_Servicio_Linea
    {
        public string oservicio { get; set; }
        public Int32 oservicio_linea { get; set; }
        public string bodega { get; set; }
        public string lote { get; set; }
        public string localizacion { get; set; }
        public string articulo { get; set; }
        public string estado_orden { get; set; }
        public DateTime fecha_entrega { get; set; }
        public Int32 linea_usuario { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal cantidad_pedida { get; set; }
        public decimal cantidad_a_factura { get; set; }
        public decimal cantidad_facturada { get; set; }
        public decimal cantidad_reservada { get; set; }
        public decimal cantidad_bonificad { get; set; }
        public decimal cantidad_cancelada { get; set; }
        public string tipo_descuento { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal porc_descuento { get; set; }
        public string descripcion { get; set; }
        public string comentario { get; set; }
        public Int32 pedido_linea_bonif { get; set; }
        public string unidad_distribucio { get; set; }
        public DateTime fecha_prometida { get; set; }
        public Int32 linea_orden_compra { get; set; }
        public string proyecto { get; set; }
        public string fase { get; set; }
        public string centro_costo { get; set; }
        public string cuenta_contable { get; set; }
        public string pedido { get; set; }
        public string u_boleta { get; set; }
        public string boleta_cs { get; set; }
        public string u_doc_ref { get; set; }
        public string u_tecnico { get; set; }
        public string u_oservicio { get; set; }
        public string usuario { get; set; }
        public Int32 orden_asignacion { get; set; }
        public string estado_boleta { get; set; }
        public DateTime fec_hr_inicio { get; set; }
        public DateTime fec_hr_original { get; set; }
        public string usuario_modifica { get; set; }
        public string falla { get; set; }
        public string tipo_equipo_cs { get; set; }
        public string boleta { get; set; }
        public string detalle_falla { get; set; }
        public string solucion_falla { get; set; }
        public string confirmada { get; set; }

    }

    public class Estado
    {
        public string estado { get; set; }
        public string descripcion { get; set; }
    }

    public class Boleta_Estado  // aplicado en frmOrdenServicio
    {
        public string boleta { get; set; }
        public Int32 orden_asignacion { get; set; }
        public string usuario { get; set; }
        public string estado { get; set; }
        public DateTime fec_hr_inicio { get; set; }
        public DateTime fec_hr_original { get; set; }
        public string usuario_modifica { get; set; }

    }

    public class Boleta_Falla  // aplicado en frmOrdenServicio
    {
        public string boleta { get; set; }
        public string usuario { get; set; }        
        public string falla { get; set; }
        public string tipo_equipo_cs { get; set; }
        public string detalle_falla { get; set; }
        public string solucion_falla { get; set; }
        public string confirmada { get; set; }
        public string tipo_equipo_cs_descrip { get; set; } 
    }

    public class Departamento  // aplicado en frmOrdenServicio
    {
        public string departamento { get; set; }
        public string descripcion { get; set; }
    }

    public class Localizacion  // aplicado en frmOrdenServicio
    {
        public string bodega { get; set; }
        public string localizacion { get; set; }
        public string descripcion { get; set; }     
    }

    public class Tienda  // aplicado en frmOrdenServicio
    {
        public string zona { get; set; }
        public string nombre { get; set; }
        public string u_sucursal { get; set; }
        public string u_codsuc { get; set; }
     
    }

    public class OrdenNumerador  // aplicado en frmOrdenServicio
    {
        public string u_codigo { get; set; }
        public string u_valor_consecutivo { get; set; }
        public string u_valor_maximo { get; set; }
        public string u_zona { get; set; }
        public string u_emitidos { get; set; }     
    }

    public class PedidoVehiculo   // aplicado en frmDatosVehiculo
    {
        public string u_posicion{ get; set; }
        public string u_dni{ get; set; }
        public string u_nombre{ get; set; }
        public string u_apellido{ get; set; }
        public string u_direccion{ get; set; }
        public string u_email{ get; set; }
        public string u_telefono{ get; set; }
        public string u_placa{ get; set; }
        public string u_tipovehiculo{ get; set; }
        public string u_modelo{ get; set; }
        public string u_marca{ get; set; }
        public Int32 u_kilometraje{ get; set; }
        public string u_chasis{ get; set; }
        public string u_entregado{ get; set; }
        public string u_serviciomina{ get; set; }
        public string tipoveh_descripcion { get; set; }        
    }    
  
    public class Vendedor   // aplicado en frmOrdenServicio
    {
        public string vendedor { get; set; }
        public string nombre { get; set; }
        public string empleado { get; set; }
    }

    public class Articulo_Precio
    {
        public string NIVEL_PRECIO { get; set; }
        public string MONEDA { get; set; }
        public Int32 VERSION { get; set; }
        public string ARTICULO { get; set; }
        public Int32 VERSION_ARTICULO { get; set; }
        public Decimal PRECIO { get; set; }
        public string ESQUEMA_TRABAJO { get; set; }
        public Decimal MARGEN_MULR { get; set; }
        public Decimal MARGEN_UTILIDAD { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public DateTime FECHA_ULT_MODIF { get; set; }
        public string USUARIO_ULT_MODIF { get; set; }
        public Decimal MARGEN_UTILIDAD_MIN { get; set; }
    }

    public class Periodo   // aplicado en frmComisionFlotas
    {
        //public string periodo { get; set; }
        //public string fecinicio { get; set; }
        //public string fecfinal { get; set; }
        //public string anno { get; set; }
        //public string tipo { get; set; }

        ////IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
        public Int32 idperiodo { get; set; }
        public string tipo { get; set; }
        public string anno { get; set; }
        public string periodo { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_final { get; set; }
        public string comentario { get; set; }
    }

    //orden,tabla,nombre,descripcion
    public class CursorApssa        // aplicado en frmComisionFlotas
    {
        public int orden { get; set; }
        public string tabla { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
    public class Tmp_Flete
    {
        public DateTime f_facturacion { get; set; }
        public string c_fac { get; set; }
        public string n_fac { get; set; }
        public string codcdv { get; set; }
        public string nomcdv { get; set; }
        public string codcli { get; set; }
        public string nomcli { get; set; }
        public string codven { get; set; }
        public string nomven { get; set; }
        public string tienda { get; set; }      //nomtie
        public string mone { get; set; }
        public string codf { get; set; }
        public string codi { get; set; }
        public string descr { get; set; }
        public Decimal cant { get; set; }
        public Decimal cdes { get; set; }
        public Decimal monto { get; set; }
        public Decimal pena45 { get; set; }
        public Decimal pena90 { get; set; }
        public DateTime fproceso { get; set; }
        public Decimal comision { get; set; }
        public string observacion { get; set; }
    }
    public class Tmp_Penalidad
    {
        public DateTime f_facturacion { get; set; }
        public string c_fac { get; set; }
        public string n_fac { get; set; }
        public string codcdv { get; set; }
        public string nomcdv { get; set; }
        public string codcli { get; set; }
        public string nomcli { get; set; }
        public string codven { get; set; }
        public string nomven { get; set; }
        public string tienda { get; set; }  //nomtie
        public string mone { get; set; }
        public string codf { get; set; }
        public string codi { get; set; }
        public string descr { get; set; }
        public Decimal cant { get; set; }
        public Decimal cdes { get; set; }
        public Decimal monto { get; set; }
        public Decimal pena45 { get; set; }
        public Decimal pena90 { get; set; }
        public DateTime fproceso { get; set; }
        public Decimal comision { get; set; }
        public string observacion { get; set; }
        public string situacion { get; set; }
        public DateTime vencimiento { get; set; }
        public DateTime uabono { get; set; }
        public Int32 dias { get; set; }
        public string letra { get; set; }
        public Int32 nlet { get; set; }
        public string estado { get; set; }
        public Decimal penalidad { get; set; }
        public string politica { get; set; }
        public string flag { get; set; }
    }

    public class Aprobacion_FD
    {
         public string PEDIDO {get;set;}
         public string CLIENTE {get;set;}
         public string NOMBRE_CLIENTE {get;set;}
         public DateTime FECHA {get;set;}
         public decimal TOTAL_MERCADERIA {get;set;}
         public decimal TOTAL_FACTURA {get;set;}
         public string USA_DESPACHOS{get;set;}
         public int AUDIT_TRANS_INV {get;set;}
         public string COBRADA {get;set;}
         public string CONDICION_PAGO {get;set;}
         public string MONEDA_FACTURA {get;set;}
         public string VENDEDOR  {get;set;}
         public string OBSERVACION {get;set;}
         public string USUARIO_APRUEBA { get; set; }
         public DateTime FECHA_APRUEBA { get; set; }
         public string ESTADO_DEVOLUCION  {get;set;}
    }




}
