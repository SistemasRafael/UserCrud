using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories.Actions;
using System.Collections.Generic;

namespace StudentCrud.Domain.Model.Repositories
{
    public interface IAddressRepository :
        IReadRepository<Address, int>,
        IUpdateRepository<Address, ResultTrack>,
        IAddRepository<Address, ResultTrack>,
        IDeleteRepository<Address, ResultTrack>
    {
        IEnumerable<Address> GetAll();
    }
}
