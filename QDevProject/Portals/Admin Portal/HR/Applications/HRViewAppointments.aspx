 <%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRViewAppointments.aspx.cs" Inherits="QDevProject.Portals.Admin_Portal.HR.Applications.HRViewAppointments" %>

<asp:Content ID="viewAppointments" ContentPlaceHolderID="MainContent"  runat="server">
    
    <table id="appointments_table" class="table table-hover">
        
        <thead>
            <th>No:</th>
            <th>First Name:</th>
            <th>Last Name:</th>
            <th>Company Name:</th>
            <th>Contact Name:</th>
            <th>Appointment Type:</th>
            <th>Job Title:</th>
            <th>Date:</th>
            <th>Time:</th>
        </thead>
        <tbody>
            <asp:ListView id="appointments_list" runat="server" OnItemDataBound="appointments_list_ItemDataBound">
                <ItemTemplate>
                    <tr>
                    <td><%#Eval("appointment_id")%></td>
                    <td><%#Eval("first_name")%></td>
                    <td><%#Eval("last_name")%></td>
                    <td><%#Eval("company_name")%></td>
                    <td><%#Eval("app_contact")%></td>
                    <td><%#Eval("appointment_type")%></td>
                    <td><%#Eval("job_title")%></td>
                    <td><%#Eval("interview_date", "{0:dd/MM/yyyy}")%></td>
                    <td><%#Eval("interview_start")%></td>
                     <td><asp:LinkButton id="updateAppoinment" CommandArgument='<%#Eval("appointment_id")%>' CommandName="update"  OnCommand="updateAppoinment_Command" runat="server"  Text="Update"/></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td colspan="10">
                           <h2 class="text-center">No Job Found!</h2>
                        </td>
                    </tr>
                </EmptyDataTemplate>
            </asp:ListView>
        </tbody>
        
    </table>
    <Label id="test" runat="server" />
</asp:Content>

