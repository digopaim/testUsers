using System.Threading.Tasks;

namespace Domain.Core.Events
{
    public interface IEventStore
    {
        Task Save<T>(T theEvent) where T : Event;
    }
}