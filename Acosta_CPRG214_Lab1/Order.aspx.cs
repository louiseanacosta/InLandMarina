using MarinaBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acosta_CPRG214_Lab1
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check customer in session
            if(Session["customerFirstName"] == null || Session["customerLastName"] == null)
            {
                // redirect
                Response.Redirect("~/Register.aspx");
            }


        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            Customer customer = CustomerDB.GetCustomer(Session["customerFirstName"].ToString(), Session["customerLastName"].ToString());
            for(int i=0; i<GridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                Label lb=(Label)GridView1.Rows[i].FindControl("Label1");
                if (ch.Checked == true)
                {
                    // save lease
                    LeaseDB.SaveLease(Convert.ToInt32(lb.Text), customer.Id);

                    // add to list box
                    ListBox1.Items.Add(lb.Text.ToString());

                }
            }

            // forward to order page
            Response.Redirect("~/Order.aspx");

        }
    }
}