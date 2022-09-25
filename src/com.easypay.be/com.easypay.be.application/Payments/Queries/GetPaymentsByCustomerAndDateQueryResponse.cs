using com.easypay.be.application.Payments.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentsByCustomerAndDateQueryResponse
    {
        public IEnumerable<GetPaymentsDto> Payments { get; }

        public GetPaymentsByCustomerAndDateQueryResponse(IEnumerable<GetPaymentsDto> payments)
        {
            Payments = payments;
        }
    }
}
