using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class StaffTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["LoginID"] == null)  // no such value in session state
             {
                 Response.Redirect("index.html");
             }       
             else      
             {
                 lblLoginID.Text = Session["LoginID"].ToString();

                 //retrieve log in time from ession
                 lblLoginDateTime.Text = "You have logged in since " + Session["LoggedInTime"].ToString();

                 //display number of users online
                 lblCurrentUser.Text = "There are currently " + Application["CurrentUsers"].ToString() + " user (s)";
             } 
        }
    }
}