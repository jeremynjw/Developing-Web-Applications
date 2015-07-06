using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void menuAdmin_MenuItemClick(object sender, MenuEventArgs e)
        {
            if(e.Item.Value == "Logout")
            {
                Session.Abandon(); // kill all session variables
                Response.Redirect("Index.html"); // redirect to start page
            }
        }
    }
}