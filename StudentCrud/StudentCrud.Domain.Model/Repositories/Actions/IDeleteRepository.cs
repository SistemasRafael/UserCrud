using System.Threading.Tasks;

namespace StudentCrud.Domain.Model.Repositories.Actions
{
    public interface IDeleteRepository<T, Y> where T : class
    {
        Y Delete(T parameters);
    }
}
