using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemDatabaseFirst
{
    class LibraryManager
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\furka\\Desktop\\c# projelerim\\LibraryManagementSystemDatabaseFirst\\LibraryManagementSystem.mdf\";Integrated Security=True";

        static SqlConnection connection = new SqlConnection(connectionString);

        public static void UpdateLibraryInfo()
        {
            Console.WriteLine("Enter the new library name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the new address:");
            string newAddress = Console.ReadLine();

            Console.WriteLine("Enter the new phone number:");
            string newPhone = Console.ReadLine();

            try
            {
                connection.Open();

                string updateQuery = "UPDATE Library SET Name = @name, Address = @address, Phone = @phone";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@name", newName);
                updateCommand.Parameters.AddWithValue("@address", newAddress);
                updateCommand.Parameters.AddWithValue("@phone", newPhone);
                updateCommand.ExecuteNonQuery();

                Console.WriteLine("Library information updated!");
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

        public static void ViewLibraryInfo()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM Library";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Library Information:");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["ID"]);
                    Console.WriteLine("Name: " + reader["Name"]);
                    Console.WriteLine("Address: " + reader["Address"]);
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

