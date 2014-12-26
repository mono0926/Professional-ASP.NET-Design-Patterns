using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public interface IPrice
    {
        decimal Cost { get; set; }
    }
}
