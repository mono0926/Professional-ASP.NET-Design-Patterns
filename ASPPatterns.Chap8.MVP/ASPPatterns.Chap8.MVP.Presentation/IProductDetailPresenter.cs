using System;
namespace ASPPatterns.Chap8.MVP.Presentation
{
    public interface IProductDetailPresenter
    {
        void Display();
        void AddProductToBasketAndShowBasketPage();
    }
}
