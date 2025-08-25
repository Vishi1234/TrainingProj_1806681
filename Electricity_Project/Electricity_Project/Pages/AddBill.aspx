<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="Electricity_Project.Pages.AddBill" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Add Multiple Bills</title>
    <style>
        .consumer-block {
            border: 1px solid #ccc;
            padding: 10px;
            margin-bottom: 15px;
        }
        input[type="text"] {
            width: 300px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Add Electricity Bills</h2>

        <label>Number of Consumers:</label>
        <asp:TextBox ID="txtConsumerCount" runat="server" />
        <asp:Button ID="btnGenerate" runat="server" Text="Generate Fields" OnClick="btnGenerate_Click" />
        <asp:Button ID="btnBack" runat="server" Text="← Back" PostBackUrl="~/Pages/ConsumerActions.aspx" />
        <br /><br />

        <asp:PlaceHolder ID="phConsumers" runat="server" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Bills" OnClick="btnSubmit_Click" />
        <br /><br />
        <asp:Label ID="lblResult" runat="server" ForeColor="Green" />
    </form>
</body>
</html>
