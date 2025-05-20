using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Services;
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
                //LoadComboGender();
                //LoadComboStates();
                //LoadComboCities();
                //LoadComboEmailType();
                //LoadComboPhoneType();
            }
        }

        protected void btnSubmitForm_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //    btnSubmitForm.Text = "My form is valid!";
            //}
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

        //void LoadComboGender()
        //{
        //    List<string> genders = new List<string>() { 
        //        "Select option", 
        //        "Male", 
        //        "Female" 
        //    };

        //    int index = 0;
        //    genders.ForEach(gender =>
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = gender;
        //        item.Value = index.ToString();
        //        GenderId.Items.Add(item);
        //        index++;
        //    });
        //}

        //void LoadComboStates()
        //{
        //    List<string> states = new List<string>() {
        //        "Select option",
        //        "Sonora",
        //        "Sinaloa"
        //    };

        //    int index = 0;
        //    states.ForEach(gender =>
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = gender;
        //        item.Value = index.ToString();
        //        StateId.Items.Add(item);
        //        index++;
        //    });
        //}

        //void LoadComboCities()
        //{
        //    List<string> cities = new List<string>() {
        //        "Select option",
        //        "Hermosillo",
        //        "Obregon"
        //    };

        //    int index = 0;
        //    cities.ForEach(gender =>
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = gender;
        //        item.Value = index.ToString();
        //        CityId.Items.Add(item);
        //        index++;
        //    });
        //}

        //void LoadComboEmailType()
        //{
        //    List<string> emailTypes = new List<string>() {
        //        "Select option",
        //        "Gmail",
        //        "Hotmail"
        //    };

        //    int index = 0;
        //    emailTypes.ForEach(gender =>
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = gender;
        //        item.Value = index.ToString();
        //        TypeEmailId.Items.Add(item);
        //        index++;
        //    });
        //}

        //void LoadComboPhoneType()
        //{
        //    List<string> phoneTypes = new List<string>() {
        //        "Select option",
        //        "Phone",
        //        "Cell phone"
        //    };

        //    int index = 0;
        //    phoneTypes.ForEach(gender =>
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = gender;
        //        item.Value = index.ToString();
        //        PhoneTypeId.Items.Add(item);
        //        index++;
        //    });
        //}

        [WebMethod]
        public static string Add_Student(StudentAddParameters student)
        {
            var studentService = new StudentService();
            var _student = student.MapToModel();

            var resultTrack = studentService.Add(_student);
            if (!resultTrack.HasError)
            {
                return resultTrack.Output.ToString();
            }
            else if (resultTrack.HasSQLError)
            {
                return resultTrack.Message;
            }
            else if (resultTrack.HasError)
            {
                return resultTrack.Message;
            }

            return "Status 400 Bad Request";
        }

        [WebMethod]
        public static object Add_Address(AddressAddParameters address)
        {
            var addressService = new AddressService();
            var _address = address.MapToModel();

            var resultTrack = addressService.Add(_address);
            if (!resultTrack.HasError)
            {
                return resultTrack.Output.ToString();
            }
            else if (resultTrack.HasSQLError)
            {
                return resultTrack.Message;
            }
            else if (resultTrack.HasError)
            {
                return resultTrack.Message;
            }

            return "Status 400 Bad Request";
        }

        [WebMethod]
        public static object Add_Email(EmailAddParameters email)
        {
            var emailService = new EmailService();
            var _email = email.MapToModel();

            var resultTrack = emailService.Add(_email);
            if (!resultTrack.HasError)
            {
                return resultTrack.Output.ToString();
            }
            else if (resultTrack.HasSQLError)
            {
                return resultTrack.Message;
            }
            else if (resultTrack.HasError)
            {
                return resultTrack.Message;
            }

            return "Status 400 Bad Request";
        }

        [WebMethod]
        public static object Add_Phone(PhoneAddParameters phone)
        {
            var phoneService = new PhoneService();
            var _phone = phone.MapToModel();

            var resultTrack = phoneService.Add(_phone);
            if (!resultTrack.HasError)
            {
                return resultTrack.Output.ToString();
            }
            else if (resultTrack.HasSQLError)
            {
                return resultTrack.Message;
            }
            else if (resultTrack.HasError)
            {
                return resultTrack.Message;
            }

            return "Status 400 Bad Request";
        }
    }
}