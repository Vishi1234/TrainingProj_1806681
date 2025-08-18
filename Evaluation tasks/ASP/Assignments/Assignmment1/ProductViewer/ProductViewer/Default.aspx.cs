using System;
using System.Collections.Generic;

namespace ProductViewer
{
    public partial class Default : System.Web.UI.Page
    {
        // Product data: name, image path, and price
        Dictionary<string, (string imageUrl, double price)> products = new Dictionary<string, (string, double)>
        {
            { "Laptop", ("images/laptop.jpg", 75000) },
            { "Smartphone", ("images/phone.jpg", 45000) },
            { "Headphones", ("images/headphones.jpg", 2500) },
            { "Smartwatch", ("images/watch.jpg", 12000) }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Clear();
                ddlProducts.Items.Add("Select a product");
                foreach (var product in products.Keys)
                {
                    ddlProducts.Items.Add(product);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                imgProduct.ImageUrl = products[selected].imageUrl;
                lblPrice.Text = "";
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                lblPrice.Text = $"Price: ₹{products[selected].price:N0}";
            }
            else
            {
                lblPrice.Text = "Please select a valid product.";
            }
        }
    }
}
