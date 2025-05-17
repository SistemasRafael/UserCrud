using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Domain.Services.Implementations;
using System;
using System.Web.UI;

namespace StudentCrud
{
    public partial class _Default : Page
    {
        private readonly IStudentService studentService = null; 

        public _Default()
        {
            studentService = new StudentService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}