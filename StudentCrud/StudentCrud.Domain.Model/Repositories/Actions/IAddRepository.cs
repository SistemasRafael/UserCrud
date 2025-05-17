using System.Threading.Tasks;

namespace StudentCrud.Domain.Model.Repositories.Actions
{
    public interface IAddRepository<T, Y> where T : class
    {
        Y Add(T parameters);
    }
}
