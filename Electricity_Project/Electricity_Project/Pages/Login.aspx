﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Electricity_Project.Pages.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="lblUsername" runat="server" Text="Username:" />
            <asp:TextBox ID="txtUsername" runat="server" />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
