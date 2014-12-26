using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.IoC.Model.Payment;
using ASPPatterns.Chap8.IoC.Model.Despatch;

namespace ASPPatterns.Chap8.IoC.Model
{
    public class OrderService
    {
        private IPaymentGateway _paymentGateway;
        private IDespatchService _despatchService;

        public OrderService(IPaymentGateway paymentGateway, IDespatchService despatchService)
        {
            _paymentGateway = paymentGateway;
            _despatchService = despatchService;
        }

        public override string ToString()
        {
            return String.Format("Payment Gateway: {0}, Despatch Service: {1}", _paymentGateway.ToString(), _despatchService.ToString());
        }
    }
}
