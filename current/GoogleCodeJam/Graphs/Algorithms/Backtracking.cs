using GoogleCodeJam.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam.Graphs.Algorithms
{
	public class Backtracking<T>
	{
		private readonly Func<IGraphNode<T>, IEnumerable<T>> _expand;
		private readonly Func<IGraphNode<T>, bool> _evaluate;
		private readonly Action<IGraphNode<T>> _backtrack;

		public Backtracking(
			Func<IGraphNode<T>, IEnumerable<T>> expand = null,
			Func<IGraphNode<T>, bool> evaluate = null,
			Action<IGraphNode<T>> backtrack = null)
		{
			_expand = expand;
			_evaluate = evaluate;
			_backtrack = backtrack;
		}

		public IGraphNode<T> Begin(T root)
		{
			var current = new GraphNode<T>(root);
			return FindFirst(current);
		}

		private IGraphNode<T> FindFirst(IGraphNode<T> root)
		{
			var stack = new Stack<IEnumerator<IGraphNode<T>>>();

			var enumerator = new[] {root}.ToList().GetEnumerator();
			stack.Push(enumerator);

			while (stack.Count != 0)
			{
				var items = stack.Peek();
				if (!items.MoveNext())
				{
					items.Dispose();
					stack.Pop();

					if (items.Current != null)
						_backtrack?.Invoke(items.Current);

					continue;
				}

				var current = items.Current;
				if (IsFound(current))
					return current;

				var children = GetChildren(current);
				stack.Push(children.GetEnumerator());
			}

			return null;
		}

		private bool IsFound(IGraphNode<T> node) => _evaluate?.Invoke(node) ?? false;

		private IEnumerable<IGraphNode<T>> GetChildren(IGraphNode<T> node)
		{
			if (node == null)
				yield break;

			var items = _expand?.Invoke(node);
			foreach (var item in items.Iterable())
				yield return new GraphNode<T>(node, item);
		}
	}
}