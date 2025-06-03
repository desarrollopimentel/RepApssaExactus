using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApssaExactus
{

    public class ContabilidadBE
    {
    }

    public class ParametrosLiquidacion
    {
        public string tipo_asiento{ get; set; }
        public string paquete { get; set; }
        public string cuenta_banco { get; set; }
        public string tipo { get; set; }
        public string subtipo { get; set; }

        public string tipo_asiento_desc { get; set; }
        public string paquete_desc { get; set; }
        public string cuenta_banco_desc { get; set; }
        public string tipo_desc { get; set; }
        public string subtipo_desc { get; set; }

    }


    public class Cuenta_ContBE
    {
        public string cuenta_contable { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }
        public string tipo_detallado { get; set; }
        public string acepta_datos { get; set; }
        public string usa_centro_costo { get; set; }
    }

    public class Diario
    {
        public string ASIENTO { get; set; }
        public Int32 CONSECUTIVO { get; set; }
        public string NIT { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string CUENTA_CONTABLE { get; set; }
        public string FUENTE { get; set; }
        public string REFERENCIA { get; set; }
        public Decimal DEBITO_LOCAL { get; set; }
        public Decimal DEBITO_DOLAR { get; set; }
        public Decimal CREDITO_LOCAL { get; set; }
        public Decimal CREDITO_DOLAR { get; set; }
        public Decimal DEBITO_UNIDADES { get; set; }
        public Decimal CREDITO_UNIDADES { get; set; }
        public Decimal TIPO_CAMBIO { get; set; }
        public Decimal BASE_LOCAL { get; set; }
        public Decimal BASE_DOLAR { get; set; }
        public string PROYECTO { get; set; }
        public string FASE { get; set; }
        // DE Asiento_de_diario
	    public string PAQUETE { get; set; }
	    public string TIPO_ASIENTO { get; set; }
	    public DateTime FECHA { get; set; }

    }

    public class Mayor
    {
        public string ASIENTO { get; set; }
        public Int32 CONSECUTIVO { get; set; }
        public string NIT { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string CUENTA_CONTABLE { get; set; }
        public DateTime FECHA { get; set; }
        public string TIPO_ASIENTO { get; set; }
        public string FUENTE { get; set; }
        public string REFERENCIA { get; set; }
        public string ORIGEN { get; set; }
        public Decimal DEBITO_LOCAL { get; set; }
        public Decimal CREDITO_LOCAL { get; set; }
        public Decimal DEBITO_DOLAR { get; set; }
        public Decimal CREDITO_DOLAR { get; set; }
        public string CONTABILIDAD { get; set; }
        public string CLASE_ASIENTO { get; set; }
        public string ESTADO_CONS_FISC { get; set; }
        public string ASNT_CONS_FISC { get; set; }
        public string ESTADO_CONS_CORP { get; set; }
        public string ASNT_CONS_CORP { get; set; }
        public Decimal DEBITO_UNIDADES { get; set; }
        public Decimal CREDITO_UNIDADES { get; set; }
        public Decimal TIPO_CAMBIO { get; set; }
        public Decimal BASE_LOCAL { get; set; }
        public Decimal BASE_DOLAR { get; set; }
        public string PROYECTO { get; set; }
        public string FASE { get; set; }
        public string CARGADO_OBRA_CURSO { get; set; }
    }

    public class Asiento_de_diario
    {
	    public string ASIENTO { get; set; }
	    public string PAQUETE { get; set; }
	    public string TIPO_ASIENTO { get; set; }
	    public DateTime FECHA { get; set; }
	    public string CONTABILIDAD { get; set; }
	    public string ORIGEN { get; set; }
	    public string CLASE_ASIENTO { get; set; }
	    public Decimal TOTAL_DEBITO_LOC { get; set; }
	    public Decimal TOTAL_DEBITO_DOL { get; set; }
	    public Decimal TOTAL_CREDITO_LOC { get; set; }
	    public Decimal TOTAL_CREDITO_DOL { get; set; }
	    public string ULTIMO_USUARIO { get; set; }
	    public DateTime FECHA_ULT_MODIF { get; set; }
	    public string MARCADO { get; set; }
	    public string NOTAS { get; set; }
	    public Decimal TOTAL_CONTROL_LOC { get; set; }
	    public Decimal TOTAL_CONTROL_DOL { get; set; }
	    public string USUARIO_CREACION { get; set; }
	    public DateTime FECHA_CREACION { get; set; }
	    public string DEPENDENCIA { get; set; }
    }

    public class Cuenta_contable
    {
        public string CUENTA_CONTABLE { get; set; }
        public string SECCION_CUENTA { get; set; }
        public string UNIDAD { get; set; }
        public string DESCRIPCION { get; set; }
        public string TIPO { get; set; }
        public string TIPO_DETALLADO { get; set; }
        public string TIPO_OAF { get; set; }
        public string SALDO_NORMAL { get; set; }
        public string CONVERSION { get; set; }
        public string TIPO_CAMBIO { get; set; }
        public string ACEPTA_DATOS { get; set; }
        public string CONSOLIDA { get; set; }
        public string USA_CENTRO_COSTO { get; set; }
        public string NOTAS { get; set; }
        public string USUARIO { get; set; }
        public DateTime FECHA_HORA { get; set; }
        public string USUARIO_ULT_MOD { get; set; }
        public DateTime FCH_HORA_ULT_MOD { get; set; }
        public string ACEPTA_UNIDADES { get; set; }
        public string USO_RESTRINGIDO { get; set; }
        public string ORIGEN_CONVERSION { get; set; }
        public string VALIDA_PRESUP_CR { get; set; }
        public string CUENTA_IFRS { get; set; }
        public string INCLUIR_REP_CP { get; set; }
        public string INCLUIR_REP_CB { get; set; }
        public string ENTIDAD_FINANCIERA_CB { get; set; }
        public string INCLUIR_REP_CC { get; set; }
        public string USA_CONTA_ELECTRO { get; set; }
        public string VERSION { get; set; }
        public DateTime FECHA_INI_CE { get; set; }
        public DateTime FECHA_FIN_CE { get; set; }
        public string COD_AGRUPADOR { get; set; }
        public string DESC_COD_AGRUP { get; set; }
        public string SUB_CTA_DE { get; set; }
        public string DESC_SUB_CTA { get; set; }
        public string NIVEL { get; set; }
    }    

    public class Ctas_contable
    {
	    public string CUENTA_CONTABLE { get; set; }
	    public string SECCION_CUENTA { get; set; }
	    public string UNIDAD { get; set; }
	    public string DESCRIPCION { get; set; }
	    public string TIPO { get; set; }
	    public string TIPO_DETALLADO { get; set; }
	    public string TIPO_OAF { get; set; }
	    public string SALDO_NORMAL { get; set; }
	    public string CONVERSION { get; set; }
	    public string TIPO_CAMBIO { get; set; }
	    public string ACEPTA_DATOS { get; set; }
	    public string CONSOLIDA { get; set; }
	    public string USA_CENTRO_COSTO { get; set; }
	    public string NOTAS { get; set; }
	    public string USUARIO { get; set; }
	    public DateTime FECHA_HORA { get; set; }
	    public string USUARIO_ULT_MOD { get; set; }
	    public DateTime FCH_HORA_ULT_MOD { get; set; }
	    public string ACEPTA_UNIDADES { get; set; }
	    public string USO_RESTRINGIDO { get; set; }
	    public string ORIGEN_CONVERSION { get; set; }
	    public string VALIDA_PRESUP_CR { get; set; }
	    public string CUENTA_IFRS { get; set; }
	    public string INCLUIR_REP_CP { get; set; }
	    public string INCLUIR_REP_CB { get; set; }
	    public string ENTIDAD_FINANCIERA_CB { get; set; }
	    public string INCLUIR_REP_CC { get; set; }
	    public string USA_CONTA_ELECTRO { get; set; }
	    public string VERSION { get; set; }
	    public DateTime FECHA_INI_CE { get; set; }
	    public DateTime FECHA_FIN_CE { get; set; }
	    public string COD_AGRUPADOR { get; set; }
	    public string DESC_COD_AGRUP { get; set; }
	    public string SUB_CTA_DE { get; set; }
	    public string DESC_SUB_CTA { get; set; }
	    public string NIVEL { get; set; }
	    public string CTA_NAVASOFT { get; set; }
    }



    public class DiarioNavasoftBE               // aplicado en frmAsientoExactusNavasoft
    {
      public string ano_as { get; set; }
      public string mes_as { get; set; }
      public string dia_as { get; set; }
      public string compro { get; set; }
      public string origen { get; set; }
      public string cuenta { get; set; }
      public string ccosto { get; set; }
      public string coddoc { get; set; }
      public string nrodoc { get; set; }
      public string docref { get; set; }
      public string nroref { get; set; }
      public DateTime fvenci { get; set; }
      public string idrefe { get; set; }
      public string nomref { get; set; }
      public string rucref { get; set; }
      public string glosa { get; set; }
      public string tmovim { get; set; }
      public Decimal debe { get; set; }
      public Decimal haber { get; set; }
      public Decimal debed { get; set; }
      public Decimal haberd { get; set; }
      public string gcosto { get; set; }
      public string amarre { get; set; }
      public string ctaref { get; set; }
      public string ctapte { get; set; }
      public string moneda { get; set; }
      public string destin { get; set; }
      public string estado { get; set; }
      public Decimal tipcam { get; set; }
      public string codpos { get; set; }
      public string inaigv { get; set; }
      public string flucaj { get; set; }
      public Decimal montus { get; set; }
      public DateTime fechao { get; set; }
      public string codscc { get; set; }
      public string idcompro { get; set; }
      public string codsub { get; set; }
      public string codsun { get; set; }
      public DateTime fpago { get; set; }
      public string obser { get; set; }
      public DateTime detfec { get; set; }
      public string detnro { get; set; }
      public Decimal detimp { get; set; }
      public Decimal dettas { get; set; }
      public string codpro { get; set; }
      public string ctaact { get; set; }
      public string crefe { get; set; }
      public string nrefe { get; set; }
      public DateTime frefe { get; set; }
      public string codi { get; set; }
      public string nplan { get; set; }
  }



    /*
    public class DiarioNavasoftBE               // aplicado en frmAsientoExactusNavasoft
  {
      public string ano_as { get; set; }
      public string mes_as { get; set; }
      public string dia_as { get; set; }
      public string compro { get; set; }
      public string origen { get; set; }
      public string cuenta { get; set; }
      public string ccosto { get; set; }
      public string coddoc { get; set; }
      public string nrodoc { get; set; }
      public string docref { get; set; }
      public string nroref { get; set; }
      public DateTime fvenci { get; set; }
      public string idrefe { get; set; }
      public string nomref { get; set; }
      public string rucref { get; set; }
      public string glosa { get; set; }
      public string tmovim { get; set; }
      public Decimal debe { get; set; }
      public Decimal haber { get; set; }
      public Decimal debed { get; set; }
      public Decimal haberd { get; set; }
      public string gcosto { get; set; }
      public string amarre { get; set; }
      public string ctaref { get; set; }
      public string ctapte { get; set; }
      public string moneda { get; set; }
      public string destin { get; set; }
      public string estado { get; set; }
      public Decimal tipcam { get; set; }
      public string codpos { get; set; }
      public string inaigv { get; set; }
      public string flucaj { get; set; }
      public Decimal montus { get; set; }
      //public DateTime fechao { get; set; }
      public string codscc { get; set; }
      public string idcompro { get; set; }
      public string codsub { get; set; }
      public string codsun { get; set; }
      //public DateTime fpago { get; set; }
      public string obser { get; set; }
      //public DateTime detfec { get; set; }
      public string detnro { get; set; }
      public Decimal detimp { get; set; }
      public Decimal dettas { get; set; }
      public string codpro { get; set; }
      public string ctaact { get; set; }
      public string crefe { get; set; }
      public string nrefe { get; set; }
      //public DateTime frefe { get; set; }
      public string codi { get; set; }
      public string nplan { get; set; }
  }
  */


}
