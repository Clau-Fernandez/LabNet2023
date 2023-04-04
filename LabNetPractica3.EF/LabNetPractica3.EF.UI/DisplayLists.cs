using LabNetPractica3.EF.Entities;
using LabNetPractica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.UI
{
    public class DisplayLists
    {
        public string CategoriesList() 
        {   
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            string listOfCategories = "";

            foreach (Categories category in categoriesLogic.GetAll())
            {
                listOfCategories += $"{category.CategoryID} - {category.CategoryName} - {category.Description}\n";
            }
            
            return listOfCategories;
            
        }

        public string ShippersList() 
        {
            ShippersLogic shippersLogic = new ShippersLogic();
            string listOfCategories = "";

            foreach (Shippers shipper in shippersLogic.GetAll())
            {
                listOfCategories += $"{shipper.ShipperID} - {shipper.CompanyName}\n";
            }

            return listOfCategories;
        }


    }
}
