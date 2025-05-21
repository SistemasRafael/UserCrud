using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IEmailTypeService
    {
        IEnumerable<EmailType> GetAll();
        EmailType GetBy(int email_Type_Id);
    }
}
