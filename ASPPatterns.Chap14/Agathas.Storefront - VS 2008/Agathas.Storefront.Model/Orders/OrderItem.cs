using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Orders
{
    public class OrderItem : EntityBase<int>
    {
        private readonly Product _product;
        private readonly Order _order;
        private readonly int _qty;
        private readonly decimal _price;

        public OrderItem()
        {
        }

        public OrderItem(Product product, Order order, int qty)
        {
            _product = product;
            _order = order;
            _price = product.Price;
            _qty = qty;
        }

        public Product Product
        {
            get { return _product; }
        }

        public int Qty
        {
            get { return _qty; }
        }

        public decimal Price
        {
            get { return _price; }
        }

        public Order Order
        {
            get { return _order; }
        }

        public decimal LineTotal()
        {
            return Qty * Price;
        }

        protected override void Validate()
        {
            if (Order == null)
                base.AddBrokenRule(OrderItemBusinessRules.OrderRequired);

            if (Product == null)
                base.AddBrokenRule(OrderItemBusinessRules.ProductRequired);

            if (Price < 0)
                base.AddBrokenRule(OrderItemBusinessRules.PriceNonNegative);

            if (Qty < 0)
                base.AddBrokenRule(OrderItemBusinessRules.QtyNonNegative);
        }

        public bool Contains(Product product)
        {
            return Product == product;
        }
    }

}
