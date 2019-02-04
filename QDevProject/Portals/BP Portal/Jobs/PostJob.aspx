<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostJob.aspx.cs" Inherits="QDevProject.Portals.BP_Portal.Jobs.PostJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="col-lg-12 col-md-12">
            <h1>Post Jobs</h1>
            

                             <div class="col-lg-12 col-md-12">
                                <div class="alert alert alert-warning-blue">
                                    <strong>IMPORTANT NOTES :</strong>
                                    <ul class="important-notes">
                                        <li><span style="color: red;">*</span> Indicates required field</li>
                                        
                                    </ul>
                                 </div>
                                      <h4>Basic Information </h4>
                                 </div>

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="form-group">
                                    <label class="control-label col-lg-4">Job Title<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                      <asp:TextBox ID="txtJobTitle" runat="server"
                                          class="form-control" type="text" MaxLength="30" required />
                                        </div>
                                </div>


                                <div class="form-group">
                                    <label class="control-label col-lg-4">Job Description</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtJobDesc" runat="server"
                                            class="form-control" type="text" MaxLength="500" TextMode="MultiLine" />


                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-lg-4">Monthly Salary<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtMonthlySalary" runat="server"
                                            class="form-control" type="number" MaxLength="10"
                                            required />
                                    </div>
                                </div>
                                 <br />
                                <div class="form-group">
                                    <label class="control-label col-lg-4">Posting Start<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtPostStart" runat="server"
                                            class="form-control" type="date" MaxLength="100" 
                                            required />
                                        </div>

                                    <br />

                                    <div class="form-group">
                                    <label class="control-label col-lg-4">Posting End<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtPostEnd" runat="server"
                                            class="form-control" type="date" MaxLength="100" 
                                            required />
                                        </div>
                                
                                    <br />

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <hr />
                                <div class="form-group text-center">
                                    <asp:Button ID="btnApply" runat="server"
                                        CssClass="btn btn-success"
                                        OnClick="btnApply_Click"
                                        Text="Submit" ValidationGroup="Date">
                                    </asp:Button>

                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
       
    </section>
</asp:Content>
