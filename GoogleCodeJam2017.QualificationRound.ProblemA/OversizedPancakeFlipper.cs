using GoogleCodeJam.Graphs.Algorithms;
using GoogleCodeJam.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam2017.QualificationRound.ProblemA
{
	public class OversizedPancakeFlipper
	{
		public string Resolve(string input)
		{
			var lines = input.ToLines().ToList();

			var testCases = int.Parse(lines[0]);
			lines.RemoveAt(0);

			var tests = lines.Select(x =>
			{
				var chunks = x.ToChunks();
				var flipperSize = int.Parse(chunks[1]);
				return new State(chunks[0], flipperSize);
			});

			var results = tests.AsParallel()
				.Select(x =>
				{
					var result = new BreadthFirstSearch<State>(
						expand: node => node.State.GetFlipPositions(),
						evaluate: node => node.State.Pancakes.All(p => p))
						.Begin(x);
					return result;
				});

			var output = results
				.Select(x => x == null ? "IMPOSSIBLE" : $"{x.Depth}")
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}

		public class State : IEquatable<State>
		{
			public bool[] Pancakes { get; }
			public int FlipperSize { get; }

			public State(string pancakes, int flipperSize)
			{
				Pancakes = pancakes.Select(x => x == '+').ToArray();
				FlipperSize = flipperSize;
			}

			protected State(bool[] pancakes, int flipperSize)
			{
				Pancakes = pancakes;
				FlipperSize = flipperSize;
			}

			public IEnumerable<State> GetFlipPositions()
			{
				for (var i = 0; i <= Pancakes.Length - FlipperSize; i++)
				{
					var pancakes = Pancakes.ToArray();
					for (var pos = 0; pos < FlipperSize; pos++)
						pancakes[pos + i] = !pancakes[pos + i];

					yield return new State(pancakes, FlipperSize);
				}
			}

			public override string ToString()
			{
				return Pancakes.Select(x => x ? "+" : "-").Join();
			}

			#region Equals

			public bool Equals(State other)
			{
				if (ReferenceEquals(null, other)) return false;
				if (ReferenceEquals(this, other)) return true;

				return Pancakes.SequenceEqual(other.Pancakes);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;

				return Equals((State) obj);
			}

			public override int GetHashCode()
			{
				return Pancakes.GetSequenceHashCode();
			}

			#endregion
		}
	}
}