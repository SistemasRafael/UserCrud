using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories.Actions;
using System.Collections.Generic;

namespace StudentCrud.Domain.Model.Repositories
{
    public interface IPhoneTypeRepository : IReadRepository<PhoneType, int>
    {
        IEnumerable<PhoneType> GetAll();
    }
}
