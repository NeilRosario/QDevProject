<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewJobList.aspx.cs" Inherits="QDevProject.Portals.Admin_Portal.HR.Jobs.ViewJobList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                        
                            <h1>Pending Job List</h1>
                            <div>
                                <br />
                              
                            </div>

                            <table id="table" class="table table-hover">
                                <thead>
                                    
                                    <th>Company Name</th>
                                    <th>Approval Status</th>
                                    <th>Job Title</th>
                                    <th>Job Description</th>
                                    <th>Monthly Salary</th>
                                    <th>Date Submitted</th>


                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvJobs" runat="server"
                                        OnItemCommand="lvJobs_ItemCommand"
                                        OnPagePropertiesChanging="lvJobs_PagePropertiesChanging">
                                        <ItemTemplate>
                                            <tr>
                                             

                                                <td><%#Eval("company_name") %></td>
                                                <td><%#Eval("description") %></td>
                                                <td><%#Eval("job_title") %></td>
                                                <td><%#Eval("job_description") %></td>
                                                <td><%#Eval("job_monthly_salary") %></td>
                                                <td><%#Eval("date_submitted") %></td>
=   

                                                <td>

                                                    <asp:LinkButton ID="btnAccept" runat="server"
                                                        class="btn btn-xs btn-info" CommandName="acceptapp">
                                                    <i class="fa fa-user"> Accept </i>
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnreject" runat="server"
                                                        class="btn btn-xs btn-info" CommandName="rejectapp">
                                                    <i class="fa fa-user"> Reject </i>
                                                    </asp:LinkButton>
                                                </td>
                                               
                                         
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
                            <div class="col-lg-offset-5">
                             <asp:DataPager ID="dpJobs" runat="server"
                                    PagedControlID="lvJobs" PageSize="10">
                                   <Fields>
                                       <asp:NumericPagerField
                                     ButtonType="Button"
                                     CurrentPageLabelCssClass="btn btn"
                                     NumericButtonCssClass="btn btn"
                                     NextPreviousButtonCssClass="btn btn-default"
                                     ButtonCount="5" />
                                   </Fields>
                          </asp:DataPager>
                           </div>
                              </div>
                          </div>
                    </div>
                </div>
                </div>
</asp:Content>
