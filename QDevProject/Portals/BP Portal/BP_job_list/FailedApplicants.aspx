<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FailedApplicants.aspx.cs" Inherits="RecruitMe.BP_job_list.FailedApplicants" %>


<asp:Content ID="process_application" ContentPlaceHolderID="MainContent"  runat="server">
    
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
                   <asp:Literal ID="job_id" runat="server" text='<%#Eval("application_no")%>' Visible="false"/>
                    <td><%#Eval("job_title")%></td>
                    <td><%#Eval("first_name")%></td>
                    <td><%#Eval("date_applied")%></td>
                    <td><%#Eval("status")%></td>
                    <td></td>
                  
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td colspan="10">
                           <h2 class="text-center">Failed Applicants!</h2>
                        </td>
                    </tr>
                </EmptyDataTemplate>
            </asp:ListView>
        </tbody>
        
    </table>
    <asp:LinkButton ID="redirect" runat="server" CommandArgument="go_back" CommandName="go_back" Text="Return" OnCommand="redirect_Command"/>
    <Label id="test" runat="server" />
</asp:Content>
