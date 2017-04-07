using System;
using System.Collections.Generic;
using GoogleCodeJam.Helpers;

namespace GoogleCodeJam.Graphs.BackTrackings
{
	/// <summary>
	/// A backtracking algorithm running over a simple tree graph, without any cross or back edges.
	/// </summary>
	/// <typeparam name="TState">The state at each node.</typeparam>
	public class TreeBackTracking<TState>
	{
		public Func<ITreeGraphNode<TState>, IEnumerable<TState>> Expand { get; }
		public Func<ITreeGraphNode<TState>, bool> Evaluate { get; }
		public Action<ITreeGraphNode<TState>> Collapse { get; }

		private readonly TState _initState;
		private readonly ISet<ITreeGraphNode<TState>> _evaluatedNodes = new HashSet<ITreeGraphNode<TState>>();

		public TreeBackTracking(
			Func<ITreeGraphNode<TState>, IEnumerable<TState>> expand = null,
			Func<ITreeGraphNode<TState>, bool> evaluate = null,
			Action<ITreeGraphNode<TState>> collapse = null)
		{
			Expand = expand;
			Evaluate = evaluate;
			Collapse = collapse;
		}

		public TreeBackTracking(
			TState initState,
			Func<ITreeGraphNode<TState>, IEnumerable<TState>> expand = null,
			Func<ITreeGraphNode<TState>, bool> evaluate = null,
			Action<ITreeGraphNode<TState>> collapse = null)
			: this(expand, evaluate, collapse)
		{
			_initState = initState;
		}

		public TState Start()
		{
			return Start(_initState);
		}

		public TState Start(TState initState)
		{
			var root = new TreeGraphNode<TState>(initState);
			return Process(root);
		}

		protected TState Process(ITreeGraphNode<TState> node)
		{
			if (_evaluatedNodes.Contains(node))
			{
				Collapse?.Invoke(node);
				return node.Payload;
			}

			var result = Evaluate?.Invoke(node) ?? false;
			if (result)
				return node.Payload;

			_evaluatedNodes.Add(node);

			var children = Expand?.Invoke(node).Iterable();
			foreach (var child in children)
			{
				node = new TreeGraphNode<TState>(node, child);
				node.Payload = Process(node);
			}
		}
	}
}
