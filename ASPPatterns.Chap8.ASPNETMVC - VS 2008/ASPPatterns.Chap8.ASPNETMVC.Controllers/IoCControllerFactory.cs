using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using StructureMap;

namespace ASPPatterns.Chap8.ASPNETMVC.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }    
    }     
}
