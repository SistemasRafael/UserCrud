using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class EmailTypeService : IEmailTypeService
    {
        private readonly IEmailTypeRepository emailTypeRepository = new EmailTypeRepository();

        public IEnumerable<EmailType> GetAll()
        {
            return emailTypeRepository.GetAll();
        }

        public EmailType GetBy(int email_Type_Id)
        {
            return emailTypeRepository.GetBy(email_Type_Id);
        }
    }
}
