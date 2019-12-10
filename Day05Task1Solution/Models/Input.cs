using System;
using System.Collections.Generic;
using System.Text;

namespace Day05Task1Solution.Models
{
    public class Input
    {
        private int _index;
        private readonly long[] _list;

        public Input()
        {
            _list = new long[] { };
            _index = 0;
        }

        public Input(long input)
        {
            _list = new long[] { input };
            _index = 0;
        }

        public Input(long[] list)
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
