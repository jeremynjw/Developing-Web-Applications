using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel {
    public partial class DeleteStaff : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack){

            }

            // Check is there a query string "staffId" in the URL - important for
            // security checks
            if (Request.QueryString["staffid"] != null) {
                lblStaffID.Text = Request.QueryString["staffid"];
                lblStaffName.Text = Request.QueryString["name"];
            }
        }

        protected void btnNo_Click(object sender, EventArgs e) {
            Response.Redirect("ViewStaff.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                // Check if there is a query string "staffid" in the URL
                if (Request.QueryString["staffid"] != null) {
                    // Get the staffid from query string
                    // and convert the query stirng to 32-bit integer.
                    int staffID = Convert.ToInt32(Request.QueryString["staffid"]);

                    // Create a Staff object
                    Staff objStaff = new Staff();

                    // Call the Delete() method of Staff class to delete
                    // the staff Id of the record to be deleted is passed as a property
                    // of the staff object, the method returns an integer error
                    // the calling program
                    objStaff.StaffId = staffID;
                    int errorCode = objStaff.Delete();

                    if (errorCode == 0) {
                        // Display appropriate message
                        lblMessage.Text = "Staff record has been deleted successfully.";

                        // Disable "Yes" and "No" buttons
                        btnYes.Enabled = false;
                        btnNo.Enabled = false;

                        // Display link back to View Staff Page
                        lnkVewStaff.Visible = true;
                    }
                }
            }
        }
    }
}