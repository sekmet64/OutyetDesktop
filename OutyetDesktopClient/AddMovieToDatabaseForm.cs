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
    public partial class AddMovieToDatabaseForm : Form
    {
        private BLL b = Program.BLL;

        public AddMovieToDatabaseForm()
        {
            InitializeComponent();
        }

        private void AddMovieToDatabaseForm_Load(object sender, EventArgs e)
        {
            for (Int32 i = 2020; i > 1900; i--)
            {
                yearBox.Items.Add(i);
            }
            yearBox.SelectedItem = 2011;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            b.AddMovieToDatabase(titleBox.Text, (int)yearBox.SelectedItem, releaseDateBox.Value, directorsBox.Text.Split('\n'), 
                writersBox.Text.Split('\n'), producersBox.Text.Split('\n'), castBox.Text.Split('\n'));
            

			String message = titleBox.Text + " - was added. Do you want to add another movie?";
                        String caption = "Success";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (MessageBox.Show(message, caption, buttons) == System.Windows.Forms.DialogResult.Yes)
            {
                EmptyControls();
            }
            else
            {
                this.Close();
            }
        }

        private void EmptyControls()
        {
            titleBox.Text = "";
            yearBox.SelectedValue = 2011;
            directorsBox.Text = "";
            writersBox.Text = "";
            producersBox.Text = "";
            castBox.Text = "";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
