using System;
using System.Collections.Generic;
using System.Linq;

namespace IntcodeInterpreter.Models
{
    internal class InputData
    {
        private int _index;
        private readonly List<long> _list;

        internal InputData()
        {
            _list = new List<long>();
            _index = 0;
        }

        internal void Add(params long[] list)
        {
            _list.AddRange(list);
        }

        internal void Set(params long[] list)
        {
            _list.Clear();
            Add(list);
        }

        internal void Restart()
        {
            _index = 0;
        }

        internal long Next()
        {
            if (_index >= _list.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return _list[_index++];
        }

        internal bool HasMore()
        {
            return _list.Count > _index;
        }
    }
}
