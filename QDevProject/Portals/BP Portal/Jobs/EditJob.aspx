<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditJob.aspx.cs" Inherits="QDevProject.Portals.BP_Portal.Jobs.EditJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>     <asp:Literal ID="ltJID" runat="server"  Visible="true"/></h1>

                            <div class="form-group">
                                    <label class="control-label col-lg-4">Job Location</label>
                                    <div class="col-lg-8">
                                    <asp:textbox id="txtJobLocation" runat="server" class="form-control" type="text" required />
                                    </div>
                                <label class="control-label col-lg-4">Job Title</label>
                                    <div class="col-lg-8">
                                    <asp:textbox id="txtJobTitle" runat="server" class="form-control" type="text" required />
                                    </div>
                                <label class="control-label col-lg-4">Job Description</label>
                                    <div class="col-lg-8">
                                    <asp:textbox id="txtDesc" runat="server" class="form-control" type="text" MaxLength="500" TextMode="MultiLine" required />
                                    </div>
                                <label class="control-label col-lg-4">Monthly Salary</label>
                                    <div class="col-lg-8">
                                    <asp:textbox id="txtSal" runat="server" class="form-control" type="number" required />
                                    </div>
                                    </div>
                                    

                                    <asp:Button ID="btnEdit" runat="server"
                                        CssClass="btn btn-success"
                                        OnClick="btnEdit_Click"
                                        Text="Submit">
                                    </asp:Button>


                          

</asp:Content>
