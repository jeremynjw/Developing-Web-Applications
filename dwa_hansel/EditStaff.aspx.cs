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
    public partial class EditStaff : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {     
                ddlNationality.Items.Add("Singapore");     
                ddlNationality.Items.Add("Malaysia");     
                ddlNationality.Items.Add("Indonesia");     
                ddlNationality.Items.Add("China");  

                //ddlBranch.Items.Add("1");     // *** this is hardcoding, but we will learn how to import data from db to ddl
                //ddlBranch.Items.Add("2");     
                //ddlBranch.Items.Add("3");  
                displayBranchDropDownList();

                if (Request.QueryString["staffid"] != null) { // *** check if there is a querystring that exists
                    //Create a new Staff object           
                    Staff objStaff = new Staff();         

                    //Read Staff ID from query string         
                    objStaff.StaffId = Convert.ToInt32(Request.QueryString["staffid"]);                  

                    // Load staff information to various controls         
                    int errorCode = objStaff.GetDetails();  // *** objStaff.staffId must be called first in order for this to work
                    if (errorCode == 0) {                
                        //Assign property values from the Staff object to various controls             
                        txtName.Text = objStaff.Name;             
                        txtDOB.Text = objStaff.Dob.ToShortDateString();  
                        if (objStaff.Gender == "M")                 
                            radMale.Checked = true;             
                        else if (objStaff.Gender == "F")                 
                            radFemale.Checked = true;  
                        //Format currency value: 2 decimal places, punctuated at thousand                          
                        txtSalary.Text = objStaff.Salary.ToString("##,##0.00");
                        txtEmail.Text = objStaff.Email;             
                        ddlNationality.SelectedValue = objStaff.Nationality;             
                        chkFullTime.Checked = objStaff.IsFullTime;  
                    
                        // Select Branch Number in DropDownList             
                        ddlBranch.SelectedValue = objStaff.BranchNo.ToString();         
                    } else if (errorCode == -2) {             
                        lblMessage.Text = "Unable to retrieve staff details for ID  " +                                
                            objStaff.StaffId.ToString();             
                        lblMessage.ForeColor = System.Drawing.Color.Red;         
                    }     
                } 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                Staff objStaff = new Staff();
                // Read Staff ID from query string passed from ViewStaff.aspx         
                objStaff.StaffId = Convert.ToInt32(Request.QueryString["staffid"]);                  
                
                //Read updated values from various web controls and          
                //transfer them to the staff object properties                  
                objStaff.Name =txtName.Text.Trim(); // also trims excess spaces between words
                
                //Trim method: remove excessive spaces                          
                if (radMale.Checked == true)             
                    objStaff.Gender = "M";         
                else if (radFemale.Checked == true)             
                    objStaff.Gender = "F";  

                objStaff.Dob = Convert.ToDateTime(txtDOB.Text.Trim()); 
                objStaff.Salary = Convert.ToDouble(txtSalary.Text.Trim()); 
                objStaff.Email = txtEmail.Text.Trim(); 
                objStaff.Nationality = ddlNationality.SelectedValue; 
                objStaff.IsFullTime = chkFullTime.Checked;
                if (ddlBranch.SelectedIndex != 0) // Prevent errors if user does not select
                    objStaff.BranchNo = Convert.ToInt32(ddlBranch.SelectedValue);
                else
                    objStaff.BranchNo = 0;
                
                int errorCode = objStaff.Update();
                if (errorCode == 0) { 
                    lblMessage.Text = "Staff record has been updated successfully."; 
                } else if (errorCode == -2) { 
                    lblMessage.Text = "Unable to save edited record as it is not found!"; 
                    lblMessage.ForeColor = System.Drawing.Color.Red; 
                }
            }
        }

        private void displayBranchDropDownList() {
            // Read connection
            string strConn = ConfigurationManager.ConnectionStrings["DWABookConnectionString"].ToString();

            // Create a SqlConnection object with the Connection String
            SqlConnection conn = new SqlConnection(strConn);

            // Create SqlCommand obj, with SQL statement to retrieve
            SqlCommand cmd = new SqlCommand("SELECT * FROM Branch", conn);

            // Create a DataAdapter obj
            SqlDataAdapter daBranch = new SqlDataAdapter(cmd);

            // Create DataSet obj
            DataSet result = new DataSet();

            // Open a Database connection
            conn.Open();
            // Use DataAdapter to fill DataSet result to a table "BranchDetails"
            daBranch.Fill(result, "BranchDetails");
            // Close Database connection
            conn.Close();

            // Specify the dropdown list to get data from the DataSet
            ddlBranch.DataSource = result.Tables["BranchDetails"];
            ddlBranch.DataTextField = "address";
            ddlBranch.DataValueField = "branchNo";

            // Load Branch infomation to the drop-down list
            ddlBranch.DataBind();

            //Insert prompt for the DropDownList at the first position of the list     
            ddlBranch.Items.Insert(0, "(No branch selected)");
        }
    }
}