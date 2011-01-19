using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DataAccessLayer
{
    public class DAL
    {
        private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        private SqlConnection conn;

        public DAL()
        {
            builder.DataSource = @"CSONGI-LAPTOP\SQLEXPRESS";
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "outyet";
            conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
        }

        public ArrayList GetLists(String username)
        {
            SqlCommand command = CreateStoredProcedureCommand("GetLists");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlDataReader reader = command.ExecuteReader();
            
            ArrayList lists = new ArrayList();
            while (reader.Read())
            {
                lists.Add(reader.GetString(0));
            }
            reader.Close();

            return lists;
        }

        public DataTable GetMovies()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = CreateStoredProcedureCommand("GetMovies");

            adapter.SelectCommand = command;

            DataTable dataTable = new DataTable("Movies");
            adapter.Fill(dataTable);

            return dataTable;
        }

        public SqlCommand CreateStoredProcedureCommand(String commandText)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            return command;
        }

        public Boolean AddMovieToList(String username, int movieID, String list)
        {
            SqlCommand command = CreateStoredProcedureCommand("AddMovieToList");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pMovieID = new SqlParameter("@movieID", SqlDbType.Int);
            pMovieID.Direction = ParameterDirection.Input;
            pMovieID.Value = movieID;
            command.Parameters.Add(pMovieID);

            SqlParameter pList = new SqlParameter("@list", SqlDbType.VarChar, 50);
            pList.Direction = ParameterDirection.Input;
            pList.Value = list;
            command.Parameters.Add(pList);
            
            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();
            int retval = (int)command.Parameters["@retval"].Value;
            return retval > 0;  
        }

        public DataTable GetListEntries(String username, String list)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = CreateStoredProcedureCommand("GetListEntries");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pList = new SqlParameter("@list", SqlDbType.VarChar, 50);
            pList.Direction = ParameterDirection.Input;
            pList.Value = list;
            command.Parameters.Add(pList);

            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;            
        }

        public Boolean UserExists(String username)
        {
            SqlCommand command = CreateStoredProcedureCommand("UserExists");
            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();
            int retval = (int)command.Parameters["@retval"].Value;
            return retval > 0;
        }

        public void CreateUser(String username, String firstName, String lastName, String password)
        {
            SqlCommand command = CreateStoredProcedureCommand("CreateUser");
            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pFirstName = new SqlParameter("@firstName", SqlDbType.VarChar, 50);
            pFirstName.Direction = ParameterDirection.Input;
            pFirstName.Value = firstName;
            command.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter("@lastName", SqlDbType.VarChar, 50);
            pLastName.Direction = ParameterDirection.Input;
            pLastName.Value = lastName;
            command.Parameters.Add(pLastName);

            SqlParameter pPassword = new SqlParameter("@password", SqlDbType.VarChar, 50);
            pPassword.Direction = ParameterDirection.Input;
            pPassword.Value = password;
            command.Parameters.Add(pPassword);

            command.ExecuteNonQuery();
        }

        public Boolean CheckLogin(String username, String password)
        {
            SqlCommand command = CreateStoredProcedureCommand("CheckLogin");
            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pPassword = new SqlParameter("@password", SqlDbType.VarChar, 50);
            pPassword.Direction = ParameterDirection.Input;
            pPassword.Value = password;
            command.Parameters.Add(pPassword);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();

            int retval = (int)command.Parameters["@retval"].Value;
            return retval > 0;
        }

        public Int32 GetUserRank(String username)
        {
            SqlCommand command = CreateStoredProcedureCommand("GetUserRank");
            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();

            int retval = (int)command.Parameters["@retval"].Value;
            return retval;
        }

        public void AddMovieToDatabase(String title, int year, DateTime releaseDate, String[] directors, String[] writers, String[] producers, String[] cast)
        {
            // add the movie
            SqlCommand command = CreateStoredProcedureCommand("AddMovieToDatabase");

            SqlParameter pTitle = new SqlParameter("@title", SqlDbType.VarChar, 50);
            pTitle.Direction = ParameterDirection.Input;
            pTitle.Value = title;
            command.Parameters.Add(pTitle);

            SqlParameter pYear = new SqlParameter("@year", SqlDbType.Int);
            pYear.Direction = ParameterDirection.Input;
            pYear.Value = year;
            command.Parameters.Add(pYear);

            SqlParameter pReleaseDate = new SqlParameter("@releaseDate", SqlDbType.Date);
            pReleaseDate.Direction = ParameterDirection.Input;
            pReleaseDate.Value = releaseDate;
            command.Parameters.Add(pReleaseDate);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();

            int retval = (int)command.Parameters["@retval"].Value;

            int movieID = retval;

            // directors

            foreach (String director in directors)
            {
                SqlCommand command2 = CreateStoredProcedureCommand("AddDirectorToMovie");

                SqlParameter pDirector = new SqlParameter("@director", SqlDbType.VarChar, 50);
                pDirector.Direction = ParameterDirection.Input;
                pDirector.Value = director;
                command2.Parameters.Add(pDirector);

                SqlParameter pMovieID = new SqlParameter("movieID", SqlDbType.Int);
                pMovieID.Direction = ParameterDirection.Input;
                pMovieID.Value = movieID;
                command2.Parameters.Add(pMovieID);

                command2.ExecuteNonQuery();
            }

            // writers

            foreach (String writer in writers)
            {
                SqlCommand command2 = CreateStoredProcedureCommand("AddWriterToMovie");

                SqlParameter pWriter = new SqlParameter("@writer", SqlDbType.VarChar, 50);
                pWriter.Direction = ParameterDirection.Input;
                pWriter.Value = writer;
                command2.Parameters.Add(pWriter);

                SqlParameter pMovieID = new SqlParameter("movieID", SqlDbType.Int);
                pMovieID.Direction = ParameterDirection.Input;
                pMovieID.Value = movieID;
                command2.Parameters.Add(pMovieID);

                command2.ExecuteNonQuery();
            }

            // producers

            foreach (String producer in producers)
            {
                SqlCommand command2 = CreateStoredProcedureCommand("AddProducerToMovie");

                SqlParameter pProducer = new SqlParameter("@producer", SqlDbType.VarChar, 50);
                pProducer.Direction = ParameterDirection.Input;
                pProducer.Value = producer;
                command2.Parameters.Add(pProducer);

                SqlParameter pMovieID = new SqlParameter("movieID", SqlDbType.Int);
                pMovieID.Direction = ParameterDirection.Input;
                pMovieID.Value = movieID;
                command2.Parameters.Add(pMovieID);

                command2.ExecuteNonQuery();
            }

            // cast

            foreach (String actor in cast)
            {
                SqlCommand command2 = CreateStoredProcedureCommand("AddActorToMovie");

                SqlParameter pActor = new SqlParameter("@actor", SqlDbType.VarChar, 50);
                pActor.Direction = ParameterDirection.Input;
                pActor.Value = actor;
                command2.Parameters.Add(pActor);

                SqlParameter pMovieID = new SqlParameter("movieID", SqlDbType.Int);
                pMovieID.Direction = ParameterDirection.Input;
                pMovieID.Value = movieID;
                command2.Parameters.Add(pMovieID);

                command2.ExecuteNonQuery();
            }
        }

        public Boolean CreateList(string username, string list)
        {
            SqlCommand command = CreateStoredProcedureCommand("CreateList");
            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pList = new SqlParameter("@list", SqlDbType.VarChar, 50);
            pList.Direction = ParameterDirection.Input;
            pList.Value = list;
            command.Parameters.Add(pList);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();

            int retval = (int)command.Parameters["@retval"].Value;
            return retval > 0;
        }

        public DataSet GetMovieDetails(int movieID)
        {
            DataSet dataSet = new DataSet("MovieDetails");
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            // Movie details

            SqlCommand command = CreateStoredProcedureCommand("GetMovieDetails");

            SqlParameter pMovieID = new SqlParameter("@movieID", SqlDbType.Int);
            pMovieID.Direction = ParameterDirection.Input;
            pMovieID.Value = movieID;
            command.Parameters.Add(pMovieID);
            
            DataTable detailsTable = new DataTable("Details");
            adapter.SelectCommand = command;
            adapter.Fill(detailsTable);
            dataSet.Tables.Add(detailsTable);

            // Directors
            command.CommandText = "GetDirectorsForMovie";

            DataTable directorsTable = new DataTable("Directors");
            adapter.Fill(directorsTable);
            dataSet.Tables.Add(directorsTable);
            
            // Writers
            command.CommandText = "GetWritersForMovie";

            DataTable writersTable = new DataTable("Writers");
            adapter.Fill(writersTable);
            dataSet.Tables.Add(writersTable);

            // Producers
            command.CommandText = "GetProducersForMovie";

            DataTable producersTable = new DataTable("Producers");
            adapter.Fill(producersTable);
            dataSet.Tables.Add(producersTable);

            // Actors
            command.CommandText = "GetActorsForMovie";

            DataTable actorsTable = new DataTable("Actors");
            adapter.Fill(actorsTable);
            dataSet.Tables.Add(actorsTable);

            return dataSet;
        }

        public void RemoveMovieFromList(string username, string list, int movieID)
        {
            SqlCommand command = CreateStoredProcedureCommand("RemoveMovieFromList");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pList = new SqlParameter("@list", SqlDbType.VarChar, 50);
            pList.Direction = ParameterDirection.Input;
            pList.Value = list;
            command.Parameters.Add(pList);

            SqlParameter pMovieID = new SqlParameter("@movieID", SqlDbType.Int);
            pMovieID.Direction = ParameterDirection.Input;
            pMovieID.Value = movieID;
            command.Parameters.Add(pMovieID);

            command.ExecuteNonQuery();
        }

        public void DeleteList(string username, string list)
        {
            SqlCommand command = CreateStoredProcedureCommand("DeleteList");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pList = new SqlParameter("@list", SqlDbType.VarChar, 50);
            pList.Direction = ParameterDirection.Input;
            pList.Value = list;
            command.Parameters.Add(pList);

            command.ExecuteNonQuery();
        }

        public Boolean FollowArtist(string username, string person)
        {
            SqlCommand command = CreateStoredProcedureCommand("FollowArtist");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pPerson = new SqlParameter("@person", SqlDbType.VarChar, 50);
            pPerson.Direction = ParameterDirection.Input;
            pPerson.Value = person;
            command.Parameters.Add(pPerson);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();

            int retval = (int)command.Parameters["@retval"].Value;
            return retval > 0;
        }

        public bool UnfollowArtist(string username, string person)
        {
            SqlCommand command = CreateStoredProcedureCommand("UnfollowArtist");

            SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = username;
            command.Parameters.Add(pUsername);

            SqlParameter pPerson = new SqlParameter("@person", SqlDbType.VarChar, 50);
            pPerson.Direction = ParameterDirection.Input;
            pPerson.Value = person;
            command.Parameters.Add(pPerson);

            SqlParameter pRetVal = new SqlParameter("@retval", SqlDbType.Int);
            pRetVal.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(pRetVal);

            command.ExecuteNonQuery();

            int retval = (int)command.Parameters["@retval"].Value;
            return retval > 0;
        }

        public void UpdateMovie(int movieID, string title, int year, DateTime releaseDate)
        {
            SqlCommand command = CreateStoredProcedureCommand("UpdateMovie");

            SqlParameter pMovieID = new SqlParameter("@movieID", SqlDbType.Int);
            pMovieID.Direction = ParameterDirection.Input;
            pMovieID.Value = movieID;
            command.Parameters.Add(pMovieID);

            SqlParameter pTitle = new SqlParameter("@title", SqlDbType.VarChar, 50);
            pTitle.Direction = ParameterDirection.Input;
            pTitle.Value = title;
            command.Parameters.Add(pTitle);

            SqlParameter pYear = new SqlParameter("@year", SqlDbType.Int);
            pYear.Direction = ParameterDirection.Input;
            pYear.Value = year;
            command.Parameters.Add(pYear);

            SqlParameter pReleaseDate = new SqlParameter("@releaseDate", SqlDbType.Date);
            pReleaseDate.Direction = ParameterDirection.Input;
            pReleaseDate.Value = releaseDate;
            command.Parameters.Add(pReleaseDate);

            command.ExecuteNonQuery();
        }
    }
}
