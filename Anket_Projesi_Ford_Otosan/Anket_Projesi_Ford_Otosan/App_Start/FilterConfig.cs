using System.Web;
using System.Web.Mvc;

namespace Anket_Projesi_Ford_Otosan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
