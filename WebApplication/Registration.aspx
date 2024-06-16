<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication1.Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #fff;
            font-family: Arial, sans-serif;
            color: #000;
        }
        .top-bar {
            background-color: #000;
            font-size:40px;
            color: #fff;
            text-align: left;
            padding: 20px 10px 10px 20px;
        }
        .top-bar h1{
            font-weight:800;
        }
        .container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            height: 80vh;
        }
        .register-form {
            border-radius: 15px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 40px;
            max-width: 800px;
            width: 100%;
            color: #000;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-control {
            border: 1px solid #ccc;
            border-radius: 15px;
            padding: 22px;
            font-size: 16px;
            text-align: left; 
            transition: box-shadow 0.3s ease, border-color 0.3s ease;
        }
        .form-control:focus {
            outline: none;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-color: #007bff;
        }
        .btn-register {
            background-color: #000;
            border: none;
            border-radius: 15px;
            color: #fff;
            font-size: 16px;
            font-weight: bold;
            padding: 15px;
            width: 100%;
            transition: background-color 0.3s ease;
        }
        .btn-register:hover {
            background-color: #333;
            color: #fff;
        }
        .form-heading {
            text-align: center;
            margin-bottom: 40px;
            margin-top: 40px;
        }
        .form-heading .large-text {
            font-size: 40px;
            font-weight: bold;
        }
        .switch-container {
            text-align: center;
            margin-bottom: 20px;
        }
        .switch-container button {
            background-color: #fff;
            border: 1px solid #000;
            border-radius:15px;
            color: #000;
            cursor: pointer;
            font-size: 18px;
            font-weight: bold;
            padding: 10px 20px;
            margin: 0 5px;
            transition: background-color 0.3s ease, color 0.3s ease;
        }
        .switch-container button.active {
            background-color: #000;
            color: #fff;
            border-radius:15px;
        }
        .row {
            display: flex;
            flex-wrap: wrap;
        }
        .col-half {
            flex: 0 0 50%;
            max-width: 50%;
            padding: 0 10px;
            box-sizing: border-box;
        }
        .col-full {
            flex: 0 0 100%;
            max-width: 100%;
            padding: 0 10px;
            box-sizing: border-box;
        }
        label {
            font-weight: bold;
            margin-bottom: 5px;
            display: block;
        }
        .login-text {
            text-align: center;
            margin-top: 20px;
        }
        .login-link {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }
        .login-link:hover {
            text-decoration: underline;
        }
    </style>
    <script>
        function switchForm(type) {
            var userForm = document.getElementById('userForm');
            var partnerForm = document.getElementById('partnerForm');
            var userButton = document.getElementById('btnUser');
            var partnerButton = document.getElementById('btnPartner');
            var heading = document.getElementById('formHeading');

            if (type === 'user') {
                userForm.style.display = 'block';
                partnerForm.style.display = 'none';
                userButton.classList.add('active');
                partnerButton.classList.remove('active');
                heading.textContent = 'USER REGISTRATION';
            } else {
                userForm.style.display = 'none';
                partnerForm.style.display = 'block';
                userButton.classList.remove('active');
                partnerButton.classList.add('active');
                heading.textContent = 'PARTNER REGISTRATION';
            }
        }

        function validateForm() {
            var userPassword = document.getElementById('<%= txtUserPassword.ClientID %>').value;
            var userRePassword = document.getElementById('<%= txtUserRePassword.ClientID %>').value;
            var partnerPassword = document.getElementById('<%= txtPartnerPassword.ClientID %>').value;
            var partnerRePassword = document.getElementById('<%= txtPartnerRePassword.ClientID %>').value;

            if (userPassword !== userRePassword || partnerPassword !== partnerRePassword) {
                alert("Passwords do not match.");
                return false;
            }
            return true;
        }

        window.onload = function () {
            switchForm('user'); 
        };
    </script>
</head>
<body>
    <div class="top-bar">
        <h1>DEBRA</h1>
        <h6>Event Management Company</h6>
    </div>

    <form id="form1" runat="server">
        <div class="container">
            <h2 class="form-heading">
                <span id="formHeading" class="large-text">USER REGISTRATION</span>
            </h2>
            <div class="switch-container">
                <button type="button" id="btnUser" class="active" onclick="switchForm('user')">Register as User</button>
                <span>|</span>
                <button type="button" id="btnPartner" onclick="switchForm('partner')">Register as Partner</button>
            </div>
            <div id="userForm" class="register-form">
                <div class="row">
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtUserName.ClientID %>">Name</label>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Placeholder="Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtUserEmail.ClientID %>">Email address</label>
                            <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control" Placeholder="Email address" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtUserPassword.ClientID %>">Password</label>
                            <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtUserRePassword.ClientID %>">Re-enter Password</label>
                            <asp:TextBox ID="txtUserRePassword" runat="server" CssClass="form-control" Placeholder="Re-enter Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtUserAddress.ClientID %>">Address</label>
                            <asp:TextBox ID="txtUserAddress" runat="server" CssClass="form-control" Placeholder="Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtUserContact.ClientID %>">Contact No</label>
                            <asp:TextBox ID="txtUserContact" runat="server" CssClass="form-control" Placeholder="Contact No" TextMode="Phone"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-full">
                        <asp:Button ID="btnUserRegister" runat="server" OnClick="UserRegister_Click" Text="Register" CssClass="btn btn-register" OnClientClick="return validateForm();" />
                                    
                        <div class="login-text">
                            <span>Already have an account? </span>
                            <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx" CssClass="login-link">Click here to login</asp:HyperLink>
                        </div>

                    </div>
                </div>
            </div>
            <div id="partnerForm" class="register-form" style="display:none;">
                <div class="row">
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtPartnerCompanyName.ClientID %>">Company Name</label>
                            <asp:TextBox ID="txtPartnerCompanyName" runat="server" CssClass="form-control" Placeholder="Company Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtPartnerEmail.ClientID %>">Email address</label>
                            <asp:TextBox ID="txtPartnerEmail" runat="server" CssClass="form-control" Placeholder="Email address" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtPartnerPassword.ClientID %>">Password</label>
                            <asp:TextBox ID="txtPartnerPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtPartnerRePassword.ClientID %>">Re-enter Password</label>
                            <asp:TextBox ID="txtPartnerRePassword" runat="server" CssClass="form-control" Placeholder="Re-enter Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtPartnerAddress.ClientID %>">Address</label>
                            <asp:TextBox ID="txtPartnerAddress" runat="server" CssClass="form-control" Placeholder="Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-half">
                        <div class="form-group">
                            <label for="<%= txtPartnerContact.ClientID %>">Contact No</label>
                            <asp:TextBox ID="txtPartnerContact" runat="server" CssClass="form-control" Placeholder="Contact No" TextMode="Phone"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-full">
                        <asp:Button ID="btnPartnerRegister" runat="server" OnClick="PartnerRegister_Click" Text="Register" CssClass="btn btn-register" OnClientClick="return validateForm();" />

                        <div class="login-text">
                            <span>Already have an account? </span>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" CssClass="login-link">Click here to login</asp:HyperLink>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
