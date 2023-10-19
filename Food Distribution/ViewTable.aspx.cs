using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ViewTable : System.Web.UI.Page
{
    public static int userID;
    public int userType;
    public int pb;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["userId1"]) == "" || Session["userId1"] == null)
            Response.Redirect("Login.aspx");
        if (!IsPostBack)
            pb = 0;
        else
            pb++;

        string myConnectionString;
        string mySqlStr1;
        SqlConnection mySqlConnection;
        SqlCommand myCommandObj1;
        SqlParameter q1;
        SqlDataReader reader;

        myConnectionString = db.connectionString;
        mySqlStr1 = "SELECT * from Users WHERE Users.id=@ui";
        mySqlConnection = new SqlConnection(myConnectionString);
        myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);
        q1 = new SqlParameter();
        q1.ParameterName = "@ui";
        q1.SqlDbType = SqlDbType.Int;
        q1.Value = Convert.ToInt32(Session["userId1"]);
        myCommandObj1.Parameters.Add(q1);

        myCommandObj1.Connection.Open();
        reader = myCommandObj1.ExecuteReader();

        if (reader.Read())
        {
            userType = Convert.ToInt32(reader["TYPE"]);
        }
        reader.Close();
        myCommandObj1.Connection.Close();

        if (userType == 2 && pb == 0)
        {
            DropDownList2.Visible = true;
            DropDownList2.Items.Add("guests");
            myConnectionString = db.connectionString;
            mySqlStr1 = "SELECT * from Users";
            mySqlConnection = new SqlConnection(myConnectionString);
            myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


            myCommandObj1.Connection.Open();
            reader = myCommandObj1.ExecuteReader();

            while (reader.Read() && !IsPostBack)
            {
                DropDownList2.Items.Add(Convert.ToString(reader["UN"]));
            }
            reader.Close();
            myCommandObj1.Connection.Close();

            DropDownList1.Visible = false;
            return;
        }

        if (userType != 2)
            userID = Convert.ToInt32(Session["userId1"]);

        myConnectionString = db.connectionString;
        mySqlStr1 = "SELECT * from Events WHERE Events.USERID=@ui";
        mySqlConnection = new SqlConnection(myConnectionString);
        myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);
        q1 = new SqlParameter();
        q1.ParameterName = "@ui";
        q1.SqlDbType = SqlDbType.Int;
        q1.Value = userID;
        myCommandObj1.Parameters.Add(q1);

        myCommandObj1.Connection.Open();
        reader = myCommandObj1.ExecuteReader();
        int ii = 0;
        while (reader.Read())
        {
            if (reader["TYPE"] != null && Convert.ToString(reader["TYPE"]) != "" && !IsPostBack)
            {
                DropDownList1.Items.Add("" + (int)(ii + 1) + ": " + Convert.ToString(reader["TYPE"]));
                DropDownList1.Items[ii].Value = Convert.ToString(reader["id"]);
                ii++;
            }
        }
        reader.Close();
        myCommandObj1.Connection.Close();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button2.Visible = false;
        if (userType == 2 && DropDownList1.Visible == false)
        {
            DropDownList1.Items.Clear();

            string myConnectionStringf;
            string mySqlStr1f;
            SqlConnection mySqlConnectionf;
            SqlCommand myCommandObj1f;
            SqlParameter q1f;
            SqlDataReader readerf;

            DropDownList1.Visible = true;
            GridView1.DataSource = null;
            GridView1.DataBind();
            myConnectionStringf = db.connectionString;
            mySqlStr1f = "SELECT * from Users WHERE Users.UN=@un";
            mySqlConnectionf = new SqlConnection(myConnectionStringf);
            myCommandObj1f = new SqlCommand(mySqlStr1f, mySqlConnectionf);
            q1f = new SqlParameter();
            q1f.ParameterName = "@un";
            q1f.SqlDbType = SqlDbType.VarChar;
            q1f.Value = DropDownList2.Text;
            myCommandObj1f.Parameters.Add(q1f);

            myCommandObj1f.Connection.Open();
            readerf = myCommandObj1f.ExecuteReader();

            if (readerf.Read())
            {
                userID = Convert.ToInt32(readerf["id"]);
            }
            readerf.Close();
            myCommandObj1f.Connection.Close();

            // if (DropDownList2.Text == "guests")
            //   userID = -1;

            myConnectionStringf = db.connectionString;
            mySqlStr1f = "SELECT * from Events WHERE Events.USERID=@ui";
            mySqlConnectionf = new SqlConnection(myConnectionStringf);
            myCommandObj1f = new SqlCommand(mySqlStr1f, mySqlConnectionf);
            q1f = new SqlParameter();
            q1f.ParameterName = "@ui";
            q1f.SqlDbType = SqlDbType.Int;
            q1f.Value = userID;
            myCommandObj1f.Parameters.Add(q1f);

            myCommandObj1f.Connection.Open();
            readerf = myCommandObj1f.ExecuteReader();
            int ii = 0;
            while (readerf.Read())
            {
                if (readerf["TYPE"] != null && Convert.ToString(readerf["TYPE"]) != "" && pb == 1)
                {
                    DropDownList1.Items.Add("" + (int)(ii + 1) + ": " + Convert.ToString(readerf["TYPE"]));
                    DropDownList1.Items[ii].Value = Convert.ToString(readerf["id"]);
                    ii++;
                }
            }
            readerf.Close();
            myCommandObj1f.Connection.Close();
            return;

        }
        else
            if (userType == 2)
            {
                DropDownList1.Visible = false;
                if (DropDownList1.Visible == false)
                {

                    Button2.Visible = true;


                }
            }

        DataTable dt = new DataTable();
        SqlCommand sc2 = new SqlCommand();
        SqlConnection sqlcon = new SqlConnection(db.connectionString);
        SqlCommand sc = new SqlCommand("SELECT * from Events WHERE Events.USERID=@ui AND Events.id=@id", sqlcon);

        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@ui";
        q1.SqlDbType = SqlDbType.Int;
        q1.Value = Convert.ToInt32(userID);
        sc.Parameters.Add(q1);

        SqlParameter q2 = new SqlParameter();
        q2.ParameterName = "@id";
        q2.SqlDbType = SqlDbType.VarChar;
        q2.Value = DropDownList1.SelectedValue;
        sc.Parameters.Add(q2);

        if (DropDownList1.Text == null || DropDownList1.Text == "")
            return;

        sc.Connection.Open();
        SqlDataReader reader = sc.ExecuteReader();

        sc2 = new SqlCommand("SELECT * from Past WHERE Past.id>=@mb AND Past.id<=@me", sqlcon);
        q1 = new SqlParameter();
        q1.ParameterName = "@mb";
        q1.SqlDbType = SqlDbType.VarChar;
        q2 = new SqlParameter();
        q2.ParameterName = "@me";
        q2.SqlDbType = SqlDbType.VarChar;


        if (reader.Read())
        {

            q1.Value = Convert.ToString(reader["MANOTMB"]);
            sc2.Parameters.Add(q1);

            q2.Value = Convert.ToString(reader["MANOTME"]);
            sc2.Parameters.Add(q2);

        }
        reader.Close();
        sc.Connection.Close();

        SqlDataAdapter sd = new SqlDataAdapter(sc2);
        sd.Fill(dt);
        /*
        DataColumn dc1 = dt.Columns[3];
        DataColumn dc2 = dt.Columns[6];
        datac

        */
        //  dt.Columns[3].
        //    dt.Rows[1][3] = 111;

        DataTable dtCloned = dt.Clone();
        dtCloned.Columns[3].DataType = typeof(string);
        dtCloned.Columns[6].DataType = typeof(string);
        foreach (DataRow row in dt.Rows)
        {
            dtCloned.ImportRow(row);

        }

        Boolean ok = true;
        int i = 0;
        while (ok)
        {
            try
            {
                string myConnectionString;
                string mySqlStr1;
                SqlConnection mySqlConnection;
                SqlCommand myCommandObj1;
                SqlParameter qa;
                SqlDataReader readera;


                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * from Manot WHERE Manot.id=@mi";
                mySqlConnection = new SqlConnection(myConnectionString);
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);
                qa = new SqlParameter();
                qa.ParameterName = "@mi";
                qa.SqlDbType = SqlDbType.Int;
                qa.Value = Convert.ToInt32(dtCloned.Rows[i][3]);
                myCommandObj1.Parameters.Add(qa);

                myCommandObj1.Connection.Open();
                readera = myCommandObj1.ExecuteReader();

                if (readera.Read())
                {
                    dtCloned.Rows[i][3] = "" + readera["NOM"];
                }
                readera.Close();
                myCommandObj1.Connection.Close();

                if (dtCloned.Rows[i][6] != null && Convert.ToInt32(dtCloned.Rows[i][6]) != 0)
                {
                    myConnectionString = db.connectionString;
                    mySqlStr1 = "SELECT * from Manot WHERE Manot.id=@mi";
                    mySqlConnection = new SqlConnection(myConnectionString);
                    myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);
                    qa = new SqlParameter();
                    qa.ParameterName = "@mi";
                    qa.SqlDbType = SqlDbType.Int;
                    qa.Value = Convert.ToInt32(dtCloned.Rows[i][6]);
                    myCommandObj1.Parameters.Add(qa);

                    myCommandObj1.Connection.Open();
                    readera = myCommandObj1.ExecuteReader();

                    if (readera.Read())
                    {
                        dtCloned.Rows[i][6] = "" + readera["NOM"];
                    }
                    readera.Close();
                    myCommandObj1.Connection.Close();
                }

                // dtCloned.Rows[i][6] = "fh";
                i++;
            }
            catch
            {
                ok = false;
            }

        }
        GridView1.DataSource = dtCloned;
        GridView1.DataBind();
        string stam1 = "width: 552px;" + "height:" + i * 45 + "px" + "; margin-left: 350px;background-color:white; ";
        div1.Style.Add("st1", stam1);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        int usid = 0;
        string myConnectionStringf;
        string mySqlStr1f;
        SqlConnection mySqlConnectionf;
        SqlCommand myCommandObj1f;
        SqlParameter q1f;
        SqlParameter q2f;
        SqlDataReader readerf;
        SqlDataReader reader;

        myConnectionStringf = db.connectionString;
        mySqlStr1f = "SELECT * from Users WHERE Users.UN=@un";
        mySqlConnectionf = new SqlConnection(myConnectionStringf);
        myCommandObj1f = new SqlCommand(mySqlStr1f, mySqlConnectionf);
        q1f = new SqlParameter();
        q1f.ParameterName = "@un";
        q1f.SqlDbType = SqlDbType.VarChar;
        q1f.Value = DropDownList2.Text;
        myCommandObj1f.Parameters.Add(q1f);

        myCommandObj1f.Connection.Open();
        readerf = myCommandObj1f.ExecuteReader();

        if (readerf.Read())
        {
            usid = Convert.ToInt32(readerf["id"]);
        }
        readerf.Close();
        myCommandObj1f.Connection.Close();

        if (DropDownList2.Text == "guests")
            userID = -1;



        myConnectionStringf = db.connectionString;
        mySqlStr1f = "SELECT * from Events WHERE Events.USERID=@ui AND Events.id=@id";
        mySqlConnectionf = new SqlConnection(myConnectionStringf);
        myCommandObj1f = new SqlCommand(mySqlStr1f, mySqlConnectionf);

        q1f = new SqlParameter();
        q1f.ParameterName = "@ui";
        q1f.SqlDbType = SqlDbType.Int;
        q1f.Value = usid;
        myCommandObj1f.Parameters.Add(q1f);

        q2f = new SqlParameter();
        q2f.ParameterName = "@id";
        q2f.SqlDbType = SqlDbType.VarChar;
        q2f.Value = DropDownList1.SelectedValue;
        myCommandObj1f.Parameters.Add(q2f);

        myCommandObj1f.Connection.Open();
        reader = myCommandObj1f.ExecuteReader();

        if (reader.Read())
        {
            SqlConnection mySqlConnectiona = new SqlConnection(myConnectionStringf);
            SqlCommand sc2 = new SqlCommand("SELECT * from Past WHERE Past.id>=@mb AND Past.id<=@me", mySqlConnectiona);

            q1f = new SqlParameter();
            q1f.ParameterName = "@mb";
            q1f.SqlDbType = SqlDbType.Int;
            q1f.Value = Convert.ToInt32(reader["MANOTMB"]);
            sc2.Parameters.Add(q1f);

            q2f = new SqlParameter();
            q2f.ParameterName = "@me";
            q2f.SqlDbType = SqlDbType.Int;
            q2f.Value = Convert.ToInt32(reader["MANOTME"]);
            sc2.Parameters.Add(q2f);

            sc2.Connection.Close();
            sc2.Connection.Open();
            SqlDataReader reader2 = sc2.ExecuteReader();


            while (reader2.Read())
            {

                SqlConnection mySqlConnectionb = new SqlConnection(myConnectionStringf);
                SqlCommand sc3 = new SqlCommand("DELETE from Manot WHERE Manot.id=@lo OR  Manot.id=@to", mySqlConnectionb);

                SqlParameter q1 = new SqlParameter();
                q1.ParameterName = "@lo";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = Convert.ToString(reader2["MANA"]);
                sc3.Parameters.Add(q1);

                SqlParameter q2 = new SqlParameter();
                q2.ParameterName = "@to";
                q2.SqlDbType = SqlDbType.VarChar;
                q2.Value = Convert.ToString(reader2["MANATOS"]);
                sc3.Parameters.Add(q2);

                sc3.Connection.Close();
                sc3.Connection.Open();
                sc3.ExecuteReader();
                sc3.Connection.Close();


            }

            reader2.Close();
            sc2.Connection.Close();

            SqlCommand sc4 = new SqlCommand("DELETE from Past WHERE Past.id>=@mb AND Past.id<=@me", mySqlConnectionf);

            SqlParameter q1g = new SqlParameter();
            q1g.ParameterName = "@mb";
            q1g.SqlDbType = SqlDbType.VarChar;
            q1g.Value = Convert.ToString(reader["MANOTMB"]);
            sc4.Parameters.Add(q1g);

            SqlParameter q2g = new SqlParameter();
            q2g.ParameterName = "@me";
            q2g.SqlDbType = SqlDbType.VarChar;
            q2g.Value = Convert.ToString(reader["MANOTME"]);
            sc4.Parameters.Add(q2g);

            sc4.Connection.Close();
            sc4.Connection.Open();
            sc4.ExecuteReader();
            sc4.Connection.Close();

        }
        reader.Close();
        myCommandObj1f.Connection.Close();

        myConnectionStringf = db.connectionString;
        mySqlStr1f = "DELETE  from Events WHERE Events.USERID=@ui AND Events.id=@id";
        mySqlConnectionf = new SqlConnection(myConnectionStringf);
        myCommandObj1f = new SqlCommand(mySqlStr1f, mySqlConnectionf);

        q1f = new SqlParameter();
        q1f.ParameterName = "@ui";
        q1f.SqlDbType = SqlDbType.Int;
        q1f.Value = usid;
        myCommandObj1f.Parameters.Add(q1f);

        q2f = new SqlParameter();
        q2f.ParameterName = "@id";
        q2f.SqlDbType = SqlDbType.VarChar;
        q2f.Value = DropDownList1.SelectedValue;
        myCommandObj1f.Parameters.Add(q2f);

        myCommandObj1f.Connection.Close();
        myCommandObj1f.Connection.Open();
        myCommandObj1f.ExecuteReader();
        myCommandObj1f.Connection.Close();
    }
}