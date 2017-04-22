using GoogleCodeJam.Helpers;
using System;
using System.Linq;

namespace GoogleCodeJam2017.QualificationRound.ProblemB
{
	public class TidyNumbers
	{
		public string Resolve(string input)
		{
			var lines = input.ToLines().ToList();
			lines.RemoveAt(0);

			var results = lines.Select(line =>
			{
				var test = line.ToChunks()[0];
				var numbers = test.Select(c => int.Parse(c.ToString())).ToList();

				var position = 1;
				while (position < numbers.Count)
				{
					var n0 = numbers[position - 1];
					var n1 = numbers[position];

					if (n1 < n0)
					{
						if (n0 == 1)
						{
							numbers = numbers.Skip(1).Select(x => 9).ToList();
							break;
						}
						numbers = numbers.Take(position - 1).Append(n0 - 1).Concat(numbers.Skip(position).Select(x => 9)).ToList();
						position = Math.Max(1, position - 1);
						continue;
					}

					position++;
				}

				return numbers.Select(x => x.ToString()).Join();
			});

			var output = results
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}
	}
}