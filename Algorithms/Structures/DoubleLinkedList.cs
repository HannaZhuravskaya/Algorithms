using System;

public class DoubleLinkedList<T> where T: struct
{
    private Node? _head;
    private Node? _tail;
    private int _cnt;

    public int Count => _cnt;

    public void PushBack(T value)
    {
        ++_cnt;

        var node = new Node(value);

        if(_tail is null)
        {
            _head = _tail = node;
            return;
        }
        
        _tail.Next = node;
        node.Prev = _tail;
        _tail = node;

    }

    public void PushFront(T value)
    {
        ++_cnt;

         var node = new Node(value);

        if(_head is null)
        {
            _head = _tail = node;
            return;
        }
        
        _head.Prev = node;
        node.Next = _head;
        _head = node;
    }

    public T PopBack()
    {
        if(_tail is null)
            throw new ArgumentOutOfRangeException();

        --_cnt;

        var value = _tail.Value;
        _tail = _tail.Prev;

        if(_tail is not null)
            _tail.Next = null;

        return value;
    }

    public T PopFront()
    {
        if(_head is null)
            throw new ArgumentOutOfRangeException();

        --_cnt;

        var value = _head.Value;
        _head = _head.Next;

        if(_head is not null)
            _head.Prev = null;

        return value;
    }

    private class Node
    {
        public Node(T value) => Value = value;

        public T Value {get;}
        public Node? Next {get;set;}
        public Node? Prev {get;set;}
    }
}