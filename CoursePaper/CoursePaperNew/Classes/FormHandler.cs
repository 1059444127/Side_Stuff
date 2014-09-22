/* Static FormHandler class 
 * Provides basic functionality for adding, editing and deleting of elements in the database through the application */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoursePaperNew.Classes.Exceptions;
using MySql.Data.MySqlClient;

namespace CoursePaperNew.Classes
{
    public static class FormHandler
    {
        public static bool EditElement(string bookTitle, string bookEdition, long authorID, long categoryID, long bookID)
        {
            if (bookTitle.Length < 2)
            {
                throw new FailedValidationException("Book Title must be at least 2 characters long!");
            }
            else if (bookEdition.Length < 4 || bookEdition.Length > 4)
            {
                throw new FailedValidationException("Book Edition must be exactly 4 characters long.");
            }
            else
            {
                string query = String.Format("UPDATE books SET book_title = \"{0}\", book_edition = \"{1}\" WHERE book_id = {2}", bookTitle, bookEdition, bookID);
                if (DBConnector.ExecuteNonQuery(query))
                {
                    string secondQuery = String.Format("UPDATE users_books_authors_categories SET author_id = {0}, category_id = {1} WHERE book_id = {2}", authorID, categoryID, bookID);
                    if (DBConnector.ExecuteNonQuery(secondQuery))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ConnectionFailedException("Failed to edit book");
                }
            }
        }

        public static bool AddElement(long userID, string bookTitle, string bookEdition, long authorID, long categoryID)
        {
            string query = String.Format("INSERT INTO books (book_title, book_edition, date_added) VALUES(\"{0}\", \"{1}\", NOW())", bookTitle, bookEdition);
            long? book_id = DBConnector.ExecuteNonQueryAndReturnID(query);
            if (book_id != null)
            {
                string secondQuery = String.Format("INSERT INTO users_books_authors_categories (user_id, book_id, author_id, category_id) VALUES({0}, {1}, {2}, {3})", userID, book_id, authorID, categoryID);
                if (DBConnector.ExecuteNonQuery(secondQuery))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteElement(int elementID, string elementHeader, string elementBody, DateTime elementDate)
        {
            if (DBConnector.ExecuteNonQuery(String.Format("INSERT INTO archive (data_id, header, body, date_added, date_deleted) VALUES({0}, '{1}', '{2}', '{3}', NOW())", elementID, elementHeader, elementBody, elementDate.ToString("yyyy-MM-dd H:mm:ss"))))
            {
                if (DBConnector.ExecuteNonQuery(String.Format("DELETE FROM data WHERE data_id = {0}", elementID)))
                {
                    return true;
                }
                else
                {
                    throw new ConnectionFailedException("Connection Failed!");
                }
            }
            else
            {
                throw new ConnectionFailedException("Connection failed!");
            }
        }
    }
}
