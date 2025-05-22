using StudentCrud.Domain.Dto;
using StudentCrud.Utilities.DesignPatterns.Builder;
using System;

namespace Design.Patterns.Examples.Creational.Builder
{
    public class StudentBuilder : IBuilder<StudentDto>
    {
        private int _student_Id;
        private string _last_Name;
        private string _middle_Name;
        private string _first_Name;
        private DateTime _create_On;
        private DateTime _update_On;
        private int _gender;
        private GenderTypeDto _genderType;
        private AddressDto _address;
        private EmailDto _email;
        private PhoneDto _phone;

        public static StudentBuilder CreateBuilder() => new StudentBuilder();

        public StudentBuilder SetStudentId(int student_Id)
        {
            _student_Id = student_Id;
            return this;
        }

        public StudentBuilder SetLastName(string last_Name)
        {
            _last_Name = last_Name;
            return this;
        }

        public StudentBuilder SetMiddleName(string middle_Name)
        {
            _middle_Name = middle_Name;
            return this;
        }

        public StudentBuilder SetFirstName(string first_Name)
        {
            _first_Name = first_Name;
            return this;
        }

        public StudentBuilder SetCreateOn(DateTime create_On)
        {
            _create_On = create_On;
            return this;
        }

        public StudentBuilder SetUpdateOn(DateTime update_On)
        {
            _update_On = update_On;
            return this;
        }

        public StudentBuilder SetGender(int gender)
        {
            _gender = gender;
            return this;
        }

        public StudentBuilder SetGenderType(GenderTypeDto genderType)
        {
            _genderType = genderType;
            return this;
        }

        public StudentBuilder SetAddress(AddressDto address)
        {
            _address = address;
            return this;
        }

        public StudentBuilder SetEmail(EmailDto email)
        {
            _email = email;
            return this;
        }

        public StudentBuilder SetPhone(PhoneDto phone)
        {
            _phone = phone;
            return this;
        }

        public StudentDto build()
        {
            return new StudentDto()
            {
                Student_Id = _student_Id,
                Last_Name = _last_Name,
                Middle_Name = _middle_Name,
                First_Name = _first_Name,
                Create_On = _create_On,
                Update_On = _update_On,
                Gender = _gender,
                GenderType = _genderType,
                Address = _address,
                Email = _email,
                Phone = _phone
            };
        }
    }
}
