using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace ASPPatterns.Chap8.CoR.Controller.Request
{
    public class WebRequest
    {
        public NameValueCollection QueryArguments { get; set; }
        public string RequestedURL { get; set; }
    }
}
