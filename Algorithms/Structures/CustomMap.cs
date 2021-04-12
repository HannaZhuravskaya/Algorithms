using System;
using System.Collections.Generic;
using System.Linq;

public class CustomMap<TK, TV>
{
    private class MapNode
    {
        public MapNode(TK key, TV value)
        {
            Key = key;
            Value = value;
        }

        public MapNode? Next {get;set;}
        public TK Key {get;}
        public TV Value {get;}
    }

    private int _size;
    private int _capacity;
    private List<MapNode?> _bucketList;

    public int Size => _size;

    public bool IsEmpty => _size == 0;

    public CustomMap()
    {
        _capacity = 64;
        _bucketList = new (_capacity);
        _bucketList.AddRange(Enumerable.Repeat(default(MapNode?), _capacity));
    }

    public void Add(TK key, TV value)
    {
        var index = GetHashCode(key);
        var node = new MapNode(key, value);

        if(_bucketList[index] is not null)
            node.Next = _bucketList[index];
        else
            ++_size;
           
        _bucketList[index] = node;
    }

    private int GetHashCode(TK key)
    {
        if(key is null)
           throw new ArgumentException(); 

        return ((key.GetHashCode() % _capacity) + _capacity) % _capacity;
    }

    public TV? Remove(TK key)
    {
        var index = GetHashCode(key);
    
        var curr = _bucketList[index];
        if(curr is null)
            return default(TV);

        if(curr.Key!.Equals(key))
        {
            var value = curr.Value;
            _bucketList[index] = null;

            if(_bucketList[index] is null)
                --_size;
            return value;
        }
    
        var prev = curr;
        curr = prev.Next;

        while(curr is not null)
        {
            if(curr.Key!.Equals(key))
            {
                --_size;
                var value = curr.Value;
                prev.Next = curr.Next;
                return value;
            }
            
            prev = curr;
            curr = curr.Next;
        }
           
        return default(TV);
    }

    public TV? Get(TK key)
    {
        var index = GetHashCode(key);
    
        if(_bucketList[index] is null)
            return default(TV);

        var curr = _bucketList[index];

        while(curr is not null)
        {
            if(curr.Key!.Equals(key))
                return curr.Value;
            
            curr = curr.Next;
        }
           
        return  default(TV);
    }
}