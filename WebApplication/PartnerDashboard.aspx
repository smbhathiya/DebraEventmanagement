<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartnerDashboard.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Events</title>
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
                background-color: #333;
                color: #fff;
            }

        .section {
            margin-bottom: 20px;
        }

        .hidden {
            display: none;
        }

        .form-group {
            margin-bottom: 20px;
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



        .upload-label,
        .description-label {
            display: block;
            margin-bottom: 5px;
        }

        .file-upload {
            position: relative;
            overflow: hidden;
            display: inline-block;
            vertical-align: middle;
        }

        .inputfile {
            position: absolute;
            top: 0;
            right: 0;
            margin: 0;
            padding: 0;
            font-size: 20px;
            cursor: pointer;
            opacity: 0;
        }

        .file-upload-btn {
            cursor: pointer;
            background-color: #212529;
            color: #fff;
            border-radius: 10px;
            padding: 8px;
            transition: background-color 0.3s ease;
        }

        .file-name {
            display: inline-block;
            margin-left: 10px;
            font-weight: bold;
            color: #212529;
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
    <script type="text/javascript">
        function updateFileName() {
            var fileName = document.getElementById("FileUpload1").value.split("\\").pop();
            document.getElementById("file-name").innerText = fileName;
        }

        function showSection(sectionId) {
            var sections = ['searchEventSection', 'eventDetailsSection', 'updateEventSection', 'addEventSection'];
            var section = document.getElementById(sectionId);

            if (section.style.display === 'block') {
                section.style.display = 'none';
                return;
            }

            sections.forEach(function (secId) {
                document.getElementById(secId).style.display = 'none';
            });

            section.style.display = 'block';

            if (sectionId === 'addEventSection') {
                document.getElementById('extraFields').style.display = 'block';
                generateEventID();
            } else {
                document.getElementById('extraFields').style.display = 'none';
            }
        }

        function generateEventID() {
            var now = new Date();
            var year = now.getFullYear().toString().slice(-2);
            var month = ('0' + (now.getMonth() + 1)).slice(-2);
            var day = ('0' + now.getDate()).slice(-2);
            var hours = ('0' + now.getHours()).slice(-2);
            var minutes = ('0' + now.getMinutes()).slice(-2);

            var eventID = year + month + day + hours + minutes;

            var eventIDTextBox = document.getElementById('eventidtxtbox');
            eventIDTextBox.value = eventID;
            eventIDTextBox.readOnly = true;
        }
    </script>

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
                                                <a class="nav-link active" href="PartnerDashboard.aspx">Dashboard</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" href="Home.aspx" target="_blank">View Events</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" href="partnerProfile.aspx">Profile</a>
                                            </li>

                                        </ul>
                                        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-btn ml-3" />
                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="container">
                    <div class="container d-flex justify-content-center">
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter Event ID or Name"></asp:TextBox>
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-custom" OnClientClick="showSection('searchEventSection'); return false;" OnClick="btnSearch_Click1" />
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" CssClass="btn btn-custom" OnClientClick="showSection('addEventSection'); return false;" />
                            </div>
                        </div>
                    </div>
                    <div id="searchEventSection" class="section">
                    </div>
                    <div id="eventDetailsSection" class="section hidden">
                    </div>
                    <div id="updateEventSection" class="section hidden">
                    </div>
                    <div id="addEventSection" class="section hidden">
                        <div id="extraFields" class="hidden">
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Event ID"></asp:Label>
                                    <asp:TextBox ID="eventidtxtbox" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label2" runat="server" Text="Event Name"></asp:Label>
                                    <asp:TextBox ID="eventnametxtbox" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Ticket Price"></asp:Label>
                                    <asp:TextBox ID="ticketPriceTxtBox" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                                    <asp:TextBox ID="datbox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label5" runat="server" Text="Time"></asp:Label>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label6" runat="server" Text="Location"></asp:Label>
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>


                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label8" runat="server" Text="Event Description" CssClass="description-label"></asp:Label>
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="Tickets Count"></asp:Label>
                                        <asp:TextBox ID="txtRemainingTickets" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <asp:Label ID="Label7" runat="server" Text="Upload Cover Image" CssClass="upload-label"></asp:Label>
                                    <div class="file-upload">
                                        <label for="FileUpload1" class="file-upload-btn">Choose File</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="inputfile" onchange="updateFileName()" />
                                        <span id="file-name" class="file-name">No file chosen</span>
                                    </div>
                                </div>
                            </div>



                        </div>
                        <asp:Button ID="Button4" runat="server" Text="Add Event" CssClass="btn btn-custom col-md-2" OnClick="AddEventtodb_Click" Style="margin-bottom: 30px; padding: 10px;" />
                    </div>

                </div>

                <%--table--%>
                <div class="table-container">
                    <asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
                        OnRowEditing="gvEvents_RowEditing" OnRowUpdating="gvEvents_RowUpdating" OnRowDeleting="gvEvents_RowDeleting"
                        OnRowCancelingEdit="gvEvents_RowCancelingEdit">
                        <Columns>
                            <asp:TemplateField HeaderText="Event ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEventId" runat="server" Text='<%# Eval("eventid") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEventId" runat="server" Text='<%# Bind("eventid") %>' CssClass="form-control" Enabled="false"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event Details">
                                <ItemTemplate>
                                    <strong>Name:</strong>
                                    <asp:Label ID="lblEventName" runat="server" Text='<%# Eval("event_name") %>'></asp:Label><br />
                                    <br />
                                    <strong>Description:</strong>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <strong>Name:</strong>
                                    <asp:TextBox ID="txtEventName" runat="server" Text='<%# Bind("event_name") %>' CssClass="form-control"></asp:TextBox><br />
                                    <strong>Description:</strong>
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("description") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cover Image">
                                <ItemTemplate>
                                    <asp:Image ID="imgCover" runat="server" ImageUrl='<%# Eval("imageUrl") %>' Width="66px" Height="100px" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Image ID="imgCurrentCover" runat="server" ImageUrl='<%# Eval("imageUrl") %>' Width="66px" Height="100px" />
                                    <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control-file" />
                                </EditItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Date, Time & Location">
                                <ItemTemplate>
                                    <strong>Date:</strong> <%# Eval("date", "{0:yyyy-MM-dd}") %><br /><br />
                                    <strong>Time:</strong> <%# Eval("time", "{0:HH:mm}") %><br /><br />
                                    <strong>Location:</strong> <%# Eval("location") %><br />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <strong>Date:</strong>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("date", "{0:yyyy-MM-dd}") %>' TextMode="Date" CssClass="form-control"></asp:TextBox><br />
                                    <strong>Time:</strong>
                                    <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("time", "{0:HH:mm}") %>' TextMode="Time" CssClass="form-control"></asp:TextBox><br />
                                    <strong>Location:</strong>
                                    <asp:TextBox ID="txtLocation" runat="server" Text='<%# Bind("location") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Ticket Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblTicketPrice" runat="server" Text='<%# Eval("ticket_price") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTicketPrice" runat="server" Text='<%# Bind("ticket_price") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remaining Tickets">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemainingTickets" runat="server" Text='<%# Eval("remainingTickets") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRemainingTickets" runat="server" Text='<%# Bind("remainingTickets") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sold Tickets">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoldTickets" runat="server" Text='<%# Eval("soldTickets") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSoldTickets" runat="server" Text='<%# Bind("soldTickets") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Income and Commission Details">
                                <ItemTemplate>
                                    <div>
                                        <p><strong>Estimated Income:</strong> <%# Eval("EstimatedIncome") %></p>
                                        <p><strong>Current Income:</strong> <%# Eval("CurrentIncome") %></p>
                                        <p><strong>Commission Rate:</strong> <%# Eval("CommissionRate") %></p>
                                        <p><strong>Commission:</strong> <%# Eval("Commission") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Panel ID="pnlItemTemplate" runat="server">
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-sm btn-block" Style="padding: 8px;" />
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("eventid") %>' Text="Delete" CssClass="btn btn-danger btn-sm btn-block" OnClick="DeleteEvent_Click" OnClientClick="return confirm('Are you sure you want to delete this event?');" Style="padding: 8px;" />
                                    </asp:Panel>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm btn-block" Style="padding: 8px; width: 100px" />
                                        <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-sm btn-block" Style="padding: 8px; width: 100px" />
                                    </asp:Panel>
                                </EditItemTemplate>
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
