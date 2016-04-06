/// Page logic for myDisk Inventory Borrower tracker
/// Author: Ben Collord
/// Last Modified:  11/13/2015 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BorrowerPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs args)
    {
        if (IsValid)
        {
            Borrower borrower = new Borrower();
            borrower.FirstName = txtFName.Text;
            borrower.LastName = txtLName.Text;
            borrower.Phone = txtPhoneNum.Text;

            try
            {
                borrower.Insert();
                lblMessage.CssClass = "success";
                lblMessage.Text = "Borrower registered successfully!";
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Error registering borrower." + "<br />" + ex.Message;
            }
            finally
            {
                lblMessage.Visible = true;
            } 
        }
    }
}