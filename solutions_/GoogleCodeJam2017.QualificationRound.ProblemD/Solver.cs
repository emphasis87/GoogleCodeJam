using GoogleCodeJam.Graphs;
using GoogleCodeJam.Graphs.Algorithms;
using GoogleCodeJam.Helpers;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam2017.QualificationRound.ProblemD
{
	public class Solver
	{
		private int _size;
		private int _score;
		private int[,] _current;
		private int[,] _original;
		private int[,] _modifiable;
		private int[,] _solution;
		private int _modifiableCount;

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
				_size = int.Parse(chunks[0]);
				var modelsCount = int.Parse(chunks[1]);

				_score = 0;

				_original = new int[_size, _size];
				lines.Take(modelsCount).ForEach(l =>
				{
					var ch = l.ToChunks();
					var type = GetModelType(ch[0]);
					var row = int.Parse(ch[1]);
					var col = int.Parse(ch[2]);

					_original[row, col] = type;

					_score += GetStylePoints(type);
				});

				lines.RemoveRange(0, modelsCount);

				_modifiable = new int[_size, _size];
				_solution = new int[_size, _size];
				_current = new int[_size, _size];
				_original.CopyTo(_current, 0);

				var initial = new State(-1, -1, 0, 0, _score);
				var backtraking = new Backtracking<State>(
					expand: Expand);
				var result = backtraking.Begin(initial);

				results.Add("");
			}

			var output = results
				.Select((x, i) => $"Case #{i + 1}: {x}")
				.ToArray();

			return output.JoinLines();
		}

		private IEnumerable<State> Expand(IGraphNode<State> node)
		{
			var current = node.State;

			var row = current.Row == -1 ? 0 : current.Row;
			var col = current.Column == -1 ? 0 : current.Column;

			if (current.Row != -1)
			{
				var value = _current[row, col];
				if (value == 0 && current.CurrentType != 4)
				{
					if (current.CurrentType == 0)
					{
						// TODO check for +
						// count !+ in row and column
						var count = 0;
						for (var x = 0; x < _size; x++)
						{
							var v = _current[x, col];
							if (v == 1 || v == 2)
							{
								count++;
								if (count == 2)
									break;
							}
						}
						if (count < 2)
						{
						}
					}
					else if (current.CurrentType == 1)
					{
						// TODO check for x
					}
					else if (current.CurrentType == 2)
					{
						// TODO check for o
					}
				}
			}

			while (col < _size)
			{
				var value = _current[row, col];
				if (value < 4)
				{
					if (value == 0)
					{
						//
					}
				}

				row++;
				if (row >= _size)
				{
					row = 0;
					col++;
				}
			}
		}

		public class State
		{
			public int Row { get; }
			public int Column { get; }

			public int PreviousType { get; }
			public int CurrentType { get; }

			public int Score { get; }

			public State(int row, int column, int previousType, int currentType, int score)
			{
				Row = row;
				Column = column;
				PreviousType = previousType;
				CurrentType = currentType;
				Score = score;
			}
		}

		private int GetModelType(string symbol)
		{
			switch (symbol)
			{
				case "+":
					return 1;

				case "x":
					return 2;

				case "o":
					return 4;
			}
			return 0;
		}

		private string GetModelSymbol(int type)
		{
			switch (type)
			{
				case 1:
					return "+";

				case 2:
					return "x";

				case 4:
					return "o";
			}
			return ".";
		}

		private int GetStylePoints(int type)
		{
			switch (type)
			{
				case 1:
				case 2:
					return 1;

				case 4:
					return 2;
			}
			return 0;
		}
	}
}