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
        private readonly IAddressService addressService = null;
        private readonly IEmailService emailService = null;
        private readonly IPhoneService phoneService = null;

        public _Default()
        {
            studentService = new StudentService();
            addressService = new AddressService();
            emailService = new EmailService();
            phoneService = new PhoneService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //var student_Id = Student();
            //Address(student_Id);
            //Email(student_Id);
            //Phone(student_Id);
        }

        private void Phone(int student_Id)
        {
            int phoneIdCopy = 0;
            var phones = phoneService.GetAll().ToList();
            if (phones.Count == 0)
            {
                phoneIdCopy = (int)phoneService.Add(new Phone()
                {
                    Student_Id = student_Id,
                    Phone_Number = "12345678",
                    Phone_Type = 1,
                    Country_Code = "12345",
                    Area_Code = "54321"
                }).Output;
            }
            else
            {
                phoneIdCopy = phones[0].Phone_Id;
            }
            var phone = phoneService.GetBy(phoneIdCopy);
            var resultTrack = phoneService.Delete(phone);
            var areTherePhones = phoneService.GetAll().ToList();
            var existPhone = phoneService.GetBy(phone.Phone_Id);
            var phoneId = phoneService.Add(new Phone()
            {
                Student_Id = student_Id,
                Phone_Number = "12345678",
                Phone_Type = 2,
                Country_Code = "123",
                Area_Code = "321"
            });

            var updatePhone = phoneService.GetBy((int)phoneId.Output);
            updatePhone.Phone_Number = "123434235";
            updatePhone.Phone_Type = 1;
            updatePhone.Country_Code = "12312";
            updatePhone.Area_Code = "32134";

            var phoneUpdateId = phoneService.Update(updatePhone);
        }

        private void Email(int student_Id)
        {
            string email_NameCopy = string.Empty;
            var emails = emailService.GetAll().ToList();
            if (emails.Count == 0)
            {
                email_NameCopy = (string)emailService.Add(new Email()
                {
                    Student_Id = student_Id,
                    Email_Name = "testAddress@test.com",
                    Email_Type = 1
                }).Output;
            }
            else
            {
                email_NameCopy = emails[0].Email_Name;
            }

            var email = emailService.GetBy(email_NameCopy);
            var resultTrack = emailService.Delete(email);
            var areThereaddresses = emailService.GetAll().ToList();
            var existEmail = emailService.GetBy(email.Email_Name);
            var addressId = emailService.Add(new Email()
            {
                Student_Id = student_Id,
                Email_Name = "testAddressCopy@test.com",
                Email_Type = 1
            });

            var updateEmail = emailService.GetBy((string)addressId.Output);
            updateEmail.Email_Name = "testAddressCopy@test.com";
            updateEmail.Email_Type = 2;

            var email_NameUpdate = emailService.Update(updateEmail);
        }

        private void Address(int student_Id)
        {
            int addressIdCopy = 0;
            var addresses = addressService.GetAll().ToList();
            if (addresses.Count == 0)
            {
                addressIdCopy = (int)addressService.Add(new Address()
                {
                    Student_Id = student_Id,
                    Address_Line = "testAddress",
                    City = "testCity",
                    Zip_Codepost = "testZip_Codepost",
                    State = "testState"
                }).Output;
            }
            else
            {
                addressIdCopy = addresses[0].Address_Id;
            }
            var address = addressService.GetBy(addressIdCopy);
            var resultTrack = addressService.Delete(address);
            var areThereaddresses = addressService.GetAll().ToList();
            var existAddress = addressService.GetBy(address.Address_Id);
            var addressId = addressService.Add(new Address()
            {
                Student_Id = student_Id,
                Address_Line = "testAddressCopy",
                City = "testCityCopy",
                Zip_Codepost = "testZip_CodepostCopy",
                State = "testStateCopy"
            });

            var updateAddress = addressService.GetBy((int)addressId.Output);
            updateAddress.Address_Line = "testAddressCopy2";
            updateAddress.City = "testCityCopy2";
            updateAddress.Zip_Codepost = "testZip_CodepostCopy2";
            updateAddress.State = "testStateCopy2";

            var addressUpdateId = addressService.Update(updateAddress);
        }

        private int Student()
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

            return (int)studentUpdateId.Output;
        }
    }
}