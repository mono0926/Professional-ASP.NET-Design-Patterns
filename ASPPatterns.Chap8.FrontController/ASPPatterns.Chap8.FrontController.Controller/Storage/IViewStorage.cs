using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.FrontController.Controller.Storage
{
    public interface IViewStorage
    {
        void Add(ViewStorageKeys key, object value);

        object Get(ViewStorageKeys key);        
    }
}
