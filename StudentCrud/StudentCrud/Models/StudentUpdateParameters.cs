namespace StudentCrud.Models
{
    public class StudentUpdateParameters
    {
        public int Student_Id { get; set; }
        public string Last_Name { get; set; }
        public string Middle_Name { get; set; }
        public string First_Name { get; set; }
        public int Gender { get; set; }
    }
}