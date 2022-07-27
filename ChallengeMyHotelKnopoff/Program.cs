using ChallengeMyHotel.Model;
using System;
using System.Collections.Generic;

namespace ChallengeMyHotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehiculos vehiculos = new Vehiculos();
            vehiculos.CargarVehiculos();
            
            //Imprimo la lista original     
            vehiculos.Listado.ImprimirVehiculos("Lista de vehículos original");  
            
            //Copio en una nueva lista y la ordeno por antigüedad y obtengo los 10 más viejos
            List<Vehiculo> masAntiguos = vehiculos.OrdenarPorAnio().GetRange(0,10);
            masAntiguos.ImprimirVehiculos("Lista de los 10 más antiguos");

            //Cambio estado a Vendido
            vehiculos.ActualizarEstado("Chery","Maserati");
            vehiculos.Listado.ImprimirVehiculos("Cambio a Vendido");

            //Creo lista de caracteres repetidos
            List<string> palabras = listaDobleDigito();
            //Chequeo si hay patentes repetidas y las remuevo
            List<Vehiculo> sinPatentesConDigitosRepetidos = vehiculos.FiltrarPatentesDigitosRepetidos(palabras);
            sinPatentesConDigitosRepetidos.ImprimirVehiculos("Vehículos cuya patente no tiene dígitos repetidos seguidos");
            
            Console.ReadLine();
        }

        private static List<string>listaDobleDigito ()
        {
            List<string> palabras = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                palabras.Add(Convert.ToString($"{i}{i}"));
            }
            return palabras;
        }
            }

    /// <summary>
    /// clase para extensiones de vehiculos
    /// </summary>
    internal static class ExtensionesVehiculosConsola
    {
        public static void ImprimirVehiculos(this List<Vehiculo> listadoVehiculos, string titulo ="")
        {
            if(!string.IsNullOrEmpty(titulo))
            {
                Console.WriteLine(titulo );
            }
            foreach (Vehiculo vh in listadoVehiculos)
            {
                Console.WriteLine(vh.ToString());
            }
            Console.WriteLine();
        }

        public static void CargarVehiculos(this Vehiculos listadoVehiculos)
        {
            Random random = new Random();
            //Creo lista random
            for (int i = 10; i < 34; i++)
            {
                listadoVehiculos.Agregar("A" + i, random.Next(2000, 2020), "Chery");
            }
        }
    }
 

}
