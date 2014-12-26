using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Model.Orders
{
    public class PaymentFactory
    {
        public static Payment CreatePayment(string paymentToken,
                                            decimal amount, string paymentMerchant)
        {
            return new Payment(DateTime.Now, paymentToken, paymentMerchant, amount);
        }
    }

}
