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
    public partial class NewListForm : Form
    {
        BLL b = Program.BLL;

        public NewListForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
             MainForm p = (MainForm)Owner;
            if (b.CreateList(p.Username, listBox.Text))
            {
                try
                {
                    p.PopulateForm();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("You cannot delete the followed artists list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A list with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
