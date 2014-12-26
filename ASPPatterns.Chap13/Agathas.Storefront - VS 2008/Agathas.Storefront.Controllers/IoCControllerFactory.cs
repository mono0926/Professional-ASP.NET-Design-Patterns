using System;
using System.Web.Mvc;
using StructureMap;

namespace Agathas.Storefront.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(Type controllerType)
        {            
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }  
}
