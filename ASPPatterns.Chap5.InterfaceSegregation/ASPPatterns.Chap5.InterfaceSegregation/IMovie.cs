using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.InterfaceSegregation.Model
{
    public interface IMovie
    {        
        int Certification { get; set; }
        int RunningTime { get; set; }
    }
}
