using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam.Graphs.BackTrackings
{
	public interface ITreeGraphNode<TPayload>
	{
		TPayload Payload { get; set; }
		ITreeGraphNode<TPayload> Parent { get; }
	}

	public class TreeGraphNode<TPayload> : ITreeGraphNode<TPayload>
	{
		public TPayload Payload { get; set; }
		public ITreeGraphNode<TPayload> Parent { get; }

		public TreeGraphNode(ITreeGraphNode<TPayload> parent)
		{
			Parent = parent;
		}

		public TreeGraphNode(ITreeGraphNode<TPayload> parent, TPayload payload)
		{
			Parent = parent;
			Payload = payload;
		}

		public TreeGraphNode(TPayload payload)
		{
			Payload = payload;
		}
	}
}
