using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class db
{


    public static string connectionString = @" Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Food Distribution\App_Data\Halukot.mdf;Integrated Security=True";
    public db()
    {

    }
    public static int exec(string sql)
    {
        int rowsAffected;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        rowsAffected = command.ExecuteNonQuery();
        connection.Close();
        return rowsAffected;
    }

    public static DataTable vieww(string sql)
    {
        DataSet ds = new DataSet();
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.Connection = connection;
        connection.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds);
        DataTable dt = ds.Tables[0];
        return dt;

    }
}