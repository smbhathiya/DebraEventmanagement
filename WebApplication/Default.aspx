﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

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
            background-color: #000;
            font-size: 40px;
            color: #fff;
            text-align: left;
            padding: 20px 10px 10px 20px;
        }
        .top-bar h1 {
            font-weight: 800;
        }
        .container {
            margin-top: 20px;
        }
        .btn-custom {
            background-color: #000;
            color: #fff;
            border-radius: 15px;
            transition: background-color 0.3s ease;
        }
        .btn-custom:hover {
            background-color: #333;
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
        .table {
            width: 100%;
            max-width: 100%;
            margin-bottom: 1rem;
            background-color: transparent;
        }
        .table th,
        .table td {
            padding: 1rem;
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
     .form-group {
        min-width: 100px; 
    }
    </style>
<script type="text/javascript">
    function showSection(sectionId) {
        document.getElementById('searchEventSection').style.display = 'none';
        document.getElementById('eventDetailsSection').style.display = 'none';
        document.getElementById('updateEventSection').style.display = 'none';
        document.getElementById('addEventSection').style.display = 'none';

        document.getElementById(sectionId).style.display = 'block';

        if (sectionId === 'addEventSection') {
            document.getElementById('extraFields').style.display = 'block';
            generateEventID(); // Call the function to generate event ID when showing addEventSection
        } else {
            document.getElementById('extraFields').style.display = 'none';
        }
    }

    function generateEventID() {
        // Get the current date and time
        var now = new Date();
        var year = now.getFullYear().toString().slice(-2); // Get the last two digits of the year
        var month = ('0' + (now.getMonth() + 1)).slice(-2); // Add leading zero if month is less than 10
        var day = ('0' + now.getDate()).slice(-2); // Add leading zero if day is less than 10
        var hours = ('0' + now.getHours()).slice(-2); // Add leading zero if hours is less than 10
        var minutes = ('0' + now.getMinutes()).slice(-2); // Add leading zero if minutes is less than 10

        // Generate the event ID
        var eventID = year + month + day + hours + minutes;

        var eventIDTextBox = document.getElementById('eventidtxtbox');
        eventIDTextBox.value = eventID;
        eventIDTextBox.readOnly = true;
    }
</script>

</head>
<body>
    <div class="top-bar">
        <h1>DEBRA</h1>
        <h6>Event Management Company</h6>
    </div>
    <div class="container">
        <form id="form1" runat="server">
            <div class="form-row align-items-center mb-3">
                <div class="col">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter Event ID or Name"></asp:TextBox>
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-custom" OnClientClick="showSection('searchEventSection'); return false;" OnClick="btnSearch_Click1" />
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" CssClass="btn btn-custom" OnClientClick="showSection('addEventSection'); return false;" />
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-custom" OnClick="btnLogout_Click" />
                </div>
            </div>
            <div id="searchEventSection" class="section">
                <!-- Search event results will be displayed here -->
            </div>
            <div id="eventDetailsSection" class="section hidden">
                <!-- Content for displaying event details -->
            </div>
            <div id="updateEventSection" class="section hidden">
                <!-- Content for updating event details -->
            </div>
<div id="addEventSection" class="section hidden">
    <div id="extraFields" class="hidden">
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label1" runat="server" Text="Event ID" ></asp:Label>
                <asp:TextBox ID="eventidtxtbox" runat="server" CssClass="form-control" ></asp:TextBox>
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
    </div>
    <asp:Button ID="Button4" runat="server" Text="Add Event" CssClass="btn btn-custom" OnClick="AddEventtodb_Click" />
</div>

<asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
    OnRowEditing="gvEvents_RowEditing" OnRowUpdating="gvEvents_RowUpdating" OnRowDeleting="gvEvents_RowDeleting"
    OnRowCancelingEdit="gvEvents_RowCancelingEdit">
    <Columns>
        <asp:BoundField DataField="eventid" HeaderText="Event ID" ReadOnly="true" />
        <asp:TemplateField HeaderText="Event Name">
            <ItemTemplate>
                <asp:Label ID="lblEventName" runat="server" Text='<%# Eval("event_name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEventName" runat="server" Text='<%# Bind("event_name") %>' CssClass="form-control"></asp:TextBox>
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
        <asp:TemplateField HeaderText="Date">
            <ItemTemplate>
                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("date") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("date") %>' TextMode="Date" CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Time">
            <ItemTemplate>
                <asp:Label ID="lblTime" runat="server" Text='<%# Eval("time") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("time") %>' TextMode="Time" CssClass="form-control"></asp:TextBox>
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

        <asp:TemplateField ShowHeader="False">
    <ItemTemplate>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-sm btn-block" />
            </div>
            <div class="form-group col-md-6">
                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("eventid") %>' Text="Delete" CssClass="btn btn-danger btn-sm btn-block" OnClick="DeleteEvent_Click" OnClientClick="return confirm('Are you sure you want to delete this event?');" />
            </div>
        </div>
    </ItemTemplate>
    <EditItemTemplate>
        <div class="form-row " >
            <div class="form-group col-md-6">
                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm btn-block" />
            </div>
            <div class="form-group col-md-6">
                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-sm btn-block" />
            </div>
        </div>
    </EditItemTemplate>
</asp:TemplateField>



    </Columns>
</asp:GridView>



        </form>

    </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
