using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MamidiMovies.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace MamidiMovies.DAL
{
    public class LoginSQLDAL : ILoginDAL
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MamidiMovies"].ConnectionString;

        public LoginViewModel GetLoginInformationById(int loginId)
        {
            LoginViewModel output = new LoginViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "Select * from Login where loginId = @loginId";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@loginId", loginId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Username = Convert.ToString(reader["username"]);
                        output.Password = Convert.ToString(reader["password"]);
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

        public LoginViewModel GetUsername(string username)
        {
            LoginViewModel output = new LoginViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string queryForUsername = $"Select TOP 1 * from Login where username = @username";
                    SqlCommand command = new SqlCommand(queryForUsername, conn);
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Username = Convert.ToString(reader["username"]);
                        output.Password = Convert.ToString(reader["password"]);
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

        public LoginViewModel GetPassword(string password)
        {
            LoginViewModel output = new LoginViewModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string queryForPassword = $"Select TOP 1 * from Login where password = @password";
                    SqlCommand command = new SqlCommand(queryForPassword, conn);
                    command.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Username = Convert.ToString(reader["username"]);
                        output.Password = Convert.ToString(reader["password"]);
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

        public LoginViewModel GetUsernamePassword(string username, string password)
        {
            LoginViewModel output = new LoginViewModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string queryForUsernamePassword = $"Select TOP 1 * from Login where username = @username and password = @password";
                    SqlCommand command = new SqlCommand(queryForUsernamePassword, conn);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.LoginId = Convert.ToInt32(reader["loginId"]);
                        output.Username = Convert.ToString(reader["username"]);
                        output.Password = Convert.ToString(reader["password"]);
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

        public bool RegisterUser(LoginViewModel user)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string queryRegisterUser = $"Insert into Login values(@username, @password);";
                    conn.Open();
                    SqlCommand command = new SqlCommand(queryRegisterUser, conn);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);

                    rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                    
                }
            }
            catch(SqlException ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
    }
}