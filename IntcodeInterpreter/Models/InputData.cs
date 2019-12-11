using System;
using System.Collections.Generic;
using System.Text;

namespace IntcodeInterpreter.Models
{
    public class InputData
    {
        private int _index;
        private readonly long[] _list;

        public InputData()
        {
            _list = new long[] { };
            _index = 0;
        }

        public InputData(long input)
        {
            _list = new long[] { input };
            _index = 0;
        }

        public InputData(long[] list)
        {
            _list = list;
            _index = 0;
        }

        public long Next()
        {
            return _list[_index++];
        }

        public bool HasMore()
        {
            return _list.Length > _index;
        }
    }
}
