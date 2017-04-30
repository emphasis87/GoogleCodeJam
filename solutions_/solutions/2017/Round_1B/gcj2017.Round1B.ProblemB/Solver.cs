using GoogleCodeJam.Helpers;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gcj2017.Round1B.ProblemB
{
	public class Solver
	{
		private static int Mod(int x, int m)
		{
			var r = x % m;
			return r < 0 ? r + m : r;
		}

		public string Resolve(string input)
		{
			var lines = input.ToLines().ToList();
			lines.RemoveAt(0);

			var results = new List<string>();

			lines.ForEach(line =>
			{
				var c = line.ToChunks();
				var n = int.Parse(c[0]);
				var r = int.Parse(c[1]);
				var o = int.Parse(c[2]);
				var y = int.Parse(c[3]);
				var g = int.Parse(c[4]);
				var b = int.Parse(c[5]);
				var v = int.Parse(c[6]);

				var unicorns = new[]
					{
						Enumerable.Range(0, r).Select(x => new Unicorn(0b100)),
						Enumerable.Range(0, o).Select(x => new Unicorn(0b110)),
						Enumerable.Range(0, y).Select(x => new Unicorn(0b010)),
						Enumerable.Range(0, g).Select(x => new Unicorn(0b011)),
						Enumerable.Range(0, b).Select(x => new Unicorn(0b001)),
						Enumerable.Range(0, v).Select(x => new Unicorn(0b101)),
					}.SelectMany(x => x)
					.ToList();

				unicorns.Shuffle();

				while (true)
				{
					var unresolved = unicorns.Select((u, i) =>
						{
							var u1 = unicorns[Mod(i - 1, n)];
							var u2 = unicorns[Mod(i + 1, n)];
							var success = u.Success(u1, u2);

							return new {Unicorn = u, Left = u1, Right = u2, Success = success, Index = i};
						})
						.Where(x => x.Success != 0)
						.OrderByDescending(x => x.Success)
						.ToArray();

					var swapped = new HashSet<int>();

					unresolved.ForEach(x =>
					{
						var m0 = x.Success;
						var gain = 0;
						var index = x.Index;

						for (var i = 0; i < n -1; i++)
						{
							index = Mod(index + 1, n);

							var ul = unicorns[Mod(index - 1, n)];
							var u0 = unicorns[index];
							var ur = unicorns[Mod(index + 1, n)];

							var t0 = u0.Success(ul, ur);
							int t1, m1;
							if (i == 0 || i == n - 2)
							{
								m1 = x.Unicorn.Success(ur, u0);
								t1 = u0.Success(x.Left, x.Unicorn);
							}
							else
							{
								m1 = x.Unicorn.Success(ul, ur);
								t1 = u0.Success(x.Left, x.Right);
							}

							var gain1 = m0 + t0 - (m1 + t1);
							if (gain1 > gain)
							{
								gain = gain1;

								if (swapped.Contains(x.Index) ||
								    swapped.Contains(x.Index+1) ||
								    swapped.Contains(x.Index-1) ||
								    swapped.Contains(index)||
								    swapped.Contains(index+1)||
								    swapped.Contains(index-1))
									continue;

								swapped.Add(x.Index);
								swapped.Add(index);

								unicorns[x.Index] = u0;
								unicorns[index] = x.Unicorn;
								break;
							}
						}
					});

					if (unresolved.Length == 0)
						break;

					if (swapped.Count != 0)
						continue;

					results.Add("IMPOSSIBLE");
					return;
				}

				results.Add(unicorns.Select(x => x.ToColor()).Join());
			});

			var output = results
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}

		public class Unicorn
		{
			public int Color { get; set; }

			public Unicorn(int color)
			{
				Color = color;
			}

			public bool IsSameColor(Unicorn other)
			{
				return (Color & other.Color) != 0;
			}

			public int Success(Unicorn one, Unicorn two)
			{
				return (IsSameColor(one) ? 1 : 0) + (IsSameColor(two) ? 1 : 0);
			}

			public string ToColor()
			{
				switch (Color)
				{
					case 0b100: return "R";
					case 0b010: return "Y";
					case 0b001: return "B";
					case 0b110: return "O";
					case 0b011: return "G";
					case 0b101: return "V";
				}
				throw new ArgumentException();
			}
		}
	}
}