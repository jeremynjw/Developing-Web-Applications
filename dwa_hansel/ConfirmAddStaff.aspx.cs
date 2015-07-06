using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class ConfirmAddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblName.Text = Request.QueryString["name"];
                lblGender.Text = Request.QueryString["gender"];
                lblDOB.Text = Request.QueryString["dob"];
                lblSalary.Text = Request.QueryString["salary"];
                lblEmail.Text = Request.QueryString["email"];
                lblNationality.Text = Request.QueryString["nationality"];
                lblIsFullTimeStaff.Text = Request.QueryString["fulltime"];
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (Page.IsValid) { // All validation passed
                // Create a new object from the Staff class
                Staff objStaff = new Staff();

                // Pass data to the properties of the Staff object,          
                // do the necessary data type conversion if need to.  
                objStaff.Name = lblName.Text;

                // if-else required because Gender property only can contain 'M' or 'F' (char(1))
                // Check database design for this portion
                if (lblGender.Text == "Male") 
                    objStaff.Gender = "M"; 
                else objStaff.Gender = "F";

                objStaff.Dob = Convert.ToDateTime(lblDOB.Text); 
                objStaff.Salary = Convert.ToDouble(lblSalary.Text); 
                objStaff.Email = lblEmail.Text; 
                objStaff.Nationality = lblNationality.Text;

                if (lblIsFullTimeStaff.Text == "yes") 
                    objStaff.IsFullTime = true; 
                else objStaff.IsFullTime = false;

                // Call the add method to insert the staff record to database.          
                int errorCode = objStaff.Add();  
                // Record has been inserted successfully if the returned code is 0.          
                if (errorCode == 0)              
                    lblMessage.Text = "New staff is added successfully";   

            }
        }
    }
}