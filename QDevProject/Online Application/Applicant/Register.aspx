<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="QDevProject.Online_Application.Applicant.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="col-lg-12 col-md-12">
            <h1>Sign Up</h1>
            <div class="panel panel-blue">
                <div class="panel-heading">Please enter your Email and Password.</div>
                <div class="form-horizontal">
                    <div class="panel-body">
                        <div class="rows">
                            <div class="control-label col-lg-7">
                <asp:Label ID="error" runat="server" ForeColor="#CD3333"
                    Visible="false">
                Email is already Taken!
                </asp:Label>
            </div>

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
                                    <label class="control-label col-lg-4">Email Address<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                      <asp:TextBox ID="txtEmail" runat="server"
                                          class="form-control" type="email" MaxLength="30" required />
                                        </div>
                                </div>


                                <div class="form-group">
                                    <label class="control-label col-lg-4">Password<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                      <asp:TextBox ID="txtPW" runat="server"
                                        class="form-control" type="password" MaxLength="20" required />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-lg-4">First Name<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtFN" runat="server"
                                            class="form-control" type="text" MaxLength="100"
                                            required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-4">Middle Name<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtMN" runat="server"
                                            class="form-control" type="text" MaxLength="100" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-4">Last Name<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtLN" runat="server"
                                            class="form-control" type="text" MaxLength="50"
                                            required />
                                    </div>
                                </div>


                               <div class="form-group">
                                    <label class="control-label col-sm-4">Gender<span style="color: red;">*</span></label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownList7" runat="server" class="form-control" required="required">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                               <div class="form-group">
                                    <label class="control-label col-lg-4">Birth Date<span style="color: red;">*</span></label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtBirthDate" runat="server"
                                            class="form-control" type="date" MaxLength="100" 
                                            required />
                                        <asp:RangeValidator ID="RangeValidator1" runat="server"
                                            ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Invalid Date!"
                                            ForeColor="Red"
                                            MaximumValue="1/1/2010" MinimumValue="01/01/1960" SetFocusOnError="True" ValidationGroup="Date"
                                            Type="Date"></asp:RangeValidator>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-4">CV</label>
                                         <div class="col-lg-8">
                                             <asp:FileUpload ID="FileContent" runat="server" class="form-control" required />
                                         </div>
                                </div>
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
            </div>
        </div>
    </section>
</asp:Content>
