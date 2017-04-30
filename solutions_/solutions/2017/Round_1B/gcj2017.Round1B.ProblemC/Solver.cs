using GoogleCodeJam.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace gcj2017.Round1B.ProblemC
{
	public class Solver
	{
		public string Resolve(string input)
		{
			var lines = input.ToLines().ToList();
			lines.RemoveAt(0);

			var results = new List<string>();

			var output = results
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}

		public class State
		{
			public State()
			{
			}
		}
	}
}