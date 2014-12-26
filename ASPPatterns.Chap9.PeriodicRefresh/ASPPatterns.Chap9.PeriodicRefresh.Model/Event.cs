using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap9.PeriodicRefresh.Model
{
    public class Event
    {
        public int Id { get; set; }        
        public string Time { get; set; }        
        public DateTime RealTime { get; set; }        
        public string Text { get; set; }
    }
}
