using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CinemaWatch
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
