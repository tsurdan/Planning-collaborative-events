using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoadingPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["maslul123"]) == "1")
            img1.Attributes["src"] = ResolveUrl("images/loadingIcon1.gif");
        else
            if (Convert.ToString(Session["maslul123"]) == "2")
                img1.Attributes["src"] = ResolveUrl("images/loadingIcon2.gif");
            else
                if (Convert.ToString(Session["maslul123"]) == "3")
                    img1.Attributes["src"] = ResolveUrl("images/loadingIcon3.gif");
        System.Threading.Thread.Sleep(10);
    }
}