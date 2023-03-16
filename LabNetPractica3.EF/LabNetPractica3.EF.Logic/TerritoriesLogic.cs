using LabNetPractica3.EF.Data;
using LabNetPractica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public List<Territories> GetAll()
        {
            return context.Territories.ToList();

        }
        public void Add(Territories newTerritory)
        {
            context.Territories.Add(newTerritory);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var territoryToDelete = context.Territories.Find(id);
            context.Territories.Remove(territoryToDelete);

            context.SaveChanges();
        }

        public void Update(Territories territory)
        {
            var territoryUpdate = context.Territories.Find(territory.TerritoryID);
            territoryUpdate.TerritoryDescription = territory.TerritoryDescription;

            context.SaveChanges();

        }

    }
}
