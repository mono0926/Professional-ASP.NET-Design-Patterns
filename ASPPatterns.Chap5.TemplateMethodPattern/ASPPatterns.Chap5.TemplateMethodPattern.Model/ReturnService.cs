using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    public class ReturnService
    {        
        public void Process(ReturnOrder ReturnOrder)
        {
            ReturnProcessTemplate returnProcess = ReturnProcessFactory.CreateFrom(ReturnOrder.Action);

            returnProcess.Process(ReturnOrder);                                     

            // Code to refund the back to the customer...
        }
    }
}
