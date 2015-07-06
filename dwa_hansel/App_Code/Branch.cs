using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dwa_hansel {
    public class Branch {
        public int BranchNo { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public DateTime DateStarted { get; set; } 

        public int GetBranchStaff(ref DataSet staffResult){
            //Read connection string "DWABookConnectionString" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
            ["DWABookConnectionString"].ToString();

            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL
            //statement which retrieves all attributes of a staff record.
            SqlCommand cmd = new SqlCommand
            ("SELECT * FROM Staff WHERE BranchNo = @selectedBranchNo", conn);

            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the branchNo property of the Branch class.
            cmd.Parameters.AddWithValue("@selectedBranchNo", BranchNo);
            //cmd.Parameters.AddWithValue("@address", address);
            //cmd.Parameters.AddWithValue("@telNo", telNo);
            //cmd.Parameters.AddWithValue("@dateStarted", dateStarted);

           //Instantiate a DataAdapter object, pass the SqlCommand
           //object created as parameter.
            SqlDataAdapter daStaff = new SqlDataAdapter(cmd);

            //Open a database connection.
            conn.Open();

            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet.
            daStaff.Fill(staffResult, "StaffDetails");

            //Close database connection
            conn.Close();

            //Return 0 when no error occurs.
            return 0; 
        }
    }
}