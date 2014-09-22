/* A simple Class that connects to the database and executes a query.
 * Database connection string are located in App.config
 * Implements MySQL query protection from SQL injection */


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using CoursePaperNew.Classes.Exceptions;

namespace CoursePaperNew.Classes
{
    public static class DBConnector
    {
        private static MySqlConnection connection;
        private static string server;
        private static string username;
        private static string password;
        private static string database;

        static DBConnector()
        {
            Initialise();
        }

        // Initialise database connection
        private static void Initialise()
        {
            server = ConfigurationManager.AppSettings["DatabaseServer"];
            username = ConfigurationManager.AppSettings["DatabaseUsername"];
            password = ConfigurationManager.AppSettings["DatabasePassword"];
            database = ConfigurationManager.AppSettings["DatabaseDB"];
            string connectionString = String.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", server, database, username, password);
            connection = new MySqlConnection(connectionString);
        }

        // Open connection to the database server
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid user/password, please try again");
                        break;
                    default:
                        MessageBox.Show("An error occured");
                        break;
                }
                return false;
            }
        }

        // Close connection to the database server
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool ExecuteStoredProcedure(string procedure, List<MySqlParameter> parameters)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(procedure, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (MySqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                try
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    CloseConnection();
                    return false;
                }
            }
            else
            {
                throw new ConnectionFailedException("Failed to connect to database!");
            }
        }

        public static DataTable ExecuteStoredProcedureReturnTable(string procedure, List<MySqlParameter> parameters)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(procedure, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                foreach (MySqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                try
                {
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        CloseConnection();
                        return dt;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    CloseConnection();
                    return null;
                }
            }
            else
            {
                throw new ConnectionFailedException("Failed to connect to database!");
            }
        }

        // A method that executes INSERT, DELETE, or UPDATE queries
        public static bool ExecuteNonQuery(string query, List<MySqlParameter> parameters = null)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (parameters != null)
                {
                    foreach (MySqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                try
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Something went wrong");
                    CloseConnection();
                    return false;
                }
            }
            else
            {
                throw new ConnectionFailedException("Failed to connect to database!");
            }
        }

        public static long? ExecuteNonQueryAndReturnID(string Query, List<MySqlParameter> parameters = null)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                if (parameters != null)
                {
                    foreach (MySqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                try
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return cmd.LastInsertedId;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Something went wrong");
                    CloseConnection();
                    return null;
                }
            }
            else
            {
                throw new ConnectionFailedException("Failed to connect to database!");
            }
        }

        // A method that executes queries with return objects
         public static DataTable Select(string query)
        {
            if (OpenConnection() == true)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "users");
                DataTable dt = ds.Tables["users"];
                CloseConnection();
                return dt;
            }
            else
            {
                CloseConnection();
                throw new ConnectionFailedException("Failed to connect to database!");
            }
        }
    }
}
