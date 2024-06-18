<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebApplication1.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
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
                                        <a class="nav-link active" href="AdminDashboard.aspx">Dashboard</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="About.aspx">About</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ContactUs.aspx">Contact Us</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="action">Profile</a>
                                    </li>

                                </ul>
                                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-btn ml-3" />
                            </div>
                        </nav>
                    </div>
                </div>
            </div>
        </div>

        <div class="container d-flex justify-content-center">
            <div class="row mb-3">
                <div class="col-md-8">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter Event Name"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:Button ID="btnAddEvent" runat="server" Text="Search Event" CssClass="btn btn-custom" />
                </div>
            </div>
        </div>

        <div class="table-container">
            <asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowEditing="gvEvents_RowEditing" OnRowUpdating="gvEvents_RowUpdating" OnRowCancelingEdit="gvEvents_RowCancelingEdit">
                <Columns>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("company_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Event ID">
                        <ItemTemplate>
                            <asp:Label ID="lblEventId" runat="server" Text='<%# Eval("eventid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Event Name">
                        <ItemTemplate>
                            <asp:Label ID="lblEventName" runat="server" Text='<%# Eval("event_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ticket Price">
                        <ItemTemplate>
                            <asp:Label ID="lblTicketPrice" runat="server" Text='<%# Eval("ticket_price",  "Rs. {0:N}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sold Tickets">
                        <ItemTemplate>
                            <asp:Label ID="lblSoldTickets" runat="server" Text='<%# Eval("soldTickets") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remaining Tickets">
                        <ItemTemplate>
                            <asp:Label ID="lblRemainingTickets" runat="server" Text='<%# Eval("remainingTickets") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Commission Rate">
                        <ItemTemplate>
                            <asp:Label ID="lblCommissionRate" runat="server" Text='<%# Eval("commissionRate") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCommissionRate" runat="server" Text='<%# Bind("commissionRate") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estimated Income">
                        <ItemTemplate>
                            <asp:Label ID="lblEstimatedIncome" runat="server" Text='<%# Eval("EstimatedIncome",  "Rs. {0:N}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Current Income">
                        <ItemTemplate>
                            <asp:Label ID="lblCurrentIncome" runat="server" Text='<%# Eval("CurrentIncome",  "Rs. {0:N}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Commission">
                        <ItemTemplate>
                            <asp:Label ID="lblCommission" runat="server" Text='<%# Eval("commission",  "Rs. {0:N}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-sm"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm" Style="margin: 2px;"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-sm" Style="margin: 2px;"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("eventid") %>' Text="Delete" OnClick="DeleteEvent_Click" OnClientClick="return confirm('Are you sure you want to delete this event?');" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
