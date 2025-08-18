using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ValidatorApp 
{ 
   public partial class Validator : System.Web.UI.Page
   {
     protected void btnCheck_Click(object sender, EventArgs e)
     {
        string name = txtName.Text.Trim();
        string familyName = txtFamilyName.Text.Trim();
        string address = txtAddress.Text.Trim();
        string city = txtCity.Text.Trim();
        string zip = txtZip.Text.Trim();
        string phone = txtPhone.Text.Trim();
        string email = txtEmail.Text.Trim();

        string errorMsg = "";

        if (name == familyName)
            errorMsg += "Name must be different from Family Name.<br/>";

        if (address.Length < 2)
            errorMsg += "Address must be at least 2 characters.<br/>";

        if (city.Length < 2)
            errorMsg += "City must be at least 2 characters.<br/>";

        if (!Regex.IsMatch(zip, @"^\d{5}$"))
            errorMsg += "Zip Code must be exactly 5 digits.<br/>";

        if (!Regex.IsMatch(phone, @"^\d{2,3}-\d{7}$"))
            errorMsg += "Phone must be in format XX-XXXXXXX or XXX-XXXXXXX.<br/>";

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            errorMsg += "Email must be a valid email address.<br/>";

        lblResult.Text = string.IsNullOrEmpty(errorMsg) ? "✅ All inputs are valid!" : errorMsg;
     }
   }
}
