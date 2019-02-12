<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewJobApplication.aspx.cs" Inherits="QDevProject.Portals.BP_Portal.Applications.ViewJobApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                       
                            <h1>Job List (Open)</h1>
                            <div>
                                <br />
                             
                            </div>

                            <table id="table" class="table table-hover">
                                <thead>
                                    
                                    <th>Approval Status</th>
                                    <th>Job Title</th>
                                    <th>Job Description</th>
                                    <th>Monthly Salary</th>
                                    <th>Date Submitted</th>
                                    <th>Posting Start</th>
                                    <th>Posting End</th>
                                    <th></th>

                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvJobs" runat="server"
                                        OnItemCommand="lvJobs_ItemCommand"
                                        OnPagePropertiesChanging="lvJobs_PagePropertiesChanging">
                                        <ItemTemplate>
                                            <tr>
                                                <asp:Literal ID="ltJobID" runat="server"
                                                    Text='<%#Eval("job_id") %>' Visible="false" />

                                                <td><%#Eval("description") %></td>
                                                <td><%#Eval("job_title") %></td>
                                                <td><%#Eval("job_description") %></td>
                                                <td><%#Eval("job_monthly_salary") %></td>
                                                <td><%#Eval("date_submitted") %></td>
                                                <td><%#Eval("posting_start") %></td>
                                                <td><%#Eval("posting_end") %></td>

                                                <td>

                                                    <a href='JobDetails.aspx?ID=<%#Eval("job_id")%>'
                                                        class="btn btn-xs btn-info" title="View Section Details">
                                                        <i class="fa fa-edit"> Job Details</i>
                                                    </a>

                                                    <a href='EditJob.aspx?ID=<%#Eval("job_id")%>'
                                                        class="btn btn-xs btn-info" title="View Section Details">
                                                        <i class="fa fa-edit"> Edit Job</i>
                                                    </a>


                                                    <asp:LinkButton ID="btnDelete" runat="server"
                                                        class="btn btn-xs btn-" CommandName="deljob">
                                                    <i class="fa fa-user"> Delete Job </i>
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
