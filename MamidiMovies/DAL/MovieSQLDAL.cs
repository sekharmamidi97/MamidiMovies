using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MamidiMovies.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace MamidiMovies.DAL
{
    public class MovieSQLDAL : IMovieDAL
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MamidiMovies"].ConnectionString;

        public bool AddMovieInformation(MoviePageViewModel movie)
        {
            int rowsAffected = 0;
            MoviePageViewModel model = new MoviePageViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string sqlQuery = $"Insert into Movie Values(@loginId, @title, @year, @isAction, @isAdventure, @isComedy, @isDocumentary, @isDrama, @isFamily, @isHistorical, @isHorror, @isMystery, @isScienceFiction, @isCartoon, @isTelevisionShow, @isOther);";
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@loginId", movie.LoginId);
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@year", movie.Year);
                    command.Parameters.AddWithValue("@isAction", 0);
                    command.Parameters.AddWithValue("@isAdventure", 0);
                    command.Parameters.AddWithValue("@isComedy", 0);
                    command.Parameters.AddWithValue("@isDocumentary", 0);
                    command.Parameters.AddWithValue("@isDrama", 0);
                    command.Parameters.AddWithValue("@isFamily", 0);
                    command.Parameters.AddWithValue("@isHistorical", 0);
                    command.Parameters.AddWithValue("@isHorror", 0);
                    command.Parameters.AddWithValue("@isMystery", 0);
                    command.Parameters.AddWithValue("@isScienceFiction", 0);
                    command.Parameters.AddWithValue("@isCartoon", 0);
                    command.Parameters.AddWithValue("@isTelevisionShow", 0);
                    command.Parameters.AddWithValue("@isOther", 0);

                    rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public MoviePageViewModel GetMovieInfoByMovieId(int movieId)
        {
            MoviePageViewModel output = new MoviePageViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "Select * from Movie where movieId = @movieId";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@movieId", movieId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.MovieId = Convert.ToInt32(reader["movieId"]);
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Title = Convert.ToString(reader["title"]);
                        output.Year = Convert.ToString(reader["year"]);
                        output.IsAction = Convert.ToBoolean(reader["isAction"]);
                        output.IsAdventure = Convert.ToBoolean(reader["isAdventure"]);
                        output.IsComedy = Convert.ToBoolean(reader["isComedy"]);
                        output.IsDocumentary = Convert.ToBoolean(reader["isDocumentary"]);
                        output.IsDrama = Convert.ToBoolean(reader["isDrama"]);
                        output.IsFamily = Convert.ToBoolean(reader["isFamily"]);
                        output.IsHistorical = Convert.ToBoolean(reader["isHistorical"]);
                        output.IsHorror = Convert.ToBoolean(reader["isHorror"]);
                        output.IsMystery = Convert.ToBoolean(reader["isMystery"]);
                        output.IsScienceFiction = Convert.ToBoolean(reader["isScienceFiction"]);
                        output.IsCartoon = Convert.ToBoolean(reader["isCartoon"]);
                        output.IsTelevisionShow = Convert.ToBoolean(reader["isTelevisionShow"]);
                        output.IsOther = Convert.ToBoolean(reader["isOther"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
                throw;
            }
            return output;
        }

        public MoviePageViewModel GetMovieByTitle(string title)
        {
            MoviePageViewModel output = new MoviePageViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string queryForTitle = $"Select TOP 1 * from Movie where title = @title";
                    SqlCommand command = new SqlCommand(queryForTitle, conn);
                    command.Parameters.AddWithValue("@title", title);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.MovieId = Convert.ToInt32(reader["movieId"]);
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Title = Convert.ToString(reader["title"]);
                        output.Year = Convert.ToString(reader["year"]);
                        output.IsAction = Convert.ToBoolean(reader["isAction"]);
                        output.IsAdventure = Convert.ToBoolean(reader["isAdventure"]);
                        output.IsComedy = Convert.ToBoolean(reader["isComedy"]);
                        output.IsDocumentary = Convert.ToBoolean(reader["isDocumentary"]);
                        output.IsDrama = Convert.ToBoolean(reader["isDrama"]);
                        output.IsFamily = Convert.ToBoolean(reader["isFamily"]);
                        output.IsHistorical = Convert.ToBoolean(reader["isHistorical"]);
                        output.IsHorror = Convert.ToBoolean(reader["isHorror"]);
                        output.IsMystery = Convert.ToBoolean(reader["isMystery"]);
                        output.IsScienceFiction = Convert.ToBoolean(reader["isScienceFiction"]);
                        output.IsCartoon = Convert.ToBoolean(reader["isCartoon"]);
                        output.IsTelevisionShow = Convert.ToBoolean(reader["isTelevisionShow"]);
                        output.IsOther = Convert.ToBoolean(reader["isOther"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
                throw;
            }
            return output;
        }
    

       

        public MoviePageViewModel GetMovieByYear(string year)
        {
            MoviePageViewModel output = new MoviePageViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string queryForYear = $"Select TOP 1 * from Movie where year = @year";
                    SqlCommand command = new SqlCommand(queryForYear, conn);
                    command.Parameters.AddWithValue("@year", year);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.MovieId = Convert.ToInt32(reader["movieId"]);
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Title = Convert.ToString(reader["title"]);
                        output.Year = Convert.ToString(reader["year"]);
                        output.IsAction = Convert.ToBoolean(reader["isAction"]);
                        output.IsAdventure = Convert.ToBoolean(reader["isAdventure"]);
                        output.IsComedy = Convert.ToBoolean(reader["isComedy"]);
                        output.IsDocumentary = Convert.ToBoolean(reader["isDocumentary"]);
                        output.IsDrama = Convert.ToBoolean(reader["isDrama"]);
                        output.IsFamily = Convert.ToBoolean(reader["isFamily"]);
                        output.IsHistorical = Convert.ToBoolean(reader["isHistorical"]);
                        output.IsHorror = Convert.ToBoolean(reader["isHorror"]);
                        output.IsMystery = Convert.ToBoolean(reader["isMystery"]);
                        output.IsScienceFiction = Convert.ToBoolean(reader["isScienceFiction"]);
                        output.IsCartoon = Convert.ToBoolean(reader["isCartoon"]);
                        output.IsTelevisionShow = Convert.ToBoolean(reader["isTelevisionShow"]);
                        output.IsOther = Convert.ToBoolean(reader["isOther"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
                throw;
            }
            return output;
        }

        public MoviePageViewModel GetMovieByTitleYear(string title, string year)
        {
            MoviePageViewModel output = new MoviePageViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string queryForTitleYear = $"Select TOP 1 * from Movie where title = @title and year = @year";
                    SqlCommand command = new SqlCommand(queryForTitleYear, conn);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@year", year);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.MovieId = Convert.ToInt32(reader["movieId"]);
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Title = Convert.ToString(reader["title"]);
                        output.Year = Convert.ToString(reader["year"]);
                        output.IsAction = Convert.ToBoolean(reader["isAction"]);
                        output.IsAdventure = Convert.ToBoolean(reader["isAdventure"]);
                        output.IsComedy = Convert.ToBoolean(reader["isComedy"]);
                        output.IsDocumentary = Convert.ToBoolean(reader["isDocumentary"]);
                        output.IsDrama = Convert.ToBoolean(reader["isDrama"]);
                        output.IsFamily = Convert.ToBoolean(reader["isFamily"]);
                        output.IsHistorical = Convert.ToBoolean(reader["isHistorical"]);
                        output.IsHorror = Convert.ToBoolean(reader["isHorror"]);
                        output.IsMystery = Convert.ToBoolean(reader["isMystery"]);
                        output.IsScienceFiction = Convert.ToBoolean(reader["isScienceFiction"]);
                        output.IsCartoon = Convert.ToBoolean(reader["isCartoon"]);
                        output.IsTelevisionShow = Convert.ToBoolean(reader["isTelevisionShow"]);
                        output.IsOther = Convert.ToBoolean(reader["isOther"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
                throw;
            }
            return output;
        }
        
    }
}