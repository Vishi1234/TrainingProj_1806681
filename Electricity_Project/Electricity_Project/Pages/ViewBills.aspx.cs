using System;
using Electricity_Project.BusinessLogics;
using System.Collections.Generic;
using System.Linq;
using Electricity_Project;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Project.Pages
{
    public partial class ViewBills : System.Web.UI.Page
    {
        protected void btnGetBills_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(txtN.Text, out n))
            {
                ElectricityBoard board = new ElectricityBoard();
                List<ElectricityBill> bills = board.Generate_N_BillDetails(n);
                gvBills.DataSource = bills;
                gvBills.DataBind();
            }
        }
    }
}