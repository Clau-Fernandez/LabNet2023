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

            context.SaveChanges();

        }

        public string CategoriesQuery() 
        {
            var listfirstLetterWithC = "";
            var firstLetterWithC = context.Categories.Where(c => c.CategoryName.StartsWith("C")).ToList();

            foreach (var c in firstLetterWithC) 
            {
                listfirstLetterWithC += $"{c.CategoryName} - {c.Description}\n";
            }
            
            return listfirstLetterWithC;

        }


    }
}
