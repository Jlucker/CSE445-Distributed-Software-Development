using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment4TryIt.AddPersonServiceReference;
using Assignment4TryIt.TransformXmlServiceReference;

namespace Assignment4TryIt
{
    public partial class _Default : Page
    {
        Random random = new Random();
        List<string> firstNames = new List<string>() {"Noah", "Emma", "Liam", "Olivia", "Mason", "Sophia",
                                                      "Jacob", "Ava", "William", "Isabella", "Ethan","Mia",
                                                      "James", "Abigail", "Alexander", "Emily", "Michael",
                                                      "Charlotte", "Benjamin", "Harper"};
        List<string> lastNames = new List<string>() {"Archer", "Ingram", "Figueroa", "Newman", "Wilkerson",
                                                     "Washington", "Bowen", "Graham", "Moss", "Franklin",
                                                     "Beck", "Payne", "Hopkins", "Drake","Mason", "Wagner",
                                                     "Flores", "Riley", "Kopp", "Ochoa", "Pak"};
        List<string> cellProviders = new List<string>() {"Verizon", "AT&T", "Sprint", "T-Mobile",
                                                         "Virgin Mobile", "Cricket", "Vodaphone", "O2"};  
        
         
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPersonData();
        }

        /// <summary>
        /// Creates a new person and then uses the service to add them to Persons.xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddButton_OnClick(object sender, EventArgs e)
        {
            AddPersonClient client = new AddPersonClient();

            var newPerson = CreateNewPerson();

            if (client.UserIdCheck(newPerson.Credential.Id))
            {
                UsernameCheckLabel.Text = "Username Already Exists!";
            }
            else
            {
                UsernameCheckLabel.Text = "";
                AddNewPerson(newPerson);
                ClearFields();
            }
        }

        /// <summary>
        /// Creates a new Person object from the data entered into the form
        /// </summary>
        /// <returns>Returns the newly created person object</returns>
        private Person CreateNewPerson()
        {
            Person person = new Person();

            Name name = new Name();
            name.First = CheckTextInput(FirstNameTextBox.Text);
            name.Last = CheckTextInput(LastNameTextBox.Text);

            Credential credential = new Credential();
            credential.Id = CheckTextInput(UserIdTextBox.Text);

            Password password = new Password();
            password.PasswordValue = CheckTextInput(PasswordTextBox.Text);
            password.Encryption = EncryptionRadioButtonList.SelectedValue;

            credential.Password = password;

            Phone phone = new Phone();
            phone.Work = CheckTextInput(WorkPhoneTextBox.Text);

            Cell cell = new Cell();
            cell.CellNumber = CheckTextInput(CellPhoneTextBox.Text);
            cell.Provider = CheckTextInput(CellProviderTextBox.Text);

            phone.Cell = cell;

            Category category = new Category();
            category.CategoryValue = CategoryRadioButtonList.SelectedValue;

            person.Name = name;
            person.Credential = credential;
            person.Phone = phone;
            person.Category = category;

            return person;
        }

        /// <summary>
        /// Clears all of the text fields in the form
        /// </summary>
        private void ClearFields()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            CellPhoneTextBox.Text = "";
            CellProviderTextBox.Text = "";
            WorkPhoneTextBox.Text = "";
            UserIdTextBox.Text = "";
            PasswordTextBox.Text = "";
            EncryptionRadioButtonList.SelectedIndex = 0;
            CategoryRadioButtonList.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a new Person object to the Persons.xml file via the AddPerson service
        /// </summary>
        /// <param name="person"></param>
        private void AddNewPerson(Person person)
        {
            AddPersonClient client = new AddPersonClient();
            client.AddNewPerson(person);
            GetPersonData();
        }

        /// <summary>
        /// Checks if the text is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The input string if it's not null or empty and string.Empty otherwise</returns>
        private string CheckTextInput(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Populates the table with person data from Persons.xml
        /// </summary>
        private void GetPersonData()
        {
            PersonTable.Rows.Clear();

            AddPersonClient client = new AddPersonClient();
            var persons = client.GetPersons();

            persons.Person = persons.Person.OrderBy(p => p.Name.First).ToArray();

            var shading = 0;
            foreach (var person in persons.Person)
            {
                TableRow row1 = new TableRow();
                row1.BackColor = CheckColor(shading);
                row1.ForeColor = CheckFontColor(shading);

                TableCell nameCell = new TableCell();
                nameCell.Text = person.Name.First + " " + person.Name.Last;
                nameCell.Font.Size = 16;
                nameCell.ColumnSpan = 2;
                row1.Cells.Add(nameCell);

                TableCell categoryCell = new TableCell();
                categoryCell.Text = person.Category.CategoryValue;
                categoryCell.Font.Size = 16;
                categoryCell.ColumnSpan = 2;
                row1.Cells.Add(categoryCell);

                TableRow row2 = new TableRow();
                row2.BackColor = CheckColor(shading);
                row2.ForeColor = CheckFontColor(shading);

                TableCell phoneCell1 = new TableCell();
                phoneCell1.Text = "Cell:";
                phoneCell1.Width = 50;
                phoneCell1.Font.Bold = true;
                row2.Cells.Add(phoneCell1);

                TableCell phoneCell2 = new TableCell();
                phoneCell2.Text = person.Phone.Cell.CellNumber;
                row2.Cells.Add(phoneCell2);

                TableCell phoneCell3 = new TableCell();
                phoneCell3.Text = "Provider: ";
                phoneCell3.Font.Bold = true;
                row2.Cells.Add(phoneCell3);

                TableCell phoneCell4 = new TableCell();
                phoneCell4.Text = person.Phone.Cell.Provider;
                row2.Cells.Add(phoneCell4);

                TableRow row3 = new TableRow();
                row3.BackColor = CheckColor(shading);
                row3.ForeColor = CheckFontColor(shading);

                TableCell phoneCell5 = new TableCell();
                phoneCell5.Text = "Work:";
                phoneCell5.Font.Bold = true;
                row3.Cells.Add(phoneCell5);

                TableCell phoneCell6 = new TableCell();
                phoneCell6.Text = person.Phone.Work;
                phoneCell6.ColumnSpan = 3;
                row3.Cells.Add(phoneCell6);

                TableRow row4 = new TableRow();
                row4.BackColor = CheckColor(shading);
                row4.ForeColor = CheckFontColor(shading);

                TableCell credentialCell1 = new TableCell();
                credentialCell1.Text = "Username:";
                credentialCell1.Font.Bold = true;
                row4.Cells.Add(credentialCell1);

                TableCell credentialCell2 = new TableCell();
                credentialCell2.Text = person.Credential.Id;
                credentialCell2.ColumnSpan = 3;
                row4.Cells.Add(credentialCell2);

                TableRow row5 = new TableRow();
                row5.BackColor = CheckColor(shading);
                row5.ForeColor = CheckFontColor(shading);

                TableCell credentialCell3 = new TableCell();
                credentialCell3.Text = "Password:";
                credentialCell3.Font.Bold = true;
                row5.Cells.Add(credentialCell3);

                TableCell credentialCell4 = new TableCell();
                credentialCell4.Text = person.Credential.Password.PasswordValue;
                row5.Cells.Add(credentialCell4);

                TableCell credentialCell5 = new TableCell();
                credentialCell5.Text = "Encryption:";
                credentialCell5.Font.Bold = true;
                row5.Cells.Add(credentialCell5);

                TableCell credentialCell6 = new TableCell();
                credentialCell6.Text = person.Credential.Password.Encryption;
                row5.Cells.Add(credentialCell6);

                PersonTable.Rows.Add(row1);
                PersonTable.Rows.Add(row2);
                PersonTable.Rows.Add(row3);
                PersonTable.Rows.Add(row4);
                PersonTable.Rows.Add(row5);

                if (shading == 0)
                {
                    shading = 1;
                }
                else
                {
                    shading = 0;
                }
            }
        }

        /// <summary>
        /// Alternates the table's background color 
        /// </summary>
        /// <param name="shading"></param>
        /// <returns>Returns blue if 0 and empty if 1</returns>
        private Color CheckColor(int shading)
        {
            if (shading == 0)
            {
                return Color.FromArgb(66,139,202);
            }
            else
            {
                return Color.Empty;
            }
        }

        /// <summary>
        /// Alternates the table's font color
        /// </summary>
        /// <param name="shading"></param>
        /// <returns>Returns white if 0 and black if 1</returns>
        private Color CheckFontColor(int shading)
        {
            if (shading == 0)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        /// <summary>
        /// Generates random data and populates the form for easy testing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TestDataButton_OnClick(object sender, EventArgs e)
        {
            var randomFirst = random.Next(0, firstNames.Count);
            var firstName = firstNames.ElementAt(randomFirst);

            var randomLast = random.Next(0, firstNames.Count);
            var lastName = lastNames.ElementAt(randomLast);

            var firstThree = random.Next(100, 999);
            var secondThree = random.Next(100, 999);
            var lastFour = random.Next(1000, 9999);

            var workPhone = firstThree + "-" + secondThree + "-" + lastFour;

            firstThree = random.Next(100, 999);
            secondThree = random.Next(100, 999);
            lastFour = random.Next(1000, 9999);

            var cellPhone = firstThree + "-" + secondThree + "-" + lastFour;

            var randomProvider = random.Next(0, cellProviders.Count);
            var cellProvider = cellProviders.ElementAt(randomProvider);

            var usernameNumber = random.Next(1, 100);
            var usernameFirst = firstName.Substring(0, 1);
            var usernameLast = lastName;
            var username = usernameFirst.ToLower() + usernameLast.ToLower() + usernameNumber;

            AddPersonClient client = new AddPersonClient();
            // This ensures that a taken username is not randomly generated
            // The loop is broken after 100 just in case the list is saturated.
            var userIdHalt = 0;
            while (client.UserIdCheck(username))
            {
                username = username + random.Next(10, 99);

                if (userIdHalt == 100)
                {
                    break;
                }
            }

            var nameHalt = 0;
            // This ensures that a taken first and last name are not randomly generated
            // The loop is broken after 100 just in case the list is saturated.
            while (client.PersonNameCheck(firstName, lastName))
            {
                randomFirst = random.Next(0, firstNames.Count);
                firstName = firstNames.ElementAt(randomFirst);

                randomLast = random.Next(0, firstNames.Count);
                lastName = lastNames.ElementAt(randomLast);

                if (nameHalt == 100)
                {
                    break;
                }
            }

            var password = System.Web.Security.Membership.GeneratePassword(18, 2);

            var category = random.Next(0, 3);

            EncryptionRadioButtonList.SelectedIndex = 0;

            FirstNameTextBox.Text = firstName;
            LastNameTextBox.Text = lastName;
            CellPhoneTextBox.Text = cellPhone;
            CellProviderTextBox.Text = cellProvider;
            WorkPhoneTextBox.Text = workPhone;
            UserIdTextBox.Text = username;
            PasswordTextBox.Text = password;
            CategoryRadioButtonList.SelectedIndex = category;
        }

        /// <summary>
        /// Captures the the data entered in the XML and XSL fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void XmlXslUploadButton_OnClick(object sender, EventArgs e)
        {
            var upload = CheckFields();

            if (upload.code1 == 4 || upload.code2 == 4)
            {
                if (upload.code1 == 4)
                {
                    XmlFileUploadLabel.Text = "Please Supply valid XML data";
                    XmlFileUploadLabel.ForeColor = Color.Red;
                    XmlUrlLabel.Text = "Please Supply valid XML data";
                    XmlUrlLabel.ForeColor = Color.Red;
                    RawXmlLabel.Text = "Please Supply valid XML data";
                    RawXmlLabel.ForeColor = Color.Red;
                }
                if (upload.code2 == 4)
                {
                    XslFileUploadLabel.Text = "Please Supply valid XSL data";
                    XslFileUploadLabel.ForeColor = Color.Red;
                    XslUrlLabel.Text = "Please Supply valid XSL data";
                    XslUrlLabel.ForeColor = Color.Red;
                    RawXslLabel.Text = "Please Supply valid XSL data";
                    RawXslLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                var html = SendToTransformationService(upload);
                ClearTransformFields();
                DownloadHtmlFile(html);
            }
        }

        /// <summary>
        /// Creates an HTML file from the HTML string received from the Transformation service and
        /// allows the user to download it.
        /// </summary>
        /// <param name="html"></param>
        private void DownloadHtmlFile(string html)
        {
            var fileName = "result.html";
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("HtmlFiles/" + fileName)))
            {
                writer.WriteLine(html);
                writer.Close();
            }

            using (System.IO.FileStream stream = System.IO.File.Open(Server.MapPath("HtmlFiles/" + fileName),System.IO.FileMode.Open))
            {
                byte[] file = new byte[stream.Length];
                stream.Read(file, 0, Convert.ToInt32(stream.Length));
                Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(file);
                Response.End();
            }
        }

        /// <summary>
        /// Clears all of the transform input fields 
        /// </summary>
        private void ClearTransformFields()
        {
            XmlUrlTextBox.Text = string.Empty;
            RawXmlTextBox.Text = string.Empty;
            XmlFileUploadControl = new FileUpload();

            XslUrlTextBox.Text = string.Empty;
            RawXslTextBox.Text = string.Empty;
            XslFileUploadControl = new FileUpload();

        }
        /// <summary>
        /// Checks which fields have been used on the form and returns the corresponding code
        /// </summary>
        /// <returns>Returns an operation code</returns>
        private Upload CheckFields()
        {
            Upload upload = new Upload();

            if (!string.IsNullOrEmpty(RawXmlTextBox.Text))
            {
                upload.xmlRaw = RawXmlTextBox.Text;
                upload.xmlRaw = upload.xmlRaw.Trim();
                upload.code1 = 1;
            }
            else if (XmlFileUploadControl.HasFile)
            {
                try
                {
                    if (XmlFileUploadControl.PostedFile.ContentType.Equals("text/xml"))
                    {
                        if (XmlFileUploadControl.PostedFile.ContentLength <= 512000000)
                        {
                            var filename = Path.GetFileName(XmlFileUploadControl.FileName);

                            if (filename.Contains(".xml"))
                            {
                                XmlFileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                                upload.xmlSimpleFilename = filename;
                                upload.xmlFilename = Server.MapPath("~/") + filename;
                                upload.xmlFileContent = System.IO.File.ReadAllText(upload.xmlFilename);
                                upload.xmlFileContent = upload.xmlFileContent.Trim();
                                upload.code1 = 2;
                            }
                            else
                            {
                                XmlFileUploadLabel.Text = "File must have .xml extension. Example: Person.xml";
                                upload.code1 = 4;
                            }
                        }
                        else
                        {
                            XmlFileUploadLabel.Text = "File size exceeds 500MB";
                            upload.code1 = 4;
                        }
                    }
                    else
                    {
                        XmlFileUploadLabel.Text = "Only accepts Text/XML file types";
                        upload.code1 = 4;
                    }
                }
                catch (Exception e)
                {
                    XmlFileUploadLabel.Text = "Error: File could not be uploaded \n" + e;
                    upload.code1 = 4;
                }  
            }
            else if (!string.IsNullOrEmpty(XmlUrlTextBox.Text))
            {
                upload.xmlUrl = XmlUrlTextBox.Text;
                upload.xmlUrl = upload.xmlUrl.Trim();
                upload.code1 = 3;
            }
            else
            {
                upload.code1 = 4;
            }

            if (!string.IsNullOrEmpty(RawXslTextBox.Text))
            {
                upload.xslRaw = RawXslTextBox.Text;
                upload.xslRaw = upload.xslRaw.Trim();
                upload.code2 = 1;
            }
            else if (XslFileUploadControl.HasFile)
            {
                try
                {
                    if (XslFileUploadControl.PostedFile.ContentType.Equals("text/xml"))
                    {
                        if (XslFileUploadControl.PostedFile.ContentLength <= 512000000)
                        {
                            var filename2 = Path.GetFileName(XslFileUploadControl.FileName);

                            if (filename2.Contains(".xsl"))
                            {
                                XslFileUploadControl.SaveAs(Server.MapPath("~/") + filename2);
                                upload.xslSimpleFilename = filename2;
                                upload.xslFilename = Server.MapPath("~/") + filename2;
                                upload.xslFileContent = System.IO.File.ReadAllText(upload.xslFilename);
                                upload.xslFileContent = upload.xslFileContent.Trim();
                                upload.code2 = 2;
                            }
                            else
                            {
                                XslFileUploadLabel.Text = "File must have .xsl extension. Example: Person.xsl";
                                upload.code2 = 4;
                            }
                        }
                        else
                        {
                            XslFileUploadLabel.Text = "File size exceeds 500MB";
                            upload.code2 = 4;
                        }
                    }
                    else
                    {
                        XslFileUploadLabel.Text = "Only accepts Text/XML file types";
                        upload.code2 = 4;
                    }
                }
                catch (Exception e)
                {
                    XslFileUploadLabel.Text = "Error: File could not be uploaded \n" + e;
                    upload.code2 = 4;
                }
                
            }
            else if (!string.IsNullOrEmpty(XslUrlTextBox.Text))
            {
                upload.xslUrl = XslUrlTextBox.Text;
                upload.xslUrl = upload.xslUrl.Trim();
                upload.code2 = 3;
            }
            else
            {
                upload.code2 = 4;
            }
            return upload;
        }

        /// <summary>
        /// Sends the XML and XSL data to the Transformation service
        /// </summary>
        /// <param name="upload"></param>
        /// <returns>Formatted html from the XML and XSL files</returns>
        private string SendToTransformationService(Upload upload)
        {
            var html = string.Empty;
            try
            {
                TransformationServiceClient client = new TransformationServiceClient();
                html = client.TransformXml(upload);
                return html;
            }
            catch (Exception e)
            {
                html = "Error: Transformation Service unable to process request \n" + e;
                return html;
            }
        }
    }
}