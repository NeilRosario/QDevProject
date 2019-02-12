<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewActiveApplicants.aspx.cs" Inherits="QDevProject.Portals.Admin_Portal.Admin.Applicants.ViewActiveApplicants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                       
                            <h1>Active Applicant</h1>
                            <div>
                                <br />
                            
                            </div>

                            <table id="table" class="table table-hover">
                                <thead>
                                    
                                    <th>Applicant Email</th>
                                    <th>Full Name </th>
                                    <th>Date of Birth</th>
                                    <th>Gender</th>
                                    <th></th>

                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvApplicant" runat="server"
                                        OnPagePropertiesChanging="lvApplicant_PagePropertiesChanging">
                                        <ItemTemplate>
                                            <tr>
                                                <asp:Literal ID="ltJobID" runat="server"
                                                    Text='<%#Eval("applicant_id") %>' Visible="false" />

                                                <td><%#Eval("a_email") %></td>
                                                <td><%#Eval("Full Name") %></td>
                                                <td><%#Eval("date_of_birth") %></td>
                                                <td><%#Eval("gender") %></td>

                                         
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
                             <asp:DataPager ID="dpApplicants" runat="server"
                                    PagedControlID="lvApplicant" PageSize="10">
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
