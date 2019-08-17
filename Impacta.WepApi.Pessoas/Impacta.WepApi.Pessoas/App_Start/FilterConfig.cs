using System.Web;
using System.Web.Mvc;

namespace Impacta.WepApi.Pessoas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
