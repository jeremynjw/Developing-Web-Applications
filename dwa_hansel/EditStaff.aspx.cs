using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel {
    public partial class EditStaff : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {     
                ddlNationality.Items.Add("Singapore");     
                ddlNationality.Items.Add("Malaysia");     
                ddlNationality.Items.Add("Indonesia");     
                ddlNationality.Items.Add("China");  

                ddlBranch.Items.Add("1");     // *** this is hardcoding, but we will learn how to import data from db to ddl
                ddlBranch.Items.Add("2");     
                ddlBranch.Items.Add("3");  

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
                objStaff.BranchNo = Convert.ToInt32(ddlBranch.SelectedValue); 
                
                int errorCode = objStaff.Update();
                if (errorCode == 0) { 
                    lblMessage.Text = "Staff record has been updated successfully."; 
                } else if (errorCode == -2) { 
                    lblMessage.Text = "Unable to save edited record as it is not found!"; 
                    lblMessage.ForeColor = System.Drawing.Color.Red; 
                }
            }
        }
    }
}