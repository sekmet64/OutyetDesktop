using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        private BLL b = Program.BLL;
        private String username;
        private String password;
        private String activeList;
        private Int32 selectedMovieID;

        #region getterssetters
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public String Password
        {
            set
            {
                password = value;
            }
        }

        public String ActiveList
        {
            get
            {
                return activeList;
            }
        }
        #endregion getterssetters

        #region init
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            username = Properties.Settings.Default.userName;
            password = Properties.Settings.Default.password;
            if (username == "")
            {
                if (new SigninForm().ShowDialog(this) == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
           
            PopulateForm();
        }

        #endregion init

        public void PopulateForm()
        {
            if (b.GetUserRank(username) == 1)
            {
                adminToolStripMenuItem.Visible = true;
            }

            // status bar
            userStatus.Image = OutyetDesktopClient.Properties.Resources.Person;
            userStatus.Text = username;

            PopulateLists();      
        }

        public void PopulateMovies()
        {
            // movies list
            dataGridView.Columns.Clear();
            dataGridView.DataSource = b.GetListEntries(username, activeList);
            dataGridView.Columns["ID"].Visible = false;
            dataGridView.Columns["ReleaseDate"].Visible = false;
            dataGridView.Sort(dataGridView.Columns["ReleaseDate"], ListSortDirection.Ascending);
            dataGridView.Columns["Release"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["Release"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewLinkColumn detailsColumn = new DataGridViewLinkColumn();

            detailsColumn.Text = "more...";
            detailsColumn.UseColumnTextForLinkValue = true;
            detailsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView.Columns.Add(detailsColumn);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // ((DataGridViewLinkCell)row.Cells["Details"]).
            }
            detailsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void addTitleStripButton_Click(object sender, EventArgs e)
        {
            AddMovie();
        }

        private void addMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMovie();
        }

        private void AddMovie()
        {
            new AddMovie().Show(this);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userName = "";
            Properties.Settings.Default.password = "";
            this.Visible = false;
            if (new SigninForm().ShowDialog(this) == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addMovieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AddMovieToDatabaseForm().Show(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new NewListForm().Show(this);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
                new MovieDetailsForm((Int32)dataGridView.Rows[e.RowIndex].Cells[0].Value).Show(this);
        }

        private void listComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeList = listComboBox.Text; 
            PopulateMovies();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            b.RemoveMovieFromList(username, activeList, selectedMovieID);
            PopulateMovies();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                selectedMovieID = (Int32)dataGridView.SelectedRows[0].Cells[0].Value;
            }
        }

        private void removeMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b.RemoveMovieFromList(username, activeList, selectedMovieID);
            PopulateMovies();
        }

        private void newListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewListForm().Show(this);
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteList();
        }

        private void DeleteList()
        {
            String message = "Are you sure you want to delete the list: " + activeList + "?";
            String caption = "Confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (MessageBox.Show(message, caption, buttons) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    b.DeleteList(username, activeList);
                    PopulateLists();
                }
                catch (Exception e)
                {
                    MessageBox.Show("You cannot delete the followed artist list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        public void PopulateLists()
        {
            // lists combo box

            listComboBox.DataSource = b.GetLists(username);
            activeList = listComboBox.Text;

            PopulateMovies();
        }

        private void deleteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteList();
        }

        private void followArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FollowArtistForm().Show(this);
        }

        private void unfollowArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnfollowArtistForm().Show(this);
        }

        private void editMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditMovieForm().Show(this);
        }
    }
}
