using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptionService;

namespace Assignment5WebApp
{
    public partial class EncryptDecrypt_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Encrypts the specified string using the EncryptionService.DLL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EncryptButton_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ToBeEncryptedTextBox.Text))
            {
                EncryptionService.EncryptionService es = new EncryptionService.EncryptionService();
                var result = es.Encrypt(ToBeEncryptedTextBox.Text);
                ToBeDecryptedTextBox.Text = result;
            }
        }

        /// <summary>
        /// Decrypts the specified string using the EncryptionService.DLL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DecryptButton_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ToBeDecryptedTextBox.Text))
            {
                EncryptionService.EncryptionService es = new EncryptionService.EncryptionService();
                var result = es.Decrypt(ToBeDecryptedTextBox.Text);
                DecryptedLabel.Text = result;
            }
        }
    }
}