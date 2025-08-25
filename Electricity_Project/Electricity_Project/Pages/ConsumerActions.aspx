<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumerActions.aspx.cs" Inherits="YourNamespace.ConsumerActions" %>

<!DOCTYPE html>
<html>
<head>
    <title>Consumer Electricity Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Consumer Electricity Management Portal</h2>

        <asp:Button ID="btnAddConsumer" runat="server" Text="Add Consumer" OnClick="btnAddConsumer_Click" />
        <br /><br />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Consumers" OnClick="btnShowAll_Click" />
        <br /><br />
        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Consumer" OnClick="btnRetrieve_Click" />
        <br /><br />

        <asp:Panel ID="pnlConsumerInput" runat="server" Visible="false">
        <br />
        <asp:Label ID="lblConsumerPrompt" runat="server" Text="Enter Consumer Number:" />
        <asp:TextBox ID="txtConsumerNumber" runat="server" />
        <br /><br />
        <asp:Button ID="btnShowDetails" runat="server" Text="Show Details" OnClick="btnShowDetails_Click" />
        </asp:Panel>

        <asp:Panel ID="Panel1" runat="server" Visible="false">
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" />
        </asp:Panel>

        <asp:Panel ID="pnlOutput" runat="server" Visible="false">
            <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
