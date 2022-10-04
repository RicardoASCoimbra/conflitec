using Conflitec.Domain.Core.Commands;
using Conflitec.Domain.Core.Events;

namespace Conflitec.Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}

