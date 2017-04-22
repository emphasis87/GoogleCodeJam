using FluentAssertions;
using NUnit.Framework;

namespace GoogleCodeJam2017.QualificationRound.ProblemC.Tests
{
	public class SolverTests
	{
		[Test]
		public void Can_Resolve_sample()
		{
			var sampleIn = @"
5
4 2
5 2
6 2
1000 1000
1000 1".Trim();

			var sampleOut = @"
Case #1: 1 0
Case #2: 1 0
Case #3: 1 1
Case #4: 0 0
Case #5: 500 499".Trim();

			var stalls = new Solver();
			var result = stalls.Resolve(sampleIn);

			result.Should().Be(sampleOut);
		}
	}
}