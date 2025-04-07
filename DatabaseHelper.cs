using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace StudentRegistration
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "server=localhost;user=root;password=maulvimamun;database=StudentDB";

        public void SaveStudent(Student student)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = @"INSERT INTO Students (FullName, Grade, DateOfBirth, PhoneNumber, RegisteredAt, Gender)
                             VALUES (@FullName, @Grade, @DateOfBirth, @PhoneNumber, @RegisteredAt, @Gender)";
            using var mycmd = new MySqlCommand(query, conn);
            mycmd.Parameters.AddWithValue("@FullName", student.FullName);
            mycmd.Parameters.AddWithValue("@Grade", student.Grade);
            mycmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            mycmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            mycmd.Parameters.AddWithValue("@RegisteredAt", student.RegisteredAt);
            mycmd.Parameters.AddWithValue("@Gender", student.Gender);
            mycmd.ExecuteNonQuery();
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM Students";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    ID = reader.GetInt32("ID"),
                    FullName = reader.GetString("FullName"),
                    Grade = reader.GetString("Grade"),
                    DateOfBirth = reader.GetInt32("DateOfBirth"),
                    PhoneNumber = reader.GetString("PhoneNumber"),
                    RegisteredAt = reader.GetDateTime("RegisteredAt"),
                    Gender = reader.GetString("Gender")
                });
            }
            return students;
        }

        public void DeleteStudent(int id)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM Students WHERE ID = @ID";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStudent(int id, string newName, string newPhone)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE Students SET FullName = @Name, PhoneNumber = @Phone WHERE ID = @ID";
            using var mycmd = new MySqlCommand(query, conn);
            mycmd.Parameters.AddWithValue("@Name", newName);
            mycmd.Parameters.AddWithValue("@Phone", newPhone);
            mycmd.Parameters.AddWithValue("@ID", id);
            mycmd.ExecuteNonQuery();
        }
    }
}
