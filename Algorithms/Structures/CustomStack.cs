using System;

namespace Algorithms.Structures
{
    /*
                 Time Complexity	                                                       Space Complexity
                     Average	                            Worst	                            Worst
           Access	Search	Insertion	Deletion	Access	Search	Insertion	Deletion
    Stack	Θ(n)	Θ(n)	  Θ(1)	      Θ(1)	     O(n)	  O(n)	  O(1)	      O(1)	         O(n)
    */

    public class CustomStack<T> where T : struct
    {
        private Node? _last = null;

        public void Push(T value)
        {
            var node = new Node(value);

            if (_last is not null)
                node.Prev = _last;

            _last = node;
        }

        public T Pop()
        {
            if (_last is null)
                throw new ArgumentOutOfRangeException();

            var value = _last.Value;

            _last = _last.Prev;

            return value;
        }

        private class Node
        {
            public Node(T value) => Value = value;

            public T Value { get; }
            public Node? Prev { get; set; }
        }
    }
}