<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyTickets.aspx.cs" Inherits="WebApplication1.BuyTickets" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buy Tickets</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
            color: #333;
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

        .event-details {
            background-color: #fff;
            border: 1px solid #dee2e6;
            border-radius: 10px;
            padding: 30px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

            .event-details img {
                max-width: 100%;
                border-radius: 10px;
                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                transition: transform 0.3s ease;
            }

                .event-details img:hover {
                    transform: scale(1.1);
                }

            .event-details h2 {
                font-size: 36px;
                color: #343a40;
                margin-top: 20px;
                margin-bottom: 20px;
            }

            .event-details p {
                font-size: 18px;
                color: #6c757d;
                margin-bottom: 8px;
            }

            .event-details strong {
                color: #343a40;
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

        .section-container {
            background-color: #f8f9fa;
            padding: 20px;
            margin-bottom: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .section-title {
            font-size: 24px;
            font-weight: bold;
            color: #343a40;
            margin-bottom: 10px;
        }

        .section-content {
            font-size: 18px;
            color: #6c757d;
            margin-bottom: 10px;
        }

            .section-content strong {
                color: #343a40;
            }

        h2 {
            font-weight: bold;
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
            <div class="row event-details">
                <div class="col-md-4">
                    <asp:Image ID="imgEvent" runat="server" CssClass="img-fluid rounded shadow-sm" />
                </div>
                <div class="col-md-8">
                    <div class="container">
                        <h2>
                            <asp:Label ID="lblEventNameValue" runat="server" Text=""></asp:Label></h2>
                        <p>
                            <asp:Label ID="lblDescriptionValue" runat="server" Text=""></asp:Label></p>
                    </div>
                    <div class="container mt-4">
                        <div class="row">
                            <div class="col-md-6">
                                <p><strong>Date:</strong>
                                    <asp:Label ID="lblDateValue" runat="server" Text=""></asp:Label></p>
                                <p><strong>Time:</strong>
                                    <asp:Label ID="lblTimeValue" runat="server" Text=""></asp:Label></p>
                                <p><strong>Location:</strong>
                                    <asp:Label ID="lblLocationValue" runat="server" Text=""></asp:Label></p>
                                <p><strong>Company Name:</strong>
                                    <asp:Label ID="lblCompanyNameValue" runat="server" Text=""></asp:Label></p>
                            </div>
                            <div class="col-md-6">
                                <p><strong>Ticket Price:</strong>
                                    <asp:Label ID="lblTicketPriceValue" runat="server" Text=""></asp:Label></p>
                                <p><strong>Available Tickets:</strong>
                                    <asp:Label ID="lblRemainingTicketsValue" runat="server" Text=""></asp:Label></p>
                            </div>
                        </div>
                    </div>
                    <div class="container mt-4">
                        <p><strong>Number of Tickets:</strong>
                            <asp:TextBox ID="txtTicketCount" runat="server" CssClass="form-control" /></p>
                        <asp:Button ID="btnBuyTickets" runat="server" Text="Buy Tickets" OnClick="btnBuyTickets_Click" CssClass="btn btn-primary btn-block" />
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="lbl-error-message" ForeColor="Red" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
</div>
            <div class="footer">
                <div class="container">
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
