<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="forgotten_password.aspx.cs" Inherits="QDevProject.Extras.forgotten_password" %>

<asp:Content ID="forgot_password" ContentPlaceHolderID="MainContent"  runat="server">

     <div>
            <label id="label" runat="server">Email recovery</label>
            <asp:TextBox ID="current_email" runat="server"></asp:TextBox>

        </div>
        <div>
            <asp:Button id="system_check" runat="server" text="Recover Password Recover" OnClick="system_check_Click"/>
        </div>
        <div>
            <label id="message" runat="server"></label>
        </div>
</asp:Content>
