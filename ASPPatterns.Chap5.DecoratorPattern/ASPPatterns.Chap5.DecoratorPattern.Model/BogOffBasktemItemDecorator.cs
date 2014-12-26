using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public class BogOffBasktemItemDecorator : IBasketItem 
    {   
        private IBasketItem _basketItem;

        public BogOffBasktemItemDecorator(IBasketItem basketItem)
        {
            _basketItem = basketItem;
        }

        public Product Product
        {
            get
            {
                return _basketItem.Product; 
            }
            set
            {
                _basketItem.Product = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _basketItem.Quantity; 
            }
            set
            {
                _basketItem.Quantity = value;
            }
        }

        public decimal LineTotal
        {
            get 
            {
                if (LineContainsNoProducts())
                { 
                    return 0;
                }
                else if (LineContainsAnEvenQuantity())
                {
                    return Quantity / 2 * Product.Price.Cost;
                }
                else if (LineContainsOneProduct())
                {
                    return Product.Price.Cost;
                }
                else
                {
                    return (((Quantity - 1) / 2) + 1) * Product.Price.Cost;
                }
                                
            }
        }

        private bool LineContainsNoProducts()
        {
            return Quantity == 0;
        }

        private bool LineContainsOneProduct()
        {
            return Quantity == 1;
        }

        private bool LineContainsAnEvenQuantity()
        {
            return Quantity % 2 == 0;
        }        
    }
}
