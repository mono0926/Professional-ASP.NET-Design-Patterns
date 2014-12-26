using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.CoR.Controller.Storage
{
    public static class ViewStorageFactory
    {       
        public static IViewStorage GetStorage()
        {
            return new ViewStorage();
        }
    }
}
