using LabNetPractica3.EF.Entities;
using LabNetPractica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.UI
{
    public class MenuCategories : MenuBase
    {
        public override void ChooseMethodToExecute(int opcion) 
        {
            bool seguirProbando = true;
            do
            {
                switch (opcion)
                {
                    case 1:
                        DisplayLists displayLists = new DisplayLists();
                        Console.WriteLine(displayLists.CategoriesList());
                        break;
                    case 2:
                        CategoriesLogic categoriesLogic = new CategoriesLogic();
                        categoriesLogic.Add(new Categories {CategoryName = "prueba", Description="prueba" });
                        
                        break;
                    //case 3:
                       
                    //    break;
                    //case 4:
                       
                }

                


            } while (seguirProbando);
        }
    }
}
