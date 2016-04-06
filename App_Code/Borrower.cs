using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
/// <summary>
///     Represents a Borrower record from disk_inventory database
///     Child class of ActiveRecord
///     Author: Ben Collord
///     Last Modified: 11/24/2015
/// </summary>
public class Borrower : ActiveRecord
{
    private string phone;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone 
    {
        get
        {
            return this.phone;
        }
        set
        {
            // Strip out non numeric characters
            Regex rgx = new Regex("[^0-9]");
            value = rgx.Replace(value, "");

            // Test length
            if (value.Length != 10)
            {
                throw new ArgumentException("Phone number must be 10 digits");
            }

            // Format phone number
            value = String.Format("{0}-{1}-{2}", value.Substring(0, 3), value.Substring(3, 3), value.Substring(6));

            // Set value
            this.phone = value;
        }
    }

    public override void Insert()
    {
        using (SqlConnection conn = GetSqlConnection())
        using (SqlCommand cmd = new SqlCommand("sp_InsertBorrower", conn))
        {
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", this.FirstName);
            cmd.Parameters.AddWithValue("@LastName", this.LastName);
            cmd.Parameters.AddWithValue("@Phone", this.Phone);

            cmd.ExecuteNonQuery();
        }
    }
}