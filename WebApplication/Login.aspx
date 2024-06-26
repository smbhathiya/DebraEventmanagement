<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Debra</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #fff;
            font-family: Arial, sans-serif;
            color: #000;
        }
        .container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .login-form {
            border-radius: 15px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            padding: 40px;
            max-width: 500px;
            width: 100%;
            color: #000;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-control {
            border: 1px solid #ccc;
            border-radius: 20px;
            padding: 25px;
            font-size: 16px;
            text-align: center; 
            transition: box-shadow 0.3s ease, border-color 0.3s ease;
        }
        .form-control:focus {
            outline: none;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-color: #007bff;
        }
        .btn-login {
            background-color: #212529;
            border: none;
            border-radius: 20px;
            color: #fff;
            font-size: 16px;
            font-weight: bold;
            padding: 15px 0;
            width: 100%;
            transition: background-color 0.3s ease;
        }
        .btn-login:hover {
            background-color: #333;
            color: #fff;
        }
        .form-heading {
            text-align: center;
            margin-bottom: 40px;
            margin-top: 40px;
        }
        .form-heading .small-text {
            font-size: 32px;
        }
        .form-heading .large-text {
            font-size: 72px;
            font-weight: bold;
        }
        .registration-text {
            text-align: center;
            margin-top: 20px;
        }
        .registration-link {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }
        .registration-link:hover {
            text-decoration: underline;
        }
    </style>
    <script>
        function validateForm() {
            var email = document.getElementById("<%= txtEmail.ClientID %>").value;
            var password = document.getElementById("<%= txtPassword.ClientID %>").value;
            if (email == "" || password == "") {
                alert("Email and Password must be filled out");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div class="container">
        
        <div class="login-form">
            <h2 class="form-heading">
    <span class="small-text">Welcome to</span><br />
    <span class="large-text">DEBRA</span>
</h2>
            <div class="form-group">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email address" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" CssClass="btn btn-login" OnClientClick="return validateForm();" />
            <div class="registration-text">
                <span>Don't have an account? </span>
                <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/Registration.aspx" CssClass="registration-link">Click here to register</asp:HyperLink>
            </div>
        </div>
    </div>
</form>
</body>
</html>
