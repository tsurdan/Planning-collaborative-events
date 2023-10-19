<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Insert.aspx.cs" Inherits="Insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Planning</title>
    <link rel="shortcut icon" href="images/logoMeal.png" />
</head>
<body style="height: 805px; background: url(images/FoodBGimg.png)">
    <form id="ins" runat="server" style="width: 552px; height: 1083px; margin-left: 350px; background-color: white;">
        <div style="height: 716px; margin-left: 56px" aria-atomic="True">
            The name of the dish:<br />
            <asp:TextBox ID="nom" runat="server"></asp:TextBox>
            <br />
            <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="A" MaximumValue="zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz" ErrorMessage="RangeValidator" Text="The name of the dish you entered does not match" Type="String" ControlToValidate="nom" ForeColor="Red"></asp:RangeValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter a name" ControlToValidate="nom" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator0" runat="server" ErrorMessage="RegularExpressionValidator" Text="You must enter a name " ValidationExpression="[a-zA-Z ]*$" ControlToValidate="nom" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="UserCustomValidate" ControlToValidate="nom" ErrorMessage="rtyu" ForeColor="#000066"></asp:CustomValidator>
            &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Visible="False" OnClick="LinkButton1_Click">yes</asp:LinkButton>
            &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" Visible="False" OnClick="LinkButton2_Click">no</asp:LinkButton>
            <br />
            <br />
            The amount of the dish:<br />
            <asp:TextBox ID="kamut" runat="server"></asp:TextBox>

            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>units</asp:ListItem>
                <asp:ListItem>kg</asp:ListItem>

            </asp:DropDownList>

            <br />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter amount" ControlToValidate="kamut" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Text="You must enter a number" ValidationExpression="\d+" ControlToValidate="kamut" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <br />
            Price per one:<br />
            <asp:TextBox ID="pfo" runat="server"></asp:TextBox>

            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>ILS</asp:ListItem>
                <asp:ListItem>Dollar</asp:ListItem>
                <asp:ListItem>Pound</asp:ListItem>
                <asp:ListItem>Yuan</asp:ListItem>
                <asp:ListItem>Euro</asp:ListItem>
                <asp:ListItem>BTC</asp:ListItem>
            </asp:DropDownList>

            <br />

            <asp:RangeValidator ID="RangeValidator2" runat="server" MinimumValue="0.0000001" MaximumValue="60000000000" ErrorMessage="RangeValidator" Text=" Price per one you entered does not match" Type="Double" ControlToValidate="pfo" ForeColor="Red"></asp:RangeValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter price per one" ControlToValidate="pfo" ForeColor="Red"></asp:RequiredFieldValidator>




            <br />
            <br />
            The difficulty level of making the dish:<asp:RadioButtonList ID="kh" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>

            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter a difficulty level" ControlToValidate="kh" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            The difficulty level of carrying the dish:<br />
            <asp:RadioButtonList ID="ks" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>

            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter a difficulty level" ControlToValidate="ks" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <div id="div2" runat="server" visible="false">
                <asp:Label ID="lb1" runat="server" Text="You added a new dish that the site didn't recognize. What is the normal amount to be brought by a single person ?"></asp:Label>
                <br />

                &nbsp;<asp:TextBox ID="tb1" runat="server" Width="119px"></asp:TextBox>

                <br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter a number" ControlToValidate="tb1" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" Text="You must enter a number" ValidationExpression="\d+" ControlToValidate="tb1" ForeColor="Red"></asp:RegularExpressionValidator>
                <br />
                <br />
                <br />
            </div>

            <asp:TableCell runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Continue" BackColor="RoyalBlue" Height="40px" Width="100px" BorderColor="White" ForeColor="White" />

            </asp:TableCell>
        </div>
    </form>
</body>
</html>
