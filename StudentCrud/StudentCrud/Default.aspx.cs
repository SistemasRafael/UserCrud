using StudentCrud.Domain.Services.Implementations;
using StudentCrud.Extensions;
using StudentCrud.Models;
using System;
using System.Web.Services;
using System.Web.UI;

namespace StudentCrud
{
    public partial class _Default : Page
    {
        protected void Page_LoadComplete()
        {
            string myScript2 = "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/StudentService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/AddressService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/EmailService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/PhoneService.js\"></script>";
            myScript2 += "\n<script type=\"text/javascript\" language=\"Javascript\" src=\"Scripts/Student.js\"></script>";
            ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript2, false);
        }

        [WebMethod]
        public static string AddStudent(StudentAddParameters student)
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
        public static object AddAddress(AddressAddParameters address)
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
        public static object AddEmail(EmailAddParameters email)
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
        public static object AddPhone(PhoneAddParameters phone)
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