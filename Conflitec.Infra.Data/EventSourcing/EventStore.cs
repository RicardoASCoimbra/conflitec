﻿using Conflitec.Domain.Core.Events;
using Conflitec.Domain.Core.Interfaces;
using Newtonsoft.Json;

namespace Conflitec.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(theEvent, serializedData, "_user.Name");
        }
    }
}
