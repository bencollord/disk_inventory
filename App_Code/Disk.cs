using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///     Represents a Disk record from disk_inventory database
///     Child class of ActiveRecord
///     Author: Ben Collord
///     Last Modified: 11/24/2015
/// </summary>
public class Disk : ActiveRecord
{
    private string type;

    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool IsBorrowed { get; set; }
    public string Type
    {
        get { return this.type; }
        set
        {
            if (value == "CD" || value == "DVD")
            {
                this.type = value;
            }
            else
            {
                throw new Exception("Value of disk type must be 'CD' or 'DVD'");
            }
        }
    }

    public override void Insert()
    {
        using(SqlConnection conn = GetSqlConnection())
        using(SqlCommand cmd = new SqlCommand("sp_InsertDisk", conn))
        {
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DiskName", this.Title);
            cmd.Parameters.AddWithValue("@ReleaseDate", this.ReleaseDate);
            cmd.Parameters.AddWithValue("@DiskType", this.Type);
            cmd.Parameters.AddWithValue("@GenreName", this.Genre);
            cmd.Parameters.AddWithValue("@IsBorrowed", this.IsBorrowed);

            cmd.ExecuteNonQuery();
        }
    }
}