using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class StudentBusiness:IStudentBusiness
    {
        private IStudentRepository studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }


        public List<Student> GetAllStudents()
        {
            if(studentRepository.GetAllStudents().Count > 0) { return studentRepository.GetAllStudents(); }
            else { return null; }
        }

        public bool InsertStudent(Student student)
        {
            if (studentRepository.InsertStudent(student) > 0) { return true; }
            else { return false; }
        }

        public bool DeleteStudent(int studentId)
        {
            if(studentRepository.DeleteStudent(studentId)>0) { return true; }
            else { return false; }
        }

        public bool UpdateStudent(int studentId,string name,int age)
        {
            if (studentRepository.UpdateStudent(studentId,name,age) > 0) { return true; }
            else { return false; }
        }



        public Student GetOldestStudent()
        {
            if (studentRepository.GetOldestStudent() != null) { return studentRepository.GetOldestStudent(); }
            else { return null; }
        }

        public Student StudentById(int studentId)
        {
            if (studentRepository.StudentById(studentId) != null) { return studentRepository.StudentById(studentId); }
            else { return null; }
        }


    }
}
