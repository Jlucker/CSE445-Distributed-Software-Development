<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Staff2Home.aspx.cs" Inherits="Assignment5WebApp.Staff2Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div class="row">
        <div class="col-md-8">
            <asp:Label runat="server" Width="700" ID="Staff2HomeLabel" CssClass="h2"></asp:Label>
            <asp:Label runat="server" Width="700" ID="Label1">The Staff2 page consists of a control panel for roles and users</asp:Label>
        </div>
    </div>
    <div class="row">
      <div class="col-md-6">
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" Width="300px"><h2>Authenticate User</h2></asp:Label></asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Username:</asp:Label></asp:TableCell>
                    </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="AuthUserDropDown" Width="200px"/></asp:TableCell>
                    </asp:TableRow>
                   
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Role:</asp:Label></asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="UserRoleDropDown" Width="200px">
                            <asp:ListItem Text="1 - Member Role" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2 - Staff1 Role" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3 - Staff2 Role" Value="3"></asp:ListItem>
                        </asp:DropDownList> </asp:TableCell>
                    </asp:TableRow>
                       
                  <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Button ID="AuthUserButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="AuthUserButton_OnClick" Text ="Authenticate" Width ="200px"></asp:Button></asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" ID="AuthUSerLabel">Result:</asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
            <br/>
        </div>
         <div class="col-md-6">
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" Width="300px"><h2>Create User</h2></asp:Label></asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Username:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:TextBox runat="server" Width="200px" ID="CreateUserTextBox"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                   
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Password:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:TextBox runat="server" Width="200px" ID="CreateUserPasswordTextBox"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Role:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:CheckBoxList runat="server" ID="CreateUserRoleCheckBox" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Staff1" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Staff2" Value="3"></asp:ListItem>
                    </asp:CheckBoxList></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Button ID="CreateUserButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="CreateUserButton_OnClick" Text ="Create" Width ="200px"></asp:Button></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" ID="CreateUserLabel">Result:</asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
            <br/>
        </div>
       
    </div>
    <br />
    <br />
    <div class="row">
      <div class="col-md-6">
            <asp:Table runat="server">
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" Width="300px"><h2>Delete User</h2></asp:Label></asp:TableCell>
                    </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Username:</asp:Label></asp:TableCell>
                    </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="DeleteUserDropDown" Width="200px"/></asp:TableCell>
                    </asp:TableRow>
                   
                  <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Button ID="DeleteUserButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="DeleteUserButton_OnClick" Text ="Delete" Width ="200px"></asp:Button></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" ID="DeleteUserLabel">Result:</asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
            <br/>
        </div>
        <div class="col-md-6">
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" Width="300px"><h2>Add/Remove Roles</h2></asp:Label></asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Username:</asp:Label></asp:TableCell>
                    </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="AddRolesDropDownList" Width="200px"/></asp:TableCell>
                    </asp:TableRow>
                   
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server">Role:</asp:Label></asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:CheckBoxList runat="server" ID="AddRolesCheckBoxList" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Staff1" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Staff2" Value="3"></asp:ListItem>
                    </asp:CheckBoxList></asp:TableCell>
                </asp:TableRow>
                       
                  <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Button ID="AddRolesButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="AddRolesButton_OnClick" Text ="Add/Remove" Width ="200px"></asp:Button></asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" ID="AddRolesLabel">Result:</asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
            <br/>
        </div>
    </div>
    <br/>
    <br/>
     <div class="row">
           <div class="col-md-12" style="height: 900px; overflow: scroll">
           
        <asp:Table runat="server" id="UserTable" width ="100%">
            
        </asp:Table>
      </div>
         </div>
         <div class="row">
              <div class="col-md-12">
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" Width="300px"><h2>Load With User Data</h2></asp:Label></asp:TableCell>
                    </asp:TableRow>
               
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" ID="LoadDataLabel">Loads 10 Randomly Generated Users into the XML File</asp:Label></asp:TableCell>
                </asp:TableRow>

                  <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Button ID="LoadDataButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="LoadDataButton_OnClick" Text ="Load User Data" Width ="200px"></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br/>
        </div>
     </div>
</asp:Content>