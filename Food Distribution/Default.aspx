<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Planning</title>
    <link rel="shortcut icon" href="images/logoMeal.png" />
</head>
<body style="background: url(images/FoodBGimg.png)">
    <form id="form1" runat="server" style="width: 552px; height: 595px; margin-left: 350px; background-color: white;">
        <div id="div1" runat="server" style="height: 200px; margin-left: 130px">

            <p style="margin-left: 20px">
                <br />
                The amount of people:<br />
                <asp:TextBox ID="nop" runat="server" Height="26px" Width="100px" Font-Size="Medium"></asp:TextBox>

                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nop" ErrorMessage="RequiredFieldValidator" ForeColor="Red">You must enter a number of people</asp:RequiredFieldValidator>
                <br />

                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="nop" ErrorMessage="RangeValidator" MaximumValue="2147483647" MinimumValue="2" Type="Integer" ForeColor="Red">The amount of people you entered does not match</asp:RangeValidator>
            </p>
            <p style="margin-left: 20px">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="It is impossible to add another dish. There are too many dishes in relative to the amount of people." Visible="False"></asp:Label>
            </p>
            <p style="margin-left: 20px">

                <asp:Label ID="maa" runat="server" Height="100px" Width="300px"></asp:Label>

            </p>


        </div>
        <div id="div2" runat="server" style="height: 300px; margin-left: 160px">
                        The event type:<br />
            <asp:TextBox ID="eventType" runat="server" Height="26px" Width="140px" Font-Size="Medium"></asp:TextBox>
            <br />
            <asp:RangeValidator ID="RangeValidator2" runat="server" MinimumValue="A" MaximumValue="zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz" ErrorMessage="RangeValidator" Text="The event type you entered does not match" Type="String" ControlToValidate="eventType" ForeColor="Red"></asp:RangeValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="You must enter an event type" ControlToValidate="eventType" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator0" runat="server" ErrorMessage="RegularExpressionValidator" Text="You must enter an event type " ValidationExpression="[a-zA-Z ]*$" ControlToValidate="eventType" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>

            <asp:CheckBoxList ID="cb" runat="server" Height="35px" Width="200px" Font-Size="Medium">
            </asp:CheckBoxList>


        </div>

        <div id="div3" runat="server" style="height: 332px; margin-left: 160px; width: 390px;">
            <br />


        </div>
    </form>




</body>
</html>
a