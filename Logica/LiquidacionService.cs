using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.IO;

namespace Logica
{
    public class LiquidacionService
    {
        private LiquidacionRepository productoRepository = null;
        private List<Liquidacion> productoList = null;
        public LiquidacionService()
        {
            productoRepository = new LiquidacionRepository();
            productoList = productoRepository.CargarRegistros();

        }

        public String GuardarRegistros(Liquidacion producto)
        {
            if (producto.IdLiquidacion == null || producto.valorHospitalizacion == 0
                || producto.TipoAfiliacion == null || producto.IdPaciente == null)
            {
                return $"Campos nulos";
            }
            var message = (productoRepository.GuardarRegistros(producto));
            productoList = productoRepository.CargarRegistros();
            return message;
        }
        public List<Liquidacion> CargarRegistros()
        {
            return productoList;
        }
        public string EliminarRegistro(string idAEliminar)
        {
            try
            {
                var productoAEliminar = productoList.FirstOrDefault(p => p.IdPaciente == idAEliminar);

                if (productoAEliminar != null)
                {
                    productoList.Remove(productoAEliminar);
                    productoRepository.Guardar(productoList);
                    return "Registro eliminado con éxito.";
                }
                else
                {
                    return "No se encontró un registro con el ID proporcionado.";
                }
            }
            catch (IOException)
            {
                return "Ocurrió un error al intentar eliminar el registro.";
            }
        }
    }
}

