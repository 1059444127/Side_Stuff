using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace CoursePaperWpf
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

        private static void Initialise()
        {
            server = "localhost";
            username = "root";
            password = "";
            database = "course_paper";
            string connectionString = String.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", server, database, username, password);
            connection = new MySqlConnection(connectionString);
        }

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
                        System.Windows.MessageBox.Show("Cannot connect to server");
                        break;
                    case 1045:
                        System.Windows.MessageBox.Show("Invalid user/password, please try again");
                        break;
                    default:
                        System.Windows.MessageBox.Show("An error occured");
                        break;
                }
                return false;
            }
        }

        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void ExecuteNonQuery(string query)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
                catch(MySqlException)
                {
                    System.Windows.MessageBox.Show("Something went wrong");
                    CloseConnection();
                }
            }
        }

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
                return null;
            }
        }
    }
}
