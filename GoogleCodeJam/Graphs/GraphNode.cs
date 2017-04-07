using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam.Graphs
{
	public interface IGraphNode<out T>
	{
		T Payload { get; set; }
		bool IsEvaluated { get; set; }
		IGraphNode<T> Parent { get; }
		IEnumerable<IGraphNode<T>> Parents { get; }
	}

	public class GraphNode<T> : IGraphNode<T>
	{
		public T Payload { get; internal set; }
		public IGraphNode<T> Parent => Parents.FirstOrDefault();
		public IEnumerable<IGraphNode<T>> Parents { get; protected set; }

		public GraphNode(T payload)
		{
			Payload = payload;
		}

		public GraphNode(T payload, IGraphNode<T> parent)
			: this(payload)
		{
			SetParents(parent);
		}

		public GraphNode(IGraphNode<T> parent)
		{
			SetParents(parent);
		}

		public GraphNode(T payload, IEnumerable<IGraphNode<T>> parents)
			: this(payload)
		{
			SetParents(parents);
		}

		public GraphNode(IEnumerable<IGraphNode<T>> parents)
		{
			SetParents(parents);
		}

		protected void SetParents(IEnumerable<IGraphNode<T>> parents)
		{
			Parents = parents.ToArray();
		}

		protected void SetParents(params IGraphNode<T>[] parents)
		{
			Parents = parents ?? new IGraphNode<T>[0];
		}
	}
}
