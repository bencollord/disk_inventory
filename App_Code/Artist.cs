using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///     Represents an Artist record from disk_inventory database
///     Child class of ActiveRecord
///     Author: Ben Collord
///     Last Modified: 11/24/2015
/// </summary>
public class Artist : ActiveRecord
{
    private int id;
    private string name;


    public int ID 
    {
        get 
        { 
            return this.id; 
        }
    }

    public string Name { get; set; }

    public static Artist GetByName(string artistName)
    {
        // GetConnection() is a static method of the parent class
        using (SqlConnection conn = GetSqlConnection())
        using(SqlCommand cmd = new SqlCommand("sp_GetArtistByName", conn))
        {
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", artistName);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Artist artist = new Artist();
                    artist.id = reader.GetInt32(0);
                    artist.name = reader.GetString(1);
                    return artist;
                }
                else
                {
                    return null;
                }
            }
        } // Using directives automaticaly close the reader and connection
    }

    // Inserts the current object as new record into the database
    public override void Insert()
    {
        using (SqlConnection conn = GetSqlConnection())
        using (SqlCommand cmd = new SqlCommand("sp_InsertArtist", conn))
        {
            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArtistName", this.Name);
            cmd.ExecuteNonQuery();
        }
    }
}