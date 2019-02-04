<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vc_downloadtest.aspx.cs" Inherits="RecruitMe.BP_job_list.vc_downloadtest" %>


<asp:Content ID="process_application" ContentPlaceHolderID="MainContent"  runat="server">
    
    <table id="applications_table" class="table table-hover">
        
        <thead>
            <th>Applicant Details</th>
            <th></th>
            
        </thead>
        <tbody>
            <asp:ListView id="applicant_details" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>First Name:</td>
                        <td><%#Eval("first_name")%></td>
                    </tr>
                    <tr>
                        <td>Middle Initial:</td>
                        <td><%#Eval("middle_name")%></td>
                    </tr>
                    <tr>
                        <td>Last Time:</td>
                         <td><%#Eval("last_name")%></td>
                    </tr>
                    <tr>
                        <td>Date of Birth:</td>
                          <td><%#Eval("date_of_birth")%></td>
                    </tr>
                    <tr>
                        <td>Email:</td>
                         <td><%#Eval("a_email")%></td>
                    </tr>
                    <tr>
                        <td>Gender:</td>
                         <td><%#Eval("gender")%></td>
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
                <asp:ListView id="contact_details" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td>Phone Number:</td>
                        <td><%#Eval("home_phone")%></td>
                    </tr>
                    <tr>
                        <td>Mobile Number:</td>
                        <td><%#Eval("mobile_number")%></td>
                    </tr>
                    <tr>
                        <td>Alternate Number:</td>
                         <td><%#Eval("alternate_mobile")%></td>
                    </tr>
                  
                </ItemTemplate>

                <EmptyDataTemplate>
                    <tr>
                        <td colspan="10">
                           <h2 class="text-center"></h2>
                        </td>
                    </tr>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:ListView id="education_status" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td>School Name:</td>
                        <td><%#Eval("school_name")%></td>
                    </tr>
                        <tr>
                        <td>Course:</td>
                        <td><%#Eval("course_name")%></td>
                    </tr>
                    <tr>
                        <td>Educational Attainment:</td>
                        <td><%#Eval("educational_attainment")%></td>
                    </tr><tr>
                        <td>Date Graduated:</td>
                        <td><%#Eval("date_graduated")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td colspan="10">
                           <h2 class="text-center">No Education</h2>
                        </td>
                    </tr>
                </EmptyDataTemplate>
            </asp:ListView>
            
        </tbody>
        
    </table>
    <asp:LinkButton ID="return" runat="server" CommandArgument="go_back" CommandName="go_back" Text="Return" OnCommand="return_Command"/>
    <div>
        <div>
            <asp:Button id="file_download" OnClick="file_download_Click" runat="server" Text="DownloadCV" />
        </div>
        <div>
            <asp:Label id="test_command" runat="server" />
        </div>
    </div>
    
</asp:Content>


