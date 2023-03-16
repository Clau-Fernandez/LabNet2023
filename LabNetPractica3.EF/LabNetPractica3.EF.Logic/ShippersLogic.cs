using LabNetPractica3.EF.Data;
using LabNetPractica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.Logic
{
    public class ShippersLogic: BaseLogic, IABMLogic<Shippers>
    {
        public List<Shippers> GetAll() 
        {
            return context.Shippers.ToList();
        }

        public void Add(Shippers newShipper)
        {
            context.Shippers.Add(newShipper);
        }

        public void Delete(int id)
        {
            var shipperToDelete = context.Shippers.Find(id);
            context.Shippers.Remove(shipperToDelete);

            context.SaveChanges();

            var lastShipperId = context.Shippers.Max(s => s.ShipperID);
            var connection = context.Database.Connection;
            var command = connection.CreateCommand();
            command.CommandText = $"DBCC CHECKIDENT('[dbo].[Shippers]', RESEED, {lastShipperId});";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void Update(Shippers shipper)
        {
            var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
            shipperUpdate.CompanyName = shipper.CompanyName;

            context.SaveChanges();
        }


        public string ShippersQuery()
        {
            var containsUnited = "";
            var result = context.Shippers.Where(s => s.CompanyName.Contains("United")).ToList();
            
            foreach (var s in result)
            {
                containsUnited += $"{s.CompanyName} - ID:{s.ShipperID}\n";
            }

            return containsUnited;

        }
    }
}
