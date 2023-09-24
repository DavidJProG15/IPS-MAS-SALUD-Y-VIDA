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
        public char TipoAfiliacion { get; set; }
        public double SalarioDevengado { get; set; }
        public double valorHospitalizacion { get; set; }
        public double SalarioMinimo { get; set; } 
        public double ValorTotal { get; set; }
        
        public Liquidacion(string idLiquidacion, string idPaciente, char tipoAfiliacion, double salarioDevengado, double valorHospitalizacion )
        {
            this.IdLiquidacion = idLiquidacion;
            this.IdPaciente = idPaciente;
            this.TipoAfiliacion = tipoAfiliacion;
            this.SalarioDevengado = salarioDevengado;
            this.valorHospitalizacion = valorHospitalizacion;
            this.SalarioMinimo = 1160000;
            //salariominimo = 1160000;
        }
        public Liquidacion() { }

        public double TarifaContributiva()
        {
            if (TipoAfiliacion == 'S')
            {
                SalarioDevengado = 0;
                return SalarioDevengado;

            }
            else if(TipoAfiliacion == 'C')
            {
                if (SalarioDevengado < SalarioMinimo * 2)
                {
                    ValorTotal = (SalarioDevengado * 0.15);
                    if (ValorTotal > 250000)
                    {
                        ValorTotal = 250000;
                    }
                }
                else if ((SalarioDevengado > SalarioMinimo * 2) && (SalarioDevengado < SalarioMinimo * 5))
                {
                    ValorTotal = (SalarioDevengado * 0.20);
                    if ((ValorTotal > 900000 ))
                    {
                        ValorTotal = 900000;
                    }
                }
                else if (SalarioDevengado > SalarioMinimo * 5)
                {
                    ValorTotal = (SalarioDevengado * 0.25);                    
                        
                        if (ValorTotal > 1500000)
                        {
                            ValorTotal = 1500000;
                        }
                    
                }
                
            }
            return ValorTotal;
        }
        

        public override string ToString()
        {
            return $"{IdLiquidacion};{IdPaciente};{TipoAfiliacion};{SalarioDevengado};{valorHospitalizacion};{SalarioMinimo};" +
                $"{ValorTotal}";
        }
    } 
}
