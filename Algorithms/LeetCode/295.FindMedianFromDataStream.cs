#nullable disable

using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class MedianFinder
    {
        private PriorityQueue _left = new PriorityQueue(false);
        private PriorityQueue _right = new PriorityQueue(true);
        private bool _even = true;

        public void AddNum(int num)
        {
            if (_even)
            {
                _right.Add(num);
                _left.Add(_right.Extract());
            }
            else
            {
                _left.Add(num);
                _right.Add(_left.Extract());
            }

            _even = !_even;
        }

        public double FindMedian() => _even ? (double)(_left.Peek() + _right.Peek()) / 2.0 : _left.Peek();

        #region PriorityQueue
        private class PriorityQueue
        {
            private List<int> _elements = new List<int>();
            private int _size;
            private bool _maxHeap;

            public PriorityQueue(bool maxHeap = true)
            {
                _maxHeap = maxHeap;
            }

            public void Add(int value)
            {
                if (_size == _elements.Count)
                    _elements.Add(default);

                _elements[_size] = value;

                var parentIndex = GetParent(_size);
                var childIndex = _size;

                while (parentIndex >= 0 && ShouldBeParent(childIndex, parentIndex))
                {
                    Swap(parentIndex, childIndex);
                    childIndex = parentIndex;
                    parentIndex = GetParent(childIndex);
                }

                ++_size;
            }

            public int Extract()
            {
                if (_size == 0)
                    throw new InvalidOperationException();

                if (_size == 1)
                {
                    _size = 0;
                    return _elements[0];
                }

                var result = Peek();
                _elements[0] = _elements[_size - 1];
                _size--;

                Heapify(0);

                return result;
            }

            public int Peek() => _size >= 0 ? _elements[0] : throw new InvalidOperationException();

            private int GetParent(int index) => (index - 1) / 2;
            private int GetFirstChild(int index) => 2 * index + 1;
            private int GetSecondChild(int index) => 2 * index + 2;

            private void Swap(int first, int second)
            {
                var temp = _elements[first];
                _elements[first] = _elements[second];
                _elements[second] = temp;
            }

            private void Heapify(int index)
            {
                var left = GetFirstChild(index);
                var right = GetSecondChild(index);

                var root = index;

                if (left < _size && ShouldBeParent(left, root))
                    root = left;

                if (right < _size && ShouldBeParent(right, root))
                    root = right;

                if (ShouldBeParent(root, index))
                {
                    Swap(index, root);
                    Heapify(root);
                }
            }

            private bool ShouldBeParent(int childIndex, int parentIndex)
            {
                var comp = _elements[parentIndex].CompareTo(_elements[childIndex]);
                return _maxHeap ? comp < 0 : comp > 0;
            }

        }
        #endregion
    }
}