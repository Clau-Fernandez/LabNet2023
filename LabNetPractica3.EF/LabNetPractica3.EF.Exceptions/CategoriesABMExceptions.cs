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
    public class CategoriesABMExceptions: BaseLogic, IABMExceptions
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();


        public string AddException()
        {
            try
            {
                Console.WriteLine("Ingresa el nombre de la categoría");
                string categoryName = Console.ReadLine();

                Console.WriteLine("Ingresa una breve descripción");
                string categoryDescription = Console.ReadLine();

                categoriesLogic.Add(new Categories
                {
                    CategoryName = categoryName,
                    Description = categoryDescription
                });
                
                return ("La categoria se ha agregado con exito");
            }
            catch (DataException)
            {
                categoriesLogic = new CategoriesLogic();
                return "Los campos no pueden quedar vacios " ;
            }
            
        }

        public string DeleteException() 
        {
            try
            {
                Console.WriteLine("Ingresa el ID de la categoria que queres eliminar. Recordá que solo podes eliminar las categorias que vos hayas creado");
                string numIngresado = Console.ReadLine();
                int idEliminar;
                int lastId = context.Categories.Max(c => c.CategoryID);

                bool parseando = int.TryParse(numIngresado, out idEliminar);
                
                if (parseando && idEliminar >= 8 && idEliminar <= lastId)
                {
                    categoriesLogic.Delete(idEliminar);
                    return ("La categoria se ha eliminado con exito");
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
                categoriesLogic = new CategoriesLogic();
                return "No se puede eliminar un registro original de esta base de datos";
            }
        }


        public string UpdateException() 
        {
            Console.WriteLine("Ingresa el ID de la categoria que queres modificar. Recordá que solo podes modificar las categorias que vos hayas creado");

            try
            {
                string userAnswer = Console.ReadLine();
                int categoryId;
                int lastId = context.Categories.Max(c => c.CategoryID);

                bool parseando = int.TryParse(userAnswer, out categoryId);

                if (parseando && categoryId >= 8 && categoryId <= lastId)
                {
                    Console.WriteLine("Ingresa la nueva descripción");
                    string newDescription = Console.ReadLine();

                    categoriesLogic.Update(new Categories
                    {
                        CategoryID = categoryId,
                        Description = newDescription
                    });
                    
                    return ("La categoria se ha modificado con exito");
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
