
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace Ques2_DbFirstApproach
{
    public partial class CustomerModel
    {
        public virtual ObjectResult<Customer> GetCustomersByCountry_Result(string country)
        {
            var countryParam = new ObjectParameter("Country", country);
            return ((IObjectContextAdapter)this).ObjectContext
                   .ExecuteFunction<Customer>("GetCustomersByCountry_Result", countryParam);
        }
    }

}