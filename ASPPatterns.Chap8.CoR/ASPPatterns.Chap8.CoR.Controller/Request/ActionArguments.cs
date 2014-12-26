using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.CoR.Controller.Request
{
    public class ActionArguments
    {
        public static readonly Argument<int> CategoryId = new Argument<int>("categoryId");
        public static readonly Argument<int> ProductId = new Argument<int>("productId");
    }
}
