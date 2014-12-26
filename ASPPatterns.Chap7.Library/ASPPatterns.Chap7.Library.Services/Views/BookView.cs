using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Services.Views
{
    public class BookView
    {
        public string Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string OnLoanTo { get; set; }    
    }
}
