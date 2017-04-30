using FluentAssertions;
using NUnit.Framework;

namespace gcj2017.Round1B.ProblemB.Tests
{
	public class SolverTests
	{
		[Test]
		public void Can_Resolve_sample()
		{
			var sampleIn = @"
4
6 2 0 2 0 2 0
3 1 0 2 0 0 0
6 2 0 1 1 2 0
4 0 0 2 0 0 2
".Trim();

			var sampleOut = @"
Case #1: RYBRBY
Case #2: IMPOSSIBLE
Case #3: YBRGRB
Case #4: YVYV
".Trim();

			var solver = new Solver();
			var result = solver.Resolve(sampleIn);

			result.Should().Be(sampleOut);
		}
	}
}