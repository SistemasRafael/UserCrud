using StudentCrud.Domain.Dto;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCrud
{
    public partial class ListStudent : Page
    {
        public IStudentService studentService;
        public IAddressService addressService;
        public IEmailService emailService;
        public IPhoneService phoneService;
        public IEmailTypeService emailTypeService;
        public IGenderTypeService genderTypeService;
        public IPhoneTypeService phoneTypeService;

        public ListStudent()
        {
            studentService = new StudentService();
            addressService = new AddressService();
            emailService = new EmailService();
            phoneService = new PhoneService();
            emailTypeService = new EmailTypeService();
            genderTypeService = new GenderTypeService();
            phoneTypeService = new PhoneTypeService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        void ShowFaildMessage(string errorMessage)
        {
            var sciprt = "$('#Faild-Message-Id').removeClass('d-none');" +
                         "$('#Faild-Message-Id').addClass('show'); " +
                         "$('#Faild-Message-Id').text('" + errorMessage + "');";
            ClientScript.RegisterStartupScript(GetType(), "messageFaild", sciprt, true);
        }

        void LoadGrid()
        {
            try
            {
                var table = GetAll_Student();
                GHotels.DataSource = table.ToDataTable();
                GHotels.DataBind();
            }
            catch (Exception ex)
            {
                ShowFaildMessage(ex.Message);
            }
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