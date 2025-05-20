using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository emailRepository = new EmailRepository();

        public ResultTrack Add(Email entity)
        {
            return emailRepository.Add(entity);
        }

        public ResultTrack Delete(Email entity)
        {
            return emailRepository.Delete(entity);
        }

        public IEnumerable<Email> GetAll()
        {
            return emailRepository.GetAll();
        }

        public Email GetBy(string email_Name)
        {
            return emailRepository.GetBy(email_Name);
        }

        public Email GetByStudentId(int student_Id)
        {
            return emailRepository.GetByStudentId(student_Id);
        }

        public ResultTrack Update(Email entity)
        {
            return emailRepository.Update(entity);
        }
    }
}
