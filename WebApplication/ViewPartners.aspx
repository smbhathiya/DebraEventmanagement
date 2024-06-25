<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPartners.aspx.cs" Inherits="WebApplication1.ViewPartners" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Partners</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
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

        .table {
            width: 100%;
            max-width: 100%;
            margin-bottom: 1rem;
            background-color: transparent;
            border-collapse: separate;
            border-spacing: 0;
            border-radius: 10px;
            overflow: hidden;
        }


            .table th,
            .table td {
                border: 1px solid #ddd;
            }


        .table-container {
            margin: 20px;
        }

        .table th {
            background-color: #212529;
            color: #fff;
        }

        .table th,
        .table td {
            padding: 0.75rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }

        .table thead th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
        }

        .table tbody + tbody {
            border-top: 2px solid #dee2e6;
        }

        .table .table {
            background-color: #fff;
        }

        .container {
            margin-top: 20px;
        }

        .btn-custom {
            background-color: #212529;
            color: #fff;
            border-radius: 15px;
            transition: background-color 0.3s ease;
        }

            .btn-custom:hover {
                background-color: #0f0f0f;
                color: #fff;
            }

        .form-control {
            border: 1px solid #ccc;
            border-radius: 15px;
            padding: 10px;
            font-size: 16px;
            text-align: left;
            transition: box-shadow 0.3s ease, border-color 0.3s ease;
        }

            .form-control:focus {
                outline: none;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                border-color: #007bff;
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
                                                <a class="nav-link" href="AdminDashboard.aspx">Dashboard</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" href="Home.aspx" target="_blank">View Events</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link active" href="ViewPartners.aspx">Partners</a>
                                            </li>

                                        </ul>
                                        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-btn ml-3" />
                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="table-container">
                    <asp:GridView ID="gvPartners" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                        <Columns>
                            <asp:TemplateField HeaderText="Company Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("company_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact No">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("contact_no") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("email") %>' Text="Delete" OnClick="DeleteEvent_Click" OnClientClick="return confirm('Are you sure you want to delete this partner?');" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
