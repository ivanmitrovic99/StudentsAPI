using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Vezbanje2404.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentBusiness studentBusiness;

        public StudentController(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
        }

        [HttpGet("getall")]
        public List<Student> GetAllStudents()
        {
            return studentBusiness.GetAllStudents();

        }

        [HttpGet("getoldest")]
        public Student GetOldestStudent()
        {
            return studentBusiness.GetOldestStudent();

        }

        [HttpGet("{studentId}/getbyid")]
        public Student StudentById(int studentId)
        {
            return studentBusiness.StudentById(studentId);

        }

        [HttpPost("insert")]
        public bool InsertStudent([FromBody] Student student) {
            return studentBusiness.InsertStudent(student);
        }

        [HttpPost("{studentId}/update")]
        public bool UpdateStudent(int studentId,[FromBody] Student student)
        {
            return studentBusiness.UpdateStudent(studentId,student.name,student.age);
        }

        [HttpPost("{studentId}/delete")]
        public bool DeleteStudent(int studentId)
        {
            return studentBusiness.DeleteStudent(studentId);
        }
    }
}
