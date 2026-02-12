using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHandsOn.Domain.Exceptions
{
    public class ExternalServiceException: Exception
    {
        public ExternalServiceException(string message,Exception inner): base(message, inner) { }
    }
}
