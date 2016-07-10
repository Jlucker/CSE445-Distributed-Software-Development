<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Staff1Home.aspx.cs" Inherits="Assignment5WebApp.Staff1Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
   <script src="//code.jquery.com/jquery-1.10.2.js"></script>
   <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
   <script>
       $(function() {
           $( "#datepicker" ).datepicker();
       });
  </script>
    <br/>
    <br/>
    <div class="row">
        <div class="col-md-8">
            <asp:Label runat="server" Width="700" ID="Staff1HomeLabel" CssClass="h2"></asp:Label>
            <asp:Label runat="server" Width="700" ID="Label1">Selecting "All Users" in the drop down will add a todo item for all users.</asp:Label>
            <asp:Label runat="server" Width="700" ID="Label2">Selecting a specific user will add a todo item for that user.</asp:Label>
        </div>
    </div>
    <br/>
    <br/>
    <div class="row">
      <div class="col-md-12">
          <asp:Label runat="server" Width="700"><h2>Add Todo Item</h2></asp:Label>
           <asp:Table runat="server" Width="100%">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="25%"><asp:TextBox runat="server" Width="100%" ID="AddItemTextBox" placeholder="Title" Height="45px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="20%"><asp:DropDownList runat="server" ID="AuthUserDropDown" Width="100%" Height="45px"/></asp:TableCell>
                    <asp:TableCell runat="server" Width="20%"><input type="text" id="datepicker" style="height:45px; width:100%" placeholder="Due Date" name="datepicker"></asp:TableCell>
                    <asp:TableCell runat="server" Width="20%"><asp:Button ID="AddItemButton" Width="100%" CssClass="btn btn-primary btn-lg" runat="server" OnClick="AddItemButton_OnClick" Text ="Add" ></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
           <br />
            <h3 ID="ActiveTasks" runat="server">Active Tasks</h3>
            <asp:Table ID="TodoTable" runat="server" width="700px">
                <asp:TableRow runat="server">
                </asp:TableRow>
            </asp:Table>
            <h3 ID="CompletedTasks" runat="server">Completed Tasks</h3>
            <asp:Table ID="CompleteTable" runat="server" width="700px">
                <asp:TableRow runat="server">
                </asp:TableRow>
            </asp:Table>
      </div>
    </div>
    <div class="row">
        <asp:Label runat="server" ID="debug" Width="700"></asp:Label>
    </div>
</asp:Content>