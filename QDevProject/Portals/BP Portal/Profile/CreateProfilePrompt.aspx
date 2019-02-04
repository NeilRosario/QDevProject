<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProfilePrompt.aspx.cs" Inherits="QDevProject.Portals.BP_Portal.Profile.CreateProfilePrompt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome</h1>
    <h3>It appears your account's profile is not yet complete. Kindly click the button below to complete your account registration.</h3>

    
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <hr />
            <div class="form-group text-left">
                <asp:Button ID="btnApply" runat="server"
                    CssClass="btn btn-success" Text="Finish Application"
                    OnClick="btnApply_Click">
                </asp:Button>
           </div>
       </div>                        
</asp:Content>
