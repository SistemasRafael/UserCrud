using System;

namespace StudentCrud.Domain.Dto
{
    public class StudentDto
    {
        public int Student_Id { get; set; }
        public string Last_Name { get; set; }
        public string Middle_Name { get; set; }
        public string First_Name { get; set; }
        public DateTime Create_On { get; set; }
        public DateTime Update_On { get; set; }
        public int Gender { get; set; }
        public GenderTypeDto GenderType { get; set; }
        public AddressDto Address { get; set; }
        public EmailDto Email { get; set; }
        public PhoneDto Phone { get; set; }
    }
}
