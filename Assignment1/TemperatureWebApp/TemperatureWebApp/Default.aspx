<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TemperatureWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Temperature Converter</h1>
        <h2>Celsius to Fahrenheit</h2>
        <asp:Table runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Width="250px"><asp:TextBox ID ="c2fTextBox"  runat="server" Width ="200px" Height="45px" ></asp:TextBox></asp:TableCell>
                 <asp:TableCell runat="server" Width="150px"><asp:Button ID="c2fConvertButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="c2fConvertButton_OnClick" Text ="Convert"></asp:Button></asp:TableCell>
                 <asp:TableCell runat="server" Width="400px"><asp:Label ID="c2fLabel" font-size="32px" runat="server">Result1</asp:Label></asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        <h2>Fahrenheit to Celsius</h2>
        <asp:Table runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Width="250px"><asp:TextBox ID ="f2cTextBox"  runat="server" Width ="200px" Height="45px" ></asp:TextBox></asp:TableCell>
                 <asp:TableCell runat="server" Width="150px"><asp:Button ID="f2cConvertButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="f2cConvertButton_OnClick" Text ="Convert"></asp:Button></asp:TableCell>
                 <asp:TableCell runat="server" Width="400px"><asp:Label ID="f2cLabel" font-size="32px" runat="server">Result2</asp:Label></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
