using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemDatabaseFirst
{
     class BookManager
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\furka\\Desktop\\c# projelerim\\LibraryManagementSystemDatabaseFirst\\LibraryManagementSystem.mdf\";Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void AddBook()
        {
            Console.WriteLine("Enter book name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter author ID:");
            int authorID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter category ID:");
            int categoryID = Convert.ToInt32(Console.ReadLine());

            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO Book (Name, AuthorID, CategoryID) VALUES (@name, @authorID, @categoryID)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", name);
                insertCommand.Parameters.AddWithValue("@authorID", authorID);
                insertCommand.Parameters.AddWithValue("@categoryID", categoryID);
                insertCommand.ExecuteNonQuery();

                Console.WriteLine("Book added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void DeleteBook()
        {
            Console.WriteLine("Enter the book ID to delete:");
            int bookID = Convert.ToInt32(Console.ReadLine());

            try
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Book WHERE ID = @id";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@id", bookID);
                deleteCommand.ExecuteNonQuery();

                Console.WriteLine("Book deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void BorrowBook()
        {
            Console.WriteLine("Enter the book ID to borrow:");
            int bookID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the student ID to borrow the book:");
            int studentID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the borrowing date (yyyy-MM-dd):");
            string borrowingDate = Console.ReadLine();

            Console.WriteLine("Enter the return date (yyyy-MM-dd):");
            string returnDate = Console.ReadLine();

            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO Borrowing (BookID, StudentID, BorrowingDate, ReturnDate) VALUES (@bookID, @studentID, @borrowingDate, @returnDate)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@bookID", bookID);
                insertCommand.Parameters.AddWithValue("@studentID", studentID);
                insertCommand.Parameters.AddWithValue("@borrowingDate", borrowingDate);
                insertCommand.Parameters.AddWithValue("@returnDate", returnDate);
                insertCommand.ExecuteNonQuery();

                Console.WriteLine("Book borrowed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ReturnBook()
        {
            Console.WriteLine("Enter the book ID to return:");
            int bookID = Convert.ToInt32(Console.ReadLine());

            try
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Borrowing WHERE BookID = @bookID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@bookID", bookID);
                deleteCommand.ExecuteNonQuery();

                Console.WriteLine("Book returned!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ViewAuthorInfo()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM Author";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Author Information:");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["ID"]);
                    Console.WriteLine("Name: " + reader["Name"]);
                    Console.WriteLine("Birth Date: " + reader["BirthDate"]);
                    Console.WriteLine("Country: " + reader["Country"]);
                    Console.WriteLine();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
