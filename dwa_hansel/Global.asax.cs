using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace dwa_hansel
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Application["CurrentUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Lock all Applicaton Variables before manipulating them
            Application.Lock();

            // Increment the Application Variables by 1
            Application["CurrentUsers"] = 
                Convert.ToInt32(Application["CurrentUsers"]) + 1;

            // Unlock all Application Variables to allow for others
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Lock all Application Variables before manipulating them      
            Application.Lock();              
            
            // Decrement the Application Variables by 1      
            Application["CurrentUsers"] =                   
                Convert.ToInt32(Application["CurrentUsers"]) - 1;
            
            // Unlock all Application Variables to allow for others      
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}