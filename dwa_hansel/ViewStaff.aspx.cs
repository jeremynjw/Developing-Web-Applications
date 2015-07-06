using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dwa_hansel
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayStaffList();
            }
        }
        
        private void displayStaffList() 
        { 
            //Read connection string "DWABookConnectionString" from web.config file     
            string strConn = ConfigurationManager.ConnectionStrings
                             ["DWABookConnectionString"].ToString();
          
            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);  

            //Instantiate a SqlCommand object, supply it with the SQL statement        
            //SELECT that operates against the database, and the connection object 
            //used for connecting to the database.
            SqlCommand cmd = new SqlCommand("SELECT * FROM Staff ORDER BY StaffID", conn);  

            //Instantiate a DataAdapter object and  pass the SqlCommand object  
            // created as parameter.
            SqlDataAdapter daStaff = new SqlDataAdapter(cmd);  

            //Create a DataSet object to contain the records retrieved from database     
            DataSet result = new DataSet();                  
            
            //A connection must be opened before any operations made.     
            conn.Open();  
    
            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet.     
            //DataSet "result" will store the result of the SELECT operation.     
            daStaff.Fill(result, "StaffDetails");  
    
            //A connection should always be closed, whether error occurs or not.      
            conn.Close();  
    
            //Specify GridView to get data from table "StaffDetails"      
            //in DataSet "result"  
            gvStaff.DataSource = result.Tables["StaffDetails"];  
    
            //Display the list of data in GridView     
            gvStaff.DataBind(); }

        protected void gvStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the page index to the page clicked by user.     
            gvStaff.PageIndex = e.NewPageIndex;     
            
            // Display records on the new page.     
            displayStaffList(); 
        }  
    }
}