namespace StudentCrud.Models
{
    public class PhoneUpdateParameters
    {
        public int Phone_Id { get; set; }
        public int Student_Id { get; set; }
        public string Phone_Number { get; set; }
        public int Phone_Type { get; set; }
        public string Country_Code { get; set; }
        public string Area_Code { get; set; }
    }
}