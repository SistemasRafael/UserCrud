using StudentCrud.Domain.Dto;
using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCrud
{
    public partial class ListStudent : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        void LoadGrid()
        {
            var table = GetAll_Student();
            GHotels.DataSource = table.ToDataTable();
            GHotels.DataBind();
        }

        protected void gdview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int student_Id = int.Parse(GHotels.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect($"AddStudent.aspx?Student_Id={student_Id}");
        }

        protected void CustomersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int student_Id = int.Parse(GHotels.DataKeys[e.RowIndex].Value.ToString());
            Delete_Student(student_Id);
            LoadGrid();
        }

        List<StudentDto> GetAll_Student()
        {
            var studentService = new StudentService();
            var addressService = new AddressService();
            var emailService = new EmailService();
            var emailTypeService = new EmailTypeService();
            var genderTypeService = new GenderTypeService();
            var phoneService = new PhoneService();
            var phoneTypeService = new PhoneTypeService();

            var students = studentService.GetAll()
                                         .Select(item => item.MapToDto())
                                         .ToList();

            students.ForEach(student => {
                student.GenderType = genderTypeService.GetBy(student.Gender).MapToDto() ?? new GenderTypeDto();
                student.Address = addressService.GetByStudentId(student.Student_Id).MapToDto() ?? new AddressDto();
                student.Email = emailService.GetByStudentId(student.Student_Id).MapToDto() ?? new EmailDto();
                student.Email.EmailType = emailTypeService.GetBy(student.Email.Email_Type).MapToDto() ?? new EmailTypeDto();
                student.Phone = phoneService.GetByStudentId(student.Student_Id).MapToDto() ?? new PhoneDto();
                student.Phone.PhoneType = phoneTypeService.GetBy(student.Phone.Phone_Type).MapToDto() ?? new PhoneTypeDto();
            });

            return students;
        }

        int Delete_Student(int Student_Id)
        {
            var studentService = new StudentService();
            var addressService = new AddressService();
            var emailService = new EmailService();
            var phoneService = new PhoneService();

            var student = studentService.GetBy(Student_Id);
            var address = addressService.GetByStudentId(Student_Id);
            var email = emailService.GetByStudentId(Student_Id);
            var phone = phoneService.GetByStudentId(Student_Id);

            if (address != null)
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

            return Student_Id;
        }
    }
}