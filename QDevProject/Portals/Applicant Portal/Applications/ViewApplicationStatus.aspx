<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewApplicationStatus.aspx.cs" Inherits="QDevProject.Portals.Applicant_Portal.Applications.ViewApplicationStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                       
                            <h1>Application Status</h1>
                            <div>
                                <br />

                            </div>

                            <table id="table" class="table table-hover">
                                <thead>
                                    <th>Application Status</th>
                                    <th>Company Name</th>
                                    <th>Job Title</th>
                                    <th>Job Description</th>
                                    <th>Job Status</th>

                                   

                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvApp" runat="server">
        
                                        <ItemTemplate>
                                            <tr>
                                               
                                                <asp:Literal ID="ltAppID" runat="server"
                                                    Text='<%#Eval("application_no") %>' Visible="false" />
                                                <td><%#Eval("status") %></td>
                                                <td><%#Eval("company_name") %></td>
                                                <td><%#Eval("job_title") %></td>
                                                <td><%#Eval("job_description") %></td>
                                                <td><%#Eval("Description") %></td>
                                                <td>


                                 
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <tr>
                                                <td colspan="10">
                                                    <h2 class="text-center">No records found!
                                                    </h2>
                                                </td>
                                            </tr>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </tbody>
                            </table>   
                            
                              </div>
                          </div>
                    </div>
                </div>
                </div>
    

</asp:Content>
