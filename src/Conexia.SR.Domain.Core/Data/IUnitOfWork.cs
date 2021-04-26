using System.Threading.Tasks;

namespace Conexia.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
