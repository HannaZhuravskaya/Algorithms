using System;
using System.Collections.Generic;

/*
Operations on Min Heap:
1) getMini():  O(1).
2) extractMin():  O(Logn) 
3) decreaseKey():  O(Logn).
4) insert(): O(Logn)
5) delete(): O(Logn) 

build from aray -> O(N)
*/
public class MaxHeap<T> where T : struct, IComparable<T>
{
	private T[] _elements;
	private int _size;
	private int _capacity;
	private T _maxValue;

	public MaxHeap(List<T> elements, T maxValue) : this(elements.Count, maxValue)
	{	
		_size = elements.Count;
		for(int i = 0 ; i < elements.Count; ++i)
			_elements[i] = elements[i];
	
		for(int i = (_elements.Length / 2 ) - 1; i >= 0; --i)
			Heapify(i);
	}
	
	public MaxHeap(int size, T maxValue)
	{
		_elements = new T[size];
		_size = 0;
		_capacity = size;
		_maxValue = maxValue;
	}
	
	public T MaxValue => _elements[0];
	
	public void Insert(T value)
	{
		if(_size == _capacity || value.Equals(_maxValue) )
			throw new ArgumentOutOfRangeException();

		_elements[_size] = value;

		var parentIndex = GetParent(_size);
		var childIndex= _size;

		while(parentIndex >= 0 && _elements[parentIndex].CompareTo(_elements[childIndex]) < 0)
		{
			Swap(ref _elements[parentIndex], ref _elements[childIndex]);
			childIndex = parentIndex;
			parentIndex = GetParent(childIndex);
		}

		++_size;	
	}

	public void Delete(int key)
	{
		IncreaseValue(key, _maxValue);
		ExtractMax();
	}

	public T ExtractMax()
	{
		if(_size == 0)
			throw new InvalidOperationException();

		if(_size == 1)
		{
			_size = 0;
			return _elements[0];
		}


		var result = MaxValue;
		_elements[0] = _elements[_size - 1];
		_size--;

		Heapify(0);

		return result;
	}

	public void IncreaseValue(int index, T to)
	{
		_elements[index] = to;
		
		var parentIndex = GetParent(index);
		var childIndex= index;

		while(parentIndex != 0 && _elements[parentIndex].CompareTo(_elements[childIndex]) < 0)
		{
			Swap(ref _elements[parentIndex], ref _elements[childIndex]);
			childIndex = parentIndex;
			parentIndex = GetParent(childIndex);
		}
	}

	private int GetParent(int index) => (index-1) / 2;
	private int GetFirstChild(int index) => 2 * index + 1;
	private int GetSecondChild(int index) => 2 * index + 2;

	private void Heapify(int index)
	{
		var left = GetFirstChild(index);
		var right = GetSecondChild(index);
		
		var max = index;

		if(left < _size && _elements[left].CompareTo(_elements[max]) > 0)
			max = left;

		if(right < _size && _elements[right].CompareTo(_elements[max]) > 0)
			max = right;

		if(_elements[index].CompareTo( _elements[max]) < 0)
		{
			Swap(ref _elements[index], ref _elements[max]);
			Heapify(max);
		}
	}

	private static void Swap(ref T first, ref T second)
	{
		var temp = first;
		first = second;
		second = temp;
	}
}