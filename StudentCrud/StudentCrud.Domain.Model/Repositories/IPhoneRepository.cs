using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories.Actions;
using System.Collections.Generic;

namespace StudentCrud.Domain.Model.Repositories
{
    public interface IPhoneRepository :
        IReadRepository<Phone, int>,
        IUpdateRepository<Phone, ResultTrack>,
        IAddRepository<Phone, ResultTrack>,
        IDeleteRepository<Phone, ResultTrack>
    {
        IEnumerable<Phone> GetAll();
    }
}
