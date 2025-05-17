using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories.Actions;
using System.Collections.Generic;

namespace StudentCrud.Domain.Model.Repositories
{
    public interface IEmailRepository :
        IUpdateRepository<Email, ResultTrack>,
        IAddRepository<Email, ResultTrack>,
        IDeleteRepository<Email, ResultTrack>
    {
        IEnumerable<Email> GetAll();
        Email GetBy(string email_Name);
    }
}
