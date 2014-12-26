using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.IoC.Model.Payment
{
    public class PaymentGateway : IPaymentGateway 
    {
        IPaymentMerchant _paymentMerchant;

        public PaymentGateway(IPaymentMerchant paymentMerchant)
        {
            _paymentMerchant = paymentMerchant;
        }

        public override string ToString()
        {
            return _paymentMerchant.ToString();
        }
    }
}
