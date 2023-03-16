using LabNetPractica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabNetPractica3.EF.Exceptions
{
    public class DeleteException
    {
       
        public string CategoriesDeleteException() 
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            try
            {
                Console.WriteLine("Ingresa el ID de la categoria que queres eliminar. Recordá que solo podes eliminar las categorias que vos hayas creado");
                string numIngresado = Console.ReadLine();
                int idEliminar;
                bool parseando = int.TryParse(numIngresado, out idEliminar);

                if (parseando && idEliminar >= 8)
                {
                    categoriesLogic.Delete(idEliminar);
                    return ("La categoria se ha eliminado con exito");
                }
                else
                {                    
                    throw new FormatException("No ingresaste un número");
                }

            }
            catch (ArgumentNullException ex)
            {
                return ("Mensaje de la excepción: " + ex.Message);
            }
            catch (DataException)
            {

                return ("Mensaje de la excepción: No se puede eliminar los campos originales de esta base de datos.\nIntenta solo con los campos que vos hayas ingresado ");
            }

            catch (FormatException ex)
            {
                return "Mensaje de la excepción: " + ex.Message;
            }
        }


    }    
}
