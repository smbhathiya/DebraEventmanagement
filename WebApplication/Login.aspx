<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Debra</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: url('Images/img1.jpg') no-repeat center center fixed;
            background-size: cover;
            font-family: Arial, sans-serif;
            color: #000;
            height: 100vh;
            margin: 0;
        }

        html, body {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background: rgba(255, 255, 255, 0.8);
            padding: 40px;
            border-radius: 15px;
        }

        .login-form {
            border-radius: 15px;
            padding: 40px;
            max-width: 500px;
            width: 70%;
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

        .carousel-container {
            width: 100%;
            background: rgba(255, 255, 255, 0.9); /* White background with 90% opacity */
            border-radius: 15px;
        }

        .carousel-item img {
            border-radius: 10px;
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
            <div class="carousel-container">
                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" data-interval="3000">
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img class="d-block w-100" src="Images/img1.jpg" alt="First slide">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="Images/img2.jpg" alt="Second slide">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="Images/img3.jpg" alt="Third slide">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="Images/img4.jpg" alt="Fourth slide">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="Images/img5.jpg" alt="Fifth slide">
                        </div>
                    </div>
                </div>
            </div>
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
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
