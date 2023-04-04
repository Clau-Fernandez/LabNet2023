using System.Web;
using System.Web.Mvc;

namespace LabNetPractica7.WEB.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
