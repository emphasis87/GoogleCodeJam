using System;
using System.Collections.Generic;

namespace GoogleCodeJam.Graphs
{
	public interface IGraphNode<out T>
	{
		IGraphNode<T> Parent { get; }
		T State { get; }
		int Depth { get; }
	}

	public class GraphNode<T> : IGraphNode<T>, IEquatable<IGraphNode<T>>
	{
		public IGraphNode<T> Parent { get;}
		public T State { get; }

		public GraphNode(T state)
		{
			State = state;
		}

		public GraphNode(IGraphNode<T> parent, T state)
		{
			Parent = parent;
			State = state;
		}

		private int? _depth;

		public int Depth
		{
			get
			{
				// TODO cyclic depth
				if (!_depth.HasValue)
					_depth = Parent?.Depth + 1 ?? 0;

				return _depth.Value;
			}
		}

		public override string ToString()
		{
			return $"[{Depth}] {State}";
		}

		#region Equals

		public bool Equals(IGraphNode<T> other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(this, other)) return true;

			return EqualityComparer<T>.Default.Equals(State, other.State);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is IGraphNode<T>)) return false;

			return Equals((IGraphNode<T>) obj);
		}

		public override int GetHashCode()
		{
			return EqualityComparer<T>.Default.GetHashCode(State);
		}

		#endregion
	}
}