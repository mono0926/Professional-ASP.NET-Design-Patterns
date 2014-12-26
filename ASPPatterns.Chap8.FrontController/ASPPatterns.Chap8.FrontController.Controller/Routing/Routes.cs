using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.FrontController.Controller.Routing
{
    public class Routes
    {
        public static readonly Route Home = new Route("/Home.catalog");
        public static readonly Route CategoryProducts = new Route("/Products.catalog");
        public static readonly Route ProductDetail = new Route("/Product.catalog");
    }
}
