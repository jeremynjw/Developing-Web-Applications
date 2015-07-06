using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 

namespace dwa_hansel {
    public partial class ViewBranch : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //Page is loading onto the web browser, not being refreshed due to
            //"postback" triggered by clicking of a submit button, or other
            //control that causes an auto-postback.
            if (!Page.IsPostBack) {
                displayBranchList();
            }
        }

        private void displayBranchList() {
            //Read connection string "DWABookConnectionString" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
            ["DWABookConnectionString"].ToString();

            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL statement
            //(SELECT, INSERT, UPDATE or DELETE) that is to be operated against the
            //database, and the connection object used for connecting to the database.
            SqlCommand cmd = new SqlCommand("SELECT * FROM Branch", conn);

            //Declare and instantiate DataAdapter object
            SqlDataAdapter daBranch = new SqlDataAdapter(cmd);

            //Create a DataSet object to contain the records retrieved from database
            DataSet results = new DataSet();

            //Use DataAdapter to fetch data to a table
            //named as "BranchDetails" in DataSet.
            conn.Open();
            daBranch.Fill(results, "BranchDetails");
            conn.Close();

            //Specify GridView to get data from table "BranchDetails"
            //in DataSet "result"
            gvBranch.DataSource = results.Tables["BranchDetails"];

            //Display the list of data into GridView
            gvBranch.DataBind();
        }

        protected void gvBranch_SelectedIndexChanged(object sender, EventArgs e) {
            // Get the SelectedDataKey from GridView, which is the BranchNo,
            // and do the necessary data conversion.
            int selectedBranchNo = Convert.ToInt32(gvBranch.SelectedDataKey[0]); // checking for primary key

            // Create a Branch object.
            Branch objBranch = new Branch();

            // Create a DataSet object to contain the staff list of a branch.
            DataSet staffResult = new DataSet();

            // Call the getDetails method of Staff class to retrieve staff details
            // from database.
            objBranch.BranchNo = selectedBranchNo;
            int errorCode = objBranch.GetBranchStaff(ref staffResult);
            if (errorCode == 0) {
                // Load Staff information to the GridView: gvStaff
                gvStaff.DataSource = staffResult.Tables["StaffDetails"];
                // gvStaff.DataSource = staffResult.Tables[0];
                gvStaff.DataBind();
            }
        }
    }
}