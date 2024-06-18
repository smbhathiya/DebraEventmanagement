<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #fff;
            font-family: Arial, sans-serif;
            color: #000;
        }

        .top-bar {
            background-color: #000;
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

        .navbar-toggler {
            background-color: #fff;
            border: none;
        }

        .navbar-toggler-icon {
            color: #000;
        }

        .logout-btn {
            background-color: #fff;
            color: #000;
            border: 1px solid #fff;
            padding: 5px 10px;
            font-size: 18px;
            border-radius: 5px;
        }

        .logout-btn:hover {
            background-color: #ccc;
            color: #000;
            font-weight:bold;
        }
    </style>
</head>
<body>
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
                                    <a class="nav-link" href="ContactUs.aspx">Contact Us</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active" href="action">Profile</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active" href="action">Logout</a>
                                </li>
                            </ul>
                        </div>
                    </nav>                  
                </div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <!-- Page Content -->
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
