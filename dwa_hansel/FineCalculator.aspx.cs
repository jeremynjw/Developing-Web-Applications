using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class FineCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }

        protected void btnCompute_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // All validations passed
            {
                int numBooksOverdue;
                double fine = 0.0;
                // Read the number of books overdue
                numBooksOverdue = Convert.ToInt32(txtNumOverdueBk.Text);
                // Reset the fine breakdown label
                lblFineBreakdown.Text = "";
                // For loop to calculate fine
                for (int i = 1; i <= numBooksOverdue; i++)
                {
                    lblFineBreakdown.Text += "Overdue cost for Book " +
                        i + " = $" + i + "<br />";
                    fine += i;
                }
                lblFine.Text = fine.ToString("##,###0.00");
            }
        }    
    }
}