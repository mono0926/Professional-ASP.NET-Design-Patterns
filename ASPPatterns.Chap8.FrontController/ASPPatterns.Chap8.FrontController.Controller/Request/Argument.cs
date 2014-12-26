using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace ASPPatterns.Chap8.FrontController.Controller.Request
{
    public class Argument<T>
    {
        private string _key;

        public Argument(string key)
        {
            _key = key;
        }

        public string Key 
        {
            get { return _key; }
        }

        public T ExtractFrom(NameValueCollection queryArguments)
        {                     
            try
            {
                return (T)Convert.ChangeType(queryArguments[_key], typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
