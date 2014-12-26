using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    public class WorldPayPayment : PaymentServiceBase 
    {
        public WorldPayPayment(string AccountId, string AccountPassword, string ProductId)
        {
            this.AccountId = AccountId;
            this.AccountPassword = AccountPassword;
            this.ProductId = ProductId;
        }
        public string AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string ProductId { get; set; }

        public override RefundResponse Refund(decimal amount, string transactionId)
        {
            RefundResponse refundResponse = new RefundResponse();
            MockWorldPayWebService worldPayWebService = new MockWorldPayWebService();

            string response = worldPayWebService.MakeRefund(amount, transactionId, AccountId, AccountPassword, ProductId);

            refundResponse.Message = response;

            if (response.Contains("A_Success"))
                refundResponse.Success = true;
            else
                refundResponse.Success = false;

            return refundResponse;
        }
    }
}
