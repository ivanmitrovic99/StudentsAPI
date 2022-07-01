using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class StudentRepository : IStudentRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Student> GetAllStudents()
        {
            List<Student> listToReturn = new List<Student>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM students";
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Student student = new Student();
                    student.ID = dataReader.GetInt32(0);
                    student.name = dataReader.GetString(1);
                    student.index = dataReader.GetString(2);
                    student.age = dataReader.GetInt32(3);
                    listToReturn.Add(student);
                }
                return listToReturn;

            }
        }

        public int InsertStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO students VALUES(" + "'" + student.name + "'" + "," + "'" + student.index + "'" + "," + student.age + ")";
                return cmd.ExecuteNonQuery();
            }

        }

        public int DeleteStudent(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM students WHERE Id=" + studentId + "";
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateStudent(int studentId, string name, int age)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE students SET name=" + "'" + name + "'" + ", " + "age=" + age + "WHERE Id=" + studentId + ";";
                return cmd.ExecuteNonQuery();
            }
        }

        public Student GetOldestStudent()
        {
            List<Student> students = GetAllStudents();
            Student oldestStudent = new Student();
            int oldestAge = 0;
            foreach (Student student in students)
            {
                if (student.age > oldestAge)
                {
                    oldestAge = student.age;
                    oldestStudent = student;
                }
            }
            return oldestStudent;
        }

        public Student StudentById(int studentId)
        {
            Student student = new Student();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM students WHERE Id=" + studentId + ";";
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    
                    student.ID = dataReader.GetInt32(0);
                    student.name = dataReader.GetString(1);
                    student.index = dataReader.GetString(2);
                    student.age = dataReader.GetInt32(3);

                }
                return student;

            }

        }
    }
}

