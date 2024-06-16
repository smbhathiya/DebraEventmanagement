<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Events</title>
    <style>
        .section { margin-bottom: 20px; }
        .hidden { display: none; }
    </style>

<script type="text/javascript">

    function showSection(sectionId) {
        document.getElementById('searchEventSection').style.display = 'none';
        document.getElementById('eventDetailsSection').style.display = 'none';
        document.getElementById('updateEventSection').style.display = 'none';
        document.getElementById('addEventSection').style.display = 'none';

        document.getElementById(sectionId).style.display = 'block';

        // Additional logic to show extra fields when Add Event button is clicked
        if (sectionId === 'addEventSection') {
            document.getElementById('extraFields').style.display = 'block';
        } else {
            document.getElementById('extraFields').style.display = 'none';
        }
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Enter Event ID or Name"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="showSection('searchEventSection'); return false;" OnClick="btnSearch_Click1" />
        <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" OnClientClick="showSection('addEventSection'); return false;" />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        <br />
        <br />
        <div id="searchEventSection" class="section">
        </div>
        <div id="eventDetailsSection" class="section hidden">
            <!-- Content for displaying event details -->
        </div>
        <div id="updateEventSection" class="section hidden">
            <!-- Content for updating event details -->
        </div>
        <div id="addEventSection" class="section hidden">
            <div id="extraFields" class="hidden">
                <asp:Label ID="Label1" runat="server" Text="Event ID"></asp:Label>
                <asp:TextBox ID="eventidtxtbox" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Event Name"></asp:Label>
                <asp:TextBox ID="eventnametxtbox" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Ticket Price"></asp:Label>
                <asp:TextBox ID="ticketPriceTxtBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                <asp:TextBox ID="datbox" runat="server" style="margin-top: 0px" TextMode="Date"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Time"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Time"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Location"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <asp:Button ID="Button4" runat="server" Text="Add Event" OnClick="AddEventtodb_Click" />
        </div>

<asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" CssClass="section"
    OnRowEditing="gvEvents_RowEditing" OnRowUpdating="gvEvents_RowUpdating" OnRowDeleting="gvEvents_RowDeleting"
    OnRowCancelingEdit="gvEvents_RowCancelingEdit">
    <Columns>
        <asp:BoundField DataField="eventid" HeaderText="Event ID" />
        <asp:TemplateField HeaderText="Event Name">
            <ItemTemplate>
                <asp:Label ID="lblEventName" runat="server" Text='<%# Eval("event_name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEventName" runat="server" Text='<%# Bind("event_name") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ticket Price">
            <ItemTemplate>
                <asp:Label ID="lblTicketPrice" runat="server" Text='<%# Eval("ticket_price") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTicketPrice" runat="server" Text='<%# Bind("ticket_price") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
    <ItemTemplate>
        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("date") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("date") %>' TextMode="Date"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Time">
    <ItemTemplate>
        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("time") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("time") %>' TextMode="Time"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Location">
    <ItemTemplate>
        <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("location") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtLocation" runat="server" Text='<%# Bind("location") %>'></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" OnClick="DeleteEvent_Click"
                    CommandArgument='<%# Eval("eventid") %>' Text="Delete"
                    OnClientClick="return confirm('Are you sure you want to delete this event?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



    </form>
</body>
</html>
