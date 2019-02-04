using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
