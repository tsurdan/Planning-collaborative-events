using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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




/// <summary>
/// Summary description for ws
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ws : System.Web.Services.WebService {
   
    public ws () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    [WebMethod]
    public Coins Exchange(Coins co)
    {






        string myConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Food Distribution\App_Data\Halukot.mdf;Integrated Security=True";
        string mySqlStr1 = "SELECT * FROM Gates WHERE Gates.COIN_NAME=@cn ";
        SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@cn";
        q1.SqlDbType = SqlDbType.VarChar;
        q1.Value = co.getName();
        myCommandObj1.Parameters.Add(q1);


        myCommandObj1.Connection.Open();
        SqlDataReader reader = myCommandObj1.ExecuteReader();

        double gate = -1;
        while (reader.Read())
        {
            gate = Convert.ToDouble(reader["GATE"]);
        }
        reader.Close();
        myCommandObj1.Connection.Close();


        string na="";
        double nu=0;
        if(gate!=-1)
        {
            nu = co.getNum() * gate;
            na = "ILS";
        }
        else
        {
            nu = co.getNum();
            na = co.getName();
        }
        Coins nc = new Coins(nu,na);
        return nc;
    }






    [WebMethod]
    public Coins newCoin(double nu, string na)
    {
        Coins nc = new Coins(nu, na);
        return nc;
    }

    [WebMethod]
    public double getNu(Coins co)
    {
        return co.getNum();
    }



    [WebMethod]
    public string getNa(Coins co)
    {
        return co.getName();
    }
}
