using GoogleCodeJam.Helpers;
using System;
using System.Collections.Generic;

namespace GoogleCodeJam.Graphs.Algorithms
{
	public class BreadthFirstSearch<T>
	{
		private readonly Func<IGraphNode<T>, IEnumerable<T>> _expand;
		private readonly Func<IGraphNode<T>, bool> _evaluate;

		public BreadthFirstSearch(
			Func<IGraphNode<T>, IEnumerable<T>> expand,
			Func<IGraphNode<T>, bool> evaluate)
		{
			_expand = expand;
			_evaluate = evaluate;
		}

		public IGraphNode<T> Begin(T root)
		{
			var current = new GraphNode<T>(root);
			return FindFirst(current);
		}

		private IGraphNode<T> FindFirst(IGraphNode<T> root)
		{
			var toExpand = new Queue<IEnumerable<IGraphNode<T>>>();
			toExpand.Enqueue(new[] {root});

			var resolved = new HashSet<IGraphNode<T>>();
			var nodes = Traverse(toExpand);
			foreach (var current in nodes)
			{
				if (resolved.Contains(current))
					continue;

				if (IsFound(current))
					return current;

				resolved.Add(current);
				toExpand.Enqueue(GetChildren(current));
			}

			return null;
		}

		private IEnumerable<IGraphNode<T>> Traverse(Queue<IEnumerable<IGraphNode<T>>> toExpand)
		{
			while (toExpand.Count != 0)
			{
				var current = toExpand.Dequeue();
				foreach (var node in current)
					yield return node;
			}
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