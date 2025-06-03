using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApssaExactus
{
    class CreditoslBE
    {
    }

    public class FormatoClausula
    {
        public Int16 id_clausula { get; set; }
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public string clausula { get; set; }
        public string activo { get; set; }

    }

    public class CondicionPago
    {
        public string CONDICION_PAGO { get; set; }
        public string DESCRIPCION { get; set; }
    }


    public class AnalistaCreditoBE
    {
        public string usuario_cc { get; set; }
        public string nombre { get; set; }
        public string zona { get; set; }
        public string grupo { get; set; }

    }









}
