<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAllergens.aspx.cs" Inherits="AddAllergens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Planning</title>
    <link rel="shortcut icon" href="images/logoMeal.png" />
</head>
<body style="background: url(images/FoodBGimg.png)">
    <form id="form1" runat="server" style="width: 552px; height: 595px; margin-left: 350px; background-color: white;">
        <div>

            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:CheckBoxList ID="dp" runat="server" Height="35px" Width="200px" Font-Size="Medium">
            </asp:CheckBoxList>

        </div>
        <div>


            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="End" BackColor="RoyalBlue" Height="40" Width="60" BorderColor="White" ForeColor="white" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <div id="div2" runat="server" visible="false" style="width: 552px; height: 50px; background-color: white;">
        </div>
    </form>
</body>
</html>
