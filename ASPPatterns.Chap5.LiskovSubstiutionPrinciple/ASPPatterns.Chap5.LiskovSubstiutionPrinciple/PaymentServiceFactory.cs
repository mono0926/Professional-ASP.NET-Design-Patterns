using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    public class PaymentServiceFactory
    {
        public static PaymentServiceBase GetPaymentServiceFrom(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.PayPal:
                    return new PayPalPayment("Scott123-PP", "ABCXYZ-PP");
                case PaymentType.WorldPay:
                    return new WorldPayPayment("Scott123-WP", "ABCXYZ-WP", "1"); 
                default:
                    throw new ApplicationException("No Payment Service available for " + paymentType.ToString());
            }
        }
    }
}
