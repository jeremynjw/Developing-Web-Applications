using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dwa_hansel
{
    public partial class RentalCalculator : System.Web.UI.Page
    {
        // store the currency code
        private string[] currencyCode =
            new string[] { "SGD", "USD", "EUR", "MYR" };

        // store the corresponding currency description
        private string[] currencyDescription =
            new string[] { "Singapore Dollar", "US Dollar", "Euro", "Malaysia Ringgit" };

        // store the corresponding currency conversion rate
        private double[] conversionRate =
            new double[] { 1.0, 0.68, 0.48, 2.0 };

         protected void Page_Load(object sender, EventArgs e)    
         {       
             if (!Page.IsPostBack)          
             {            
                 // Use for loop to populate Number of books dropdown list             
                 for (int i = 1; i < 6; i++)             
                 {                
                     ddlNumBooks.Items.Add(i.ToString());             
                 }

                 // CHALLENGE : Use for loop to populate Number of days with value 1 to 30
                 for (int i = 1; i < 31; i++)
                 {
                     ddlNumDays.Items.Add(i.ToString());
                 }

                 // Add currency codes to radio button list
                 for(int i = 0; i < currencyCode.Length; i++)
                 {
                     rdoCurrencies.Items.Add(currencyCode[i]);
                 }
                 rdoCurrencies.SelectedIndex = 0; // first item is selected
             }       
         }

         protected void btnCalRentalFee_Click(object sender, EventArgs e)
         {
             if (Page.IsValid) // All validators passed
             {
                 int numBook, numDay; double rentalRate, rentalFee;
                 // Calculate the rental fee based on the inputs   
                 numBook = Convert.ToInt32(ddlNumBooks.SelectedItem.Value);
                 numDay = Convert.ToInt32(ddlNumDays.SelectedItem.Value);
                 rentalRate = Convert.ToInt32(txtRentalRate.Text);
                 rentalFee = numBook * numDay * rentalRate;
                 // Display the rental fee on label 
                 lblRentalFee.Text = rentalFee.ToString("##,###0.00");

             } 
         }

         protected void btnCalcDiscountRentalFee_Click(object sender, EventArgs e)
         {
             double rentalFee, discount, amtPayable;

             rentalFee = Convert.ToDouble(lblRentalFee.Text);

             if (rentalFee < 11.0)
                 discount = 0;
             else if (rentalFee < 51.0)
                 discount = 5.0;
             else if (rentalFee > 101.0)
                 discount = 10.0;
             else
                 discount = 20.0;

             lblDiscountPercent.Text = discount.ToString("###0.0");
             amtPayable = rentalFee * ((100 - discount) / 100);
             lblAmtPayable.Text = amtPayable.ToString("##,###0.00");
         }

         protected void rdoCurrencies_SelectedIndexChanged(object sender, EventArgs e)
         {
             double discountPercent, rentalFee, amtPayable;

             if(lblRentalFee.Text == "" || lblDiscountPercent.Text == "")
             {
                 rdoCurrencies.SelectedIndex = 0; // reset the selection
                 return; // Stop conversion if any of the above is empty
             }

            // Compute amount payable in SGD
             rentalFee = Convert.ToDouble(lblRentalFee.Text);
             discountPercent = Convert.ToDouble(lblDiscountPercent.Text);
             amtPayable = rentalFee * ((100 - discountPercent) / 100);

             // Convert discounted rental fee to the selected currency
             int selectedCurrencyIndex = rdoCurrencies.SelectedIndex;
             amtPayable *= conversionRate[selectedCurrencyIndex];

             // Display the rental fee
             lblAmtPayable.Text = amtPayable.ToString("##,###0.00");
         } 
    }
}