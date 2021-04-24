namespace Algorithms.LeetCode
{
    public class MyCircularQueue
    {
        private int[] _queue;
        private int _head;
        private int _tail;
        private int _size;

        public MyCircularQueue(int k)
        {
            _queue = new int[k];
            _head = _tail = _size = 0;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            _queue[_tail] = value;
            _tail = (_tail + 1 + _queue.Length) % _queue.Length;

            ++_size;

            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
                return false;

            _head = (_head + 1 + _queue.Length) % _queue.Length;
            --_size;

            return true;
        }

        public int Front() => IsEmpty() ? -1 : _queue[_head];

        public int Rear() => IsEmpty() ? -1 : _queue[(_tail - 1 + _queue.Length) % _queue.Length];

        public bool IsEmpty() => _size == 0;

        public bool IsFull() => _size == _queue.Length;
    }
}