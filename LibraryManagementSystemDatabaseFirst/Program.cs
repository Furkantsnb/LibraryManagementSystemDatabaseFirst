using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystemDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Update Library Information");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("6. Borrow Book");
                Console.WriteLine("7. Return Book");
                Console.WriteLine("8. View Library Information");
                Console.WriteLine("9. View Student Information");
                Console.WriteLine("10. View Author Information");
                Console.WriteLine("0. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        LibraryManager.UpdateLibraryInfo();
                        break;
                    case 2:
                        StudentManager.AddStudent();
                        break;
                    case 3:
                        StudentManager.DeleteStudent();
                        break;
                    case 4:
                        BookManager.AddBook();
                        break;
                    case 5:
                        BookManager.DeleteBook();
                        break;
                    case 6:
                        BookManager.BorrowBook();
                        break;
                    case 7:
                        BookManager.ReturnBook();
                        break;
                    case 8:
                        LibraryManager.ViewLibraryInfo();
                        break;
                    case 9:
                        StudentManager.ViewStudentInfo();
                        break;
                    case 10:
                        BookManager.ViewAuthorInfo();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
            }
        }
    }
 }
