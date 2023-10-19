<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadingPage.aspx.cs" Inherits="LoadingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Planning</title>
    <link rel="shortcut icon" href="images/logoMeal.png" />

    <script type="text/javascript">
        window.onload = function () {
            setTimeout(myFunction, 2000);
        }
        function myFunction() {

            window.location.replace("Split.aspx");
        }
    </script>

</head>
<body style="background: url(images/FoodBGimg.png)">

    <div style="width: 552px; height: 609px; margin-left: 350px; background-color: white; margin-top: 0px; margin-bottom: 0px">

        <img id="img1" runat="server" style="height: 400px; width: 552px;" />

        <img src="images/loadingIconText.gif" style="height: 150px; width: 250px; margin-left: 160px; margin-top: 0px;" />
    </div>
</body>
</html>
