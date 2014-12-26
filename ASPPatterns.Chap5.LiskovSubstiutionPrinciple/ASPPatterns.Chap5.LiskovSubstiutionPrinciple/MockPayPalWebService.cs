using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    // Stub class to act as a PayPal web service
    public class MockPayPalWebService
    {
        public string ObtainToken(string AccountName, string Password)
        {
            return "";
        }

        public string MakeRefund(decimal amount, string transactionId, string token)
        {
            return "Auth:0999";
        }
    }
}
