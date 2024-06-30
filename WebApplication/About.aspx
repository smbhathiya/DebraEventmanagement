<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About DEBRA</title>
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

        .wrapper {
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        .content {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
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

        .about-content {
            background-color: rgba(255, 255, 255, 0.8);
            padding: 40px;
            border-radius: 15px;
            text-align: center;
            max-width: 800px;
            margin-top: 20px; 
        }

        .about-content h2 {
            font-size: 36px;
            margin-bottom: 20px;
        }

        .about-content h5 {
            font-size: 18px;
            line-height: 1.6;
            margin-bottom: 20px;
            padding:15px;
            border-radius:10px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
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

            <div class="content">
                <div class="about-content">
                    <h2>About DEBRA</h2>
                    <h5>DEBRA is a leading event management company specializing in creating memorable and impactful experiences for a wide range of events, from corporate gatherings to social celebrations. With a dedicated team of professionals and years of expertise, we ensure every event is meticulously planned and flawlessly executed.</h5>
                    <h5>Our mission is to exceed client expectations by delivering innovative event solutions that inspire and engage audiences. Whether you're planning a large-scale conference or an intimate gathering, DEBRA is your partner in turning your vision into reality.</h5>
                    <h5>Connect with us today and let us transform your event into an unforgettable experience!</h5>
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
