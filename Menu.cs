using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration
{
    public class Menu
    {
        StudentDetails studentDetails = new StudentDetails();
        public void StudentMenu()
        {
            {
                bool run = true;
                while (run)
                {
                    Console.WriteLine("1. Register Student");
                    Console.WriteLine("2. Remove Student Details");
                    Console.WriteLine("3. Update Student Records");
                    Console.WriteLine("4. View All Student");
                    Console.WriteLine("5. Search Student");
                    Console.WriteLine("6. Logout");
                    Console.Write("Choose:");
                    int input = int.Parse(Console.ReadLine()!);
                    switch (input)
                    {
                        case 1:
                        studentDetails.RegisterStudent();
                        break;
                        case 2:
                        studentDetails.RemoveDetais();
                        break;
                        case 3:
                        studentDetails.UpdateDetails();
                        break;
                        case 4:
                        studentDetails.ViewStudentDetails();
                        break;
                        case 5:
                        studentDetails.SearchstudentDetail();
                        break;
                        case 6:
                        run = false;
                        Console.WriteLine("Exiting The Registration Page..", ConsoleColor.Green);
                            break;
                            default:
                            Console.WriteLine("Invalid Input", ConsoleColor.Red);
                            break;
                    }
                }
            }

        }


    }
}