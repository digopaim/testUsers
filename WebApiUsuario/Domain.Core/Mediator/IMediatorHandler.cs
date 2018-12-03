using Domain.Core.Commands;
using Domain.Core.Events;
using System;
using System.Threading.Tasks;

namespace Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(Guid IdentifiedCommand, T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
        Task RaiseEvent<T>(T @event, bool saveEventSource) where T : Event;
        Task RaiseEventBus<T>(T @event) where T : Event;
        Task RaiseEventBusPropagator<T>(T @event) where T : Event;
    }
}
