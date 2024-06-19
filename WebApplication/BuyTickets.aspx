<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyTickets.aspx.cs" Inherits="WebApplication1.BuyTickets" %>


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
                                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-btn ml-3" />
                            </div>

                        </nav>
                    </div>
                </div>
            </div>
        </div>





    </form>





    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
