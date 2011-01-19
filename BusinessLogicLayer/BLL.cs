using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Collections;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLL
    {
        private DAL d = new DAL();

        public ArrayList GetLists(String username)
        {
            return d.GetLists(username);
        }

        public DataTable GetMovies()
        {
            return d.GetMovies();
        }

        public Boolean AddMovieToList(String username, Int32 movieID, String list)
        {
            return d.AddMovieToList(username, movieID, list);
        }

        public DataTable GetListEntries(String username, String list)
        {
            return HumanReadableDates(d.GetListEntries(username, list));
        }

        public Boolean UserExists(String username)
        {
            return d.UserExists(username);
        }

        public void CreateUser(String username, String firstName, String lastName, String password)
        {
            d.CreateUser(username, firstName, lastName, password);
        }

        public Boolean CheckLogin(String username, String password)
        {
            return d.CheckLogin(username, password);
        }

        public Int32 GetUserRank(String username)
        {
            return d.GetUserRank(username);
        }

        public void AddMovieToDatabase(String title, Int32 year, DateTime releaseDate, String[] directors, String[] writers, String[] producers, String[] cast)
        {
            d.AddMovieToDatabase(title, year, releaseDate, directors, writers, producers, cast);
        }

        public Boolean CreateList(String username, String list)
        {
            return d.CreateList(username, list);
        }

        private DataTable HumanReadableDates(DataTable dataTable)
        {
            dataTable.Columns.Add(new DataColumn("Release", System.Type.GetType("System.String")));
            dataTable.Columns["Release"].SetOrdinal(1);
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime date = (DateTime)row["ReleaseDate"];
                TimeSpan span = date - DateTime.Now;

                String release;
                if (span.TotalDays < 0)
                    release = "released";
                else if (span.Days < 1)
                    release = "today";
                else if (span.TotalDays < 2)
                    release = "tomorrow";
                else if (span.TotalDays < 31)
                    release = (Int32)(span.TotalDays) + " days";
                else if (span.TotalDays < 365)
                    release = (Int32)(span.TotalDays / 31) + " months";
                else
                    release = (Int32)(span.TotalDays / 365) + " years";

                row["Release"] = release;
            }
            return dataTable;               
        }

        public DataSet GetMovieDetails(Int32 movieID)
        {
            return d.GetMovieDetails(movieID);
        }

        public void RemoveMovieFromList(String username, String list, Int32 movieID)
        {
            d.RemoveMovieFromList(username, list, movieID);
        }

        public void DeleteList(String username, String list)
        {
            d.DeleteList(username, list);
        }

        public Boolean FollowArtist(String username, String person)
        {
            return d.FollowArtist(username, person);
        }

        public Boolean UnfollowArtist(String username, String person)
        {
            return d.UnfollowArtist(username, person);
        }

        public void UpdateMovie(Int32 movieID, String title, Int32 year, DateTime releaseDate)
        {
            d.UpdateMovie(movieID, title, year, releaseDate);
        }
    }
}
