using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class PhoneTypeService : IPhoneTypeService
    {
        private readonly IPhoneTypeRepository phoneTypeRepository = new PhoneTypeRepository();
        public IEnumerable<PhoneType> GetAll()
        {
            return phoneTypeRepository.GetAll();
        }

        public PhoneType GetBy(int phone_Type_Id)
        {
            return phoneTypeRepository.GetBy(phone_Type_Id);
        }
    }
}
