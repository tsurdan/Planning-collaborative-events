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

public partial class Insert : System.Web.UI.Page
{
    public static int isd = 0;
    protected Boolean isExcitInData(string mana, string uom)
    {

        string myConnectionString = db.connectionString;
        string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo";
        SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);

        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@no";
        q1.SqlDbType = SqlDbType.VarChar;
        q1.Value = mana;

        SqlParameter q2 = new SqlParameter();
        q2.ParameterName = "@uo";
        q2.SqlDbType = SqlDbType.VarChar;
        q2.Value = uom;

        myCommandObj1.Parameters.Add(q1);
        myCommandObj1.Parameters.Add(q2);
        myCommandObj1.Connection.Open();
        SqlDataReader reader = myCommandObj1.ExecuteReader();


        while (reader.Read())
        {
            return true;
        }
        reader.Close();
        myCommandObj1.Connection.Close();
        return false;
    }

    protected string removeSpaces(string str)
    {
        return str.Replace(" ", String.Empty);
    }
    protected void UserCustomValidate(object source, ServerValidateEventArgs args)
    {

        //string str = args.Value;
        args.IsValid = true;
        if (isExcitInData(nom.Text, DropDownList1.Text) || Convert.ToString(Session["ar1"]) == "ken")
            return;
        if (Convert.ToString(Session["noLinkButtonClicked1"]) == "yes")
        {
            Session["noLinkButtonClicked1"] = "no";
            return;
        }

        string[] letters = new string[53];
        letters[0] = ""; letters[1] = "a"; letters[2] = "b"; letters[3] = "c"; letters[4] = "d"; letters[5] = "e"; letters[6] = "f"; letters[7] = "g"; letters[8] = "h"; letters[9] = "i"; letters[10] = "j"; letters[11] = "k"; letters[12] = "l"; letters[13] = "m"; letters[14] = "n"; letters[15] = "o"; letters[16] = "p"; letters[17] = "q"; letters[18] = "r"; letters[19] = "s"; letters[20] = "t"; letters[21] = "u"; letters[22] = "v"; letters[23] = "w"; letters[24] = "x"; letters[25] = "y"; letters[26] = "z"; letters[27] = "A"; letters[28] = "B"; letters[29] = "C"; letters[30] = "D"; letters[31] = "E"; letters[32] = "F"; letters[33] = "G"; letters[34] = "H"; letters[35] = "I"; letters[36] = "J"; letters[37] = "K"; letters[38] = "L"; letters[39] = "M"; letters[40] = "N"; letters[41] = "O"; letters[42] = "P"; letters[43] = "Q"; letters[44] = "R"; letters[45] = "S"; letters[46] = "T"; letters[47] = "U"; letters[48] = "V"; letters[49] = "W"; letters[50] = "X"; letters[51] = "Y"; letters[52] = "Z";
        string guess = "";
        string name = nom.Text + " ";
        int lng = -1;
        int lng0 = -1;
        string str = "";
        Boolean isSimilar = false;

        for (int i = 0; i < name.Length; i++)
        {
            //replace each charecter place to all alpha-beta to test if the new str is in the data
            for (int j = 0; j < letters.Length; j++)
            {
                if (i == 0)
                {
                    lng = name.Length - i - 1;
                    str = letters[j] + name.Substring(i + 1, lng);
                }
                if (i > 0 && i < name.Length - 1)
                {
                    lng0 = i - 0;
                    lng = name.Length - i - 1;
                    str = name.Substring(0, lng0) + letters[j] + name.Substring(i + 1, lng);
                }
                if (i > 0 && i == name.Length - 1)
                {
                    lng = name.Length - 1;
                    str = name.Substring(0, lng) + letters[j];

                }
                if (isExcitInData(removeSpaces(str), DropDownList1.Text))
                {
                    guess = removeSpaces(str);
                    isSimilar = true;
                    j = letters.Length;
                    i = name.Length;
                }
                else
                {

                    if (i > 0 && i < name.Length - 1)
                    {
                        lng0 = i - 0;//hala  2
                        lng = name.Length - i;
                        str = name.Substring(0, lng0) + letters[j] + name.Substring(i, lng);
                    }
                    if (isExcitInData(removeSpaces(str), DropDownList1.Text))
                    {
                        guess = removeSpaces(str);
                        isSimilar = true;
                        j = letters.Length;
                        i = name.Length;
                    }
                }

            }

        }


        if (isSimilar)
        {

            args.IsValid = false;
            //guess = "chicken";
            CustomValidator1.ErrorMessage = "Did you mean: " + guess + "?";
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
        }
        else
        {
            if (!isExcitInData(nom.Text, DropDownList1.Text))
            {
                div2.Visible = true;
            }
        }
        Session["noLinkButtonClicked1"] = "no";

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string fdg=Convert.ToString(Session["btnc"]);
        if (!Page.IsPostBack)
        {
            //  Session["btnc"] = "no";
            // int ind = -1;
            string str = "";
            if (Convert.ToInt32(Request.QueryString["msg"]) == 2)
            {
                for (int j = 0; j <= Convert.ToInt32(Session["index1"]); j++)
                {
                    string det = "" + Session["" + j];
                    if (det.IndexOf("" + Session["val1"]) != -1)
                    {
                        str = det;//ind = j; 


                    }
                }
                if (str != "")//(ind != -1)
                {
                    //str = Convert.ToString(Session[ind]);
                    string letter = "";
                    if (str.Substring(str.IndexOf(",") + 1, str.IndexOf("*") - str.IndexOf(",") - 1).IndexOf("units") != -1)
                        letter = "u";
                    else
                        if (str.Substring(str.IndexOf(",") + 1, str.IndexOf("*") - str.IndexOf(",") - 1).IndexOf("kg") != -1)
                            letter = "k";
                    int lng0 = str.IndexOf(",");
                    string naom = str.Substring(0, lng0);
                    int lng1 = str.IndexOf(letter) - str.IndexOf(",") - 1;
                    string kamutt = str.Substring(str.IndexOf(",") + 1, lng1);
                    int lng2 = str.IndexOf(";") - str.IndexOf("*") - 1;
                    string prfo = str.Substring(str.IndexOf("*") + 1, lng2);
                    int lng3 = str.IndexOf(":") - str.IndexOf(";") - 1;
                    string khh = str.Substring(str.IndexOf(";") + 1, lng3);         //,.;:|
                    int lng4 = str.IndexOf("|") - str.IndexOf(":") - 1;
                    string kss = str.Substring(str.IndexOf(":") + 1, lng4);

                    //     int lng5 = str.IndexOf("*") - str.IndexOf(letter) - 1;
                    //    string kamuttUom = str.Substring(str.IndexOf(letter) - 1, lng5);

                    this.nom.Text = naom;
                    this.kamut.Text = kamutt;

                    //  int[] ghj = new int[9];
                    //  ghj[1000] = 1;
                    this.pfo.Text = prfo;
                    this.kh.SelectedValue = khh;
                    this.ks.SelectedValue = kss;
                    if (str.Length - str.IndexOf("|") - 1 > 0)
                    {
                        int lng5 = str.Length - str.IndexOf("|") - 1;
                        string norkam = str.Substring(str.IndexOf("|") + 1, lng5);
                        this.tb1.Text = norkam;
                        div2.Visible = true;
                    }
                    string kamuttUom = "";
                    if (letter == "k")
                        kamuttUom = "kg";
                    else
                        if (letter == "u")
                            kamuttUom = "units";
                    for (int j = 0; j < 2; j++)
                        if (DropDownList1.Items[j].Text == kamuttUom)
                            DropDownList1.Items[j].Selected = true;
                    Session["ar1"] = "ken";
                }
            }
            else
            {
                Session["ar1"] = "lo";
                //   isd++;
                if (Session["index1"] != null && Session["index1"] != "")
                    Session["index1"] = "" + (Convert.ToInt32(Session["index1"]) + 1);
                else
                    Session["index1"] = "0";

            }
            // Session["index"] = isd;
            // Session["nop"] = Request.Form["nop"];
            // string str = "";
            //  int ind = 0;
            /*
            if(Session["naom"]!=null)
            {
            
                for(int j=0;j<Convert.ToInt32(Session["index"]);j++)
                {
                    str = Convert.ToString(Session["" + Session["index"]]).Substring(0, Convert.ToString(Session["" + Session["index"]]).IndexOf(","));
                    if(str==Session["naom"].ToString())
                    {
                        ind = j;
                        j = Convert.ToInt32(Session["index"]);
                    }

                } 
                this.nom.Text = Convert.ToString(Session["naom"]);
            }
            */
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            localhostws.ws aso = new localhostws.ws();
            localhostws.Coins doco = aso.newCoin(Convert.ToDouble(pfo.Text), DropDownList2.Text);
            localhostws.Coins fgh = aso.Exchange(doco);
            double nu = aso.getNu(fgh);

            //  double nu = Convert.ToDouble(pfo.Text);//aso.getNu(fgh);
            // Session["btnc"] = "was";
            int ind = -1;
            if (Convert.ToString(Session["ar1"]) != "ken")
            {
                int ix = Convert.ToInt32(Session["index1"]); //chicken
                Session["" + ix] = "" + nom.Text + "," + kamut.Text + DropDownList1.Text + "*" + Convert.ToString(nu) + ";" + kh.Text + ":" + ks.Text + "|" + tb1.Text;
                Session["ma1"] += "" + nom.Text + ",";
                if (ix % 6 == 0)
                    Session["ma1"] += "\n";
                //Session["nop"] += "";
            }
            else
            {

                for (int j = 0; j <= Convert.ToInt32(Session["index1"]); j++)//j=1
                {
                    string det = "" + Session["" + j];
                    if (det.IndexOf("" + Session["val1"]) != -1)
                    {
                        ind = j;


                    }
                }
                if (ind != -1)
                    Session["" + ind] = "" + nom.Text + "," + kamut.Text + DropDownList1.Text + "*" + Convert.ToString(nu) + ";" + kh.Text + ":" + ks.Text + "|" + tb1.Text;

            }


            Response.Redirect("Default.aspx?ms=1");

        }
        // Response.Redirect("idiot.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string str = CustomValidator1.ErrorMessage;
        int lng = str.IndexOf("?") - str.IndexOf(":") - 1;
        string guess = str.Substring(str.IndexOf(":") + 1, lng);
        guess = guess.Replace(" ", String.Empty);
        nom.Text = guess;
        LinkButton1.Visible = false;
        LinkButton2.Visible = false;
        CustomValidator1.Visible = false;
        div2.Visible = false;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        CustomValidator1.IsValid = true;
        if (!IsPostBack)
            Session["noLinkButtonClicked1"] = "yes";
        LinkButton1.Visible = false;
        LinkButton2.Visible = false;
        CustomValidator1.Visible = false;
        div2.Visible = true;

    }
}