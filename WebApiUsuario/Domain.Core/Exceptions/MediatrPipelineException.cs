using System;

namespace Domain.Core.Validators
{
    public class MediatrPipelineException : Exception
    {
        public MediatrPipelineException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}