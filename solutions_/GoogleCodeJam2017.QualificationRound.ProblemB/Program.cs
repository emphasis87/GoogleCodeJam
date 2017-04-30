using GoogleCodeJam;

namespace GoogleCodeJam2017.QualificationRound.ProblemB
{
	public class Program : ProgramBase
	{
		private static int Main(string[] args)
		{
			var tidyNumbers = new TidyNumbers();
			return Execute(args, x => tidyNumbers.Resolve(x));
		}
	}
}