using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApssaExactus
{
    public class GeneralBE
    {
    }

    public class Moneda
    {
        public string moneda { get; set; }
    }

    //usuarioreporte.usuario = lectoruser[0].ToString();          // USUARIO
    //usuarioreporte.nombre = lectoruser[1].ToString();           // NOMBRE
    //usuarioreporte.zona = lectoruser[2].ToString();             // ZONA
    //usuarioreporte.bodega = lectoruser[3].ToString();           // BODEGA
    //usuarioreporte.clave_reporte = lectoruser[4].ToString();    // PASSWORD
    //usuarioreporte.grupo = lectoruser[5].ToString();            // GRUPO

    public class UsuarioReporte
    {
        //u_codigo,u_descrip,u_zona,u_bodega,u_clave
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string zona { get; set; }
        public string bodega { get; set; }
        public string clave_reporte { get; set; }
        public string grupo { get; set; }
        public string zona_descrip { get; set; }
        public string bodega_descrip { get; set; }
        public string grupo_a { get; set; }
        public string caja { get; set; }
        public string caja_descrip { get; set; }

    }

    public class Usuario_ReporteBE
    {
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string activo { get; set; }
        public string req_cambio_clave { get; set; }
        public Int32 frecuencia_clave { get; set; }
        public DateTime fecha_ult_clave { get; set; }
        public Int32 max_intentos_conex { get; set; }
        public string clave { get; set; }
        public string correo_electronico { get; set; }
        public string tipo_acceso { get; set; }
        public string celular { get; set; }
        public string firma { get; set; }
        public string cargo { get; set; }
        public string zona { get; set; }
        public string bodega { get; set; }
        public string clave_reporte { get; set; }
        public string grupo { get; set; }
        public string zona_descrip { get; set; }
        public string bodega_descrip { get; set; }
        public string grupo_a { get; set; }
    }


    public class VendedorBE
    {
        public string VENDEDOR { get; set; }
        public string NOMBRE { get; set; }
        public string EMPLEADO { get; set; }
        public Decimal COMISION { get; set; }
        public string CTR_COMISION { get; set; }
        public string CTA_COMISION { get; set; }
        public string E_MAIL { get; set; }
        public string ACTIVO { get; set; }
    }

    // 05/09/2018
    public class ClienteBE
    {
        public string CLIENTE { get; set; }
        public string NOMBRE { get; set; }

    }



}
