using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Electricity_Project.BusinessLogics
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(connStr);
        }

    }
}