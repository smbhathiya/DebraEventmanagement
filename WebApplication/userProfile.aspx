<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="WebApplication1.Profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
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
            margin: 40px;
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

.profile-card {
        background-color: #fff;
        border-radius: 10px;
        padding: 20px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        max-width: 800px;
        width: 100%;
    }

    .profile-info {
        display: flex;
        flex-direction: column;
        gap: 10px;
    }

    .profile-info-item {
        display: flex;
        justify-content: space-between;
        padding: 10px;
        background-color: #f8f9fa;
        border-radius: 5px;
    }

    .profile-info-item strong {
        font-weight: bold;
    }

    .profile-edit-form {
        display: flex;
        flex-direction: column;
        gap: 10px;
    }

    .profile-edit-form .form-group {
        margin-bottom: 1rem;
    }

    .profile-edit-form .form-group label {
        margin-bottom: 0.5rem;
        font-weight: bold;
    }

    .profile-edit-form .form-control {
        width: 100%;
        padding: 10px;
        font-size: 16px;
        border-radius: 5px;
        border: 1px solid #ccc;
    }

    .edit-buttons {
        display: flex;
        gap: 10px;
        justify-content: flex-end;
        margin-top: 10px;
    }

    .edit-buttons .btn {
        padding: 10px 20px;
        font-size: 16px;
    }
        .profile-table th {
        background-color: #fff !important;
        color: #000 !important;
        text-align: left;
        padding: 0px;
        font-size: 18px;
        border-color:white;
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
                                                <a class="nav-link active" href="userProfile.aspx">Profile</a>
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
    <div class="profile-card mx-auto">
        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CssClass="table profile-table"
            OnRowEditing="gvUser_RowEditing" OnRowUpdating="gvUser_RowUpdating" OnRowCancelingEdit="gvUser_RowCancelingEdit">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="profile-info">
                            <div class="profile-info-item">
                                <strong>User Id:</strong>
                                <asp:Label ID="lblEventId" runat="server" Text='<%# Eval("userId") %>'></asp:Label>
                            </div>
                            <div class="profile-info-item">
                                <strong>Company Name:</strong>
                                <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                            </div>
                            <div class="profile-info-item">
                                <strong>Email:</strong>
                                <asp:Label ID="lbl2" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                            </div>
                            <div class="profile-info-item">
                                <strong>Address:</strong>
                                <asp:Label ID="lb3" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                            </div>
                            <div class="profile-info-item">
                                <strong>Contact No:</strong>
                                <asp:Label ID="lbl4" runat="server" Text='<%# Eval("contact_no") %>'></asp:Label>
                            </div>
                            <div class="edit-buttons">
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-md" />
                            </div>
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="profile-edit-form">
                            <div class="form-group">
                                <label><strong>User Id:</strong></label>
                                <asp:TextBox ID="txtUserId" runat="server" Text='<%# Bind("userId") %>' CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label><strong>User Name:</strong></label>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("name") %>' CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label><strong>Email:</strong></label>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label><strong>Address:</strong></label>
                                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("address") %>' CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label><strong>Contact No:</strong></label>
                                <asp:TextBox ID="txtContactNo" runat="server" Text='<%# Bind("contact_no") %>' CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="edit-buttons">
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-md" />
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-md" />
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>




                <div class="mt-4">
                    <div class="table-container">
                        <asp:GridView ID="GridViewPurchasedTickets" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Sales ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesId" runat="server" Text='<%# Eval("salesid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSalesId" runat="server" Text='<%# Bind("salesid") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEventName" runat="server" Text='<%# Eval("event_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEventName" runat="server" Text='<%# Bind("event_name") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("location") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLocation" runat="server" Text='<%# Bind("location") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("time") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tickets Purchased">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTicketsPurchased" runat="server" Text='<%# Eval("tickets_purchased") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTicketsPurchased" runat="server" Text='<%# Bind("tickets_purchased") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ticket Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTicketPrice" runat="server" Text='<%# String.Format("Rs. {0:N}", Eval("ticket_price")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTicketPrice" runat="server" Text='<%# Bind("ticket_price") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalPrice" runat="server" Text='<%# String.Format("Rs. {0:N}", Eval("total_price")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%# Bind("total_price") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
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
