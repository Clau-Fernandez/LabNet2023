using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    internal class Program
    {       

        static void Main(string[] args)
        {

            bool seguirProbando = true;

                Console.WriteLine("Bienvenido/a a la aplicación: Probando Métodos");
            do
            {
                Console.WriteLine("\nA continuación te mostramos nuestra lista de métodos:\n");

                int opcion = Validaciones.ValidandoMenu();

                
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine(MisMetodosExcepciones.ProbandoDividirPorCero());
                        break;
                    case 2:
                        Console.WriteLine(MisMetodosExcepciones.ProbandoDividir());
                        break;
                    case 3:
                        try
                        {
                            Logic.MetodoQueLanzaExcepcion();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Se ha capturado una excepción!");
                            Console.WriteLine($"Tipo de excepción: {ex.GetType()}");
                            Console.WriteLine($"Mensaje: {ex.Message}");
                        }
                        break;
                    case 4:
                        try
                        {
                            MiExcepcionPersonalizada.MetodoQueLanzaExcepcionPersonalizada();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Se ha capturado una excepción!");
                            Console.WriteLine($"Tipo de excepción: {ex.GetType()}");
                            Console.WriteLine($"Mensaje: {ex.Message}");
                        }
                        break;
                }

                if ( opcion == 0) { break; }
                
                else 
                {

                    Console.WriteLine("\n¿Querés seguir probando métodos? Ingresa 's' para continuar o cualquier otra tecla para salir.");

                    string respuesta = Console.ReadLine();

                    if (respuesta.ToLower() != "s")
                    {
                        seguirProbando = false;
                        return;
                    }

                }


            } while (seguirProbando);


            Console.ReadLine();
        }
    }
}
