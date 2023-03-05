using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labNetPractica1
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            List<TransportePublico> transportes = new List<TransportePublico>();

            Console.WriteLine("¡Bienvenido/a a la aplicación RDP! Tu aplicación de registro de pasajeros.");

            Console.WriteLine("\nEmpecemos registrando los pasajeros de los taxis...");

            //-------------------TAXI----------------------------------

            for (int i = 0; i < 5; i++)
            {
                Taxi taxi = new Taxi();
                Console.WriteLine($"Ingresa la cantidad de pasajeros del {i + 1}° taxi");


                string valorIngresado = Console.ReadLine();
                int cantPasajeros;

                bool parsearCadenaAValorNumerico = int.TryParse(valorIngresado, out cantPasajeros);

                while (cantPasajeros < 0 || cantPasajeros > 4 || parsearCadenaAValorNumerico == false)
                {
                    Console.WriteLine("El valor ingresado no es correcto, recordá que en nuestros taxis solo pueden entrar como mucho cuatro pasajeros");
                    Console.WriteLine($"Volvamos a intentarlo...ingresa la cantidad de pasajeros para el {i + 1}° taxi");
                    valorIngresado = Console.ReadLine();
                    parsearCadenaAValorNumerico = int.TryParse(valorIngresado, out cantPasajeros);
                }

                taxi.SetPasajeros(cantPasajeros);
                taxi.SetNombre($"Taxi {i + 1}");
                transportes.Add(taxi);

                

            }

            //-------------------OMNIBUS----------------------------------
            Console.WriteLine("\nAhora pasemos a registrar los pasajeros de los ómnibus...");

            for (int i = 0; i < 5; i++)
            {
                Omnibus omnibus = new Omnibus();
                Console.WriteLine($"Ingresa la cantidad de pasajeros del {i + 1}° omnibus");
                

                string valorIngresado = Console.ReadLine();
                int cantPasajeros;

                bool parsearCadenaAValorNumerico = int.TryParse(valorIngresado, out cantPasajeros);

                while (cantPasajeros < 0 || cantPasajeros > 100 || parsearCadenaAValorNumerico == false)
                {
                    Console.WriteLine("El valor ingresado no es correcto, recordá que nuestros ómnibus tienen una capacidad máxima de 100 pasajeros");
                    Console.WriteLine($"Volvamos a intentarlo...ingresa la cantidad de pasajeros para el {i + 1}° omnibus");
                    valorIngresado = Console.ReadLine();
                    parsearCadenaAValorNumerico = int.TryParse(valorIngresado, out cantPasajeros);
                }

                omnibus.SetPasajeros(cantPasajeros);
                omnibus.SetNombre($"Ómnibus {i + 1}");
                transportes.Add(omnibus);
            }

            Console.WriteLine("\nListado de pasajeros ingresados");
            foreach (var item in transportes)
            {
                Console.WriteLine($"{item.GetNombre()} tiene: {item.GetPasajeros()} pasajeros");
            }
            

            //-------------------Probando Métodos----------------------------------

            bool seguirProbando = true;

            Console.WriteLine("\nNuestros transportes tienen algunas funciones que podes probar");
            while (seguirProbando)
            {
                Console.WriteLine("Funciones:");
                Console.WriteLine("-Taxis: \n 1.Avanzar \n 2.Detenerse \n 3.Calcular el precio del viaje");
                Console.WriteLine("-Ómnibus: \n 4.Avanzar \n 5.Detenerse ");
                Console.WriteLine("Si querés probar alguna ingresa el número correspondiente, si no, ingresa 'x' para salir ");
                string respuesta = Console.ReadLine();
                int numMetodo;

                if (respuesta.ToLower() == "x")
                {
                    Console.WriteLine("Gracias por usar la app, hasta pronto! :D ");
                    seguirProbando = false;

                }
                else if (int.TryParse(respuesta, out numMetodo) && numMetodo >= 1 && numMetodo <= 5)
                {
                    switch (numMetodo)
                    {
                        case 1:
                            Console.WriteLine(transportes[0].Avanzar());
                            break;
                        case 2:
                            Console.WriteLine(transportes[0].Detenerse());
                            break;
                        case 3:
                            Console.WriteLine("Ingresa la distancia, en metros, de tu viaje");
                            string distancia = Console.ReadLine();
                            double valor;
                            bool parsearDistancia = double.TryParse(distancia, out valor);
                            if (parsearDistancia == true)
                            {
                                if (transportes[0] is Taxi)
                                {
                                    Console.WriteLine("El costo del viaje es de:$" + ((Taxi)transportes[0]).CalcularPrecioViaje(valor));
                                }

                            }
                            else { Console.WriteLine("El valor ingresado no es correcto"); }

                            break;
                        case 4:
                            Console.WriteLine(transportes[transportes.Count-1].Avanzar());
                            break;
                        case 5:
                            Console.WriteLine(transportes[transportes.Count - 1].Detenerse());
                            break;
                    }

                    Console.WriteLine("¿Querés probar otra funcionalidad? (s/n)");
                    string noSeguir = Console.ReadLine();
                    if (noSeguir.ToLower() == "n")
                    {
                        seguirProbando = false;
                        Console.WriteLine("Gracias por usar la app, hasta pronto! :D ");
                    }


                }
                else { Console.WriteLine("No has ingresado un valor válido... intentalo de nuevo ;) "); }

            }

            Console.ReadLine();
        }
    }
}
