<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Member.aspx.cs" Inherits="Assignment5WebApp.Member" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <asp:Label runat="server" Width="700"><h2>Member Page</h2></asp:Label>
        </div>
    </div>
    <br/>
    <br/>
     <div class="row">
        <div class="col-md-6">
             <asp:Table runat="server">
                 
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center"><asp:Label runat="server"><h2>Existing Member Sign In</h2> </asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center"><asp:TextBox runat="server" Width="300px" ID="ExistingUserNameTextBox" placeholder="Username" Height="45px" ></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center"><asp:TextBox runat="server" Width="300px" ID="ExistingPasswordTextBox" placeholder="Password" Height="45px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                  <asp:TableCell runat="server" HorizontalAlign="Center"><asp:Button ID="ExistingUserButton" CssClass="btn btn-primary btn-lg" runat="server" Width="280px" OnClick="ExistingUserButton_OnClick" Text ="Sign In" ></asp:Button></asp:TableCell>
                </asp:TableRow>
                 
                <asp:TableRow runat="server">
                  <asp:TableCell runat="server"><asp:Label runat="server" ID="ExisingMemberLabel"></asp:Label></asp:TableCell>
                </asp:TableRow>
                 
                 <asp:TableRow runat="server">
                  <asp:TableCell runat="server"><asp:Label runat="server"><h3>Test Account Info For Easy Testing:</h3></asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                  <asp:TableCell runat="server"><asp:Label runat="server">Test Account: TestUser1</asp:Label></asp:TableCell>
                </asp:TableRow>
                 
                 <asp:TableRow runat="server">
                  <asp:TableCell runat="server"><asp:Label runat="server">Test Password: test</asp:Label></asp:TableCell>
                </asp:TableRow>
                 
                 <asp:TableRow runat="server">
                  <asp:TableCell runat="server" HorizontalAlign="Center"><asp:Button ID="LoadTestInfoButton" CssClass="btn btn-primary btn-lg" runat="server" Width="280px" OnClick="LoadTestInfoButton_OnClick" Text ="Load Test Account" ></asp:Button></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
          <div class="col-md-6">
             <asp:Table runat="server">
                 
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center"><asp:Label runat="server"><h2>New Member Sign Up</h2> </asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center"><asp:TextBox runat="server" Width="300px" ID="NewUserTextBox" placeholder="Username" Height="45px" ></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center"><asp:TextBox runat="server" Width="300px" ID="NewUserPasswordTextBox" placeholder="Password" Height="45px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                  <asp:TableCell runat="server" HorizontalAlign="Center"><asp:Button ID="NewUserButton" CssClass="btn btn-primary btn-lg" runat="server" Width="280px" OnClick="NewUserButton_OnClick" Text ="Sign Up" ></asp:Button></asp:TableCell>
                </asp:TableRow>
                 
                <asp:TableRow runat="server">
                  <asp:TableCell runat="server"><asp:Label runat="server" ID="NewMemberLabel"></asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
    </div>

</asp:Content>

