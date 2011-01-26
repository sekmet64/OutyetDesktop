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
    public partial class EditMovieForm : Form
    {
        BLL b = Program.BLL;
        MainForm p;
        private Int32 activeMovieID;
        private DataTable moviesTable;

        public EditMovieForm()
        {
            InitializeComponent();
        }

        private void EditMovieForm_Load(object sender, EventArgs e)
        {
            p = (MainForm)Owner;
            for (Int32 i = 2020; i > 1900; i--)
            {
                yearBox.Items.Add(i);
            }
            yearBox.SelectedItem = 2011;
            PopulateMovies("");
        }

        private void PopulateMovies(String filter)
        {
            moviesTable = b.GetMovies();
            moviesList.Items.Clear();
            foreach (DataRow row in moviesTable.Rows)
            {
                if (((String)row["Title"]).Contains(filter))
                {
                    moviesList.Items.Add(new MovieItem((String)row["Title"], (Int32)row["ID"]));
                    
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            PopulateMovies(searchBox.Text);
        }

        private struct MovieItem
        {
            public String title;
            public Int32 ID;
            public MovieItem(String title, Int32 ID)
            {
                this.title = title;
                this.ID = ID;
            }
            public override String ToString()
            {
                return title;
            }
        }

        private void moviesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateMovie(((MovieItem)moviesList.SelectedItem).ID);
            groupBox.Enabled = true;
        }

        private void PopulateMovie(Int32 movieID)
        {
            activeMovieID = movieID;
            DataSet movieDetails = b.GetMovieDetails(movieID);
            DataTable detailsTable = movieDetails.Tables["Details"];
            titleBox.Text = (String)detailsTable.Rows[0]["Title"];
            yearBox.Text = detailsTable.Rows[0]["Year"].ToString();
            if (detailsTable.Rows[0]["ReleaseDate"].ToString() != "")
            {
                releaseDateBox.Value = DateTime.Parse(detailsTable.Rows[0]["ReleaseDate"].ToString());
            }

            DataTable directorsTable = movieDetails.Tables["Directors"];
            directorsBox.Items.Clear();
            foreach (DataRow row in directorsTable.Rows)
            {
                directorsBox.Items.Add((String)row["Name"]);
            }

            DataTable writersTable = movieDetails.Tables["Writers"];
            writersBox.Items.Clear();
            foreach (DataRow row in writersTable.Rows)
            {
                writersBox.Items.Add((String)row["Name"]);
            }

            DataTable producersTable = movieDetails.Tables["Producers"];
            producersBox.Items.Clear();
            foreach (DataRow row in producersTable.Rows)
            {
                producersBox.Items.Add((String)row["Name"]);
            }

            DataTable castTable = movieDetails.Tables["Actors"];
            castBox.Items.Clear();
            foreach (DataRow row in castTable.Rows)
            {
                castBox.Items.Add((String)row["Name"]);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            b.UpdateMovie(activeMovieID, titleBox.Text, Int32.Parse(yearBox.Text), releaseDateBox.Value);
            PopulateMovies(searchBox.Text);
        }
    }
}
