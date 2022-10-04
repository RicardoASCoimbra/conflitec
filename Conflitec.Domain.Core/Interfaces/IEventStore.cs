using Conflitec.Domain.Core.Events;

namespace Conflitec.Domain.Core.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
