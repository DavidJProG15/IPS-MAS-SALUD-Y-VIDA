using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Liquidacion
    {
        public string IdLiquidacion { get; set; }
        public string IdPaciente { get;set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioDevengado { get; set; }
        public double valorHospitalizacion { get; set; }
        public double SalarioMinimo { get; set; }
        public double ValorTotal { get; set; }

        public Liquidacion(string idLiquidacion, string idPaciente, double salarioDevengado1, string tipoAfiliacion, double salarioDevengado, double valorHospitalizacion, double salariominimo)
        {
            this.IdLiquidacion = idLiquidacion;
            this.IdPaciente = idPaciente;
            this.TipoAfiliacion = tipoAfiliacion;
            this.SalarioDevengado = salarioDevengado;
            this.valorHospitalizacion = valorHospitalizacion;
            this.SalarioMinimo = salariominimo;
        }
        public Liquidacion() { }

        public double TarifaContributiva()
        {
            SalarioMinimo = 1160000;
            if (SalarioDevengado < SalarioMinimo * 2)
            {
                ValorTotal = (SalarioDevengado * 0.15);
                if (ValorTotal < SalarioDevengado * 2)
                {
                    ValorTotal = 250000;
                }
            }
            else if ((SalarioDevengado > SalarioMinimo * 2) && (SalarioDevengado < SalarioMinimo * 5))
            {
                ValorTotal = (SalarioDevengado * 0.20);
                if ((ValorTotal > SalarioMinimo * 2) && (ValorTotal < SalarioMinimo * 5))
                {
                    ValorTotal = 900000;
                }
            }
            else if (SalarioDevengado > SalarioMinimo * 5)
            {
                ValorTotal = (SalarioDevengado * 0.25);
                if (ValorTotal < SalarioDevengado * 2)
                {
                    ValorTotal = 250000;
                    if (ValorTotal > SalarioDevengado * 5)
                    {
                        ValorTotal = 1500000;
                    }
                }
            }
            return ValorTotal;
        }
        public double TarifaSubsidiada()
        {
            SalarioDevengado = 0;
            return SalarioDevengado;
        }

        public override string ToString()
        {
            return $"{IdLiquidacion};{IdPaciente};{TipoAfiliacion};{SalarioDevengado};{valorHospitalizacion};{SalarioMinimo};" +
                $"{ValorTotal}";
        }
    } 
}
