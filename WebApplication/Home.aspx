<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />

    <style>
        body {
            background-color: #fff;
            font-family: Arial, sans-serif;
            color: #000;
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

        .event-card {
            border: 1px solid #ddd;
            border-radius: 10px;
            padding: 20px;
            margin-bottom: 20px;
            display: flex;
            align-items: center;
            background-color: #f8f9fa;
        }

        .event-image {
            flex: 0 0 auto;
            margin-right: 20px;
            width: 100%;
            height: auto;
        }

        .event-image-container {
            width: 200px;
            height: 300px;
            overflow: hidden;
            margin: 25px;
        }

        .event-details {
            flex: 1 1 auto;
        }

            .event-details h3 {
                margin-top: 0;
            }

            .event-details p {
                margin: 0;
                font-size: 16px;
            }

                .event-details p.important {
                    font-size: 18px;
                    font-weight: bold;
                }

        .footer {
            background-color: #212529;
            color: #fff;
            padding: 20px 0;
            text-align: center;
        }

            .footer a {
                color: #fddc5c;
                text-decoration: none;
            }

                .footer a:hover {
                    text-decoration: underline;
                }

        #back-to-top {
            position: fixed;
            bottom: 40px;
            right: 40px;
            z-index: 1000;
        }

            #back-to-top a {
                display: block;
                width: 50px;
                height: 50px;
                background-color: #212529;
                border-radius: 50%;
                text-align: center;
                line-height: 50px;
                color: #fff;
                font-size: 24px;
                text-decoration: none;
            }

                #back-to-top a:hover {
                    background-color: #000;
                    color: #fff;
                }

                        .btn-primary {
            background-color: #212529;
            border-color: #212529;
            padding: 8px 12px;
            font-size: 18px;
            margin-top: 20px;
            transition: background-color 0.3s ease;
            width: 40%;
        }
        .btn-primary:hover {
            background-color: #111111ff;
        }
        .btn-primary:active,
        .btn-primary:focus {
            background-color: #111111ff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

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
                                        <a class="nav-link active" href="Home.aspx">Home</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="About.aspx">About</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="Contact.aspx">Contact Us</a>
                                    </li>
                                    <li class="nav-item">
                                         <a class="nav-link" href="Profile.aspx">Profile</a>
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
            <asp:Repeater ID="EventRepeater" runat="server"  OnItemCommand="EventRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="event-card">
                        <div class="event-image-container">
                            <asp:Image ID="EventImage" runat="server" CssClass="event-image" ImageUrl='<%# Eval("imageUrl") %>' />
                        </div>
                        <div class="event-details">
                            <h2><%# Eval("event_name") %></h2>
                            <p class="important"><%# Eval("description") %></p>
                            <p>Time: <span class="important"><%# Eval("time") %></span></p>
                            <p>Date: <span class="important"><%# Eval("date") %></span></p>
                            <p>Location: <span class="important"><%# Eval("location") %></span></p>
                            <p>Ticket Price: <span class="important"><%# Eval("ticket_price","Rs. {0:N}") %></span></p>
                            <p>Organized by: <span class="important"><%# Eval("company_name") %></span></p>
                            <asp:Button ID="BuyTicketsButton" runat="server" Text="Buy Tickets" CssClass="btn btn-primary mt-4" CommandArgument='<%# Eval("eventid") %>' CommandName="BuyTickets" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
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

    </form>

    <div id="back-to-top" class="back-to-top">
        <a href="#top">
            <i class="fas fa-chevron-up"></i>
        </a>
    </div>
        <script>

            window.onscroll = function () {
                const backToTopButton = document.getElementById('back-to-top');
                if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
                    backToTopButton.style.display = 'block';
                } else {
                    backToTopButton.style.display = 'none';
                }
            };

            document.getElementById('back-to-top').addEventListener('click', function (e) {
                e.preventDefault();
                window.scrollTo({ top: 0, behavior: 'smooth' });
            });
        </script>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
