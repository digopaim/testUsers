using System;
using MediatR;
using RabbitMQ;

namespace Domain.Core.Events
{
    [Serializable]
    public abstract class Message : MessageQueue, INotification
    {
        public Guid AggregateId { get; protected set; }

        protected Message() =>
            MessageType = GetType().Name;
        
    }
}