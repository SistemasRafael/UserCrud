namespace StudentCrud.Domain.Model.DatabaseModels
{
    public class Address
    {
        public int Address_Id { get; set; }
        public int Student_Id { get; set; }
        public string Address_Line { get; set; }
        public string City { get; set; }
        public string Zip_Codepost { get; set; }
        public string State { get; set; }
    }
}
