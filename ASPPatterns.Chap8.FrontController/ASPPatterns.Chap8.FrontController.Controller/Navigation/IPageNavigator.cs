using System;
namespace ASPPatterns.Chap8.FrontController.Controller.Navigation
{
    public interface IPageNavigator
    {
        void NavigateTo(PageDirectory page);
    }
}
