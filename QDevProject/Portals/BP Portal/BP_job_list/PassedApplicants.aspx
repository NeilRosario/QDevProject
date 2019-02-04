<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PassedApplicants.aspx.cs" Inherits="RecruitMe.BP_job_list.PassedApplicants" %>


<asp:Content ID="process_application" ContentPlaceHolderID="MainContent"  runat="server">
    <table class="table table-hover">
        <thead>
            <th>Filter:</th>
            <th><asp:LinkButton CommandArguement="failed" CommandName="filter_failed" OnCommand="filter_command" runat="server" text="Failed"/></th>
            <th><asp:LinkButton CommandArguement="passed" CommandName="filter_passed" OnCommand="filter_command" runat="server" text="Passed"/>
            <th></th>
            </thead>
        </table>

    <table id="applications_table" class="table table-hover">
        
        <thead>
            <th>Job Title:</th>
            <th>Applicant Name:</th>
            <th>Date Applied:</th>
            <th>Status:</th>
        </thead>
        <tbody>
            <asp:ListView id="applications_list" runat="server">
                <ItemTemplate>
                    <tr>
                   <asp:Literal ID="job_id" runat="server" text='<%#Eval("application_no")%>' Visible="false"/>
                    <td><%#Eval("job_title")%></td>
                    <td><%#Eval("first_name")%></td>
                    <td><%#Eval("date_applied")%></td>
                    <td><%#Eval("status")%></td>
                    <td></td>
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
    <asp:LinkButton ID="redirect" runat="server" CommandArgument="go_back" CommandName="go_back" Text="Return" OnCommand="redirect_Command"/>
    <Label id="test" runat="server" />
</asp:Content>