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


public partial class _Default : System.Web.UI.Page
{
    public string[] addCell(string[] arr, int plus)
    {
        plus = Math.Abs(plus);
        string[] leha = new string[arr.Length + plus];
        for (int i = 0; i < arr.Length; i++)
        {
            leha[i] = arr[i];
        }
        return leha;
    }

    public int find(string[] arr, string somthing)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == somthing)
                return i;

        }
        return -1;
    }

    public int find1(string[] arr, string somthing, int after)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == somthing && i != after)
                return i;

        }
        return -1;
    }
    public string[] removeNull(string[] arr)
    {
        int j = 0;
        string[] leha = new string[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
                leha[j] = arr[i];
            else
                if (i + 1 < arr.Length)
                    j--;
            j++;

        }
        int cou = countArr(leha);
        string[] leha1 = new string[cou];
        for (int i = 0; i < leha1.Length; i++)
            leha1[i] = leha[i];

        return leha1;
    }
    public int[] removeNull(int[] arr)
    {
        int j = 0;
        int[] leha = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != 0)
                leha[j] = arr[i];
            else
                if (i + 1 < arr.Length)
                    j--;
            j++;

        }
        int cou = countArr(leha);
        int[] leha1 = new int[cou];
        for (int i = 0; i < leha1.Length; i++)
            leha1[i] = leha[i];

        return leha1;
    }

    public int countMofa(string[] arr, string str)
    {
        int c = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == str)
                c++;
        }

        return c;
    }
    public int countArr(string[] arr)
    {
        int counter = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
                counter++;

        }
        return counter;
    }
    public int countArr(int[] arr)
    {
        int counter = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != 0)
                counter++;

        }
        return counter;
    }
    /*
   public static Table tavla = new Table();
   public static TableRow myline = new TableRow();
   public static TableCell ta = new TableCell();
    */
    public static Button[] b = new Button[1001];
    public static int count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["msgg"] != null && (Request.QueryString["msgg"] == "" || Request.QueryString["msgg"] == " "))
            Response.Redirect("Begin.aspx");
        DropDownList1.Visible = false;
        cb.Visible = false;
        if (nop.Text != null && nop.Text != "")
            Session["nop1"] = nop.Text;
        if (eventType.Text != null && eventType.Text != "")
            Session["eventType1"] = eventType.Text;
        //Response.Redirect("Insert.aspx?msg=1");


        /* if (Session["index"] != null)*/
        if (Convert.ToInt32(Request.QueryString["ms"]) == 1)
        {
            this.nop.Text = "" + Session["nop1"];
            if (Convert.ToString(Session["maslul123"]) != "3")
                this.eventType.Text = "" + Session["eventType1"];

            //    myline.Cells.RemoveAt(0);//Convert.ToInt32(Session["index"])-1);
            //     ta.HorizontalAlign = HorizontalAlign.Center;

            //Random rnd=new Random();
            //int j = rnd.Next(1, 100000);

            //   for(int i=0;i<count;i++)
            //   {
            //    b[i].ID = "bt" + i;
            //   this.form1.Controls.Add(b[i]);
            //  }

            if (Session["ma1"] != null)
            {
                this.maa.Text = Convert.ToString(Session["ma1"]);
                Button end = new Button();
                end.ID = "end";
                end.Text = "End";
                end.BackColor = Color.FromName("RoyalBlue");
                end.Height = 40;
                end.Width = 40;
                end.BorderColor = Color.FromName("White");
                end.ForeColor = Color.FromName("White");
                end.Click += end_Click;
                div3.Controls.Add(end);
                // this.form1.Controls.Add(end);
            }
            if (Convert.ToString(Session["ar1"]) != "ken")
            {
                b[count] = new Button();
                b[count].ID = "btn" + 0;
                // setId(b[count]);
                // string s = "btn" + count;
                // b[count].ID = s; //(Convert.ToInt32(Session["index"])).ToString();
                string str = "" + Session["" + Convert.ToInt32(Session["index1"])];
                int lng1 = str.IndexOf(",");
                string naom = str.Substring(0, lng1);
                b[count].Text = naom;
                //btnn.Click -= btnOC;
                b[count].Click += btnOC;
                //btnn.Click += new EventHandler(this.btnOC);
                b[count].UseSubmitBehavior = false;
                // btnn.PostBackUrl="Insert.aspx?msg=3";
                //b[count] = btnn;
                b[count].BackColor = Color.FromName("RoyalBlue");
                b[count].Height = 40;
                //b[count].Width = 40;
                b[count].BorderColor = Color.FromName("White");
                b[count].ForeColor = Color.FromName("White");
                div3.Controls.Add(b[count]);
                //this.form1.Controls.Add(b[count]);
                count++;

            }
            // Random fgh = new Random();
            // int i = fgh.Next(10000000, 1000000000);
            Button bt = new Button();
            //string st = "btn" + count;
            bt.ID = "2";
            bt.Text = " + ";
            //bt.Click -= btnOC;
            bt.Click += btnOC;
            //bt.Click += new EventHandler(this.btnOC);
            bt.UseSubmitBehavior = false;
            // bt.PostBackUrl = "Insert.aspx?msg=3";
            //b[count] = bt;
            bt.BackColor = Color.FromName("RoyalBlue");
            bt.Height = 40;
            bt.Width = 40;
            bt.BorderColor = Color.FromName("White");
            bt.ForeColor = Color.FromName("White");
            div3.Controls.Add(bt);
            // this.form1.Controls.Add(bt);
            //count++;

            /*
            ta.Controls.Add(btnn);
            myline.Cells.Add(ta);
            tavla.Rows.Add(myline);
            Panel1.Controls.Add(tavla);
         * */

        }



            //  ta.HorizontalAlign = HorizontalAlign.Center;

        else
        {
            if (Convert.ToString(Session["maslul123"]) != "3")
            {

                ////////////////////////////////////////
                /*
                string myConnectionString;
                string mySqlStr1;
                SqlConnection mySqlConnection;
                SqlCommand myCommandObj1;
                SqlParameter q1;
                SqlDataReader reader;

                this.maa.Text = Convert.ToString(Session["ma1"]);
                DropDownList1.Visible = true;

                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Events ";
                mySqlConnection = new SqlConnection(myConnectionString);
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();
                string[] last = new string[2];
                int cou = 0;






                while (reader.Read())
                {
                    if (reader["TYPE"] != null && Convert.ToString(reader["TYPE"]) != "" && find(last, Convert.ToString(reader["TYPE"])) == -1)
                    {
                        last[cou] = Convert.ToString(reader["TYPE"]);
                        last = addCell(last, 1);
                        cou++;
                        DropDownList1.Items.Add(Convert.ToString(reader["TYPE"]));
                    }



                }

                reader.Close();
                myCommandObj1.Connection.Close();
                */
                ////////////////////////////////////////

                if (Convert.ToString(Session["maslul123"]) == "2")
                {
                    cb.Items.Clear();
                    cb.Visible = true;
                    cb.ID = "cb" + 1;
                    int x = 0;
                    string[] names = new string[2];

                    string myConnectionStringj = db.connectionString;
                    string mySqlStr1j = "SELECT * FROM Manot";
                    SqlConnection mySqlConnectionj = new SqlConnection(myConnectionStringj);
                    SqlCommand myCommandObj1j = new SqlCommand(mySqlStr1j, mySqlConnectionj);



                    myCommandObj1j.Connection.Open();
                    SqlDataReader readerj = myCommandObj1j.ExecuteReader();

                    int i = 0;
                    while (readerj.Read())
                    {
                        if (find(names, Convert.ToString(readerj["NOM"])) == -1)
                        {
                            names[x] = Convert.ToString(readerj["NOM"]);
                            cb.Items.Add(names[x]);
                            cb.Items[i].Value = Convert.ToString(readerj["id"]) + ";";
                            i++;
                            x++;
                            names = addCell(names, 1);
                        }

                    }

                    readerj.Close();
                    myCommandObj1j.Connection.Close();

                    Button end1 = new Button();
                    end1.ID = "end";
                    end1.Style.Add("st2", "margin-left: 20px");
                    end1.Text = "End";
                    end1.BackColor = Color.FromName("RoyalBlue");
                    end1.Height = 40;
                    end1.Width = 40;
                    end1.BorderColor = Color.FromName("White");
                    end1.ForeColor = Color.FromName("White");
                    end1.Click += end_Click;
                    if (Request.QueryString["msgg"] != null && Request.QueryString["msgg"] != "")
                        end_Click(sender, e);
                    div3.Controls.Add(end1);
                    form1.Style.Add("sty1", "width: 552px; height:" + (595 + i * 15) + "px; margin-left: 350px; background-color: white;");
                    div2.Style.Add("sty1", "height:" + (300 + i * 15) + "px; margin-left: 160px");
                    div3.Style.Add("sty1", "height: 332px;margin-top:" + (i * 15) + "px; margin-left: 160px; width: 390px;");
                }
                else
                {
                    //Session["fsd"]=0;
                    Button btn = new Button();
                    //string stri="btn" + count;
                    btn.BackColor = Color.FromName("RoyalBlue");

                    btn.BorderColor = Color.FromName("White");
                    btn.ForeColor = Color.FromName("White");
                    btn.ID = "0";
                    btn.Text = " + ";
                    btn.Height = 40;
                    btn.Width = 40;
                    //btn.Click -= btnOC;
                    btn.Click += btnOC;
                    //btn.Click += new EventHandler(this.btnOC);
                    btn.UseSubmitBehavior = false;
                    // btn.PostBackUrl = "Insert.aspx?msg=3";
                    //b[count] = btn;
                    div3.Controls.Add(btn);
                    // this.form1.Controls.Add(btn);
                    //count = 1;
                    //btn.CommandName = "btnOC";
                    //btn.OnClientClick = "btnOC";
                    /*
                    ta.Controls.Add(btn);
                    myline.Cells.Add(ta);
                    tavla.Rows.Add(myline);
                    Panel1.Controls.Add(tavla);
                    */

                    // String bbttnn = "btn" + Convert.ToString(Session["index"]);
                    //this.btn1.Visible = true;


                    /*
                    Table tavla = new Table();
                    TableRow myline = new TableRow();
                        for (int j = 1; j < 22; j++)
                        {
                            TableCell ta = new TableCell();
                            ta.HorizontalAlign = HorizontalAlign.Center;
                            Button btn = new Button();
                            btn.ID = "btn" + j.ToString();
                            btn.Text = " + ";
                            btn.OnClientClick = "btnOC";
                            ta.Controls.Add(btn);
                            myline.Cells.Add(ta);

                        }
                        tavla.Rows.Add(myline);
                        Panel1.Controls.Add(tavla);
                     */
                }
            }

            else
            {


                string myConnectionString;
                string mySqlStr1;
                SqlConnection mySqlConnection;
                SqlCommand myCommandObj1;
                SqlParameter q1;
                SqlDataReader reader;

                this.maa.Text = Convert.ToString(Session["ma1"]);
                DropDownList1.Visible = true;
                eventType.Visible = false;

                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Events ";
                mySqlConnection = new SqlConnection(myConnectionString);
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);

                /*
                SqlParameter q1 = new SqlParameter();
                q1.ParameterName = "@no";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = name;
                myCommandObj1.Parameters.Add(q1);
                */
                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();
                string[] last = new string[2];
                int cou = 0;






                while (reader.Read())
                {
                    if (reader["TYPE"] != null && Convert.ToString(reader["TYPE"]) != "" && find(last, Convert.ToString(reader["TYPE"])) == -1)
                    {
                        last[cou] = Convert.ToString(reader["TYPE"]);
                        last = addCell(last, 1);
                        cou++;
                        DropDownList1.Items.Add(Convert.ToString(reader["TYPE"]));
                    }



                }

                reader.Close();
                myCommandObj1.Connection.Close();

                LinkButton lb = new LinkButton();
                lb.Text = "Add an allergen (optional)";
                lb.Click += lbOC;
                div3.Controls.Add(lb);
                Button end1 = new Button();
                end1.ID = "end";
                end1.Style.Add("st2", "margin-left: 20px");
                end1.Text = "End";
                end1.BackColor = Color.FromName("RoyalBlue");
                end1.Height = 40;
                end1.Width = 40;
                end1.BorderColor = Color.FromName("White");
                end1.ForeColor = Color.FromName("White");
                end1.Click += end_Click;
                if (Request.QueryString["msgg"] != null && Request.QueryString["msgg"] != "")
                    end_Click(sender, e);
                div3.Controls.Add(end1);
            }



        }


    }
    void end_Click(System.Object sender, EventArgs e)
    {
        if (Convert.ToString(Session["maslul123"]) == "1")
        {
            if ((int)((Convert.ToDouble(Session["index1"]) + 1.0) / 2.0 + 0.5) > Convert.ToInt32(Session["nop1"]))
            {
                Label1.Visible = true;
                return;
            }
            else
            {
                Label1.Visible = false;
            }
        }
        if (Convert.ToString(Session["maslul123"]) == "3")
        {

            //if (Page.IsValid)
            // {
            string myConnectionString;
            string mySqlStr1;
            SqlConnection mySqlConnection;
            SqlCommand myCommandObj1;
            SqlParameter q1;
            SqlDataReader reader;
            int[] alIds = new int[0];
            if (Convert.ToString(Request.QueryString["msgg"]) != null && Convert.ToString(Request.QueryString["msgg"]) != "")
            {

                string msg = Convert.ToString(Request.QueryString["msgg"]);
                string[] idss = msg.Split(';');
                alIds = new int[idss.Length];
                for (int i = 0; i < alIds.Length; i++)
                    if (idss[i] != null && idss[i] != "")
                        alIds[i] = Convert.ToInt32(idss[i]);
                alIds = removeNull(alIds);
            }
            //////////////////////////////////////////////////////////


            string[] names = new string[2];
            int cou = 0;
            int cou1 = 0;
            int cou2 = 0;
            myConnectionString = db.connectionString;
            mySqlStr1 = "SELECT * FROM Events WHERE Events.TYPE=@ty ";
            mySqlConnection = new SqlConnection(myConnectionString);
            myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);
            string[] nameswas = new string[2];

            q1 = new SqlParameter();
            q1.ParameterName = "@ty";
            q1.SqlDbType = SqlDbType.VarChar;
            if (Convert.ToString(Request.QueryString["msgg"]) != null && Convert.ToString(Request.QueryString["msgg"]) != "")
                q1.Value = Convert.ToString(Session["dp1"]);
            else
            {
                q1.Value = DropDownList1.Text;
                Session["dp1"] = DropDownList1.Text; ;
            }
            myCommandObj1.Parameters.Add(q1);
            myCommandObj1.Connection.Open();
            reader = myCommandObj1.ExecuteReader();


            while (reader.Read())
            {
                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Past WHERE Past.id>=@mb AND Past.id<=@me";
                mySqlConnection = new SqlConnection(myConnectionString);
                //  myCommandObj1.Connection.Close(); //shly
                SqlCommand myCommandObj2 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@mb";
                q1.SqlDbType = SqlDbType.Int;
                q1.Value = Convert.ToInt32(reader["MANOTMB"]);
                myCommandObj2.Parameters.Add(q1);


                SqlParameter q2 = new SqlParameter();
                q2.ParameterName = "@me";
                q2.SqlDbType = SqlDbType.Int;
                q2.Value = Convert.ToInt32(reader["MANOTME"]);
                myCommandObj2.Parameters.Add(q2);

                myCommandObj2.Connection.Open();
                SqlDataReader reader2 = myCommandObj2.ExecuteReader();
                while (reader2.Read())
                {

                    myConnectionString = db.connectionString;
                    mySqlStr1 = "SELECT * FROM Manot WHERE Manot.id=@ma OR Manot.id=@mt";
                    mySqlConnection = new SqlConnection(myConnectionString);
                    //  myCommandObj1.Connection.Close(); //shly
                    SqlCommand myCommandObj3 = new SqlCommand(mySqlStr1, mySqlConnection);


                    q1 = new SqlParameter();
                    q1.ParameterName = "@ma";
                    q1.SqlDbType = SqlDbType.Int;
                    q1.Value = Convert.ToInt32(reader2["MANA"]);
                    myCommandObj3.Parameters.Add(q1);


                    q2 = new SqlParameter();
                    q2.ParameterName = "@mt";
                    q2.SqlDbType = SqlDbType.Int;
                    q2.Value = Convert.ToInt32(reader2["MANATOS"]);
                    myCommandObj3.Parameters.Add(q2);

                    myCommandObj3.Connection.Open(); //ot1
                    SqlDataReader reader3 = myCommandObj3.ExecuteReader();
                    while (reader3.Read())
                    {
                        if (find(nameswas, Convert.ToString(reader3["NOM"])) == -1)
                        {
                            nameswas[cou1] = Convert.ToString(reader3["NOM"]);
                            cou1++;
                            nameswas = addCell(nameswas, 1);
                        }


                    }

                    myCommandObj3.Connection.Close();
                }/////////////
                myCommandObj2.Connection.Close();
                if (nameswas.Length > names.Length)
                    names = addCell(names, nameswas.Length - names.Length);
                for (int i = 0; i < nameswas.Length; i++)
                {
                    names[cou] = nameswas[i];
                    cou++;
                    names = addCell(names, 1);
                }
                nameswas = new string[2];
                cou1 = 0;
                cou2++;
            }///////////////////////
            myCommandObj1.Connection.Close(); //shly
            names = removeNull(names);
            int cm = Convert.ToInt32((int)((names.Length / cou2) + 0.5));//cama manot
            int[] namesc = new int[names.Length];
            int c = 0;
            string mana = "";

            for (int i = 0; i < names.Length; i++)
            {
                namesc[i] = countMofa(names, names[i]);
                c = namesc[i];
                mana = names[i];
                while (c > 1)
                {

                    names[find1(names, mana, i)] = null;
                    names = removeNull(names);
                    c--;
                }
            }

            int max = -1;
            int index = 0;
            string[] names2 = new string[names.Length];
            int cou22 = 0;
            while (names.Length > 0)
            {
                for (int j = 0; j < namesc.Length; j++)
                {
                    max = Math.Max(max, namesc[j]);
                    if (max == namesc[j])
                    {
                        index = j;
                    }
                }
                max = 0;
                names2[cou22] = names[index];
                cou22++;
                names[index] = null;
                names = removeNull(names);
                namesc[index] = 0;
                namesc = removeNull(namesc);
            }

            for (int k = 0; k < alIds.Length; k++)
            {
                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM AllergensToManot WHERE AllergensToManot.IDALLERGEN=@ia ";
                mySqlConnection = new SqlConnection(myConnectionString);
                //  myCommandObj1.Connection.Close(); //shly
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@ia";
                q1.SqlDbType = SqlDbType.Int;
                q1.Value = alIds[k];
                myCommandObj1.Parameters.Add(q1);
                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();


                while (reader.Read())
                {
                    myConnectionString = db.connectionString;
                    mySqlStr1 = "SELECT * FROM Manot WHERE Manot.id=@im ";
                    mySqlConnection = new SqlConnection(myConnectionString);
                    //  myCommandObj1.Connection.Close(); //shly
                    myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                    q1 = new SqlParameter();
                    q1.ParameterName = "@im";
                    q1.SqlDbType = SqlDbType.Int;
                    q1.Value = Convert.ToInt32(reader["IDMANA"]);
                    myCommandObj1.Parameters.Add(q1);
                    myCommandObj1.Connection.Open();
                    SqlDataReader reader4 = myCommandObj1.ExecuteReader();
                    if (reader4.Read())
                    {
                        for (int i = 0; i < names2.Length; i++)
                        {
                            if (names2[i] == Convert.ToString(reader4["NOM"]))
                            {
                                names2[i] = null;
                                names2 = removeNull(names2);
                            }
                        }
                    }
                }
                myCommandObj1.Connection.Close(); //shly
            }

            while (cm > names2.Length)
                cm--;

            for (int i = 0; i < cm; i++)
            {


                string name = names2[i];
                int units = 0;
                int kg = 0;

                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no ";
                mySqlConnection = new SqlConnection(myConnectionString);
                //  myCommandObj1.Connection.Close(); //shly
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@no";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = name;
                myCommandObj1.Parameters.Add(q1);
                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();


                while (reader.Read())
                {
                    if (Convert.ToString(reader["UOM"]) == "units")
                        units++;
                    else
                        if (Convert.ToString(reader["UOM"]) == "kg")
                            kg++;

                }

                reader.Close();
                myCommandObj1.Connection.Close();

                string uom = "";
                if (Math.Max(units, kg) == units)
                    uom = "units";
                else
                    uom = "kg";

                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo";
                mySqlConnection = new SqlConnection(myConnectionString);
                //  myCommandObj1.Connection.Close(); //shly
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@no";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = name;
                myCommandObj1.Parameters.Add(q1);

                SqlParameter q2 = new SqlParameter();
                q2.ParameterName = "@uo";
                q2.SqlDbType = SqlDbType.VarChar;
                q2.Value = uom;
                myCommandObj1.Parameters.Add(q2);

                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();

                double pfo = 0;
                int kh = 0;
                int ks = 0;

                double pfos = 0;
                double khs = 0;
                double kss = 0;

                double pfoc = 0;
                double khc = 0;
                double ksc = 0;
                while (reader.Read())
                {
                    pfos += Convert.ToDouble(reader["PFO"]);
                    pfoc++;
                    khs += Convert.ToDouble(reader["KH"]);
                    khc++;
                    kss += Convert.ToDouble(reader["KS"]);
                    ksc++;

                }
                pfo = pfos / pfoc;
                kh = Convert.ToInt32((int)((khs / khc) + 0.5));
                ks = Convert.ToInt32((int)((kss / ksc) + 0.5));
                reader.Close();
                myCommandObj1.Connection.Close();



                double yach = 0;
                double yachs = 0;
                double yachc = 0;


                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo";
                mySqlConnection = new SqlConnection(myConnectionString);
                //  myCommandObj1.Connection.Close(); //shly
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@no";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = name;
                myCommandObj1.Parameters.Add(q1);

                q2 = new SqlParameter();
                q2.ParameterName = "@uo";
                q2.SqlDbType = SqlDbType.VarChar;
                q2.Value = uom;
                myCommandObj1.Parameters.Add(q2);

                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();

                while (reader.Read())
                {

                    string myConnectionString2 = db.connectionString;
                    string mySqlStr12 = "SELECT * FROM Past WHERE Past.MANA=@ma OR Past.MANATOS=@ma";
                    SqlConnection mySqlConnection2 = new SqlConnection(myConnectionString2);
                    SqlCommand myCommandObj12 = new SqlCommand(mySqlStr12, mySqlConnection2);


                    SqlParameter q12 = new SqlParameter();
                    q12.ParameterName = "@ma";
                    q12.SqlDbType = SqlDbType.Int;
                    q12.Value = Convert.ToInt32(reader["id"]);
                    myCommandObj12.Parameters.Add(q12);
                    myCommandObj12.Connection.Open();
                    SqlDataReader reader2 = myCommandObj12.ExecuteReader();
                    double nuope = 0;
                    int lnoh = -1;
                    double kam = 0;
                    while (reader2.Read())
                    {
                        string myConnectionString3 = db.connectionString;
                        string mySqlStr13 = "SELECT * FROM Events WHERE Events.MANOTMB<=@mm AND Events.MANOTME>=@mm";
                        SqlConnection mySqlConnection3 = new SqlConnection(myConnectionString3);
                        SqlCommand myCommandObj13 = new SqlCommand(mySqlStr13, mySqlConnection3);


                        SqlParameter q13 = new SqlParameter();
                        q13.ParameterName = "@mm";
                        q13.SqlDbType = SqlDbType.Int;
                        q13.Value = Convert.ToInt32(reader2["id"]);
                        myCommandObj13.Parameters.Add(q13);
                        myCommandObj13.Connection.Open();
                        SqlDataReader reader3 = myCommandObj13.ExecuteReader();



                        if (reader3.Read())
                        {
                            if (Convert.ToInt32(reader3["NOH"]) == lnoh)
                            {
                                nuope += 0;
                            }
                            else
                            {
                                lnoh = Convert.ToInt32(reader3["NOH"]);
                                nuope += Convert.ToInt32(reader3["NOP"]);

                            }
                            if (Convert.ToInt32(reader2["MANA"]) == Convert.ToInt32(reader["id"]))
                                kam += Convert.ToDouble(reader2["KAMUT"]);
                            else
                                if (Convert.ToInt32(reader2["MANATOS"]) == Convert.ToInt32(reader["id"]))
                                    kam += Convert.ToDouble(reader2["KAMUTTOS"]);



                        }


                        reader3.Close();
                        myCommandObj13.Connection.Close();

                    }

                    yachs += kam / nuope;
                    if (nuope != -1)
                        yachc++;


                    reader2.Close();
                    myCommandObj12.Connection.Close();
                }//
                reader.Close();
                myCommandObj1.Connection.Close();
                nop.Text = Convert.ToString(Session["nop1"]);
                double nopd = Convert.ToDouble(Session["nop1"]);
                // Session["nop"] = nop.Text;
                yach = yachs / yachc;
                int kamut = Convert.ToInt32((int)((yach * nopd) + 0.5));
                if (kamut <= 0)
                    kamut = 1;



                /////////////////////////////////////////////////////////
                

                // Session["btnc"] = "was";
                Session["index1"] = "" + i;
                int ix = Convert.ToInt32(Session["index1"]); //chicken
                Session["" + ix] = "" + name + "," + Convert.ToString(kamut) + Convert.ToString(uom) + "*" + Convert.ToString(pfo) + ";" + Convert.ToString(kh) + ":" + Convert.ToString(ks) + "|";

            }//////
            //

            // }
        }


        else
            if (Convert.ToString(Session["maslul123"]) == "2")
            {

                string ms = "";
                int kamano = 0;
                int i = 0;
                int length = 0;
                Boolean ok = true;
                string s = "";
                while (ok)
                {
                    try
                    {
                        s = cb.Items[i].Text;
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
                    if (cb.Items[i].Selected)
                    {
                        ms += cb.Items[i].Text + ";";
                        kamano++;
                    }

                    i++;
                }

                string[] manaNames = ms.Split(';');
                manaNames = removeNull(manaNames);
                /////////////////////////////////////////////////////hjk
                if ((int)((((double)kamano) / 2.0) + 0.5) > Convert.ToInt32(nop.Text))
                {
                    Label1.Visible = true;
                    return;
                }
                else
                {
                    Label1.Visible = false;
                }

                for (int gsd = 0; gsd < manaNames.Length; gsd++)
                {

                    string name = manaNames[gsd];
                    int units = 0;
                    int kg = 0;

                    string myConnectionString = db.connectionString;
                    string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no ";
                    SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
                    SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                    SqlParameter q1 = new SqlParameter();
                    q1.ParameterName = "@no";
                    q1.SqlDbType = SqlDbType.VarChar;
                    q1.Value = name;
                    myCommandObj1.Parameters.Add(q1);
                    myCommandObj1.Connection.Open();
                    SqlDataReader reader = myCommandObj1.ExecuteReader();


                    while (reader.Read())
                    {
                        if (Convert.ToString(reader["UOM"]) == "units")
                            units++;
                        else
                            if (Convert.ToString(reader["UOM"]) == "kg")
                                kg++;

                    }

                    reader.Close();
                    myCommandObj1.Connection.Close();

                    string uom = "";
                    if (Math.Max(units, kg) == units)
                        uom = "units";
                    else
                        uom = "kg";

                    myConnectionString = db.connectionString;
                    mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo";
                    mySqlConnection = new SqlConnection(myConnectionString);
                    //  myCommandObj1.Connection.Close(); //shly
                    myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                    q1 = new SqlParameter();
                    q1.ParameterName = "@no";
                    q1.SqlDbType = SqlDbType.VarChar;
                    q1.Value = name;
                    myCommandObj1.Parameters.Add(q1);

                    SqlParameter q2 = new SqlParameter();
                    q2.ParameterName = "@uo";
                    q2.SqlDbType = SqlDbType.VarChar;
                    q2.Value = uom;
                    myCommandObj1.Parameters.Add(q2);

                    myCommandObj1.Connection.Open();
                    reader = myCommandObj1.ExecuteReader();

                    double pfo = 0;
                    int kh = 0;
                    int ks = 0;

                    double pfos = 0;
                    double khs = 0;
                    double kss = 0;

                    double pfoc = 0;
                    double khc = 0;
                    double ksc = 0;
                    while (reader.Read())
                    {
                        pfos += Convert.ToDouble(reader["PFO"]);
                        pfoc++;
                        khs += Convert.ToDouble(reader["KH"]);
                        khc++;
                        kss += Convert.ToDouble(reader["KS"]);
                        ksc++;

                    }
                    pfo = pfos / pfoc;
                    kh = Convert.ToInt32((int)((khs / khc) + 0.5));
                    ks = Convert.ToInt32((int)((kss / ksc) + 0.5));
                    reader.Close();
                    myCommandObj1.Connection.Close();



                    double yach = 0;
                    double yachs = 0;
                    double yachc = 0;


                    myConnectionString = db.connectionString;
                    mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo";
                    mySqlConnection = new SqlConnection(myConnectionString);
                    //  myCommandObj1.Connection.Close(); //shly
                    myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                    q1 = new SqlParameter();
                    q1.ParameterName = "@no";
                    q1.SqlDbType = SqlDbType.VarChar;
                    q1.Value = name;
                    myCommandObj1.Parameters.Add(q1);

                    q2 = new SqlParameter();
                    q2.ParameterName = "@uo";
                    q2.SqlDbType = SqlDbType.VarChar;
                    q2.Value = uom;
                    myCommandObj1.Parameters.Add(q2);

                    myCommandObj1.Connection.Open();
                    reader = myCommandObj1.ExecuteReader();

                    while (reader.Read())
                    {

                        string myConnectionString2 = db.connectionString;
                        string mySqlStr12 = "SELECT * FROM Past WHERE Past.MANA=@ma OR Past.MANATOS=@ma";
                        SqlConnection mySqlConnection2 = new SqlConnection(myConnectionString2);
                        SqlCommand myCommandObj12 = new SqlCommand(mySqlStr12, mySqlConnection2);


                        SqlParameter q12 = new SqlParameter();
                        q12.ParameterName = "@ma";
                        q12.SqlDbType = SqlDbType.Int;
                        q12.Value = Convert.ToInt32(reader["id"]);
                        myCommandObj12.Parameters.Add(q12);
                        myCommandObj12.Connection.Open();
                        SqlDataReader reader2 = myCommandObj12.ExecuteReader();
                        double nuope = 0;
                        double kam = 0;
                        int lnoh = -1;
                        while (reader2.Read())
                        {
                            string myConnectionString3 = db.connectionString;
                            string mySqlStr13 = "SELECT * FROM Events WHERE Events.MANOTMB<=@mm AND Events.MANOTME>=@mm";
                            SqlConnection mySqlConnection3 = new SqlConnection(myConnectionString3);
                            SqlCommand myCommandObj13 = new SqlCommand(mySqlStr13, mySqlConnection3);


                            SqlParameter q13 = new SqlParameter();
                            q13.ParameterName = "@mm";
                            q13.SqlDbType = SqlDbType.Int;
                            q13.Value = Convert.ToInt32(reader2["id"]);
                            myCommandObj13.Parameters.Add(q13);
                            myCommandObj13.Connection.Open();
                            SqlDataReader reader3 = myCommandObj13.ExecuteReader();



                            if (reader3.Read())
                            {
                                if (Convert.ToInt32(reader3["NOH"]) == lnoh)
                                {
                                    nuope += 0;
                                }
                                else
                                {
                                    lnoh = Convert.ToInt32(reader3["NOH"]);
                                    nuope += Convert.ToInt32(reader3["NOP"]);

                                }
                                //nuope = Convert.ToInt32(reader3["NOH"]);
                                if (Convert.ToInt32(reader2["MANA"]) == Convert.ToInt32(reader["id"]))
                                    kam += Convert.ToDouble(reader2["KAMUT"]);
                                else
                                    if (Convert.ToInt32(reader2["MANATOS"]) == Convert.ToInt32(reader["id"]))
                                        kam += Convert.ToDouble(reader2["KAMUTTOS"]);



                            }


                            reader3.Close();
                            myCommandObj13.Connection.Close();

                        }

                        yachs += kam / nuope;
                        if (nuope != -1)
                            yachc++;
                        //   manaNames[1000] = "";
                        reader2.Close();
                        myCommandObj12.Connection.Close();
                    }//



                    reader.Close();
                    myCommandObj1.Connection.Close();
                    double nopd = Convert.ToDouble(Session["nop1"]);
                    // Session["nop"] = nop.Text;
                    yach = yachs / yachc;
                    int kamut = Convert.ToInt32((int)((yach * nopd) + 0.5));
                    if (kamut <= 0)
                        kamut = 1;




                    /////////////////////////////////////////////////////////



                    // Session["btnc"] = "was";
                    //  int ind = -1;
                    //   if (Convert.ToString(Session["ar"]) != "ken")
                    //   {
                    Session["index1"] = "" + gsd;
                    int ix = Convert.ToInt32(Session["index1"]); //chicken
                    Session["" + ix] = "" + name + "," + Convert.ToString(kamut) + Convert.ToString(uom) + "*" + Convert.ToString(pfo) + ";" + Convert.ToString(kh) + ":" + Convert.ToString(ks) + "|";
                    //  Session["ma"] += "" + name + ",";
                    //Session["nop"] += "";
                    // }
                    // else
                    // {

                    //   for (int j = 0; j <= Convert.ToInt32(Session["index"]); j++)//j=1
                    //   {
                    //     string det = "" + Session["" + j];
                    //       if (det.IndexOf("" + Session["val"]) != -1)
                    //     {
                    //            ind = j;
                    //
                    ///
                    //       }
                    //  }
                    //  if (ind != -1)
                    //      Session["" + ind] = "" + name + "," + Convert.ToString(kamut) + Convert.ToString(uom) + "*" + Convert.ToString(pfo) + ";" + Convert.ToString(kh) + ":" + Convert.ToString(ks) + "|";

                    //    }

                }
            }
        // Response.Redirect("List.aspx?mas=3");
        Session["maslul1234"] = "4";
        /*
         string[] asd = new string[Convert.ToInt32(Session["index"])+1];
         for (int i = 0; i < asd.Length; i++)
             asd[i] = Convert.ToString(Session["" + i]);
         asd[1000] = "";
        */
        Response.Redirect("LoadingPage.aspx");
    }

    /* protected*/
    void btnOC(System.Object sender, EventArgs e)
    {
        if (Convert.ToString(Session["maslul123"]) == "1")
        {
            Session["eventType1"] = "" + Request.Form["eventType"];
            if ((int)((Convert.ToDouble(Session["index1"]) + 2.0) / 2.0 + 0.5) > Convert.ToInt32(Session["nop1"]) && ((Button)sender).Text == " + ")
            {
                Label1.Visible = true;
                return;
            }
            else
            {
                Label1.Visible = false;
            }
        }
        if (Convert.ToString(Session["maslul123"]) == "2")
        {
            Session["nop1"] = "" + Request.Form["nop"];
            Session["eventType1"] = "" + Request.Form["eventType"];
            if (Page.IsValid)
            {
                if (((Button)sender).Text == " + ")
                    Response.Redirect("~/Choose.aspx?msg=1", true);

                Session["val1"] = ((Button)sender).Text;
                Response.Redirect("~/Choose.aspx?msg=2", true);
            }
        }
        else
        {
            Session["nop1"] = "" + Request.Form["nop"];
            if (Page.IsValid)
            {
                if (((Button)sender).Text == " + ")
                    Response.Redirect("~/Insert.aspx?msg=1", true);

                Session["val1"] = ((Button)sender).Text;
                Response.Redirect("~/Insert.aspx?msg=2", true);
            }
        }


    }

    void lbOC(System.Object sender, EventArgs e)
    {
        Session["dp1"] = DropDownList1.Text; ;
        Response.Redirect("AddAllergens.aspx");
    }

}
