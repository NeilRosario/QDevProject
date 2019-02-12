<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCompanyJob.aspx.cs" Inherits="QDevProject.Portals.Applicant_Portal.Company.ViewCompanyJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                       
                            <h1><asp:Literal ID="ltCompID" runat="server" /> - Job List</h1>
                            <div>
                                <br />

                            </div>

                            <table id="table" class="table table-hover">
                                <thead>
                                    
                                    <th>Job Title</th>
                                    <th>Job Description</th>
                                    <th>Salary</th>
                                    <th>Status</th>
                                   

                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvComp" runat="server"
                                        OnItemCommand="lvComp_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                               
                                                <asp:Literal ID="ltJobID" runat="server"
                                                    Text='<%#Eval("job_id") %>' Visible="false" />
                                                <td><%#Eval("job_title") %></td>
                                                <td><%#Eval("job_description") %></td>
                                                <td><%#Eval("job_monthly_salary") %></td>
                                                <td><%#Eval("Description") %></td>
                                                <td>

                                                   <asp:LinkButton ID="btnApply" runat="server"
                                                        class="btn btn-xs btn-info" CommandName="sendapplication">
                                                    <i class="fa fa-user"> Apply </i>
                                                    </asp:LinkButton>
                                 
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
