using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exactus.BE
{
    class TesoreriaBE
    {
    }


    public class DocumentoCP_BE
    {
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public string documento { get; set; }
        public string moneda { get; set; }
        public Decimal monto { get; set; }
        public Decimal saldo { get; set; }
        public Decimal monto_soles { get; set; }
        public Decimal monto_dolares { get; set; }
        public Decimal saldo_soles { get; set; }
        public Decimal saldo_dolares { get; set; }
        public string proveedor { get; set; }


    }

    //CUENTA_BANCO,NOMBRE,ENTIDAD_FINANCIERA,MONEDA,SALDO
    public class Cuenta
    {
        public string CUENTA_BANCO { get; set; }
        public string NOMBRE { get; set; }
        public string ENTIDAD_FINANCIERA { get; set; }
        public string MONEDA { get; set; }
        public string SALDO { get; set; }
    }


}
