using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap8.FrontController.Controller.Storage
{
    public class ViewStorage : IViewStorage 
    {
        public void Add(ViewStorageKeys key, object value)
        {
            HttpContext.Current.Items.Add(key.ToString(), value);
        }

        public object Get(ViewStorageKeys key)
        {
            return HttpContext.Current.Items[key.ToString()];
        }
    }
}
