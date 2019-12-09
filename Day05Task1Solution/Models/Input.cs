using System;
using System.Collections.Generic;
using System.Text;

namespace Day05Task1Solution.Models
{
    public class Input
    {
        private int _index;
        private readonly int[] _list;

        public Input(int input)
        {
            _list = new int[] { input };
            _index = 0;
        }

        public Input(int[] list)
        {
            _list = list;
            _index = 0;
        }

        public int Next()
        {
            return _list[_index++];
        }

        public bool HasMore()
        {
            return _list.Length > _index;
        }
    }
}
