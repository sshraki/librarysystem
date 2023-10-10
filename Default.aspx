<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksApp.Login" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Library Management System</title>
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/signin.css" rel="stylesheet" />
    <style>
       body {
    background-image: url('Images/lib.jpg');
}
    </style>
</head>
<body>
    <div class="container" style="width:50% !important; text-align:center;justify-items:center;padding-top:150px;"> 
        <h3 style="font-weight:600;color:white;">Library Management System</h3>

        <form class="form-signin" runat="server">
            <label for="inputUserName" class="sr-only">User Name</label>
            <input type="text" id="inputUserName" class="form-control" placeholder="User Name" runat="server"
                required autofocus />
            <label for="inputPassword" class="sr-only">Password</label>
            <input type="password" runat="server" id="inputPassword" class="form-control" placeholder="Password"
                required />
            <asp:Button runat="server" CssClass="btn btn-lg btn-primary btn-block" 
                Text="Sign In" ID="btnLogin" OnClick="btnLogin_Click" />
        </form>
        <label id="lbl" runat="server" style="color:red;"></label>
    </div>
</body>
</html>
