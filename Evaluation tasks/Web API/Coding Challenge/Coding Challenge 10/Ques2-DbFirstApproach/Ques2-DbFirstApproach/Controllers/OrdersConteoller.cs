using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ques2_DbFirstApproach.Controllers
{
    public class OrdersConteoller : ApiController
    {
        private NorthWindEntities db = new NorthWindEntities();

        [HttpGet]
        [Route("api/orders/buchanan")]
        public IHttpActionResult GetOrdersForBuchanan()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .ToList();

            return Ok(orders);
        }
    }

}