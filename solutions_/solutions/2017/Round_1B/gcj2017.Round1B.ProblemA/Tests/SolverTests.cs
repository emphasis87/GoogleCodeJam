using FluentAssertions;
using NUnit.Framework;

namespace GoogleCodeJam2017.Round1B.ProblemA.Tests
{
	public class SolverTests
	{
		[Test]
		public void Can_Resolve_sample()
		{
			var sampleIn = @"
3
2525 1
2400 5
300 2
120 60
60 90
100 2
80 100
70 10
".Trim();

			var sampleOut = @"
Case #1: 101.000000
Case #2: 100.000000
Case #3: 33.333333
".Trim();

			var solver = new Solver();
			var result = solver.Resolve(sampleIn);

			result.Should().Be(sampleOut);
		}
	}
}