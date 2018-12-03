using System;
using System.Threading.Tasks;
using Domain.Core.Events;
using Domain.Core.Exceptions;
using Domain.Core.Idempotency;
using FluentValidation.Results;

namespace Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();

    }
}