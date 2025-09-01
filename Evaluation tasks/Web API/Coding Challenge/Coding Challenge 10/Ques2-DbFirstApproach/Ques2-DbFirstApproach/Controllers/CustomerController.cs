using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ques2_DbFirstApproach.Controllers
{
    public class CustomersController : ApiController
    {
        private NorthWindEntities db = new NorthWindEntities();

        [HttpGet]
        [Route("api/customers/bycountry/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();

            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }
    }
}