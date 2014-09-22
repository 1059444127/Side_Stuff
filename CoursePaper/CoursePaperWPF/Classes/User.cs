using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoursePaperWpf
{
    public static class User
    {
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
                throw new FailedValidationException("Invalid username or password!");
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
