using System;

namespace Algorithms.LeetCode
{
    public class KthSmallestElementInSortedMatrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            var n = matrix.Length;

            var heap = new MinHeap(n);

            for (int i = 0; i < n; ++i)
            {
                heap.Add((0, i, matrix[0][i]));
            }

            for (int i = 0; i < k - 1; ++i)
            {
                var value = heap.ExtractMin();

                if (value.x == n - 1)
                    continue;

                heap.Add((value.x + 1, value.y, matrix[value.x + 1][value.y]));
            }

            return heap.GetMin().value;
        }


        #region MinHeap
        private class MinHeap
        {
            private (int x, int y, int value)[] _elements;
            private int _size;
            private int _capacity;

            public MinHeap(int size)
            {
                _elements = new (int x, int y, int value)[size];
                _capacity = size;
                _size = 0;
            }

            // return the min value -> O(1)
            public (int x, int y, int value) GetMin() => _elements[0];

            // O(logN)
            public (int x, int y, int value) ExtractMin()
            {
                if (_size == 0)
                    throw new InvalidOperationException();

                if (_size == 1)
                {
                    _size = 0;
                    return _elements[0];
                }

                var result = GetMin();
                _elements[0] = _elements[_size - 1];
                _size--;

                Heapify(0);

                return result;
            }

            public void Add((int x, int y, int value) data)
            {
                if (_size == _capacity || data.value.Equals(int.MinValue))
                    throw new ArgumentOutOfRangeException();

                _elements[_size] = data;

                var parentIndex = GetParent(_size);
                var childIndex = _size;

                while (parentIndex >= 0 && _elements[parentIndex].value > _elements[childIndex].value)
                {
                    Swap(ref _elements[parentIndex], ref _elements[childIndex]);
                    childIndex = parentIndex;
                    parentIndex = GetParent(childIndex);
                }

                ++_size;
            }

            private int GetParent(int index) => (index - 1) / 2;
            private int GetFirstChild(int index) => 2 * index + 1;
            private int GetSecondChild(int index) => 2 * index + 2;

            private void Heapify(int index)
            {
                var left = GetFirstChild(index);
                var right = GetSecondChild(index);

                var min = index;

                if (left < _size && _elements[left].value < _elements[min].value)
                    min = left;

                if (right < _size && _elements[right].value < _elements[min].value)
                    min = right;

                if (_elements[index].value > _elements[min].value)
                {
                    Swap(ref _elements[index], ref _elements[min]);
                    Heapify(min);
                }
            }

            private static void Swap(ref (int x, int y, int value) first, ref (int x, int y, int value) second)
            {
                var temp = first;
                first = second;
                second = temp;
            }
        }
        #endregion
    }
}