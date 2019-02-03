<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QDevProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>QDev</h1>
        <p class="lead">We're a small company dedicated to bringing together Business Partners and Applicants to make the whole process seamless and convienent for everyone..</p>
        <p><a href="About.aspx" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Already have an account?</h2>
            <p>
                Log in as a Business Partner or an Applicant if you already have an account with us!
            </p>
            <p>
                <a class="btn btn-default" href="LogIn.aspx">Log In &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Join us today!</h2>
            <p>
                Don't have an account yet? Register here as a Business Partner or an Applicant and find what you need today!
            </p>
            <p>
                <a class="btn btn-default" href="Online Application/BP/Register.aspx">Register as a Business Partner &raquo;</a>
                <a class="btn btn-default" href="Online Application/Applicant/Register.aspx">Register as an Applicant &raquo;</a>
            </p>
        </div>

    </div>

</asp:Content>
