using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Algorithms.LeetCode
{
    public class PerformanceOfTeam
    {
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            var workers = new List<(int s, int e)>(n);
            for (int i = 0; i < n; i++)
            {
                workers.Add((speed[i], efficiency[i]));
            }

            workers.Sort((d1, d2) => d1.e != d2.e ? d2.e.CompareTo(d1.e) : d1.s.CompareTo(d2.s));

            BigInteger res = 0;
            BigInteger sum = 0;
            var heap = new MinHeap(new List<int>(k));

            foreach (var worker in workers)
            {
                sum += worker.s;
                heap.Push(worker.s);

                if (heap._data.Count > k)
                    sum -= heap.Pop();

                BigInteger curRes = (sum * worker.e);
                if (curRes > res)
                    res = curRes;
            }

            return (int)(res % 1000000007);
        }

        private class MinHeap
        {
            public readonly List<int> _data;

            public MinHeap(List<int> inputs)
            {
                _data = inputs;
                for (int i = _data.Count / 2; i >= 0; i--)
                {
                    Heapify(i);
                }
            }

            private void Swap(int i, int j)
            {
                var tmp = _data[i];
                _data[i] = _data[j];
                _data[j] = tmp;
            }

            private void Heapify(int i)
            {
                while (2 * i + 1 < _data.Count)
                {
                    int left = 2 * i + 1;
                    int right = 2 * i + 2;
                    int j = left;

                    if (right < _data.Count && _data[right] < _data[left])
                    {
                        j = right;
                    }

                    if (_data[i] <= _data[j])
                        break;

                    Swap(i, j);
                    i = j;
                }
            }

            public int Pop()
            {
                var top = _data[0];
                _data[0] = _data.Last();
                _data.RemoveAt(_data.Count - 1);
                Heapify(0);
                return top;
            }

            public void Push(int value)
            {
                _data.Add(value);
                int i = _data.Count - 1;
                while (_data[i] < _data[(i - 1) / 2])
                {
                    Swap(i, (i - 1) / 2);
                    i = (i - 1) / 2;
                }
            }
        }
    }
}