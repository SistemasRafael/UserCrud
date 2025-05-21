using StudentCrud.Domain.Dto;
using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var emailTypeService = new EmailTypeService();
            var phoneService = new PhoneService();

            var student = studentService.GetBy(GetStudentId()).MapToDto();
            student.Address = addressService.GetByStudentId(student.Student_Id).MapToDto() ?? new AddressDto();
            student.Email = emailService.GetByStudentId(student.Student_Id).MapToDto() ?? new EmailDto();
            student.Email.EmailType = emailTypeService.GetBy(student.Email.Email_Type).MapToDto() ?? new EmailTypeDto();
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
                if (_addres != null) { 
                    Update_Address(new AddressUpdateParameters()
                    {
                        Address_Id = _addres.Address_Id,
                        Address_Line = AddressId.Text,
                        City = CityId.SelectedValue,
                        Zip_Codepost = ZipCodeId.Text,
                        State = StateId.SelectedValue,
                    });
                }
                else
                {
                    Add_Address(new AddressAddParameters()
                    {
                        Student_Id = GetStudentId(),
                        Address_Line = AddressId.Text,
                        City = CityId.SelectedValue,
                        Zip_Codepost = ZipCodeId.Text,
                        State = StateId.SelectedValue,
                    });
                }

                var emailService = new EmailService();
                var _email = emailService.GetByStudentId(GetStudentId());
                if (_email != null)
                {
                    Update_Email(new EmailUpdateParameters()
                    {
                        Student_Id = GetStudentId(),
                        Email_Name = EmailId.Text,
                        Email_Type = int.Parse(TypeEmailId.SelectedValue)
                    });
                }
                else
                {
                    Add_Email(new EmailAddParameters()
                    {
                        Student_Id = GetStudentId(),
                        Email_Name = EmailId.Text,
                        Email_Type = int.Parse(TypeEmailId.SelectedValue)
                    });
                }

                var _phoneService = new PhoneService();
                var _phone = _phoneService.GetByStudentId(GetStudentId());
                if (_phone != null)
                {
                    Update_Phone(new PhoneUpdateParameters()
                    {
                        Phone_Id = _phone.Phone_Id,
                        Phone_Number = PhoneNumberId.Text,
                        Phone_Type = int.Parse(PhoneTypeId.SelectedValue),
                        Country_Code = CountryCodeId.Text,
                        Area_Code = AreaCodeId.Text,
                    });
                }
                else
                {
                    Add_Phone(new PhoneAddParameters()
                    {
                        Student_Id = GetStudentId(),
                        Phone_Number = PhoneNumberId.Text,
                        Phone_Type = int.Parse(PhoneTypeId.SelectedValue),
                        Country_Code = CountryCodeId.Text,
                        Area_Code = AreaCodeId.Text,
                    });
                }
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
            StateId.SelectedValue = "Select option";
            CityId.SelectedValue = "Select option";            
            EmailId.Text = string.Empty;
            TypeEmailId.SelectedValue = "0";
            ZipCodeId.Text = string.Empty;
            AddressId.Text = string.Empty;
            PhoneNumberId.Text = string.Empty;
            PhoneTypeId.SelectedValue = "0";
            CountryCodeId.Text = string.Empty;
            AreaCodeId.Text = string.Empty;
        }

        void LoadComboGender()
        {
            var genderTypeService = new GenderTypeService();
            var genders = genderTypeService.GetAll().ToList();

            ListItem itemOpt = new ListItem();
            itemOpt.Text = "Select option";
            itemOpt.Value = "0";
            GenderId.Items.Add(itemOpt);

            genders.ForEach(gender =>
            {
                ListItem item = new ListItem();
                item.Text = gender.Gender_Type;
                item.Value = gender.Gender_Type_Id.ToString();
                GenderId.Items.Add(item);
            });
        }

        void LoadComboStates()
        {
            List<string> states = new List<string>() {
                "Select option",
                "Sonora",
                "Sinaloa"
            };

            states.ForEach(state =>
            {
                ListItem item = new ListItem();
                item.Text = state;
                item.Value = state;
                StateId.Items.Add(item);
            });
        }

        void LoadComboCities()
        {
            List<string> cities = new List<string>() {
                "Select option",
                "Hermosillo",
                "Obregon"
            };

            cities.ForEach(citie =>
            {
                ListItem item = new ListItem();
                item.Text = citie;
                item.Value = citie;
                CityId.Items.Add(item);
            });
        }

        void LoadComboEmailType()
        {
            var emailTypeService = new EmailTypeService();
            var emailTypes = emailTypeService.GetAll().ToList();

            ListItem itemOpt = new ListItem();
            itemOpt.Text = "Select option";
            itemOpt.Value = "0";
            TypeEmailId.Items.Add(itemOpt);

            emailTypes.ForEach(email =>
            {
                ListItem item = new ListItem();
                item.Text = email.Email_Type;
                item.Value = email.Email_Type_Id.ToString();
                TypeEmailId.Items.Add(item);
            });
        }

        void LoadComboPhoneType()
        {
            var phoneTypeService = new PhoneTypeService();
            var phoneTypes = phoneTypeService.GetAll().ToList();

            ListItem itemOpt = new ListItem();
            itemOpt.Text = "Select option";
            itemOpt.Value = "0";
            PhoneTypeId.Items.Add(itemOpt);

            phoneTypes.ForEach(phoneType =>
            {
                ListItem item = new ListItem();
                item.Text = phoneType.Phone_Type;
                item.Value = phoneType.Phone_Type_Id.ToString();
                PhoneTypeId.Items.Add(item);
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