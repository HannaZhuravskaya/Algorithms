using System;
using System.Collections.Generic;
using FluentAssertions;

public class MapSum
{
    private TrieNode _root;

    public MapSum()
    {
        _root = new TrieNode();
    }

    public void Insert(string key, int val)
    {
        var cur = _root;
        for (var i = 0; i < key.Length; ++i)
        {
            var child = cur.GetChild(key[i]);
            if (child is null)
            {
                child = new TrieNode(key[i], i == key.Length - 1 ? val : (int?)null, i == key.Length - 1);
                cur.Children.AddLast(child);
            }
            else if (i == key.Length - 1)
            {
                child.Value = val;
                child.IsWord = true;
            }

            cur = child;
        }
    }

    public int Sum(string prefix)
    {
        var cur = _root;
        for (var i = 0; i < prefix.Length; ++i)
        {
            var child = cur.GetChild(prefix[i]);
            if (child is null)
                return 0;

            cur = child;
        }

        var max = FindAllWordsSum(cur);
        return max;
    }

    private int FindAllWordsSum(TrieNode? node)
    {
        var result = 0;

        if (node is null)
            return 0;

        foreach (var child in node.Children)
        {
            result += FindAllWordsSum(child);
        }

        if (node.IsWord && node.Value.HasValue)
            result += node.Value.Value;

        return result;
    }

    private class TrieNode
    {
        public TrieNode(char? key = null, int? value = null, bool isWord = false)
        {
            Key = key;
            Value = value;
            IsWord = isWord;
            Children = new LinkedList<TrieNode>();
        }
        public char? Key;
        public int? Value;
        public bool IsWord;
        public LinkedList<TrieNode> Children;

        public TrieNode? GetChild(char letter)
        {
            foreach (var child in Children)
            {
                if (child.Key == letter)
                    return child;
            }

            return null;
        }
    }

    public static void Check()
    {
        var obj = new MapSum();
        obj.Insert("apple", 3);
        obj.Sum("ap").Should().Be(3);
        obj.Insert("app", 2);
        obj.Sum("ap").Should().Be(5);

        obj = new MapSum();
        obj.Insert("apple", 3);
        obj.Sum("ap").Should().Be(3);
        obj.Insert("app", 2);
        obj.Insert("apple", 2);
        obj.Sum("ap").Should().Be(4);

        obj = new MapSum();
        obj.Insert("aa", 3);
        obj.Sum("a").Should().Be(3);
        obj.Insert("ab", 2);
        obj.Sum("a").Should().Be(5);
    }
}
