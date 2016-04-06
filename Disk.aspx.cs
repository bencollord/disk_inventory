/// Page logic for myDisk Inventory Disk tracker
/// Author: Ben Collord
/// Last Modified:  11/13/2015 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class DiskPage : System.Web.UI.Page
{
    protected void btnSubmit_Click(object sender, EventArgs args)
    {
        if (IsValid)
        {
            Disk disk = new Disk();
            disk.Title = txtDiskName.Text;
            disk.Genre = txtGenre.Text;
            disk.ReleaseDate = Convert.ToDateTime(txtReleaseDate.Text);
            disk.Type = ddlDiskType.SelectedValue;
            disk.IsBorrowed = cbIsBorrowed.Checked;

            try
            {
                disk.Insert();
                lblMessage.CssClass = "success";
                lblMessage.Text = "Disk added successfully!";
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Error inserting disk." + "<br />" + ex.Message;
            }
            finally
            {
                lblMessage.Visible = true;
            }
        }
    }
}