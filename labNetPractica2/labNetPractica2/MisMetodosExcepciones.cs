using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public static class MisMetodosExcepciones
    {
        public static string ProbandoDividirPorCero()
        {
            string estadoDeLaOperacion = "";

            try
            {
                Console.WriteLine("Ingresa un número entero para realizar la operación");
                string numIngresado = Console.ReadLine();
                int numero;
                bool parseando = int.TryParse(numIngresado, out numero);

                if (parseando)
                {
                    int resultado = MisMetodos.DividirPorCero(numero);
                    estadoDeLaOperacion = "exitosa";
                    return ("El resultado es: " + resultado.ToString());
                }
                else
                {
                    estadoDeLaOperacion = "falló";
                    throw new FormatException("No ingresaste un número");
                }
            }
            catch (DivideByZeroException ex)
            {
                estadoDeLaOperacion = "falló";
                return ("Mensaje de la excepción: " + ex.Message);
            }
            catch (FormatException ex)
            {
                estadoDeLaOperacion = "falló";
                return "Mensaje de la excepción: " + ex.Message;
            }
            finally
            {
                Console.WriteLine($"La operación ha terminado.\nEstado de la operación: {estadoDeLaOperacion}");
            }

        }

        public static string ProbandoDividir()
        {
            double dividendo;
            double divisor;
            try
            {
                Console.Write("Ingrese el dividendo: ");
                dividendo = double.Parse(Console.ReadLine());
                Console.Write("Ingrese el divisor: ");
                divisor = double.Parse(Console.ReadLine());

                if (divisor == 0)
                {
                    throw new DivideByZeroException("No no no ¿qué estamos haciendo?...recuerda que no se puede dividir por cero!");
                }

                double resultado = MisMetodos.Division(dividendo, divisor);
                return "El resultado es: " + resultado.ToString();
            }
            catch (DivideByZeroException ex)
            {
                return ex.Message;
            }
            catch (FormatException ex)
            {
                return "Seguro ingresaste una letra o no ingresaste nada!" + ex.Message;
            }
            finally
            {
                Console.WriteLine("Terminó la ejecución de este método.");
            }
        }





    } 
}