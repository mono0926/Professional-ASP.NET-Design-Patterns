using System;
namespace ASPPatterns.Chap8.CoR.Controller.Navigation
{
    public interface IPageNavigator
    {
        void NavigateTo(PageDirectory page);
    }
}
