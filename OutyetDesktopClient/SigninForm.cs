using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace OutyetDesktopClient
{
    public partial class SigninForm : Form
    {
        BLL b = Program.BLL;
        MainForm mainForm;

        public SigninForm()
        {
            InitializeComponent();
        }

        private void SigninForm_Load(object sender, EventArgs e)
        {
            errorProvider.Icon = OutyetDesktopClient.Properties.Resources.Excl;
            mainForm = (MainForm)Owner;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CreateUserForm().ShowDialog(this);
        }

        public void EnterLogin(String username, String password)
        {
            usernameBox.Text = username;
            passwordBox.Text = password;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (b.CheckLogin(usernameBox.Text, passwordBox.Text))
            {
                errorProvider.SetError(usernameBox, "");
                Properties.Settings.Default.userName = usernameBox.Text;
                Properties.Settings.Default.password = passwordBox.Text;
                mainForm.Username = usernameBox.Text;
                mainForm.Password = passwordBox.Text;
                mainForm.PopulateForm();
                mainForm.Visible = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                errorProvider.SetError(usernameBox, "Invalid username or password.");
                this.DialogResult = DialogResult.None;
            }   
        }
    }
}
