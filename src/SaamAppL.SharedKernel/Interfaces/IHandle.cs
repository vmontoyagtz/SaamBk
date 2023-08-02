using System.Threading.Tasks;

namespace SaamAppLib.SharedKernel.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        Task HandleAsync(T args);
    }
}