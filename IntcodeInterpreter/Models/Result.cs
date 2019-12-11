using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Models
{
    public class Result
    {
        public Status Status { get; set; }
        public IList<long> Output { get; set; }
    }
}
