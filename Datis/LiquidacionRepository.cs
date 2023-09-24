using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.IO;

namespace Datos
{
    public class LiquidacionRepository
    {
        string filePath = "LIQUIDACIONES.txt";
        public string GuardarRegistros(Liquidacion producto)
        {
            var write = new StreamWriter(filePath, true);
            write.WriteLine(producto.ToString());
            write.Close();
            return $"Registro almacenado";
        }
        public string Guardar(List<Liquidacion> liquidacionList)
        {
            var write = new StreamWriter(filePath);
            foreach (var i in liquidacionList)
            {
                write.WriteLine(i.ToString());
            }
            write.Close();
            return $"Registros cargados";
        }
        public List<Liquidacion> CargarRegistros()
        {
            var liquidacionList = new List<Liquidacion>();
            try
            {
                StreamReader reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    liquidacionList.Add(Map(reader.ReadLine()));
                }
                reader.Close();
                return liquidacionList;
            }
            catch (IOException)
            {
                return null;
            }
        }
        private Liquidacion Map(string linea)
        {
            var l = new Liquidacion();
            l.IdLiquidacion = linea.Split(';')[0];
            l.IdPaciente = linea.Split(';')[1];
            l.TipoAfiliacion = char.Parse(linea.Split(';')[2]);
            l.SalarioDevengado = double.Parse(linea.Split(';')[3]);
            l.valorHospitalizacion = double.Parse(linea.Split(';')[4]);
            l.ValorTotal = double.Parse(linea.Split(';')[5]);
            return l;
        }
    }
}
