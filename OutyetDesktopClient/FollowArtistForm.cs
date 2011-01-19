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
    public partial class FollowArtistForm : Form
    {
        BLL b = Program.BLL;
        MainForm p;

        public FollowArtistForm()
        {
            InitializeComponent();
        }

        private void FollowArtistForm_Load(object sender, EventArgs e)
        {
            p = (MainForm)Owner;
        }

        private void followButton_Click(object sender, EventArgs e)
        {
            if (b.FollowArtist(p.Username, artistText.Text))
            {
                p.PopulateForm();
                this.Close();
            }
            else
            {
                MessageBox.Show(artistText.Text + " was not found in the database. Sorry.", "Unknown artist",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
