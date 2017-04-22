using GoogleCodeJam.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam2017.QualificationRound.ProblemC
{
	public class Solver
	{
		public string Resolve(string input)
		{
			var lines = input.ToLines().ToList();
			lines.RemoveAt(0);

			var results = lines.Select(line =>
			{
				var chunks = line.ToChunks();
				var stalls = long.Parse(chunks[0]);
				var people = long.Parse(chunks[1]);

				var space = new SortedSet<long>();
				var count = new Dictionary<long, long>();

				space.Add(stalls);
				count[stalls] = 1;

				long max = 0, min = 0;
				while (people > 0)
				{
					if (space.Count == 0)
						return "0 0";

					var current = space.Last();
					space.Remove(current);

					max = min = current / 2;
					if (current % 2 == 0)
						min--;

					var cnt = count[current];
					count[current] = 0;
					people -= cnt;

					if (max != 0)
					{
						space.Add(max);
						count.Update(max, x => x + cnt);
					}

					if (min != 0)
					{
						space.Add(min);
						count.Update(min, x => x + cnt);
					}
				}

				return $"{max} {min}";
			});

			var output = results
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}
	}
}