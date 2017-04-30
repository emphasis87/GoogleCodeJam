using FluentAssertions;
using NUnit.Framework;

namespace gcj2017.Round1B.ProblemC.Tests
{
	public class SolverTests
	{
		[Test]
		public void Can_Resolve_sample()
		{
			var sampleIn = @"
3
2 0
1 1
o 1 1
3 4
+ 2 3
+ 2 1
x 3 1
+ 2 2
".Trim();

			var sampleOut = @"
Case #1: 4 3
o 2 2
+ 2 1
x 1 1
Case #2: 2 0
Case #3: 6 2
o 2 3
x 1 2
".Trim();

			var solver = new Solver();
			var result = solver.Resolve(sampleIn);

			result.Should().Be(sampleOut);
		}
	}
}