using Day05Task1Solution.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day05Task1Solution.Models
{
    public class Result
    {
        public Status Status { get; set; }
        public IList<long> Output { get; set; }
    }
}
