<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="ProcessApplicants.aspx.cs" Inherits="RecruitMe.BP_job_list.ProcessApplicants" %>

<asp:Content ID="process_application" ContentPlaceHolderID="MainContent"  runat="server">
    <table>
        <thead>
            <tr>
            <th style="width:400px"><asp:DropDownList style="width:300px" ID="applicants" runat="server"></asp:DropDownList></th>
            <th style="width:100px"><asp:LinkButton ID="btn_reject" CommandArgument="Fail" CommandName="fail" OnCommand="btn_reject_Command1" runat="server" Text="Failed"></asp:LinkButton></th>
            <th style="width:100px"><asp:LinkButton ID="btn_pass" CommandArgument="Pass" CommandName="pass" OnCommand="btn_reject_Command1" runat="server" Text="Pass"></asp:LinkButton></th>
                </tr>
        </thead>
    </table>
    
    <table id="applications_table" class="table table-hover">
        
        <thead>
            <th>Job Title:</th>
            <th>First Name:</th>
            <th>Last Name:</th>
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
                    <td><%#Eval("last_name")%></td>
                    <td><%#Eval("date_applied")%></td>
                    <td><%#Eval("status")%></td>
                    <td><asp:LinkButton  CommandArgument='<%#Eval("application_no")%>' CommandName="view_profile" OnCommand="view_applicant" text="View Profile" runat="server"/></td>
                    <td><asp:LinkButton  CommandArgument='<%#Eval("application_no")%>' CommandName="fail" OnCommand="applicant_process" text="Failed Final Interview" runat="server"/></td>
                    <td><asp:LinkButton  CommandArgument='<%#Eval("application_no")%>' CommandName="pass" OnCommand="applicant_process" text="Pass Final Interview" runat="server"/></td>
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
