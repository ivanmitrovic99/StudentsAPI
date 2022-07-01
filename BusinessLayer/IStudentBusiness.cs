using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IStudentBusiness
    {

        List<Student> GetAllStudents();
        bool InsertStudent(Student student);

        bool DeleteStudent(int studentId);

        Student GetOldestStudent();

        Student StudentById(int studentId);
        bool UpdateStudent(int studentId, string name, int age);
    }
}
