<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRProcessApp.aspx.cs" Inherits="RecruitMe.HRApp_process.HRProcessApp" %>


<asp:Content ID="process_application" ContentPlaceHolderID="MainContent"  runat="server">
    
    <table id="applications_table" class="table table-hover">
        
        <thead>
            <th>Job Title:</th>
            <th>First Name:</th>
            <th>Last Name:</th>
            <th>Date Applied:</th>
            <th>Status:</th>
        </thead>
        <tbody>
            <asp:ListView id="applicant_list" runat="server">
                <ItemTemplate>
                    <tr>
                   <asp:Literal ID="job_id" runat="server" text='<%#Eval("application_no")%>' Visible="false"/>
                    <td><%#Eval("job_title")%></td>
                    <td><%#Eval("first_name")%></td>
                    <td><%#Eval("last_name")%></td>
                    <td><%#Eval("date_applied")%></td>
                    <td><%#Eval("status")%></td>
                     <th style="width:100px"><asp:LinkButton ID="btn_reject" CommandArgument='<%#Eval("application_no")%>' CommandName="fail" OnCommand="btn_reject_Command1" runat="server" Text="Failed"></asp:LinkButton></th>
                    <th style="width:100px"><asp:LinkButton ID="btn_pass" CommandArgument='<%#Eval("application_no")%>' CommandName="pass" OnCommand="btn_reject_Command1" runat="server" Text="Pass"></asp:LinkButton></th>
                     <th style="width:100px"><asp:LinkButton ID="btn_check_app" CommandArgument='<%#Eval("application_no")%>' CommandName="view_details" OnCommand="btn_reject_Command1" runat="server" Text="Check Profile"></asp:LinkButton></th>
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