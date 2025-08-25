using System;
using System.Data;
using System.Data.SqlClient;

namespace YourNamespace
{
    public partial class ConsumerActions : System.Web.UI.Page
    {
        string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=ElectricityBill;Integrated Security=True";

        protected void btnAddConsumer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBill.aspx");
        }


        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ElectricityBillTable";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string output = "<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse;'>";
                output += "<tr><th>Consumer Number</th><th>Consumer Name</th><th>Units Consumed</th><th>Bill Amount</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    output += "<tr>";
                    output += $"<td>{row["consumer_number"]}</td>";
                    output += $"<td>{row["consumer_name"]}</td>";
                    output += $"<td>{row["units_consumed"]}</td>";
                    output += $"<td>{row["bill_amount"]}</td>";
                    output += "</tr>";
                }

                output += "</table>";

                lblOutput.Text = output;
                pnlOutput.Visible = true;
            }
        }


        // Step 1: Reveal input panel
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            pnlConsumerInput.Visible = true;
            pnlOutput.Visible = false;
        }

        // Step 2: Fetch and show details
        protected void btnShowDetails_Click(object sender, EventArgs e)
        {
            string consumerNumber = txtConsumerNumber.Text.Trim();

            if (string.IsNullOrEmpty(consumerNumber))
            {
                lblOutput.Text = "Please enter a valid consumer number.";
                pnlOutput.Visible = true;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ElectricityBillTable WHERE consumer_number = @ConsumerNumber";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ConsumerNumber", consumerNumber);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblOutput.Text = $"Consumer Number: {reader["consumer_number"]}, Name: {reader["consumer_name"]}, Units: {reader["units_consumed"]}, Bill: ₹{reader["bill_amount"]}";
                }
                else
                {
                    lblOutput.Text = "Consumer not found.";
                }

                pnlOutput.Visible = true;
                conn.Close();
            }
        }

        private void ShowMessage(string message)
        {
            lblOutput.Text = message;
            pnlOutput.Visible = true;
        }
    }
}
