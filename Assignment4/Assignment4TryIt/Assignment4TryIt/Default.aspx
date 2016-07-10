<%@ Page Title="Home Page" Language="C#" ValidateRequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment4TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-12">
            <h2>Add Person Service</h2>
            <p>This is a service that adds a person to the Persons.xml file</p>
        </div>
     </div>
    <div class="row">
        <div class="col-md-6">
            
             <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server" id="NameLabel" CssClass="h3">Name</asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">First Name:</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Last Name:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="FirstNameTextBox" runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="LastNameTextBox" runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server" id="PhoneLabel" CssClass="h3">Phone</asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Cell:</asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Cell Provider:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="CellPhoneTextBox" runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="CellProviderTextBox" runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Work:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="WorkPhoneTextBox" runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server" id="CredentialLabel" CssClass="h3">Credential</asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Username:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="UserIdTextBox"  runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server" Width="50px" ><asp:Label runat="server" id="UsernameCheckLabel"></asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Password:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:TextBox ID ="PasswordTextBox" runat="server" Width ="200px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server">Requires Encryption?</asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:RadioButtonList ID="EncryptionRadioButtonList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="Yes" />
                        <asp:ListItem Text="No" Value="No" /></asp:RadioButtonList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px" height="25"><asp:Label runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px"><asp:Label runat="server" id="CategoryLabel" CssClass="h3">Category</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="300px" ColumnSpan="2"><asp:RadioButtonList ID="CategoryRadioButtonList" runat="server" RepeatDirection="Horizontal"> 
                        <asp:ListItem Text="Family" Value="Family" />
                        <asp:ListItem Text="Friend" Value="Friend" />
                        <asp:ListItem Text="Work" Value="Work" />
                    </asp:RadioButtonList></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="200px" height="50px"><asp:Label runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center"><asp:Button ID="TestDataButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="TestDataButton_OnClick" Text ="Load Test Data" Width ="200px"></asp:Button></asp:TableCell>
                    <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center"><asp:Button ID="AddButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="AddButton_OnClick" Text ="Submit" Width ="200px"></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br/>
        <div class="col-md-6" style="height: 730px; overflow: scroll">
           
        <asp:Table runat="server" id="PersonTable" width ="100%">
            
        </asp:Table>
                
        </div>
    </div>
    <br/><br/>
    <div class="row">
        <div class="col-md-12">
            <h2>Transformation Service</h2>
            <p>This is a service that generates an HTML file from an XML file and the corresponding XSL file</p>
            <p>Please choose one of the options for your XML and XSL source</p>
        </div>
     </div>
    <div class="row">
        <div class="col-md-6">
            <h3>XML file sources</h3>
            <p>Please provide a link or upload your XML file</p>
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="100%"><asp:Label runat="server" id="XmlUrlLabel">Specify a URL for your XML file:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="100%"><asp:TextBox ID ="XmlUrlTextBox" runat="server" Width ="100%"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:Label runat="server" id="XmlFileUploadLabel">Upload your XML file:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:FileUpload runat="server" id="XmlFileUploadControl"/></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:Label runat="server" id="RawXmlLabel">Paste the contents of your XML file:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:TextBox ID ="RawXmlTextBox" runat="server" Width ="100%" height="300px" TextMode ="Multiline"></asp:TextBox></asp:TableCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
        <div class="col-md-6">
            <h3>XSL file sources</h3>
            <p>Please provide a link or upload your XSL file</p>
            <asp:Table runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="100%"><asp:Label runat="server" id="XslUrlLabel">Specify a URL for your XSL file:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="100%"><asp:TextBox ID ="XslUrlTextBox" runat="server" Width ="100%"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:Label runat="server" id="XslFileUploadLabel">Upload your XSL file:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:FileUpload runat="server" id="XslFileUploadControl"/></asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:Label runat="server" id="RawXslLabel">Paste the contents of your XSL file:</asp:Label></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                     <asp:TableCell runat="server" Width="100%"><asp:TextBox ID ="RawXslTextBox" runat="server" Width ="100%" height="300px" TextMode ="Multiline"></asp:TextBox></asp:TableCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
     </div>
    <br/><br/>
    <div class="row">
        <div class="col-md-12">
            <asp:Button id="XmlXslUploadButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="XmlXslUploadButton_OnClick" Text ="Get HTML File" Width ="200px"></asp:Button>
        </div>
    </div>
    <div class="row">
        <br/><br/>
        <div class="col-md-12" style="height: 700px; overflow: scroll">
            <asp:Label runat="server" id="TableLabel"></asp:Label>
        </div>
    </div>
    <br/><br/>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" id="ErrorLabel"></asp:Label>
        </div>
    </div>
</asp:Content>
