using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class GenderTypeService : IGenderTypeService
    {
        private readonly IGenderTypeRepository genderTypeRepository = new GenderTypeRepository();
        public IEnumerable<GenderType> GetAll()
        {
            return genderTypeRepository.GetAll();
        }

        public GenderType GetBy(int gender_Type_Id)
        {
            return genderTypeRepository.GetBy(gender_Type_Id);
        }
    }
}

