<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewBills.aspx.cs" Inherits="Electricity_Project.Pages.ViewBills" %>
<!DOCTYPE html>
<html>
<head><title>View Bills</title></head>
<body>
    <form id="form1" runat="server">
        <h2>Retrieve Last N Bills</h2>
        <asp:Label Text="Enter N:" runat="server" />
        <asp:TextBox ID="txtN" runat="server" /><br />
        <asp:Button ID="btnGetBills" Text="Get Bills" runat="server" OnClick="btnGetBills_Click" /><br />
        <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />
    </form>
</body>
</html>
