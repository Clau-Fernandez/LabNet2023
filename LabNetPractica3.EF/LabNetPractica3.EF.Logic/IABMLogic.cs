using LabNetPractica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.Logic
{
    interface IABMLogic <T>
    {
        List<T> GetAll();
        void Add(T newCategory);
        void Delete(int id);
        void Update(T newCategory);




    }
}
