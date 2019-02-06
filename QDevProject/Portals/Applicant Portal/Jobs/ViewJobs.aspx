<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewJobs.aspx.cs" Inherits="QDevProject.Portals.Applicant_Portal.Jobs.ViewJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                        
                            <h1>Job List (Open)</h1>
                            <div>
                                <br />
                                <a href='AddAdmin.aspx'
                                    class="btn btn-xs btn-default" style="margin-bottom: 20px;" title="Add Admin">
                                    <i class="fa fa-plus"></i>
                                </a>
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
                                                <asp:Literal ID="ltJobID" runat="server"
                                                    Text='<%#Eval("job_id") %>' Visible="false" />

                                                <td><%#Eval("company_name") %></td>
                                                <td><%#Eval("description") %></td>
                                                <td><%#Eval("job_title") %></td>
                                                <td><%#Eval("job_description") %></td>
                                                <td><%#Eval("job_monthly_salary") %></td>
                                                <td><%#Eval("date_submitted") %></td>
=   

                                                <td>

                                                    <a href='JobDetails.aspx?ID=<%#Eval("job_id")%>'
                                                        class="btn btn-xs btn-info" title="View Section Details">
                                                        <i class="fa fa-edit"> Job Details</i>
                                                    </a>
                                                    <asp:LinkButton ID="btnApply" runat="server"
                                                        class="btn btn-xs btn-info" CommandName="sendapplication">
                                                    <i class="fa fa-user"> Send Application </i>
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
