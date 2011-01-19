using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using BusinessLogicLayer;

namespace OutyetDesktopClient
{
    public partial class CreateUserForm : Form
    {
        private ErrorProvider error;
        private Regex usernameRegex = new Regex(@"^[\w\.0-9]*$");
        private Regex nameRegex = new Regex(@"^[\w]+$");
        private BLL b = Program.BLL;
        private Boolean usernameOK, firstNameOK, lastNameOK, passwordOK;

        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
            error = new ErrorProvider();
            error.Icon = OutyetDesktopClient.Properties.Resources.Excl;
        }

        private void usernameBox_Validated(object sender, EventArgs e)
        {
            if (usernameBox.TextLength < 6)
            {
                error.SetError(usernameBox, "Username must be between 6-30 characters."); usernameOK = false;
            }
            else if (!usernameRegex.IsMatch(usernameBox.Text))
            {
                error.SetError(usernameBox, "Username must contain only letters, numbers and dots."); usernameOK = false;
            }
            else if (b.UserExists(usernameBox.Text))
            {
                error.SetError(usernameBox, "Username already exists."); usernameOK = false;
            }
            else
            {
                error.SetError(usernameBox, ""); usernameOK = true;
            }
        }

        private void firstNameBox_Validated(object sender, EventArgs e)
        {
            if (firstNameBox.TextLength < 3)
            {
                error.SetError(firstNameBox, "First name must be between 6-30 characters."); firstNameOK = false;
            }
            else if (!nameRegex.IsMatch(firstNameBox.Text))
            {
                error.SetError(firstNameBox, "First name must contain only letters."); firstNameOK = false;
            }
            else
            {
                error.SetError(firstNameBox, ""); firstNameOK = true;
            }
        }

        private void lastNameBox_Validated(object sender, EventArgs e)
        {
            if (lastNameBox.TextLength < 3)
            {
                error.SetError(lastNameBox, "Last name must be between 6-30 characters."); lastNameOK = false;
            }
            else if (!nameRegex.IsMatch(lastNameBox.Text))
            {
                error.SetError(lastNameBox, "Last name must contain only letters."); lastNameOK = false;
            }
            else
            {
                error.SetError(lastNameBox, ""); lastNameOK = true;
            }
        }

        private void password2Box_Validated(object sender, EventArgs e)
        {
            if (password2Box.TextLength < 6)
            {
                error.SetError(password2Box, "Password must be between 6-30 characters."); passwordOK = false;
            }
            else if (password1Box.Text != password2Box.Text)
            {
                error.SetError(password2Box, "Passwords do not match."); passwordOK = false;
            }
            else
            {
                error.SetError(password2Box, ""); passwordOK = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (usernameOK && firstNameOK && lastNameOK && passwordOK)
            {
                b.CreateUser(usernameBox.Text, firstNameBox.Text, lastNameBox.Text, password2Box.Text);
                ((SigninForm)Owner).EnterLogin(usernameBox.Text, password2Box.Text);
                this.Close();
            }
        }
    }
}
