using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories.Actions;
using System.Collections.Generic;

namespace StudentCrud.Domain.Model.Repositories
{
    public interface IGenderTypeRepository : IReadRepository<GenderType, int>
    {
        IEnumerable<GenderType> GetAll();
    }
}
