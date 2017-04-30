using FluentAssertions;
using NUnit.Framework;

namespace GoogleCodeJam2017.QualificationRound.ProblemB.Tests
{
	public class TidyNumbersTests
	{
		[Test]
		public void Can_Resolve_sample()
		{
			var sampleIn = @"
4
132
1000
7
111111111111111110".Trim();

			var sampleOut = @"
Case #1: 129
Case #2: 999
Case #3: 7
Case #4: 99999999999999999".Trim();

			var numbers = new TidyNumbers();
			var result = numbers.Resolve(sampleIn);

			result.Should().Be(sampleOut);
		}
	}
}