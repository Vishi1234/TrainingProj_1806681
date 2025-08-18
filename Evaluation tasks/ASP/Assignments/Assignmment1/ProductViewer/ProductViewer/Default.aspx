<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductViewer.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product Viewer</title>
    <style>
        .container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
            text-align: center;
        }
        img {
            max-width: 100%;
            height: auto;
            margin-top: 15px;
            border-radius: 8px;
        }
        .price-label {
            font-size: 18px;
            font-weight: bold;
            color: green;
            margin-top: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2> Select a Product</h2>

            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" />

            <asp:Image ID="imgProduct" runat="server" />

            <br /><br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />

            <br />
            <asp:Label ID="lblPrice" runat="server" CssClass="price-label" />
        </div>
    </form>
</body>
</html>

