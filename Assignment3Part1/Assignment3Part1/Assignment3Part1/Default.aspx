<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment3Part1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-md-12">
            <h2>Weather Service</h2>
            <p>This is a weather service powered by the Accuweather API</p>
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="250px"><asp:TextBox ID ="WeatherTextBox"  runat="server" Width ="300px" Height="45px" ></asp:TextBox></asp:TableCell>
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
    <div class="row">
        <div class="col-md-12">
            <h2>News Service</h2>
            <p>This is a news service powered by the Guardian news API</p>
                <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="250px"><asp:TextBox ID ="NewsTextBox"  runat="server" Width ="300px" Height="45px" ></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="150px"><asp:Button ID="NewsButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="NewsButton_OnClick" Text ="Go!"></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="NewsTable" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="100px"><asp:Label ID="TopicLabel" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="700px"><asp:Label ID="TitleLabel" font-size="20px" runat="server"> </asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
     </div>
    
</asp:Content>
