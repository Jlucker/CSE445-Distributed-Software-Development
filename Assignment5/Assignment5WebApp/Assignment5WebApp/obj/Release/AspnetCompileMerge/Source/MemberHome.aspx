<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MemberHome.aspx.cs" Inherits="Assignment5WebApp.MemberHome" %>

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
            <asp:Label runat="server" Width="700" ID="MemberHomeLabel" CssClass="h2"></asp:Label>
        </div>
    </div>
    <br/>
    <br/>
    <div class="row">
        <div class="col-md-12">
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="250px"><asp:TextBox ID ="WeatherTextBox"  runat="server" Width ="300px" Height="45px" placeholder="Enter Zipcode or Address" ></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="150px"><asp:Button ID="WeatherButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="WeatherButton_OnClick" Text ="Go!"></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br/> 
            <asp:Table ID="WeatherTable" runat="server">
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server" Width="100px"><asp:Label ID="Label3" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Day1Label" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Day2Label" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Day3Label" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Day4Label" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Day5Label" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server" Width="100px"><asp:Label ID="Label2" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Image1" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Image2" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Image3" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Image4" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="Image5" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server" Width="100px"><asp:Label ID="Label1" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="DescLabel1" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="DescLabel2" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="DescLabel3" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="DescLabel4" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="DescLabel5" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server" Width="100px"><asp:Label ID="HighLabel" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MaxLabel1" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MaxLabel2" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MaxLabel3" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MaxLabel4" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MaxLabel5" font-size="30px" runat="server"> </asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server" Width="100px"><asp:Label ID="LowLabel" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MinTemp1Label" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MinTemp2Label" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MinTemp3Label" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MinTemp4Label" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label ID="MinTemp5Label" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    <br/>
    <br/>
    <div class="row">
      <div class="col-md-12">
          <asp:Label runat="server" Width="700"><h2>Add Todo Item</h2></asp:Label>
           <asp:Table runat="server" width ="100%">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="33%"><asp:TextBox runat="server" Width="100%" ID="AddItemTextBox" placeholder="Title" Height="45px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="33%"><input type="text" id="datepicker" style="height:45px; width:100%;" placeholder="Due Date" name="datepicker"></asp:TableCell>
                    <asp:TableCell runat="server" Width="33%"><asp:Button ID="AddItemButton" CssClass="btn btn-primary btn-lg" Width="40%" runat="server" OnClick="AddItemButton_OnClick" Text ="Add" ></asp:Button></asp:TableCell>
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