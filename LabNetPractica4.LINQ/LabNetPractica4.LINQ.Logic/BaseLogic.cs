using LabNetPractica4.LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.Logic
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
