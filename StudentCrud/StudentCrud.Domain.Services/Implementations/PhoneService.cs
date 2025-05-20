using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository phoneRepository = new PhoneRepository();

        public ResultTrack Add(Phone entity)
        {
            return phoneRepository.Add(entity);
        }

        public ResultTrack Delete(Phone entity)
        {
            return phoneRepository.Delete(entity);
        }

        public IEnumerable<Phone> GetAll()
        {
            return phoneRepository.GetAll();
        }

        public Phone GetBy(int phone_Id)
        {
            return phoneRepository.GetBy(phone_Id);
        }

        public Phone GetByStudentId(int student_Id)
        {
            return phoneRepository.GetByStudentId(student_Id);
        }

        public ResultTrack Update(Phone entity)
        {
            return phoneRepository.Update(entity);
        }
    }
}
