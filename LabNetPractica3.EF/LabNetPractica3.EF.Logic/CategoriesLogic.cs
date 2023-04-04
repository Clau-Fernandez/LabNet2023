using LabNetPractica3.EF.Data;
using LabNetPractica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LabNetPractica3.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {       
        public List<Categories> GetAll() 
        {
            return context.Categories.ToList();

        }

        public void Add(Categories newCategory) 
        {
            context.Categories.Add(newCategory);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToDelete = context.Categories.Find(id);
            context.Categories.Remove(categoryToDelete);

            context.SaveChanges();
            
            var lastCategoryId = context.Categories.Max(c => c.CategoryID);
            var connection = context.Database.Connection;
            var command = connection.CreateCommand();
            command.CommandText = $"DBCC CHECKIDENT('[dbo].[Categories]', RESEED, {lastCategoryId});";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
          
        }

        public void Update(Categories category)
        {
            var categoryUpdate = context.Categories.Find(category.CategoryID);
            categoryUpdate.Description =category.Description;
            categoryUpdate.CategoryName = category.CategoryName;

            context.SaveChanges();

        }

        public Categories GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public List<Categories> GetCategoriesStartingWithC()
        {
            return context.Categories.Where(c => c.CategoryName.StartsWith("C")).ToList();
        }


    }
}
