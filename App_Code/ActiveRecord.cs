using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///     Abstract base class for database entities
///     Each child class represents a database table
///     Author: Ben Collord
///     Last Modified: 11/23/2015
/// </summary>
public abstract class ActiveRecord
{
    protected static SqlConnection GetSqlConnection()
    {
        Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~/");
        string connectionString = webConfig.ConnectionStrings.ConnectionStrings["disk_inventoryConnectionString"].ConnectionString;
        return new SqlConnection(connectionString);
    }

    // Saves data as new record
    public abstract void Insert();
    // Updates record with new data (to be implemented later)
    //public abstract void Update(int id);
    // Deletes record from table (to be implemented later)
    //public abstract void Delete(int id);
}