<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="QDevProject.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="single">LOG IN</h1>
    <div class="form-horizontal">
        <div class="form-group">
            <div class="control-label col-lg-7">
                <asp:Label ID="error" runat="server" ForeColor="#CD3333"
                    Visible="false">
                Invalid Email or Password!
                </asp:Label>
            </div>
            </div>
        
        <div class="form-group">
            <label class="control-label col-lg-4">Email Adress</label>
            <div class="col-lg-8">
                <asp:TextBox ID="txtEmail" runat="server"
                    class="input-txt" type="email" MaxLength="50" required />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-lg-4">Password</label>
            <div class="col-lg-4">
                <asp:TextBox ID="txtPassword" runat="server"
                    class="input-txt" type="password" MaxLength="20" required />
            </div>
        </div>
        <br />

        <br />
        <br />
            <div style="float:right; margin-right:700px;" class="form-group">
                <div class="col-lg-offset-4 col-lg-8">
                    <br />
                    <asp:Button ID="btnLogin" runat="server" class="btn btn--right" Type="submit" Text="Login" 
                        OnClick="btnLogin_Click"/>
                         <br /><br />
                </div>
            </div>

        <br />
        <br />
        <br />
        <br />
        </div>
</asp:Content>
