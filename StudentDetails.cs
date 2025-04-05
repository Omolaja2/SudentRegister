using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ConsoleTables;

namespace StudentRegistration
{

    public class StudentDetails
    {
        Student student = new Student();
        private List<Student> students = [];

        public void RegisterStudent()
        {
            Console.Write("Enter Student FullNAme: ");
            string fullname = Console.ReadLine()!;
            Console.Write("Student Class: ");
            string grade = Console.ReadLine()!;
            Console.Write("Enter Gender (M/F): ");
            string sex = Console.ReadLine()!;
            while (sex.ToLower() != "male" && sex.ToLower() != "female")
            {
                Console.Write("Invalid input. Please enter 'Male' or 'Female':");
                sex = Console.ReadLine()!;
            }
            
            Console.Write("(D.O.B) Date Of Birth (Year): ");
            int dob;


            while (!int.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Invalid input. Please enter a valid year of birth:", ConsoleColor.Red);
            }

            Console.Write("Enter Parnet/Guardiance Phone.No: ");
            string phonenumber = Console.ReadLine()!;
            if (!ValidatePhoneNumber(phonenumber))
            {
                return;
            }
            Console.Write("time Registered: ");
            DateTime registered = DateTime.Parse(Console.ReadLine()!);

            int id = students.Count > 0 ? students.Count + 1 : 1;

            Student newStundent = new Student()
            {
                FullName = fullname,
                Grade = grade,
                DateOfBirth = dob,
                ID = id,
                PhoneNumber = phonenumber,
                RegisteredAt = registered,
                Gender = sex
            };
            students.Add(newStundent);
            Console.WriteLine($"Student With Id =>{id} Registered Succesfully", ConsoleColor.Blue);
        }

        public void RemoveDetais()
        {
            Console.Write("Enter The Student Id Youre To Remove: ");
            int idinput = int.Parse(Console.ReadLine()!);
            var remove = GetById(idinput);

            if (remove == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The task you are trying to delete does not exist!");
                Console.ResetColor();
            }
            else
            {
                students.Remove(remove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Task {remove.ID} Deleted successfully!", ConsoleColor.Red);
                Console.ResetColor();
            }
        }

        public void UpdateDetails()
        {
            Console.Write("Enter The Id of The Student Details You Want To Update: ");
            int id = int.Parse(Console.ReadLine()!);
            var details = GetById(id);
            if (details == null)
            {
                Console.WriteLine("The Id You Input Does Not Exist!", ConsoleColor.Red);

            }
            else
            {
                Console.WriteLine($"Current Name : {details.FullName} || Current PhoneNumber: {details.PhoneNumber}");

                Console.Write("Enter New Student Name");
                string newName = Console.ReadLine()!;
                Console.Write("Enter New Phone Number");
                string newPhoneNumber = Console.ReadLine()!;
                if (!ValidatePhoneNumber(newPhoneNumber))
                {
                    return;
                }

                details.FullName = newName.ToString();
                details.PhoneNumber = newPhoneNumber.ToString();
                Console.WriteLine($"Details With Id{details.ID} Updated Sucesfull", ConsoleColor.Green);
            }

        }


        static bool ValidatePhoneNumber(string phone)
        {
            string phonePattern = @"^\d{11}$";
            if (!Regex.IsMatch(phone, phonePattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Phone Number Must Be Exactly 11 Digits and Cannot Contain Special Characters!");
                Console.ResetColor();
                return false;
            }
            return true;
        }


        public string ReadPassword()
        {
            string pinandpassword = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace && pinandpassword.Length > 0)
                    {

                        pinandpassword = pinandpassword.Substring(0, pinandpassword.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {

                        pinandpassword += key.KeyChar;
                        Console.Write("*");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pinandpassword;
        }

        public void ViewStudentDetails()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Student Registered Yet");

            }

            var table = new ConsoleTable("FullName", "Grade", "D.O.B", "ID", "Guardians/Phone.No", "RegisteredAt", "Gender");
            {
                foreach (var item in students)

                {
                    table.AddRow(
                   item.FullName,
                   item.Grade,
                   item.DateOfBirth,
                   item.ID,
                   item.PhoneNumber,
                   item.RegisteredAt.ToString("yyyy-MM-dd HH:mm"),
                   item.Gender
                    );

                }
            }
            table.Write();
            Console.WriteLine();
        }
        public void SearchstudentDetail()
        {
            Console.WriteLine("Input The Id of the Student ");
            int id = int.Parse(Console.ReadLine()!);
            var details = GetById(id);
            if (details == null)
            {
                Console.WriteLine("Record not found");
            }
            else
            {
                Console.WriteLine($"The Student With The Id Is ||{details.Grade} | {details.PhoneNumber}| {details.FullName}");
            }
        }
        public Student? GetById(int id)
        {
            return students.Find(x => x.ID == id);
        }

    }
}