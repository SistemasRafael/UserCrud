using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCrud.Domain.Model.Repositories
{
    public interface IStudentRepository :
        IReadRepository<Student, int>,
        IUpdateRepository<Student, ResultTrack>,
        IAddRepository<Student, ResultTrack>,
        IDeleteRepository<Student, ResultTrack>
    {
        IEnumerable<Student> GetAll();
    }
}
