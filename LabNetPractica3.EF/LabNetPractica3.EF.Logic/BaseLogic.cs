using LabNetPractica3.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext context;
        public BaseLogic() 
        {
            context = new NorthwindContext();
        }
    }
}
