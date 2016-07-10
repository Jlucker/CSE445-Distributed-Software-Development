<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EncryptDecrypt-TryIt.aspx.cs" Inherits="Assignment5WebApp.EncryptDecrypt_TryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>EncryptDecrypt-TryIt</h1>
        <p>This is the try it page for the encryption and decryption services</p>
    </div>
    <br/>
    <div class="row">
        <div class="col-md-6">
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:TextBox ID ="ToBeEncryptedTextBox" placeholder="String to be encrypted" runat="server" Width="300px"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><asp:Button id="EncryptButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="EncryptButton_OnClick" Text ="Encrypt"></asp:Button></asp:TableCell>
                    </asp:TableRow>
            </asp:Table>
            <br/>
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:TextBox ID ="ToBeDecryptedTextBox" runat="server" placeholder="Encrypted String" Width="300px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Button id="DecryptButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="DecryptButton_OnClick" Text ="Decrypt"></asp:Button></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Label runat="server" id="DecryptedLabel">Ready to Decrypt</asp:Label></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
    </div>
</asp:Content>

