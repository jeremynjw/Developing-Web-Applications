using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { 
        // Read inputs from HTML form sent using the POST method  
        // from the previous page 
            string loginID = Request.Form["LoginID"].ToLower(); //Textbox: LoginID     
            string password = Request.Form["Password"]; //Textbox: Password     
            string userType = Request.Form["User"]; //Radio Button Group: User      
            
            if (loginID=="abc@npbook.com" && password=="pass1234" && userType=="Staff"){
                Session["LoginID"] = loginID;          //More info in Practical 6, something to do with global variables
                Session["LoggedInTime"] = DateTime.Now.ToString();
                // Redirect user to Main.aspx page          
                Response.Redirect("Main.aspx");     
            } else {          
                // Display error message          
                lblError.Text = "Invalid Login Credentials!";     
            } 
        }  
    }
}