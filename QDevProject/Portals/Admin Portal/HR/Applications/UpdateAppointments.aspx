<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateAppointments.aspx.cs" Inherits="QDevProject.Portals.Admin_Portal.HR.Applications.UpdateAppointments" %>

<asp:Content ID="bp_appointments" ContentPlaceHolderID="MainContent" runat="server">
    <table id="bp_message" class="table table-hover">
        <thead></thead>
        <tbody>
                    <tr>
                        <td>Applicantion No:</td>
                        <td><asp:Label id="app_number" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Name:</td>
                        <td><asp:Label id="applicant_name" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Email:</td>
                        <td><asp:Label ID="a_email" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Cellphone</td>
                        <td><asp:Label id="mobile_no" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Contact Name</td>
                        <td><asp:TextBox id="bp_contact" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Kind of Appointment:</td>
                        <td><asp:Label id="apt_type" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Appointment Type:</td>
                        <td>
                            <asp:DropDownList ID="appointment_type" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Name:</td>
                        <td><asp:Label ID="c_company" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Contact Email</td>
                        <td><asp:Label ID="c_email" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Contact Address</td>
                        <td><asp:Label ID="c_address" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Conctact Number</td>
                        <td><asp:Label ID="c_number" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Date Selected:</td>
                        <td><asp:Label id="apt_date" runat="server" /></td>
                    </tr>
   
                    <tr>
                        <td>Date:</td>
                        <td><asp:Calendar id="date_appointment"  runat="server"/><asp:Label ID="test" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Time Selected:</td>
                        <td><asp:Label id="app_time" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Time</td>
                        <td><asp:DropDownList id="drop_start_time" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:LinkButton id="set_update" CommandArgument="appointment" CommandName="update_appt" OnCommand="set_update_Command" text="Send Appointment" runat="server"/></td>
                    </tr>
            
        </tbody>

    </table>

</asp:Content>