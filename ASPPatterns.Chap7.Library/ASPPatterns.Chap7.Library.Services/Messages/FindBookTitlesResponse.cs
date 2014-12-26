using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Services.Views;

namespace ASPPatterns.Chap7.Library.Services.Messages
{
    public class FindBookTitlesResponse : ResponseBase 
    {
        public IEnumerable<BookTitleView> BookTitles { get; set; }  
    }
}
