<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCompanyList.aspx.cs" Inherits="QDevProject.Portals.Applicant_Portal.Company.ViewCompanyList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div class="form-horizontal">

                       
                            <h1>Company List</h1>
                            <div>
                                <br />
                           
                            </div>

                            <table id="table" class="table table-hover">
                                <thead>
                                    
                                    <th>Company Name</th>
                                    <th>Contact Number</th>
                                    <th>Company Email</th>
                                   

                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvComp" runat="server"
                                        OnPagePropertiesChanging="lvComp_PagePropertiesChanging">
                                        <ItemTemplate>
                                            <tr>
                                               
                                           <asp:Literal ID="ltCompID" runat="server"
                                                    Text='<%#Eval("b_access_id") %>' Visible="false" />
                                                <td><%#Eval("company_name") %></td>
                                                <td><%#Eval("b_contactno") %></td>
                                                <td><%#Eval("business_email") %></td>
                                                <td>

                                                    <a href='ViewCompanyJob.aspx?ID=<%#Eval("b_access_id")%>'
                                                        class="btn btn-xs btn-info" title="View Section Details">
                                                        <i class="fa fa-edit"> View Jobs</i>
                                                    </a>

                                                    <a href='EditJob.aspx?ID=<%#Eval("b_access_id")%>'
                                                        class="btn btn-xs btn-info" title="View Section Details">
                                                        <i class="fa fa-edit"> View Company Details</i>
                                                    </a>                                  
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
                             <asp:DataPager ID="dpComp" runat="server"
                                    PagedControlID="lvComp" PageSize="10">
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
