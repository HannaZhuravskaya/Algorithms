using System;

public class BinarySearchTree<T> where T: struct, IComparable<T>
{
	private class Node
	{
		public Node(T value) => Value = value;
		public T Value {get; set;}
		public Node? Left {get;set;}
		public Node? Right {get; set;}
	}

	private Node? _root;

	public void Insert(T value)
	{
		var node = new Node(value);
		if(_root is null)
		{
			_root = node;
			return;
		}

		Insert(value, _root);

	}

	private void Insert (T value, Node node)
	{
		if(node.Value.Equals(value))
			return;

		if(node.Value.CompareTo( value) < 0)
		{
			if(node.Right is null)
				node.Right = new Node(value);
			else
				Insert(value, node.Right);
		}

		if(node.Value.CompareTo(value) > 0)
		{
			if(node.Left is null)
				node.Left = new Node(value);
			else
				Insert(value, node.Left);
		}
	}


	public void Delete(T value) => Delete(_root, value);

	private Node? Delete(Node? root, T value)
	{
		if(root is null)
			return root;

		if(root.Value.CompareTo(value) > 0) 
			root.Left = Delete(root.Left, value);

		else if(root.Value.CompareTo(value) < 0) 
			root.Right = Delete(root.Right, value);
		
		else
		{
			if(root.Left is null)
				return root.Right;

			else if(root.Right is null)
				return root.Left;
			
			var nodeToDelete = FindNodeToDelete(root);
			root.Value = nodeToDelete.Value;
			root.Right = Delete(root.Right, nodeToDelete.Value);
		}

		return root;
	}

	private Node FindNodeToDelete(Node node)
	{
		var cur = node.Right;

		if(cur is null)
			return node;

		while(cur.Left is not null)
			cur = cur.Left;

		return cur;
	}


	public bool Find(T value)
	{
		var curNode = _root;

		while(curNode is not null)
		{
			if(curNode.Value.CompareTo(value) == 0)
				return true;

			if(curNode.Value.CompareTo(value) > 0)
				curNode = curNode.Left;
			else
				curNode = curNode.Right;
		}
		
		return false;
	}

	public void Inorder(Action<T> action) => Inorder(_root, action);

	private void Inorder(Node? node, Action<T> action)
	{
		if(node is null)
			return;

		Inorder(node.Left, action);
		action.Invoke(node.Value);
		Inorder(node.Right, action);
	}

	public void Preorder(Action<T> action) => Preorder(_root,action);

	private void Preorder(Node? node, Action<T> action)
	{
		if(node is null)
			return;

		action.Invoke(node.Value);
		Preorder(node.Left, action);
		Preorder(node.Right, action);
	}
	
	public void Postorder(Action<T> action) => Postorder(_root, action);

	private void Postorder(Node? node, Action<T> action)
	{
		if(node is null)
			return;

		Postorder(node.Left, action);
		Postorder(node.Right, action);
		action.Invoke(node.Value);
	}
}