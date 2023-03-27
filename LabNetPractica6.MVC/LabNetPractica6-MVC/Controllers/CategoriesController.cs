using LabNetPractica3.EF.Logic;
using LabNetPractica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabNetPractica6_MVC.Models;
using System.Web.UI.WebControls;

namespace LabNetPractica6_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();
       
        public ActionResult Index()
        {
            List<Categories> listOfCategories = categoriesLogic.GetAll();

            List<CategoryView> categoryViews = listOfCategories.Select(c=> new CategoryView 
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description,
            }).ToList();

            return View(categoryViews);

        }
        public ActionResult Insert() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryView categoryView) 
        {
            try
            {
                Categories categoryEntity = new Categories 
                {   CategoryName = categoryView.CategoryName,
                    Description = categoryView.Description };
                categoriesLogic.Add(categoryEntity);
                return RedirectToAction("Index");
            }
            catch (Exception )
            {
                return RedirectToAction("Error", "Error", new { errorMessage = "Se ha producido un error" });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                categoriesLogic.Delete(id);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Error", new { errorMessage = "No se pueden borrar elementos originales de la base de datos" });
            }
        }

        public ActionResult Update(int id)
        {
            var categoryToUpdate = categoriesLogic.GetById(id);

            if (categoryToUpdate == null)
            {
                return RedirectToAction("Index");
            }

            CategoryView categoryView = new CategoryView
            {
                CategoryID = categoryToUpdate.CategoryID,
                CategoryName = categoryToUpdate.CategoryName,
                Description = categoryToUpdate.Description,
            };

            return View(categoryView);
        }

        [HttpPost]
        public ActionResult Update(CategoryView categoryView)
        {
            try
            {
                Categories categoryEntity = new Categories
                {
                    CategoryID = categoryView.CategoryID,
                    CategoryName = categoryView.CategoryName,
                    Description = categoryView.Description
                };

                categoriesLogic.Update(categoryEntity);

                return RedirectToAction("Index");
            }
            catch (Exception )
            {
                return RedirectToAction("Error", "Error", new { errorMessage = "Se ha producido un error" });
            }
        }
    


        public ActionResult CategoriesStartingWithC()
        {
            List<Categories> categoriesStartingWithC = categoriesLogic.GetCategoriesStartingWithC();

            List<CategoryView> categoryViews = categoriesStartingWithC.Select(c => new CategoryView
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description,
            }).ToList();

            return View("CategoriesStartingWithC", categoryViews);
        }


    }
}
