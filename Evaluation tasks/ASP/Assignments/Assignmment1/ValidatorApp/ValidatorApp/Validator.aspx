<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ValidatorApp.Validator" %>

<!DOCTYPE html>
<html>
<head>
    <title>Validator Form</title>
    <style>
        .container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: #f4f4f4;
            border-radius: 10px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            font-weight: bold;
        }
        .error {
            color: red;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Validator Form</h2>

            <div class="form-group">
                <label>Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Family Name:</label>
                <asp:TextBox ID="txtFamilyName" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>City:</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Zip Code:</label>
                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" CssClass="btn btn-primary" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" CssClass="error" />
        </div>
    </form>
</body>
</html>
