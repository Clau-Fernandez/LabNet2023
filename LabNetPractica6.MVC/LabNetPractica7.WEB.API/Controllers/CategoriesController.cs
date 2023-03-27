using LabNetPractica3.EF.Logic;
using LabNetPractica6_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LabNetPractica3.EF.Entities;
using LabNetPractica7.WEB.API.Models;

namespace LabNetPractica7.WEB.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoriesLogic categoriesLogic;

        public CategoriesController()
        {
            categoriesLogic = new CategoriesLogic();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var categories = categoriesLogic.GetAll();
                var categoryModels = new List<CategoryModel>();
                foreach (var category in categories)
                {
                    var categoryModel = new CategoryModel
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        Description = category.Description
                    };
                    categoryModels.Add(categoryModel);
                }
                return Ok(categoryModels);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var category = categoriesLogic.GetById(id);

                if (category == null)
                {
                    return NotFound();
                }

                var categoryModel = new CategoryModel
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                return Ok(categoryModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }
        public IHttpActionResult Post([FromBody] CategoryModel categoryModel)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Categories
            {
                CategoryName = categoryModel.CategoryName,
                Description = categoryModel.Description
            };

            categoriesLogic.Add(category);

            categoryModel.CategoryID = category.CategoryID;
            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, categoryModel);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        public IHttpActionResult Put(int id, [FromBody] CategoryModel categoryModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingCategory = categoriesLogic.GetById(id);

                if (existingCategory == null)
                {
                    return NotFound();
                }

                var category = new Categories
                {
                    CategoryID = id,
                    CategoryName = categoryModel.CategoryName,
                    Description = categoryModel.Description
                };

                categoriesLogic.Update(category);

                return Ok();
            }
            catch (Exception ex)
            { 
                return InternalServerError(ex);
            }
        }

        
        public IHttpActionResult Delete(int id)
        {
            try
            {
            var categoryToDelete = categoriesLogic.GetById(id);

            if (categoryToDelete == null)
            {
                return NotFound();
            }

            categoriesLogic.Delete(id);

            return Ok();

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        
    }
}


