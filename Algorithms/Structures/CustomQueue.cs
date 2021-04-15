using System;

namespace Algorithms.Structures
{
    /*
                 Time Complexity	                                                       Space Complexity
                     Average	                            Worst	                            Worst
           Access	Search	Insertion	Deletion	Access	Search	Insertion	Deletion
    Queue	Θ(n)	Θ(n)	  Θ(1)	      Θ(1)	     O(n)	  O(n)	  O(1)     	  O(1)	         O(n)
    */

    public class CustomQueue<T> where T : struct
    {
        private Node? _first;
        private Node? _last;

        public void Enqueue(T value)
        {
            var node = new Node(value);

            if (_last is not null)
                _last.Next = node;

            _last = node;

            if (_first is null)
                _first = node;
        }

        public T Dequeue()
        {
            if (_first is null)
                throw new ArgumentOutOfRangeException();

            var value = _first.Value;

            _first = _first.Next;

            return value;
        }

        private class Node
        {
            public Node(T value) => Value = value;

            public T Value { get; }
            public Node? Next { get; set; }
        }
    }
}