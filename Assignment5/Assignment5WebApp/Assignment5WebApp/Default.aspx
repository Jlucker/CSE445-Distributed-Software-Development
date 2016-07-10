<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Assignment 5 Web App</h1>
        <p class="lead">This app allows users to sign up and use a persistent Todo List and it also displays the weather on the user's member page</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Members</h2>
            <p>Members can create an account and begin using the todo list and other features immeadiately
            </p>
            <br/>
            <p>
                <a class="btn btn-default" href="Member.aspx">Member Page &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Staff 1</h2>
            <p>Users in the Staff1 role are todo list managers and have access to all of the member todo lists.  They can also add and delete items from 
               all todo lists.
            </p>
            <p>
                <a class="btn btn-default" href="Staff1.aspx">Staff 1 Page &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Staff 2</h2>
            <p>
                Users in the Staff2 role are permissions managers and can edit the roles of all members and staff.
            </p>
            <br/>
            <p>
                <a class="btn btn-default" href="Staff2.aspx">Staff 2 Page &raquo;</a>
            </p>
        </div>
    </div>
    <br/>
    <br/>
    <div class="row">
        <div class="col-md-12">
            <h2>Service Directory</h2>
            <p>This page is deployed at: http://webstrar42.fulton.asu.edu/</p>
            <p>This project is developed by Justin Lucker </p>
            <asp:Table runat="server" BorderWidth="1">
                <asp:TableRow runat="server" Font-Bold="True" >
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server">Provider Name</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Service Name</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Inputs</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Outputs</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server">Try-It Link</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="400px" BorderWidth="1"><asp:Label runat="server">Service Description</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Planned Resources</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server" >
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server">Justin Lucker</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">AuthService</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Credentials Object</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">AuthResponse Object</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server"><a href="AuthService-TryIt.aspx">Click Here</a></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="400px" BorderWidth="1"><asp:Label runat="server">This service authenticates users</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">No External Resources</asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server" >
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server">Justin Lucker</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">TodoListService</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">TodoItem Object</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">TodoList Object</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server"><a href="TodoListService-TryIt.aspx">Click Here</a></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="400px" BorderWidth="1"><asp:Label runat="server">This service controls the todo list</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">No External Resources</asp:Label></asp:TableCell>
                </asp:TableRow>
                
                 <asp:TableRow runat="server" >
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server">Justin Lucker</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">WeatherService</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Location String</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Weather Object</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="150px" BorderWidth="1"><asp:Label runat="server"><a href="WeatherService-TryIt.aspx">Click Here</a></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="400px" BorderWidth="1"><asp:Label runat="server">This service provides access to weather data</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" BorderWidth="1"><asp:Label runat="server">Accuweather API</asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
    </div>
    <br/>
    <br/>

</asp:Content>
