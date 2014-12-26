using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    public class NoQuibblesReturnProcess : ReturnProcessTemplate
    {
        protected override void GenerateReturnTransactionFor(ReturnOrder ReturnOrder)
        {
            // Code to put items back into stock...
        }

        protected override void CalculateRefundFor(ReturnOrder ReturnOrder)
        {            
            ReturnOrder.AmountToRefund = ReturnOrder.PricePaid; 
        }
    }
}
