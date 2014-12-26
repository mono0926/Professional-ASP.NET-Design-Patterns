using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    public class FaultyReturnProcess : ReturnProcessTemplate
    {
        protected override void GenerateReturnTransactionFor(ReturnOrder ReturnOrder)
        {
            // Code to send generate order that sends faulty item back to
            // manufacturer...
        }

        protected override void CalculateRefundFor(ReturnOrder ReturnOrder)
        {
            ReturnOrder.AmountToRefund = ReturnOrder.PricePaid + ReturnOrder.PostageCost;
        }
    }
}
