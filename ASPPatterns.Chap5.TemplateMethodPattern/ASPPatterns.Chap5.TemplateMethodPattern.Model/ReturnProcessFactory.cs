using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    public static class ReturnProcessFactory
    {
        public static ReturnProcessTemplate CreateFrom(ReturnAction ReturnAction)
        {
            switch (ReturnAction)
            {
                case (ReturnAction.FaultyReturn):         
                    return new FaultyReturnProcess();            
                case (ReturnAction.NoQuibblesReturn):
                    return new NoQuibblesReturnProcess();
                default:
                    throw new ApplicationException("No Process Template defined for Return Action of " +
                                                   ReturnAction.ToString());
            }
        }
    }
}
