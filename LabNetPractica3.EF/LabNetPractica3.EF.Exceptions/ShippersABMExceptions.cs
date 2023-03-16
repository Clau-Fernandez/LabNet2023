using LabNetPractica3.EF.Entities;
using LabNetPractica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.Exceptions
{
    public class ShippersABMExceptions:BaseLogic, IABMExceptions
    {
        ShippersLogic shippersLogic = new ShippersLogic();


        public string AddException()
        {
            try
            {
                Console.WriteLine("Ingresa el nombre de la Compañía");
                string companyName = Console.ReadLine();

                shippersLogic.Add(new Shippers
                {
                    CompanyName = companyName,
                });

                return ("El nombre de la compañía se ha agregado con exito");
            }
            catch (DataException)
            {
                shippersLogic = new ShippersLogic();
                return "Los campos no pueden quedar vacios ";
            }

        }

        public string DeleteException()
        {
            try
            {
                Console.WriteLine("Ingresa el ID de la compañía que queres eliminar. Recordá que solo podes eliminar las categorias que vos hayas creado");
                string numIngresado = Console.ReadLine();
                int idEliminar;
                int lastId = context.Shippers.Max(s => s.ShipperID);

                bool parseando = int.TryParse(numIngresado, out idEliminar);

                if (parseando && idEliminar >= 3 && idEliminar <= lastId)
                {
                    shippersLogic.Delete(idEliminar);
                    return ("La compañía se ha eliminado con exito");
                }
                else if (parseando)
                {
                    return ("El número ingresado no es valido. Intentalo de vuelta");
                }
                else
                {
                    throw new FormatException("No ingresaste un número");
                }
            }

            catch (FormatException ex)
            {
                return "Mensaje de la excepción: " + ex.Message;
            }
            catch (DataException)
            {
                shippersLogic = new ShippersLogic();
                return "No se puede eliminar un registro original de esta base de datos";
            }
        }


        public string UpdateException()
        {
            Console.WriteLine("Ingresa el ID del nombre de la compañia que queres modificar. Recordá que solo podes modificar los registros que vos hayas creado");

            try
            {
                string userAnswer = Console.ReadLine();
                int shipperId;
                int lastId = context.Shippers.Max(s => s.ShipperID);

                bool parseando = int.TryParse(userAnswer, out shipperId);

                if (parseando && shipperId >= 3 && shipperId <= lastId)
                {
                    Console.WriteLine("Ingresa el nuevo nombre de la compañía");
                    string newName = Console.ReadLine();

                    shippersLogic.Update(new Shippers
                    {
                        ShipperID = shipperId,
                        CompanyName = newName
                    });

                    return ("El nombre se ha modificado con exito");
                }
                else if (parseando)
                {
                    return ("El número ingresado no es valido. Intentalo de vuelta");
                }
                else
                {
                    throw new FormatException("No ingresaste un número.Intentalo de nuevo");
                }

            }
            catch (FormatException ex)
            {
                return ("Mensaje de la excepción: " + ex.Message);
            }


        }


    
    }
}
