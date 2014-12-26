using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public class CurrencyPriceDecorator : IPrice
    {
        private IPrice _basePrice;
        private decimal _exchangeRate;

        public CurrencyPriceDecorator(IPrice price, decimal exchangeRate)
        {
            _basePrice = price;
            _exchangeRate = exchangeRate;
        }

        public decimal Cost
        {
            get { return _basePrice.Cost * _exchangeRate; }
            set { _basePrice.Cost = value; }
        }
    }
}
