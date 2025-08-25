using NorthWind_Proj;
//using NorthWind_Proj.Models;
using System.Linq;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class CodeController : Controller
    {
        NorthWindEntities db = new NorthWindEntities();

        public ActionResult GermanyCustomer()
        {
            var germanCustomers = db.Customers
                                     .Where(c => c.Country == "Germany")
                                     .ToList();
            return View(germanCustomers);
        }

        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();
            return View(customer);
        }
    }
}
