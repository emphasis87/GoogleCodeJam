using FluentAssertions;
using NUnit.Framework;

namespace GoogleCodeJam.Problem.Tests
{
	[Timeout(15000)]
	public class SolverTests
	{
		[Test]
		public void Can_Resolve_sample()
		{
			var sampleIn = @"

".Trim();

			var sampleOut = @"

".Trim();

			var solver = new Solver();
			var result = solver.Solve(sampleIn);

			result.Should().Be(sampleOut);
		}
	}
}