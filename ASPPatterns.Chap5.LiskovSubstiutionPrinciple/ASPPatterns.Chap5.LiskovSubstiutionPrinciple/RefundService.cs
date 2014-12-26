using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    public class RefundService
    {
        public RefundResponse Refund(RefundRequest refundRequest)
        {
            PaymentServiceBase paymentService = PaymentServiceFactory.GetPaymentServiceFrom(refundRequest.Payment);
            RefundResponse refundResponse;                

            refundResponse = paymentService.Refund(refundRequest.RefundAmount, refundRequest.PaymentTransactionId);           

            return refundResponse;
        }
    }
}
