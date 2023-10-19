using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected int isExcitInData(string usna, string pawo)
    {

        string myConnectionString = db.connectionString;
        string mySqlStr1 = "SELECT * FROM Users WHERE Users.UN=@us AND Users.PW=@pa ";
        SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);

        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@us";
        q1.SqlDbType = SqlDbType.VarChar;
        q1.Value = usna;
        myCommandObj1.Parameters.Add(q1);

        SqlParameter q2 = new SqlParameter();
        q2.ParameterName = "@pa";
        q2.SqlDbType = SqlDbType.VarChar;
        q2.Value = pawo;
        myCommandObj1.Parameters.Add(q2);

        myCommandObj1.Connection.Open();
        SqlDataReader reader = myCommandObj1.ExecuteReader();


        while (reader.Read())
        {
            return Convert.ToInt32(reader["id"]);
        }
        reader.Close();
        myCommandObj1.Connection.Close();
        return -1;
    }

    protected Boolean isEmpty(string str)
    {
        for(int i=0;i<str.Length;i++)
        {
            if (str[i] != null && str[i] != ' ')
                return true;
        }
        return false;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        if(Request.QueryString["msg"]=="1")
        {
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            Button1.Text = "Sign Up";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["msg"] == "1")
        {
            SqlConnection sc = new SqlConnection(db.connectionString);
            string mySqlStr = string.Format("INSERT INTO Users VALUES ('{0}','{1}','{2}')", username.Text, password.Text, 1);
            SqlCommand myCommandObj = new SqlCommand(mySqlStr, sc);
            myCommandObj.Connection.Open();
            myCommandObj.ExecuteNonQuery();
            myCommandObj.Connection.Close();
            Session["userId1"] =""+ isExcitInData(username.Text, password.Text);
            Response.Redirect("Begin.aspx");
        }
        if (username.Text == null || username.Text == "" || username.Text == " " || !isEmpty(username.Text))
        {
            Label2.Visible = true;
            return;
        }
        else
            Label2.Visible = false;
        if (password.Text == null || password.Text == "" || password.Text == " " || !isEmpty(password.Text))
        {
            Label3.Visible = true;
            return;
        }
        else
            Label3.Visible = false;
        int id = isExcitInData(username.Text, password.Text);
        if(id != -1)
        {
            Session["userId1"] =""+ id;
            Response.Redirect("Begin.aspx");
        }
        else
        {
            Label1.Visible = true;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx?msg=1");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["userId1"] ="8";
        Response.Redirect("Begin.aspx");
    }
}