using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Domain.Services.Implementations;
using System;
using System.Linq;
using System.Web.UI;

namespace StudentCrud
{
    public partial class _Default : Page
    {
        private readonly IStudentService studentService = null; 

        public _Default()
        {
            studentService = new StudentService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int studentIdCopy = 0;
            var students = studentService.GetAll().ToList();
            if (students.Count == 0)
            {
                studentIdCopy = (int)studentService.Add(new Student()
                {
                    Last_Name = "Maldonado1",
                    Middle_Name = "Flores1",
                    First_Name = "Leonardo1",
                    Gender = 1
                }).Output;
            }
            else 
            {
                studentIdCopy = students[0].Student_Id;
            }
            var student = studentService.GetBy(studentIdCopy);
            var resultTrack = studentService.Delete(student);
            var areThereStudents = studentService.GetAll().ToList();
            var existStudent = studentService.GetBy(student.Student_Id);
            var studentId = studentService.Add(new Student()
            {
                Last_Name = "Maldonado",
                Middle_Name = "Flores",
                First_Name = "Leonardo",
                Gender = 1
            });

            var updateStudent = studentService.GetBy((int)studentId.Output);
            updateStudent.Last_Name = "Maldonado";
            updateStudent.Middle_Name = "Durazo";
            updateStudent.First_Name = "Milagros";
            updateStudent.Gender = 2;

            var studentUpdateId = studentService.Update(updateStudent);
        }
    }
}