using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursePaper
{
    public class User
    {
        private long userID;
        private string username;
        private string password;

        public long UserId
        {
            get { return this.userID; }
        }

        public string Username
        {
            get { return this.username; }
        }

        public string Password
        {
            get { return this.password; }
        }

        public User(long userID, string username, string password)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
        }

        public static bool RegisterUser(string username, string password)
        {
            if (ValidateUser(username) && ValidatePassword(password))
            {
                DataTable table = DBConnector.Select(String.Format("SELECT * FROM users WHERE username='{0}'", username));
                if (table.Rows.Count > 0)
                {
                    throw new UserExistsException("This username is already taken!");
                }
                else
                {
                    password = PasswordHash.CreateHash(password, PasswordHash.GenerateSalt());
                    DBConnector.ExecuteNonQuery(String.Format("INSERT INTO users (username, password) VALUES ('{0}', '{1}')", username, password));
                    return true;
                }
            }
            else
            {
                throw new FailedValidationException("Username or password incorrect!");
            }
        }

        public static User LoginUser(string username, string password)
        {
            if (ValidateUser(username) && ValidatePassword(password))
            {
                try
                {
                    DataTable dt = DBConnector.Select(String.Format("SELECT * FROM users WHERE username='{0}'", username));
                    object userID = dt.Rows[0][0];
                    string currentUsername = dt.Rows[0][1].ToString();
                    string currentPassword = dt.Rows[0][2].ToString();

                    long parsedUserID = long.Parse(userID.ToString());

                    if (PasswordHash.ValidatePassword(password, currentPassword))
                    {
                        return new User(parsedUserID, currentUsername, currentPassword);
                    }
                    else
                    {
                        throw new FailedValidationException("Invalid username or password!");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    throw new FailedValidationException("Invalid username or password!");
                }
            }
            else
            {
                throw new FailedValidationException("Username or password incorrect!");
            }
        }

        public static bool ValidateUser(string username)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z0-9]{4,15}";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(username);
        }

        public static bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, "(?=.{8,})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+");
        }
    }
}
