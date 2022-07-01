using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        int InsertStudent(Student student);

        int DeleteStudent(int studentId);
        Student StudentById(int studentId);
        int UpdateStudent(int studentId,string name,int age);
        Student GetOldestStudent();
    }
}
