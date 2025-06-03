using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApssaExactus
{
    class LogisticaBE
    {
    }

    public class Preferencia        // aplicado en frm_VentaCompraV2_GY
    {
        public string modulo { get; set; }
        public string reporte { get; set; }
        public string preferencia { get; set; }
        public string bodega { get; set; }
        public string familia { get; set; }
        public string subfamilia { get; set; }
        public string grupo { get; set; }

    }



    public class OrdenCompra
    {
        public string shipto { get; set; }
        public string numero_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
        public string moneda { get; set; }
        public Decimal subtotal { get; set; }
        public Decimal impuesto { get; set; }
        public Decimal total { get; set; }
        public DateTime fecha_entrega { get; set; }
        public string rubro3 { get; set; }
        public string rubro5 { get; set; }

        public List<OrdenCompraLinea> OrdenDetalle { get; set; }
        //public ICollection<OrdenCompraLinea> Detalle { get; set; }

        //public OrdenCompra()
        //{
        //    this.Detalle = new HashSet<OrdenCompraLinea>();
        //}
    }



    public class OrdenCompraLinea
    {
        public string shipto { get; set; }
        public string numero_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
        public string moneda { get; set; }
        public Decimal total { get; set; }
        public string codigo { get; set; }
        public Decimal cantidad { get; set; }
        public Decimal precio { get; set; }
        public Decimal igv { get; set; }
        public DateTime fecha_entrega { get; set; }
        public string rubro3 { get; set; }
        public string rubro5 { get; set; }

    }



}
