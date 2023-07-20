using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemDatabaseFirst
{
    class StudentManager
    {

        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\furka\\Desktop\\c# projelerim\\LibraryManagementSystemDatabaseFirst\\LibraryManagementSystem.mdf\";Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void AddStudent()
        {
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter student surname:");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter student department:");
            string department = Console.ReadLine();

            Console.WriteLine("Enter student phone number:");
            string phone = Console.ReadLine();

            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO Student (Name, Surname, Department, Phone) VALUES (@name, @surname, @department, @phone)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", name);
                insertCommand.Parameters.AddWithValue("@surname", surname);
                insertCommand.Parameters.AddWithValue("@department", department);
                insertCommand.Parameters.AddWithValue("@phone", phone);
                insertCommand.ExecuteNonQuery();

                Console.WriteLine("Student added!");
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

        public static void DeleteStudent()
        {
            Console.WriteLine("Enter the student ID to delete:");
            int studentID = Convert.ToInt32(Console.ReadLine());

            try
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Student WHERE ID = @id";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@id", studentID);
                deleteCommand.ExecuteNonQuery();

                Console.WriteLine("Student deleted!");
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

        public static void ViewStudentInfo()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM Student";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Student Information:");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["ID"]);
                    Console.WriteLine("Name: " + reader["Name"]);
                    Console.WriteLine("Surname: " + reader["Surname"]);
                    Console.WriteLine("Department: " + reader["Department"]);
                    Console.WriteLine("Phone: " + reader["Phone"]);
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
