<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodoListService-TryIt.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Assignment5WebApp.TodoListService_TryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
  <script>
    $(function() {
        $( "#datepicker" ).datepicker();
    });
  </script>

    <div class="jumbotron">
        <h1>TodoListService-TryIt</h1>
        <p>This is the try it page for the TodoList Service</p>
    </div>
    <br/>
    <br/>
    <div class="row">
      <div class="col-md-8">
          <asp:Label runat="server" Width="700"><h2>Add Todo Item</h2></asp:Label>
           <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:TextBox runat="server" Width="500px" ID="AddItemTextBox" placeholder="Title" Height="45px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="AuthUserDropDown" Width="200px" Height="45px"/></asp:TableCell>
                    <asp:TableCell runat="server"><input type="text" id="datepicker" style="height:45px; width:100px;" placeholder="Due Date" name="datepicker"></asp:TableCell>
                    <asp:TableCell runat="server" Width="20%"><asp:Button ID="AddItemButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="AddItemButton_OnClick" Text ="Add" ></asp:Button></asp:TableCell>
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