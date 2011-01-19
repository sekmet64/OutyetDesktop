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
    public partial class AddMovie : Form
    {
        private String searchTerm;

        private BLL b = Program.BLL;

        public AddMovie()
        {
            InitializeComponent();
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchTerm = searchBox.Text.Trim();
            if (searchTerm.Length > 0)
            {
                dataGridView.Visible = true;
                getMoviesBindingSource.Filter = "Title LIKE '*" + searchTerm + "*'";
                getMoviesTableAdapter.Fill(this.outyetDataSet.GetMovies);
                if (getMoviesBindingSource.Count == 0)
                {
                    NoResults();
                }
                else
                {
                    ResultsOK();
                }
            }
            else
            {
                NoSearchTerm();
            }
        }


        private void NoResults()
        {
            statusLabel.Visible = true;
            dataGridView.Visible = false;
            statusLabel.Text = "Your search - " + searchTerm + "- did not match any movies.";
        }

        private void ResultsOK()
        {
            statusLabel.Visible = false;
            dataGridView.Visible = true;
        }

        private void NoSearchTerm()
        {
            statusLabel.Visible = true;
            dataGridView.Visible = false;
            statusLabel.Text = "Please enter movie title in the search box.";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int movieID = (int)dataGridView.SelectedRows[0].Cells[0].Value;
            MainForm p = (MainForm)Owner;
            String username = p.Username;
            String list = p.ActiveList;
            if (b.AddMovieToList(username, movieID, list))
            {
                p.PopulateMovies();
                this.Close();
            }
            else
            {
                MessageBox.Show("This movie is already added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
                new MovieDetailsForm((Int32)dataGridView.Rows[e.RowIndex].Cells[0].Value).Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
