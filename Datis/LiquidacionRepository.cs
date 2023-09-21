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
        public string GuardarArchivo(Liquidacion liquidacion)
        {
            var write = new StreamWriter(filePath, true);
            write.WriteLine(liquidacion.ToString());
            write.Close();
            return $"El registro se ha guardado correctamente";
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
        private Liquidacion Map(string line)
        {
            var liquidacion = new Liquidacion();
            var datos = line.Split(';');
            return liquidacion;

        }
    }
}
