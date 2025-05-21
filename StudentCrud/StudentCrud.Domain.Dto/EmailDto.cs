using System;

namespace StudentCrud.Domain.Dto
{
    public class EmailDto
    {
        public string Email_Name { get; set; }
        public int Student_Id { get; set; }
        public int Email_Type { get; set; }
        public DateTime Create_On { get; set; }
        public DateTime Update_On { get; set; }
        public EmailTypeDto EmailType { get; set; }
    }
}
