<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QDevProject.Portals.BP_Portal.Home" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>QDev</h1>
        <p class="lead">We're a small company dedicated to bringing together Business Partners and Applicants to make the whole process seamless and convienent for everyone..</p>
        <p><a href="About.aspx" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-2">
            <h2>Jobs</h2>
            <p>
                View/Post/Edit a Job Posting. Show to the world what you have available!
            </p>
            <p>
                <a class="btn btn-default" href="Jobs/ViewJobs.aspx">View Jobs &raquo;</a>
            </p>
        </div>
        <div class="col-md-2">
            <h2></h2>
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
