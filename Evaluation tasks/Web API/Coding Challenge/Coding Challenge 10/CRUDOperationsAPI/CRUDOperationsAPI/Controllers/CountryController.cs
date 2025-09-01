
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static CRUDOperationsAPI.Models.CountryModel;

namespace CRUDOperationsAPI.Controllers
{
    public class CountryController : ApiController
    {

        static List<Country> countryData = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "UK", Capital = "London" }
        };

        public IHttpActionResult Get()
        {
            return Ok(countryData);
        }

        public IHttpActionResult Get(int id)
        {
            var country = countryData.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            else 
                return Ok(country);
        }

        public IHttpActionResult Post([FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");
            else
                country.ID = countryData.Max(c => c.ID);
                country.ID = country.ID + 1;
                countryData.Add(country);
                return Created($"api/Country/{country.ID}", country);
        }

        public IHttpActionResult Put(int id, [FromBody] Country newCountry)
        {
            var country = countryData.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            else 
                country.CountryName = newCountry.CountryName;
                country.Capital = newCountry.Capital;
                return Ok(country);
        }

        public IHttpActionResult Delete(int id)
        {
            var country = countryData.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            else 
                countryData.Remove(country);
                return Ok();

        }
    }
}