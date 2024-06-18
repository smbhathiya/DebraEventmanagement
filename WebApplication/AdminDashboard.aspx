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
            background-color: #000;
            font-size: 40px;
            color: #fff;
            text-align: left;
            padding: 20px 10px 10px 20px;
        }

            .top-bar h1 {
                font-weight: 700;
            }

        .page-title {
            text-align: center;
            color: #000;
            padding: 10px;
        }

            .page-title h3 {
                font-size: 28px;
                font-weight: 800;
            }
    </style>
    <script type="text/javascript">
        function confirmDelete() {
            return confirm('Are you sure you want to delete this event?');
        }
    </script>

</head>
<body>
    <div class="top-bar">
        <h1>DEBRA</h1>
        <h6>Event Management Company</h6>
    </div>
    <div class="page-title">
        <h3>DASHBOARD</h3>
    </div>

    <form id="form1" runat="server">
        <div class="container">
            <div class="form-row align-items-center mb-3">
                <div class="col">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter Event ID or Name"></asp:TextBox>
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-custom" OnClientClick="#" />
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" CssClass="btn btn-custom" OnClientClick="#" />
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-custom" OnClick="btnLogout_Click" />
                </div>
            </div>


        </div>

        <div>

<asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" OnRowEditing="gvEvents_RowEditing" OnRowUpdating="gvEvents_RowUpdating" OnRowCancelingEdit="gvEvents_RowCancelingEdit">
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
                <asp:TextBox ID="txtCommissionRate" runat="server" Text='<%# Bind("commissionRate") %>'></asp:TextBox>
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
                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm"></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary btn-sm"></asp:LinkButton>
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
