using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Begin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Convert.ToString(Session["userId1"]) == "" || Session["userId1"] == null)
            Response.Redirect("Login.aspx");
        if (Convert.ToString(Session["userId1"]) != "-1")
            LinkButton1.Visible = true;

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["maslul123"] = "1";
        Response.Redirect("LoadingPage.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Session["maslul123"] = "2";
        Response.Redirect("LoadingPage.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Session["maslul123"] = "3";
        Response.Redirect("LoadingPage.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewTable.aspx");
    }
}