using System;

namespace StudentCrud.Domain.Model.DatabaseModels
{
    public class Student
    {
        public int Student_Id { get; set; }
        public string Last_Name { get; set; }
        public string Middle_Name { get; set; }
        public string First_Name { get; set; }
        public DateTime Create_On { get; set; }
        public DateTime Update_On { get; set; }
        public int Gender { get; set; }

    }
}
