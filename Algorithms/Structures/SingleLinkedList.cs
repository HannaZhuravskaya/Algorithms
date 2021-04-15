using System;

namespace Algorithms.Structures
{
    public class SingleLinkedList<T> where T : struct
    {
        private Node? _head;
        private int _cnt;

        public int Count => _cnt;

        public void Insert(T value)
        {
            var node = new Node(value) { Next = _head };
            _head = node;
            ++_cnt;
        }

        public T Remove()
        {
            if (_head is null)
                throw new ArgumentOutOfRangeException();

            --_cnt;
            var value = _head.Value;
            _head = _head.Next;
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