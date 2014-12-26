using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ASPPatterns.Chap9.PeriodicRefresh.Service
{
    [DataContract]
    public class Commentary
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public DateTime RealTime { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
}
