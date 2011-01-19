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
    public partial class UnfollowArtistForm : Form
    {
        BLL b = Program.BLL;
        MainForm p;

        public UnfollowArtistForm()
        {
            InitializeComponent();
        }

        private void UnfollowArtistForm_Load(object sender, EventArgs e)
        {
            p = (MainForm)Owner;
        }
        
        private void unfollowButton_Click(object sender, EventArgs e)
        {
            
            if (b.UnfollowArtist(p.Username, artistBox.Text))
            {
                p.PopulateForm();
                this.Close();
            }
            else
            {
                MessageBox.Show(artistBox.Text + " was not found in the database. Sorry.", "Unknown artist",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
