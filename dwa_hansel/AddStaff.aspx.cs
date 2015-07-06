using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class AddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlNationality.Items.Add("Singapore");
                ddlNationality.Items.Add("Malaysia");
                ddlNationality.Items.Add("Indonesia");
                ddlNationality.Items.Add("China");

                // Back button to update
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string strValues;
                strValues = "name=" + txtName.Text; // means string concatenation
                if (radMale.Checked == true)
                    strValues += "&gender=Male";
                else strValues += "&gender=Female";

                strValues += "&dob=" + Server.UrlEncode(txtDOB.Text);
                strValues += "&salary=" + txtSalary.Text;
                strValues += "&email=" + txtEmail.Text;
                strValues += "&nationality=" + ddlNationality.SelectedValue;
                if (chkFullTime.Checked == true)
                    strValues += "&fulltime=yes";
                else strValues += "&fulltime=no";

                // lblValues.Text = strValues;
                Response.Redirect("ConfirmAddStaff.aspx?" + strValues);
            }
        }
    }
}