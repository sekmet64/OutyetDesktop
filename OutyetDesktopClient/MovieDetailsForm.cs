using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BusinessLogicLayer;


namespace OutyetDesktopClient
{
    
    public partial class MovieDetailsForm : Form
    {
        private Int32 movieID;
        private BLL b = Program.BLL;

        public MovieDetailsForm(Int32 movieID)
        {
            this.movieID = movieID;
            InitializeComponent();
        }

        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
            DataSet tables = b.GetMovieDetails(movieID);
            DataTable detailsTable = tables.Tables["Details"];
            this.Text = (String)detailsTable.Rows[0]["Title"];
            richTextBox.Text += "Title:\t" + detailsTable.Rows[0]["Title"] + '\n';
            richTextBox.Text += "Year:\t" + detailsTable.Rows[0]["Year"] + '\n';
            richTextBox.Text += "Release date:\t" + ((DateTime)detailsTable.Rows[0]["ReleaseDate"]).ToShortDateString() + '\n';

            DataTable directorsTable = tables.Tables["Directors"];
            richTextBox.Text += "Directors:\n";
            foreach (DataRow row in directorsTable.Rows)
            {
                richTextBox.Text += '\t' + (String)row["Name"] + '\n';
            }

            DataTable producersTable = tables.Tables["Producers"];
            richTextBox.Text += "Producers:\n";
            foreach (DataRow row in producersTable.Rows)
            {
                richTextBox.Text += '\t' + (String)row["Name"] + '\n';
            }

            DataTable writersTable = tables.Tables["Writers"];
            richTextBox.Text += "Writers:\n";
            foreach (DataRow row in writersTable.Rows)
            {
                richTextBox.Text += '\t' + (String)row["Name"] + '\n';
            }

            DataTable actorsTable = tables.Tables["Actors"];
            richTextBox.Text += "Cast:\n";
            foreach (DataRow row in actorsTable.Rows)
            {
                richTextBox.Text += '\t' + (String)row["Name"] + '\n';
            }
        }
    }
}
