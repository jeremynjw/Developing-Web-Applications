using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dwa_hansel {
    public class Staff {
        //Properties
        public int StaffId { get; set; } 
        public string Name { get; set; } 
        public string Gender { get; set; } 
        public DateTime Dob { get; set; }     
        public string Nationality { get; set; }     
        public string Email { get; set; }     
        public double Salary { get; set; }     
        public bool IsFullTime { get; set; }     
        public int BranchNo { get; set; }

        public int Add() {
            string strConn = ConfigurationManager.ConnectionStrings["DWABookConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("INSERT INTO Staff (Name, Gender, DOB, Salary, " + "EmailAddr, Nationality, Status) " + "VALUES(@name, @gender, @dob, @salary, " + "@email, @country, @status)", conn);

            //Define the parameters used in SQL statement, value for each parameter     
            //is retrieved from respective class's property.     
            cmd.Parameters.AddWithValue("@name", Name);     
            cmd.Parameters.AddWithValue("@gender", Gender);     
            cmd.Parameters.AddWithValue("@dob", Dob);     
            cmd.Parameters.AddWithValue("@salary", Salary);     
            cmd.Parameters.AddWithValue("@email", Email);     
            cmd.Parameters.AddWithValue("@country", Nationality);     
            cmd.Parameters.AddWithValue("@status", IsFullTime);

            //A connection to database must be opened before any operations made.     
            conn.Open();  
            //ExecuteNonQuery is used for INSERT, UPDATE, DELETE SQL statement.     
            cmd.ExecuteNonQuery();  
            //A connection should be closed after operations.     
            conn.Close();  
            //Return 0 when no error occurs.     
            return 0;
        }

        public int GetDetails() {     
            //Read connection string "DWABookConnectionString" from web.config file.     
            string strConn = ConfigurationManager.ConnectionStrings                      
                ["DWABookConnectionString"].ToString();          
            
            //Create a SqlConnection object with the Connection String read.       
            SqlConnection conn = new SqlConnection(strConn);  
            
            //Create a SqlCommand object, with a SELECT SQL statement to retrieve all      
            //attributes of a staff, and a connection object to open the database.     
            SqlCommand cmd = new SqlCommand      
                ("SELECT * FROM Staff WHERE StaffID = @selectedStaffID", conn);
            
            //Define parameter used in SQL, get its value from class property staffId
            cmd.Parameters.AddWithValue("@selectedStaffID", StaffId);  
            
            //Create a DataAdapter object, pass SqlCommand object as parameter.
            SqlDataAdapter daStaff = new SqlDataAdapter(cmd);  

            //Create a DataSet object result
            DataSet result = new DataSet();  

            //Open a database connection.
            conn.Open();  

            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet.
            daStaff.Fill(result, "StaffDetails");
                
            //Close database connection     
            conn.Close();  
    
            if (result.Tables["StaffDetails"].Rows.Count > 0)     {      
            //Assign values from DataSet to class properties of Staff        
            //DBNUll() detects null value retrieved from the database for a         
            //particular attribute  

                //name        
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["Name"]))            
                    Name = Convert.ToString(result.Tables["StaffDetails"].Rows[0]["Name"]);
                
                //gender        
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["Gender"]))
                    Gender = Convert.ToString(result.Tables["StaffDetails"].Rows[0]["Gender"]);

                //dob       
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["DOB"]))
                    Dob = Convert.ToDateTime(result.Tables["StaffDetails"].Rows[0]["DOB"]);
                
                //salary        
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["Salary"]))
                    Salary = Convert.ToDouble(result.Tables["StaffDetails"].Rows[0]["Salary"]);
                
                //email       
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["EmailAddr"]))
                    Email = Convert.ToString(result.Tables["StaffDetails"].Rows[0]["EmailAddr"]);

                //nationality        
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["Nationality"]))
                    Nationality = Convert.ToString(result.Tables["StaffDetails"].Rows[0]["Nationality"]);
                
                //is full time 
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["Status"]))
                    IsFullTime = Convert.ToBoolean(result.Tables["StaffDetails"].Rows[0]["Status"]);
                
                //branchNo  
                if (!DBNull.Value.Equals(result.Tables["StaffDetails"].Rows[0]["BranchNo"]))
                    BranchNo = Convert.ToInt32(result.Tables["StaffDetails"].Rows[0]["BranchNo"]);
                
                return 0;     
            } else {
                // No record found
                return -2;     
            } 
        } 

        

        public int Update() {     
            //Read connection string from web.config file.     
            string strConn = ConfigurationManager.ConnectionStrings                      
                ["DWABookConnectionString"].ToString();  
            
            //Create a SqlConnection object with the Connection String read.       
            SqlConnection conn = new SqlConnection(strConn);  

            //Create a SqlCommand object, with a SQL statement UPDATE to update the      
            //attributes of a staff, and a connection object to open the database.     
            SqlCommand cmd = new SqlCommand(             
                "UPDATE Staff SET Name=@name, Gender=@gender, Salary=@salary, " +             
                "DOB=@dob, EmailAddr=@email, Nationality=@nationality, " +             
                "Status=@status, BranchNo=@branchNo " +             
                "WHERE StaffID=@selectedStaffID", conn);          
            
            //Define the parameters used in SQL statement, value for each parameter 
            //are retrieved from class properties of Staff     
            cmd.Parameters.AddWithValue("@name", Name);     
            cmd.Parameters.AddWithValue("@gender", Gender);     
            cmd.Parameters.AddWithValue("@salary", Salary);     
            cmd.Parameters.AddWithValue("@dob", Dob);     
            cmd.Parameters.AddWithValue("@email", Email);     
            cmd.Parameters.AddWithValue("@nationality",Nationality);     
            cmd.Parameters.AddWithValue("@status", IsFullTime);     

            if (BranchNo == 0)
                cmd.Parameters.AddWithValue("@branchNo", DBNull.Value);     
            else
                cmd.Parameters.AddWithValue("@branchNo", BranchNo);

            cmd.Parameters.AddWithValue("@selectedStaffID", StaffId);  

            //Open a database connection.     
            conn.Open();  

            //ExecuteNonQuery is used for INSERT, UPDATE, DELETE SQL statement.     
            int count = cmd.ExecuteNonQuery();  

            //Connection should be closed after operations.     
            conn.Close();  
            if (count != 0) //At least one row of record updated,         
                return 0;   //return 0 as no error occurs.     
            else         
                return -2;  //No update as the record is not found. 
        }

        public int Delete() {
            // Read connection string
            string strConn = ConfigurationManager.ConnectionStrings["DWABookConnectionString"].ToString();

            // Instantiate a SqlConnection obj with the Connection String read
            SqlConnection conn = new SqlConnection(strConn.ToString());

            // Instantiate a SqlCommand obj, provide a DELETE SQL statement
            // to delete a staff record specified by a Staff ID.
            SqlCommand cmd = new SqlCommand("DELETE FROM Staff " +
                                            "WHERE StaffID = @selectedStaffID", conn);

            // Open a database connection
            conn.Open();
            cmd.ExecuteNonQuery();
            // Close a database connection
            conn.Close();

            // Return 0 when no error occurs
            return 0;
        }
    }
}