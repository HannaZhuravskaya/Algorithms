using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Custom
{
    public class GetTopUsersTask
    {
        public List<string> GetTopUsers(List<string> logs, int k)
        {
            var usersDict = new Dictionary<string, int>();

            // Create users dict
            foreach (var log in logs)
            {
                var userWithMessageWords = GetUserWithWrittenWotds(log);

                if (usersDict.ContainsKey(userWithMessageWords.user))
                {
                    usersDict[userWithMessageWords.user] = usersDict[userWithMessageWords.user] + userWithMessageWords.cnt;
                }
                else
                {
                    usersDict[userWithMessageWords.user] = userWithMessageWords.cnt;
                }
            }

            if (k >= usersDict.Count)
                return usersDict.Select(data => data.Key).ToList();

            // Error: forget pass k as param 
            //    return GetTopUsersWithMaxHeap(usersDict);
            //    return GetTopUsersWithMinHeap(usersDict);
            return GetTopUsersWithMinHeap(usersDict, k);
        }

        // Error: forget pass k as param
        // private List<string> GetTopUsersWithMaxHeap(Dictionary<string, int> usersDict)
        private List<string> GetTopUsersWithMaxHeap(Dictionary<string, int> usersDict, int k)
        {
            var topUsers = new List<string>();
            var maxHeap = new MaxHeap(usersDict);

            for (int i = 0; i < k; ++i)
            {
                topUsers.Add(maxHeap.ExtractMax());
            }

            return topUsers;
        }

        // Error: forget pass k as param
        // private List<string> GetTopUsersWithMinHeap(Dictionary<string, int> usersDict)
        private List<string> GetTopUsersWithMinHeap(Dictionary<string, int> usersDict, int k)
        {
            var topUsers = new List<string>();
            // Error capacity as param
            //var minHeap = new MinHeap();
            var minHeap = new MinHeap(k);

            int cnt = 0;
            foreach (var data in usersDict)
            {
                if (cnt < k)
                {
                    minHeap.Add(data);
                    ++cnt;
                }
                else if (minHeap.GetMinValue() < data.Value)
                {
                    minHeap.ExtractMin();
                    minHeap.Add(data);
                }
                else if (minHeap.GetMinValue() == data.Value)
                {
                    // TODO: add rule to check user_name priority
                }
            }

            for (int i = 0; i < k; ++i)
            {
                topUsers.Add(minHeap.ExtractMin());
            }

            return topUsers;
        }


        // Error: method actually doesn't work as expected. Generate empty strings in word array. 
        // Not the most important think, but should be rewritten.
        private (string user, int cnt) GetUserWithWrittenWotds(string log) // "[10:39] <john> hello there!"
        {
            // Error: instead of string.Split(..., log) -> log.Split(...)
            // var data = string.Split('<', log); 
            // data = string.Split('>', data[1]); 
            var data = log.Split('<'); // ["[10:39] ", "john> hello there!"]
            data = data[1].Split('>'); // ["john", " hello there!"]
            var userName = data[0]; // "john"
            var message = data[1]; // " hello there!"

            // Error: instead split "!#@%" -> new char[] { ... }
            // var words = string.Split("!@#$%^&*(){},./?1234567890 ", message);
            var words = message.Split(
                new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', ',', '.', '/', '?', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ' }); // ["hello", "there"]

            // Error: words is an array, instead of Count use Length
            // Error: initialize Tuple with constructor, do not use params names
            // return new(user: userNmae, cnt: words.Count);

            // hello123 a12 fgd!gdf -> ["hello", "a", "fgd", "gdf"]
            return new(userName, words.Length);
        }

        #region MaxHeap
        /*      
        Notes: Used right description of structure and operations complexity

            private class MaxHeap
            {
                // Create a max heap, that works on array -> O(N)
                public MaxHeap(Dictionary<string, int> data) { }

                // return the max value -> O(1)
                public string GetMax() { }

                // O(logN)
                public string ExtractMax() { }
            }
        */

        // Implemented MaxHeap to test main task
        private class MaxHeap
        {
            private KeyValuePair<string, int>[] _elements;
            private int _size;
            private int _capacity;
            private KeyValuePair<string, int> _maxValue = new(string.Empty, int.MaxValue);

            // Create a max heap, that works on array -> O(N)
            public MaxHeap(Dictionary<string, int> data)
            {
                _elements = new KeyValuePair<string, int>[data.Count];
                _capacity = _size = data.Count;

                var cnt = 0;
                foreach (var d in data)
                    _elements[cnt++] = d;

                for (int i = (_elements.Length / 2) - 1; i >= 0; --i)
                    Heapify(i);
            }

            // return the max value -> O(1)
            public string GetMax() => _elements[0].Key;

            // O(logN)
            public string ExtractMax()
            {
                if (_size == 0)
                    throw new InvalidOperationException();

                if (_size == 1)
                {
                    _size = 0;
                    return _elements[0].Key;
                }

                var result = GetMax();
                _elements[0] = _elements[_size - 1];
                _size--;

                Heapify(0);

                return result;
            }

            private int GetParent(int index) => (index - 1) / 2;
            private int GetFirstChild(int index) => 2 * index + 1;
            private int GetSecondChild(int index) => 2 * index + 2;

            private void Heapify(int index)
            {
                var left = GetFirstChild(index);
                var right = GetSecondChild(index);

                var max = index;

                if (left < _size && _elements[left].Value > _elements[max].Value)
                    max = left;

                if (right < _size && _elements[right].Value > _elements[max].Value)
                    max = right;

                if (_elements[index].Value < _elements[max].Value)
                {
                    Swap(ref _elements[index], ref _elements[max]);
                    Heapify(max);
                }
            }

            private static void Swap(ref KeyValuePair<string, int> first, ref KeyValuePair<string, int> second)
            {
                var temp = first;
                first = second;
                second = temp;
            }
        }

        #endregion

        #region MinHeap
        /*      
        Notes: Some typos in description [MinHeap instead of MaxHeap, constructor with size instead of array, GetMinValue()]

            private class MinHeap
            {
                // Create a max heap, that works on array -> O(N)
                public MaxHeap(Dictionary<string, int> data) { }

                // return the max value -> O(1)
                public string GetMin() { }

                // O(logN)
                public string ExtractMin() { }
            }
        */

        // Implemented MaxHeap to test main task
        private class MinHeap
        {
            private KeyValuePair<string, int>[] _elements;
            private int _size;
            private int _capacity;
            private KeyValuePair<string, int> _minValue = new(string.Empty, int.MinValue);

            public MinHeap(int size)
            {
                _elements = new KeyValuePair<string, int>[size];
                _capacity = size;
                _size = 0;
            }

            // return the min value -> O(1)
            public string GetMin() => _elements[0].Key;

            public int GetMinValue() => _elements[0].Value;

            // O(logN)
            public string ExtractMin()
            {
                if (_size == 0)
                    throw new InvalidOperationException();

                if (_size == 1)
                {
                    _size = 0;
                    return _elements[0].Key;
                }

                var result = GetMin();
                _elements[0] = _elements[_size - 1];
                _size--;

                Heapify(0);

                return result;
            }

            public void Add(KeyValuePair<string, int> data)
            {
                if (_size == _capacity || data.Value.Equals(_minValue))
                    throw new ArgumentOutOfRangeException();

                _elements[_size] = data;

                var parentIndex = GetParent(_size);
                var childIndex = _size;

                while (parentIndex >= 0 && _elements[parentIndex].Value > _elements[childIndex].Value)
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

                if (left < _size && _elements[left].Value < _elements[min].Value)
                    min = left;

                if (right < _size && _elements[right].Value < _elements[min].Value)
                    min = right;

                if (_elements[index].Value > _elements[min].Value)
                {
                    Swap(ref _elements[index], ref _elements[min]);
                    Heapify(min);
                }
            }

            private static void Swap(ref KeyValuePair<string, int> first, ref KeyValuePair<string, int> second)
            {
                var temp = first;
                first = second;
                second = temp;
            }
        }

        #endregion

        #region Tests Cases
        public static void Test()
        {
            var obj = new GetTopUsersTask();
            var data = new List<string>(){
                "[10:39] <user 1>one two",
                "[10:39:1256] <user 1>three four five six seven",
                "[10:39] <user 3>one",
                "[10:39] <user 4>one two",
                "[10:39] <user 2>o t t f f s s e n t",
            };

            var res = obj.GetTopUsers(data, 2);
        }
        #endregion
    }
}