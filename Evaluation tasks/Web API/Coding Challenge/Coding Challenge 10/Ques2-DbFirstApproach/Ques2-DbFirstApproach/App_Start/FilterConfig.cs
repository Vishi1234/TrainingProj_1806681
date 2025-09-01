using System.Web;
using System.Web.Mvc;

namespace Ques2_DbFirstApproach
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
