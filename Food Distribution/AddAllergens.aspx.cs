using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.ProviderBase;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Drawing;

public partial class AddAllergens : System.Web.UI.Page
{

    public string getNom(string str)
    {

        return Convert.ToString(str.Substring(0, (str.IndexOf(","))));

    }
    public string getKamut(string str)
    {

        return Convert.ToString(str.Substring(str.IndexOf(",") + 1, (str.IndexOf("*") - str.IndexOf(",") - 1)));


    }

    public double getPrice(string str)
    {


        return Convert.ToDouble(str.Substring(str.IndexOf("*") + 1, (str.IndexOf(";") - str.IndexOf("*") - 1)));


    }

    public int getKh(string str)
    {

        return Convert.ToInt32(str.Substring(str.IndexOf(";") + 1, (str.IndexOf(":") - str.IndexOf(";") - 1)));

    }

    public int getKs(string str)
    {

        return Convert.ToInt32(str.Substring(str.IndexOf(":") + 1, (str.IndexOf("|") - str.IndexOf(":") - 1)));

    }

    public double getKamutNum(string str)
    {
        string kaNum = "";
        string s = getKamut(str);
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9' || s[i] == '.')
                kaNum += s[i];
        }
        return Convert.ToDouble(kaNum);
    }

    public string getKamutUom(string str)
    {

        string kaNum = "";
        string kaUom = "";
        string s = getKamut(str);
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9' || s[i] == '.')
                kaNum += s[i];
            else
                kaUom += s[i];
        }
        return kaUom;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Request.QueryString["msg"]) != null && Convert.ToString(Request.QueryString["msg"]) != "" && Convert.ToString(Request.QueryString["msg"]) != " ")
            Session["msg1"] = Convert.ToString(Request.QueryString["msg"]);
        LinkButton lb = new LinkButton();
        lb.Text = "Would you like to add allergens to another new dish? (optional)";
        lb.Click += lbOC;
        if (Convert.ToString(Session["newMana1"]) != "" && !IsPostBack)
        {
            string nam = "";
            string[] newManot = Convert.ToString(Session["newMana1"]).Split(';');
            string newMana = "";
            if (newManot.Length > 1)
            {
                newMana = newManot[0];
                nam = getNom(Convert.ToString(Session["" + Convert.ToInt32(newMana)]));
                Label1.Text = "Add allergens to the new dish: " + nam + ", you introduced the web-site to ";
                newManot[0] = null;
                Session["newMana1"] = "";
                for (int ig = 0; ig < newManot.Length; ig++)
                    if (newManot[ig] != null && newManot[ig] != "")
                        Session["newMana1"] += newManot[ig] + ";";

                //indexNewManot++;
                newManot = Convert.ToString(Session["newMana1"]).Split(';');
                if (newManot.Length > 1)
                {
                    newMana = newManot[0];
                    lb.Text = "Would you like to add allergens to the new dish:" + getNom(Convert.ToString(Session["" + Convert.ToInt32(newMana)])) + "? (optional)";
                    div2.Visible = true;
                }
            }


        }
        div2.Controls.Add(lb);
        //  DropDownList1.Visible = true;

        string myConnectionString = db.connectionString;
        string mySqlStr1 = "SELECT * FROM Allergens ";
        SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);

        /*
        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@no";
        q1.SqlDbType = SqlDbType.VarChar;
        q1.Value = name;
        myCommandObj1.Parameters.Add(q1);
        */
        myCommandObj1.Connection.Open();
        SqlDataReader reader = myCommandObj1.ExecuteReader();






        int i = 0;
        while (reader.Read())
        {
            if (reader["NAME"] != null && Convert.ToString(reader["NAME"]) != "")
            {

                dp.Items.Add(Convert.ToString(reader["NAME"]));
                dp.Items[i].Value = Convert.ToString(reader["id"]);
                i++;
            }



        }

        reader.Close();
        myCommandObj1.Connection.Close();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
               string myConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Food Distribution\App_Data\Halukot.mdf;Integrated Security=True";
               string mySqlStr1 = "SELECT * FROM Allergens WHERE Allergens.NAME=@na ";
               SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
               SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);
               string[] nameswas =new string[2];

               SqlParameter q1 = new SqlParameter();
               q1.ParameterName = "@na";
               q1.SqlDbType = SqlDbType.VarChar;
               q1.Value = dp.Text;
               myCommandObj1.Parameters.Add(q1);
               myCommandObj1.Connection.Open();
               SqlDataReader reader = myCommandObj1.ExecuteReader();

               int id = -1;
               if (reader.Read())
               {
                   id=Convert.ToInt32(reader["id"]);
                   
               }
               reader.Close();
               myCommandObj1.Connection.Close();
         */
        if (Convert.ToString(Session["newMana1"]) != "" || Convert.ToString(Request.QueryString["msg"]) != null)
        {
            string std = Convert.ToString(Session["msg1"]);
            string mana = Convert.ToString(Session["" + Convert.ToString(Session["msg1"])]);
            string myConnectionString = db.connectionString;
            string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.PFO=@pf AND Manot.KH=@khh AND Manot.KS=@kss AND Manot.UOM=@uo ";
            SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
            SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


            SqlParameter q1 = new SqlParameter();
            q1.ParameterName = "@no";
            q1.SqlDbType = SqlDbType.VarChar;
            q1.Value = getNom(mana);
            myCommandObj1.Parameters.Add(q1);
            SqlParameter q2 = new SqlParameter();
            q2.ParameterName = "@pf";
            q2.SqlDbType = SqlDbType.Real;
            q2.Value = getPrice(mana);
            myCommandObj1.Parameters.Add(q2);

            SqlParameter q3 = new SqlParameter();
            q3.ParameterName = "@khh";
            q3.SqlDbType = SqlDbType.Int;
            q3.Value = getKh(mana);
            myCommandObj1.Parameters.Add(q3);

            SqlParameter q4 = new SqlParameter();
            q4.ParameterName = "@kss";
            q4.SqlDbType = SqlDbType.Int;
            q4.Value = getKs(mana);
            myCommandObj1.Parameters.Add(q4);

            SqlParameter q5 = new SqlParameter();
            q5.ParameterName = "@uo";
            q5.SqlDbType = SqlDbType.VarChar;
            q5.Value = getKamutUom(mana);
            myCommandObj1.Parameters.Add(q5);

            myCommandObj1.Connection.Open();
            SqlDataReader reader = myCommandObj1.ExecuteReader();

            int idmana = -1;
            while (reader.Read())
            {
                idmana = Convert.ToInt32(reader["id"]);
            }
            reader.Close();
            myCommandObj1.Connection.Close();


            string ms = "";
            int i = 0;
            int length = 0;
            Boolean ok = true;
            string s = "";
            while (ok)
            {
                try
                {
                    s = dp.Items[i].Text;
                    ok = true;
                    length++;
                    i++;
                }
                catch
                {
                    ok = false;
                    i = 0;
                }
            }
            while (i < length)
            {
                if (dp.Items[i].Selected)
                {
                    ms += dp.Items[i].Text + ";";
                }

                i++;
            }

            string[] allergensNames = ms.Split(';');
            int[] allergensIds = new int[allergensNames.Length];
            for (int j = 0; j < allergensIds.Length - 1; j++)
            {


                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Allergens WHERE Allergens.NAME=@name ";
                mySqlConnection = new SqlConnection(myConnectionString);
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@name";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = allergensNames[j];
                myCommandObj1.Parameters.Add(q1);



                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();

                while (reader.Read())
                {
                    allergensIds[j] = Convert.ToInt32(reader["id"]);
                }
                reader.Close();
                myCommandObj1.Connection.Close();
            }


            for (int j = 0; j < allergensIds.Length - 1; j++)
            {
                SqlConnection sc = new SqlConnection(db.connectionString);
                string mySqlStr = string.Format("INSERT INTO AllergensToManot VALUES ('{0}','{1}')", idmana, allergensIds[j]);
                SqlCommand myCommandObj = new SqlCommand(mySqlStr, sc);
                myCommandObj.Connection.Open();
                myCommandObj.ExecuteNonQuery();
                myCommandObj.Connection.Close();

            }
            Response.Redirect("Begin.aspx");
        }
        string ms1 = "";
        int i1 = 0;
        int length1 = 0;
        Boolean ok1 = true;
        string s1 = "";
        while (ok1)
        {
            try
            {
                s1 = dp.Items[i1].Value;
                ok1 = true;
                length1++;
                i1++;
            }
            catch
            {
                ok1 = false;
                i1 = 0;
            }
        }
        while (i1 < length1)
        {
            if (dp.Items[i1].Selected)
            {
                ms1 += dp.Items[i1].Value + ";";
            }

            i1++;
        }


        Response.Redirect("Default.aspx?msgg=" + ms1);
    }

    public void lbOC(object sender, EventArgs e)
    {
        string mana = Convert.ToString(Session["" + Convert.ToString(Session["msg1"])]);
        string myConnectionString = db.connectionString;
        string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.PFO=@pf AND Manot.KH=@khh AND Manot.KS=@kss AND Manot.UOM=@uo ";
        SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@no";
        q1.SqlDbType = SqlDbType.VarChar;
        q1.Value = getNom(mana);
        myCommandObj1.Parameters.Add(q1);

        SqlParameter q2 = new SqlParameter();
        q2.ParameterName = "@pf";
        q2.SqlDbType = SqlDbType.Real;
        q2.Value = getPrice(mana);
        myCommandObj1.Parameters.Add(q2);

        SqlParameter q3 = new SqlParameter();
        q3.ParameterName = "@khh";
        q3.SqlDbType = SqlDbType.Int;
        q3.Value = getKh(mana);
        myCommandObj1.Parameters.Add(q3);

        SqlParameter q4 = new SqlParameter();
        q4.ParameterName = "@kss";
        q4.SqlDbType = SqlDbType.Int;
        q4.Value = getKs(mana);
        myCommandObj1.Parameters.Add(q4);

        SqlParameter q5 = new SqlParameter();
        q5.ParameterName = "@uo";
        q5.SqlDbType = SqlDbType.VarChar;
        q5.Value = getKamutUom(mana);
        myCommandObj1.Parameters.Add(q5);

        myCommandObj1.Connection.Open();
        SqlDataReader reader = myCommandObj1.ExecuteReader();

        int idmana = -1;
        while (reader.Read())
        {
            idmana = Convert.ToInt32(reader["id"]);
        }
        reader.Close();
        myCommandObj1.Connection.Close();


        string ms = "";
        int i = 0;
        int length = 0;
        Boolean ok = true;
        string s = "";
        while (ok)
        {
            try
            {
                s = dp.Items[i].Text;
                ok = true;
                length++;
                i++;
            }
            catch
            {
                ok = false;
                i = 0;
            }
        }
        while (i < length)
        {
            if (dp.Items[i].Selected)
            {
                ms += dp.Items[i].Text + ";";
            }

            i++;
        }

        string[] allergensNames = ms.Split(';');
        int[] allergensIds = new int[allergensNames.Length];
        for (int j = 0; j < allergensIds.Length - 1; j++)
        {


            myConnectionString = db.connectionString;
            mySqlStr1 = "SELECT * FROM Allergens WHERE Allergens.NAME=@name ";
            mySqlConnection = new SqlConnection(myConnectionString);
            myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


            q1 = new SqlParameter();
            q1.ParameterName = "@name";
            q1.SqlDbType = SqlDbType.VarChar;
            q1.Value = allergensNames[j];
            myCommandObj1.Parameters.Add(q1);



            myCommandObj1.Connection.Open();
            reader = myCommandObj1.ExecuteReader();

            while (reader.Read())
            {
                allergensIds[j] = Convert.ToInt32(reader["id"]);
            }
            reader.Close();
            myCommandObj1.Connection.Close();
        }


        for (int j = 0; j < allergensIds.Length - 1; j++)
        {
            SqlConnection sc = new SqlConnection(db.connectionString);
            string mySqlStr = string.Format("INSERT INTO AllergensToManot VALUES ('{0}','{1}')", idmana, allergensIds[j]);
            SqlCommand myCommandObj = new SqlCommand(mySqlStr, sc);
            myCommandObj.Connection.Open();
            myCommandObj.ExecuteNonQuery();
            myCommandObj.Connection.Close();

        }
        Response.Redirect("AddAllergens.aspx");
    }
}