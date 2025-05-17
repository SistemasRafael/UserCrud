using System.Threading.Tasks;

namespace StudentCrud.Domain.Model.Repositories.Actions
{
    public interface IReadRepository<T, Y> where T : class
    {
        T GetBy(Y parameters);
    }
}
