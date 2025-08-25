using Electricity_Project.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Electricity_Project.Pages
{
    public partial class AddBill : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack && int.TryParse(Request.Form[txtConsumerCount.UniqueID], out int count))
            {
                GenerateConsumerFields(count);
            }
        }


        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            phConsumers.Controls.Clear();

            if (int.TryParse(txtConsumerCount.Text, out int count) && count > 0)
            {
                GenerateConsumerFields(count);
            }
            else
            {
                lblResult.Text = "Please enter a valid number of consumers.";
            }
        }


        private void GenerateConsumerFields(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                var panel = new Panel { CssClass = "consumer-block" };

                panel.Controls.Add(new Literal { Text = $"<h4>Consumer {i}</h4>" });

                panel.Controls.Add(new Literal { Text = "Consumer Number: " });
                panel.Controls.Add(new TextBox { ID = $"txtConsumerNumber{i}" });
                panel.Controls.Add(new Literal { Text = "<br/>" });

                panel.Controls.Add(new Literal { Text = "Consumer Name: " });
                panel.Controls.Add(new TextBox { ID = $"txtConsumerName{i}" });
                panel.Controls.Add(new Literal { Text = "<br/>" });

                panel.Controls.Add(new Literal { Text = "Units Consumed: " });
                panel.Controls.Add(new TextBox { ID = $"txtUnitsConsumed{i}" });
                panel.Controls.Add(new Literal { Text = "<br/><br/>" });

                phConsumers.Controls.Add(panel);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ElectricityBoard board = new ElectricityBoard();
            BillValidator validator = new BillValidator();
            List<string> results = new List<string>();

            if (int.TryParse(txtConsumerCount.Text, out int count) && count > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    var txtNumber = phConsumers.FindControl($"txtConsumerNumber{i}") as TextBox;
                    var txtName = phConsumers.FindControl($"txtConsumerName{i}") as TextBox;
                    var txtUnits = phConsumers.FindControl($"txtUnitsConsumed{i}") as TextBox;

                    if (txtNumber != null && txtName != null && txtUnits != null)
                    {
                        ProcessConsumer(txtNumber.Text, txtName.Text, txtUnits.Text, board, validator, results, i);
                    }
                    else
                    {
                        results.Add($"Consumer {i}: Missing input fields.");
                    }
                }

                lblResult.Text = string.Join("<br/>", results);
            }
            else
            {
                lblResult.Text = "Invalid consumer count.";
            }
        }

        private void ProcessConsumer(string number, string name, string unitsText, ElectricityBoard board, BillValidator validator, List<string> results, int index)
        {
            if (!int.TryParse(unitsText, out int units))
            {
                results.Add($"Consumer {index}: Units must be a number.");
                return;
            }

            if (validator.ValidateUnitsConsumed(units) != "Valid")
            {
                results.Add($"Consumer {index}: Invalid units.");
                return;
            }

            ElectricityBill bill = new ElectricityBill
            {
                ConsumerNumber = number,
                ConsumerName = name,
                UnitsConsumed = units
            };

            board.CalculateBill(bill);
            board.AddBill(bill);

            results.Add($"Consumer {index}: ₹{bill.BillAmount} added for {bill.ConsumerName}.");
        }
    }
}

