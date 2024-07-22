<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPortal.aspx.cs" Inherits="WebApplication1.PaymentPortal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Portal</title>
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

        .container {
            margin-top: 30px;
        }

        .payment-details {
            background: rgba(255, 255, 255, 0.8);
            border: 1px solid #dee2e6;
            border-radius: 10px;
            padding: 30px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .form-control {
            font-size: 16px;
            padding: 10px;
        }

        .btn-primary {
            background-color: #212529;
            border-color: #212529;
            padding: 12px 24px;
            font-size: 18px;
            margin-top: 20px;
            transition: background-color 0.3s ease;
            width: 100%;
            margin-bottom: 50px;
        }

            .btn-primary:hover {
                background-color: #111111ff;
            }

            .btn-primary:active,
            .btn-primary:focus {
                background-color: #111111ff;
            }

        .lbl-error-message {
            font-size: 16px;
            margin-top: 10px;
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
                                                <a class="nav-link" href="Contact.aspx">Contact Us</a>
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

                <div class="container mt-4">
                    <div class="row payment-details">
                        <div class="col-md-12">
                            <h2>Payment Information</h2>
                            <div class="container mt-4">
                        <div class="row">
                            <div class="col-md-6">
                                <p><strong>Card Number:</strong>
                                    <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" required /></p>
                                <p><strong>Expiration Date:</strong>
                                    <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" /></p>
                                <p><strong>CVV:</strong>
                                    <asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" /></p>
                            </div>
                            <div class="col-md-6">
                                <p><strong>Cardholder Name:</strong>
                                    <asp:TextBox ID="txtCardholderName" runat="server" CssClass="form-control" /></p>
                                <p><strong>Billing Address:</strong>
                                    <asp:TextBox ID="txtBillingAddress" runat="server" CssClass="form-control" /></p>
                                <p><strong>Zip Code:</strong>
                                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" /></p>
                            </div>
                        </div>
                    </div>

                    <div class="container mt-4">
                        <h3>Order Summary</h3>
                        <p><strong>Ticket Price:</strong>
                            <asp:Label ID="lblTicketPrice" runat="server" Text="$0.00" CssClass="form-control" /></p>
                        <p><strong>Tickets Count:</strong>
                            <asp:Label ID="lblTicketsCount" runat="server" Text="0" CssClass="form-control" /></p>
                        <p><strong>Total Price:</strong>
                            <asp:Label ID="lblTotalPrice" runat="server" Text="$0.00" CssClass="form-control" /></p>
                    </div>

                            <div class="container mt-4">
                                <asp:Button ID="btnProcessPayment" runat="server" Text="Process Payment" OnClick="btnProcessPayment_Click" CssClass="btn btn-primary btn-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="footer-container">
                    <p>&copy; 2024 DEBRA Event Management Company. All rights reserved.</p>
                    <p>
                        Follow us on 
                        <a href="#">Facebook</a>, 
                        <a href="#">X</a>, 
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
