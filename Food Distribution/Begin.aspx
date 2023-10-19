<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Begin.aspx.cs" Inherits="Begin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Planning</title>
    <link rel="shortcut icon" href="images/logoMeal.png" />
    <style type="text/css">
        .auto-style1 {
            width: 268px;
            height: 136px;
        }

        .auto-style2 {
            width: 486px;
            height: 335px;
        }

        .auto-style3 {
            width: 523px;
            height: 347px;
        }

        .auto-style4 {
            width: 518px;
            height: 345px;
        }
    </style>
</head>
<body style="background: url(images/FoodBGimg.png)">
    <<form id="form1" runat="server" style="width: 700px; height: 1200px; margin-left: 300px; background-color: white;">


        <img style="margin-left: 217px" alt="" class="auto-style1" src="images/evpl.png" />



        <div>

            <asp:ImageButton ID="ImageButton1" CssClass="auto-style2" runat="server" ImageUrl="images/robot1.png" OnClick="ImageButton1_Click" />
            <asp:ImageButton ID="ImageButton2" CssClass="auto-style3" runat="server" ImageUrl="images/robot2.png" OnClick="ImageButton2_Click" />
            <asp:ImageButton ID="ImageButton3" CssClass="auto-style4" runat="server" ImageUrl="images/robot3.png" OnClick="ImageButton3_Click" />

            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">View past divisions</asp:LinkButton>

        </div>






    </form>
</body>
</html>
