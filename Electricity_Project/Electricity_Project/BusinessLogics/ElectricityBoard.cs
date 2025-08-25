using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Electricity_Project.BusinessLogics
{

    public class ElectricityBoard
    {
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units > 100)
            {
                units -= 100;
                amount += Math.Min(units, 200) * 1.5;
                units = Math.Max(units - 200, 0);
                amount += Math.Min(units, 300) * 3.5;
                units = Math.Max(units - 300, 0);
                amount += Math.Min(units, 400) * 5.5;
                units = Math.Max(units - 400, 0);
                amount += units * 7.5;
            }

            ebill.BillAmount = amount;
        }

        public void AddBill(ElectricityBill ebill)
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=ElectricityBill;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ElectricityBillTable (consumer_number, consumer_name, units_consumed, bill_amount) VALUES (@num, @name, @units, @amount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=ElectricityBill;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT TOP {n} * FROM ElectricityBillTable ORDER BY consumer_number DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ElectricityBill ebill = new ElectricityBill
                    {
                        ConsumerNumber = reader["consumer_number"].ToString(),
                        ConsumerName = reader["consumer_name"].ToString(),
                        UnitsConsumed = Convert.ToInt32(reader["units_consumed"]),
                        BillAmount = Convert.ToDouble(reader["bill_amount"])
                    };
                    bills.Add(ebill);
                }
            }
            return bills;
        }
    }
    }