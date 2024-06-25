<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partnerProfile.aspx.cs" Inherits="WebApplication1.partnerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Partner Profile</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #fff;
            font-family: Arial, sans-serif;
            color: #000;
            height: 100vh;
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

        .page-title h3 {
            text-align: center;
            color: #212529;
            padding: 15px;
            font-weight: bold;
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

        .profile-info {
        padding: 40px;
        background-color: #f8f9fa;
        border-radius: 5px;
    }



    .profile-info strong {
        font-weight: bold;
    }


    .edit-buttons {
        margin-top: 10px;
    }

    .btn-primary {
        color: #fff;
        background-color: #212529;
        border-color: #212529;
        width: 100px;
    }



    .btn-secondary {
        color: #fff;
        background-color: #6c757d;
        border-color: #6c757d;
        width: 100px;
    }

    .btn-secondary:hover {
        color: #fff;
        background-color: #495057;
        border-color: #495057;
    }
    .table{
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
                                                <a class="nav-link " href="AdminDashboard.aspx">Dashboard</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" href="Home.aspx" target="_blank">View Events</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link active" href="partnerProfile.aspx">Profile</a>
                                            </li>

                                        </ul>
                                        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-btn ml-3" />
                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>

                    <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CssClass="table"
                        OnRowEditing="gvUser_RowEditing" OnRowUpdating="gvUser_RowUpdating" OnRowCancelingEdit="gvUser_RowCancelingEdit">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="profile-info">
                                        <div><strong>User Id:</strong>
                                            <asp:Label ID="lblEventId" runat="server" Text='<%# Eval("userId") %>'></asp:Label></div>
                                        <div><strong>Company Name:</strong>
                                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("company_name") %>'></asp:Label></div>
                                        <div><strong>Email:</strong>
                                            <asp:Label ID="lbl2" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                        </div>
                                        <div>
                                            <strong>Address:</strong>
                                            <asp:Label ID="lb3" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                        </div>
                                        <div>
                                            <strong>Contact No:</strong>
                                            <asp:Label ID="lbl4" runat="server" Text='<%# Eval("contact_no") %>'></asp:Label>
                                        </div>
                                        <div class="edit-buttons">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-sm" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="form-group">
                                        <div>
                                            <strong>User Id:</strong>
                                            <asp:TextBox ID="lblEventId" runat="server" Text='<%# Bind("userId") %>' CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">

                                        <label><strong>Company Name:</strong></label>
                                        <asp:TextBox ID="txtCompanyName" runat="server" Text='<%# Bind("company_name") %>' CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div>
                                            <strong>Email:</strong>
                                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
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
                                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary btn-sm" />
                                        <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-sm" />
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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


