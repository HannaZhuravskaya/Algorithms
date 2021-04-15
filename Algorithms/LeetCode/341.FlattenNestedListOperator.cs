public class NestedIterator
{
    private Stack<(NestedInteger, int?)> _root;
    private int? _next;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        _root = new Stack<(NestedInteger, int?)>();
        for (int i = nestedList.Count - 1; i >= 0; --i)
            _root.Push((nestedList[i], nestedList[i].IsInteger() ? (int?)null : 0));

        if (_root.Count > 0)
            _next = GetNext();
    }

    public bool HasNext()
    {
        return _next != null;
    }

    public int Next()
    {
        var result = _next.Value;
        _next = _root.Count > 0 ? GetNext() : (int?)null;
        return result;
    }

    private int? GetNext()
    {
        var (cur, index) = _root.Pop();

        if (cur.IsInteger())
            return cur.GetInteger();
        else
        {
            var list = cur.GetList();

            if (index.Value == list.Count)
                return _root.Count > 0 ? GetNext() : (int?)null;

            var elem = list[index.Value];

            index = index.Value + 1;

            if (index < list.Count)
                _root.Push((cur, index));

            if (elem.IsInteger())
            {
                return elem.GetInteger();
            }
            else
            {
                _root.Push((elem, 0));
                return GetNext();
            }
        }
    }
}

/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */