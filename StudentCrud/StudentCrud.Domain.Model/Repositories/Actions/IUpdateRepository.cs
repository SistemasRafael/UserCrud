using System.Threading.Tasks;

namespace StudentCrud.Domain.Model.Repositories.Actions
{
    public interface IUpdateRepository<T, Y> where T : class
    {
        Y Update(T parameters);
    }
}
