using MarinaBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acosta_CPRG214_Lab1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // clear session
            

        }

        protected void uxRegister_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                FirstName = uxFirstName.Text,
                LastName = uxLastName.Text,
                Phone = uxPhone.Text,
                City = uxCity.Text
            };

            // try saving then check
            if (CustomerDB.SaveCustomer(customer))
            {
                // saved
                customer = CustomerDB.GetCustomer(customer.FirstName, customer.LastName);
                Session.Add("customerFirstName", customer.FirstName);
                Session.Add("customerLastName", customer.LastName);

                // forward to order page
                Response.Redirect("~/Order.aspx");
            }
            else
            {
                // not saved
                // show error
                uxError.Text = "Failed Saving";
                Session.Abandon();
            }
        }
    }
}