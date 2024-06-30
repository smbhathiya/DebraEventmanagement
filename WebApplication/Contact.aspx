<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us - DEBRA</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <style>
        body {
            background: url('Images/img1.jpg') no-repeat center center fixed;
            background-size: cover;
            font-family: Arial, sans-serif;
            color: #000;
            height: 100vh;
            margin: 0;
        }

        .top-bar {
            background-color: #212529;
            font-size: 40px;
            color: #fff;
            padding: 20px;
        }

        .top-bar h1 {
            font-weight: 700;
            margin: 0;
        }

        .top-bar h6 {
            margin: 0;
            font-size: 18px;
        }

        .navbar {
            margin-top: 10px;
        }

        .navbar-nav .nav-link {
            color: #fff !important;
            font-size: 18px;
            padding: 10px 15px;
        }

        .navbar-nav .nav-link.active {
            font-weight: bold;
        }

        .navbar-nav .nav-link:hover {
            color: #fddc5c;
            text-decoration: underline;
        }

        .navbar-toggler {
            border: none;
        }

        .navbar-toggler-icon {
            color: #212529;
        }

        .logout-btn {
            color: #fff;
            background-color: #212529;
            border: 1px solid #fff;
            padding: 5px 10px;
            font-size: 18px;
            border-radius: 5px;
            font-weight: bold;
        }

        .logout-btn:hover {
            background-color: #fff;
            color: #212529;
            font-weight: bold;
            text-decoration: none;
        }

        .footer {
            background-color: #212529;
            color: #fff;
            padding: 20px 0;
            text-align: center;
            margin-top: 20px;
        }

        .footer a {
            color: #fddc5c;
            text-decoration: none;
        }

        .footer a:hover {
            text-decoration: underline;
        }

        html, body {
            height: 100%;
            margin: 0;
        }

        .wrapper {
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        .content {
            flex: 1;
        }

        .contact-container {
            background-color: rgba(255, 255, 255, 0.8);
            padding: 40px;
            border-radius: 15px;
            max-width: 800px;
            margin: 20px auto; 
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-submit {
            background-color: #212529;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 18px;
            border-radius: 5px;
        }

        .btn-submit:hover {
            background-color: #000;
            color: #fff;
            text-decoration: none;
        }
        h2{
            font-weight:700;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="content">
                <div class="top-bar">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <h1>DEBRA</h1>
                                <h6>Event Management Company</h6>
                            </div>
                            <div class="col-md-6 d-flex justify-content-end align-items-center">
                                <nav class="navbar navbar-expand-lg navbar-dark">
                                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                                        <span class="navbar-toggler-icon"></span>
                                    </button>
                                    <div class="collapse navbar-collapse" id="navbarNav">
                                        <ul class="navbar-nav">
                                            <li class="nav-item">
                                                <a class="nav-link" href="Home.aspx">Home</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" href="About.aspx">About</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link active" href="Contact.aspx">Contact Us</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" href="userProfile.aspx">Profile</a>
                                            </li>
                                        </ul>
                                        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-btn ml-3" />
                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="contact-container">
                    <h2>Contact Us</h2>
                    <p>If you have any questions or inquiries, please fill out the form below and<br/> we'll get back to you as soon as possible.</p>

                    <div class="form-group">
                        <label for="fullName">Full Name</label>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your full name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="email">Email address</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="message">Message</label>
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3" placeholder="Write your message"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Send Message" CssClass="btn btn-submit"  />
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>

            </div>
            <div class="footer">
                <div class="container">
                    <p>&copy; 2024 DEBRA Event Management Company. All rights reserved.</p>
                    <p>
                        Follow us on
                        <a href="#">Facebook</a>,
                        <a href="#">Twitter</a>,
                        <a href="#">Instagram</a>
                    </p>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
