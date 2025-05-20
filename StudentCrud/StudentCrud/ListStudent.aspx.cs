using StudentCrud.Domain.Dto;
using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;

namespace StudentCrud
{
    public partial class ListStudent : Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string scripts = "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/StudentService.js\"></script>";
            scripts += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/PageListStudent.js\"></script>";
            ClientScript.RegisterStartupScript(this.GetType(), "myKey", scripts, false);
        }

        [WebMethod]
        public static List<StudentDto> GetAll_Student()
        {
            var studentService = new StudentService();
            var addressService = new AddressService();
            var emailService = new EmailService();
            var phoneService = new PhoneService();

            var students = studentService.GetAll()
                                         .Select(item => item.MapToDto())
                                         .ToList();

            students.ForEach(student => {
                student.Address = addressService.GetByStudentId(student.Student_Id).MapToDto();
                student.Email = emailService.GetByStudentId(student.Student_Id).MapToDto();
                student.Phone = phoneService.GetByStudentId(student.Student_Id).MapToDto();
            });

            return students;
        }

        [WebMethod]
        public static string Delete_Student(int Student_Id)
        {
            var studentService = new StudentService();
            var addressService = new AddressService();
            var emailService = new EmailService();
            var phoneService = new PhoneService();

            var student = studentService.GetBy(Student_Id);
            var address = addressService.GetByStudentId(Student_Id);
            var email = emailService.GetByStudentId(Student_Id);
            var phone = phoneService.GetByStudentId(Student_Id);

            if(address != null)
            {
                addressService.Delete(address);
            }

            if (email != null)
            {
                emailService.Delete(email);
            }

            if (phone != null) 
            {
                phoneService.Delete(phone);
            }

            studentService.Delete(student);

            return Student_Id.ToString();
        }
    }
}