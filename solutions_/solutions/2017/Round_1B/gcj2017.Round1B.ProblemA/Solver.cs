using GoogleCodeJam.Helpers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GoogleCodeJam2017.Round1B.ProblemA
{
	public class Solver
	{
		public string Resolve(string input)
		{
			var lines = input.ToLines().ToList();
			lines.RemoveAt(0);

			var results = new List<string>();

			while (lines.Count != 0)
			{
				var line = lines[0];
				lines.RemoveAt(0);

				var chunks = line.ToChunks();
				var d = double.Parse(chunks[0]);
				var n = int.Parse(chunks[1]);

				var horses = lines.Take(n)
					.Collect(x =>
					{
						var c = x.ToChunks();
						return new Horse(d, double.Parse(c[0]), double.Parse(c[1]));
					});

				lines.RemoveRange(0, n);

				var min = horses.Min(x => x.Time);
				var max = horses.Max(x => x.Time);

				var result = d / max;
				results.Add(result.ToString("0.000000", CultureInfo.InvariantCulture));
			}

			var output = results
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}

		public class Horse
		{
			public double Destination { get; }
			public double Position { get; set; }
			public double Current { get; set; }
			public double Speed { get; set; }
			public double Time { get; set; }

			public Horse(double destination, double position, double speed)
			{
				Destination = destination;
				Position = position;
				Current = position;
				Speed = speed;
				Time = (Destination - Position) / Speed;
			}
		}
	}
}