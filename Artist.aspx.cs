/// Page logic for myDisk Inventory Artist tracker
/// Author: Ben Collord
/// Last Modified:  11/13/2015 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArtistPage : System.Web.UI.Page
{
    protected void cvArtistNotDuplicate_Validate(object sender, ServerValidateEventArgs args)
    {
        if (Artist.GetByName(txtArtistName.Text) == null)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs args)
    {
        if (IsValid)
        {
            // Create Artist object and load properties with form data
            Artist artist = new Artist();
            artist.Name = txtArtistName.Text;

            // Save artist in database
            try
            {
                artist.Insert();
                lblMessage.CssClass = "success";
                lblMessage.Text = "New artist saved successfully!";
            }
            catch 
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Error saving artist";
            }
            finally
            {
                lblMessage.Visible = true;
            }
        }
    }
}