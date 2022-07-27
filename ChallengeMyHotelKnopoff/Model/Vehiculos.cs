using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeMyHotel.Model
{

    internal class Vehiculos
    {
        #region miembros privados
        private bool ExisteVehiculoPorPatente(string patente)
        {
            foreach (Vehiculo vh in Listado)
            {
                if (vh.Patente.Trim().ToUpper() == patente.Trim().ToUpper())
                    return true;
            }
            return false;
        }
        #endregion

        #region metodos privados

        #endregion
        #region miembros publicos

        public List<Vehiculo> Listado { get; private set; } = new List<Vehiculo>();
        #endregion

        #region metodos publicos
        public Resultado Agregar(Vehiculo vh)
        {
            Resultado res = new Resultado();
            if (!ExisteVehiculoPorPatente(vh.Patente))
            {
                Listado.Add(vh);
                res.AsignarResultado(true, "Vehículo agregado");
            }
            else
            {
                res.AsignarResultado(false, "El vehículo ya existe en la lista");
                //podriamos tambien, en vez de deveolver el resultado, generar una excepción
                //throw new Exception("El vehículo ya existe en el listado");
            }
            return res;

        }
        public Resultado Agregar(string patente, int anio, string modelo)
        {
            return Agregar(new Vehiculo(patente, anio, modelo));
        }

        public void Quitar(Vehiculo vh)
        {
            /// <summary>
            /// Si existe el vehículo, lo remuevo
            /// </summary>
            if (!ExisteVehiculoPorPatente(vh.Patente))
            {
                Listado.Remove(vh);
            }
        }

        public void ActualizarEstado(string modelo1, string modelo2)
        {
            /// <summary>
            /// Si alguno de los dos modelos existen, actualiza el Estado
            /// </summary>
            foreach (Vehiculo v in Listado.Where(x => x.Modelo == modelo1 || x.Modelo == modelo2))
            {
                v.Estado = EstadoVehiculoEnum.Vendido;
            }
        }
        public List<Vehiculo> OrdenarPorAnio()
        {
            //esto tambien se puede hacer de la siguiente manera
            // Listado.Sort((x, y) => string.Compare(x.Patente, y.Patente));

            return Listado.OrderBy(x => x.Anio).ToList();
        }

        public List<Vehiculo> ObtenerRango(int n)
        {
            return Listado.GetRange(0, n);
        }
        public List<Vehiculo> FiltrarPatentesDigitosRepetidos(List<string> palabras)
        {
            List<Vehiculo> auxVehiculos = Listado.ToList();
            foreach (Vehiculo v in Listado)
            {
                foreach (string l in palabras)
                {
                    if (v.Patente.Contains(l))
                    {
                        auxVehiculos.Remove(v);
                    }
                }
            }
            return auxVehiculos;
        }
        #endregion







    }
}
