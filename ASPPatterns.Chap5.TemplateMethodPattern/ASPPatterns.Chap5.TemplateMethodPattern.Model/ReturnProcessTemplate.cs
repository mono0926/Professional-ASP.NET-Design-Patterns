using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    public abstract class ReturnProcessTemplate
    {       
        protected abstract void GenerateReturnTransactionFor(ReturnOrder ReturnOrder);
        protected abstract void CalculateRefundFor(ReturnOrder ReturnOrder);

        public void Process(ReturnOrder ReturnOrder)
        {
            GenerateReturnTransactionFor(ReturnOrder);
            CalculateRefundFor(ReturnOrder);
        }
    }
}
