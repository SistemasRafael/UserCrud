using StudentCrud.Domain.Dto;
using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCrud
{
    public partial class AddStudent : Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComboGender();
                LoadComboStates();
                LoadComboCities();
                LoadComboEmailType();
                LoadComboPhoneType();

                if(!GetStudentId().Equals(0))
                {
                    TituloId.Text = "Edit Student";
                    BtnAdd.Visible = false;
                    BtnUpdate.Visible = true;
                    BtnAddNew.Visible = true;
                    SetValuesToParameters();
                }
            }
        }

        int GetStudentId()
        {
            var queryStringStudentId = Request.QueryString["Student_Id"];
            if (queryStringStudentId != null)
            {
                return int.Parse(queryStringStudentId.ToString());
            }

            return 0;
        }

        void SetValuesToParameters()
        {
            var student = GetStudent();
            FirstNameId.Text = student.First_Name;
            LastNameId.Text = student.Last_Name;
            MiddleNameId.Text = student.Middle_Name;
            GenderId.SelectedValue = student.Gender.ToString();

            if (student.Address != null)
            {
                AddressId.Text = student.Address.Address_Line;
                CityId.SelectedValue = student.Address.City;
                ZipCodeId.Text = student.Address.Zip_Codepost;
                StateId.SelectedValue = student.Address.State;
            }

            if (student.Email != null)
            {
                EmailId.Text = student.Email.Email_Name;
                TypeEmailId.SelectedValue = student.Email.Email_Type.ToString();
            }

            if (student.Phone != null)
            {
                PhoneNumberId.Text = student.Phone.Phone_Number;
                PhoneTypeId.SelectedValue = student.Phone.Phone_Type.ToString();
                CountryCodeId.Text = student.Phone.Country_Code;
                AreaCodeId.Text = student.Phone.Area_Code;
            }
        }

        StudentDto GetStudent()
        {
            var studentService = new StudentService();
            var addressService = new AddressService();
            var emailService = new EmailService();
            var phoneService = new PhoneService();

            var student = studentService.GetBy(GetStudentId()).MapToDto();
            student.Address = addressService.GetByStudentId(student.Student_Id).MapToDto() ?? new AddressDto();
            student.Email = emailService.GetByStudentId(student.Student_Id).MapToDto() ?? new EmailDto();
            student.Phone = phoneService.GetByStudentId(student.Student_Id).MapToDto() ?? new PhoneDto();

            return student;
        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AddStudentData();
                ShowSuccessMessage();
            }
        }

        protected void BtnAddNewClick(object sender, EventArgs e)
        {
            Response.Redirect("AddStudent.aspx");
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UpdateStudentData();
                ShowSuccessMessage();
            }
        }

        void ShowSuccessMessage()
        {
            var sciprt = "$('#Success-Message-Id').removeClass('d-none');" +
                         "$('#Success-Message-Id').addClass('show'); " +
                         "setTimeout(function () { $('#Success-Message-Id').hide(); }, 4000);";
            ClientScript.RegisterStartupScript(GetType(), "messageSuccess", sciprt, true);
        }

        void UpdateStudentData()
        {
            try
            {
                Update_Student(new StudentUpdateParameters()
                {
                    Student_Id = GetStudentId(),
                    First_Name = FirstNameId.Text,
                    Last_Name = LastNameId.Text,
                    Middle_Name = MiddleNameId.Text,
                    Gender = int.Parse(GenderId.SelectedValue)
                });

                var _addressService = new AddressService();
                var _addres = _addressService.GetByStudentId(GetStudentId());
                Update_Address(new AddressUpdateParameters()
                {
                    Address_Id = _addres.Address_Id,
                    Address_Line = AddressId.Text,
                    City = CityId.SelectedValue,
                    Zip_Codepost = ZipCodeId.Text,
                    State = StateId.SelectedValue,
                });

                Update_Email(new EmailUpdateParameters()
                {
                    Student_Id = GetStudentId(),
                    Email_Name = EmailId.Text,
                    Email_Type = int.Parse(TypeEmailId.SelectedValue)
                });

                var _phoneService = new PhoneService();
                var _phone = _phoneService.GetByStudentId(GetStudentId());
                Update_Phone(new PhoneUpdateParameters()
                {
                    Phone_Id = _phone.Phone_Id,
                    Phone_Number = PhoneNumberId.Text,
                    Phone_Type = int.Parse(PhoneTypeId.SelectedValue),
                    Country_Code = CountryCodeId.Text,
                    Area_Code = AreaCodeId.Text,
                });
            }
            catch (Exception ex)
            {

            }
        }

        void AddStudentData()
        {
            try
            {
                var _student_Id = Add_Student(new StudentAddParameters()
                {
                    First_Name = FirstNameId.Text,
                    Last_Name = LastNameId.Text,
                    Middle_Name = MiddleNameId.Text,
                    Gender = int.Parse(GenderId.SelectedValue)
                });

                Add_Address(new AddressAddParameters()
                {
                    Student_Id = _student_Id,
                    Address_Line = AddressId.Text,
                    City = CityId.SelectedValue,
                    Zip_Codepost = ZipCodeId.Text,
                    State = StateId.SelectedValue,
                });

                Add_Email(new EmailAddParameters()
                {
                    Student_Id = _student_Id,
                    Email_Name = EmailId.Text,
                    Email_Type = int.Parse(TypeEmailId.SelectedValue)
                });

                Add_Phone(new PhoneAddParameters()
                {
                    Student_Id = _student_Id,
                    Phone_Number = PhoneNumberId.Text,
                    Phone_Type = int.Parse(PhoneTypeId.SelectedValue),
                    Country_Code = CountryCodeId.Text,
                    Area_Code = AreaCodeId.Text,
                });

                ClearForm();
            }
            catch (Exception ex)
            {

            }
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            ClearForm();
        }

        void ClearForm()
        {
            FirstNameId.Text = string.Empty;
            LastNameId.Text = string.Empty;
            MiddleNameId.Text = string.Empty;
            GenderId.SelectedValue = "0";
            AddressId.Text = string.Empty;
            CityId.SelectedValue = "0";
            ZipCodeId.Text = string.Empty;
            StateId.SelectedValue = "0";
            EmailId.Text = string.Empty;
            TypeEmailId.SelectedValue = "0";
            PhoneNumberId.Text = string.Empty;
            PhoneTypeId.SelectedValue = "0";
            CountryCodeId.Text = string.Empty;
            AreaCodeId.Text = string.Empty;
            //TituloId.Text = "Add Student";
            //BtnSave.Text = "Add";
            //Student_Id = 0;
        }

        protected void Page_LoadComplete()
        {
            string myScript2 = "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/StudentService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/AddressService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/EmailService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/PhoneService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/PageAddStudent.js\"></script>";
            ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript2, false);
        }

        void LoadComboGender()
        {
            List<string> genders = new List<string>() {
                "Select option",
                "Male",
                "Female"
            };

            int index = 0;
            genders.ForEach(gender =>
            {
                ListItem item = new ListItem();
                item.Text = gender;
                item.Value = index.ToString();
                GenderId.Items.Add(item);
                index++;
            });
        }

        void LoadComboStates()
        {
            List<string> states = new List<string>() {
                "Select option",
                "Sonora",
                "Sinaloa"
            };

            int index = 0;
            states.ForEach(gender =>
            {
                ListItem item = new ListItem();
                item.Text = gender;
                item.Value = index.ToString();
                StateId.Items.Add(item);
                index++;
            });
        }

        void LoadComboCities()
        {
            List<string> cities = new List<string>() {
                "Select option",
                "Hermosillo",
                "Obregon"
            };

            int index = 0;
            cities.ForEach(gender =>
            {
                ListItem item = new ListItem();
                item.Text = gender;
                item.Value = index.ToString();
                CityId.Items.Add(item);
                index++;
            });
        }

        void LoadComboEmailType()
        {
            List<string> emailTypes = new List<string>() {
                "Select option",
                "Gmail",
                "Hotmail"
            };

            int index = 0;
            emailTypes.ForEach(gender =>
            {
                ListItem item = new ListItem();
                item.Text = gender;
                item.Value = index.ToString();
                TypeEmailId.Items.Add(item);
                index++;
            });
        }

        void LoadComboPhoneType()
        {
            List<string> phoneTypes = new List<string>() {
                "Select option",
                "Phone",
                "Cell phone"
            };

            int index = 0;
            phoneTypes.ForEach(gender =>
            {
                ListItem item = new ListItem();
                item.Text = gender;
                item.Value = index.ToString();
                PhoneTypeId.Items.Add(item);
                index++;
            });
        }

        int Add_Student(StudentAddParameters student)
        {
            var studentService = new StudentService();
            var _student = student.MapToModel();

            var resultTrack = studentService.Add(_student);
            if (!resultTrack.HasError)
            {
                return (int)resultTrack.Output;
            }

            return -1;
        }

        int Add_Address(AddressAddParameters address)
        {
            var addressService = new AddressService();
            var _address = address.MapToModel();

            var resultTrack = addressService.Add(_address);
            if (!resultTrack.HasError)
            {
                return (int)resultTrack.Output;
            }

            return -1;
        }

        string Add_Email(EmailAddParameters email)
        {
            var emailService = new EmailService();
            var _email = email.MapToModel();

            var resultTrack = emailService.Add(_email);
            if (!resultTrack.HasError)
            {
                return resultTrack.Output.ToString();
            }

            return string.Empty;
        }

        int Add_Phone(PhoneAddParameters phone)
        {
            var phoneService = new PhoneService();
            var _phone = phone.MapToModel();

            var resultTrack = phoneService.Add(_phone);
            if (!resultTrack.HasError)
            {
                return (int)resultTrack.Output;
            }

            return -1;
        }

        int Update_Student(StudentUpdateParameters student)
        {
            var studentService = new StudentService();
            var _student = student.MapToModel();

            var resultTrack = studentService.Update(_student);
            if (!resultTrack.HasError)
            {
                return (int)resultTrack.Output;
            }

            return -1;
        }

        int Update_Address(AddressUpdateParameters address)
        {
            var addressService = new AddressService();
            var _address = address.MapToModel();

            var resultTrack = addressService.Update(_address);
            if (!resultTrack.HasError)
            {
                return (int)resultTrack.Output;
            }

            return -1;
        }

        string Update_Email(EmailUpdateParameters email)
        {
            var emailService = new EmailService();
            var _email = email.MapToModel();

            var resultTrack = emailService.Update(_email);
            if (!resultTrack.HasError)
            {
                return resultTrack.Output.ToString();
            }

            return string.Empty;
        }

        int Update_Phone(PhoneUpdateParameters phone)
        {
            var phoneService = new PhoneService();
            var _phone = phone.MapToModel();

            var resultTrack = phoneService.Update(_phone);
            if (!resultTrack.HasError)
            {
                return (int)resultTrack.Output;
            }

            return -1;
        }
    }
}