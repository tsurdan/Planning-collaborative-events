using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Split : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["maslul1234"]) == "4")
            Response.Redirect("List.aspx?mas=3");

        if (Convert.ToString(Session["maslul123"]) == "1")
            Response.Redirect("Default.aspx");

        if (Convert.ToString(Session["maslul123"]) == "2")
            Response.Redirect("Default.aspx");

        if (Convert.ToString(Session["maslul123"]) == "3")
            Response.Redirect("Default.aspx");


    }
}