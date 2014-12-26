using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Basket
{
    public class BasketItem : EntityBase<int>
    {
        private int _qty;
        private Product _product;
        private Basket _basket;

        public BasketItem()
        {
        }

        public BasketItem(Product product, Basket basket, int qty)
        {
            _product = product;
            _basket = basket;
            _qty = qty;
        }
        
        public decimal LineTotal()
        {
            return Product.Price * Qty;
        }

        public int Qty { get { return _qty; } }

        public Product Product { get { return _product; } }

        public Basket Basket { get { return _basket; } }

        public bool Contains(Product product)
        {
            return Product == product;
        }

        public void IncreaseItemQtyBy(int qty)
        {
            _qty += qty;
        }

        public void ChangeItemQtyTo(int qty)
        {
            _qty = qty;
        }

        protected override void Validate()
        {
            if (Qty < 0)
                base.AddBrokenRule(BasketItemBusinessRules.QtyInvalid);

            if (Product == null)
                base.AddBrokenRule(BasketItemBusinessRules.ProductRequired);

            if (Basket == null)
                base.AddBrokenRule(BasketItemBusinessRules.BasketRequired);
        }
    }

}
