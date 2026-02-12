using ExceptionsHandsOn.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHandsOn.Infrastructure.External
{
    public class PaymentGatewayClient
    {
        public void ProcessPayment()
        {
            try
            {
                throw new InvalidOperationException("Gateway Timeout");
            }
            catch(Exception ex)
            {
                throw new ExternalServiceException("Payment Failed", ex);
            }
        }
    }
}
