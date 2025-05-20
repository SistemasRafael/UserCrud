using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IEmailService
    {
        ResultTrack Add(Email entity);
        ResultTrack Update(Email entity);
        ResultTrack Delete(Email entity);
        IEnumerable<Email> GetAll();
        Email GetBy(string email_Name);
        Email GetByStudentId(int student_Id);
    }
}
