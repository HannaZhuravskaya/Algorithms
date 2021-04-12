using System.Collections.Generic;

public class Trie {
    private class Node
    {
        public Node()
        {
            Nodes = new Node[26];
        }

        public bool IsWord {get; set;}
        public Node?[] Nodes {get;}
    }

    private Node _root;

    public Trie() 
    {
        _root = new Node();
    }
    
    public void Insert(string word) {
        var cnt = 0;

        Node cur = _root;

        while(cnt < word.Length)
        {
            var pos = word[cnt] - 'a';
               
            if(cur.Nodes[pos] is null)
                cur.Nodes[pos] = new Node();
            
            cur = cur.Nodes[pos]!;
            ++cnt;
        }

        cur.IsWord = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        var cnt = 0;
        Node cur = _root;

        while(cnt < word.Length)
        {
            var pos = word[cnt] - 'a';
               
            if(cur.Nodes[pos] is null)
                return false;
            
            cur = cur.Nodes[pos]!;
            ++cnt;
        }

        return cur.IsWord;
    }
    
    public bool StartsWith(string prefix) {
        var cnt = 0;
        Node cur = _root;

        while(cnt < prefix.Length)
        {
            var pos = prefix[cnt] - 'a';
               
            if(cur.Nodes[pos] is null)
                return false;
            
            cur = cur.Nodes[pos]!;
            ++cnt;
        }

        return FindWords(cur);
    }

    public List<string> GetWordsStartsWith(string prefix) {
        var cnt = 0;
        Node cur = _root;

        var words = new List<string>();

        while(cnt < prefix.Length)
        {
            var pos = prefix[cnt] - 'a';
               
            if(cur.Nodes[pos] is null)
                return words;
            
            cur = cur.Nodes[pos]!;
            ++cnt;
        }

        FindWords(cur, words, prefix);

        return words;
    }

    private void FindWords(Node? node, List<string> words, string prefix)
    {
        if(node is null)
            return;

        if(node.IsWord)
            words.Add(prefix);

        for(int i = 0; i <  node.Nodes.Length; ++i){
            char ch = (char)(i + 'a');
            FindWords(node.Nodes[i], words, prefix + ch);
        }
    }

    
    private bool FindWords(Node? node)
    {
        if(node is null)
            return false;

        if(node.IsWord)
            return true;

        foreach(var childNode in node.Nodes){
            if(FindWords(childNode))
                return true;
        }

        return false;
    }
}