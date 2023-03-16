using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.UI
{
    public abstract class MenuBase
    {
        public void ShowMenu()
        {
            Console.WriteLine("Tenes diferentes métodos para probar");
            Console.WriteLine("1. Mostrar lista completa");
            Console.WriteLine("2. Agregar un nuevo registro");
            Console.WriteLine("3. Modificar un registro");
            Console.WriteLine("4. Eliminar un registro");
            Console.WriteLine("5. Probar una consulta");

        }

        abstract public void ChooseMethodToExecute(int opcion);
        
    }
}
